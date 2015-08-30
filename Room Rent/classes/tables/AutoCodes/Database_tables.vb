'Class Version : 1.0.0.2
'Created Dated : 29/08/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Imports System.Data



Public Class Database_Table_code_class_tblWorkers
Public Shared tablename As String = "tblWorkers"


Structure Fields


    Dim WorkerID_ as int32
    Dim WorkerName_ as string
    Dim DC_Date_ as datetime
    Dim Started_Date_ as datetime
    Dim Email_ as string
    Dim MobileNo_ as string
    Dim PreferredContactMethod_ as string
    Dim AdditionalInfo_ as string
    Dim Status_ as string
    Dim CheckInRoomNo_ as string
    Dim CheckInDate_ as datetime
    Dim CheckInID_ as int32
    Dim dc_file_ as byte()
    Dim dc_file_ext_ as string
    Dim dc_file_name_ as string
    Dim NotAvailableTill_ as datetime
    Dim AvailabilityComment_ as string
    Dim RealName_ as string
    Dim DOB_ as datetime
    Dim Nation_ as string
    Dim IsEscort_ as string

End Structure


Enum FieldName


    [WorkerID]
    [WorkerName]
    [DC_Date]
    [Started_Date]
    [Email]
    [MobileNo]
    [PreferredContactMethod]
    [AdditionalInfo]
    [Status]
    [CheckInRoomNo]
    [CheckInDate]
    [CheckInID]
    [dc_file]
    [dc_file_ext]
    [dc_file_name]
    [NotAvailableTill]
    [AvailabilityComment]
    [RealName]
    [DOB]
    [Nation]
    [IsEscort]

End Enum


Public ReadOnly Property tblWorkers_insert
Get
Return <tblWorkers_insert><![CDATA[
  INSERT INTO [tblWorkers]
  (
      [WorkerID],
      [WorkerName],
      [DC_Date],
      [Started_Date],
      [Email],
      [MobileNo],
      [PreferredContactMethod],
      [AdditionalInfo],
      [Status],
      [CheckInRoomNo],
      [CheckInDate],
      [CheckInID],
      [dc_file],
      [dc_file_ext],
      [dc_file_name],
      [NotAvailableTill],
      [AvailabilityComment],
      [RealName],
      [DOB],
      [Nation],
      [IsEscort]
  )
  VALUES
  (
      @WorkerID_,
      @WorkerName_,
      @DC_Date_,
      @Started_Date_,
      @Email_,
      @MobileNo_,
      @PreferredContactMethod_,
      @AdditionalInfo_,
      @Status_,
      @CheckInRoomNo_,
      @CheckInDate_,
      @CheckInID_,
      @dc_file_,
      @dc_file_ext_,
      @dc_file_name_,
      @NotAvailableTill_,
      @AvailabilityComment_,
      @RealName_,
      @DOB_,
      @Nation_,
      @IsEscort_
  )
]]></tblWorkers_insert>.Value
End Get
End Property


Private ReadOnly Property tblWorkers_update
Get
Return <tblWorkers_update><![CDATA[
UPDATE [tblWorkers]
Set 
    [WorkerName]=@WorkerName_,
    [DC_Date]=@DC_Date_,
    [Started_Date]=@Started_Date_,
    [Email]=@Email_,
    [MobileNo]=@MobileNo_,
    [PreferredContactMethod]=@PreferredContactMethod_,
    [AdditionalInfo]=@AdditionalInfo_,
    [Status]=@Status_,
    [CheckInRoomNo]=@CheckInRoomNo_,
    [CheckInDate]=@CheckInDate_,
    [CheckInID]=@CheckInID_,
    [dc_file]=@dc_file_,
    [dc_file_ext]=@dc_file_ext_,
    [dc_file_name]=@dc_file_name_,
    [NotAvailableTill]=@NotAvailableTill_,
    [AvailabilityComment]=@AvailabilityComment_,
    [RealName]=@RealName_,
    [DOB]=@DOB_,
    [Nation]=@Nation_,
    [IsEscort]=@IsEscort_
 WHERE [WorkerID]=@WorkerID_
]]></tblWorkers_update>.Value
End Get
End Property


Public ReadOnly Property tblWorkers_select
Get
Return <tblWorkers_select><![CDATA[
SELECT 
      [WorkerID],
      [WorkerName],
      [DC_Date],
      [Started_Date],
      [Email],
      [MobileNo],
      [PreferredContactMethod],
      [AdditionalInfo],
      [Status],
      [CheckInRoomNo],
      [CheckInDate],
      [CheckInID],
      [dc_file],
      [dc_file_ext],
      [dc_file_name],
      [NotAvailableTill],
      [AvailabilityComment],
      [RealName],
      [DOB],
      [Nation],
      [IsEscort]
FROM [tblWorkers]
    WHERE 1=1
]]></tblWorkers_select>.Value
End Get
End Property


Private ReadOnly Property tblWorkers_Delete_By_RowID
Get
Return <tblWorkers_Delete_By_RowID><![CDATA[
DELETE FROM [tblWorkers] WHERE [WorkerID]=@WorkerID_
]]></tblWorkers_Delete_By_RowID>.Value
End Get
End Property


Private ReadOnly Property tblWorkers_Delete_By_SELECT
Get
Return <tblWorkers_Delete_By_SELECT><![CDATA[
DELETE FROM [tblWorkers] WHERE 1=1
]]></tblWorkers_Delete_By_SELECT>.Value
End Get
End Property


Private ReadOnly Property tblWorkers_MAXID
Get
Return <tblWorkers_MAXID><![CDATA[
SELECT MAX([WorkerID]) FROM [tblWorkers] WHERE 1=1
]]></tblWorkers_MAXID>.Value
End Get
 End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblWorkers_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal WorkerName_ As String,
    ByVal DC_Date_ As DateTime,
    ByVal Started_Date_ As DateTime,
    ByVal Email_ As String,
    ByVal MobileNo_ As String,
    ByVal PreferredContactMethod_ As String,
    ByVal AdditionalInfo_ As String,
    ByVal Status_ As String,
    ByVal CheckInRoomNo_ As String,
    ByVal CheckInDate_ As DateTime,
    ByVal CheckInID_ As Int32,
    ByVal dc_file_ As Byte(),
    ByVal dc_file_ext_ As String,
    ByVal dc_file_name_ As String,
    ByVal NotAvailableTill_ As DateTime,
    ByVal AvailabilityComment_ As String,
    ByVal RealName_ As String,
    ByVal DOB_ As DateTime,
    ByVal Nation_ As String,
    ByVal IsEscort_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim WorkerID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblWorkers_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@WorkerName_", WorkerName_)
            .AddWithValue("@DC_Date_", DC_Date_)
            .AddWithValue("@Started_Date_", Started_Date_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@MobileNo_", MobileNo_)
            .AddWithValue("@PreferredContactMethod_", PreferredContactMethod_)
            .AddWithValue("@AdditionalInfo_", AdditionalInfo_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@CheckInRoomNo_", CheckInRoomNo_)
            .AddWithValue("@CheckInDate_", CheckInDate_)
            .AddWithValue("@CheckInID_", CheckInID_)
            .AddWithValue("@dc_file_", dc_file_)
            .AddWithValue("@dc_file_ext_", dc_file_ext_)
            .AddWithValue("@dc_file_name_", dc_file_name_)
            .AddWithValue("@NotAvailableTill_", NotAvailableTill_)
            .AddWithValue("@AvailabilityComment_", AvailabilityComment_)
            .AddWithValue("@RealName_", RealName_)
            .AddWithValue("@DOB_", DOB_)
            .AddWithValue("@Nation_", Nation_)
            .AddWithValue("@IsEscort_", IsEscort_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return WorkerID_
    End Function



    Function Update(
    ByVal WorkerName_ As String,
    ByVal DC_Date_ As DateTime,
    ByVal Started_Date_ As DateTime,
    ByVal Email_ As String,
    ByVal MobileNo_ As String,
    ByVal PreferredContactMethod_ As String,
    ByVal AdditionalInfo_ As String,
    ByVal Status_ As String,
    ByVal CheckInRoomNo_ As String,
    ByVal CheckInDate_ As DateTime,
    ByVal CheckInID_ As Int32,
    ByVal dc_file_ As Byte(),
    ByVal dc_file_ext_ As String,
    ByVal dc_file_name_ As String,
    ByVal NotAvailableTill_ As DateTime,
    ByVal AvailabilityComment_ As String,
    ByVal RealName_ As String,
    ByVal DOB_ As DateTime,
    ByVal Nation_ As String,
    ByVal IsEscort_ As String,
    ByVal WorkerID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblWorkers_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@WorkerName_", WorkerName_)
            .AddWithValue("@DC_Date_", DC_Date_)
            .AddWithValue("@Started_Date_", Started_Date_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@MobileNo_", MobileNo_)
            .AddWithValue("@PreferredContactMethod_", PreferredContactMethod_)
            .AddWithValue("@AdditionalInfo_", AdditionalInfo_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@CheckInRoomNo_", CheckInRoomNo_)
            .AddWithValue("@CheckInDate_", CheckInDate_)
            .AddWithValue("@CheckInID_", CheckInID_)
            .AddWithValue("@dc_file_", dc_file_)
            .AddWithValue("@dc_file_ext_", dc_file_ext_)
            .AddWithValue("@dc_file_name_", dc_file_name_)
            .AddWithValue("@NotAvailableTill_", NotAvailableTill_)
            .AddWithValue("@AvailabilityComment_", AvailabilityComment_)
            .AddWithValue("@RealName_", RealName_)
            .AddWithValue("@DOB_", DOB_)
            .AddWithValue("@Nation_", Nation_)
            .AddWithValue("@IsEscort_", IsEscort_)
            .AddWithValue("@WorkerID_", WorkerID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return WorkerID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.WorkerName
                fn = "WorkerName"
            Case FieldName.DC_Date
                fn = "DC_Date"
            Case FieldName.Started_Date
                fn = "Started_Date"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.MobileNo
                fn = "MobileNo"
            Case FieldName.PreferredContactMethod
                fn = "PreferredContactMethod"
            Case FieldName.AdditionalInfo
                fn = "AdditionalInfo"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.CheckInRoomNo
                fn = "CheckInRoomNo"
            Case FieldName.CheckInDate
                fn = "CheckInDate"
            Case FieldName.CheckInID
                fn = "CheckInID"
            Case FieldName.dc_file
                fn = "dc_file"
            Case FieldName.dc_file_ext
                fn = "dc_file_ext"
            Case FieldName.dc_file_name
                fn = "dc_file_name"
            Case FieldName.NotAvailableTill
                fn = "NotAvailableTill"
            Case FieldName.AvailabilityComment
                fn = "AvailabilityComment"
            Case FieldName.RealName
                fn = "RealName"
            Case FieldName.DOB
                fn = "DOB"
            Case FieldName.Nation
                fn = "Nation"
            Case FieldName.IsEscort
                fn = "IsEscort"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblWorkers] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblWorkers_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal WorkerID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblWorkers_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@WorkerID_", WorkerID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return WorkerID_
    End Function



    Function Selection_One_Row(
    ByVal WorkerID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblWorkers_select & "  AND [WorkerID]=@WorkerID_"

        With comSelection.Parameters
            .AddWithValue("@WorkerID_", WorkerID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("WorkerName") Is DBNull.Value Then : .WorkerName_ = dt.Rows(0).Item("WorkerName") : End If
                If Not dt.Rows(0).Item("DC_Date") Is DBNull.Value Then : .DC_Date_ = dt.Rows(0).Item("DC_Date") : End If
                If Not dt.Rows(0).Item("Started_Date") Is DBNull.Value Then : .Started_Date_ = dt.Rows(0).Item("Started_Date") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
                If Not dt.Rows(0).Item("MobileNo") Is DBNull.Value Then : .MobileNo_ = dt.Rows(0).Item("MobileNo") : End If
                If Not dt.Rows(0).Item("PreferredContactMethod") Is DBNull.Value Then : .PreferredContactMethod_ = dt.Rows(0).Item("PreferredContactMethod") : End If
                If Not dt.Rows(0).Item("AdditionalInfo") Is DBNull.Value Then : .AdditionalInfo_ = dt.Rows(0).Item("AdditionalInfo") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("CheckInRoomNo") Is DBNull.Value Then : .CheckInRoomNo_ = dt.Rows(0).Item("CheckInRoomNo") : End If
                If Not dt.Rows(0).Item("CheckInDate") Is DBNull.Value Then : .CheckInDate_ = dt.Rows(0).Item("CheckInDate") : End If
                If Not dt.Rows(0).Item("CheckInID") Is DBNull.Value Then : .CheckInID_ = dt.Rows(0).Item("CheckInID") : End If
                If Not dt.Rows(0).Item("dc_file") Is DBNull.Value Then : .dc_file_ = dt.Rows(0).Item("dc_file") : End If
                If Not dt.Rows(0).Item("dc_file_ext") Is DBNull.Value Then : .dc_file_ext_ = dt.Rows(0).Item("dc_file_ext") : End If
                If Not dt.Rows(0).Item("dc_file_name") Is DBNull.Value Then : .dc_file_name_ = dt.Rows(0).Item("dc_file_name") : End If
                If Not dt.Rows(0).Item("NotAvailableTill") Is DBNull.Value Then : .NotAvailableTill_ = dt.Rows(0).Item("NotAvailableTill") : End If
                If Not dt.Rows(0).Item("AvailabilityComment") Is DBNull.Value Then : .AvailabilityComment_ = dt.Rows(0).Item("AvailabilityComment") : End If
                If Not dt.Rows(0).Item("RealName") Is DBNull.Value Then : .RealName_ = dt.Rows(0).Item("RealName") : End If
                If Not dt.Rows(0).Item("DOB") Is DBNull.Value Then : .DOB_ = dt.Rows(0).Item("DOB") : End If
                If Not dt.Rows(0).Item("Nation") Is DBNull.Value Then : .Nation_ = dt.Rows(0).Item("Nation") : End If
                If Not dt.Rows(0).Item("IsEscort") Is DBNull.Value Then : .IsEscort_ = dt.Rows(0).Item("IsEscort") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblWorkers_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("WorkerName") Is DBNull.Value Then : .WorkerName_ = dt.Rows(0).Item("WorkerName") : End If
                If Not dt.Rows(0).Item("DC_Date") Is DBNull.Value Then : .DC_Date_ = dt.Rows(0).Item("DC_Date") : End If
                If Not dt.Rows(0).Item("Started_Date") Is DBNull.Value Then : .Started_Date_ = dt.Rows(0).Item("Started_Date") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
                If Not dt.Rows(0).Item("MobileNo") Is DBNull.Value Then : .MobileNo_ = dt.Rows(0).Item("MobileNo") : End If
                If Not dt.Rows(0).Item("PreferredContactMethod") Is DBNull.Value Then : .PreferredContactMethod_ = dt.Rows(0).Item("PreferredContactMethod") : End If
                If Not dt.Rows(0).Item("AdditionalInfo") Is DBNull.Value Then : .AdditionalInfo_ = dt.Rows(0).Item("AdditionalInfo") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("CheckInRoomNo") Is DBNull.Value Then : .CheckInRoomNo_ = dt.Rows(0).Item("CheckInRoomNo") : End If
                If Not dt.Rows(0).Item("CheckInDate") Is DBNull.Value Then : .CheckInDate_ = dt.Rows(0).Item("CheckInDate") : End If
                If Not dt.Rows(0).Item("CheckInID") Is DBNull.Value Then : .CheckInID_ = dt.Rows(0).Item("CheckInID") : End If
                If Not dt.Rows(0).Item("dc_file") Is DBNull.Value Then : .dc_file_ = dt.Rows(0).Item("dc_file") : End If
                If Not dt.Rows(0).Item("dc_file_ext") Is DBNull.Value Then : .dc_file_ext_ = dt.Rows(0).Item("dc_file_ext") : End If
                If Not dt.Rows(0).Item("dc_file_name") Is DBNull.Value Then : .dc_file_name_ = dt.Rows(0).Item("dc_file_name") : End If
                If Not dt.Rows(0).Item("NotAvailableTill") Is DBNull.Value Then : .NotAvailableTill_ = dt.Rows(0).Item("NotAvailableTill") : End If
                If Not dt.Rows(0).Item("AvailabilityComment") Is DBNull.Value Then : .AvailabilityComment_ = dt.Rows(0).Item("AvailabilityComment") : End If
                If Not dt.Rows(0).Item("RealName") Is DBNull.Value Then : .RealName_ = dt.Rows(0).Item("RealName") : End If
                If Not dt.Rows(0).Item("DOB") Is DBNull.Value Then : .DOB_ = dt.Rows(0).Item("DOB") : End If
                If Not dt.Rows(0).Item("Nation") Is DBNull.Value Then : .Nation_ = dt.Rows(0).Item("Nation") : End If
                If Not dt.Rows(0).Item("IsEscort") Is DBNull.Value Then : .IsEscort_ = dt.Rows(0).Item("IsEscort") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.WorkerName
                fn = "WorkerName"
            Case FieldName.DC_Date
                fn = "DC_Date"
            Case FieldName.Started_Date
                fn = "Started_Date"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.MobileNo
                fn = "MobileNo"
            Case FieldName.PreferredContactMethod
                fn = "PreferredContactMethod"
            Case FieldName.AdditionalInfo
                fn = "AdditionalInfo"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.CheckInRoomNo
                fn = "CheckInRoomNo"
            Case FieldName.CheckInDate
                fn = "CheckInDate"
            Case FieldName.CheckInID
                fn = "CheckInID"
            Case FieldName.dc_file
                fn = "dc_file"
            Case FieldName.dc_file_ext
                fn = "dc_file_ext"
            Case FieldName.dc_file_name
                fn = "dc_file_name"
            Case FieldName.NotAvailableTill
                fn = "NotAvailableTill"
            Case FieldName.AvailabilityComment
                fn = "AvailabilityComment"
            Case FieldName.RealName
                fn = "RealName"
            Case FieldName.DOB
                fn = "DOB"
            Case FieldName.Nation
                fn = "Nation"
            Case FieldName.IsEscort
                fn = "IsEscort"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblWorkers] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.WorkerName
                fn = "WorkerName"
            Case FieldName.DC_Date
                fn = "DC_Date"
            Case FieldName.Started_Date
                fn = "Started_Date"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.MobileNo
                fn = "MobileNo"
            Case FieldName.PreferredContactMethod
                fn = "PreferredContactMethod"
            Case FieldName.AdditionalInfo
                fn = "AdditionalInfo"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.CheckInRoomNo
                fn = "CheckInRoomNo"
            Case FieldName.CheckInDate
                fn = "CheckInDate"
            Case FieldName.CheckInID
                fn = "CheckInID"
            Case FieldName.dc_file
                fn = "dc_file"
            Case FieldName.dc_file_ext
                fn = "dc_file_ext"
            Case FieldName.dc_file_name
                fn = "dc_file_name"
            Case FieldName.NotAvailableTill
                fn = "NotAvailableTill"
            Case FieldName.AvailabilityComment
                fn = "AvailabilityComment"
            Case FieldName.RealName
                fn = "RealName"
            Case FieldName.DOB
                fn = "DOB"
            Case FieldName.Nation
                fn = "Nation"
            Case FieldName.IsEscort
                fn = "IsEscort"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblWorkers] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblWorkerFavourites
    Public Shared tablename As String = "tblWorkerFavourites"


    Structure Fields


        Dim ItemId_ As Int32
        Dim WorkerId_ As Int32
        Dim ClientName_ As String
        Dim Mobile_ As String
        Dim Email_ As String
        Dim PreferedContactTime_ As String
        Dim PrefereredContactMethod_ As String

    End Structure


    Enum FieldName


        [ItemId]
        [WorkerId]
        [ClientName]
        [Mobile]
        [Email]
        [PreferedContactTime]
        [PrefereredContactMethod]

    End Enum


    Public ReadOnly Property tblWorkerFavourites_insert
        Get
            Return <tblWorkerFavourites_insert><![CDATA[
  INSERT INTO [tblWorkerFavourites]
  (
      [ItemId],
      [WorkerId],
      [ClientName],
      [Mobile],
      [Email],
      [PreferedContactTime],
      [PrefereredContactMethod]
  )
  VALUES
  (
      @ItemId_,
      @WorkerId_,
      @ClientName_,
      @Mobile_,
      @Email_,
      @PreferedContactTime_,
      @PrefereredContactMethod_
  )
]]></tblWorkerFavourites_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblWorkerFavourites_update
        Get
            Return <tblWorkerFavourites_update><![CDATA[
UPDATE [tblWorkerFavourites]
Set 
    [WorkerId]=@WorkerId_,
    [ClientName]=@ClientName_,
    [Mobile]=@Mobile_,
    [Email]=@Email_,
    [PreferedContactTime]=@PreferedContactTime_,
    [PrefereredContactMethod]=@PrefereredContactMethod_
 WHERE [ItemId]=@ItemId_
]]></tblWorkerFavourites_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblWorkerFavourites_select
        Get
            Return <tblWorkerFavourites_select><![CDATA[
SELECT 
      [ItemId],
      [WorkerId],
      [ClientName],
      [Mobile],
      [Email],
      [PreferedContactTime],
      [PrefereredContactMethod]
FROM [tblWorkerFavourites]
    WHERE 1=1
]]></tblWorkerFavourites_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblWorkerFavourites_Delete_By_RowID
        Get
            Return <tblWorkerFavourites_Delete_By_RowID><![CDATA[
DELETE FROM [tblWorkerFavourites] WHERE [ItemId]=@ItemId_
]]></tblWorkerFavourites_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblWorkerFavourites_Delete_By_SELECT
        Get
            Return <tblWorkerFavourites_Delete_By_SELECT><![CDATA[
DELETE FROM [tblWorkerFavourites] WHERE 1=1
]]></tblWorkerFavourites_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblWorkerFavourites_MAXID
        Get
            Return <tblWorkerFavourites_MAXID><![CDATA[
SELECT MAX([ItemId]) FROM [tblWorkerFavourites] WHERE 1=1
]]></tblWorkerFavourites_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblWorkerFavourites_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal WorkerId_ As Int32,
    ByVal ClientName_ As String,
    ByVal Mobile_ As String,
    ByVal Email_ As String,
    ByVal PreferedContactTime_ As String,
    ByVal PrefereredContactMethod_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblWorkerFavourites_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemId_", ItemId_)
            .AddWithValue("@WorkerId_", WorkerId_)
            .AddWithValue("@ClientName_", ClientName_)
            .AddWithValue("@Mobile_", Mobile_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@PreferedContactTime_", PreferedContactTime_)
            .AddWithValue("@PrefereredContactMethod_", PrefereredContactMethod_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemId_
    End Function



    Function Update(
    ByVal WorkerId_ As Int32,
    ByVal ClientName_ As String,
    ByVal Mobile_ As String,
    ByVal Email_ As String,
    ByVal PreferedContactTime_ As String,
    ByVal PrefereredContactMethod_ As String,
    ByVal ItemId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblWorkerFavourites_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@WorkerId_", WorkerId_)
            .AddWithValue("@ClientName_", ClientName_)
            .AddWithValue("@Mobile_", Mobile_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@PreferedContactTime_", PreferedContactTime_)
            .AddWithValue("@PrefereredContactMethod_", PrefereredContactMethod_)
            .AddWithValue("@ItemId_", ItemId_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ItemId_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.WorkerId
                fn = "WorkerId"
            Case FieldName.ClientName
                fn = "ClientName"
            Case FieldName.Mobile
                fn = "Mobile"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.PreferedContactTime
                fn = "PreferedContactTime"
            Case FieldName.PrefereredContactMethod
                fn = "PrefereredContactMethod"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblWorkerFavourites] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblWorkerFavourites_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ItemId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblWorkerFavourites_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemId_", ItemId_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemId_
    End Function



    Function Selection_One_Row(
    ByVal ItemId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblWorkerFavourites_select & "  AND [ItemId]=@ItemId_"

        With comSelection.Parameters
            .AddWithValue("@ItemId_", ItemId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("WorkerId") Is DBNull.Value Then : .WorkerId_ = dt.Rows(0).Item("WorkerId") : End If
                If Not dt.Rows(0).Item("ClientName") Is DBNull.Value Then : .ClientName_ = dt.Rows(0).Item("ClientName") : End If
                If Not dt.Rows(0).Item("Mobile") Is DBNull.Value Then : .Mobile_ = dt.Rows(0).Item("Mobile") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
                If Not dt.Rows(0).Item("PreferedContactTime") Is DBNull.Value Then : .PreferedContactTime_ = dt.Rows(0).Item("PreferedContactTime") : End If
                If Not dt.Rows(0).Item("PrefereredContactMethod") Is DBNull.Value Then : .PrefereredContactMethod_ = dt.Rows(0).Item("PrefereredContactMethod") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblWorkerFavourites_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ItemId") Is DBNull.Value Then : .ItemId_ = dt.Rows(0).Item("ItemId") : End If
                If Not dt.Rows(0).Item("WorkerId") Is DBNull.Value Then : .WorkerId_ = dt.Rows(0).Item("WorkerId") : End If
                If Not dt.Rows(0).Item("ClientName") Is DBNull.Value Then : .ClientName_ = dt.Rows(0).Item("ClientName") : End If
                If Not dt.Rows(0).Item("Mobile") Is DBNull.Value Then : .Mobile_ = dt.Rows(0).Item("Mobile") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
                If Not dt.Rows(0).Item("PreferedContactTime") Is DBNull.Value Then : .PreferedContactTime_ = dt.Rows(0).Item("PreferedContactTime") : End If
                If Not dt.Rows(0).Item("PrefereredContactMethod") Is DBNull.Value Then : .PrefereredContactMethod_ = dt.Rows(0).Item("PrefereredContactMethod") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.WorkerId
                fn = "WorkerId"
            Case FieldName.ClientName
                fn = "ClientName"
            Case FieldName.Mobile
                fn = "Mobile"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.PreferedContactTime
                fn = "PreferedContactTime"
            Case FieldName.PrefereredContactMethod
                fn = "PrefereredContactMethod"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblWorkerFavourites] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemId
                fn = "ItemId"
            Case FieldName.WorkerId
                fn = "WorkerId"
            Case FieldName.ClientName
                fn = "ClientName"
            Case FieldName.Mobile
                fn = "Mobile"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.PreferedContactTime
                fn = "PreferedContactTime"
            Case FieldName.PrefereredContactMethod
                fn = "PrefereredContactMethod"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblWorkerFavourites] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblVouchers
    Public Shared tablename As String = "tblVouchers"


    Structure Fields


        Dim VoucherId_ As Int32
        Dim RefNo_ As String
        Dim VoucherDate_ As DateTime
        Dim Valid_ As Int32
        Dim VoucherValue_ As Int32
        Dim Comment_ As String
        Dim Status_ As String
        Dim Type_ As String

    End Structure


    Enum FieldName


        [VoucherId]
        [RefNo]
        [VoucherDate]
        [Valid]
        [VoucherValue]
        [Comment]
        [Status]
        [Type]

    End Enum


    Public ReadOnly Property tblVouchers_insert
        Get
            Return <tblVouchers_insert><![CDATA[
  INSERT INTO [tblVouchers]
  (
      [VoucherId],
      [RefNo],
      [VoucherDate],
      [Valid],
      [VoucherValue],
      [Comment],
      [Status],
      [Type]
  )
  VALUES
  (
      @VoucherId_,
      @RefNo_,
      @VoucherDate_,
      @Valid_,
      @VoucherValue_,
      @Comment_,
      @Status_,
      @Type_
  )
]]></tblVouchers_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblVouchers_update
        Get
            Return <tblVouchers_update><![CDATA[
UPDATE [tblVouchers]
Set 
    [RefNo]=@RefNo_,
    [VoucherDate]=@VoucherDate_,
    [Valid]=@Valid_,
    [VoucherValue]=@VoucherValue_,
    [Comment]=@Comment_,
    [Status]=@Status_,
    [Type]=@Type_
 WHERE [VoucherId]=@VoucherId_
]]></tblVouchers_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblVouchers_select
        Get
            Return <tblVouchers_select><![CDATA[
SELECT 
      [VoucherId],
      [RefNo],
      [VoucherDate],
      [Valid],
      [VoucherValue],
      [Comment],
      [Status],
      [Type]
FROM [tblVouchers]
    WHERE 1=1
]]></tblVouchers_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblVouchers_Delete_By_RowID
        Get
            Return <tblVouchers_Delete_By_RowID><![CDATA[
DELETE FROM [tblVouchers] WHERE [VoucherId]=@VoucherId_
]]></tblVouchers_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblVouchers_Delete_By_SELECT
        Get
            Return <tblVouchers_Delete_By_SELECT><![CDATA[
DELETE FROM [tblVouchers] WHERE 1=1
]]></tblVouchers_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblVouchers_MAXID
        Get
            Return <tblVouchers_MAXID><![CDATA[
SELECT MAX([VoucherId]) FROM [tblVouchers] WHERE 1=1
]]></tblVouchers_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblVouchers_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal RefNo_ As String,
    ByVal VoucherDate_ As DateTime,
    ByVal Valid_ As Int32,
    ByVal VoucherValue_ As Int32,
    ByVal Comment_ As String,
    ByVal Status_ As String,
    ByVal Type_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim VoucherId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblVouchers_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@VoucherId_", VoucherId_)
            .AddWithValue("@RefNo_", RefNo_)
            .AddWithValue("@VoucherDate_", VoucherDate_)
            .AddWithValue("@Valid_", Valid_)
            .AddWithValue("@VoucherValue_", VoucherValue_)
            .AddWithValue("@Comment_", Comment_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Type_", Type_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return VoucherId_
    End Function



    Function Update(
    ByVal RefNo_ As String,
    ByVal VoucherDate_ As DateTime,
    ByVal Valid_ As Int32,
    ByVal VoucherValue_ As Int32,
    ByVal Comment_ As String,
    ByVal Status_ As String,
    ByVal Type_ As String,
    ByVal VoucherId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblVouchers_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@RefNo_", RefNo_)
            .AddWithValue("@VoucherDate_", VoucherDate_)
            .AddWithValue("@Valid_", Valid_)
            .AddWithValue("@VoucherValue_", VoucherValue_)
            .AddWithValue("@Comment_", Comment_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@VoucherId_", VoucherId_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return VoucherId_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.VoucherId
                fn = "VoucherId"
            Case FieldName.RefNo
                fn = "RefNo"
            Case FieldName.VoucherDate
                fn = "VoucherDate"
            Case FieldName.Valid
                fn = "Valid"
            Case FieldName.VoucherValue
                fn = "VoucherValue"
            Case FieldName.Comment
                fn = "Comment"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Type
                fn = "Type"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblVouchers] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblVouchers_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal VoucherId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblVouchers_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@VoucherId_", VoucherId_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return VoucherId_
    End Function



    Function Selection_One_Row(
    ByVal VoucherId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblVouchers_select & "  AND [VoucherId]=@VoucherId_"

        With comSelection.Parameters
            .AddWithValue("@VoucherId_", VoucherId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("VoucherId") Is DBNull.Value Then : .VoucherId_ = dt.Rows(0).Item("VoucherId") : End If
                If Not dt.Rows(0).Item("RefNo") Is DBNull.Value Then : .RefNo_ = dt.Rows(0).Item("RefNo") : End If
                If Not dt.Rows(0).Item("VoucherDate") Is DBNull.Value Then : .VoucherDate_ = dt.Rows(0).Item("VoucherDate") : End If
                If Not dt.Rows(0).Item("Valid") Is DBNull.Value Then : .Valid_ = dt.Rows(0).Item("Valid") : End If
                If Not dt.Rows(0).Item("VoucherValue") Is DBNull.Value Then : .VoucherValue_ = dt.Rows(0).Item("VoucherValue") : End If
                If Not dt.Rows(0).Item("Comment") Is DBNull.Value Then : .Comment_ = dt.Rows(0).Item("Comment") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblVouchers_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("VoucherId") Is DBNull.Value Then : .VoucherId_ = dt.Rows(0).Item("VoucherId") : End If
                If Not dt.Rows(0).Item("RefNo") Is DBNull.Value Then : .RefNo_ = dt.Rows(0).Item("RefNo") : End If
                If Not dt.Rows(0).Item("VoucherDate") Is DBNull.Value Then : .VoucherDate_ = dt.Rows(0).Item("VoucherDate") : End If
                If Not dt.Rows(0).Item("Valid") Is DBNull.Value Then : .Valid_ = dt.Rows(0).Item("Valid") : End If
                If Not dt.Rows(0).Item("VoucherValue") Is DBNull.Value Then : .VoucherValue_ = dt.Rows(0).Item("VoucherValue") : End If
                If Not dt.Rows(0).Item("Comment") Is DBNull.Value Then : .Comment_ = dt.Rows(0).Item("Comment") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.VoucherId
                fn = "VoucherId"
            Case FieldName.RefNo
                fn = "RefNo"
            Case FieldName.VoucherDate
                fn = "VoucherDate"
            Case FieldName.Valid
                fn = "Valid"
            Case FieldName.VoucherValue
                fn = "VoucherValue"
            Case FieldName.Comment
                fn = "Comment"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Type
                fn = "Type"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblVouchers] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.VoucherId
                fn = "VoucherId"
            Case FieldName.RefNo
                fn = "RefNo"
            Case FieldName.VoucherDate
                fn = "VoucherDate"
            Case FieldName.Valid
                fn = "Valid"
            Case FieldName.VoucherValue
                fn = "VoucherValue"
            Case FieldName.Comment
                fn = "Comment"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Type
                fn = "Type"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblVouchers] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblUserRules
    Public Shared tablename As String = "tblUserRules"


    Structure Fields


        Dim ItemSl_ As Int32
        Dim RuleName_ As String
        Dim Enabled_ As Boolean
        Dim CreatedDate_ As DateTime
        Dim UserID_ As Int32

    End Structure


    Enum FieldName


        [ItemSl]
        [RuleName]
        [Enabled]
        [CreatedDate]
        [UserID]

    End Enum


    Public ReadOnly Property tblUserRules_insert
        Get
            Return <tblUserRules_insert><![CDATA[
  INSERT INTO [tblUserRules]
  (
      [ItemSl],
      [RuleName],
      [Enabled],
      [CreatedDate],
      [UserID]
  )
  VALUES
  (
      @ItemSl_,
      @RuleName_,
      @Enabled_,
      @CreatedDate_,
      @UserID_
  )
]]></tblUserRules_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserRules_update
        Get
            Return <tblUserRules_update><![CDATA[
UPDATE [tblUserRules]
Set 
    [RuleName]=@RuleName_,
    [Enabled]=@Enabled_,
    [CreatedDate]=@CreatedDate_,
    [UserID]=@UserID_
 WHERE [ItemSl]=@ItemSl_
]]></tblUserRules_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblUserRules_select
        Get
            Return <tblUserRules_select><![CDATA[
SELECT 
      [ItemSl],
      [RuleName],
      [Enabled],
      [CreatedDate],
      [UserID]
FROM [tblUserRules]
    WHERE 1=1
]]></tblUserRules_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserRules_Delete_By_RowID
        Get
            Return <tblUserRules_Delete_By_RowID><![CDATA[
DELETE FROM [tblUserRules] WHERE [ItemSl]=@ItemSl_
]]></tblUserRules_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserRules_Delete_By_SELECT
        Get
            Return <tblUserRules_Delete_By_SELECT><![CDATA[
DELETE FROM [tblUserRules] WHERE 1=1
]]></tblUserRules_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserRules_MAXID
        Get
            Return <tblUserRules_MAXID><![CDATA[
SELECT MAX([ItemSl]) FROM [tblUserRules] WHERE 1=1
]]></tblUserRules_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblUserRules_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal RuleName_ As String,
    ByVal Enabled_ As Boolean,
    ByVal CreatedDate_ As DateTime,
    ByVal UserID_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblUserRules_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)
            .AddWithValue("@RuleName_", RuleName_)
            .AddWithValue("@Enabled_", Enabled_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@UserID_", UserID_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemSl_
    End Function



    Function Update(
    ByVal RuleName_ As String,
    ByVal Enabled_ As Boolean,
    ByVal CreatedDate_ As DateTime,
    ByVal UserID_ As Int32,
    ByVal ItemSl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblUserRules_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@RuleName_", RuleName_)
            .AddWithValue("@Enabled_", Enabled_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@UserID_", UserID_)
            .AddWithValue("@ItemSl_", ItemSl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ItemSl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.RuleName
                fn = "RuleName"
            Case FieldName.Enabled
                fn = "Enabled"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UserID
                fn = "UserID"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblUserRules] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblUserRules_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ItemSl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblUserRules_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemSl_
    End Function



    Function Selection_One_Row(
    ByVal ItemSl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblUserRules_select & "  AND [ItemSl]=@ItemSl_"

        With comSelection.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("RuleName") Is DBNull.Value Then : .RuleName_ = dt.Rows(0).Item("RuleName") : End If
                If Not dt.Rows(0).Item("Enabled") Is DBNull.Value Then : .Enabled_ = dt.Rows(0).Item("Enabled") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblUserRules_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("RuleName") Is DBNull.Value Then : .RuleName_ = dt.Rows(0).Item("RuleName") : End If
                If Not dt.Rows(0).Item("Enabled") Is DBNull.Value Then : .Enabled_ = dt.Rows(0).Item("Enabled") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.RuleName
                fn = "RuleName"
            Case FieldName.Enabled
                fn = "Enabled"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UserID
                fn = "UserID"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblUserRules] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.RuleName
                fn = "RuleName"
            Case FieldName.Enabled
                fn = "Enabled"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UserID
                fn = "UserID"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblUserRules] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblUserLoginInfo
    Public Shared tablename As String = "tblUserLoginInfo"


    Structure Fields


        Dim ItemSL_ As Int32
        Dim UserID_ As Int32
        Dim LoginDate_ As DateTime
        Dim LogoutDate_ As DateTime

    End Structure


    Enum FieldName


        [ItemSL]
        [UserID]
        [LoginDate]
        [LogoutDate]

    End Enum


    Public ReadOnly Property tblUserLoginInfo_insert
        Get
            Return <tblUserLoginInfo_insert><![CDATA[
  INSERT INTO [tblUserLoginInfo]
  (
      [ItemSL],
      [UserID],
      [LoginDate],
      [LogoutDate]
  )
  VALUES
  (
      @ItemSL_,
      @UserID_,
      @LoginDate_,
      @LogoutDate_
  )
]]></tblUserLoginInfo_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserLoginInfo_update
        Get
            Return <tblUserLoginInfo_update><![CDATA[
UPDATE [tblUserLoginInfo]
Set 
    [UserID]=@UserID_,
    [LoginDate]=@LoginDate_,
    [LogoutDate]=@LogoutDate_
 WHERE [ItemSL]=@ItemSL_
]]></tblUserLoginInfo_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblUserLoginInfo_select
        Get
            Return <tblUserLoginInfo_select><![CDATA[
SELECT 
      [ItemSL],
      [UserID],
      [LoginDate],
      [LogoutDate]
FROM [tblUserLoginInfo]
    WHERE 1=1
]]></tblUserLoginInfo_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserLoginInfo_Delete_By_RowID
        Get
            Return <tblUserLoginInfo_Delete_By_RowID><![CDATA[
DELETE FROM [tblUserLoginInfo] WHERE [ItemSL]=@ItemSL_
]]></tblUserLoginInfo_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserLoginInfo_Delete_By_SELECT
        Get
            Return <tblUserLoginInfo_Delete_By_SELECT><![CDATA[
DELETE FROM [tblUserLoginInfo] WHERE 1=1
]]></tblUserLoginInfo_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserLoginInfo_MAXID
        Get
            Return <tblUserLoginInfo_MAXID><![CDATA[
SELECT MAX([ItemSL]) FROM [tblUserLoginInfo] WHERE 1=1
]]></tblUserLoginInfo_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblUserLoginInfo_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal UserID_ As Int32,
    ByVal LoginDate_ As DateTime,
    ByVal LogoutDate_ As DateTime,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSL_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblUserLoginInfo_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSL_", ItemSL_)
            .AddWithValue("@UserID_", UserID_)
            .AddWithValue("@LoginDate_", LoginDate_)
            .AddWithValue("@LogoutDate_", LogoutDate_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemSL_
    End Function



    Function Update(
    ByVal UserID_ As Int32,
    ByVal LoginDate_ As DateTime,
    ByVal LogoutDate_ As DateTime,
    ByVal ItemSL_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblUserLoginInfo_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@UserID_", UserID_)
            .AddWithValue("@LoginDate_", LoginDate_)
            .AddWithValue("@LogoutDate_", LogoutDate_)
            .AddWithValue("@ItemSL_", ItemSL_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ItemSL_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSL
                fn = "ItemSL"
            Case FieldName.UserID
                fn = "UserID"
            Case FieldName.LoginDate
                fn = "LoginDate"
            Case FieldName.LogoutDate
                fn = "LogoutDate"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblUserLoginInfo] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblUserLoginInfo_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ItemSL_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblUserLoginInfo_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSL_", ItemSL_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemSL_
    End Function



    Function Selection_One_Row(
    ByVal ItemSL_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblUserLoginInfo_select & "  AND [ItemSL]=@ItemSL_"

        With comSelection.Parameters
            .AddWithValue("@ItemSL_", ItemSL_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSL") Is DBNull.Value Then : .ItemSL_ = dt.Rows(0).Item("ItemSL") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
                If Not dt.Rows(0).Item("LoginDate") Is DBNull.Value Then : .LoginDate_ = dt.Rows(0).Item("LoginDate") : End If
                If Not dt.Rows(0).Item("LogoutDate") Is DBNull.Value Then : .LogoutDate_ = dt.Rows(0).Item("LogoutDate") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblUserLoginInfo_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ItemSL") Is DBNull.Value Then : .ItemSL_ = dt.Rows(0).Item("ItemSL") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
                If Not dt.Rows(0).Item("LoginDate") Is DBNull.Value Then : .LoginDate_ = dt.Rows(0).Item("LoginDate") : End If
                If Not dt.Rows(0).Item("LogoutDate") Is DBNull.Value Then : .LogoutDate_ = dt.Rows(0).Item("LogoutDate") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSL
                fn = "ItemSL"
            Case FieldName.UserID
                fn = "UserID"
            Case FieldName.LoginDate
                fn = "LoginDate"
            Case FieldName.LogoutDate
                fn = "LogoutDate"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblUserLoginInfo] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSL
                fn = "ItemSL"
            Case FieldName.UserID
                fn = "UserID"
            Case FieldName.LoginDate
                fn = "LoginDate"
            Case FieldName.LogoutDate
                fn = "LogoutDate"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblUserLoginInfo] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblUserDetails
    Public Shared tablename As String = "tblUserDetails"


    Structure Fields


        Dim UserId_ As Int32
        Dim BranchID_ As Int32
        Dim UserName_ As String
        Dim Password_ As String
        Dim UserType_ As String
        Dim Status_ As String
        Dim Enable_ As Boolean
        Dim LastLoginDate_ As DateTime
        Dim EnabledDate_ As DateTime
        Dim CreatedDate_ As DateTime
        Dim CreatedBy_ As Int32
        Dim UpdatedDate_ As DateTime
        Dim UpdatedBy_ As Int32
        Dim Session_ As String
        Dim FullName_ As String
        Dim Address_ As String
        Dim City_ As String
        Dim State_ As String
        Dim Zip_ As String
        Dim Phone_ As String
        Dim Email_ As String

    End Structure


    Enum FieldName


        [UserId]
        [BranchID]
        [UserName]
        [Password]
        [UserType]
        [Status]
        [Enable]
        [LastLoginDate]
        [EnabledDate]
        [CreatedDate]
        [CreatedBy]
        [UpdatedDate]
        [UpdatedBy]
        [Session]
        [FullName]
        [Address]
        [City]
        [State]
        [Zip]
        [Phone]
        [Email]

    End Enum


    Public ReadOnly Property tblUserDetails_insert
        Get
            Return <tblUserDetails_insert><![CDATA[
  INSERT INTO [tblUserDetails]
  (
      [UserId],
      [BranchID],
      [UserName],
      [Password],
      [UserType],
      [Status],
      [Enable],
      [LastLoginDate],
      [EnabledDate],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Session],
      [FullName],
      [Address],
      [City],
      [State],
      [Zip],
      [Phone],
      [Email]
  )
  VALUES
  (
      @UserId_,
      @BranchID_,
      @UserName_,
      @Password_,
      @UserType_,
      @Status_,
      @Enable_,
      @LastLoginDate_,
      @EnabledDate_,
      @CreatedDate_,
      @CreatedBy_,
      @UpdatedDate_,
      @UpdatedBy_,
      @Session_,
      @FullName_,
      @Address_,
      @City_,
      @State_,
      @Zip_,
      @Phone_,
      @Email_
  )
]]></tblUserDetails_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserDetails_update
        Get
            Return <tblUserDetails_update><![CDATA[
UPDATE [tblUserDetails]
Set 
    [BranchID]=@BranchID_,
    [UserName]=@UserName_,
    [Password]=@Password_,
    [UserType]=@UserType_,
    [Status]=@Status_,
    [Enable]=@Enable_,
    [LastLoginDate]=@LastLoginDate_,
    [EnabledDate]=@EnabledDate_,
    [CreatedDate]=@CreatedDate_,
    [CreatedBy]=@CreatedBy_,
    [UpdatedDate]=@UpdatedDate_,
    [UpdatedBy]=@UpdatedBy_,
    [Session]=@Session_,
    [FullName]=@FullName_,
    [Address]=@Address_,
    [City]=@City_,
    [State]=@State_,
    [Zip]=@Zip_,
    [Phone]=@Phone_,
    [Email]=@Email_
 WHERE [UserId]=@UserId_
]]></tblUserDetails_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblUserDetails_select
        Get
            Return <tblUserDetails_select><![CDATA[
SELECT 
      [UserId],
      [BranchID],
      [UserName],
      [Password],
      [UserType],
      [Status],
      [Enable],
      [LastLoginDate],
      [EnabledDate],
      [CreatedDate],
      [CreatedBy],
      [UpdatedDate],
      [UpdatedBy],
      [Session],
      [FullName],
      [Address],
      [City],
      [State],
      [Zip],
      [Phone],
      [Email]
FROM [tblUserDetails]
    WHERE 1=1
]]></tblUserDetails_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserDetails_Delete_By_RowID
        Get
            Return <tblUserDetails_Delete_By_RowID><![CDATA[
DELETE FROM [tblUserDetails] WHERE [UserId]=@UserId_
]]></tblUserDetails_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserDetails_Delete_By_SELECT
        Get
            Return <tblUserDetails_Delete_By_SELECT><![CDATA[
DELETE FROM [tblUserDetails] WHERE 1=1
]]></tblUserDetails_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblUserDetails_MAXID
        Get
            Return <tblUserDetails_MAXID><![CDATA[
SELECT MAX([UserId]) FROM [tblUserDetails] WHERE 1=1
]]></tblUserDetails_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblUserDetails_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal BranchID_ As Int32,
    ByVal UserName_ As String,
    ByVal Password_ As String,
    ByVal UserType_ As String,
    ByVal Status_ As String,
    ByVal Enable_ As Boolean,
    ByVal LastLoginDate_ As DateTime,
    ByVal EnabledDate_ As DateTime,
    ByVal CreatedDate_ As DateTime,
    ByVal CreatedBy_ As Int32,
    ByVal UpdatedDate_ As DateTime,
    ByVal UpdatedBy_ As Int32,
    ByVal Session_ As String,
    ByVal FullName_ As String,
    ByVal Address_ As String,
    ByVal City_ As String,
    ByVal State_ As String,
    ByVal Zip_ As String,
    ByVal Phone_ As String,
    ByVal Email_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim UserId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblUserDetails_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@BranchID_", BranchID_)
            .AddWithValue("@UserName_", UserName_)
            .AddWithValue("@Password_", Password_)
            .AddWithValue("@UserType_", UserType_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Enable_", Enable_)
            .AddWithValue("@LastLoginDate_", LastLoginDate_)
            .AddWithValue("@EnabledDate_", EnabledDate_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Session_", Session_)
            .AddWithValue("@FullName_", FullName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@City_", City_)
            .AddWithValue("@State_", State_)
            .AddWithValue("@Zip_", Zip_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Email_", Email_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return UserId_
    End Function



    Function Update(
    ByVal BranchID_ As Int32,
    ByVal UserName_ As String,
    ByVal Password_ As String,
    ByVal UserType_ As String,
    ByVal Status_ As String,
    ByVal Enable_ As Boolean,
    ByVal LastLoginDate_ As DateTime,
    ByVal EnabledDate_ As DateTime,
    ByVal CreatedDate_ As DateTime,
    ByVal CreatedBy_ As Int32,
    ByVal UpdatedDate_ As DateTime,
    ByVal UpdatedBy_ As Int32,
    ByVal Session_ As String,
    ByVal FullName_ As String,
    ByVal Address_ As String,
    ByVal City_ As String,
    ByVal State_ As String,
    ByVal Zip_ As String,
    ByVal Phone_ As String,
    ByVal Email_ As String,
    ByVal UserId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblUserDetails_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@BranchID_", BranchID_)
            .AddWithValue("@UserName_", UserName_)
            .AddWithValue("@Password_", Password_)
            .AddWithValue("@UserType_", UserType_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Enable_", Enable_)
            .AddWithValue("@LastLoginDate_", LastLoginDate_)
            .AddWithValue("@EnabledDate_", EnabledDate_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@CreatedBy_", CreatedBy_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdatedBy_", UpdatedBy_)
            .AddWithValue("@Session_", Session_)
            .AddWithValue("@FullName_", FullName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@City_", City_)
            .AddWithValue("@State_", State_)
            .AddWithValue("@Zip_", Zip_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@UserId_", UserId_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return UserId_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.BranchID
                fn = "BranchID"
            Case FieldName.UserName
                fn = "UserName"
            Case FieldName.Password
                fn = "Password"
            Case FieldName.UserType
                fn = "UserType"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Enable
                fn = "Enable"
            Case FieldName.LastLoginDate
                fn = "LastLoginDate"
            Case FieldName.EnabledDate
                fn = "EnabledDate"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblUserDetails] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblUserDetails_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal UserId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblUserDetails_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@UserId_", UserId_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return UserId_
    End Function



    Function Selection_One_Row(
    ByVal UserId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblUserDetails_select & "  AND [UserId]=@UserId_"

        With comSelection.Parameters
            .AddWithValue("@UserId_", UserId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("BranchID") Is DBNull.Value Then : .BranchID_ = dt.Rows(0).Item("BranchID") : End If
                If Not dt.Rows(0).Item("UserName") Is DBNull.Value Then : .UserName_ = dt.Rows(0).Item("UserName") : End If
                If Not dt.Rows(0).Item("Password") Is DBNull.Value Then : .Password_ = dt.Rows(0).Item("Password") : End If
                If Not dt.Rows(0).Item("UserType") Is DBNull.Value Then : .UserType_ = dt.Rows(0).Item("UserType") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Enable") Is DBNull.Value Then : .Enable_ = dt.Rows(0).Item("Enable") : End If
                If Not dt.Rows(0).Item("LastLoginDate") Is DBNull.Value Then : .LastLoginDate_ = dt.Rows(0).Item("LastLoginDate") : End If
                If Not dt.Rows(0).Item("EnabledDate") Is DBNull.Value Then : .EnabledDate_ = dt.Rows(0).Item("EnabledDate") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Session") Is DBNull.Value Then : .Session_ = dt.Rows(0).Item("Session") : End If
                If Not dt.Rows(0).Item("FullName") Is DBNull.Value Then : .FullName_ = dt.Rows(0).Item("FullName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("City") Is DBNull.Value Then : .City_ = dt.Rows(0).Item("City") : End If
                If Not dt.Rows(0).Item("State") Is DBNull.Value Then : .State_ = dt.Rows(0).Item("State") : End If
                If Not dt.Rows(0).Item("Zip") Is DBNull.Value Then : .Zip_ = dt.Rows(0).Item("Zip") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblUserDetails_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("BranchID") Is DBNull.Value Then : .BranchID_ = dt.Rows(0).Item("BranchID") : End If
                If Not dt.Rows(0).Item("UserName") Is DBNull.Value Then : .UserName_ = dt.Rows(0).Item("UserName") : End If
                If Not dt.Rows(0).Item("Password") Is DBNull.Value Then : .Password_ = dt.Rows(0).Item("Password") : End If
                If Not dt.Rows(0).Item("UserType") Is DBNull.Value Then : .UserType_ = dt.Rows(0).Item("UserType") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Enable") Is DBNull.Value Then : .Enable_ = dt.Rows(0).Item("Enable") : End If
                If Not dt.Rows(0).Item("LastLoginDate") Is DBNull.Value Then : .LastLoginDate_ = dt.Rows(0).Item("LastLoginDate") : End If
                If Not dt.Rows(0).Item("EnabledDate") Is DBNull.Value Then : .EnabledDate_ = dt.Rows(0).Item("EnabledDate") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("CreatedBy") Is DBNull.Value Then : .CreatedBy_ = dt.Rows(0).Item("CreatedBy") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdatedBy") Is DBNull.Value Then : .UpdatedBy_ = dt.Rows(0).Item("UpdatedBy") : End If
                If Not dt.Rows(0).Item("Session") Is DBNull.Value Then : .Session_ = dt.Rows(0).Item("Session") : End If
                If Not dt.Rows(0).Item("FullName") Is DBNull.Value Then : .FullName_ = dt.Rows(0).Item("FullName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("City") Is DBNull.Value Then : .City_ = dt.Rows(0).Item("City") : End If
                If Not dt.Rows(0).Item("State") Is DBNull.Value Then : .State_ = dt.Rows(0).Item("State") : End If
                If Not dt.Rows(0).Item("Zip") Is DBNull.Value Then : .Zip_ = dt.Rows(0).Item("Zip") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.BranchID
                fn = "BranchID"
            Case FieldName.UserName
                fn = "UserName"
            Case FieldName.Password
                fn = "Password"
            Case FieldName.UserType
                fn = "UserType"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Enable
                fn = "Enable"
            Case FieldName.LastLoginDate
                fn = "LastLoginDate"
            Case FieldName.EnabledDate
                fn = "EnabledDate"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblUserDetails] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.BranchID
                fn = "BranchID"
            Case FieldName.UserName
                fn = "UserName"
            Case FieldName.Password
                fn = "Password"
            Case FieldName.UserType
                fn = "UserType"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Enable
                fn = "Enable"
            Case FieldName.LastLoginDate
                fn = "LastLoginDate"
            Case FieldName.EnabledDate
                fn = "EnabledDate"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.CreatedBy
                fn = "CreatedBy"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdatedBy
                fn = "UpdatedBy"
            Case FieldName.Session
                fn = "Session"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.City
                fn = "City"
            Case FieldName.State
                fn = "State"
            Case FieldName.Zip
                fn = "Zip"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblUserDetails] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblStock
    Public Shared tablename As String = "tblStock"


    Structure Fields


        Dim StockId_ As Int32
        Dim ProductID_ As Int32
        Dim Qty_ As Int32
        Dim Price_ As Int32
        Dim Tax_ As Int32
        Dim Discount_ As Int32
        Dim Type_ As String
        Dim TrasactionId_ As Int32
        Dim TrasactionType_ As String

    End Structure


    Enum FieldName


        [StockId]
        [ProductID]
        [Qty]
        [Price]
        [Tax]
        [Discount]
        [Type]
        [TrasactionId]
        [TrasactionType]

    End Enum


    Public ReadOnly Property tblStock_insert
        Get
            Return <tblStock_insert><![CDATA[
  INSERT INTO [tblStock]
  (
      [StockId],
      [ProductID],
      [Qty],
      [Price],
      [Tax],
      [Discount],
      [Type],
      [TrasactionId],
      [TrasactionType]
  )
  VALUES
  (
      @StockId_,
      @ProductID_,
      @Qty_,
      @Price_,
      @Tax_,
      @Discount_,
      @Type_,
      @TrasactionId_,
      @TrasactionType_
  )
]]></tblStock_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblStock_update
        Get
            Return <tblStock_update><![CDATA[
UPDATE [tblStock]
Set 
    [ProductID]=@ProductID_,
    [Qty]=@Qty_,
    [Price]=@Price_,
    [Tax]=@Tax_,
    [Discount]=@Discount_,
    [Type]=@Type_,
    [TrasactionId]=@TrasactionId_,
    [TrasactionType]=@TrasactionType_
 WHERE [StockId]=@StockId_
]]></tblStock_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblStock_select
        Get
            Return <tblStock_select><![CDATA[
SELECT 
      [StockId],
      [ProductID],
      [Qty],
      [Price],
      [Tax],
      [Discount],
      [Type],
      [TrasactionId],
      [TrasactionType]
FROM [tblStock]
    WHERE 1=1
]]></tblStock_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblStock_Delete_By_RowID
        Get
            Return <tblStock_Delete_By_RowID><![CDATA[
DELETE FROM [tblStock] WHERE [StockId]=@StockId_
]]></tblStock_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblStock_Delete_By_SELECT
        Get
            Return <tblStock_Delete_By_SELECT><![CDATA[
DELETE FROM [tblStock] WHERE 1=1
]]></tblStock_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblStock_MAXID
        Get
            Return <tblStock_MAXID><![CDATA[
SELECT MAX([StockId]) FROM [tblStock] WHERE 1=1
]]></tblStock_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblStock_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal ProductID_ As Int32,
    ByVal Qty_ As Int32,
    ByVal Price_ As Int32,
    ByVal Tax_ As Int32,
    ByVal Discount_ As Int32,
    ByVal Type_ As String,
    ByVal TrasactionId_ As Int32,
    ByVal TrasactionType_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim StockId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblStock_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@StockId_", StockId_)
            .AddWithValue("@ProductID_", ProductID_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Tax_", Tax_)
            .AddWithValue("@Discount_", Discount_)
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@TrasactionId_", TrasactionId_)
            .AddWithValue("@TrasactionType_", TrasactionType_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return StockId_
    End Function



    Function Update(
    ByVal ProductID_ As Int32,
    ByVal Qty_ As Int32,
    ByVal Price_ As Int32,
    ByVal Tax_ As Int32,
    ByVal Discount_ As Int32,
    ByVal Type_ As String,
    ByVal TrasactionId_ As Int32,
    ByVal TrasactionType_ As String,
    ByVal StockId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblStock_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@ProductID_", ProductID_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Tax_", Tax_)
            .AddWithValue("@Discount_", Discount_)
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@TrasactionId_", TrasactionId_)
            .AddWithValue("@TrasactionType_", TrasactionType_)
            .AddWithValue("@StockId_", StockId_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return StockId_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.StockId
                fn = "StockId"
            Case FieldName.ProductID
                fn = "ProductID"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Tax
                fn = "Tax"
            Case FieldName.Discount
                fn = "Discount"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.TrasactionId
                fn = "TrasactionId"
            Case FieldName.TrasactionType
                fn = "TrasactionType"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblStock] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblStock_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal StockId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblStock_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@StockId_", StockId_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return StockId_
    End Function



    Function Selection_One_Row(
    ByVal StockId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblStock_select & "  AND [StockId]=@StockId_"

        With comSelection.Parameters
            .AddWithValue("@StockId_", StockId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("StockId") Is DBNull.Value Then : .StockId_ = dt.Rows(0).Item("StockId") : End If
                If Not dt.Rows(0).Item("ProductID") Is DBNull.Value Then : .ProductID_ = dt.Rows(0).Item("ProductID") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Tax") Is DBNull.Value Then : .Tax_ = dt.Rows(0).Item("Tax") : End If
                If Not dt.Rows(0).Item("Discount") Is DBNull.Value Then : .Discount_ = dt.Rows(0).Item("Discount") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
                If Not dt.Rows(0).Item("TrasactionId") Is DBNull.Value Then : .TrasactionId_ = dt.Rows(0).Item("TrasactionId") : End If
                If Not dt.Rows(0).Item("TrasactionType") Is DBNull.Value Then : .TrasactionType_ = dt.Rows(0).Item("TrasactionType") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblStock_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("StockId") Is DBNull.Value Then : .StockId_ = dt.Rows(0).Item("StockId") : End If
                If Not dt.Rows(0).Item("ProductID") Is DBNull.Value Then : .ProductID_ = dt.Rows(0).Item("ProductID") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Tax") Is DBNull.Value Then : .Tax_ = dt.Rows(0).Item("Tax") : End If
                If Not dt.Rows(0).Item("Discount") Is DBNull.Value Then : .Discount_ = dt.Rows(0).Item("Discount") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
                If Not dt.Rows(0).Item("TrasactionId") Is DBNull.Value Then : .TrasactionId_ = dt.Rows(0).Item("TrasactionId") : End If
                If Not dt.Rows(0).Item("TrasactionType") Is DBNull.Value Then : .TrasactionType_ = dt.Rows(0).Item("TrasactionType") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.StockId
                fn = "StockId"
            Case FieldName.ProductID
                fn = "ProductID"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Tax
                fn = "Tax"
            Case FieldName.Discount
                fn = "Discount"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.TrasactionId
                fn = "TrasactionId"
            Case FieldName.TrasactionType
                fn = "TrasactionType"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblStock] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.StockId
                fn = "StockId"
            Case FieldName.ProductID
                fn = "ProductID"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Tax
                fn = "Tax"
            Case FieldName.Discount
                fn = "Discount"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.TrasactionId
                fn = "TrasactionId"
            Case FieldName.TrasactionType
                fn = "TrasactionType"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblStock] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblShiftFee
    Public Shared tablename As String = "tblShiftFee"


    Structure Fields


        Dim Serial_ As Int32
        Dim Room_ As String
        Dim FeeDate_ As DateTime
        Dim WorkerID_ As Int32
        Dim Amount_ As Int32
        Dim Comment_ As String
        Dim Status_ As String
        Dim Type_ As String

    End Structure


    Enum FieldName


        [Serial]
        [Room]
        [FeeDate]
        [WorkerID]
        [Amount]
        [Comment]
        [Status]
        [Type]

    End Enum


    Public ReadOnly Property tblShiftFee_insert
        Get
            Return <tblShiftFee_insert><![CDATA[
  INSERT INTO [tblShiftFee]
  (
      [Serial],
      [Room],
      [FeeDate],
      [WorkerID],
      [Amount],
      [Comment],
      [Status],
      [Type]
  )
  VALUES
  (
      @Serial_,
      @Room_,
      @FeeDate_,
      @WorkerID_,
      @Amount_,
      @Comment_,
      @Status_,
      @Type_
  )
]]></tblShiftFee_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblShiftFee_update
        Get
            Return <tblShiftFee_update><![CDATA[
UPDATE [tblShiftFee]
Set 
    [Room]=@Room_,
    [FeeDate]=@FeeDate_,
    [WorkerID]=@WorkerID_,
    [Amount]=@Amount_,
    [Comment]=@Comment_,
    [Status]=@Status_,
    [Type]=@Type_
 WHERE [Serial]=@Serial_
]]></tblShiftFee_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblShiftFee_select
        Get
            Return <tblShiftFee_select><![CDATA[
SELECT 
      [Serial],
      [Room],
      [FeeDate],
      [WorkerID],
      [Amount],
      [Comment],
      [Status],
      [Type]
FROM [tblShiftFee]
    WHERE 1=1
]]></tblShiftFee_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblShiftFee_Delete_By_RowID
        Get
            Return <tblShiftFee_Delete_By_RowID><![CDATA[
DELETE FROM [tblShiftFee] WHERE [Serial]=@Serial_
]]></tblShiftFee_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblShiftFee_Delete_By_SELECT
        Get
            Return <tblShiftFee_Delete_By_SELECT><![CDATA[
DELETE FROM [tblShiftFee] WHERE 1=1
]]></tblShiftFee_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblShiftFee_MAXID
        Get
            Return <tblShiftFee_MAXID><![CDATA[
SELECT MAX([Serial]) FROM [tblShiftFee] WHERE 1=1
]]></tblShiftFee_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblShiftFee_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Room_ As String,
    ByVal FeeDate_ As DateTime,
    ByVal WorkerID_ As Int32,
    ByVal Amount_ As Int32,
    ByVal Comment_ As String,
    ByVal Status_ As String,
    ByVal Type_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim Serial_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblShiftFee_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@Serial_", Serial_)
            .AddWithValue("@Room_", Room_)
            .AddWithValue("@FeeDate_", FeeDate_)
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@Amount_", Amount_)
            .AddWithValue("@Comment_", Comment_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Type_", Type_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Serial_
    End Function



    Function Update(
    ByVal Room_ As String,
    ByVal FeeDate_ As DateTime,
    ByVal WorkerID_ As Int32,
    ByVal Amount_ As Int32,
    ByVal Comment_ As String,
    ByVal Status_ As String,
    ByVal Type_ As String,
    ByVal Serial_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblShiftFee_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Room_", Room_)
            .AddWithValue("@FeeDate_", FeeDate_)
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@Amount_", Amount_)
            .AddWithValue("@Comment_", Comment_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@Serial_", Serial_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return Serial_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Serial
                fn = "Serial"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.FeeDate
                fn = "FeeDate"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.Amount
                fn = "Amount"
            Case FieldName.Comment
                fn = "Comment"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Type
                fn = "Type"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblShiftFee] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblShiftFee_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal Serial_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblShiftFee_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@Serial_", Serial_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Serial_
    End Function



    Function Selection_One_Row(
    ByVal Serial_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblShiftFee_select & "  AND [Serial]=@Serial_"

        With comSelection.Parameters
            .AddWithValue("@Serial_", Serial_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Serial") Is DBNull.Value Then : .Serial_ = dt.Rows(0).Item("Serial") : End If
                If Not dt.Rows(0).Item("Room") Is DBNull.Value Then : .Room_ = dt.Rows(0).Item("Room") : End If
                If Not dt.Rows(0).Item("FeeDate") Is DBNull.Value Then : .FeeDate_ = dt.Rows(0).Item("FeeDate") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("Amount") Is DBNull.Value Then : .Amount_ = dt.Rows(0).Item("Amount") : End If
                If Not dt.Rows(0).Item("Comment") Is DBNull.Value Then : .Comment_ = dt.Rows(0).Item("Comment") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblShiftFee_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("Serial") Is DBNull.Value Then : .Serial_ = dt.Rows(0).Item("Serial") : End If
                If Not dt.Rows(0).Item("Room") Is DBNull.Value Then : .Room_ = dt.Rows(0).Item("Room") : End If
                If Not dt.Rows(0).Item("FeeDate") Is DBNull.Value Then : .FeeDate_ = dt.Rows(0).Item("FeeDate") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("Amount") Is DBNull.Value Then : .Amount_ = dt.Rows(0).Item("Amount") : End If
                If Not dt.Rows(0).Item("Comment") Is DBNull.Value Then : .Comment_ = dt.Rows(0).Item("Comment") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Serial
                fn = "Serial"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.FeeDate
                fn = "FeeDate"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.Amount
                fn = "Amount"
            Case FieldName.Comment
                fn = "Comment"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Type
                fn = "Type"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblShiftFee] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Serial
                fn = "Serial"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.FeeDate
                fn = "FeeDate"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.Amount
                fn = "Amount"
            Case FieldName.Comment
                fn = "Comment"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Type
                fn = "Type"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblShiftFee] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblSettings2
    Public Shared tablename As String = "tblSettings2"


    Structure Fields


        Dim ItemSl_ As Int32
        Dim Item_ As String
        Dim Value_ As String

    End Structure


    Enum FieldName


        [ItemSl]
        [Item]
        [Value]

    End Enum


    Public ReadOnly Property tblSettings2_insert
        Get
            Return <tblSettings2_insert><![CDATA[
  INSERT INTO [tblSettings2]
  (
      [ItemSl],
      [Item],
      [Value]
  )
  VALUES
  (
      @ItemSl_,
      @Item_,
      @Value_
  )
]]></tblSettings2_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings2_update
        Get
            Return <tblSettings2_update><![CDATA[
UPDATE [tblSettings2]
Set 
    [Item]=@Item_,
    [Value]=@Value_
 WHERE [ItemSl]=@ItemSl_
]]></tblSettings2_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblSettings2_select
        Get
            Return <tblSettings2_select><![CDATA[
SELECT 
      [ItemSl],
      [Item],
      [Value]
FROM [tblSettings2]
    WHERE 1=1
]]></tblSettings2_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings2_Delete_By_RowID
        Get
            Return <tblSettings2_Delete_By_RowID><![CDATA[
DELETE FROM [tblSettings2] WHERE [ItemSl]=@ItemSl_
]]></tblSettings2_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings2_Delete_By_SELECT
        Get
            Return <tblSettings2_Delete_By_SELECT><![CDATA[
DELETE FROM [tblSettings2] WHERE 1=1
]]></tblSettings2_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings2_MAXID
        Get
            Return <tblSettings2_MAXID><![CDATA[
SELECT MAX([ItemSl]) FROM [tblSettings2] WHERE 1=1
]]></tblSettings2_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblSettings2_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Item_ As String,
    ByVal Value_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblSettings2_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)
            .AddWithValue("@Item_", Item_)
            .AddWithValue("@Value_", Value_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemSl_
    End Function



    Function Update(
    ByVal Item_ As String,
    ByVal Value_ As String,
    ByVal ItemSl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblSettings2_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Item_", Item_)
            .AddWithValue("@Value_", Value_)
            .AddWithValue("@ItemSl_", ItemSl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ItemSl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.Item
                fn = "Item"
            Case FieldName.Value
                fn = "Value"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblSettings2] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblSettings2_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ItemSl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblSettings2_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemSl_
    End Function



    Function Selection_One_Row(
    ByVal ItemSl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblSettings2_select & "  AND [ItemSl]=@ItemSl_"

        With comSelection.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("Item") Is DBNull.Value Then : .Item_ = dt.Rows(0).Item("Item") : End If
                If Not dt.Rows(0).Item("Value") Is DBNull.Value Then : .Value_ = dt.Rows(0).Item("Value") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblSettings2_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("Item") Is DBNull.Value Then : .Item_ = dt.Rows(0).Item("Item") : End If
                If Not dt.Rows(0).Item("Value") Is DBNull.Value Then : .Value_ = dt.Rows(0).Item("Value") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.Item
                fn = "Item"
            Case FieldName.Value
                fn = "Value"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblSettings2] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.Item
                fn = "Item"
            Case FieldName.Value
                fn = "Value"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblSettings2] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblSettings
    Public Shared tablename As String = "tblSettings"


    Structure Fields


        Dim Sl_ As Int32
        Dim CompanyName_ As String
        Dim ReceiptPrinterName_ As String
        Dim CompanyAddress_ As String
        Dim CompanyPhone_ As String
        Dim MemoFooter1_ As String
        Dim MemoFooter2_ As String
        Dim MemoFooter_ As String
        Dim MemoFooter3_ As String
        Dim RoomCharge_ As String
        Dim Password_ As String
        Dim Surcharge_ As Decimal
        Dim SP_Percentage_ As Double
        Dim SP_Percentage_Night_ As Double
        Dim Day_Start_ As String
        Dim Day_End_ As String
        Dim Encryted_ As String
        Dim PassHint_ As String
        Dim SpecialServiceEnabled_ As String
        Dim Eve_start_ As String
        Dim Eve_End_ As String
        Dim Shifts_3_enabled_ As String
        Dim Contra_ As String
        Dim Contra_Password_ As String
        Dim OtherSettings_ As String

    End Structure


    Enum FieldName


        [Sl]
        [CompanyName]
        [ReceiptPrinterName]
        [CompanyAddress]
        [CompanyPhone]
        [MemoFooter1]
        [MemoFooter2]
        [MemoFooter]
        [MemoFooter3]
        [RoomCharge]
        [Password]
        [Surcharge]
        [SP_Percentage]
        [SP_Percentage_Night]
        [Day_Start]
        [Day_End]
        [Encryted]
        [PassHint]
        [SpecialServiceEnabled]
        [Eve_start]
        [Eve_End]
        [Shifts_3_enabled]
        [Contra]
        [Contra_Password]
        [OtherSettings]

    End Enum


    Public ReadOnly Property tblSettings_insert
        Get
            Return <tblSettings_insert><![CDATA[
  INSERT INTO [tblSettings]
  (
      [Sl],
      [CompanyName],
      [ReceiptPrinterName],
      [CompanyAddress],
      [CompanyPhone],
      [MemoFooter1],
      [MemoFooter2],
      [MemoFooter],
      [MemoFooter3],
      [RoomCharge],
      [Password],
      [Surcharge],
      [SP_Percentage],
      [SP_Percentage_Night],
      [Day_Start],
      [Day_End],
      [Encryted],
      [PassHint],
      [SpecialServiceEnabled],
      [Eve_start],
      [Eve_End],
      [Shifts_3_enabled],
      [Contra],
      [Contra_Password],
      [OtherSettings]
  )
  VALUES
  (
      @Sl_,
      @CompanyName_,
      @ReceiptPrinterName_,
      @CompanyAddress_,
      @CompanyPhone_,
      @MemoFooter1_,
      @MemoFooter2_,
      @MemoFooter_,
      @MemoFooter3_,
      @RoomCharge_,
      @Password_,
      @Surcharge_,
      @SP_Percentage_,
      @SP_Percentage_Night_,
      @Day_Start_,
      @Day_End_,
      @Encryted_,
      @PassHint_,
      @SpecialServiceEnabled_,
      @Eve_start_,
      @Eve_End_,
      @Shifts_3_enabled_,
      @Contra_,
      @Contra_Password_,
      @OtherSettings_
  )
]]></tblSettings_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings_update
        Get
            Return <tblSettings_update><![CDATA[
UPDATE [tblSettings]
Set 
    [CompanyName]=@CompanyName_,
    [ReceiptPrinterName]=@ReceiptPrinterName_,
    [CompanyAddress]=@CompanyAddress_,
    [CompanyPhone]=@CompanyPhone_,
    [MemoFooter1]=@MemoFooter1_,
    [MemoFooter2]=@MemoFooter2_,
    [MemoFooter]=@MemoFooter_,
    [MemoFooter3]=@MemoFooter3_,
    [RoomCharge]=@RoomCharge_,
    [Password]=@Password_,
    [Surcharge]=@Surcharge_,
    [SP_Percentage]=@SP_Percentage_,
    [SP_Percentage_Night]=@SP_Percentage_Night_,
    [Day_Start]=@Day_Start_,
    [Day_End]=@Day_End_,
    [Encryted]=@Encryted_,
    [PassHint]=@PassHint_,
    [SpecialServiceEnabled]=@SpecialServiceEnabled_,
    [Eve_start]=@Eve_start_,
    [Eve_End]=@Eve_End_,
    [Shifts_3_enabled]=@Shifts_3_enabled_,
    [Contra]=@Contra_,
    [Contra_Password]=@Contra_Password_,
    [OtherSettings]=@OtherSettings_
 WHERE [Sl]=@Sl_
]]></tblSettings_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblSettings_select
        Get
            Return <tblSettings_select><![CDATA[
SELECT 
      [Sl],
      [CompanyName],
      [ReceiptPrinterName],
      [CompanyAddress],
      [CompanyPhone],
      [MemoFooter1],
      [MemoFooter2],
      [MemoFooter],
      [MemoFooter3],
      [RoomCharge],
      [Password],
      [Surcharge],
      [SP_Percentage],
      [SP_Percentage_Night],
      [Day_Start],
      [Day_End],
      [Encryted],
      [PassHint],
      [SpecialServiceEnabled],
      [Eve_start],
      [Eve_End],
      [Shifts_3_enabled],
      [Contra],
      [Contra_Password],
      [OtherSettings]
FROM [tblSettings]
    WHERE 1=1
]]></tblSettings_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings_Delete_By_RowID
        Get
            Return <tblSettings_Delete_By_RowID><![CDATA[
DELETE FROM [tblSettings] WHERE [Sl]=@Sl_
]]></tblSettings_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings_Delete_By_SELECT
        Get
            Return <tblSettings_Delete_By_SELECT><![CDATA[
DELETE FROM [tblSettings] WHERE 1=1
]]></tblSettings_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblSettings_MAXID
        Get
            Return <tblSettings_MAXID><![CDATA[
SELECT MAX([Sl]) FROM [tblSettings] WHERE 1=1
]]></tblSettings_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblSettings_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal CompanyName_ As String,
    ByVal ReceiptPrinterName_ As String,
    ByVal CompanyAddress_ As String,
    ByVal CompanyPhone_ As String,
    ByVal MemoFooter1_ As String,
    ByVal MemoFooter2_ As String,
    ByVal MemoFooter_ As String,
    ByVal MemoFooter3_ As String,
    ByVal RoomCharge_ As String,
    ByVal Password_ As String,
    ByVal Surcharge_ As Decimal,
    ByVal SP_Percentage_ As Double,
    ByVal SP_Percentage_Night_ As Double,
    ByVal Day_Start_ As String,
    ByVal Day_End_ As String,
    ByVal Encryted_ As String,
    ByVal PassHint_ As String,
    ByVal SpecialServiceEnabled_ As String,
    ByVal Eve_start_ As String,
    ByVal Eve_End_ As String,
    ByVal Shifts_3_enabled_ As String,
    ByVal Contra_ As String,
    ByVal Contra_Password_ As String,
    ByVal OtherSettings_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim Sl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblSettings_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@CompanyName_", CompanyName_)
            .AddWithValue("@ReceiptPrinterName_", ReceiptPrinterName_)
            .AddWithValue("@CompanyAddress_", CompanyAddress_)
            .AddWithValue("@CompanyPhone_", CompanyPhone_)
            .AddWithValue("@MemoFooter1_", MemoFooter1_)
            .AddWithValue("@MemoFooter2_", MemoFooter2_)
            .AddWithValue("@MemoFooter_", MemoFooter_)
            .AddWithValue("@MemoFooter3_", MemoFooter3_)
            .AddWithValue("@RoomCharge_", RoomCharge_)
            .AddWithValue("@Password_", Password_)
            .AddWithValue("@Surcharge_", Surcharge_)
            .AddWithValue("@SP_Percentage_", SP_Percentage_)
            .AddWithValue("@SP_Percentage_Night_", SP_Percentage_Night_)
            .AddWithValue("@Day_Start_", Day_Start_)
            .AddWithValue("@Day_End_", Day_End_)
            .AddWithValue("@Encryted_", Encryted_)
            .AddWithValue("@PassHint_", PassHint_)
            .AddWithValue("@SpecialServiceEnabled_", SpecialServiceEnabled_)
            .AddWithValue("@Eve_start_", Eve_start_)
            .AddWithValue("@Eve_End_", Eve_End_)
            .AddWithValue("@Shifts_3_enabled_", Shifts_3_enabled_)
            .AddWithValue("@Contra_", Contra_)
            .AddWithValue("@Contra_Password_", Contra_Password_)
            .AddWithValue("@OtherSettings_", OtherSettings_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Sl_
    End Function



    Function Update(
    ByVal CompanyName_ As String,
    ByVal ReceiptPrinterName_ As String,
    ByVal CompanyAddress_ As String,
    ByVal CompanyPhone_ As String,
    ByVal MemoFooter1_ As String,
    ByVal MemoFooter2_ As String,
    ByVal MemoFooter_ As String,
    ByVal MemoFooter3_ As String,
    ByVal RoomCharge_ As String,
    ByVal Password_ As String,
    ByVal Surcharge_ As Decimal,
    ByVal SP_Percentage_ As Double,
    ByVal SP_Percentage_Night_ As Double,
    ByVal Day_Start_ As String,
    ByVal Day_End_ As String,
    ByVal Encryted_ As String,
    ByVal PassHint_ As String,
    ByVal SpecialServiceEnabled_ As String,
    ByVal Eve_start_ As String,
    ByVal Eve_End_ As String,
    ByVal Shifts_3_enabled_ As String,
    ByVal Contra_ As String,
    ByVal Contra_Password_ As String,
    ByVal OtherSettings_ As String,
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblSettings_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@CompanyName_", CompanyName_)
            .AddWithValue("@ReceiptPrinterName_", ReceiptPrinterName_)
            .AddWithValue("@CompanyAddress_", CompanyAddress_)
            .AddWithValue("@CompanyPhone_", CompanyPhone_)
            .AddWithValue("@MemoFooter1_", MemoFooter1_)
            .AddWithValue("@MemoFooter2_", MemoFooter2_)
            .AddWithValue("@MemoFooter_", MemoFooter_)
            .AddWithValue("@MemoFooter3_", MemoFooter3_)
            .AddWithValue("@RoomCharge_", RoomCharge_)
            .AddWithValue("@Password_", Password_)
            .AddWithValue("@Surcharge_", Surcharge_)
            .AddWithValue("@SP_Percentage_", SP_Percentage_)
            .AddWithValue("@SP_Percentage_Night_", SP_Percentage_Night_)
            .AddWithValue("@Day_Start_", Day_Start_)
            .AddWithValue("@Day_End_", Day_End_)
            .AddWithValue("@Encryted_", Encryted_)
            .AddWithValue("@PassHint_", PassHint_)
            .AddWithValue("@SpecialServiceEnabled_", SpecialServiceEnabled_)
            .AddWithValue("@Eve_start_", Eve_start_)
            .AddWithValue("@Eve_End_", Eve_End_)
            .AddWithValue("@Shifts_3_enabled_", Shifts_3_enabled_)
            .AddWithValue("@Contra_", Contra_)
            .AddWithValue("@Contra_Password_", Contra_Password_)
            .AddWithValue("@OtherSettings_", OtherSettings_)
            .AddWithValue("@Sl_", Sl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return Sl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.CompanyName
                fn = "CompanyName"
            Case FieldName.ReceiptPrinterName
                fn = "ReceiptPrinterName"
            Case FieldName.CompanyAddress
                fn = "CompanyAddress"
            Case FieldName.CompanyPhone
                fn = "CompanyPhone"
            Case FieldName.MemoFooter1
                fn = "MemoFooter1"
            Case FieldName.MemoFooter2
                fn = "MemoFooter2"
            Case FieldName.MemoFooter
                fn = "MemoFooter"
            Case FieldName.MemoFooter3
                fn = "MemoFooter3"
            Case FieldName.RoomCharge
                fn = "RoomCharge"
            Case FieldName.Password
                fn = "Password"
            Case FieldName.Surcharge
                fn = "Surcharge"
            Case FieldName.SP_Percentage
                fn = "SP_Percentage"
            Case FieldName.SP_Percentage_Night
                fn = "SP_Percentage_Night"
            Case FieldName.Day_Start
                fn = "Day_Start"
            Case FieldName.Day_End
                fn = "Day_End"
            Case FieldName.Encryted
                fn = "Encryted"
            Case FieldName.PassHint
                fn = "PassHint"
            Case FieldName.SpecialServiceEnabled
                fn = "SpecialServiceEnabled"
            Case FieldName.Eve_start
                fn = "Eve_start"
            Case FieldName.Eve_End
                fn = "Eve_End"
            Case FieldName.Shifts_3_enabled
                fn = "Shifts_3_enabled"
            Case FieldName.Contra
                fn = "Contra"
            Case FieldName.Contra_Password
                fn = "Contra_Password"
            Case FieldName.OtherSettings
                fn = "OtherSettings"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblSettings] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblSettings_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblSettings_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@Sl_", Sl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Sl_
    End Function



    Function Selection_One_Row(
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblSettings_select & "  AND [Sl]=@Sl_"

        With comSelection.Parameters
            .AddWithValue("@Sl_", Sl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("CompanyName") Is DBNull.Value Then : .CompanyName_ = dt.Rows(0).Item("CompanyName") : End If
                If Not dt.Rows(0).Item("ReceiptPrinterName") Is DBNull.Value Then : .ReceiptPrinterName_ = dt.Rows(0).Item("ReceiptPrinterName") : End If
                If Not dt.Rows(0).Item("CompanyAddress") Is DBNull.Value Then : .CompanyAddress_ = dt.Rows(0).Item("CompanyAddress") : End If
                If Not dt.Rows(0).Item("CompanyPhone") Is DBNull.Value Then : .CompanyPhone_ = dt.Rows(0).Item("CompanyPhone") : End If
                If Not dt.Rows(0).Item("MemoFooter1") Is DBNull.Value Then : .MemoFooter1_ = dt.Rows(0).Item("MemoFooter1") : End If
                If Not dt.Rows(0).Item("MemoFooter2") Is DBNull.Value Then : .MemoFooter2_ = dt.Rows(0).Item("MemoFooter2") : End If
                If Not dt.Rows(0).Item("MemoFooter") Is DBNull.Value Then : .MemoFooter_ = dt.Rows(0).Item("MemoFooter") : End If
                If Not dt.Rows(0).Item("MemoFooter3") Is DBNull.Value Then : .MemoFooter3_ = dt.Rows(0).Item("MemoFooter3") : End If
                If Not dt.Rows(0).Item("RoomCharge") Is DBNull.Value Then : .RoomCharge_ = dt.Rows(0).Item("RoomCharge") : End If
                If Not dt.Rows(0).Item("Password") Is DBNull.Value Then : .Password_ = dt.Rows(0).Item("Password") : End If
                If Not dt.Rows(0).Item("Surcharge") Is DBNull.Value Then : .Surcharge_ = dt.Rows(0).Item("Surcharge") : End If
                If Not dt.Rows(0).Item("SP_Percentage") Is DBNull.Value Then : .SP_Percentage_ = dt.Rows(0).Item("SP_Percentage") : End If
                If Not dt.Rows(0).Item("SP_Percentage_Night") Is DBNull.Value Then : .SP_Percentage_Night_ = dt.Rows(0).Item("SP_Percentage_Night") : End If
                If Not dt.Rows(0).Item("Day_Start") Is DBNull.Value Then : .Day_Start_ = dt.Rows(0).Item("Day_Start") : End If
                If Not dt.Rows(0).Item("Day_End") Is DBNull.Value Then : .Day_End_ = dt.Rows(0).Item("Day_End") : End If
                If Not dt.Rows(0).Item("Encryted") Is DBNull.Value Then : .Encryted_ = dt.Rows(0).Item("Encryted") : End If
                If Not dt.Rows(0).Item("PassHint") Is DBNull.Value Then : .PassHint_ = dt.Rows(0).Item("PassHint") : End If
                If Not dt.Rows(0).Item("SpecialServiceEnabled") Is DBNull.Value Then : .SpecialServiceEnabled_ = dt.Rows(0).Item("SpecialServiceEnabled") : End If
                If Not dt.Rows(0).Item("Eve_start") Is DBNull.Value Then : .Eve_start_ = dt.Rows(0).Item("Eve_start") : End If
                If Not dt.Rows(0).Item("Eve_End") Is DBNull.Value Then : .Eve_End_ = dt.Rows(0).Item("Eve_End") : End If
                If Not dt.Rows(0).Item("Shifts_3_enabled") Is DBNull.Value Then : .Shifts_3_enabled_ = dt.Rows(0).Item("Shifts_3_enabled") : End If
                If Not dt.Rows(0).Item("Contra") Is DBNull.Value Then : .Contra_ = dt.Rows(0).Item("Contra") : End If
                If Not dt.Rows(0).Item("Contra_Password") Is DBNull.Value Then : .Contra_Password_ = dt.Rows(0).Item("Contra_Password") : End If
                If Not dt.Rows(0).Item("OtherSettings") Is DBNull.Value Then : .OtherSettings_ = dt.Rows(0).Item("OtherSettings") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblSettings_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("CompanyName") Is DBNull.Value Then : .CompanyName_ = dt.Rows(0).Item("CompanyName") : End If
                If Not dt.Rows(0).Item("ReceiptPrinterName") Is DBNull.Value Then : .ReceiptPrinterName_ = dt.Rows(0).Item("ReceiptPrinterName") : End If
                If Not dt.Rows(0).Item("CompanyAddress") Is DBNull.Value Then : .CompanyAddress_ = dt.Rows(0).Item("CompanyAddress") : End If
                If Not dt.Rows(0).Item("CompanyPhone") Is DBNull.Value Then : .CompanyPhone_ = dt.Rows(0).Item("CompanyPhone") : End If
                If Not dt.Rows(0).Item("MemoFooter1") Is DBNull.Value Then : .MemoFooter1_ = dt.Rows(0).Item("MemoFooter1") : End If
                If Not dt.Rows(0).Item("MemoFooter2") Is DBNull.Value Then : .MemoFooter2_ = dt.Rows(0).Item("MemoFooter2") : End If
                If Not dt.Rows(0).Item("MemoFooter") Is DBNull.Value Then : .MemoFooter_ = dt.Rows(0).Item("MemoFooter") : End If
                If Not dt.Rows(0).Item("MemoFooter3") Is DBNull.Value Then : .MemoFooter3_ = dt.Rows(0).Item("MemoFooter3") : End If
                If Not dt.Rows(0).Item("RoomCharge") Is DBNull.Value Then : .RoomCharge_ = dt.Rows(0).Item("RoomCharge") : End If
                If Not dt.Rows(0).Item("Password") Is DBNull.Value Then : .Password_ = dt.Rows(0).Item("Password") : End If
                If Not dt.Rows(0).Item("Surcharge") Is DBNull.Value Then : .Surcharge_ = dt.Rows(0).Item("Surcharge") : End If
                If Not dt.Rows(0).Item("SP_Percentage") Is DBNull.Value Then : .SP_Percentage_ = dt.Rows(0).Item("SP_Percentage") : End If
                If Not dt.Rows(0).Item("SP_Percentage_Night") Is DBNull.Value Then : .SP_Percentage_Night_ = dt.Rows(0).Item("SP_Percentage_Night") : End If
                If Not dt.Rows(0).Item("Day_Start") Is DBNull.Value Then : .Day_Start_ = dt.Rows(0).Item("Day_Start") : End If
                If Not dt.Rows(0).Item("Day_End") Is DBNull.Value Then : .Day_End_ = dt.Rows(0).Item("Day_End") : End If
                If Not dt.Rows(0).Item("Encryted") Is DBNull.Value Then : .Encryted_ = dt.Rows(0).Item("Encryted") : End If
                If Not dt.Rows(0).Item("PassHint") Is DBNull.Value Then : .PassHint_ = dt.Rows(0).Item("PassHint") : End If
                If Not dt.Rows(0).Item("SpecialServiceEnabled") Is DBNull.Value Then : .SpecialServiceEnabled_ = dt.Rows(0).Item("SpecialServiceEnabled") : End If
                If Not dt.Rows(0).Item("Eve_start") Is DBNull.Value Then : .Eve_start_ = dt.Rows(0).Item("Eve_start") : End If
                If Not dt.Rows(0).Item("Eve_End") Is DBNull.Value Then : .Eve_End_ = dt.Rows(0).Item("Eve_End") : End If
                If Not dt.Rows(0).Item("Shifts_3_enabled") Is DBNull.Value Then : .Shifts_3_enabled_ = dt.Rows(0).Item("Shifts_3_enabled") : End If
                If Not dt.Rows(0).Item("Contra") Is DBNull.Value Then : .Contra_ = dt.Rows(0).Item("Contra") : End If
                If Not dt.Rows(0).Item("Contra_Password") Is DBNull.Value Then : .Contra_Password_ = dt.Rows(0).Item("Contra_Password") : End If
                If Not dt.Rows(0).Item("OtherSettings") Is DBNull.Value Then : .OtherSettings_ = dt.Rows(0).Item("OtherSettings") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.CompanyName
                fn = "CompanyName"
            Case FieldName.ReceiptPrinterName
                fn = "ReceiptPrinterName"
            Case FieldName.CompanyAddress
                fn = "CompanyAddress"
            Case FieldName.CompanyPhone
                fn = "CompanyPhone"
            Case FieldName.MemoFooter1
                fn = "MemoFooter1"
            Case FieldName.MemoFooter2
                fn = "MemoFooter2"
            Case FieldName.MemoFooter
                fn = "MemoFooter"
            Case FieldName.MemoFooter3
                fn = "MemoFooter3"
            Case FieldName.RoomCharge
                fn = "RoomCharge"
            Case FieldName.Password
                fn = "Password"
            Case FieldName.Surcharge
                fn = "Surcharge"
            Case FieldName.SP_Percentage
                fn = "SP_Percentage"
            Case FieldName.SP_Percentage_Night
                fn = "SP_Percentage_Night"
            Case FieldName.Day_Start
                fn = "Day_Start"
            Case FieldName.Day_End
                fn = "Day_End"
            Case FieldName.Encryted
                fn = "Encryted"
            Case FieldName.PassHint
                fn = "PassHint"
            Case FieldName.SpecialServiceEnabled
                fn = "SpecialServiceEnabled"
            Case FieldName.Eve_start
                fn = "Eve_start"
            Case FieldName.Eve_End
                fn = "Eve_End"
            Case FieldName.Shifts_3_enabled
                fn = "Shifts_3_enabled"
            Case FieldName.Contra
                fn = "Contra"
            Case FieldName.Contra_Password
                fn = "Contra_Password"
            Case FieldName.OtherSettings
                fn = "OtherSettings"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblSettings] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.CompanyName
                fn = "CompanyName"
            Case FieldName.ReceiptPrinterName
                fn = "ReceiptPrinterName"
            Case FieldName.CompanyAddress
                fn = "CompanyAddress"
            Case FieldName.CompanyPhone
                fn = "CompanyPhone"
            Case FieldName.MemoFooter1
                fn = "MemoFooter1"
            Case FieldName.MemoFooter2
                fn = "MemoFooter2"
            Case FieldName.MemoFooter
                fn = "MemoFooter"
            Case FieldName.MemoFooter3
                fn = "MemoFooter3"
            Case FieldName.RoomCharge
                fn = "RoomCharge"
            Case FieldName.Password
                fn = "Password"
            Case FieldName.Surcharge
                fn = "Surcharge"
            Case FieldName.SP_Percentage
                fn = "SP_Percentage"
            Case FieldName.SP_Percentage_Night
                fn = "SP_Percentage_Night"
            Case FieldName.Day_Start
                fn = "Day_Start"
            Case FieldName.Day_End
                fn = "Day_End"
            Case FieldName.Encryted
                fn = "Encryted"
            Case FieldName.PassHint
                fn = "PassHint"
            Case FieldName.SpecialServiceEnabled
                fn = "SpecialServiceEnabled"
            Case FieldName.Eve_start
                fn = "Eve_start"
            Case FieldName.Eve_End
                fn = "Eve_End"
            Case FieldName.Shifts_3_enabled
                fn = "Shifts_3_enabled"
            Case FieldName.Contra
                fn = "Contra"
            Case FieldName.Contra_Password
                fn = "Contra_Password"
            Case FieldName.OtherSettings
                fn = "OtherSettings"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblSettings] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblAdjustmentReport
    Public Shared tablename As String = "tblAdjustmentReport"


    Structure Fields


        Dim ReportID_ As Int32
        Dim StartDate_ As DateTime
        Dim EndDate_ As DateTime
        Dim TotalCash_ As Decimal
        Dim Card_ As Decimal
        Dim AdminFee_ As Decimal
        Dim Voucher_ As Decimal
        Dim GrandTotal_ As Decimal
        Dim AdjustedSash_ As Decimal
        Dim CreatedDate_ As DateTime
        Dim UserID_ As Int32

    End Structure


    Enum FieldName


        [ReportID]
        [StartDate]
        [EndDate]
        [TotalCash]
        [Card]
        [AdminFee]
        [Voucher]
        [GrandTotal]
        [AdjustedSash]
        [CreatedDate]
        [UserID]

    End Enum


    Public ReadOnly Property tblAdjustmentReport_insert
        Get
            Return <tblAdjustmentReport_insert><![CDATA[
  INSERT INTO [tblAdjustmentReport]
  (
      [ReportID],
      [StartDate],
      [EndDate],
      [TotalCash],
      [Card],
      [AdminFee],
      [Voucher],
      [GrandTotal],
      [AdjustedSash],
      [CreatedDate],
      [UserID]
  )
  VALUES
  (
      @ReportID_,
      @StartDate_,
      @EndDate_,
      @TotalCash_,
      @Card_,
      @AdminFee_,
      @Voucher_,
      @GrandTotal_,
      @AdjustedSash_,
      @CreatedDate_,
      @UserID_
  )
]]></tblAdjustmentReport_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblAdjustmentReport_update
        Get
            Return <tblAdjustmentReport_update><![CDATA[
UPDATE [tblAdjustmentReport]
Set 
    [StartDate]=@StartDate_,
    [EndDate]=@EndDate_,
    [TotalCash]=@TotalCash_,
    [Card]=@Card_,
    [AdminFee]=@AdminFee_,
    [Voucher]=@Voucher_,
    [GrandTotal]=@GrandTotal_,
    [AdjustedSash]=@AdjustedSash_,
    [CreatedDate]=@CreatedDate_,
    [UserID]=@UserID_
 WHERE [ReportID]=@ReportID_
]]></tblAdjustmentReport_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblAdjustmentReport_select
        Get
            Return <tblAdjustmentReport_select><![CDATA[
SELECT 
      [ReportID],
      [StartDate],
      [EndDate],
      [TotalCash],
      [Card],
      [AdminFee],
      [Voucher],
      [GrandTotal],
      [AdjustedSash],
      [CreatedDate],
      [UserID]
FROM [tblAdjustmentReport]
    WHERE 1=1
]]></tblAdjustmentReport_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblAdjustmentReport_Delete_By_RowID
        Get
            Return <tblAdjustmentReport_Delete_By_RowID><![CDATA[
DELETE FROM [tblAdjustmentReport] WHERE [ReportID]=@ReportID_
]]></tblAdjustmentReport_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblAdjustmentReport_Delete_By_SELECT
        Get
            Return <tblAdjustmentReport_Delete_By_SELECT><![CDATA[
DELETE FROM [tblAdjustmentReport] WHERE 1=1
]]></tblAdjustmentReport_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblAdjustmentReport_MAXID
        Get
            Return <tblAdjustmentReport_MAXID><![CDATA[
SELECT MAX([ReportID]) FROM [tblAdjustmentReport] WHERE 1=1
]]></tblAdjustmentReport_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblAdjustmentReport_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal StartDate_ As DateTime,
    ByVal EndDate_ As DateTime,
    ByVal TotalCash_ As Decimal,
    ByVal Card_ As Decimal,
    ByVal AdminFee_ As Decimal,
    ByVal Voucher_ As Decimal,
    ByVal GrandTotal_ As Decimal,
    ByVal AdjustedSash_ As Decimal,
    ByVal CreatedDate_ As DateTime,
    ByVal UserID_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ReportID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblAdjustmentReport_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ReportID_", ReportID_)
            .AddWithValue("@StartDate_", StartDate_)
            .AddWithValue("@EndDate_", EndDate_)
            .AddWithValue("@TotalCash_", TotalCash_)
            .AddWithValue("@Card_", Card_)
            .AddWithValue("@AdminFee_", AdminFee_)
            .AddWithValue("@Voucher_", Voucher_)
            .AddWithValue("@GrandTotal_", GrandTotal_)
            .AddWithValue("@AdjustedSash_", AdjustedSash_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@UserID_", UserID_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ReportID_
    End Function



    Function Update(
    ByVal StartDate_ As DateTime,
    ByVal EndDate_ As DateTime,
    ByVal TotalCash_ As Decimal,
    ByVal Card_ As Decimal,
    ByVal AdminFee_ As Decimal,
    ByVal Voucher_ As Decimal,
    ByVal GrandTotal_ As Decimal,
    ByVal AdjustedSash_ As Decimal,
    ByVal CreatedDate_ As DateTime,
    ByVal UserID_ As Int32,
    ByVal ReportID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblAdjustmentReport_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@StartDate_", StartDate_)
            .AddWithValue("@EndDate_", EndDate_)
            .AddWithValue("@TotalCash_", TotalCash_)
            .AddWithValue("@Card_", Card_)
            .AddWithValue("@AdminFee_", AdminFee_)
            .AddWithValue("@Voucher_", Voucher_)
            .AddWithValue("@GrandTotal_", GrandTotal_)
            .AddWithValue("@AdjustedSash_", AdjustedSash_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@UserID_", UserID_)
            .AddWithValue("@ReportID_", ReportID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ReportID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ReportID
                fn = "ReportID"
            Case FieldName.StartDate
                fn = "StartDate"
            Case FieldName.EndDate
                fn = "EndDate"
            Case FieldName.TotalCash
                fn = "TotalCash"
            Case FieldName.Card
                fn = "Card"
            Case FieldName.AdminFee
                fn = "AdminFee"
            Case FieldName.Voucher
                fn = "Voucher"
            Case FieldName.GrandTotal
                fn = "GrandTotal"
            Case FieldName.AdjustedSash
                fn = "AdjustedSash"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UserID
                fn = "UserID"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblAdjustmentReport] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblAdjustmentReport_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ReportID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblAdjustmentReport_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ReportID_", ReportID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ReportID_
    End Function



    Function Selection_One_Row(
    ByVal ReportID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblAdjustmentReport_select & "  AND [ReportID]=@ReportID_"

        With comSelection.Parameters
            .AddWithValue("@ReportID_", ReportID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ReportID") Is DBNull.Value Then : .ReportID_ = dt.Rows(0).Item("ReportID") : End If
                If Not dt.Rows(0).Item("StartDate") Is DBNull.Value Then : .StartDate_ = dt.Rows(0).Item("StartDate") : End If
                If Not dt.Rows(0).Item("EndDate") Is DBNull.Value Then : .EndDate_ = dt.Rows(0).Item("EndDate") : End If
                If Not dt.Rows(0).Item("TotalCash") Is DBNull.Value Then : .TotalCash_ = dt.Rows(0).Item("TotalCash") : End If
                If Not dt.Rows(0).Item("Card") Is DBNull.Value Then : .Card_ = dt.Rows(0).Item("Card") : End If
                If Not dt.Rows(0).Item("AdminFee") Is DBNull.Value Then : .AdminFee_ = dt.Rows(0).Item("AdminFee") : End If
                If Not dt.Rows(0).Item("Voucher") Is DBNull.Value Then : .Voucher_ = dt.Rows(0).Item("Voucher") : End If
                If Not dt.Rows(0).Item("GrandTotal") Is DBNull.Value Then : .GrandTotal_ = dt.Rows(0).Item("GrandTotal") : End If
                If Not dt.Rows(0).Item("AdjustedSash") Is DBNull.Value Then : .AdjustedSash_ = dt.Rows(0).Item("AdjustedSash") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblAdjustmentReport_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ReportID") Is DBNull.Value Then : .ReportID_ = dt.Rows(0).Item("ReportID") : End If
                If Not dt.Rows(0).Item("StartDate") Is DBNull.Value Then : .StartDate_ = dt.Rows(0).Item("StartDate") : End If
                If Not dt.Rows(0).Item("EndDate") Is DBNull.Value Then : .EndDate_ = dt.Rows(0).Item("EndDate") : End If
                If Not dt.Rows(0).Item("TotalCash") Is DBNull.Value Then : .TotalCash_ = dt.Rows(0).Item("TotalCash") : End If
                If Not dt.Rows(0).Item("Card") Is DBNull.Value Then : .Card_ = dt.Rows(0).Item("Card") : End If
                If Not dt.Rows(0).Item("AdminFee") Is DBNull.Value Then : .AdminFee_ = dt.Rows(0).Item("AdminFee") : End If
                If Not dt.Rows(0).Item("Voucher") Is DBNull.Value Then : .Voucher_ = dt.Rows(0).Item("Voucher") : End If
                If Not dt.Rows(0).Item("GrandTotal") Is DBNull.Value Then : .GrandTotal_ = dt.Rows(0).Item("GrandTotal") : End If
                If Not dt.Rows(0).Item("AdjustedSash") Is DBNull.Value Then : .AdjustedSash_ = dt.Rows(0).Item("AdjustedSash") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("UserID") Is DBNull.Value Then : .UserID_ = dt.Rows(0).Item("UserID") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ReportID
                fn = "ReportID"
            Case FieldName.StartDate
                fn = "StartDate"
            Case FieldName.EndDate
                fn = "EndDate"
            Case FieldName.TotalCash
                fn = "TotalCash"
            Case FieldName.Card
                fn = "Card"
            Case FieldName.AdminFee
                fn = "AdminFee"
            Case FieldName.Voucher
                fn = "Voucher"
            Case FieldName.GrandTotal
                fn = "GrandTotal"
            Case FieldName.AdjustedSash
                fn = "AdjustedSash"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UserID
                fn = "UserID"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblAdjustmentReport] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ReportID
                fn = "ReportID"
            Case FieldName.StartDate
                fn = "StartDate"
            Case FieldName.EndDate
                fn = "EndDate"
            Case FieldName.TotalCash
                fn = "TotalCash"
            Case FieldName.Card
                fn = "Card"
            Case FieldName.AdminFee
                fn = "AdminFee"
            Case FieldName.Voucher
                fn = "Voucher"
            Case FieldName.GrandTotal
                fn = "GrandTotal"
            Case FieldName.AdjustedSash
                fn = "AdjustedSash"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.UserID
                fn = "UserID"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblAdjustmentReport] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblService
    Public Shared tablename As String = "tblService"


    Structure Fields


        Dim sl_ As Int32
        Dim Service_ As String
        Dim DayPrice_ As Decimal
        Dim NightPrice_ As Decimal

    End Structure


    Enum FieldName


        [sl]
        [Service]
        [DayPrice]
        [NightPrice]

    End Enum


    Public ReadOnly Property tblService_insert
        Get
            Return <tblService_insert><![CDATA[
  INSERT INTO [tblService]
  (
      [sl],
      [Service],
      [DayPrice],
      [NightPrice]
  )
  VALUES
  (
      @sl_,
      @Service_,
      @DayPrice_,
      @NightPrice_
  )
]]></tblService_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblService_update
        Get
            Return <tblService_update><![CDATA[
UPDATE [tblService]
Set 
    [Service]=@Service_,
    [DayPrice]=@DayPrice_,
    [NightPrice]=@NightPrice_
 WHERE [sl]=@sl_
]]></tblService_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblService_select
        Get
            Return <tblService_select><![CDATA[
SELECT 
      [sl],
      [Service],
      [DayPrice],
      [NightPrice]
FROM [tblService]
    WHERE 1=1
]]></tblService_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblService_Delete_By_RowID
        Get
            Return <tblService_Delete_By_RowID><![CDATA[
DELETE FROM [tblService] WHERE [sl]=@sl_
]]></tblService_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblService_Delete_By_SELECT
        Get
            Return <tblService_Delete_By_SELECT><![CDATA[
DELETE FROM [tblService] WHERE 1=1
]]></tblService_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblService_MAXID
        Get
            Return <tblService_MAXID><![CDATA[
SELECT MAX([sl]) FROM [tblService] WHERE 1=1
]]></tblService_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblService_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Service_ As String,
    ByVal DayPrice_ As Decimal,
    ByVal NightPrice_ As Decimal,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim sl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblService_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@sl_", sl_)
            .AddWithValue("@Service_", Service_)
            .AddWithValue("@DayPrice_", DayPrice_)
            .AddWithValue("@NightPrice_", NightPrice_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Update(
    ByVal Service_ As String,
    ByVal DayPrice_ As Decimal,
    ByVal NightPrice_ As Decimal,
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblService_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Service_", Service_)
            .AddWithValue("@DayPrice_", DayPrice_)
            .AddWithValue("@NightPrice_", NightPrice_)
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return sl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.DayPrice
                fn = "DayPrice"
            Case FieldName.NightPrice
                fn = "NightPrice"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblService] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblService_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblService_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Selection_One_Row(
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblService_select & "  AND [sl]=@sl_"

        With comSelection.Parameters
            .AddWithValue("@sl_", sl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("sl") Is DBNull.Value Then : .sl_ = dt.Rows(0).Item("sl") : End If
                If Not dt.Rows(0).Item("Service") Is DBNull.Value Then : .Service_ = dt.Rows(0).Item("Service") : End If
                If Not dt.Rows(0).Item("DayPrice") Is DBNull.Value Then : .DayPrice_ = dt.Rows(0).Item("DayPrice") : End If
                If Not dt.Rows(0).Item("NightPrice") Is DBNull.Value Then : .NightPrice_ = dt.Rows(0).Item("NightPrice") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblService_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("sl") Is DBNull.Value Then : .sl_ = dt.Rows(0).Item("sl") : End If
                If Not dt.Rows(0).Item("Service") Is DBNull.Value Then : .Service_ = dt.Rows(0).Item("Service") : End If
                If Not dt.Rows(0).Item("DayPrice") Is DBNull.Value Then : .DayPrice_ = dt.Rows(0).Item("DayPrice") : End If
                If Not dt.Rows(0).Item("NightPrice") Is DBNull.Value Then : .NightPrice_ = dt.Rows(0).Item("NightPrice") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.DayPrice
                fn = "DayPrice"
            Case FieldName.NightPrice
                fn = "NightPrice"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblService] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.DayPrice
                fn = "DayPrice"
            Case FieldName.NightPrice
                fn = "NightPrice"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblService] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblBillItems
    Public Shared tablename As String = "tblBillItems"


    Structure Fields


        Dim ItemID_ As Int32
        Dim BillID_ As Int32
        Dim ProductId_ As Int32
        Dim Qty_ As Int32
        Dim Price_ As Decimal
        Dim Subtotal_ As Decimal

    End Structure


    Enum FieldName


        [ItemID]
        [BillID]
        [ProductId]
        [Qty]
        [Price]
        [Subtotal]

    End Enum


    Public ReadOnly Property tblBillItems_insert
        Get
            Return <tblBillItems_insert><![CDATA[
  INSERT INTO [tblBillItems]
  (
      [ItemID],
      [BillID],
      [ProductId],
      [Qty],
      [Price],
      [Subtotal]
  )
  VALUES
  (
      @ItemID_,
      @BillID_,
      @ProductId_,
      @Qty_,
      @Price_,
      @Subtotal_
  )
]]></tblBillItems_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblBillItems_update
        Get
            Return <tblBillItems_update><![CDATA[
UPDATE [tblBillItems]
Set 
    [BillID]=@BillID_,
    [ProductId]=@ProductId_,
    [Qty]=@Qty_,
    [Price]=@Price_,
    [Subtotal]=@Subtotal_
 WHERE [ItemID]=@ItemID_
]]></tblBillItems_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblBillItems_select
        Get
            Return <tblBillItems_select><![CDATA[
SELECT 
      [ItemID],
      [BillID],
      [ProductId],
      [Qty],
      [Price],
      [Subtotal]
FROM [tblBillItems]
    WHERE 1=1
]]></tblBillItems_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblBillItems_Delete_By_RowID
        Get
            Return <tblBillItems_Delete_By_RowID><![CDATA[
DELETE FROM [tblBillItems] WHERE [ItemID]=@ItemID_
]]></tblBillItems_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblBillItems_Delete_By_SELECT
        Get
            Return <tblBillItems_Delete_By_SELECT><![CDATA[
DELETE FROM [tblBillItems] WHERE 1=1
]]></tblBillItems_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblBillItems_MAXID
        Get
            Return <tblBillItems_MAXID><![CDATA[
SELECT MAX([ItemID]) FROM [tblBillItems] WHERE 1=1
]]></tblBillItems_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblBillItems_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal BillID_ As Int32,
    ByVal ProductId_ As Int32,
    ByVal Qty_ As Int32,
    ByVal Price_ As Decimal,
    ByVal Subtotal_ As Decimal,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblBillItems_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemID_", ItemID_)
            .AddWithValue("@BillID_", BillID_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Subtotal_", Subtotal_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemID_
    End Function



    Function Update(
    ByVal BillID_ As Int32,
    ByVal ProductId_ As Int32,
    ByVal Qty_ As Int32,
    ByVal Price_ As Decimal,
    ByVal Subtotal_ As Decimal,
    ByVal ItemID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblBillItems_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@BillID_", BillID_)
            .AddWithValue("@ProductId_", ProductId_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Subtotal_", Subtotal_)
            .AddWithValue("@ItemID_", ItemID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ItemID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemID
                fn = "ItemID"
            Case FieldName.BillID
                fn = "BillID"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Subtotal
                fn = "Subtotal"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblBillItems] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBillItems_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ItemID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBillItems_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemID_", ItemID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemID_
    End Function



    Function Selection_One_Row(
    ByVal ItemID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBillItems_select & "  AND [ItemID]=@ItemID_"

        With comSelection.Parameters
            .AddWithValue("@ItemID_", ItemID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemID") Is DBNull.Value Then : .ItemID_ = dt.Rows(0).Item("ItemID") : End If
                If Not dt.Rows(0).Item("BillID") Is DBNull.Value Then : .BillID_ = dt.Rows(0).Item("BillID") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Subtotal") Is DBNull.Value Then : .Subtotal_ = dt.Rows(0).Item("Subtotal") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBillItems_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ItemID") Is DBNull.Value Then : .ItemID_ = dt.Rows(0).Item("ItemID") : End If
                If Not dt.Rows(0).Item("BillID") Is DBNull.Value Then : .BillID_ = dt.Rows(0).Item("BillID") : End If
                If Not dt.Rows(0).Item("ProductId") Is DBNull.Value Then : .ProductId_ = dt.Rows(0).Item("ProductId") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Subtotal") Is DBNull.Value Then : .Subtotal_ = dt.Rows(0).Item("Subtotal") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemID
                fn = "ItemID"
            Case FieldName.BillID
                fn = "BillID"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Subtotal
                fn = "Subtotal"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblBillItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemID
                fn = "ItemID"
            Case FieldName.BillID
                fn = "BillID"
            Case FieldName.ProductId
                fn = "ProductId"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Subtotal
                fn = "Subtotal"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblBillItems] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblRoom
    Public Shared tablename As String = "tblRoom"


    Structure Fields


        Dim Sl_ As Int32
        Dim Room_ As String
        Dim FullName_ As String
        Dim AdditonalCharge_ As Decimal
        Dim Status_ As String
        Dim Usable_ As String
        Dim Comment_ As String
        Dim StatusTime_ As DateTime
        Dim AutoActiveIn_ As Int32
        Dim AddlSP_Fee_ As Decimal
        Dim AddlHouse_Fee_ As Decimal

    End Structure


    Enum FieldName


        [Sl]
        [Room]
        [FullName]
        [AdditonalCharge]
        [Status]
        [Usable]
        [Comment]
        [StatusTime]
        [AutoActiveIn]
        [AddlSP_Fee]
        [AddlHouse_Fee]

    End Enum


    Public ReadOnly Property tblRoom_insert
        Get
            Return <tblRoom_insert><![CDATA[
  INSERT INTO [tblRoom]
  (
      [Sl],
      [Room],
      [FullName],
      [AdditonalCharge],
      [Status],
      [Usable],
      [Comment],
      [StatusTime],
      [AutoActiveIn],
      [AddlSP_Fee],
      [AddlHouse_Fee]
  )
  VALUES
  (
      @Sl_,
      @Room_,
      @FullName_,
      @AdditonalCharge_,
      @Status_,
      @Usable_,
      @Comment_,
      @StatusTime_,
      @AutoActiveIn_,
      @AddlSP_Fee_,
      @AddlHouse_Fee_
  )
]]></tblRoom_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblRoom_update
        Get
            Return <tblRoom_update><![CDATA[
UPDATE [tblRoom]
Set 
    [Sl]=@Sl_,
    [FullName]=@FullName_,
    [AdditonalCharge]=@AdditonalCharge_,
    [Status]=@Status_,
    [Usable]=@Usable_,
    [Comment]=@Comment_,
    [StatusTime]=@StatusTime_,
    [AutoActiveIn]=@AutoActiveIn_,
    [AddlSP_Fee]=@AddlSP_Fee_,
    [AddlHouse_Fee]=@AddlHouse_Fee_
 WHERE [Room]=@Room_
]]></tblRoom_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblRoom_select
        Get
            Return <tblRoom_select><![CDATA[
SELECT 
      [Sl],
      [Room],
      [FullName],
      [AdditonalCharge],
      [Status],
      [Usable],
      [Comment],
      [StatusTime],
      [AutoActiveIn],
      [AddlSP_Fee],
      [AddlHouse_Fee]
FROM [tblRoom]
    WHERE 1=1
]]></tblRoom_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblRoom_Delete_By_RowID
        Get
            Return <tblRoom_Delete_By_RowID><![CDATA[
DELETE FROM [tblRoom] WHERE [Room]=@Room_
]]></tblRoom_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblRoom_Delete_By_SELECT
        Get
            Return <tblRoom_Delete_By_SELECT><![CDATA[
DELETE FROM [tblRoom] WHERE 1=1
]]></tblRoom_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblRoom_MAXID
        Get
            Return <tblRoom_MAXID><![CDATA[
SELECT MAX([Room]) FROM [tblRoom] WHERE 1=1
]]></tblRoom_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblRoom_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Sl_ As Int32,
    ByVal FullName_ As String,
    ByVal AdditonalCharge_ As Decimal,
    ByVal Status_ As String,
    ByVal Usable_ As String,
    ByVal Comment_ As String,
    ByVal StatusTime_ As DateTime,
    ByVal AutoActiveIn_ As Int32,
    ByVal AddlSP_Fee_ As Decimal,
    ByVal AddlHouse_Fee_ As Decimal,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim Room_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblRoom_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@Room_", Room_)
            .AddWithValue("@FullName_", FullName_)
            .AddWithValue("@AdditonalCharge_", AdditonalCharge_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Usable_", Usable_)
            .AddWithValue("@Comment_", Comment_)
            .AddWithValue("@StatusTime_", StatusTime_)
            .AddWithValue("@AutoActiveIn_", AutoActiveIn_)
            .AddWithValue("@AddlSP_Fee_", AddlSP_Fee_)
            .AddWithValue("@AddlHouse_Fee_", AddlHouse_Fee_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Room_
    End Function



    Function Update(
    ByVal Sl_ As Int32,
    ByVal FullName_ As String,
    ByVal AdditonalCharge_ As Decimal,
    ByVal Status_ As String,
    ByVal Usable_ As String,
    ByVal Comment_ As String,
    ByVal StatusTime_ As DateTime,
    ByVal AutoActiveIn_ As Int32,
    ByVal AddlSP_Fee_ As Decimal,
    ByVal AddlHouse_Fee_ As Decimal,
    ByVal Room_ As String,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblRoom_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@FullName_", FullName_)
            .AddWithValue("@AdditonalCharge_", AdditonalCharge_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Usable_", Usable_)
            .AddWithValue("@Comment_", Comment_)
            .AddWithValue("@StatusTime_", StatusTime_)
            .AddWithValue("@AutoActiveIn_", AutoActiveIn_)
            .AddWithValue("@AddlSP_Fee_", AddlSP_Fee_)
            .AddWithValue("@AddlHouse_Fee_", AddlHouse_Fee_)
            .AddWithValue("@Room_", Room_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return Room_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.AdditonalCharge
                fn = "AdditonalCharge"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Usable
                fn = "Usable"
            Case FieldName.Comment
                fn = "Comment"
            Case FieldName.StatusTime
                fn = "StatusTime"
            Case FieldName.AutoActiveIn
                fn = "AutoActiveIn"
            Case FieldName.AddlSP_Fee
                fn = "AddlSP_Fee"
            Case FieldName.AddlHouse_Fee
                fn = "AddlHouse_Fee"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblRoom] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblRoom_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal Room_ As String,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblRoom_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@Room_", Room_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Room_
    End Function



    Function Selection_One_Row(
    ByVal Room_ As String,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblRoom_select & "  AND [Room]=@Room_"

        With comSelection.Parameters
            .AddWithValue("@Room_", Room_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("Room") Is DBNull.Value Then : .Room_ = dt.Rows(0).Item("Room") : End If
                If Not dt.Rows(0).Item("FullName") Is DBNull.Value Then : .FullName_ = dt.Rows(0).Item("FullName") : End If
                If Not dt.Rows(0).Item("AdditonalCharge") Is DBNull.Value Then : .AdditonalCharge_ = dt.Rows(0).Item("AdditonalCharge") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Usable") Is DBNull.Value Then : .Usable_ = dt.Rows(0).Item("Usable") : End If
                If Not dt.Rows(0).Item("Comment") Is DBNull.Value Then : .Comment_ = dt.Rows(0).Item("Comment") : End If
                If Not dt.Rows(0).Item("StatusTime") Is DBNull.Value Then : .StatusTime_ = dt.Rows(0).Item("StatusTime") : End If
                If Not dt.Rows(0).Item("AutoActiveIn") Is DBNull.Value Then : .AutoActiveIn_ = dt.Rows(0).Item("AutoActiveIn") : End If
                If Not dt.Rows(0).Item("AddlSP_Fee") Is DBNull.Value Then : .AddlSP_Fee_ = dt.Rows(0).Item("AddlSP_Fee") : End If
                If Not dt.Rows(0).Item("AddlHouse_Fee") Is DBNull.Value Then : .AddlHouse_Fee_ = dt.Rows(0).Item("AddlHouse_Fee") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblRoom_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("Room") Is DBNull.Value Then : .Room_ = dt.Rows(0).Item("Room") : End If
                If Not dt.Rows(0).Item("FullName") Is DBNull.Value Then : .FullName_ = dt.Rows(0).Item("FullName") : End If
                If Not dt.Rows(0).Item("AdditonalCharge") Is DBNull.Value Then : .AdditonalCharge_ = dt.Rows(0).Item("AdditonalCharge") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Usable") Is DBNull.Value Then : .Usable_ = dt.Rows(0).Item("Usable") : End If
                If Not dt.Rows(0).Item("Comment") Is DBNull.Value Then : .Comment_ = dt.Rows(0).Item("Comment") : End If
                If Not dt.Rows(0).Item("StatusTime") Is DBNull.Value Then : .StatusTime_ = dt.Rows(0).Item("StatusTime") : End If
                If Not dt.Rows(0).Item("AutoActiveIn") Is DBNull.Value Then : .AutoActiveIn_ = dt.Rows(0).Item("AutoActiveIn") : End If
                If Not dt.Rows(0).Item("AddlSP_Fee") Is DBNull.Value Then : .AddlSP_Fee_ = dt.Rows(0).Item("AddlSP_Fee") : End If
                If Not dt.Rows(0).Item("AddlHouse_Fee") Is DBNull.Value Then : .AddlHouse_Fee_ = dt.Rows(0).Item("AddlHouse_Fee") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.AdditonalCharge
                fn = "AdditonalCharge"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Usable
                fn = "Usable"
            Case FieldName.Comment
                fn = "Comment"
            Case FieldName.StatusTime
                fn = "StatusTime"
            Case FieldName.AutoActiveIn
                fn = "AutoActiveIn"
            Case FieldName.AddlSP_Fee
                fn = "AddlSP_Fee"
            Case FieldName.AddlHouse_Fee
                fn = "AddlHouse_Fee"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblRoom] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.FullName
                fn = "FullName"
            Case FieldName.AdditonalCharge
                fn = "AdditonalCharge"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Usable
                fn = "Usable"
            Case FieldName.Comment
                fn = "Comment"
            Case FieldName.StatusTime
                fn = "StatusTime"
            Case FieldName.AutoActiveIn
                fn = "AutoActiveIn"
            Case FieldName.AddlSP_Fee
                fn = "AddlSP_Fee"
            Case FieldName.AddlHouse_Fee
                fn = "AddlHouse_Fee"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblRoom] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblBill
    Public Shared tablename As String = "tblBill"


    Structure Fields


        Dim BillID_ As Int32
        Dim C_Name_ As String
        Dim Amount_ As Decimal
        Dim BillDate_ As DateTime
        Dim Status_ As String
        Dim UserId_ As Int32

    End Structure


    Enum FieldName


        [BillID]
        [C_Name]
        [Amount]
        [BillDate]
        [Status]
        [UserId]

    End Enum


    Public ReadOnly Property tblBill_insert
        Get
            Return <tblBill_insert><![CDATA[
  INSERT INTO [tblBill]
  (
      [BillID],
      [C_Name],
      [Amount],
      [BillDate],
      [Status],
      [UserId]
  )
  VALUES
  (
      @BillID_,
      @C_Name_,
      @Amount_,
      @BillDate_,
      @Status_,
      @UserId_
  )
]]></tblBill_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblBill_update
        Get
            Return <tblBill_update><![CDATA[
UPDATE [tblBill]
Set 
    [C_Name]=@C_Name_,
    [Amount]=@Amount_,
    [BillDate]=@BillDate_,
    [Status]=@Status_,
    [UserId]=@UserId_
 WHERE [BillID]=@BillID_
]]></tblBill_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblBill_select
        Get
            Return <tblBill_select><![CDATA[
SELECT 
      [BillID],
      [C_Name],
      [Amount],
      [BillDate],
      [Status],
      [UserId]
FROM [tblBill]
    WHERE 1=1
]]></tblBill_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblBill_Delete_By_RowID
        Get
            Return <tblBill_Delete_By_RowID><![CDATA[
DELETE FROM [tblBill] WHERE [BillID]=@BillID_
]]></tblBill_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblBill_Delete_By_SELECT
        Get
            Return <tblBill_Delete_By_SELECT><![CDATA[
DELETE FROM [tblBill] WHERE 1=1
]]></tblBill_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblBill_MAXID
        Get
            Return <tblBill_MAXID><![CDATA[
SELECT MAX([BillID]) FROM [tblBill] WHERE 1=1
]]></tblBill_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblBill_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal C_Name_ As String,
    ByVal Amount_ As Decimal,
    ByVal BillDate_ As DateTime,
    ByVal Status_ As String,
    ByVal UserId_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim BillID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblBill_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@BillID_", BillID_)
            .AddWithValue("@C_Name_", C_Name_)
            .AddWithValue("@Amount_", Amount_)
            .AddWithValue("@BillDate_", BillDate_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@UserId_", UserId_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return BillID_
    End Function



    Function Update(
    ByVal C_Name_ As String,
    ByVal Amount_ As Decimal,
    ByVal BillDate_ As DateTime,
    ByVal Status_ As String,
    ByVal UserId_ As Int32,
    ByVal BillID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblBill_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@C_Name_", C_Name_)
            .AddWithValue("@Amount_", Amount_)
            .AddWithValue("@BillDate_", BillDate_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@BillID_", BillID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return BillID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.BillID
                fn = "BillID"
            Case FieldName.C_Name
                fn = "C_Name"
            Case FieldName.Amount
                fn = "Amount"
            Case FieldName.BillDate
                fn = "BillDate"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblBill] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBill_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal BillID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBill_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@BillID_", BillID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return BillID_
    End Function



    Function Selection_One_Row(
    ByVal BillID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBill_select & "  AND [BillID]=@BillID_"

        With comSelection.Parameters
            .AddWithValue("@BillID_", BillID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("BillID") Is DBNull.Value Then : .BillID_ = dt.Rows(0).Item("BillID") : End If
                If Not dt.Rows(0).Item("C_Name") Is DBNull.Value Then : .C_Name_ = dt.Rows(0).Item("C_Name") : End If
                If Not dt.Rows(0).Item("Amount") Is DBNull.Value Then : .Amount_ = dt.Rows(0).Item("Amount") : End If
                If Not dt.Rows(0).Item("BillDate") Is DBNull.Value Then : .BillDate_ = dt.Rows(0).Item("BillDate") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBill_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("BillID") Is DBNull.Value Then : .BillID_ = dt.Rows(0).Item("BillID") : End If
                If Not dt.Rows(0).Item("C_Name") Is DBNull.Value Then : .C_Name_ = dt.Rows(0).Item("C_Name") : End If
                If Not dt.Rows(0).Item("Amount") Is DBNull.Value Then : .Amount_ = dt.Rows(0).Item("Amount") : End If
                If Not dt.Rows(0).Item("BillDate") Is DBNull.Value Then : .BillDate_ = dt.Rows(0).Item("BillDate") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.BillID
                fn = "BillID"
            Case FieldName.C_Name
                fn = "C_Name"
            Case FieldName.Amount
                fn = "Amount"
            Case FieldName.BillDate
                fn = "BillDate"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblBill] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.BillID
                fn = "BillID"
            Case FieldName.C_Name
                fn = "C_Name"
            Case FieldName.Amount
                fn = "Amount"
            Case FieldName.BillDate
                fn = "BillDate"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblBill] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblProducts
    Public Shared tablename As String = "tblProducts"


    Structure Fields


        Dim ProductID_ As Int32
        Dim ProductName_ As String
        Dim Category_ As String
        Dim Brand_ As String
        Dim Price_ As Decimal
        Dim Unit_ As String
        Dim Tax_ As Decimal
        Dim Barcode_ As String
        Dim ExpireIn_ As Int32
        Dim ExpireInType_ As String
        Dim MinimumStock_ As Int32
        Dim EntryDate_ As DateTime
        Dim CodeName_ As String

    End Structure


    Enum FieldName


        [ProductID]
        [ProductName]
        [Category]
        [Brand]
        [Price]
        [Unit]
        [Tax]
        [Barcode]
        [ExpireIn]
        [ExpireInType]
        [MinimumStock]
        [EntryDate]
        [CodeName]

    End Enum


    Public ReadOnly Property tblProducts_insert
        Get
            Return <tblProducts_insert><![CDATA[
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
      [EntryDate],
      [CodeName]
  )
  VALUES
  (
      @ProductID_,
      @ProductName_,
      @Category_,
      @Brand_,
      @Price_,
      @Unit_,
      @Tax_,
      @Barcode_,
      @ExpireIn_,
      @ExpireInType_,
      @MinimumStock_,
      @EntryDate_,
      @CodeName_
  )
]]></tblProducts_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblProducts_update
        Get
            Return <tblProducts_update><![CDATA[
UPDATE [tblProducts]
Set 
    [ProductName]=@ProductName_,
    [Category]=@Category_,
    [Brand]=@Brand_,
    [Price]=@Price_,
    [Unit]=@Unit_,
    [Tax]=@Tax_,
    [Barcode]=@Barcode_,
    [ExpireIn]=@ExpireIn_,
    [ExpireInType]=@ExpireInType_,
    [MinimumStock]=@MinimumStock_,
    [EntryDate]=@EntryDate_,
    [CodeName]=@CodeName_
 WHERE [ProductID]=@ProductID_
]]></tblProducts_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblProducts_select
        Get
            Return <tblProducts_select><![CDATA[
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
      [EntryDate],
      [CodeName]
FROM [tblProducts]
    WHERE 1=1
]]></tblProducts_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblProducts_Delete_By_RowID
        Get
            Return <tblProducts_Delete_By_RowID><![CDATA[
DELETE FROM [tblProducts] WHERE [ProductID]=@ProductID_
]]></tblProducts_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblProducts_Delete_By_SELECT
        Get
            Return <tblProducts_Delete_By_SELECT><![CDATA[
DELETE FROM [tblProducts] WHERE 1=1
]]></tblProducts_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblProducts_MAXID
        Get
            Return <tblProducts_MAXID><![CDATA[
SELECT MAX([ProductID]) FROM [tblProducts] WHERE 1=1
]]></tblProducts_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblProducts_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal ProductName_ As String,
    ByVal Category_ As String,
    ByVal Brand_ As String,
    ByVal Price_ As Decimal,
    ByVal Unit_ As String,
    ByVal Tax_ As Decimal,
    ByVal Barcode_ As String,
    ByVal ExpireIn_ As Int32,
    ByVal ExpireInType_ As String,
    ByVal MinimumStock_ As Int32,
    ByVal EntryDate_ As DateTime,
    ByVal CodeName_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ProductID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblProducts_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ProductID_", ProductID_)
            .AddWithValue("@ProductName_", ProductName_)
            .AddWithValue("@Category_", Category_)
            .AddWithValue("@Brand_", Brand_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Unit_", Unit_)
            .AddWithValue("@Tax_", Tax_)
            .AddWithValue("@Barcode_", Barcode_)
            .AddWithValue("@ExpireIn_", ExpireIn_)
            .AddWithValue("@ExpireInType_", ExpireInType_)
            .AddWithValue("@MinimumStock_", MinimumStock_)
            .AddWithValue("@EntryDate_", EntryDate_)
            .AddWithValue("@CodeName_", CodeName_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ProductID_
    End Function



    Function Update(
    ByVal ProductName_ As String,
    ByVal Category_ As String,
    ByVal Brand_ As String,
    ByVal Price_ As Decimal,
    ByVal Unit_ As String,
    ByVal Tax_ As Decimal,
    ByVal Barcode_ As String,
    ByVal ExpireIn_ As Int32,
    ByVal ExpireInType_ As String,
    ByVal MinimumStock_ As Int32,
    ByVal EntryDate_ As DateTime,
    ByVal CodeName_ As String,
    ByVal ProductID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblProducts_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@ProductName_", ProductName_)
            .AddWithValue("@Category_", Category_)
            .AddWithValue("@Brand_", Brand_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Unit_", Unit_)
            .AddWithValue("@Tax_", Tax_)
            .AddWithValue("@Barcode_", Barcode_)
            .AddWithValue("@ExpireIn_", ExpireIn_)
            .AddWithValue("@ExpireInType_", ExpireInType_)
            .AddWithValue("@MinimumStock_", MinimumStock_)
            .AddWithValue("@EntryDate_", EntryDate_)
            .AddWithValue("@CodeName_", CodeName_)
            .AddWithValue("@ProductID_", ProductID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ProductID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ProductID
                fn = "ProductID"
            Case FieldName.ProductName
                fn = "ProductName"
            Case FieldName.Category
                fn = "Category"
            Case FieldName.Brand
                fn = "Brand"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Unit
                fn = "Unit"
            Case FieldName.Tax
                fn = "Tax"
            Case FieldName.Barcode
                fn = "Barcode"
            Case FieldName.ExpireIn
                fn = "ExpireIn"
            Case FieldName.ExpireInType
                fn = "ExpireInType"
            Case FieldName.MinimumStock
                fn = "MinimumStock"
            Case FieldName.EntryDate
                fn = "EntryDate"
            Case FieldName.CodeName
                fn = "CodeName"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblProducts] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblProducts_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ProductID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblProducts_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ProductID_", ProductID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ProductID_
    End Function



    Function Selection_One_Row(
    ByVal ProductID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblProducts_select & "  AND [ProductID]=@ProductID_"

        With comSelection.Parameters
            .AddWithValue("@ProductID_", ProductID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ProductID") Is DBNull.Value Then : .ProductID_ = dt.Rows(0).Item("ProductID") : End If
                If Not dt.Rows(0).Item("ProductName") Is DBNull.Value Then : .ProductName_ = dt.Rows(0).Item("ProductName") : End If
                If Not dt.Rows(0).Item("Category") Is DBNull.Value Then : .Category_ = dt.Rows(0).Item("Category") : End If
                If Not dt.Rows(0).Item("Brand") Is DBNull.Value Then : .Brand_ = dt.Rows(0).Item("Brand") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Unit") Is DBNull.Value Then : .Unit_ = dt.Rows(0).Item("Unit") : End If
                If Not dt.Rows(0).Item("Tax") Is DBNull.Value Then : .Tax_ = dt.Rows(0).Item("Tax") : End If
                If Not dt.Rows(0).Item("Barcode") Is DBNull.Value Then : .Barcode_ = dt.Rows(0).Item("Barcode") : End If
                If Not dt.Rows(0).Item("ExpireIn") Is DBNull.Value Then : .ExpireIn_ = dt.Rows(0).Item("ExpireIn") : End If
                If Not dt.Rows(0).Item("ExpireInType") Is DBNull.Value Then : .ExpireInType_ = dt.Rows(0).Item("ExpireInType") : End If
                If Not dt.Rows(0).Item("MinimumStock") Is DBNull.Value Then : .MinimumStock_ = dt.Rows(0).Item("MinimumStock") : End If
                If Not dt.Rows(0).Item("EntryDate") Is DBNull.Value Then : .EntryDate_ = dt.Rows(0).Item("EntryDate") : End If
                If Not dt.Rows(0).Item("CodeName") Is DBNull.Value Then : .CodeName_ = dt.Rows(0).Item("CodeName") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblProducts_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ProductID") Is DBNull.Value Then : .ProductID_ = dt.Rows(0).Item("ProductID") : End If
                If Not dt.Rows(0).Item("ProductName") Is DBNull.Value Then : .ProductName_ = dt.Rows(0).Item("ProductName") : End If
                If Not dt.Rows(0).Item("Category") Is DBNull.Value Then : .Category_ = dt.Rows(0).Item("Category") : End If
                If Not dt.Rows(0).Item("Brand") Is DBNull.Value Then : .Brand_ = dt.Rows(0).Item("Brand") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Unit") Is DBNull.Value Then : .Unit_ = dt.Rows(0).Item("Unit") : End If
                If Not dt.Rows(0).Item("Tax") Is DBNull.Value Then : .Tax_ = dt.Rows(0).Item("Tax") : End If
                If Not dt.Rows(0).Item("Barcode") Is DBNull.Value Then : .Barcode_ = dt.Rows(0).Item("Barcode") : End If
                If Not dt.Rows(0).Item("ExpireIn") Is DBNull.Value Then : .ExpireIn_ = dt.Rows(0).Item("ExpireIn") : End If
                If Not dt.Rows(0).Item("ExpireInType") Is DBNull.Value Then : .ExpireInType_ = dt.Rows(0).Item("ExpireInType") : End If
                If Not dt.Rows(0).Item("MinimumStock") Is DBNull.Value Then : .MinimumStock_ = dt.Rows(0).Item("MinimumStock") : End If
                If Not dt.Rows(0).Item("EntryDate") Is DBNull.Value Then : .EntryDate_ = dt.Rows(0).Item("EntryDate") : End If
                If Not dt.Rows(0).Item("CodeName") Is DBNull.Value Then : .CodeName_ = dt.Rows(0).Item("CodeName") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ProductID
                fn = "ProductID"
            Case FieldName.ProductName
                fn = "ProductName"
            Case FieldName.Category
                fn = "Category"
            Case FieldName.Brand
                fn = "Brand"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Unit
                fn = "Unit"
            Case FieldName.Tax
                fn = "Tax"
            Case FieldName.Barcode
                fn = "Barcode"
            Case FieldName.ExpireIn
                fn = "ExpireIn"
            Case FieldName.ExpireInType
                fn = "ExpireInType"
            Case FieldName.MinimumStock
                fn = "MinimumStock"
            Case FieldName.EntryDate
                fn = "EntryDate"
            Case FieldName.CodeName
                fn = "CodeName"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblProducts] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ProductID
                fn = "ProductID"
            Case FieldName.ProductName
                fn = "ProductName"
            Case FieldName.Category
                fn = "Category"
            Case FieldName.Brand
                fn = "Brand"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Unit
                fn = "Unit"
            Case FieldName.Tax
                fn = "Tax"
            Case FieldName.Barcode
                fn = "Barcode"
            Case FieldName.ExpireIn
                fn = "ExpireIn"
            Case FieldName.ExpireInType
                fn = "ExpireInType"
            Case FieldName.MinimumStock
                fn = "MinimumStock"
            Case FieldName.EntryDate
                fn = "EntryDate"
            Case FieldName.CodeName
                fn = "CodeName"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblProducts] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblPremiumServices
    Public Shared tablename As String = "tblPremiumServices"


    Structure Fields


        Dim ItemID_ As Int32
        Dim WeekDay_ As Int32
        Dim Servicecharge_ As Decimal
        Dim Sp_ As Decimal
        Dim House_ As Decimal

    End Structure


    Enum FieldName


        [ItemID]
        [WeekDay]
        [Servicecharge]
        [Sp]
        [House]

    End Enum


    Public ReadOnly Property tblPremiumServices_insert
        Get
            Return <tblPremiumServices_insert><![CDATA[
  INSERT INTO [tblPremiumServices]
  (
      [ItemID],
      [WeekDay],
      [Servicecharge],
      [Sp],
      [House]
  )
  VALUES
  (
      @ItemID_,
      @WeekDay_,
      @Servicecharge_,
      @Sp_,
      @House_
  )
]]></tblPremiumServices_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblPremiumServices_update
        Get
            Return <tblPremiumServices_update><![CDATA[
UPDATE [tblPremiumServices]
Set 
    [WeekDay]=@WeekDay_,
    [Servicecharge]=@Servicecharge_,
    [Sp]=@Sp_,
    [House]=@House_
 WHERE [ItemID]=@ItemID_
]]></tblPremiumServices_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblPremiumServices_select
        Get
            Return <tblPremiumServices_select><![CDATA[
SELECT 
      [ItemID],
      [WeekDay],
      [Servicecharge],
      [Sp],
      [House]
FROM [tblPremiumServices]
    WHERE 1=1
]]></tblPremiumServices_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblPremiumServices_Delete_By_RowID
        Get
            Return <tblPremiumServices_Delete_By_RowID><![CDATA[
DELETE FROM [tblPremiumServices] WHERE [ItemID]=@ItemID_
]]></tblPremiumServices_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblPremiumServices_Delete_By_SELECT
        Get
            Return <tblPremiumServices_Delete_By_SELECT><![CDATA[
DELETE FROM [tblPremiumServices] WHERE 1=1
]]></tblPremiumServices_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblPremiumServices_MAXID
        Get
            Return <tblPremiumServices_MAXID><![CDATA[
SELECT MAX([ItemID]) FROM [tblPremiumServices] WHERE 1=1
]]></tblPremiumServices_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblPremiumServices_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal WeekDay_ As Int32,
    ByVal Servicecharge_ As Decimal,
    ByVal Sp_ As Decimal,
    ByVal House_ As Decimal,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblPremiumServices_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemID_", ItemID_)
            .AddWithValue("@WeekDay_", WeekDay_)
            .AddWithValue("@Servicecharge_", Servicecharge_)
            .AddWithValue("@Sp_", Sp_)
            .AddWithValue("@House_", House_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemID_
    End Function



    Function Update(
    ByVal WeekDay_ As Int32,
    ByVal Servicecharge_ As Decimal,
    ByVal Sp_ As Decimal,
    ByVal House_ As Decimal,
    ByVal ItemID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblPremiumServices_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@WeekDay_", WeekDay_)
            .AddWithValue("@Servicecharge_", Servicecharge_)
            .AddWithValue("@Sp_", Sp_)
            .AddWithValue("@House_", House_)
            .AddWithValue("@ItemID_", ItemID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ItemID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemID
                fn = "ItemID"
            Case FieldName.WeekDay
                fn = "WeekDay"
            Case FieldName.Servicecharge
                fn = "Servicecharge"
            Case FieldName.Sp
                fn = "Sp"
            Case FieldName.House
                fn = "House"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblPremiumServices] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblPremiumServices_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ItemID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblPremiumServices_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemID_", ItemID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemID_
    End Function



    Function Selection_One_Row(
    ByVal ItemID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblPremiumServices_select & "  AND [ItemID]=@ItemID_"

        With comSelection.Parameters
            .AddWithValue("@ItemID_", ItemID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemID") Is DBNull.Value Then : .ItemID_ = dt.Rows(0).Item("ItemID") : End If
                If Not dt.Rows(0).Item("WeekDay") Is DBNull.Value Then : .WeekDay_ = dt.Rows(0).Item("WeekDay") : End If
                If Not dt.Rows(0).Item("Servicecharge") Is DBNull.Value Then : .Servicecharge_ = dt.Rows(0).Item("Servicecharge") : End If
                If Not dt.Rows(0).Item("Sp") Is DBNull.Value Then : .Sp_ = dt.Rows(0).Item("Sp") : End If
                If Not dt.Rows(0).Item("House") Is DBNull.Value Then : .House_ = dt.Rows(0).Item("House") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblPremiumServices_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ItemID") Is DBNull.Value Then : .ItemID_ = dt.Rows(0).Item("ItemID") : End If
                If Not dt.Rows(0).Item("WeekDay") Is DBNull.Value Then : .WeekDay_ = dt.Rows(0).Item("WeekDay") : End If
                If Not dt.Rows(0).Item("Servicecharge") Is DBNull.Value Then : .Servicecharge_ = dt.Rows(0).Item("Servicecharge") : End If
                If Not dt.Rows(0).Item("Sp") Is DBNull.Value Then : .Sp_ = dt.Rows(0).Item("Sp") : End If
                If Not dt.Rows(0).Item("House") Is DBNull.Value Then : .House_ = dt.Rows(0).Item("House") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemID
                fn = "ItemID"
            Case FieldName.WeekDay
                fn = "WeekDay"
            Case FieldName.Servicecharge
                fn = "Servicecharge"
            Case FieldName.Sp
                fn = "Sp"
            Case FieldName.House
                fn = "House"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblPremiumServices] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemID
                fn = "ItemID"
            Case FieldName.WeekDay
                fn = "WeekDay"
            Case FieldName.Servicecharge
                fn = "Servicecharge"
            Case FieldName.Sp
                fn = "Sp"
            Case FieldName.House
                fn = "House"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblPremiumServices] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblPayment
    Public Shared tablename As String = "tblPayment"


    Structure Fields


        Dim ID_ As Int32
        Dim Transc_ID_ As Int32
        Dim Transac_Type_ As String
        Dim PaymentMode_ As String
        Dim TotalAmount_ As Decimal
        Dim CASH_ As Decimal
        Dim CARD_ As Decimal
        Dim SURCHARGE_P_ As Decimal
        Dim SURCHARGE_AMT_ As Decimal
        Dim TOTAIL_PAID_ As Decimal
        Dim Transc_Time_ As DateTime
        Dim Remarks_ As String
        Dim Status_ As String
        Dim VoucherAmount_ As Decimal
        Dim VoucherID_ As Int32
        Dim ShiftFee_ As Decimal
        Dim MemoNo_ As Int32
        Dim CashOut_ As Decimal
        Dim Tip_ As Decimal
        Dim GST_ As Decimal
        Dim UserId_ As Int32

    End Structure


    Enum FieldName


        [ID]
        [Transc_ID]
        [Transac_Type]
        [PaymentMode]
        [TotalAmount]
        [CASH]
        [CARD]
        [SURCHARGE_P]
        [SURCHARGE_AMT]
        [TOTAIL_PAID]
        [Transc_Time]
        [Remarks]
        [Status]
        [VoucherAmount]
        [VoucherID]
        [ShiftFee]
        [MemoNo]
        [CashOut]
        [Tip]
        [GST]
        [UserId]

    End Enum


    Public ReadOnly Property tblPayment_insert
        Get
            Return <tblPayment_insert><![CDATA[
  INSERT INTO [tblPayment]
  (
      [ID],
      [Transc_ID],
      [Transac_Type],
      [PaymentMode],
      [TotalAmount],
      [CASH],
      [CARD],
      [SURCHARGE_P],
      [SURCHARGE_AMT],
      [TOTAIL_PAID],
      [Transc_Time],
      [Remarks],
      [Status],
      [VoucherAmount],
      [VoucherID],
      [ShiftFee],
      [MemoNo],
      [CashOut],
      [Tip],
      [GST],
      [UserId]
  )
  VALUES
  (
      @ID_,
      @Transc_ID_,
      @Transac_Type_,
      @PaymentMode_,
      @TotalAmount_,
      @CASH_,
      @CARD_,
      @SURCHARGE_P_,
      @SURCHARGE_AMT_,
      @TOTAIL_PAID_,
      @Transc_Time_,
      @Remarks_,
      @Status_,
      @VoucherAmount_,
      @VoucherID_,
      @ShiftFee_,
      @MemoNo_,
      @CashOut_,
      @Tip_,
      @GST_,
      @UserId_
  )
]]></tblPayment_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblPayment_update
        Get
            Return <tblPayment_update><![CDATA[
UPDATE [tblPayment]
Set 
    [Transc_ID]=@Transc_ID_,
    [Transac_Type]=@Transac_Type_,
    [PaymentMode]=@PaymentMode_,
    [TotalAmount]=@TotalAmount_,
    [CASH]=@CASH_,
    [CARD]=@CARD_,
    [SURCHARGE_P]=@SURCHARGE_P_,
    [SURCHARGE_AMT]=@SURCHARGE_AMT_,
    [TOTAIL_PAID]=@TOTAIL_PAID_,
    [Transc_Time]=@Transc_Time_,
    [Remarks]=@Remarks_,
    [Status]=@Status_,
    [VoucherAmount]=@VoucherAmount_,
    [VoucherID]=@VoucherID_,
    [ShiftFee]=@ShiftFee_,
    [MemoNo]=@MemoNo_,
    [CashOut]=@CashOut_,
    [Tip]=@Tip_,
    [GST]=@GST_,
    [UserId]=@UserId_
 WHERE [ID]=@ID_
]]></tblPayment_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblPayment_select
        Get
            Return <tblPayment_select><![CDATA[
SELECT 
      [ID],
      [Transc_ID],
      [Transac_Type],
      [PaymentMode],
      [TotalAmount],
      [CASH],
      [CARD],
      [SURCHARGE_P],
      [SURCHARGE_AMT],
      [TOTAIL_PAID],
      [Transc_Time],
      [Remarks],
      [Status],
      [VoucherAmount],
      [VoucherID],
      [ShiftFee],
      [MemoNo],
      [CashOut],
      [Tip],
      [GST],
      [UserId]
FROM [tblPayment]
    WHERE 1=1
]]></tblPayment_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblPayment_Delete_By_RowID
        Get
            Return <tblPayment_Delete_By_RowID><![CDATA[
DELETE FROM [tblPayment] WHERE [ID]=@ID_
]]></tblPayment_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblPayment_Delete_By_SELECT
        Get
            Return <tblPayment_Delete_By_SELECT><![CDATA[
DELETE FROM [tblPayment] WHERE 1=1
]]></tblPayment_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblPayment_MAXID
        Get
            Return <tblPayment_MAXID><![CDATA[
SELECT MAX([ID]) FROM [tblPayment] WHERE 1=1
]]></tblPayment_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblPayment_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Transc_ID_ As Int32,
    ByVal Transac_Type_ As String,
    ByVal PaymentMode_ As String,
    ByVal TotalAmount_ As Decimal,
    ByVal CASH_ As Decimal,
    ByVal CARD_ As Decimal,
    ByVal SURCHARGE_P_ As Decimal,
    ByVal SURCHARGE_AMT_ As Decimal,
    ByVal TOTAIL_PAID_ As Decimal,
    ByVal Transc_Time_ As DateTime,
    ByVal Remarks_ As String,
    ByVal Status_ As String,
    ByVal VoucherAmount_ As Decimal,
    ByVal VoucherID_ As Int32,
    ByVal ShiftFee_ As Decimal,
    ByVal MemoNo_ As Int32,
    ByVal CashOut_ As Decimal,
    ByVal Tip_ As Decimal,
    ByVal GST_ As Decimal,
    ByVal UserId_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblPayment_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ID_", ID_)
            .AddWithValue("@Transc_ID_", Transc_ID_)
            .AddWithValue("@Transac_Type_", Transac_Type_)
            .AddWithValue("@PaymentMode_", PaymentMode_)
            .AddWithValue("@TotalAmount_", TotalAmount_)
            .AddWithValue("@CASH_", CASH_)
            .AddWithValue("@CARD_", CARD_)
            .AddWithValue("@SURCHARGE_P_", SURCHARGE_P_)
            .AddWithValue("@SURCHARGE_AMT_", SURCHARGE_AMT_)
            .AddWithValue("@TOTAIL_PAID_", TOTAIL_PAID_)
            .AddWithValue("@Transc_Time_", Transc_Time_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@VoucherAmount_", VoucherAmount_)
            .AddWithValue("@VoucherID_", VoucherID_)
            .AddWithValue("@ShiftFee_", ShiftFee_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@CashOut_", CashOut_)
            .AddWithValue("@Tip_", Tip_)
            .AddWithValue("@GST_", GST_)
            .AddWithValue("@UserId_", UserId_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ID_
    End Function



    Function Update(
    ByVal Transc_ID_ As Int32,
    ByVal Transac_Type_ As String,
    ByVal PaymentMode_ As String,
    ByVal TotalAmount_ As Decimal,
    ByVal CASH_ As Decimal,
    ByVal CARD_ As Decimal,
    ByVal SURCHARGE_P_ As Decimal,
    ByVal SURCHARGE_AMT_ As Decimal,
    ByVal TOTAIL_PAID_ As Decimal,
    ByVal Transc_Time_ As DateTime,
    ByVal Remarks_ As String,
    ByVal Status_ As String,
    ByVal VoucherAmount_ As Decimal,
    ByVal VoucherID_ As Int32,
    ByVal ShiftFee_ As Decimal,
    ByVal MemoNo_ As Int32,
    ByVal CashOut_ As Decimal,
    ByVal Tip_ As Decimal,
    ByVal GST_ As Decimal,
    ByVal UserId_ As Int32,
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblPayment_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Transc_ID_", Transc_ID_)
            .AddWithValue("@Transac_Type_", Transac_Type_)
            .AddWithValue("@PaymentMode_", PaymentMode_)
            .AddWithValue("@TotalAmount_", TotalAmount_)
            .AddWithValue("@CASH_", CASH_)
            .AddWithValue("@CARD_", CARD_)
            .AddWithValue("@SURCHARGE_P_", SURCHARGE_P_)
            .AddWithValue("@SURCHARGE_AMT_", SURCHARGE_AMT_)
            .AddWithValue("@TOTAIL_PAID_", TOTAIL_PAID_)
            .AddWithValue("@Transc_Time_", Transc_Time_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@VoucherAmount_", VoucherAmount_)
            .AddWithValue("@VoucherID_", VoucherID_)
            .AddWithValue("@ShiftFee_", ShiftFee_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@CashOut_", CashOut_)
            .AddWithValue("@Tip_", Tip_)
            .AddWithValue("@GST_", GST_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@ID_", ID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.Transc_ID
                fn = "Transc_ID"
            Case FieldName.Transac_Type
                fn = "Transac_Type"
            Case FieldName.PaymentMode
                fn = "PaymentMode"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.CASH
                fn = "CASH"
            Case FieldName.CARD
                fn = "CARD"
            Case FieldName.SURCHARGE_P
                fn = "SURCHARGE_P"
            Case FieldName.SURCHARGE_AMT
                fn = "SURCHARGE_AMT"
            Case FieldName.TOTAIL_PAID
                fn = "TOTAIL_PAID"
            Case FieldName.Transc_Time
                fn = "Transc_Time"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.VoucherAmount
                fn = "VoucherAmount"
            Case FieldName.VoucherID
                fn = "VoucherID"
            Case FieldName.ShiftFee
                fn = "ShiftFee"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.CashOut
                fn = "CashOut"
            Case FieldName.Tip
                fn = "Tip"
            Case FieldName.GST
                fn = "GST"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblPayment] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblPayment_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblPayment_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ID_", ID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ID_
    End Function



    Function Selection_One_Row(
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblPayment_select & "  AND [ID]=@ID_"

        With comSelection.Parameters
            .AddWithValue("@ID_", ID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ID") Is DBNull.Value Then : .ID_ = dt.Rows(0).Item("ID") : End If
                If Not dt.Rows(0).Item("Transc_ID") Is DBNull.Value Then : .Transc_ID_ = dt.Rows(0).Item("Transc_ID") : End If
                If Not dt.Rows(0).Item("Transac_Type") Is DBNull.Value Then : .Transac_Type_ = dt.Rows(0).Item("Transac_Type") : End If
                If Not dt.Rows(0).Item("PaymentMode") Is DBNull.Value Then : .PaymentMode_ = dt.Rows(0).Item("PaymentMode") : End If
                If Not dt.Rows(0).Item("TotalAmount") Is DBNull.Value Then : .TotalAmount_ = dt.Rows(0).Item("TotalAmount") : End If
                If Not dt.Rows(0).Item("CASH") Is DBNull.Value Then : .CASH_ = dt.Rows(0).Item("CASH") : End If
                If Not dt.Rows(0).Item("CARD") Is DBNull.Value Then : .CARD_ = dt.Rows(0).Item("CARD") : End If
                If Not dt.Rows(0).Item("SURCHARGE_P") Is DBNull.Value Then : .SURCHARGE_P_ = dt.Rows(0).Item("SURCHARGE_P") : End If
                If Not dt.Rows(0).Item("SURCHARGE_AMT") Is DBNull.Value Then : .SURCHARGE_AMT_ = dt.Rows(0).Item("SURCHARGE_AMT") : End If
                If Not dt.Rows(0).Item("TOTAIL_PAID") Is DBNull.Value Then : .TOTAIL_PAID_ = dt.Rows(0).Item("TOTAIL_PAID") : End If
                If Not dt.Rows(0).Item("Transc_Time") Is DBNull.Value Then : .Transc_Time_ = dt.Rows(0).Item("Transc_Time") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("VoucherAmount") Is DBNull.Value Then : .VoucherAmount_ = dt.Rows(0).Item("VoucherAmount") : End If
                If Not dt.Rows(0).Item("VoucherID") Is DBNull.Value Then : .VoucherID_ = dt.Rows(0).Item("VoucherID") : End If
                If Not dt.Rows(0).Item("ShiftFee") Is DBNull.Value Then : .ShiftFee_ = dt.Rows(0).Item("ShiftFee") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("CashOut") Is DBNull.Value Then : .CashOut_ = dt.Rows(0).Item("CashOut") : End If
                If Not dt.Rows(0).Item("Tip") Is DBNull.Value Then : .Tip_ = dt.Rows(0).Item("Tip") : End If
                If Not dt.Rows(0).Item("GST") Is DBNull.Value Then : .GST_ = dt.Rows(0).Item("GST") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblPayment_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ID") Is DBNull.Value Then : .ID_ = dt.Rows(0).Item("ID") : End If
                If Not dt.Rows(0).Item("Transc_ID") Is DBNull.Value Then : .Transc_ID_ = dt.Rows(0).Item("Transc_ID") : End If
                If Not dt.Rows(0).Item("Transac_Type") Is DBNull.Value Then : .Transac_Type_ = dt.Rows(0).Item("Transac_Type") : End If
                If Not dt.Rows(0).Item("PaymentMode") Is DBNull.Value Then : .PaymentMode_ = dt.Rows(0).Item("PaymentMode") : End If
                If Not dt.Rows(0).Item("TotalAmount") Is DBNull.Value Then : .TotalAmount_ = dt.Rows(0).Item("TotalAmount") : End If
                If Not dt.Rows(0).Item("CASH") Is DBNull.Value Then : .CASH_ = dt.Rows(0).Item("CASH") : End If
                If Not dt.Rows(0).Item("CARD") Is DBNull.Value Then : .CARD_ = dt.Rows(0).Item("CARD") : End If
                If Not dt.Rows(0).Item("SURCHARGE_P") Is DBNull.Value Then : .SURCHARGE_P_ = dt.Rows(0).Item("SURCHARGE_P") : End If
                If Not dt.Rows(0).Item("SURCHARGE_AMT") Is DBNull.Value Then : .SURCHARGE_AMT_ = dt.Rows(0).Item("SURCHARGE_AMT") : End If
                If Not dt.Rows(0).Item("TOTAIL_PAID") Is DBNull.Value Then : .TOTAIL_PAID_ = dt.Rows(0).Item("TOTAIL_PAID") : End If
                If Not dt.Rows(0).Item("Transc_Time") Is DBNull.Value Then : .Transc_Time_ = dt.Rows(0).Item("Transc_Time") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("VoucherAmount") Is DBNull.Value Then : .VoucherAmount_ = dt.Rows(0).Item("VoucherAmount") : End If
                If Not dt.Rows(0).Item("VoucherID") Is DBNull.Value Then : .VoucherID_ = dt.Rows(0).Item("VoucherID") : End If
                If Not dt.Rows(0).Item("ShiftFee") Is DBNull.Value Then : .ShiftFee_ = dt.Rows(0).Item("ShiftFee") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("CashOut") Is DBNull.Value Then : .CashOut_ = dt.Rows(0).Item("CashOut") : End If
                If Not dt.Rows(0).Item("Tip") Is DBNull.Value Then : .Tip_ = dt.Rows(0).Item("Tip") : End If
                If Not dt.Rows(0).Item("GST") Is DBNull.Value Then : .GST_ = dt.Rows(0).Item("GST") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.Transc_ID
                fn = "Transc_ID"
            Case FieldName.Transac_Type
                fn = "Transac_Type"
            Case FieldName.PaymentMode
                fn = "PaymentMode"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.CASH
                fn = "CASH"
            Case FieldName.CARD
                fn = "CARD"
            Case FieldName.SURCHARGE_P
                fn = "SURCHARGE_P"
            Case FieldName.SURCHARGE_AMT
                fn = "SURCHARGE_AMT"
            Case FieldName.TOTAIL_PAID
                fn = "TOTAIL_PAID"
            Case FieldName.Transc_Time
                fn = "Transc_Time"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.VoucherAmount
                fn = "VoucherAmount"
            Case FieldName.VoucherID
                fn = "VoucherID"
            Case FieldName.ShiftFee
                fn = "ShiftFee"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.CashOut
                fn = "CashOut"
            Case FieldName.Tip
                fn = "Tip"
            Case FieldName.GST
                fn = "GST"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblPayment] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.Transc_ID
                fn = "Transc_ID"
            Case FieldName.Transac_Type
                fn = "Transac_Type"
            Case FieldName.PaymentMode
                fn = "PaymentMode"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.CASH
                fn = "CASH"
            Case FieldName.CARD
                fn = "CARD"
            Case FieldName.SURCHARGE_P
                fn = "SURCHARGE_P"
            Case FieldName.SURCHARGE_AMT
                fn = "SURCHARGE_AMT"
            Case FieldName.TOTAIL_PAID
                fn = "TOTAIL_PAID"
            Case FieldName.Transc_Time
                fn = "Transc_Time"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.VoucherAmount
                fn = "VoucherAmount"
            Case FieldName.VoucherID
                fn = "VoucherID"
            Case FieldName.ShiftFee
                fn = "ShiftFee"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.CashOut
                fn = "CashOut"
            Case FieldName.Tip
                fn = "Tip"
            Case FieldName.GST
                fn = "GST"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblPayment] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblMembers
    Public Shared tablename As String = "tblMembers"


    Structure Fields


        Dim MemberID_ As String
        Dim Sl_ As Int32
        Dim Name_ As String
        Dim Phone_ As String
        Dim Address_ As String
        Dim CreatedDate_ As DateTime

    End Structure


    Enum FieldName


        [MemberID]
        [Sl]
        [Name]
        [Phone]
        [Address]
        [CreatedDate]

    End Enum


    Public ReadOnly Property tblMembers_insert
        Get
            Return <tblMembers_insert><![CDATA[
  INSERT INTO [tblMembers]
  (
      [MemberID],
      [Sl],
      [Name],
      [Phone],
      [Address],
      [CreatedDate]
  )
  VALUES
  (
      @MemberID_,
      @Sl_,
      @Name_,
      @Phone_,
      @Address_,
      @CreatedDate_
  )
]]></tblMembers_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblMembers_update
        Get
            Return <tblMembers_update><![CDATA[
UPDATE [tblMembers]
Set 
    [Sl]=@Sl_,
    [Name]=@Name_,
    [Phone]=@Phone_,
    [Address]=@Address_,
    [CreatedDate]=@CreatedDate_
 WHERE [MemberID]=@MemberID_
]]></tblMembers_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblMembers_select
        Get
            Return <tblMembers_select><![CDATA[
SELECT 
      [MemberID],
      [Sl],
      [Name],
      [Phone],
      [Address],
      [CreatedDate]
FROM [tblMembers]
    WHERE 1=1
]]></tblMembers_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblMembers_Delete_By_RowID
        Get
            Return <tblMembers_Delete_By_RowID><![CDATA[
DELETE FROM [tblMembers] WHERE [MemberID]=@MemberID_
]]></tblMembers_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblMembers_Delete_By_SELECT
        Get
            Return <tblMembers_Delete_By_SELECT><![CDATA[
DELETE FROM [tblMembers] WHERE 1=1
]]></tblMembers_Delete_By_SELECT>.Value
        End Get
    End Property


    Function Insert(
    ByVal MemberID_ As String,
    ByVal Sl_ As Int32,
    ByVal Name_ As String,
    ByVal Phone_ As String,
    ByVal Address_ As String,
    ByVal CreatedDate_ As DateTime,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing


        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblMembers_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@MemberID_", MemberID_)
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@Name_", Name_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@CreatedDate_", CreatedDate_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return 0
    End Function



    Function Update(
    ByVal Sl_ As Int32,
    ByVal Name_ As String,
    ByVal Phone_ As String,
    ByVal Address_ As String,
    ByVal CreatedDate_ As DateTime,
    ByVal MemberID_ As String,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblMembers_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@Name_", Name_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@MemberID_", MemberID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return 0
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.MemberID
                fn = "MemberID"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Name
                fn = "Name"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblMembers] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblMembers_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal MemberID_ As String,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblMembers_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@MemberID_", MemberID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return 0
    End Function



    Function Selection_One_Row(
    ByVal MemberID_ As String,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblMembers_select & "  AND [MemberID]=@MemberID_"

        With comSelection.Parameters
            .AddWithValue("@MemberID_", MemberID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("MemberID") Is DBNull.Value Then : .MemberID_ = dt.Rows(0).Item("MemberID") : End If
                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("Name") Is DBNull.Value Then : .Name_ = dt.Rows(0).Item("Name") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblMembers_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("MemberID") Is DBNull.Value Then : .MemberID_ = dt.Rows(0).Item("MemberID") : End If
                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("Name") Is DBNull.Value Then : .Name_ = dt.Rows(0).Item("Name") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.MemberID
                fn = "MemberID"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Name
                fn = "Name"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblMembers] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.MemberID
                fn = "MemberID"
            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Name
                fn = "Name"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblMembers] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblGifts
    Public Shared tablename As String = "tblGifts"


    Structure Fields


        Dim sl_ As Int32
        Dim date_ As DateTime
        Dim bookingid_ As Int32
        Dim gift_amount_ As Decimal
        Dim gift_type_ As String
        Dim userid_ As Int32

    End Structure


    Enum FieldName


        [sl]
        [date]
        [bookingid]
        [gift_amount]
        [gift_type]
        [userid]

    End Enum


    Public ReadOnly Property tblGifts_insert
        Get
            Return <tblGifts_insert><![CDATA[
  INSERT INTO [tblGifts]
  (
      [sl],
      [date],
      [bookingid],
      [gift_amount],
      [gift_type],
      [userid]
  )
  VALUES
  (
      @sl_,
      @date_,
      @bookingid_,
      @gift_amount_,
      @gift_type_,
      @userid_
  )
]]></tblGifts_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblGifts_update
        Get
            Return <tblGifts_update><![CDATA[
UPDATE [tblGifts]
Set 
    [date]=@date_,
    [bookingid]=@bookingid_,
    [gift_amount]=@gift_amount_,
    [gift_type]=@gift_type_,
    [userid]=@userid_
 WHERE [sl]=@sl_
]]></tblGifts_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblGifts_select
        Get
            Return <tblGifts_select><![CDATA[
SELECT 
      [sl],
      [date],
      [bookingid],
      [gift_amount],
      [gift_type],
      [userid]
FROM [tblGifts]
    WHERE 1=1
]]></tblGifts_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblGifts_Delete_By_RowID
        Get
            Return <tblGifts_Delete_By_RowID><![CDATA[
DELETE FROM [tblGifts] WHERE [sl]=@sl_
]]></tblGifts_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblGifts_Delete_By_SELECT
        Get
            Return <tblGifts_Delete_By_SELECT><![CDATA[
DELETE FROM [tblGifts] WHERE 1=1
]]></tblGifts_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblGifts_MAXID
        Get
            Return <tblGifts_MAXID><![CDATA[
SELECT MAX([sl]) FROM [tblGifts] WHERE 1=1
]]></tblGifts_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblGifts_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal date_ As DateTime,
    ByVal bookingid_ As Int32,
    ByVal gift_amount_ As Decimal,
    ByVal gift_type_ As String,
    ByVal userid_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim sl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblGifts_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@sl_", sl_)
            .AddWithValue("@date_", date_)
            .AddWithValue("@bookingid_", bookingid_)
            .AddWithValue("@gift_amount_", gift_amount_)
            .AddWithValue("@gift_type_", gift_type_)
            .AddWithValue("@userid_", userid_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Update(
    ByVal date_ As DateTime,
    ByVal bookingid_ As Int32,
    ByVal gift_amount_ As Decimal,
    ByVal gift_type_ As String,
    ByVal userid_ As Int32,
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblGifts_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@date_", date_)
            .AddWithValue("@bookingid_", bookingid_)
            .AddWithValue("@gift_amount_", gift_amount_)
            .AddWithValue("@gift_type_", gift_type_)
            .AddWithValue("@userid_", userid_)
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return sl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.date
                fn = "date"
            Case FieldName.bookingid
                fn = "bookingid"
            Case FieldName.gift_amount
                fn = "gift_amount"
            Case FieldName.gift_type
                fn = "gift_type"
            Case FieldName.userid
                fn = "userid"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblGifts] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblGifts_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblGifts_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Selection_One_Row(
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblGifts_select & "  AND [sl]=@sl_"

        With comSelection.Parameters
            .AddWithValue("@sl_", sl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("sl") Is DBNull.Value Then : .sl_ = dt.Rows(0).Item("sl") : End If
                If Not dt.Rows(0).Item("date") Is DBNull.Value Then : .date_ = dt.Rows(0).Item("date") : End If
                If Not dt.Rows(0).Item("bookingid") Is DBNull.Value Then : .bookingid_ = dt.Rows(0).Item("bookingid") : End If
                If Not dt.Rows(0).Item("gift_amount") Is DBNull.Value Then : .gift_amount_ = dt.Rows(0).Item("gift_amount") : End If
                If Not dt.Rows(0).Item("gift_type") Is DBNull.Value Then : .gift_type_ = dt.Rows(0).Item("gift_type") : End If
                If Not dt.Rows(0).Item("userid") Is DBNull.Value Then : .userid_ = dt.Rows(0).Item("userid") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblGifts_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("sl") Is DBNull.Value Then : .sl_ = dt.Rows(0).Item("sl") : End If
                If Not dt.Rows(0).Item("date") Is DBNull.Value Then : .date_ = dt.Rows(0).Item("date") : End If
                If Not dt.Rows(0).Item("bookingid") Is DBNull.Value Then : .bookingid_ = dt.Rows(0).Item("bookingid") : End If
                If Not dt.Rows(0).Item("gift_amount") Is DBNull.Value Then : .gift_amount_ = dt.Rows(0).Item("gift_amount") : End If
                If Not dt.Rows(0).Item("gift_type") Is DBNull.Value Then : .gift_type_ = dt.Rows(0).Item("gift_type") : End If
                If Not dt.Rows(0).Item("userid") Is DBNull.Value Then : .userid_ = dt.Rows(0).Item("userid") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.date
                fn = "date"
            Case FieldName.bookingid
                fn = "bookingid"
            Case FieldName.gift_amount
                fn = "gift_amount"
            Case FieldName.gift_type
                fn = "gift_type"
            Case FieldName.userid
                fn = "userid"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblGifts] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.date
                fn = "date"
            Case FieldName.bookingid
                fn = "bookingid"
            Case FieldName.gift_amount
                fn = "gift_amount"
            Case FieldName.gift_type
                fn = "gift_type"
            Case FieldName.userid
                fn = "userid"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblGifts] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblLookUp
    Public Shared tablename As String = "tblLookUp"


    Structure Fields


        Dim sl_ As Int32
        Dim Worker_ As Int32
        Dim Client_ As Int32
        Dim Booking_ As Int32
        Dim Message_ As String
        Dim Extras_ As String
        Dim Service_ As Int32
        Dim SP_Amount_ As Decimal
        Dim House_Amount_ As Decimal
        Dim TotalAmount_ As Decimal
        Dim Type_ As String
        Dim ServiceType_ As String
        Dim Room_ As String
        Dim CreatedDate_ As DateTime

    End Structure


    Enum FieldName


        [sl]
        [Worker]
        [Client]
        [Booking]
        [Message]
        [Extras]
        [Service]
        [SP_Amount]
        [House_Amount]
        [TotalAmount]
        [Type]
        [ServiceType]
        [Room]
        [CreatedDate]

    End Enum


    Public ReadOnly Property tblLookUp_insert
        Get
            Return <tblLookUp_insert><![CDATA[
  INSERT INTO [tblLookUp]
  (
      [sl],
      [Worker],
      [Client],
      [Booking],
      [Message],
      [Extras],
      [Service],
      [SP_Amount],
      [House_Amount],
      [TotalAmount],
      [Type],
      [ServiceType],
      [Room],
      [CreatedDate]
  )
  VALUES
  (
      @sl_,
      @Worker_,
      @Client_,
      @Booking_,
      @Message_,
      @Extras_,
      @Service_,
      @SP_Amount_,
      @House_Amount_,
      @TotalAmount_,
      @Type_,
      @ServiceType_,
      @Room_,
      @CreatedDate_
  )
]]></tblLookUp_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblLookUp_update
        Get
            Return <tblLookUp_update><![CDATA[
UPDATE [tblLookUp]
Set 
    [Worker]=@Worker_,
    [Client]=@Client_,
    [Booking]=@Booking_,
    [Message]=@Message_,
    [Extras]=@Extras_,
    [Service]=@Service_,
    [SP_Amount]=@SP_Amount_,
    [House_Amount]=@House_Amount_,
    [TotalAmount]=@TotalAmount_,
    [Type]=@Type_,
    [ServiceType]=@ServiceType_,
    [Room]=@Room_,
    [CreatedDate]=@CreatedDate_
 WHERE [sl]=@sl_
]]></tblLookUp_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblLookUp_select
        Get
            Return <tblLookUp_select><![CDATA[
SELECT 
      [sl],
      [Worker],
      [Client],
      [Booking],
      [Message],
      [Extras],
      [Service],
      [SP_Amount],
      [House_Amount],
      [TotalAmount],
      [Type],
      [ServiceType],
      [Room],
      [CreatedDate]
FROM [tblLookUp]
    WHERE 1=1
]]></tblLookUp_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblLookUp_Delete_By_RowID
        Get
            Return <tblLookUp_Delete_By_RowID><![CDATA[
DELETE FROM [tblLookUp] WHERE [sl]=@sl_
]]></tblLookUp_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblLookUp_Delete_By_SELECT
        Get
            Return <tblLookUp_Delete_By_SELECT><![CDATA[
DELETE FROM [tblLookUp] WHERE 1=1
]]></tblLookUp_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblLookUp_MAXID
        Get
            Return <tblLookUp_MAXID><![CDATA[
SELECT MAX([sl]) FROM [tblLookUp] WHERE 1=1
]]></tblLookUp_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblLookUp_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Worker_ As Int32,
    ByVal Client_ As Int32,
    ByVal Booking_ As Int32,
    ByVal Message_ As String,
    ByVal Extras_ As String,
    ByVal Service_ As Int32,
    ByVal SP_Amount_ As Decimal,
    ByVal House_Amount_ As Decimal,
    ByVal TotalAmount_ As Decimal,
    ByVal Type_ As String,
    ByVal ServiceType_ As String,
    ByVal Room_ As String,
    ByVal CreatedDate_ As DateTime,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim sl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblLookUp_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@sl_", sl_)
            .AddWithValue("@Worker_", Worker_)
            .AddWithValue("@Client_", Client_)
            .AddWithValue("@Booking_", Booking_)
            .AddWithValue("@Message_", Message_)
            .AddWithValue("@Extras_", Extras_)
            .AddWithValue("@Service_", Service_)
            .AddWithValue("@SP_Amount_", SP_Amount_)
            .AddWithValue("@House_Amount_", House_Amount_)
            .AddWithValue("@TotalAmount_", TotalAmount_)
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@ServiceType_", ServiceType_)
            .AddWithValue("@Room_", Room_)
            .AddWithValue("@CreatedDate_", CreatedDate_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Update(
    ByVal Worker_ As Int32,
    ByVal Client_ As Int32,
    ByVal Booking_ As Int32,
    ByVal Message_ As String,
    ByVal Extras_ As String,
    ByVal Service_ As Int32,
    ByVal SP_Amount_ As Decimal,
    ByVal House_Amount_ As Decimal,
    ByVal TotalAmount_ As Decimal,
    ByVal Type_ As String,
    ByVal ServiceType_ As String,
    ByVal Room_ As String,
    ByVal CreatedDate_ As DateTime,
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblLookUp_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Worker_", Worker_)
            .AddWithValue("@Client_", Client_)
            .AddWithValue("@Booking_", Booking_)
            .AddWithValue("@Message_", Message_)
            .AddWithValue("@Extras_", Extras_)
            .AddWithValue("@Service_", Service_)
            .AddWithValue("@SP_Amount_", SP_Amount_)
            .AddWithValue("@House_Amount_", House_Amount_)
            .AddWithValue("@TotalAmount_", TotalAmount_)
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@ServiceType_", ServiceType_)
            .AddWithValue("@Room_", Room_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return sl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.Worker
                fn = "Worker"
            Case FieldName.Client
                fn = "Client"
            Case FieldName.Booking
                fn = "Booking"
            Case FieldName.Message
                fn = "Message"
            Case FieldName.Extras
                fn = "Extras"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.SP_Amount
                fn = "SP_Amount"
            Case FieldName.House_Amount
                fn = "House_Amount"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.ServiceType
                fn = "ServiceType"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblLookUp] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblLookUp_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblLookUp_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Selection_One_Row(
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblLookUp_select & "  AND [sl]=@sl_"

        With comSelection.Parameters
            .AddWithValue("@sl_", sl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("sl") Is DBNull.Value Then : .sl_ = dt.Rows(0).Item("sl") : End If
                If Not dt.Rows(0).Item("Worker") Is DBNull.Value Then : .Worker_ = dt.Rows(0).Item("Worker") : End If
                If Not dt.Rows(0).Item("Client") Is DBNull.Value Then : .Client_ = dt.Rows(0).Item("Client") : End If
                If Not dt.Rows(0).Item("Booking") Is DBNull.Value Then : .Booking_ = dt.Rows(0).Item("Booking") : End If
                If Not dt.Rows(0).Item("Message") Is DBNull.Value Then : .Message_ = dt.Rows(0).Item("Message") : End If
                If Not dt.Rows(0).Item("Extras") Is DBNull.Value Then : .Extras_ = dt.Rows(0).Item("Extras") : End If
                If Not dt.Rows(0).Item("Service") Is DBNull.Value Then : .Service_ = dt.Rows(0).Item("Service") : End If
                If Not dt.Rows(0).Item("SP_Amount") Is DBNull.Value Then : .SP_Amount_ = dt.Rows(0).Item("SP_Amount") : End If
                If Not dt.Rows(0).Item("House_Amount") Is DBNull.Value Then : .House_Amount_ = dt.Rows(0).Item("House_Amount") : End If
                If Not dt.Rows(0).Item("TotalAmount") Is DBNull.Value Then : .TotalAmount_ = dt.Rows(0).Item("TotalAmount") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
                If Not dt.Rows(0).Item("ServiceType") Is DBNull.Value Then : .ServiceType_ = dt.Rows(0).Item("ServiceType") : End If
                If Not dt.Rows(0).Item("Room") Is DBNull.Value Then : .Room_ = dt.Rows(0).Item("Room") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblLookUp_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("sl") Is DBNull.Value Then : .sl_ = dt.Rows(0).Item("sl") : End If
                If Not dt.Rows(0).Item("Worker") Is DBNull.Value Then : .Worker_ = dt.Rows(0).Item("Worker") : End If
                If Not dt.Rows(0).Item("Client") Is DBNull.Value Then : .Client_ = dt.Rows(0).Item("Client") : End If
                If Not dt.Rows(0).Item("Booking") Is DBNull.Value Then : .Booking_ = dt.Rows(0).Item("Booking") : End If
                If Not dt.Rows(0).Item("Message") Is DBNull.Value Then : .Message_ = dt.Rows(0).Item("Message") : End If
                If Not dt.Rows(0).Item("Extras") Is DBNull.Value Then : .Extras_ = dt.Rows(0).Item("Extras") : End If
                If Not dt.Rows(0).Item("Service") Is DBNull.Value Then : .Service_ = dt.Rows(0).Item("Service") : End If
                If Not dt.Rows(0).Item("SP_Amount") Is DBNull.Value Then : .SP_Amount_ = dt.Rows(0).Item("SP_Amount") : End If
                If Not dt.Rows(0).Item("House_Amount") Is DBNull.Value Then : .House_Amount_ = dt.Rows(0).Item("House_Amount") : End If
                If Not dt.Rows(0).Item("TotalAmount") Is DBNull.Value Then : .TotalAmount_ = dt.Rows(0).Item("TotalAmount") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
                If Not dt.Rows(0).Item("ServiceType") Is DBNull.Value Then : .ServiceType_ = dt.Rows(0).Item("ServiceType") : End If
                If Not dt.Rows(0).Item("Room") Is DBNull.Value Then : .Room_ = dt.Rows(0).Item("Room") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.Worker
                fn = "Worker"
            Case FieldName.Client
                fn = "Client"
            Case FieldName.Booking
                fn = "Booking"
            Case FieldName.Message
                fn = "Message"
            Case FieldName.Extras
                fn = "Extras"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.SP_Amount
                fn = "SP_Amount"
            Case FieldName.House_Amount
                fn = "House_Amount"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.ServiceType
                fn = "ServiceType"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblLookUp] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.Worker
                fn = "Worker"
            Case FieldName.Client
                fn = "Client"
            Case FieldName.Booking
                fn = "Booking"
            Case FieldName.Message
                fn = "Message"
            Case FieldName.Extras
                fn = "Extras"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.SP_Amount
                fn = "SP_Amount"
            Case FieldName.House_Amount
                fn = "House_Amount"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.ServiceType
                fn = "ServiceType"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblLookUp] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblLockerBooking
    Public Shared tablename As String = "tblLockerBooking"


    Structure Fields


        Dim Sl_ As Int32
        Dim LockerNumber_ As String
        Dim ClientName_ As String
        Dim PhoneNumber_ As String
        Dim Address_ As String
        Dim BookingDate_ As DateTime
        Dim StartDate_ As DateTime
        Dim EndDate_ As DateTime
        Dim Status_ As String
        Dim Time_ As Int32
        Dim TimeType_ As String
        Dim Price_ As Int32
        Dim WorkerID_ As Int32

    End Structure


    Enum FieldName


        [Sl]
        [LockerNumber]
        [ClientName]
        [PhoneNumber]
        [Address]
        [BookingDate]
        [StartDate]
        [EndDate]
        [Status]
        [Time]
        [TimeType]
        [Price]
        [WorkerID]

    End Enum


    Public ReadOnly Property tblLockerBooking_insert
        Get
            Return <tblLockerBooking_insert><![CDATA[
  INSERT INTO [tblLockerBooking]
  (
      [Sl],
      [LockerNumber],
      [ClientName],
      [PhoneNumber],
      [Address],
      [BookingDate],
      [StartDate],
      [EndDate],
      [Status],
      [Time],
      [TimeType],
      [Price],
      [WorkerID]
  )
  VALUES
  (
      @Sl_,
      @LockerNumber_,
      @ClientName_,
      @PhoneNumber_,
      @Address_,
      @BookingDate_,
      @StartDate_,
      @EndDate_,
      @Status_,
      @Time_,
      @TimeType_,
      @Price_,
      @WorkerID_
  )
]]></tblLockerBooking_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblLockerBooking_update
        Get
            Return <tblLockerBooking_update><![CDATA[
UPDATE [tblLockerBooking]
Set 
    [LockerNumber]=@LockerNumber_,
    [ClientName]=@ClientName_,
    [PhoneNumber]=@PhoneNumber_,
    [Address]=@Address_,
    [BookingDate]=@BookingDate_,
    [StartDate]=@StartDate_,
    [EndDate]=@EndDate_,
    [Status]=@Status_,
    [Time]=@Time_,
    [TimeType]=@TimeType_,
    [Price]=@Price_,
    [WorkerID]=@WorkerID_
 WHERE [Sl]=@Sl_
]]></tblLockerBooking_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblLockerBooking_select
        Get
            Return <tblLockerBooking_select><![CDATA[
SELECT 
      [Sl],
      [LockerNumber],
      [ClientName],
      [PhoneNumber],
      [Address],
      [BookingDate],
      [StartDate],
      [EndDate],
      [Status],
      [Time],
      [TimeType],
      [Price],
      [WorkerID]
FROM [tblLockerBooking]
    WHERE 1=1
]]></tblLockerBooking_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblLockerBooking_Delete_By_RowID
        Get
            Return <tblLockerBooking_Delete_By_RowID><![CDATA[
DELETE FROM [tblLockerBooking] WHERE [Sl]=@Sl_
]]></tblLockerBooking_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblLockerBooking_Delete_By_SELECT
        Get
            Return <tblLockerBooking_Delete_By_SELECT><![CDATA[
DELETE FROM [tblLockerBooking] WHERE 1=1
]]></tblLockerBooking_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblLockerBooking_MAXID
        Get
            Return <tblLockerBooking_MAXID><![CDATA[
SELECT MAX([Sl]) FROM [tblLockerBooking] WHERE 1=1
]]></tblLockerBooking_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblLockerBooking_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal LockerNumber_ As String,
    ByVal ClientName_ As String,
    ByVal PhoneNumber_ As String,
    ByVal Address_ As String,
    ByVal BookingDate_ As DateTime,
    ByVal StartDate_ As DateTime,
    ByVal EndDate_ As DateTime,
    ByVal Status_ As String,
    ByVal Time_ As Int32,
    ByVal TimeType_ As String,
    ByVal Price_ As Int32,
    ByVal WorkerID_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim Sl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblLockerBooking_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@LockerNumber_", LockerNumber_)
            .AddWithValue("@ClientName_", ClientName_)
            .AddWithValue("@PhoneNumber_", PhoneNumber_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@BookingDate_", BookingDate_)
            .AddWithValue("@StartDate_", StartDate_)
            .AddWithValue("@EndDate_", EndDate_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Time_", Time_)
            .AddWithValue("@TimeType_", TimeType_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@WorkerID_", WorkerID_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Sl_
    End Function



    Function Update(
    ByVal LockerNumber_ As String,
    ByVal ClientName_ As String,
    ByVal PhoneNumber_ As String,
    ByVal Address_ As String,
    ByVal BookingDate_ As DateTime,
    ByVal StartDate_ As DateTime,
    ByVal EndDate_ As DateTime,
    ByVal Status_ As String,
    ByVal Time_ As Int32,
    ByVal TimeType_ As String,
    ByVal Price_ As Int32,
    ByVal WorkerID_ As Int32,
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblLockerBooking_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@LockerNumber_", LockerNumber_)
            .AddWithValue("@ClientName_", ClientName_)
            .AddWithValue("@PhoneNumber_", PhoneNumber_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@BookingDate_", BookingDate_)
            .AddWithValue("@StartDate_", StartDate_)
            .AddWithValue("@EndDate_", EndDate_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Time_", Time_)
            .AddWithValue("@TimeType_", TimeType_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@Sl_", Sl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return Sl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.LockerNumber
                fn = "LockerNumber"
            Case FieldName.ClientName
                fn = "ClientName"
            Case FieldName.PhoneNumber
                fn = "PhoneNumber"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.BookingDate
                fn = "BookingDate"
            Case FieldName.StartDate
                fn = "StartDate"
            Case FieldName.EndDate
                fn = "EndDate"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Time
                fn = "Time"
            Case FieldName.TimeType
                fn = "TimeType"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.WorkerID
                fn = "WorkerID"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblLockerBooking] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblLockerBooking_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblLockerBooking_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@Sl_", Sl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Sl_
    End Function



    Function Selection_One_Row(
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblLockerBooking_select & "  AND [Sl]=@Sl_"

        With comSelection.Parameters
            .AddWithValue("@Sl_", Sl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("LockerNumber") Is DBNull.Value Then : .LockerNumber_ = dt.Rows(0).Item("LockerNumber") : End If
                If Not dt.Rows(0).Item("ClientName") Is DBNull.Value Then : .ClientName_ = dt.Rows(0).Item("ClientName") : End If
                If Not dt.Rows(0).Item("PhoneNumber") Is DBNull.Value Then : .PhoneNumber_ = dt.Rows(0).Item("PhoneNumber") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("BookingDate") Is DBNull.Value Then : .BookingDate_ = dt.Rows(0).Item("BookingDate") : End If
                If Not dt.Rows(0).Item("StartDate") Is DBNull.Value Then : .StartDate_ = dt.Rows(0).Item("StartDate") : End If
                If Not dt.Rows(0).Item("EndDate") Is DBNull.Value Then : .EndDate_ = dt.Rows(0).Item("EndDate") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Time") Is DBNull.Value Then : .Time_ = dt.Rows(0).Item("Time") : End If
                If Not dt.Rows(0).Item("TimeType") Is DBNull.Value Then : .TimeType_ = dt.Rows(0).Item("TimeType") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblLockerBooking_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("LockerNumber") Is DBNull.Value Then : .LockerNumber_ = dt.Rows(0).Item("LockerNumber") : End If
                If Not dt.Rows(0).Item("ClientName") Is DBNull.Value Then : .ClientName_ = dt.Rows(0).Item("ClientName") : End If
                If Not dt.Rows(0).Item("PhoneNumber") Is DBNull.Value Then : .PhoneNumber_ = dt.Rows(0).Item("PhoneNumber") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("BookingDate") Is DBNull.Value Then : .BookingDate_ = dt.Rows(0).Item("BookingDate") : End If
                If Not dt.Rows(0).Item("StartDate") Is DBNull.Value Then : .StartDate_ = dt.Rows(0).Item("StartDate") : End If
                If Not dt.Rows(0).Item("EndDate") Is DBNull.Value Then : .EndDate_ = dt.Rows(0).Item("EndDate") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Time") Is DBNull.Value Then : .Time_ = dt.Rows(0).Item("Time") : End If
                If Not dt.Rows(0).Item("TimeType") Is DBNull.Value Then : .TimeType_ = dt.Rows(0).Item("TimeType") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.LockerNumber
                fn = "LockerNumber"
            Case FieldName.ClientName
                fn = "ClientName"
            Case FieldName.PhoneNumber
                fn = "PhoneNumber"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.BookingDate
                fn = "BookingDate"
            Case FieldName.StartDate
                fn = "StartDate"
            Case FieldName.EndDate
                fn = "EndDate"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Time
                fn = "Time"
            Case FieldName.TimeType
                fn = "TimeType"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.WorkerID
                fn = "WorkerID"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblLockerBooking] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.LockerNumber
                fn = "LockerNumber"
            Case FieldName.ClientName
                fn = "ClientName"
            Case FieldName.PhoneNumber
                fn = "PhoneNumber"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.BookingDate
                fn = "BookingDate"
            Case FieldName.StartDate
                fn = "StartDate"
            Case FieldName.EndDate
                fn = "EndDate"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Time
                fn = "Time"
            Case FieldName.TimeType
                fn = "TimeType"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.WorkerID
                fn = "WorkerID"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblLockerBooking] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblLocker
    Public Shared tablename As String = "tblLocker"


    Structure Fields


        Dim Sl_ As Int32
        Dim LockerNumber_ As String
        Dim LockerName_ As String
        Dim Price_ As Int32
        Dim Description_ As String
        Dim DateCreated_ As DateTime
        Dim LastAccessed_ As DateTime
        Dim UserId_ As Int32

    End Structure


    Enum FieldName


        [Sl]
        [LockerNumber]
        [LockerName]
        [Price]
        [Description]
        [DateCreated]
        [LastAccessed]
        [UserId]

    End Enum


    Public ReadOnly Property tblLocker_insert
        Get
            Return <tblLocker_insert><![CDATA[
  INSERT INTO [tblLocker]
  (
      [Sl],
      [LockerNumber],
      [LockerName],
      [Price],
      [Description],
      [DateCreated],
      [LastAccessed],
      [UserId]
  )
  VALUES
  (
      @Sl_,
      @LockerNumber_,
      @LockerName_,
      @Price_,
      @Description_,
      @DateCreated_,
      @LastAccessed_,
      @UserId_
  )
]]></tblLocker_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblLocker_update
        Get
            Return <tblLocker_update><![CDATA[
UPDATE [tblLocker]
Set 
    [Sl]=@Sl_,
    [LockerName]=@LockerName_,
    [Price]=@Price_,
    [Description]=@Description_,
    [DateCreated]=@DateCreated_,
    [LastAccessed]=@LastAccessed_,
    [UserId]=@UserId_
 WHERE [LockerNumber]=@LockerNumber_
]]></tblLocker_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblLocker_select
        Get
            Return <tblLocker_select><![CDATA[
SELECT 
      [Sl],
      [LockerNumber],
      [LockerName],
      [Price],
      [Description],
      [DateCreated],
      [LastAccessed],
      [UserId]
FROM [tblLocker]
    WHERE 1=1
]]></tblLocker_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblLocker_Delete_By_RowID
        Get
            Return <tblLocker_Delete_By_RowID><![CDATA[
DELETE FROM [tblLocker] WHERE [LockerNumber]=@LockerNumber_
]]></tblLocker_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblLocker_Delete_By_SELECT
        Get
            Return <tblLocker_Delete_By_SELECT><![CDATA[
DELETE FROM [tblLocker] WHERE 1=1
]]></tblLocker_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblLocker_MAXID
        Get
            Return <tblLocker_MAXID><![CDATA[
SELECT MAX([LockerNumber]) FROM [tblLocker] WHERE 1=1
]]></tblLocker_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblLocker_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Sl_ As Int32,
    ByVal LockerName_ As String,
    ByVal Price_ As Int32,
    ByVal Description_ As String,
    ByVal DateCreated_ As DateTime,
    ByVal LastAccessed_ As DateTime,
    ByVal UserId_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim LockerNumber_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblLocker_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@LockerNumber_", LockerNumber_)
            .AddWithValue("@LockerName_", LockerName_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Description_", Description_)
            .AddWithValue("@DateCreated_", DateCreated_)
            .AddWithValue("@LastAccessed_", LastAccessed_)
            .AddWithValue("@UserId_", UserId_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return LockerNumber_
    End Function



    Function Update(
    ByVal Sl_ As Int32,
    ByVal LockerName_ As String,
    ByVal Price_ As Int32,
    ByVal Description_ As String,
    ByVal DateCreated_ As DateTime,
    ByVal LastAccessed_ As DateTime,
    ByVal UserId_ As Int32,
    ByVal LockerNumber_ As String,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblLocker_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@LockerName_", LockerName_)
            .AddWithValue("@Price_", Price_)
            .AddWithValue("@Description_", Description_)
            .AddWithValue("@DateCreated_", DateCreated_)
            .AddWithValue("@LastAccessed_", LastAccessed_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@LockerNumber_", LockerNumber_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return LockerNumber_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.LockerNumber
                fn = "LockerNumber"
            Case FieldName.LockerName
                fn = "LockerName"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Description
                fn = "Description"
            Case FieldName.DateCreated
                fn = "DateCreated"
            Case FieldName.LastAccessed
                fn = "LastAccessed"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblLocker] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblLocker_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal LockerNumber_ As String,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblLocker_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@LockerNumber_", LockerNumber_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return LockerNumber_
    End Function



    Function Selection_One_Row(
    ByVal LockerNumber_ As String,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblLocker_select & "  AND [LockerNumber]=@LockerNumber_"

        With comSelection.Parameters
            .AddWithValue("@LockerNumber_", LockerNumber_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("LockerNumber") Is DBNull.Value Then : .LockerNumber_ = dt.Rows(0).Item("LockerNumber") : End If
                If Not dt.Rows(0).Item("LockerName") Is DBNull.Value Then : .LockerName_ = dt.Rows(0).Item("LockerName") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Description") Is DBNull.Value Then : .Description_ = dt.Rows(0).Item("Description") : End If
                If Not dt.Rows(0).Item("DateCreated") Is DBNull.Value Then : .DateCreated_ = dt.Rows(0).Item("DateCreated") : End If
                If Not dt.Rows(0).Item("LastAccessed") Is DBNull.Value Then : .LastAccessed_ = dt.Rows(0).Item("LastAccessed") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblLocker_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("LockerNumber") Is DBNull.Value Then : .LockerNumber_ = dt.Rows(0).Item("LockerNumber") : End If
                If Not dt.Rows(0).Item("LockerName") Is DBNull.Value Then : .LockerName_ = dt.Rows(0).Item("LockerName") : End If
                If Not dt.Rows(0).Item("Price") Is DBNull.Value Then : .Price_ = dt.Rows(0).Item("Price") : End If
                If Not dt.Rows(0).Item("Description") Is DBNull.Value Then : .Description_ = dt.Rows(0).Item("Description") : End If
                If Not dt.Rows(0).Item("DateCreated") Is DBNull.Value Then : .DateCreated_ = dt.Rows(0).Item("DateCreated") : End If
                If Not dt.Rows(0).Item("LastAccessed") Is DBNull.Value Then : .LastAccessed_ = dt.Rows(0).Item("LastAccessed") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.LockerNumber
                fn = "LockerNumber"
            Case FieldName.LockerName
                fn = "LockerName"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Description
                fn = "Description"
            Case FieldName.DateCreated
                fn = "DateCreated"
            Case FieldName.LastAccessed
                fn = "LastAccessed"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblLocker] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.LockerNumber
                fn = "LockerNumber"
            Case FieldName.LockerName
                fn = "LockerName"
            Case FieldName.Price
                fn = "Price"
            Case FieldName.Description
                fn = "Description"
            Case FieldName.DateCreated
                fn = "DateCreated"
            Case FieldName.LastAccessed
                fn = "LastAccessed"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblLocker] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblInstant
    Public Shared tablename As String = "tblInstant"


    Structure Fields


        Dim InstantID_ As Int32
        Dim DoorName_ As String
        Dim DoorCharge_ As Int32
        Dim InstantDate_ As DateTime
        Dim TotalAmount_ As Int32
        Dim Qty_ As Int32
        Dim Status_ As String
        Dim MemoNo_ As Int32
        Dim UserId_ As Int32

    End Structure


    Enum FieldName


        [InstantID]
        [DoorName]
        [DoorCharge]
        [InstantDate]
        [TotalAmount]
        [Qty]
        [Status]
        [MemoNo]
        [UserId]

    End Enum


    Public ReadOnly Property tblInstant_insert
        Get
            Return <tblInstant_insert><![CDATA[
  INSERT INTO [tblInstant]
  (
      [InstantID],
      [DoorName],
      [DoorCharge],
      [InstantDate],
      [TotalAmount],
      [Qty],
      [Status],
      [MemoNo],
      [UserId]
  )
  VALUES
  (
      @InstantID_,
      @DoorName_,
      @DoorCharge_,
      @InstantDate_,
      @TotalAmount_,
      @Qty_,
      @Status_,
      @MemoNo_,
      @UserId_
  )
]]></tblInstant_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblInstant_update
        Get
            Return <tblInstant_update><![CDATA[
UPDATE [tblInstant]
Set 
    [DoorName]=@DoorName_,
    [DoorCharge]=@DoorCharge_,
    [InstantDate]=@InstantDate_,
    [TotalAmount]=@TotalAmount_,
    [Qty]=@Qty_,
    [Status]=@Status_,
    [MemoNo]=@MemoNo_,
    [UserId]=@UserId_
 WHERE [InstantID]=@InstantID_
]]></tblInstant_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblInstant_select
        Get
            Return <tblInstant_select><![CDATA[
SELECT 
      [InstantID],
      [DoorName],
      [DoorCharge],
      [InstantDate],
      [TotalAmount],
      [Qty],
      [Status],
      [MemoNo],
      [UserId]
FROM [tblInstant]
    WHERE 1=1
]]></tblInstant_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblInstant_Delete_By_RowID
        Get
            Return <tblInstant_Delete_By_RowID><![CDATA[
DELETE FROM [tblInstant] WHERE [InstantID]=@InstantID_
]]></tblInstant_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblInstant_Delete_By_SELECT
        Get
            Return <tblInstant_Delete_By_SELECT><![CDATA[
DELETE FROM [tblInstant] WHERE 1=1
]]></tblInstant_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblInstant_MAXID
        Get
            Return <tblInstant_MAXID><![CDATA[
SELECT MAX([InstantID]) FROM [tblInstant] WHERE 1=1
]]></tblInstant_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblInstant_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal DoorName_ As String,
    ByVal DoorCharge_ As Int32,
    ByVal InstantDate_ As DateTime,
    ByVal TotalAmount_ As Int32,
    ByVal Qty_ As Int32,
    ByVal Status_ As String,
    ByVal MemoNo_ As Int32,
    ByVal UserId_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim InstantID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblInstant_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@InstantID_", InstantID_)
            .AddWithValue("@DoorName_", DoorName_)
            .AddWithValue("@DoorCharge_", DoorCharge_)
            .AddWithValue("@InstantDate_", InstantDate_)
            .AddWithValue("@TotalAmount_", TotalAmount_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@UserId_", UserId_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return InstantID_
    End Function



    Function Update(
    ByVal DoorName_ As String,
    ByVal DoorCharge_ As Int32,
    ByVal InstantDate_ As DateTime,
    ByVal TotalAmount_ As Int32,
    ByVal Qty_ As Int32,
    ByVal Status_ As String,
    ByVal MemoNo_ As Int32,
    ByVal UserId_ As Int32,
    ByVal InstantID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblInstant_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@DoorName_", DoorName_)
            .AddWithValue("@DoorCharge_", DoorCharge_)
            .AddWithValue("@InstantDate_", InstantDate_)
            .AddWithValue("@TotalAmount_", TotalAmount_)
            .AddWithValue("@Qty_", Qty_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@InstantID_", InstantID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return InstantID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.InstantID
                fn = "InstantID"
            Case FieldName.DoorName
                fn = "DoorName"
            Case FieldName.DoorCharge
                fn = "DoorCharge"
            Case FieldName.InstantDate
                fn = "InstantDate"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblInstant] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblInstant_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal InstantID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblInstant_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@InstantID_", InstantID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return InstantID_
    End Function



    Function Selection_One_Row(
    ByVal InstantID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblInstant_select & "  AND [InstantID]=@InstantID_"

        With comSelection.Parameters
            .AddWithValue("@InstantID_", InstantID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("InstantID") Is DBNull.Value Then : .InstantID_ = dt.Rows(0).Item("InstantID") : End If
                If Not dt.Rows(0).Item("DoorName") Is DBNull.Value Then : .DoorName_ = dt.Rows(0).Item("DoorName") : End If
                If Not dt.Rows(0).Item("DoorCharge") Is DBNull.Value Then : .DoorCharge_ = dt.Rows(0).Item("DoorCharge") : End If
                If Not dt.Rows(0).Item("InstantDate") Is DBNull.Value Then : .InstantDate_ = dt.Rows(0).Item("InstantDate") : End If
                If Not dt.Rows(0).Item("TotalAmount") Is DBNull.Value Then : .TotalAmount_ = dt.Rows(0).Item("TotalAmount") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblInstant_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("InstantID") Is DBNull.Value Then : .InstantID_ = dt.Rows(0).Item("InstantID") : End If
                If Not dt.Rows(0).Item("DoorName") Is DBNull.Value Then : .DoorName_ = dt.Rows(0).Item("DoorName") : End If
                If Not dt.Rows(0).Item("DoorCharge") Is DBNull.Value Then : .DoorCharge_ = dt.Rows(0).Item("DoorCharge") : End If
                If Not dt.Rows(0).Item("InstantDate") Is DBNull.Value Then : .InstantDate_ = dt.Rows(0).Item("InstantDate") : End If
                If Not dt.Rows(0).Item("TotalAmount") Is DBNull.Value Then : .TotalAmount_ = dt.Rows(0).Item("TotalAmount") : End If
                If Not dt.Rows(0).Item("Qty") Is DBNull.Value Then : .Qty_ = dt.Rows(0).Item("Qty") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.InstantID
                fn = "InstantID"
            Case FieldName.DoorName
                fn = "DoorName"
            Case FieldName.DoorCharge
                fn = "DoorCharge"
            Case FieldName.InstantDate
                fn = "InstantDate"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblInstant] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.InstantID
                fn = "InstantID"
            Case FieldName.DoorName
                fn = "DoorName"
            Case FieldName.DoorCharge
                fn = "DoorCharge"
            Case FieldName.InstantDate
                fn = "InstantDate"
            Case FieldName.TotalAmount
                fn = "TotalAmount"
            Case FieldName.Qty
                fn = "Qty"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.UserId
                fn = "UserId"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblInstant] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblExtraService
    Public Shared tablename As String = "tblExtraService"


    Structure Fields


        Dim Sl_ As Int32
        Dim Service_ As Int32
        Dim BookingID_ As Int32
        Dim WorkerID_ As Int32
        Dim CreatedDate_ As DateTime
        Dim MemoNo_ As Int32
        Dim ServiceType_ As String
        Dim UserId_ As Int32
        Dim Shift_ As String

    End Structure


    Enum FieldName


        [Sl]
        [Service]
        [BookingID]
        [WorkerID]
        [CreatedDate]
        [MemoNo]
        [ServiceType]
        [UserId]
        [Shift]

    End Enum


    Public ReadOnly Property tblExtraService_insert
        Get
            Return <tblExtraService_insert><![CDATA[
  INSERT INTO [tblExtraService]
  (
      [Sl],
      [Service],
      [BookingID],
      [WorkerID],
      [CreatedDate],
      [MemoNo],
      [ServiceType],
      [UserId],
      [Shift]
  )
  VALUES
  (
      @Sl_,
      @Service_,
      @BookingID_,
      @WorkerID_,
      @CreatedDate_,
      @MemoNo_,
      @ServiceType_,
      @UserId_,
      @Shift_
  )
]]></tblExtraService_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblExtraService_update
        Get
            Return <tblExtraService_update><![CDATA[
UPDATE [tblExtraService]
Set 
    [Service]=@Service_,
    [BookingID]=@BookingID_,
    [WorkerID]=@WorkerID_,
    [CreatedDate]=@CreatedDate_,
    [MemoNo]=@MemoNo_,
    [ServiceType]=@ServiceType_,
    [UserId]=@UserId_,
    [Shift]=@Shift_
 WHERE [Sl]=@Sl_
]]></tblExtraService_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblExtraService_select
        Get
            Return <tblExtraService_select><![CDATA[
SELECT 
      [Sl],
      [Service],
      [BookingID],
      [WorkerID],
      [CreatedDate],
      [MemoNo],
      [ServiceType],
      [UserId],
      [Shift]
FROM [tblExtraService]
    WHERE 1=1
]]></tblExtraService_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblExtraService_Delete_By_RowID
        Get
            Return <tblExtraService_Delete_By_RowID><![CDATA[
DELETE FROM [tblExtraService] WHERE [Sl]=@Sl_
]]></tblExtraService_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblExtraService_Delete_By_SELECT
        Get
            Return <tblExtraService_Delete_By_SELECT><![CDATA[
DELETE FROM [tblExtraService] WHERE 1=1
]]></tblExtraService_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblExtraService_MAXID
        Get
            Return <tblExtraService_MAXID><![CDATA[
SELECT MAX([Sl]) FROM [tblExtraService] WHERE 1=1
]]></tblExtraService_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblExtraService_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Service_ As Int32,
    ByVal BookingID_ As Int32,
    ByVal WorkerID_ As Int32,
    ByVal CreatedDate_ As DateTime,
    ByVal MemoNo_ As Int32,
    ByVal ServiceType_ As String,
    ByVal UserId_ As Int32,
    ByVal Shift_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim Sl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblExtraService_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@Service_", Service_)
            .AddWithValue("@BookingID_", BookingID_)
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@ServiceType_", ServiceType_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@Shift_", Shift_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Sl_
    End Function



    Function Update(
    ByVal Service_ As Int32,
    ByVal BookingID_ As Int32,
    ByVal WorkerID_ As Int32,
    ByVal CreatedDate_ As DateTime,
    ByVal MemoNo_ As Int32,
    ByVal ServiceType_ As String,
    ByVal UserId_ As Int32,
    ByVal Shift_ As String,
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblExtraService_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Service_", Service_)
            .AddWithValue("@BookingID_", BookingID_)
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@ServiceType_", ServiceType_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@Shift_", Shift_)
            .AddWithValue("@Sl_", Sl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return Sl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.ServiceType
                fn = "ServiceType"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.Shift
                fn = "Shift"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblExtraService] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblExtraService_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblExtraService_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@Sl_", Sl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Sl_
    End Function



    Function Selection_One_Row(
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblExtraService_select & "  AND [Sl]=@Sl_"

        With comSelection.Parameters
            .AddWithValue("@Sl_", Sl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("Service") Is DBNull.Value Then : .Service_ = dt.Rows(0).Item("Service") : End If
                If Not dt.Rows(0).Item("BookingID") Is DBNull.Value Then : .BookingID_ = dt.Rows(0).Item("BookingID") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("ServiceType") Is DBNull.Value Then : .ServiceType_ = dt.Rows(0).Item("ServiceType") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("Shift") Is DBNull.Value Then : .Shift_ = dt.Rows(0).Item("Shift") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblExtraService_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("Service") Is DBNull.Value Then : .Service_ = dt.Rows(0).Item("Service") : End If
                If Not dt.Rows(0).Item("BookingID") Is DBNull.Value Then : .BookingID_ = dt.Rows(0).Item("BookingID") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("ServiceType") Is DBNull.Value Then : .ServiceType_ = dt.Rows(0).Item("ServiceType") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("Shift") Is DBNull.Value Then : .Shift_ = dt.Rows(0).Item("Shift") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.ServiceType
                fn = "ServiceType"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.Shift
                fn = "Shift"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblExtraService] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.ServiceType
                fn = "ServiceType"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.Shift
                fn = "Shift"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblExtraService] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblEscortDriverInfo
    Public Shared tablename As String = "tblEscortDriverInfo"


    Structure Fields


        Dim ID_ As Int32
        Dim BookingID_ As Int32
        Dim Location_ As String
        Dim Others_ As String
        Dim Remarks_ As String

    End Structure


    Enum FieldName


        [ID]
        [BookingID]
        [Location]
        [Others]
        [Remarks]

    End Enum


    Public ReadOnly Property tblEscortDriverInfo_insert
        Get
            Return <tblEscortDriverInfo_insert><![CDATA[
  INSERT INTO [tblEscortDriverInfo]
  (
      [ID],
      [BookingID],
      [Location],
      [Others],
      [Remarks]
  )
  VALUES
  (
      @ID_,
      @BookingID_,
      @Location_,
      @Others_,
      @Remarks_
  )
]]></tblEscortDriverInfo_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblEscortDriverInfo_update
        Get
            Return <tblEscortDriverInfo_update><![CDATA[
UPDATE [tblEscortDriverInfo]
Set 
    [BookingID]=@BookingID_,
    [Location]=@Location_,
    [Others]=@Others_,
    [Remarks]=@Remarks_
 WHERE [ID]=@ID_
]]></tblEscortDriverInfo_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblEscortDriverInfo_select
        Get
            Return <tblEscortDriverInfo_select><![CDATA[
SELECT 
      [ID],
      [BookingID],
      [Location],
      [Others],
      [Remarks]
FROM [tblEscortDriverInfo]
    WHERE 1=1
]]></tblEscortDriverInfo_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblEscortDriverInfo_Delete_By_RowID
        Get
            Return <tblEscortDriverInfo_Delete_By_RowID><![CDATA[
DELETE FROM [tblEscortDriverInfo] WHERE [ID]=@ID_
]]></tblEscortDriverInfo_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblEscortDriverInfo_Delete_By_SELECT
        Get
            Return <tblEscortDriverInfo_Delete_By_SELECT><![CDATA[
DELETE FROM [tblEscortDriverInfo] WHERE 1=1
]]></tblEscortDriverInfo_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblEscortDriverInfo_MAXID
        Get
            Return <tblEscortDriverInfo_MAXID><![CDATA[
SELECT MAX([ID]) FROM [tblEscortDriverInfo] WHERE 1=1
]]></tblEscortDriverInfo_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblEscortDriverInfo_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal BookingID_ As Int32,
    ByVal Location_ As String,
    ByVal Others_ As String,
    ByVal Remarks_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblEscortDriverInfo_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ID_", ID_)
            .AddWithValue("@BookingID_", BookingID_)
            .AddWithValue("@Location_", Location_)
            .AddWithValue("@Others_", Others_)
            .AddWithValue("@Remarks_", Remarks_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ID_
    End Function



    Function Update(
    ByVal BookingID_ As Int32,
    ByVal Location_ As String,
    ByVal Others_ As String,
    ByVal Remarks_ As String,
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblEscortDriverInfo_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@BookingID_", BookingID_)
            .AddWithValue("@Location_", Location_)
            .AddWithValue("@Others_", Others_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@ID_", ID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.Location
                fn = "Location"
            Case FieldName.Others
                fn = "Others"
            Case FieldName.Remarks
                fn = "Remarks"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblEscortDriverInfo] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblEscortDriverInfo_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblEscortDriverInfo_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ID_", ID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ID_
    End Function



    Function Selection_One_Row(
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblEscortDriverInfo_select & "  AND [ID]=@ID_"

        With comSelection.Parameters
            .AddWithValue("@ID_", ID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ID") Is DBNull.Value Then : .ID_ = dt.Rows(0).Item("ID") : End If
                If Not dt.Rows(0).Item("BookingID") Is DBNull.Value Then : .BookingID_ = dt.Rows(0).Item("BookingID") : End If
                If Not dt.Rows(0).Item("Location") Is DBNull.Value Then : .Location_ = dt.Rows(0).Item("Location") : End If
                If Not dt.Rows(0).Item("Others") Is DBNull.Value Then : .Others_ = dt.Rows(0).Item("Others") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblEscortDriverInfo_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ID") Is DBNull.Value Then : .ID_ = dt.Rows(0).Item("ID") : End If
                If Not dt.Rows(0).Item("BookingID") Is DBNull.Value Then : .BookingID_ = dt.Rows(0).Item("BookingID") : End If
                If Not dt.Rows(0).Item("Location") Is DBNull.Value Then : .Location_ = dt.Rows(0).Item("Location") : End If
                If Not dt.Rows(0).Item("Others") Is DBNull.Value Then : .Others_ = dt.Rows(0).Item("Others") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.Location
                fn = "Location"
            Case FieldName.Others
                fn = "Others"
            Case FieldName.Remarks
                fn = "Remarks"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblEscortDriverInfo] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.Location
                fn = "Location"
            Case FieldName.Others
                fn = "Others"
            Case FieldName.Remarks
                fn = "Remarks"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblEscortDriverInfo] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblEmployee
    Public Shared tablename As String = "tblEmployee"


    Structure Fields


        Dim EmpId_ As Int32
        Dim EmpName_ As String
        Dim Address_ As String
        Dim Phone_ As String
        Dim Email_ As String
        Dim Paytype_ As String
        Dim PayRate_ As String
        Dim PayStart_ As DateTime

    End Structure


    Enum FieldName


        [EmpId]
        [EmpName]
        [Address]
        [Phone]
        [Email]
        [Paytype]
        [PayRate]
        [PayStart]

    End Enum


    Public ReadOnly Property tblEmployee_insert
        Get
            Return <tblEmployee_insert><![CDATA[
  INSERT INTO [tblEmployee]
  (
      [EmpId],
      [EmpName],
      [Address],
      [Phone],
      [Email],
      [Paytype],
      [PayRate],
      [PayStart]
  )
  VALUES
  (
      @EmpId_,
      @EmpName_,
      @Address_,
      @Phone_,
      @Email_,
      @Paytype_,
      @PayRate_,
      @PayStart_
  )
]]></tblEmployee_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblEmployee_update
        Get
            Return <tblEmployee_update><![CDATA[
UPDATE [tblEmployee]
Set 
    [EmpName]=@EmpName_,
    [Address]=@Address_,
    [Phone]=@Phone_,
    [Email]=@Email_,
    [Paytype]=@Paytype_,
    [PayRate]=@PayRate_,
    [PayStart]=@PayStart_
 WHERE [EmpId]=@EmpId_
]]></tblEmployee_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblEmployee_select
        Get
            Return <tblEmployee_select><![CDATA[
SELECT 
      [EmpId],
      [EmpName],
      [Address],
      [Phone],
      [Email],
      [Paytype],
      [PayRate],
      [PayStart]
FROM [tblEmployee]
    WHERE 1=1
]]></tblEmployee_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblEmployee_Delete_By_RowID
        Get
            Return <tblEmployee_Delete_By_RowID><![CDATA[
DELETE FROM [tblEmployee] WHERE [EmpId]=@EmpId_
]]></tblEmployee_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblEmployee_Delete_By_SELECT
        Get
            Return <tblEmployee_Delete_By_SELECT><![CDATA[
DELETE FROM [tblEmployee] WHERE 1=1
]]></tblEmployee_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblEmployee_MAXID
        Get
            Return <tblEmployee_MAXID><![CDATA[
SELECT MAX([EmpId]) FROM [tblEmployee] WHERE 1=1
]]></tblEmployee_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblEmployee_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal EmpName_ As String,
    ByVal Address_ As String,
    ByVal Phone_ As String,
    ByVal Email_ As String,
    ByVal Paytype_ As String,
    ByVal PayRate_ As String,
    ByVal PayStart_ As DateTime,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim EmpId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblEmployee_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@EmpId_", EmpId_)
            .AddWithValue("@EmpName_", EmpName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@Paytype_", Paytype_)
            .AddWithValue("@PayRate_", PayRate_)
            .AddWithValue("@PayStart_", PayStart_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return EmpId_
    End Function



    Function Update(
    ByVal EmpName_ As String,
    ByVal Address_ As String,
    ByVal Phone_ As String,
    ByVal Email_ As String,
    ByVal Paytype_ As String,
    ByVal PayRate_ As String,
    ByVal PayStart_ As DateTime,
    ByVal EmpId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblEmployee_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@EmpName_", EmpName_)
            .AddWithValue("@Address_", Address_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Email_", Email_)
            .AddWithValue("@Paytype_", Paytype_)
            .AddWithValue("@PayRate_", PayRate_)
            .AddWithValue("@PayStart_", PayStart_)
            .AddWithValue("@EmpId_", EmpId_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return EmpId_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.EmpId
                fn = "EmpId"
            Case FieldName.EmpName
                fn = "EmpName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.Paytype
                fn = "Paytype"
            Case FieldName.PayRate
                fn = "PayRate"
            Case FieldName.PayStart
                fn = "PayStart"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblEmployee] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblEmployee_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal EmpId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblEmployee_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@EmpId_", EmpId_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return EmpId_
    End Function



    Function Selection_One_Row(
    ByVal EmpId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblEmployee_select & "  AND [EmpId]=@EmpId_"

        With comSelection.Parameters
            .AddWithValue("@EmpId_", EmpId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("EmpId") Is DBNull.Value Then : .EmpId_ = dt.Rows(0).Item("EmpId") : End If
                If Not dt.Rows(0).Item("EmpName") Is DBNull.Value Then : .EmpName_ = dt.Rows(0).Item("EmpName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
                If Not dt.Rows(0).Item("Paytype") Is DBNull.Value Then : .Paytype_ = dt.Rows(0).Item("Paytype") : End If
                If Not dt.Rows(0).Item("PayRate") Is DBNull.Value Then : .PayRate_ = dt.Rows(0).Item("PayRate") : End If
                If Not dt.Rows(0).Item("PayStart") Is DBNull.Value Then : .PayStart_ = dt.Rows(0).Item("PayStart") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblEmployee_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("EmpId") Is DBNull.Value Then : .EmpId_ = dt.Rows(0).Item("EmpId") : End If
                If Not dt.Rows(0).Item("EmpName") Is DBNull.Value Then : .EmpName_ = dt.Rows(0).Item("EmpName") : End If
                If Not dt.Rows(0).Item("Address") Is DBNull.Value Then : .Address_ = dt.Rows(0).Item("Address") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Email") Is DBNull.Value Then : .Email_ = dt.Rows(0).Item("Email") : End If
                If Not dt.Rows(0).Item("Paytype") Is DBNull.Value Then : .Paytype_ = dt.Rows(0).Item("Paytype") : End If
                If Not dt.Rows(0).Item("PayRate") Is DBNull.Value Then : .PayRate_ = dt.Rows(0).Item("PayRate") : End If
                If Not dt.Rows(0).Item("PayStart") Is DBNull.Value Then : .PayStart_ = dt.Rows(0).Item("PayStart") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.EmpId
                fn = "EmpId"
            Case FieldName.EmpName
                fn = "EmpName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.Paytype
                fn = "Paytype"
            Case FieldName.PayRate
                fn = "PayRate"
            Case FieldName.PayStart
                fn = "PayStart"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblEmployee] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.EmpId
                fn = "EmpId"
            Case FieldName.EmpName
                fn = "EmpName"
            Case FieldName.Address
                fn = "Address"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Email
                fn = "Email"
            Case FieldName.Paytype
                fn = "Paytype"
            Case FieldName.PayRate
                fn = "PayRate"
            Case FieldName.PayStart
                fn = "PayStart"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblEmployee] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblEmpCheckIN
    Public Shared tablename As String = "tblEmpCheckIN"


    Structure Fields


        Dim ID_ As Int32
        Dim EmpID_ As Int32
        Dim CheckIn_ As DateTime
        Dim CheckOut_ As DateTime
        Dim Status_ As String

    End Structure


    Enum FieldName


        [ID]
        [EmpID]
        [CheckIn]
        [CheckOut]
        [Status]

    End Enum


    Public ReadOnly Property tblEmpCheckIN_insert
        Get
            Return <tblEmpCheckIN_insert><![CDATA[
  INSERT INTO [tblEmpCheckIN]
  (
      [ID],
      [EmpID],
      [CheckIn],
      [CheckOut],
      [Status]
  )
  VALUES
  (
      @ID_,
      @EmpID_,
      @CheckIn_,
      @CheckOut_,
      @Status_
  )
]]></tblEmpCheckIN_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblEmpCheckIN_update
        Get
            Return <tblEmpCheckIN_update><![CDATA[
UPDATE [tblEmpCheckIN]
Set 
    [EmpID]=@EmpID_,
    [CheckIn]=@CheckIn_,
    [CheckOut]=@CheckOut_,
    [Status]=@Status_
 WHERE [ID]=@ID_
]]></tblEmpCheckIN_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblEmpCheckIN_select
        Get
            Return <tblEmpCheckIN_select><![CDATA[
SELECT 
      [ID],
      [EmpID],
      [CheckIn],
      [CheckOut],
      [Status]
FROM [tblEmpCheckIN]
    WHERE 1=1
]]></tblEmpCheckIN_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblEmpCheckIN_Delete_By_RowID
        Get
            Return <tblEmpCheckIN_Delete_By_RowID><![CDATA[
DELETE FROM [tblEmpCheckIN] WHERE [ID]=@ID_
]]></tblEmpCheckIN_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblEmpCheckIN_Delete_By_SELECT
        Get
            Return <tblEmpCheckIN_Delete_By_SELECT><![CDATA[
DELETE FROM [tblEmpCheckIN] WHERE 1=1
]]></tblEmpCheckIN_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblEmpCheckIN_MAXID
        Get
            Return <tblEmpCheckIN_MAXID><![CDATA[
SELECT MAX([ID]) FROM [tblEmpCheckIN] WHERE 1=1
]]></tblEmpCheckIN_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblEmpCheckIN_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal EmpID_ As Int32,
    ByVal CheckIn_ As DateTime,
    ByVal CheckOut_ As DateTime,
    ByVal Status_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblEmpCheckIN_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ID_", ID_)
            .AddWithValue("@EmpID_", EmpID_)
            .AddWithValue("@CheckIn_", CheckIn_)
            .AddWithValue("@CheckOut_", CheckOut_)
            .AddWithValue("@Status_", Status_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ID_
    End Function



    Function Update(
    ByVal EmpID_ As Int32,
    ByVal CheckIn_ As DateTime,
    ByVal CheckOut_ As DateTime,
    ByVal Status_ As String,
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblEmpCheckIN_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@EmpID_", EmpID_)
            .AddWithValue("@CheckIn_", CheckIn_)
            .AddWithValue("@CheckOut_", CheckOut_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@ID_", ID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.EmpID
                fn = "EmpID"
            Case FieldName.CheckIn
                fn = "CheckIn"
            Case FieldName.CheckOut
                fn = "CheckOut"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblEmpCheckIN] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblEmpCheckIN_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblEmpCheckIN_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ID_", ID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ID_
    End Function



    Function Selection_One_Row(
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblEmpCheckIN_select & "  AND [ID]=@ID_"

        With comSelection.Parameters
            .AddWithValue("@ID_", ID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ID") Is DBNull.Value Then : .ID_ = dt.Rows(0).Item("ID") : End If
                If Not dt.Rows(0).Item("EmpID") Is DBNull.Value Then : .EmpID_ = dt.Rows(0).Item("EmpID") : End If
                If Not dt.Rows(0).Item("CheckIn") Is DBNull.Value Then : .CheckIn_ = dt.Rows(0).Item("CheckIn") : End If
                If Not dt.Rows(0).Item("CheckOut") Is DBNull.Value Then : .CheckOut_ = dt.Rows(0).Item("CheckOut") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblEmpCheckIN_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ID") Is DBNull.Value Then : .ID_ = dt.Rows(0).Item("ID") : End If
                If Not dt.Rows(0).Item("EmpID") Is DBNull.Value Then : .EmpID_ = dt.Rows(0).Item("EmpID") : End If
                If Not dt.Rows(0).Item("CheckIn") Is DBNull.Value Then : .CheckIn_ = dt.Rows(0).Item("CheckIn") : End If
                If Not dt.Rows(0).Item("CheckOut") Is DBNull.Value Then : .CheckOut_ = dt.Rows(0).Item("CheckOut") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.EmpID
                fn = "EmpID"
            Case FieldName.CheckIn
                fn = "CheckIn"
            Case FieldName.CheckOut
                fn = "CheckOut"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblEmpCheckIN] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.EmpID
                fn = "EmpID"
            Case FieldName.CheckIn
                fn = "CheckIn"
            Case FieldName.CheckOut
                fn = "CheckOut"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblEmpCheckIN] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblDocketMemo
    Public Shared tablename As String = "tblDocketMemo"


    Structure Fields


        Dim MemoNo_ As Int32
        Dim MemoType_ As String
        Dim MemoDate_ As DateTime
        Dim Remarks_ As String
        Dim PrintText_ As String

    End Structure


    Enum FieldName


        [MemoNo]
        [MemoType]
        [MemoDate]
        [Remarks]
        [PrintText]

    End Enum


    Public ReadOnly Property tblDocketMemo_insert
        Get
            Return <tblDocketMemo_insert><![CDATA[
  INSERT INTO [tblDocketMemo]
  (
      [MemoNo],
      [MemoType],
      [MemoDate],
      [Remarks],
      [PrintText]
  )
  VALUES
  (
      @MemoNo_,
      @MemoType_,
      @MemoDate_,
      @Remarks_,
      @PrintText_
  )
]]></tblDocketMemo_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblDocketMemo_update
        Get
            Return <tblDocketMemo_update><![CDATA[
UPDATE [tblDocketMemo]
Set 
    [MemoType]=@MemoType_,
    [MemoDate]=@MemoDate_,
    [Remarks]=@Remarks_,
    [PrintText]=@PrintText_
 WHERE [MemoNo]=@MemoNo_
]]></tblDocketMemo_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblDocketMemo_select
        Get
            Return <tblDocketMemo_select><![CDATA[
SELECT 
      [MemoNo],
      [MemoType],
      [MemoDate],
      [Remarks],
      [PrintText]
FROM [tblDocketMemo]
    WHERE 1=1
]]></tblDocketMemo_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblDocketMemo_Delete_By_RowID
        Get
            Return <tblDocketMemo_Delete_By_RowID><![CDATA[
DELETE FROM [tblDocketMemo] WHERE [MemoNo]=@MemoNo_
]]></tblDocketMemo_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblDocketMemo_Delete_By_SELECT
        Get
            Return <tblDocketMemo_Delete_By_SELECT><![CDATA[
DELETE FROM [tblDocketMemo] WHERE 1=1
]]></tblDocketMemo_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblDocketMemo_MAXID
        Get
            Return <tblDocketMemo_MAXID><![CDATA[
SELECT MAX([MemoNo]) FROM [tblDocketMemo] WHERE 1=1
]]></tblDocketMemo_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblDocketMemo_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal MemoType_ As String,
    ByVal MemoDate_ As DateTime,
    ByVal Remarks_ As String,
    ByVal PrintText_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim MemoNo_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblDocketMemo_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@MemoType_", MemoType_)
            .AddWithValue("@MemoDate_", MemoDate_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@PrintText_", PrintText_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return MemoNo_
    End Function



    Function Update(
    ByVal MemoType_ As String,
    ByVal MemoDate_ As DateTime,
    ByVal Remarks_ As String,
    ByVal PrintText_ As String,
    ByVal MemoNo_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblDocketMemo_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@MemoType_", MemoType_)
            .AddWithValue("@MemoDate_", MemoDate_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@PrintText_", PrintText_)
            .AddWithValue("@MemoNo_", MemoNo_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return MemoNo_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.MemoType
                fn = "MemoType"
            Case FieldName.MemoDate
                fn = "MemoDate"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.PrintText
                fn = "PrintText"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblDocketMemo] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblDocketMemo_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal MemoNo_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblDocketMemo_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@MemoNo_", MemoNo_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return MemoNo_
    End Function



    Function Selection_One_Row(
    ByVal MemoNo_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblDocketMemo_select & "  AND [MemoNo]=@MemoNo_"

        With comSelection.Parameters
            .AddWithValue("@MemoNo_", MemoNo_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("MemoType") Is DBNull.Value Then : .MemoType_ = dt.Rows(0).Item("MemoType") : End If
                If Not dt.Rows(0).Item("MemoDate") Is DBNull.Value Then : .MemoDate_ = dt.Rows(0).Item("MemoDate") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("PrintText") Is DBNull.Value Then : .PrintText_ = dt.Rows(0).Item("PrintText") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblDocketMemo_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("MemoType") Is DBNull.Value Then : .MemoType_ = dt.Rows(0).Item("MemoType") : End If
                If Not dt.Rows(0).Item("MemoDate") Is DBNull.Value Then : .MemoDate_ = dt.Rows(0).Item("MemoDate") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
                If Not dt.Rows(0).Item("PrintText") Is DBNull.Value Then : .PrintText_ = dt.Rows(0).Item("PrintText") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.MemoType
                fn = "MemoType"
            Case FieldName.MemoDate
                fn = "MemoDate"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.PrintText
                fn = "PrintText"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblDocketMemo] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.MemoType
                fn = "MemoType"
            Case FieldName.MemoDate
                fn = "MemoDate"
            Case FieldName.Remarks
                fn = "Remarks"
            Case FieldName.PrintText
                fn = "PrintText"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblDocketMemo] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblDBVersion
    Public Shared tablename As String = "tblDBVersion"


    Structure Fields


        Dim ID_ As Int32
        Dim Version_ As String
        Dim UpdatedDate_ As DateTime
        Dim UpdaterInfo_ As String
        Dim Type_ As String

    End Structure


    Enum FieldName


        [ID]
        [Version]
        [UpdatedDate]
        [UpdaterInfo]
        [Type]

    End Enum


    Public ReadOnly Property tblDBVersion_insert
        Get
            Return <tblDBVersion_insert><![CDATA[
  INSERT INTO [tblDBVersion]
  (
      [ID],
      [Version],
      [UpdatedDate],
      [UpdaterInfo],
      [Type]
  )
  VALUES
  (
      @ID_,
      @Version_,
      @UpdatedDate_,
      @UpdaterInfo_,
      @Type_
  )
]]></tblDBVersion_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblDBVersion_update
        Get
            Return <tblDBVersion_update><![CDATA[
UPDATE [tblDBVersion]
Set 
    [Version]=@Version_,
    [UpdatedDate]=@UpdatedDate_,
    [UpdaterInfo]=@UpdaterInfo_,
    [Type]=@Type_
 WHERE [ID]=@ID_
]]></tblDBVersion_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblDBVersion_select
        Get
            Return <tblDBVersion_select><![CDATA[
SELECT 
      [ID],
      [Version],
      [UpdatedDate],
      [UpdaterInfo],
      [Type]
FROM [tblDBVersion]
    WHERE 1=1
]]></tblDBVersion_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblDBVersion_Delete_By_RowID
        Get
            Return <tblDBVersion_Delete_By_RowID><![CDATA[
DELETE FROM [tblDBVersion] WHERE [ID]=@ID_
]]></tblDBVersion_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblDBVersion_Delete_By_SELECT
        Get
            Return <tblDBVersion_Delete_By_SELECT><![CDATA[
DELETE FROM [tblDBVersion] WHERE 1=1
]]></tblDBVersion_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblDBVersion_MAXID
        Get
            Return <tblDBVersion_MAXID><![CDATA[
SELECT MAX([ID]) FROM [tblDBVersion] WHERE 1=1
]]></tblDBVersion_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblDBVersion_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Version_ As String,
    ByVal UpdatedDate_ As DateTime,
    ByVal UpdaterInfo_ As String,
    ByVal Type_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblDBVersion_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ID_", ID_)
            .AddWithValue("@Version_", Version_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdaterInfo_", UpdaterInfo_)
            .AddWithValue("@Type_", Type_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ID_
    End Function



    Function Update(
    ByVal Version_ As String,
    ByVal UpdatedDate_ As DateTime,
    ByVal UpdaterInfo_ As String,
    ByVal Type_ As String,
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblDBVersion_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Version_", Version_)
            .AddWithValue("@UpdatedDate_", UpdatedDate_)
            .AddWithValue("@UpdaterInfo_", UpdaterInfo_)
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@ID_", ID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.Version
                fn = "Version"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdaterInfo
                fn = "UpdaterInfo"
            Case FieldName.Type
                fn = "Type"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblDBVersion] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblDBVersion_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblDBVersion_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ID_", ID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ID_
    End Function



    Function Selection_One_Row(
    ByVal ID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblDBVersion_select & "  AND [ID]=@ID_"

        With comSelection.Parameters
            .AddWithValue("@ID_", ID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ID") Is DBNull.Value Then : .ID_ = dt.Rows(0).Item("ID") : End If
                If Not dt.Rows(0).Item("Version") Is DBNull.Value Then : .Version_ = dt.Rows(0).Item("Version") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdaterInfo") Is DBNull.Value Then : .UpdaterInfo_ = dt.Rows(0).Item("UpdaterInfo") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblDBVersion_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ID") Is DBNull.Value Then : .ID_ = dt.Rows(0).Item("ID") : End If
                If Not dt.Rows(0).Item("Version") Is DBNull.Value Then : .Version_ = dt.Rows(0).Item("Version") : End If
                If Not dt.Rows(0).Item("UpdatedDate") Is DBNull.Value Then : .UpdatedDate_ = dt.Rows(0).Item("UpdatedDate") : End If
                If Not dt.Rows(0).Item("UpdaterInfo") Is DBNull.Value Then : .UpdaterInfo_ = dt.Rows(0).Item("UpdaterInfo") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.Version
                fn = "Version"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdaterInfo
                fn = "UpdaterInfo"
            Case FieldName.Type
                fn = "Type"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblDBVersion] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ID
                fn = "ID"
            Case FieldName.Version
                fn = "Version"
            Case FieldName.UpdatedDate
                fn = "UpdatedDate"
            Case FieldName.UpdaterInfo
                fn = "UpdaterInfo"
            Case FieldName.Type
                fn = "Type"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblDBVersion] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblDailyCounter
    Public Shared tablename As String = "tblDailyCounter"


    Structure Fields


        Dim sl_ As Int32
        Dim Date_ As DateTime
        Dim Value_ As String
        Dim Status_ As String
        Dim Remarks_ As String

    End Structure


    Enum FieldName


        [sl]
        [Date]
        [Value]
        [Status]
        [Remarks]

    End Enum


    Public ReadOnly Property tblDailyCounter_insert
        Get
            Return <tblDailyCounter_insert><![CDATA[
  INSERT INTO [tblDailyCounter]
  (
      [sl],
      [Date],
      [Value],
      [Status],
      [Remarks]
  )
  VALUES
  (
      @sl_,
      @Date_,
      @Value_,
      @Status_,
      @Remarks_
  )
]]></tblDailyCounter_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblDailyCounter_update
        Get
            Return <tblDailyCounter_update><![CDATA[
UPDATE [tblDailyCounter]
Set 
    [Date]=@Date_,
    [Value]=@Value_,
    [Status]=@Status_,
    [Remarks]=@Remarks_
 WHERE [sl]=@sl_
]]></tblDailyCounter_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblDailyCounter_select
        Get
            Return <tblDailyCounter_select><![CDATA[
SELECT 
      [sl],
      [Date],
      [Value],
      [Status],
      [Remarks]
FROM [tblDailyCounter]
    WHERE 1=1
]]></tblDailyCounter_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblDailyCounter_Delete_By_RowID
        Get
            Return <tblDailyCounter_Delete_By_RowID><![CDATA[
DELETE FROM [tblDailyCounter] WHERE [sl]=@sl_
]]></tblDailyCounter_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblDailyCounter_Delete_By_SELECT
        Get
            Return <tblDailyCounter_Delete_By_SELECT><![CDATA[
DELETE FROM [tblDailyCounter] WHERE 1=1
]]></tblDailyCounter_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblDailyCounter_MAXID
        Get
            Return <tblDailyCounter_MAXID><![CDATA[
SELECT MAX([sl]) FROM [tblDailyCounter] WHERE 1=1
]]></tblDailyCounter_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblDailyCounter_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Date_ As DateTime,
    ByVal Value_ As String,
    ByVal Status_ As String,
    ByVal Remarks_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim sl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblDailyCounter_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@sl_", sl_)
            .AddWithValue("@Date_", Date_)
            .AddWithValue("@Value_", Value_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Remarks_", Remarks_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Update(
    ByVal Date_ As DateTime,
    ByVal Value_ As String,
    ByVal Status_ As String,
    ByVal Remarks_ As String,
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblDailyCounter_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Date_", Date_)
            .AddWithValue("@Value_", Value_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Remarks_", Remarks_)
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return sl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.Date
                fn = "Date"
            Case FieldName.Value
                fn = "Value"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Remarks
                fn = "Remarks"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblDailyCounter] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblDailyCounter_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblDailyCounter_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Selection_One_Row(
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblDailyCounter_select & "  AND [sl]=@sl_"

        With comSelection.Parameters
            .AddWithValue("@sl_", sl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("sl") Is DBNull.Value Then : .sl_ = dt.Rows(0).Item("sl") : End If
                If Not dt.Rows(0).Item("Date") Is DBNull.Value Then : .Date_ = dt.Rows(0).Item("Date") : End If
                If Not dt.Rows(0).Item("Value") Is DBNull.Value Then : .Value_ = dt.Rows(0).Item("Value") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblDailyCounter_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("sl") Is DBNull.Value Then : .sl_ = dt.Rows(0).Item("sl") : End If
                If Not dt.Rows(0).Item("Date") Is DBNull.Value Then : .Date_ = dt.Rows(0).Item("Date") : End If
                If Not dt.Rows(0).Item("Value") Is DBNull.Value Then : .Value_ = dt.Rows(0).Item("Value") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Remarks") Is DBNull.Value Then : .Remarks_ = dt.Rows(0).Item("Remarks") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.Date
                fn = "Date"
            Case FieldName.Value
                fn = "Value"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Remarks
                fn = "Remarks"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblDailyCounter] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.Date
                fn = "Date"
            Case FieldName.Value
                fn = "Value"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Remarks
                fn = "Remarks"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblDailyCounter] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblCheckIn
    Public Shared tablename As String = "tblCheckIn"


    Structure Fields


        Dim CheckInId_ As Int32
        Dim WorkerID_ As Int32
        Dim CheckInRoomNo_ As String
        Dim CheckInDate_ As DateTime
        Dim DC_Date_ As DateTime
        Dim DC_File_ As Byte()
        Dim DC_File_Name_ As String
        Dim DC_File_Ext_ As String
        Dim Status_ As String

    End Structure


    Enum FieldName


        [CheckInId]
        [WorkerID]
        [CheckInRoomNo]
        [CheckInDate]
        [DC_Date]
        [DC_File]
        [DC_File_Name]
        [DC_File_Ext]
        [Status]

    End Enum


    Public ReadOnly Property tblCheckIn_insert
        Get
            Return <tblCheckIn_insert><![CDATA[
  INSERT INTO [tblCheckIn]
  (
      [CheckInId],
      [WorkerID],
      [CheckInRoomNo],
      [CheckInDate],
      [DC_Date],
      [DC_File],
      [DC_File_Name],
      [DC_File_Ext],
      [Status]
  )
  VALUES
  (
      @CheckInId_,
      @WorkerID_,
      @CheckInRoomNo_,
      @CheckInDate_,
      @DC_Date_,
      @DC_File_,
      @DC_File_Name_,
      @DC_File_Ext_,
      @Status_
  )
]]></tblCheckIn_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblCheckIn_update
        Get
            Return <tblCheckIn_update><![CDATA[
UPDATE [tblCheckIn]
Set 
    [WorkerID]=@WorkerID_,
    [CheckInRoomNo]=@CheckInRoomNo_,
    [CheckInDate]=@CheckInDate_,
    [DC_Date]=@DC_Date_,
    [DC_File]=@DC_File_,
    [DC_File_Name]=@DC_File_Name_,
    [DC_File_Ext]=@DC_File_Ext_,
    [Status]=@Status_
 WHERE [CheckInId]=@CheckInId_
]]></tblCheckIn_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblCheckIn_select
        Get
            Return <tblCheckIn_select><![CDATA[
SELECT 
      [CheckInId],
      [WorkerID],
      [CheckInRoomNo],
      [CheckInDate],
      [DC_Date],
      [DC_File],
      [DC_File_Name],
      [DC_File_Ext],
      [Status]
FROM [tblCheckIn]
    WHERE 1=1
]]></tblCheckIn_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblCheckIn_Delete_By_RowID
        Get
            Return <tblCheckIn_Delete_By_RowID><![CDATA[
DELETE FROM [tblCheckIn] WHERE [CheckInId]=@CheckInId_
]]></tblCheckIn_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblCheckIn_Delete_By_SELECT
        Get
            Return <tblCheckIn_Delete_By_SELECT><![CDATA[
DELETE FROM [tblCheckIn] WHERE 1=1
]]></tblCheckIn_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblCheckIn_MAXID
        Get
            Return <tblCheckIn_MAXID><![CDATA[
SELECT MAX([CheckInId]) FROM [tblCheckIn] WHERE 1=1
]]></tblCheckIn_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblCheckIn_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal WorkerID_ As Int32,
    ByVal CheckInRoomNo_ As String,
    ByVal CheckInDate_ As DateTime,
    ByVal DC_Date_ As DateTime,
    ByVal DC_File_ As Byte(),
    ByVal DC_File_Name_ As String,
    ByVal DC_File_Ext_ As String,
    ByVal Status_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim CheckInId_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblCheckIn_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@CheckInId_", CheckInId_)
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@CheckInRoomNo_", CheckInRoomNo_)
            .AddWithValue("@CheckInDate_", CheckInDate_)
            .AddWithValue("@DC_Date_", DC_Date_)
            .AddWithValue("@DC_File_", DC_File_)
            .AddWithValue("@DC_File_Name_", DC_File_Name_)
            .AddWithValue("@DC_File_Ext_", DC_File_Ext_)
            .AddWithValue("@Status_", Status_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return CheckInId_
    End Function



    Function Update(
    ByVal WorkerID_ As Int32,
    ByVal CheckInRoomNo_ As String,
    ByVal CheckInDate_ As DateTime,
    ByVal DC_Date_ As DateTime,
    ByVal DC_File_ As Byte(),
    ByVal DC_File_Name_ As String,
    ByVal DC_File_Ext_ As String,
    ByVal Status_ As String,
    ByVal CheckInId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblCheckIn_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@CheckInRoomNo_", CheckInRoomNo_)
            .AddWithValue("@CheckInDate_", CheckInDate_)
            .AddWithValue("@DC_Date_", DC_Date_)
            .AddWithValue("@DC_File_", DC_File_)
            .AddWithValue("@DC_File_Name_", DC_File_Name_)
            .AddWithValue("@DC_File_Ext_", DC_File_Ext_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@CheckInId_", CheckInId_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return CheckInId_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.CheckInId
                fn = "CheckInId"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.CheckInRoomNo
                fn = "CheckInRoomNo"
            Case FieldName.CheckInDate
                fn = "CheckInDate"
            Case FieldName.DC_Date
                fn = "DC_Date"
            Case FieldName.DC_File
                fn = "DC_File"
            Case FieldName.DC_File_Name
                fn = "DC_File_Name"
            Case FieldName.DC_File_Ext
                fn = "DC_File_Ext"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblCheckIn] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblCheckIn_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal CheckInId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblCheckIn_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@CheckInId_", CheckInId_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return CheckInId_
    End Function



    Function Selection_One_Row(
    ByVal CheckInId_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblCheckIn_select & "  AND [CheckInId]=@CheckInId_"

        With comSelection.Parameters
            .AddWithValue("@CheckInId_", CheckInId_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("CheckInId") Is DBNull.Value Then : .CheckInId_ = dt.Rows(0).Item("CheckInId") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("CheckInRoomNo") Is DBNull.Value Then : .CheckInRoomNo_ = dt.Rows(0).Item("CheckInRoomNo") : End If
                If Not dt.Rows(0).Item("CheckInDate") Is DBNull.Value Then : .CheckInDate_ = dt.Rows(0).Item("CheckInDate") : End If
                If Not dt.Rows(0).Item("DC_Date") Is DBNull.Value Then : .DC_Date_ = dt.Rows(0).Item("DC_Date") : End If
                If Not dt.Rows(0).Item("DC_File") Is DBNull.Value Then : .DC_File_ = dt.Rows(0).Item("DC_File") : End If
                If Not dt.Rows(0).Item("DC_File_Name") Is DBNull.Value Then : .DC_File_Name_ = dt.Rows(0).Item("DC_File_Name") : End If
                If Not dt.Rows(0).Item("DC_File_Ext") Is DBNull.Value Then : .DC_File_Ext_ = dt.Rows(0).Item("DC_File_Ext") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblCheckIn_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("CheckInId") Is DBNull.Value Then : .CheckInId_ = dt.Rows(0).Item("CheckInId") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("CheckInRoomNo") Is DBNull.Value Then : .CheckInRoomNo_ = dt.Rows(0).Item("CheckInRoomNo") : End If
                If Not dt.Rows(0).Item("CheckInDate") Is DBNull.Value Then : .CheckInDate_ = dt.Rows(0).Item("CheckInDate") : End If
                If Not dt.Rows(0).Item("DC_Date") Is DBNull.Value Then : .DC_Date_ = dt.Rows(0).Item("DC_Date") : End If
                If Not dt.Rows(0).Item("DC_File") Is DBNull.Value Then : .DC_File_ = dt.Rows(0).Item("DC_File") : End If
                If Not dt.Rows(0).Item("DC_File_Name") Is DBNull.Value Then : .DC_File_Name_ = dt.Rows(0).Item("DC_File_Name") : End If
                If Not dt.Rows(0).Item("DC_File_Ext") Is DBNull.Value Then : .DC_File_Ext_ = dt.Rows(0).Item("DC_File_Ext") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.CheckInId
                fn = "CheckInId"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.CheckInRoomNo
                fn = "CheckInRoomNo"
            Case FieldName.CheckInDate
                fn = "CheckInDate"
            Case FieldName.DC_Date
                fn = "DC_Date"
            Case FieldName.DC_File
                fn = "DC_File"
            Case FieldName.DC_File_Name
                fn = "DC_File_Name"
            Case FieldName.DC_File_Ext
                fn = "DC_File_Ext"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblCheckIn] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.CheckInId
                fn = "CheckInId"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.CheckInRoomNo
                fn = "CheckInRoomNo"
            Case FieldName.CheckInDate
                fn = "CheckInDate"
            Case FieldName.DC_Date
                fn = "DC_Date"
            Case FieldName.DC_File
                fn = "DC_File"
            Case FieldName.DC_File_Name
                fn = "DC_File_Name"
            Case FieldName.DC_File_Ext
                fn = "DC_File_Ext"
            Case FieldName.Status
                fn = "Status"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblCheckIn] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblCalender
    Public Shared tablename As String = "tblCalender"


    Structure Fields


        Dim date_val_ As DateTime

    End Structure


    Enum FieldName


        [date_val]

    End Enum


    Public ReadOnly Property tblCalender_insert
        Get
            Return <tblCalender_insert><![CDATA[
  INSERT INTO [tblCalender]
  (
      [date_val]
  )
  VALUES
  (
      @date_val_
  )
]]></tblCalender_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblCalender_update
        Get
            Return <tblCalender_update><![CDATA[
UPDATE [tblCalender]
Set 

 WHERE [date_val]=@date_val_
]]></tblCalender_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblCalender_select
        Get
            Return <tblCalender_select><![CDATA[
SELECT 
      [date_val]
FROM [tblCalender]
    WHERE 1=1
]]></tblCalender_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblCalender_Delete_By_RowID
        Get
            Return <tblCalender_Delete_By_RowID><![CDATA[
DELETE FROM [tblCalender] WHERE [date_val]=@date_val_
]]></tblCalender_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblCalender_Delete_By_SELECT
        Get
            Return <tblCalender_Delete_By_SELECT><![CDATA[
DELETE FROM [tblCalender] WHERE 1=1
]]></tblCalender_Delete_By_SELECT>.Value
        End Get
    End Property


    Function Insert(
    ByVal date_val_ As DateTime,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing


        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblCalender_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@date_val_", date_val_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return 0
    End Function



    Function Update(
    ByVal date_val_ As DateTime,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblCalender_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@date_val_", date_val_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return 0
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.date_val
                fn = "date_val"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblCalender] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblCalender_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal date_val_ As DateTime,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblCalender_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@date_val_", date_val_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return 0
    End Function



    Function Selection_One_Row(
    ByVal date_val_ As DateTime,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblCalender_select & "  AND [date_val]=@date_val_"

        With comSelection.Parameters
            .AddWithValue("@date_val_", date_val_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("date_val") Is DBNull.Value Then : .date_val_ = dt.Rows(0).Item("date_val") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblCalender_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("date_val") Is DBNull.Value Then : .date_val_ = dt.Rows(0).Item("date_val") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.date_val
                fn = "date_val"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblCalender] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.date_val
                fn = "date_val"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblCalender] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblBookingStatus
    Public Shared tablename As String = "tblBookingStatus"


    Structure Fields


        Dim sl_ As Int32
        Dim BookingID_ As Int32
        Dim Status_ As String
        Dim Date_ As DateTime
        Dim MemoNo_ As Int32
        Dim Reason_ As String
        Dim UserId_ As Int32
        Dim NewId_ As Int32

    End Structure


    Enum FieldName


        [sl]
        [BookingID]
        [Status]
        [Date]
        [MemoNo]
        [Reason]
        [UserId]
        [NewId]

    End Enum


    Public ReadOnly Property tblBookingStatus_insert
        Get
            Return <tblBookingStatus_insert><![CDATA[
  INSERT INTO [tblBookingStatus]
  (
      [sl],
      [BookingID],
      [Status],
      [Date],
      [MemoNo],
      [Reason],
      [UserId],
      [NewId]
  )
  VALUES
  (
      @sl_,
      @BookingID_,
      @Status_,
      @Date_,
      @MemoNo_,
      @Reason_,
      @UserId_,
      @NewId_
  )
]]></tblBookingStatus_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingStatus_update
        Get
            Return <tblBookingStatus_update><![CDATA[
UPDATE [tblBookingStatus]
Set 
    [BookingID]=@BookingID_,
    [Status]=@Status_,
    [Date]=@Date_,
    [MemoNo]=@MemoNo_,
    [Reason]=@Reason_,
    [UserId]=@UserId_,
    [NewId]=@NewId_
 WHERE [sl]=@sl_
]]></tblBookingStatus_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblBookingStatus_select
        Get
            Return <tblBookingStatus_select><![CDATA[
SELECT 
      [sl],
      [BookingID],
      [Status],
      [Date],
      [MemoNo],
      [Reason],
      [UserId],
      [NewId]
FROM [tblBookingStatus]
    WHERE 1=1
]]></tblBookingStatus_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingStatus_Delete_By_RowID
        Get
            Return <tblBookingStatus_Delete_By_RowID><![CDATA[
DELETE FROM [tblBookingStatus] WHERE [sl]=@sl_
]]></tblBookingStatus_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingStatus_Delete_By_SELECT
        Get
            Return <tblBookingStatus_Delete_By_SELECT><![CDATA[
DELETE FROM [tblBookingStatus] WHERE 1=1
]]></tblBookingStatus_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingStatus_MAXID
        Get
            Return <tblBookingStatus_MAXID><![CDATA[
SELECT MAX([sl]) FROM [tblBookingStatus] WHERE 1=1
]]></tblBookingStatus_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblBookingStatus_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal BookingID_ As Int32,
    ByVal Status_ As String,
    ByVal Date_ As DateTime,
    ByVal MemoNo_ As Int32,
    ByVal Reason_ As String,
    ByVal UserId_ As Int32,
    ByVal NewId_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim sl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblBookingStatus_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@sl_", sl_)
            .AddWithValue("@BookingID_", BookingID_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Date_", Date_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@Reason_", Reason_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@NewId_", NewId_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Update(
    ByVal BookingID_ As Int32,
    ByVal Status_ As String,
    ByVal Date_ As DateTime,
    ByVal MemoNo_ As Int32,
    ByVal Reason_ As String,
    ByVal UserId_ As Int32,
    ByVal NewId_ As Int32,
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblBookingStatus_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@BookingID_", BookingID_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Date_", Date_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@Reason_", Reason_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@NewId_", NewId_)
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return sl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Date
                fn = "Date"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.Reason
                fn = "Reason"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.NewId
                fn = "NewId"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblBookingStatus] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBookingStatus_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBookingStatus_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Selection_One_Row(
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBookingStatus_select & "  AND [sl]=@sl_"

        With comSelection.Parameters
            .AddWithValue("@sl_", sl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("sl") Is DBNull.Value Then : .sl_ = dt.Rows(0).Item("sl") : End If
                If Not dt.Rows(0).Item("BookingID") Is DBNull.Value Then : .BookingID_ = dt.Rows(0).Item("BookingID") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Date") Is DBNull.Value Then : .Date_ = dt.Rows(0).Item("Date") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("Reason") Is DBNull.Value Then : .Reason_ = dt.Rows(0).Item("Reason") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("NewId") Is DBNull.Value Then : .NewId_ = dt.Rows(0).Item("NewId") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBookingStatus_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("sl") Is DBNull.Value Then : .sl_ = dt.Rows(0).Item("sl") : End If
                If Not dt.Rows(0).Item("BookingID") Is DBNull.Value Then : .BookingID_ = dt.Rows(0).Item("BookingID") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Date") Is DBNull.Value Then : .Date_ = dt.Rows(0).Item("Date") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("Reason") Is DBNull.Value Then : .Reason_ = dt.Rows(0).Item("Reason") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("NewId") Is DBNull.Value Then : .NewId_ = dt.Rows(0).Item("NewId") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Date
                fn = "Date"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.Reason
                fn = "Reason"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.NewId
                fn = "NewId"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblBookingStatus] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.sl
                fn = "sl"
            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Date
                fn = "Date"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.Reason
                fn = "Reason"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.NewId
                fn = "NewId"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblBookingStatus] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblBookings
    Public Shared tablename As String = "tblBookings"


    Structure Fields


        Dim BookingID_ As Int32
        Dim Room_ As String
        Dim Service_ As Int32
        Dim BookingDate_ As DateTime
        Dim Scheduledate_ As DateTime
        Dim BookingType_ As String
        Dim Status_ As String
        Dim WorkerID_ As Int32
        Dim CustomerName_ As String
        Dim Phone_ As String
        Dim Worker_status_ As String
        Dim Client_status_ As String
        Dim TotalClient_ As Int32
        Dim MemberId_ As String
        Dim MemoNo_ As Int32
        Dim UserId_ As Int32
        Dim ExcludeFromReport_ As Boolean
        Dim DisplayBookingId_ As Int32

    End Structure


    Enum FieldName


        [BookingID]
        [Room]
        [Service]
        [BookingDate]
        [Scheduledate]
        [BookingType]
        [Status]
        [WorkerID]
        [CustomerName]
        [Phone]
        [Worker_status]
        [Client_status]
        [TotalClient]
        [MemberId]
        [MemoNo]
        [UserId]
        [ExcludeFromReport]
        [DisplayBookingId]

    End Enum


    Public ReadOnly Property tblBookings_insert
        Get
            Return <tblBookings_insert><![CDATA[
  INSERT INTO [tblBookings]
  (
      [BookingID],
      [Room],
      [Service],
      [BookingDate],
      [Scheduledate],
      [BookingType],
      [Status],
      [WorkerID],
      [CustomerName],
      [Phone],
      [Worker_status],
      [Client_status],
      [TotalClient],
      [MemberId],
      [MemoNo],
      [UserId],
      [ExcludeFromReport],
      [DisplayBookingId]
  )
  VALUES
  (
      @BookingID_,
      @Room_,
      @Service_,
      @BookingDate_,
      @Scheduledate_,
      @BookingType_,
      @Status_,
      @WorkerID_,
      @CustomerName_,
      @Phone_,
      @Worker_status_,
      @Client_status_,
      @TotalClient_,
      @MemberId_,
      @MemoNo_,
      @UserId_,
      @ExcludeFromReport_,
      @DisplayBookingId_
  )
]]></tblBookings_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookings_update
        Get
            Return <tblBookings_update><![CDATA[
UPDATE [tblBookings]
Set 
    [Room]=@Room_,
    [Service]=@Service_,
    [BookingDate]=@BookingDate_,
    [Scheduledate]=@Scheduledate_,
    [BookingType]=@BookingType_,
    [Status]=@Status_,
    [WorkerID]=@WorkerID_,
    [CustomerName]=@CustomerName_,
    [Phone]=@Phone_,
    [Worker_status]=@Worker_status_,
    [Client_status]=@Client_status_,
    [TotalClient]=@TotalClient_,
    [MemberId]=@MemberId_,
    [MemoNo]=@MemoNo_,
    [UserId]=@UserId_,
    [ExcludeFromReport]=@ExcludeFromReport_,
    [DisplayBookingId]=@DisplayBookingId_
 WHERE [BookingID]=@BookingID_
]]></tblBookings_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblBookings_select
        Get
            Return <tblBookings_select><![CDATA[
SELECT 
      [BookingID],
      [Room],
      [Service],
      [BookingDate],
      [Scheduledate],
      [BookingType],
      [Status],
      [WorkerID],
      [CustomerName],
      [Phone],
      [Worker_status],
      [Client_status],
      [TotalClient],
      [MemberId],
      [MemoNo],
      [UserId],
      [ExcludeFromReport],
      [DisplayBookingId]
FROM [tblBookings]
    WHERE 1=1
]]></tblBookings_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookings_Delete_By_RowID
        Get
            Return <tblBookings_Delete_By_RowID><![CDATA[
DELETE FROM [tblBookings] WHERE [BookingID]=@BookingID_
]]></tblBookings_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookings_Delete_By_SELECT
        Get
            Return <tblBookings_Delete_By_SELECT><![CDATA[
DELETE FROM [tblBookings] WHERE 1=1
]]></tblBookings_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookings_MAXID
        Get
            Return <tblBookings_MAXID><![CDATA[
SELECT MAX([BookingID]) FROM [tblBookings] WHERE 1=1
]]></tblBookings_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblBookings_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Room_ As String,
    ByVal Service_ As Int32,
    ByVal BookingDate_ As DateTime,
    ByVal Scheduledate_ As DateTime,
    ByVal BookingType_ As String,
    ByVal Status_ As String,
    ByVal WorkerID_ As Int32,
    ByVal CustomerName_ As String,
    ByVal Phone_ As String,
    ByVal Worker_status_ As String,
    ByVal Client_status_ As String,
    ByVal TotalClient_ As Int32,
    ByVal MemberId_ As String,
    ByVal MemoNo_ As Int32,
    ByVal UserId_ As Int32,
    ByVal ExcludeFromReport_ As Boolean,
    ByVal DisplayBookingId_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim BookingID_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblBookings_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@BookingID_", BookingID_)
            .AddWithValue("@Room_", Room_)
            .AddWithValue("@Service_", Service_)
            .AddWithValue("@BookingDate_", BookingDate_)
            .AddWithValue("@Scheduledate_", Scheduledate_)
            .AddWithValue("@BookingType_", BookingType_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@CustomerName_", CustomerName_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Worker_status_", Worker_status_)
            .AddWithValue("@Client_status_", Client_status_)
            .AddWithValue("@TotalClient_", TotalClient_)
            .AddWithValue("@MemberId_", MemberId_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@ExcludeFromReport_", ExcludeFromReport_)
            .AddWithValue("@DisplayBookingId_", DisplayBookingId_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return BookingID_
    End Function



    Function Update(
    ByVal Room_ As String,
    ByVal Service_ As Int32,
    ByVal BookingDate_ As DateTime,
    ByVal Scheduledate_ As DateTime,
    ByVal BookingType_ As String,
    ByVal Status_ As String,
    ByVal WorkerID_ As Int32,
    ByVal CustomerName_ As String,
    ByVal Phone_ As String,
    ByVal Worker_status_ As String,
    ByVal Client_status_ As String,
    ByVal TotalClient_ As Int32,
    ByVal MemberId_ As String,
    ByVal MemoNo_ As Int32,
    ByVal UserId_ As Int32,
    ByVal ExcludeFromReport_ As Boolean,
    ByVal DisplayBookingId_ As Int32,
    ByVal BookingID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblBookings_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Room_", Room_)
            .AddWithValue("@Service_", Service_)
            .AddWithValue("@BookingDate_", BookingDate_)
            .AddWithValue("@Scheduledate_", Scheduledate_)
            .AddWithValue("@BookingType_", BookingType_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@CustomerName_", CustomerName_)
            .AddWithValue("@Phone_", Phone_)
            .AddWithValue("@Worker_status_", Worker_status_)
            .AddWithValue("@Client_status_", Client_status_)
            .AddWithValue("@TotalClient_", TotalClient_)
            .AddWithValue("@MemberId_", MemberId_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@ExcludeFromReport_", ExcludeFromReport_)
            .AddWithValue("@DisplayBookingId_", DisplayBookingId_)
            .AddWithValue("@BookingID_", BookingID_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return BookingID_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.BookingDate
                fn = "BookingDate"
            Case FieldName.Scheduledate
                fn = "Scheduledate"
            Case FieldName.BookingType
                fn = "BookingType"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.CustomerName
                fn = "CustomerName"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Worker_status
                fn = "Worker_status"
            Case FieldName.Client_status
                fn = "Client_status"
            Case FieldName.TotalClient
                fn = "TotalClient"
            Case FieldName.MemberId
                fn = "MemberId"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.ExcludeFromReport
                fn = "ExcludeFromReport"
            Case FieldName.DisplayBookingId
                fn = "DisplayBookingId"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblBookings] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBookings_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal BookingID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBookings_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@BookingID_", BookingID_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return BookingID_
    End Function



    Function Selection_One_Row(
    ByVal BookingID_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBookings_select & "  AND [BookingID]=@BookingID_"

        With comSelection.Parameters
            .AddWithValue("@BookingID_", BookingID_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("BookingID") Is DBNull.Value Then : .BookingID_ = dt.Rows(0).Item("BookingID") : End If
                If Not dt.Rows(0).Item("Room") Is DBNull.Value Then : .Room_ = dt.Rows(0).Item("Room") : End If
                If Not dt.Rows(0).Item("Service") Is DBNull.Value Then : .Service_ = dt.Rows(0).Item("Service") : End If
                If Not dt.Rows(0).Item("BookingDate") Is DBNull.Value Then : .BookingDate_ = dt.Rows(0).Item("BookingDate") : End If
                If Not dt.Rows(0).Item("Scheduledate") Is DBNull.Value Then : .Scheduledate_ = dt.Rows(0).Item("Scheduledate") : End If
                If Not dt.Rows(0).Item("BookingType") Is DBNull.Value Then : .BookingType_ = dt.Rows(0).Item("BookingType") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("CustomerName") Is DBNull.Value Then : .CustomerName_ = dt.Rows(0).Item("CustomerName") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Worker_status") Is DBNull.Value Then : .Worker_status_ = dt.Rows(0).Item("Worker_status") : End If
                If Not dt.Rows(0).Item("Client_status") Is DBNull.Value Then : .Client_status_ = dt.Rows(0).Item("Client_status") : End If
                If Not dt.Rows(0).Item("TotalClient") Is DBNull.Value Then : .TotalClient_ = dt.Rows(0).Item("TotalClient") : End If
                If Not dt.Rows(0).Item("MemberId") Is DBNull.Value Then : .MemberId_ = dt.Rows(0).Item("MemberId") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("ExcludeFromReport") Is DBNull.Value Then : .ExcludeFromReport_ = dt.Rows(0).Item("ExcludeFromReport") : End If
                If Not dt.Rows(0).Item("DisplayBookingId") Is DBNull.Value Then : .DisplayBookingId_ = dt.Rows(0).Item("DisplayBookingId") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBookings_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("BookingID") Is DBNull.Value Then : .BookingID_ = dt.Rows(0).Item("BookingID") : End If
                If Not dt.Rows(0).Item("Room") Is DBNull.Value Then : .Room_ = dt.Rows(0).Item("Room") : End If
                If Not dt.Rows(0).Item("Service") Is DBNull.Value Then : .Service_ = dt.Rows(0).Item("Service") : End If
                If Not dt.Rows(0).Item("BookingDate") Is DBNull.Value Then : .BookingDate_ = dt.Rows(0).Item("BookingDate") : End If
                If Not dt.Rows(0).Item("Scheduledate") Is DBNull.Value Then : .Scheduledate_ = dt.Rows(0).Item("Scheduledate") : End If
                If Not dt.Rows(0).Item("BookingType") Is DBNull.Value Then : .BookingType_ = dt.Rows(0).Item("BookingType") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("CustomerName") Is DBNull.Value Then : .CustomerName_ = dt.Rows(0).Item("CustomerName") : End If
                If Not dt.Rows(0).Item("Phone") Is DBNull.Value Then : .Phone_ = dt.Rows(0).Item("Phone") : End If
                If Not dt.Rows(0).Item("Worker_status") Is DBNull.Value Then : .Worker_status_ = dt.Rows(0).Item("Worker_status") : End If
                If Not dt.Rows(0).Item("Client_status") Is DBNull.Value Then : .Client_status_ = dt.Rows(0).Item("Client_status") : End If
                If Not dt.Rows(0).Item("TotalClient") Is DBNull.Value Then : .TotalClient_ = dt.Rows(0).Item("TotalClient") : End If
                If Not dt.Rows(0).Item("MemberId") Is DBNull.Value Then : .MemberId_ = dt.Rows(0).Item("MemberId") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("ExcludeFromReport") Is DBNull.Value Then : .ExcludeFromReport_ = dt.Rows(0).Item("ExcludeFromReport") : End If
                If Not dt.Rows(0).Item("DisplayBookingId") Is DBNull.Value Then : .DisplayBookingId_ = dt.Rows(0).Item("DisplayBookingId") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.BookingDate
                fn = "BookingDate"
            Case FieldName.Scheduledate
                fn = "Scheduledate"
            Case FieldName.BookingType
                fn = "BookingType"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.CustomerName
                fn = "CustomerName"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Worker_status
                fn = "Worker_status"
            Case FieldName.Client_status
                fn = "Client_status"
            Case FieldName.TotalClient
                fn = "TotalClient"
            Case FieldName.MemberId
                fn = "MemberId"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.ExcludeFromReport
                fn = "ExcludeFromReport"
            Case FieldName.DisplayBookingId
                fn = "DisplayBookingId"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblBookings] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.BookingID
                fn = "BookingID"
            Case FieldName.Room
                fn = "Room"
            Case FieldName.Service
                fn = "Service"
            Case FieldName.BookingDate
                fn = "BookingDate"
            Case FieldName.Scheduledate
                fn = "Scheduledate"
            Case FieldName.BookingType
                fn = "BookingType"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.CustomerName
                fn = "CustomerName"
            Case FieldName.Phone
                fn = "Phone"
            Case FieldName.Worker_status
                fn = "Worker_status"
            Case FieldName.Client_status
                fn = "Client_status"
            Case FieldName.TotalClient
                fn = "TotalClient"
            Case FieldName.MemberId
                fn = "MemberId"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.ExcludeFromReport
                fn = "ExcludeFromReport"
            Case FieldName.DisplayBookingId
                fn = "DisplayBookingId"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblBookings] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblBookingPayments
    Public Shared tablename As String = "tblBookingPayments"


    Structure Fields


        Dim Sl_ As Int32
        Dim Type_ As String
        Dim Total_ As Decimal
        Dim BookingId_ As Int32
        Dim CreatedDate_ As DateTime
        Dim Cash_ As Decimal
        Dim CARD_ As Decimal
        Dim Surcharge_ As Decimal
        Dim Surcharge_Amt_ As Decimal
        Dim Tip_ As Decimal
        Dim Status_ As String
        Dim PaymentMode_ As String
        Dim Sp_Amount_ As Decimal
        Dim House_amount_ As Decimal
        Dim CashOut_ As Decimal
        Dim WorkerID_ As Int32
        Dim VoucherAmount_ As Decimal
        Dim VoucherID_ As Int32
        Dim ShiftFee_ As Decimal
        Dim MemoNo_ As Int32
        Dim Upgrade_ As Decimal
        Dim EncrytedInfo_ As String
        Dim GST_ As Decimal
        Dim UserId_ As Int32
        Dim CarFare_ As Decimal
        Dim EscortExtensionFees_ As Decimal
        Dim CardName_ As String
        Dim Cancel_fees_ As Decimal
        Dim Bond_amount_ As Decimal
        Dim DisplayBookingID_ As Int32
        Dim UtilizedVoucherAmount_ As Decimal
        Dim OriginalShift_ As String
        Dim PaidShift_ As String
        Dim Gift_ As Decimal
        Dim TOTAIL_PAID_ As Decimal

    End Structure


    Enum FieldName


        [Sl]
        [Type]
        [Total]
        [BookingId]
        [CreatedDate]
        [Cash]
        [CARD]
        [Surcharge]
        [Surcharge_Amt]
        [Tip]
        [Status]
        [PaymentMode]
        [Sp_Amount]
        [House_amount]
        [CashOut]
        [WorkerID]
        [VoucherAmount]
        [VoucherID]
        [ShiftFee]
        [MemoNo]
        [Upgrade]
        [EncrytedInfo]
        [GST]
        [UserId]
        [CarFare]
        [EscortExtensionFees]
        [CardName]
        [Cancel_fees]
        [Bond_amount]
        [DisplayBookingID]
        [UtilizedVoucherAmount]
        [OriginalShift]
        [PaidShift]
        [Gift]
        [TOTAIL_PAID]

    End Enum


    Public ReadOnly Property tblBookingPayments_insert
        Get
            Return <tblBookingPayments_insert><![CDATA[
  INSERT INTO [tblBookingPayments]
  (
      [Sl],
      [Type],
      [Total],
      [BookingId],
      [CreatedDate],
      [Cash],
      [CARD],
      [Surcharge],
      [Surcharge_Amt],
      [Tip],
      [Status],
      [PaymentMode],
      [Sp_Amount],
      [House_amount],
      [CashOut],
      [WorkerID],
      [VoucherAmount],
      [VoucherID],
      [ShiftFee],
      [MemoNo],
      [Upgrade],
      [EncrytedInfo],
      [GST],
      [UserId],
      [CarFare],
      [EscortExtensionFees],
      [CardName],
      [Cancel_fees],
      [Bond_amount],
      [DisplayBookingID],
      [UtilizedVoucherAmount],
      [OriginalShift],
      [PaidShift],
      [Gift],
      [TOTAIL_PAID]
  )
  VALUES
  (
      @Sl_,
      @Type_,
      @Total_,
      @BookingId_,
      @CreatedDate_,
      @Cash_,
      @CARD_,
      @Surcharge_,
      @Surcharge_Amt_,
      @Tip_,
      @Status_,
      @PaymentMode_,
      @Sp_Amount_,
      @House_amount_,
      @CashOut_,
      @WorkerID_,
      @VoucherAmount_,
      @VoucherID_,
      @ShiftFee_,
      @MemoNo_,
      @Upgrade_,
      @EncrytedInfo_,
      @GST_,
      @UserId_,
      @CarFare_,
      @EscortExtensionFees_,
      @CardName_,
      @Cancel_fees_,
      @Bond_amount_,
      @DisplayBookingID_,
      @UtilizedVoucherAmount_,
      @OriginalShift_,
      @PaidShift_,
      @Gift_,
      @TOTAIL_PAID_
  )
]]></tblBookingPayments_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingPayments_update
        Get
            Return <tblBookingPayments_update><![CDATA[
UPDATE [tblBookingPayments]
Set 
    [Type]=@Type_,
    [Total]=@Total_,
    [BookingId]=@BookingId_,
    [CreatedDate]=@CreatedDate_,
    [Cash]=@Cash_,
    [CARD]=@CARD_,
    [Surcharge]=@Surcharge_,
    [Surcharge_Amt]=@Surcharge_Amt_,
    [Tip]=@Tip_,
    [Status]=@Status_,
    [PaymentMode]=@PaymentMode_,
    [Sp_Amount]=@Sp_Amount_,
    [House_amount]=@House_amount_,
    [CashOut]=@CashOut_,
    [WorkerID]=@WorkerID_,
    [VoucherAmount]=@VoucherAmount_,
    [VoucherID]=@VoucherID_,
    [ShiftFee]=@ShiftFee_,
    [MemoNo]=@MemoNo_,
    [Upgrade]=@Upgrade_,
    [EncrytedInfo]=@EncrytedInfo_,
    [GST]=@GST_,
    [UserId]=@UserId_,
    [CarFare]=@CarFare_,
    [EscortExtensionFees]=@EscortExtensionFees_,
    [CardName]=@CardName_,
    [Cancel_fees]=@Cancel_fees_,
    [Bond_amount]=@Bond_amount_,
    [DisplayBookingID]=@DisplayBookingID_,
    [UtilizedVoucherAmount]=@UtilizedVoucherAmount_,
    [OriginalShift]=@OriginalShift_,
    [PaidShift]=@PaidShift_,
    [Gift]=@Gift_,
    [TOTAIL_PAID]=@TOTAIL_PAID_
 WHERE [Sl]=@Sl_
]]></tblBookingPayments_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblBookingPayments_select
        Get
            Return <tblBookingPayments_select><![CDATA[
SELECT 
      [Sl],
      [Type],
      [Total],
      [BookingId],
      [CreatedDate],
      [Cash],
      [CARD],
      [Surcharge],
      [Surcharge_Amt],
      [Tip],
      [Status],
      [PaymentMode],
      [Sp_Amount],
      [House_amount],
      [CashOut],
      [WorkerID],
      [VoucherAmount],
      [VoucherID],
      [ShiftFee],
      [MemoNo],
      [Upgrade],
      [EncrytedInfo],
      [GST],
      [UserId],
      [CarFare],
      [EscortExtensionFees],
      [CardName],
      [Cancel_fees],
      [Bond_amount],
      [DisplayBookingID],
      [UtilizedVoucherAmount],
      [OriginalShift],
      [PaidShift],
      [Gift],
      [TOTAIL_PAID]
FROM [tblBookingPayments]
    WHERE 1=1
]]></tblBookingPayments_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingPayments_Delete_By_RowID
        Get
            Return <tblBookingPayments_Delete_By_RowID><![CDATA[
DELETE FROM [tblBookingPayments] WHERE [Sl]=@Sl_
]]></tblBookingPayments_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingPayments_Delete_By_SELECT
        Get
            Return <tblBookingPayments_Delete_By_SELECT><![CDATA[
DELETE FROM [tblBookingPayments] WHERE 1=1
]]></tblBookingPayments_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingPayments_MAXID
        Get
            Return <tblBookingPayments_MAXID><![CDATA[
SELECT MAX([Sl]) FROM [tblBookingPayments] WHERE 1=1
]]></tblBookingPayments_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblBookingPayments_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal Type_ As String,
    ByVal Total_ As Decimal,
    ByVal BookingId_ As Int32,
    ByVal CreatedDate_ As DateTime,
    ByVal Cash_ As Decimal,
    ByVal CARD_ As Decimal,
    ByVal Surcharge_ As Decimal,
    ByVal Surcharge_Amt_ As Decimal,
    ByVal Tip_ As Decimal,
    ByVal Status_ As String,
    ByVal PaymentMode_ As String,
    ByVal Sp_Amount_ As Decimal,
    ByVal House_amount_ As Decimal,
    ByVal CashOut_ As Decimal,
    ByVal WorkerID_ As Int32,
    ByVal VoucherAmount_ As Decimal,
    ByVal VoucherID_ As Int32,
    ByVal ShiftFee_ As Decimal,
    ByVal MemoNo_ As Int32,
    ByVal Upgrade_ As Decimal,
    ByVal EncrytedInfo_ As String,
    ByVal GST_ As Decimal,
    ByVal UserId_ As Int32,
    ByVal CarFare_ As Decimal,
    ByVal EscortExtensionFees_ As Decimal,
    ByVal CardName_ As String,
    ByVal Cancel_fees_ As Decimal,
    ByVal Bond_amount_ As Decimal,
    ByVal DisplayBookingID_ As Int32,
    ByVal UtilizedVoucherAmount_ As Decimal,
    ByVal OriginalShift_ As String,
    ByVal PaidShift_ As String,
    ByVal Gift_ As Decimal,
    ByVal TOTAIL_PAID_ As Decimal,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim Sl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblBookingPayments_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@Sl_", Sl_)
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@Total_", Total_)
            .AddWithValue("@BookingId_", BookingId_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@Cash_", Cash_)
            .AddWithValue("@CARD_", CARD_)
            .AddWithValue("@Surcharge_", Surcharge_)
            .AddWithValue("@Surcharge_Amt_", Surcharge_Amt_)
            .AddWithValue("@Tip_", Tip_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@PaymentMode_", PaymentMode_)
            .AddWithValue("@Sp_Amount_", Sp_Amount_)
            .AddWithValue("@House_amount_", House_amount_)
            .AddWithValue("@CashOut_", CashOut_)
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@VoucherAmount_", VoucherAmount_)
            .AddWithValue("@VoucherID_", VoucherID_)
            .AddWithValue("@ShiftFee_", ShiftFee_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@Upgrade_", Upgrade_)
            .AddWithValue("@EncrytedInfo_", EncrytedInfo_)
            .AddWithValue("@GST_", GST_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@CarFare_", CarFare_)
            .AddWithValue("@EscortExtensionFees_", EscortExtensionFees_)
            .AddWithValue("@CardName_", CardName_)
            .AddWithValue("@Cancel_fees_", Cancel_fees_)
            .AddWithValue("@Bond_amount_", Bond_amount_)
            .AddWithValue("@DisplayBookingID_", DisplayBookingID_)
            .AddWithValue("@UtilizedVoucherAmount_", UtilizedVoucherAmount_)
            .AddWithValue("@OriginalShift_", OriginalShift_)
            .AddWithValue("@PaidShift_", PaidShift_)
            .AddWithValue("@Gift_", Gift_)
            .AddWithValue("@TOTAIL_PAID_", TOTAIL_PAID_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Sl_
    End Function



    Function Update(
    ByVal Type_ As String,
    ByVal Total_ As Decimal,
    ByVal BookingId_ As Int32,
    ByVal CreatedDate_ As DateTime,
    ByVal Cash_ As Decimal,
    ByVal CARD_ As Decimal,
    ByVal Surcharge_ As Decimal,
    ByVal Surcharge_Amt_ As Decimal,
    ByVal Tip_ As Decimal,
    ByVal Status_ As String,
    ByVal PaymentMode_ As String,
    ByVal Sp_Amount_ As Decimal,
    ByVal House_amount_ As Decimal,
    ByVal CashOut_ As Decimal,
    ByVal WorkerID_ As Int32,
    ByVal VoucherAmount_ As Decimal,
    ByVal VoucherID_ As Int32,
    ByVal ShiftFee_ As Decimal,
    ByVal MemoNo_ As Int32,
    ByVal Upgrade_ As Decimal,
    ByVal EncrytedInfo_ As String,
    ByVal GST_ As Decimal,
    ByVal UserId_ As Int32,
    ByVal CarFare_ As Decimal,
    ByVal EscortExtensionFees_ As Decimal,
    ByVal CardName_ As String,
    ByVal Cancel_fees_ As Decimal,
    ByVal Bond_amount_ As Decimal,
    ByVal DisplayBookingID_ As Int32,
    ByVal UtilizedVoucherAmount_ As Decimal,
    ByVal OriginalShift_ As String,
    ByVal PaidShift_ As String,
    ByVal Gift_ As Decimal,
    ByVal TOTAIL_PAID_ As Decimal,
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblBookingPayments_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@Type_", Type_)
            .AddWithValue("@Total_", Total_)
            .AddWithValue("@BookingId_", BookingId_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@Cash_", Cash_)
            .AddWithValue("@CARD_", CARD_)
            .AddWithValue("@Surcharge_", Surcharge_)
            .AddWithValue("@Surcharge_Amt_", Surcharge_Amt_)
            .AddWithValue("@Tip_", Tip_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@PaymentMode_", PaymentMode_)
            .AddWithValue("@Sp_Amount_", Sp_Amount_)
            .AddWithValue("@House_amount_", House_amount_)
            .AddWithValue("@CashOut_", CashOut_)
            .AddWithValue("@WorkerID_", WorkerID_)
            .AddWithValue("@VoucherAmount_", VoucherAmount_)
            .AddWithValue("@VoucherID_", VoucherID_)
            .AddWithValue("@ShiftFee_", ShiftFee_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@Upgrade_", Upgrade_)
            .AddWithValue("@EncrytedInfo_", EncrytedInfo_)
            .AddWithValue("@GST_", GST_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@CarFare_", CarFare_)
            .AddWithValue("@EscortExtensionFees_", EscortExtensionFees_)
            .AddWithValue("@CardName_", CardName_)
            .AddWithValue("@Cancel_fees_", Cancel_fees_)
            .AddWithValue("@Bond_amount_", Bond_amount_)
            .AddWithValue("@DisplayBookingID_", DisplayBookingID_)
            .AddWithValue("@UtilizedVoucherAmount_", UtilizedVoucherAmount_)
            .AddWithValue("@OriginalShift_", OriginalShift_)
            .AddWithValue("@PaidShift_", PaidShift_)
            .AddWithValue("@Gift_", Gift_)
            .AddWithValue("@TOTAIL_PAID_", TOTAIL_PAID_)
            .AddWithValue("@Sl_", Sl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return Sl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.Total
                fn = "Total"
            Case FieldName.BookingId
                fn = "BookingId"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.Cash
                fn = "Cash"
            Case FieldName.CARD
                fn = "CARD"
            Case FieldName.Surcharge
                fn = "Surcharge"
            Case FieldName.Surcharge_Amt
                fn = "Surcharge_Amt"
            Case FieldName.Tip
                fn = "Tip"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.PaymentMode
                fn = "PaymentMode"
            Case FieldName.Sp_Amount
                fn = "Sp_Amount"
            Case FieldName.House_amount
                fn = "House_amount"
            Case FieldName.CashOut
                fn = "CashOut"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.VoucherAmount
                fn = "VoucherAmount"
            Case FieldName.VoucherID
                fn = "VoucherID"
            Case FieldName.ShiftFee
                fn = "ShiftFee"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.Upgrade
                fn = "Upgrade"
            Case FieldName.EncrytedInfo
                fn = "EncrytedInfo"
            Case FieldName.GST
                fn = "GST"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.CarFare
                fn = "CarFare"
            Case FieldName.EscortExtensionFees
                fn = "EscortExtensionFees"
            Case FieldName.CardName
                fn = "CardName"
            Case FieldName.Cancel_fees
                fn = "Cancel_fees"
            Case FieldName.Bond_amount
                fn = "Bond_amount"
            Case FieldName.DisplayBookingID
                fn = "DisplayBookingID"
            Case FieldName.UtilizedVoucherAmount
                fn = "UtilizedVoucherAmount"
            Case FieldName.OriginalShift
                fn = "OriginalShift"
            Case FieldName.PaidShift
                fn = "PaidShift"
            Case FieldName.Gift
                fn = "Gift"
            Case FieldName.TOTAIL_PAID
                fn = "TOTAIL_PAID"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblBookingPayments] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBookingPayments_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBookingPayments_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@Sl_", Sl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return Sl_
    End Function



    Function Selection_One_Row(
    ByVal Sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBookingPayments_select & "  AND [Sl]=@Sl_"

        With comSelection.Parameters
            .AddWithValue("@Sl_", Sl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
                If Not dt.Rows(0).Item("Total") Is DBNull.Value Then : .Total_ = dt.Rows(0).Item("Total") : End If
                If Not dt.Rows(0).Item("BookingId") Is DBNull.Value Then : .BookingId_ = dt.Rows(0).Item("BookingId") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("Cash") Is DBNull.Value Then : .Cash_ = dt.Rows(0).Item("Cash") : End If
                If Not dt.Rows(0).Item("CARD") Is DBNull.Value Then : .CARD_ = dt.Rows(0).Item("CARD") : End If
                If Not dt.Rows(0).Item("Surcharge") Is DBNull.Value Then : .Surcharge_ = dt.Rows(0).Item("Surcharge") : End If
                If Not dt.Rows(0).Item("Surcharge_Amt") Is DBNull.Value Then : .Surcharge_Amt_ = dt.Rows(0).Item("Surcharge_Amt") : End If
                If Not dt.Rows(0).Item("Tip") Is DBNull.Value Then : .Tip_ = dt.Rows(0).Item("Tip") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("PaymentMode") Is DBNull.Value Then : .PaymentMode_ = dt.Rows(0).Item("PaymentMode") : End If
                If Not dt.Rows(0).Item("Sp_Amount") Is DBNull.Value Then : .Sp_Amount_ = dt.Rows(0).Item("Sp_Amount") : End If
                If Not dt.Rows(0).Item("House_amount") Is DBNull.Value Then : .House_amount_ = dt.Rows(0).Item("House_amount") : End If
                If Not dt.Rows(0).Item("CashOut") Is DBNull.Value Then : .CashOut_ = dt.Rows(0).Item("CashOut") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("VoucherAmount") Is DBNull.Value Then : .VoucherAmount_ = dt.Rows(0).Item("VoucherAmount") : End If
                If Not dt.Rows(0).Item("VoucherID") Is DBNull.Value Then : .VoucherID_ = dt.Rows(0).Item("VoucherID") : End If
                If Not dt.Rows(0).Item("ShiftFee") Is DBNull.Value Then : .ShiftFee_ = dt.Rows(0).Item("ShiftFee") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("Upgrade") Is DBNull.Value Then : .Upgrade_ = dt.Rows(0).Item("Upgrade") : End If
                If Not dt.Rows(0).Item("EncrytedInfo") Is DBNull.Value Then : .EncrytedInfo_ = dt.Rows(0).Item("EncrytedInfo") : End If
                If Not dt.Rows(0).Item("GST") Is DBNull.Value Then : .GST_ = dt.Rows(0).Item("GST") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("CarFare") Is DBNull.Value Then : .CarFare_ = dt.Rows(0).Item("CarFare") : End If
                If Not dt.Rows(0).Item("EscortExtensionFees") Is DBNull.Value Then : .EscortExtensionFees_ = dt.Rows(0).Item("EscortExtensionFees") : End If
                If Not dt.Rows(0).Item("CardName") Is DBNull.Value Then : .CardName_ = dt.Rows(0).Item("CardName") : End If
                If Not dt.Rows(0).Item("Cancel_fees") Is DBNull.Value Then : .Cancel_fees_ = dt.Rows(0).Item("Cancel_fees") : End If
                If Not dt.Rows(0).Item("Bond_amount") Is DBNull.Value Then : .Bond_amount_ = dt.Rows(0).Item("Bond_amount") : End If
                If Not dt.Rows(0).Item("DisplayBookingID") Is DBNull.Value Then : .DisplayBookingID_ = dt.Rows(0).Item("DisplayBookingID") : End If
                If Not dt.Rows(0).Item("UtilizedVoucherAmount") Is DBNull.Value Then : .UtilizedVoucherAmount_ = dt.Rows(0).Item("UtilizedVoucherAmount") : End If
                If Not dt.Rows(0).Item("OriginalShift") Is DBNull.Value Then : .OriginalShift_ = dt.Rows(0).Item("OriginalShift") : End If
                If Not dt.Rows(0).Item("PaidShift") Is DBNull.Value Then : .PaidShift_ = dt.Rows(0).Item("PaidShift") : End If
                If Not dt.Rows(0).Item("Gift") Is DBNull.Value Then : .Gift_ = dt.Rows(0).Item("Gift") : End If
                If Not dt.Rows(0).Item("TOTAIL_PAID") Is DBNull.Value Then : .TOTAIL_PAID_ = dt.Rows(0).Item("TOTAIL_PAID") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBookingPayments_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("Sl") Is DBNull.Value Then : .Sl_ = dt.Rows(0).Item("Sl") : End If
                If Not dt.Rows(0).Item("Type") Is DBNull.Value Then : .Type_ = dt.Rows(0).Item("Type") : End If
                If Not dt.Rows(0).Item("Total") Is DBNull.Value Then : .Total_ = dt.Rows(0).Item("Total") : End If
                If Not dt.Rows(0).Item("BookingId") Is DBNull.Value Then : .BookingId_ = dt.Rows(0).Item("BookingId") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("Cash") Is DBNull.Value Then : .Cash_ = dt.Rows(0).Item("Cash") : End If
                If Not dt.Rows(0).Item("CARD") Is DBNull.Value Then : .CARD_ = dt.Rows(0).Item("CARD") : End If
                If Not dt.Rows(0).Item("Surcharge") Is DBNull.Value Then : .Surcharge_ = dt.Rows(0).Item("Surcharge") : End If
                If Not dt.Rows(0).Item("Surcharge_Amt") Is DBNull.Value Then : .Surcharge_Amt_ = dt.Rows(0).Item("Surcharge_Amt") : End If
                If Not dt.Rows(0).Item("Tip") Is DBNull.Value Then : .Tip_ = dt.Rows(0).Item("Tip") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("PaymentMode") Is DBNull.Value Then : .PaymentMode_ = dt.Rows(0).Item("PaymentMode") : End If
                If Not dt.Rows(0).Item("Sp_Amount") Is DBNull.Value Then : .Sp_Amount_ = dt.Rows(0).Item("Sp_Amount") : End If
                If Not dt.Rows(0).Item("House_amount") Is DBNull.Value Then : .House_amount_ = dt.Rows(0).Item("House_amount") : End If
                If Not dt.Rows(0).Item("CashOut") Is DBNull.Value Then : .CashOut_ = dt.Rows(0).Item("CashOut") : End If
                If Not dt.Rows(0).Item("WorkerID") Is DBNull.Value Then : .WorkerID_ = dt.Rows(0).Item("WorkerID") : End If
                If Not dt.Rows(0).Item("VoucherAmount") Is DBNull.Value Then : .VoucherAmount_ = dt.Rows(0).Item("VoucherAmount") : End If
                If Not dt.Rows(0).Item("VoucherID") Is DBNull.Value Then : .VoucherID_ = dt.Rows(0).Item("VoucherID") : End If
                If Not dt.Rows(0).Item("ShiftFee") Is DBNull.Value Then : .ShiftFee_ = dt.Rows(0).Item("ShiftFee") : End If
                If Not dt.Rows(0).Item("MemoNo") Is DBNull.Value Then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : End If
                If Not dt.Rows(0).Item("Upgrade") Is DBNull.Value Then : .Upgrade_ = dt.Rows(0).Item("Upgrade") : End If
                If Not dt.Rows(0).Item("EncrytedInfo") Is DBNull.Value Then : .EncrytedInfo_ = dt.Rows(0).Item("EncrytedInfo") : End If
                If Not dt.Rows(0).Item("GST") Is DBNull.Value Then : .GST_ = dt.Rows(0).Item("GST") : End If
                If Not dt.Rows(0).Item("UserId") Is DBNull.Value Then : .UserId_ = dt.Rows(0).Item("UserId") : End If
                If Not dt.Rows(0).Item("CarFare") Is DBNull.Value Then : .CarFare_ = dt.Rows(0).Item("CarFare") : End If
                If Not dt.Rows(0).Item("EscortExtensionFees") Is DBNull.Value Then : .EscortExtensionFees_ = dt.Rows(0).Item("EscortExtensionFees") : End If
                If Not dt.Rows(0).Item("CardName") Is DBNull.Value Then : .CardName_ = dt.Rows(0).Item("CardName") : End If
                If Not dt.Rows(0).Item("Cancel_fees") Is DBNull.Value Then : .Cancel_fees_ = dt.Rows(0).Item("Cancel_fees") : End If
                If Not dt.Rows(0).Item("Bond_amount") Is DBNull.Value Then : .Bond_amount_ = dt.Rows(0).Item("Bond_amount") : End If
                If Not dt.Rows(0).Item("DisplayBookingID") Is DBNull.Value Then : .DisplayBookingID_ = dt.Rows(0).Item("DisplayBookingID") : End If
                If Not dt.Rows(0).Item("UtilizedVoucherAmount") Is DBNull.Value Then : .UtilizedVoucherAmount_ = dt.Rows(0).Item("UtilizedVoucherAmount") : End If
                If Not dt.Rows(0).Item("OriginalShift") Is DBNull.Value Then : .OriginalShift_ = dt.Rows(0).Item("OriginalShift") : End If
                If Not dt.Rows(0).Item("PaidShift") Is DBNull.Value Then : .PaidShift_ = dt.Rows(0).Item("PaidShift") : End If
                If Not dt.Rows(0).Item("Gift") Is DBNull.Value Then : .Gift_ = dt.Rows(0).Item("Gift") : End If
                If Not dt.Rows(0).Item("TOTAIL_PAID") Is DBNull.Value Then : .TOTAIL_PAID_ = dt.Rows(0).Item("TOTAIL_PAID") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.Total
                fn = "Total"
            Case FieldName.BookingId
                fn = "BookingId"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.Cash
                fn = "Cash"
            Case FieldName.CARD
                fn = "CARD"
            Case FieldName.Surcharge
                fn = "Surcharge"
            Case FieldName.Surcharge_Amt
                fn = "Surcharge_Amt"
            Case FieldName.Tip
                fn = "Tip"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.PaymentMode
                fn = "PaymentMode"
            Case FieldName.Sp_Amount
                fn = "Sp_Amount"
            Case FieldName.House_amount
                fn = "House_amount"
            Case FieldName.CashOut
                fn = "CashOut"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.VoucherAmount
                fn = "VoucherAmount"
            Case FieldName.VoucherID
                fn = "VoucherID"
            Case FieldName.ShiftFee
                fn = "ShiftFee"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.Upgrade
                fn = "Upgrade"
            Case FieldName.EncrytedInfo
                fn = "EncrytedInfo"
            Case FieldName.GST
                fn = "GST"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.CarFare
                fn = "CarFare"
            Case FieldName.EscortExtensionFees
                fn = "EscortExtensionFees"
            Case FieldName.CardName
                fn = "CardName"
            Case FieldName.Cancel_fees
                fn = "Cancel_fees"
            Case FieldName.Bond_amount
                fn = "Bond_amount"
            Case FieldName.DisplayBookingID
                fn = "DisplayBookingID"
            Case FieldName.UtilizedVoucherAmount
                fn = "UtilizedVoucherAmount"
            Case FieldName.OriginalShift
                fn = "OriginalShift"
            Case FieldName.PaidShift
                fn = "PaidShift"
            Case FieldName.Gift
                fn = "Gift"
            Case FieldName.TOTAIL_PAID
                fn = "TOTAIL_PAID"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblBookingPayments] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.Sl
                fn = "Sl"
            Case FieldName.Type
                fn = "Type"
            Case FieldName.Total
                fn = "Total"
            Case FieldName.BookingId
                fn = "BookingId"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.Cash
                fn = "Cash"
            Case FieldName.CARD
                fn = "CARD"
            Case FieldName.Surcharge
                fn = "Surcharge"
            Case FieldName.Surcharge_Amt
                fn = "Surcharge_Amt"
            Case FieldName.Tip
                fn = "Tip"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.PaymentMode
                fn = "PaymentMode"
            Case FieldName.Sp_Amount
                fn = "Sp_Amount"
            Case FieldName.House_amount
                fn = "House_amount"
            Case FieldName.CashOut
                fn = "CashOut"
            Case FieldName.WorkerID
                fn = "WorkerID"
            Case FieldName.VoucherAmount
                fn = "VoucherAmount"
            Case FieldName.VoucherID
                fn = "VoucherID"
            Case FieldName.ShiftFee
                fn = "ShiftFee"
            Case FieldName.MemoNo
                fn = "MemoNo"
            Case FieldName.Upgrade
                fn = "Upgrade"
            Case FieldName.EncrytedInfo
                fn = "EncrytedInfo"
            Case FieldName.GST
                fn = "GST"
            Case FieldName.UserId
                fn = "UserId"
            Case FieldName.CarFare
                fn = "CarFare"
            Case FieldName.EscortExtensionFees
                fn = "EscortExtensionFees"
            Case FieldName.CardName
                fn = "CardName"
            Case FieldName.Cancel_fees
                fn = "Cancel_fees"
            Case FieldName.Bond_amount
                fn = "Bond_amount"
            Case FieldName.DisplayBookingID
                fn = "DisplayBookingID"
            Case FieldName.UtilizedVoucherAmount
                fn = "UtilizedVoucherAmount"
            Case FieldName.OriginalShift
                fn = "OriginalShift"
            Case FieldName.PaidShift
                fn = "PaidShift"
            Case FieldName.Gift
                fn = "Gift"
            Case FieldName.TOTAIL_PAID
                fn = "TOTAIL_PAID"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblBookingPayments] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblBookingPause
    Public Shared tablename As String = "tblBookingPause"


    Structure Fields


        Dim ItemSl_ As Int32
        Dim BookingId_ As Int32
        Dim WorkerId_ As Int32
        Dim CreatedDate_ As DateTime
        Dim PausedTime_ As DateTime
        Dim ResumeTime_ As DateTime
        Dim Status_ As String
        Dim Reason_ As String

    End Structure


    Enum FieldName


        [ItemSl]
        [BookingId]
        [WorkerId]
        [CreatedDate]
        [PausedTime]
        [ResumeTime]
        [Status]
        [Reason]

    End Enum


    Public ReadOnly Property tblBookingPause_insert
        Get
            Return <tblBookingPause_insert><![CDATA[
  INSERT INTO [tblBookingPause]
  (
      [ItemSl],
      [BookingId],
      [WorkerId],
      [CreatedDate],
      [PausedTime],
      [ResumeTime],
      [Status],
      [Reason]
  )
  VALUES
  (
      @ItemSl_,
      @BookingId_,
      @WorkerId_,
      @CreatedDate_,
      @PausedTime_,
      @ResumeTime_,
      @Status_,
      @Reason_
  )
]]></tblBookingPause_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingPause_update
        Get
            Return <tblBookingPause_update><![CDATA[
UPDATE [tblBookingPause]
Set 
    [BookingId]=@BookingId_,
    [WorkerId]=@WorkerId_,
    [CreatedDate]=@CreatedDate_,
    [PausedTime]=@PausedTime_,
    [ResumeTime]=@ResumeTime_,
    [Status]=@Status_,
    [Reason]=@Reason_
 WHERE [ItemSl]=@ItemSl_
]]></tblBookingPause_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblBookingPause_select
        Get
            Return <tblBookingPause_select><![CDATA[
SELECT 
      [ItemSl],
      [BookingId],
      [WorkerId],
      [CreatedDate],
      [PausedTime],
      [ResumeTime],
      [Status],
      [Reason]
FROM [tblBookingPause]
    WHERE 1=1
]]></tblBookingPause_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingPause_Delete_By_RowID
        Get
            Return <tblBookingPause_Delete_By_RowID><![CDATA[
DELETE FROM [tblBookingPause] WHERE [ItemSl]=@ItemSl_
]]></tblBookingPause_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingPause_Delete_By_SELECT
        Get
            Return <tblBookingPause_Delete_By_SELECT><![CDATA[
DELETE FROM [tblBookingPause] WHERE 1=1
]]></tblBookingPause_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblBookingPause_MAXID
        Get
            Return <tblBookingPause_MAXID><![CDATA[
SELECT MAX([ItemSl]) FROM [tblBookingPause] WHERE 1=1
]]></tblBookingPause_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblBookingPause_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal BookingId_ As Int32,
    ByVal WorkerId_ As Int32,
    ByVal CreatedDate_ As DateTime,
    ByVal PausedTime_ As DateTime,
    ByVal ResumeTime_ As DateTime,
    ByVal Status_ As String,
    ByVal Reason_ As String,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim ItemSl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblBookingPause_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)
            .AddWithValue("@BookingId_", BookingId_)
            .AddWithValue("@WorkerId_", WorkerId_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@PausedTime_", PausedTime_)
            .AddWithValue("@ResumeTime_", ResumeTime_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Reason_", Reason_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemSl_
    End Function



    Function Update(
    ByVal BookingId_ As Int32,
    ByVal WorkerId_ As Int32,
    ByVal CreatedDate_ As DateTime,
    ByVal PausedTime_ As DateTime,
    ByVal ResumeTime_ As DateTime,
    ByVal Status_ As String,
    ByVal Reason_ As String,
    ByVal ItemSl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblBookingPause_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@BookingId_", BookingId_)
            .AddWithValue("@WorkerId_", WorkerId_)
            .AddWithValue("@CreatedDate_", CreatedDate_)
            .AddWithValue("@PausedTime_", PausedTime_)
            .AddWithValue("@ResumeTime_", ResumeTime_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@Reason_", Reason_)
            .AddWithValue("@ItemSl_", ItemSl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return ItemSl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.BookingId
                fn = "BookingId"
            Case FieldName.WorkerId
                fn = "WorkerId"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.PausedTime
                fn = "PausedTime"
            Case FieldName.ResumeTime
                fn = "ResumeTime"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Reason
                fn = "Reason"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblBookingPause] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBookingPause_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



    Function Delete_By_RowID(
    ByVal ItemSl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblBookingPause_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return ItemSl_
    End Function



    Function Selection_One_Row(
    ByVal ItemSl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBookingPause_select & "  AND [ItemSl]=@ItemSl_"

        With comSelection.Parameters
            .AddWithValue("@ItemSl_", ItemSl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("BookingId") Is DBNull.Value Then : .BookingId_ = dt.Rows(0).Item("BookingId") : End If
                If Not dt.Rows(0).Item("WorkerId") Is DBNull.Value Then : .WorkerId_ = dt.Rows(0).Item("WorkerId") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("PausedTime") Is DBNull.Value Then : .PausedTime_ = dt.Rows(0).Item("PausedTime") : End If
                If Not dt.Rows(0).Item("ResumeTime") Is DBNull.Value Then : .ResumeTime_ = dt.Rows(0).Item("ResumeTime") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Reason") Is DBNull.Value Then : .Reason_ = dt.Rows(0).Item("Reason") : End If
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblBookingPause_select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field

                If Not dt.Rows(0).Item("ItemSl") Is DBNull.Value Then : .ItemSl_ = dt.Rows(0).Item("ItemSl") : End If
                If Not dt.Rows(0).Item("BookingId") Is DBNull.Value Then : .BookingId_ = dt.Rows(0).Item("BookingId") : End If
                If Not dt.Rows(0).Item("WorkerId") Is DBNull.Value Then : .WorkerId_ = dt.Rows(0).Item("WorkerId") : End If
                If Not dt.Rows(0).Item("CreatedDate") Is DBNull.Value Then : .CreatedDate_ = dt.Rows(0).Item("CreatedDate") : End If
                If Not dt.Rows(0).Item("PausedTime") Is DBNull.Value Then : .PausedTime_ = dt.Rows(0).Item("PausedTime") : End If
                If Not dt.Rows(0).Item("ResumeTime") Is DBNull.Value Then : .ResumeTime_ = dt.Rows(0).Item("ResumeTime") : End If
                If Not dt.Rows(0).Item("Status") Is DBNull.Value Then : .Status_ = dt.Rows(0).Item("Status") : End If
                If Not dt.Rows(0).Item("Reason") Is DBNull.Value Then : .Reason_ = dt.Rows(0).Item("Reason") : End If
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.BookingId
                fn = "BookingId"
            Case FieldName.WorkerId
                fn = "WorkerId"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.PausedTime
                fn = "PausedTime"
            Case FieldName.ResumeTime
                fn = "ResumeTime"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Reason
                fn = "Reason"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblBookingPause] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName,
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName

            Case FieldName.ItemSl
                fn = "ItemSl"
            Case FieldName.BookingId
                fn = "BookingId"
            Case FieldName.WorkerId
                fn = "WorkerId"
            Case FieldName.CreatedDate
                fn = "CreatedDate"
            Case FieldName.PausedTime
                fn = "PausedTime"
            Case FieldName.ResumeTime
                fn = "ResumeTime"
            Case FieldName.Status
                fn = "Status"
            Case FieldName.Reason
                fn = "Reason"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblBookingPause] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class


Public Class Database_Table_code_class_tblActiveWorker
    Public Shared tablename As String = "tblActiveWorker"


    Structure Fields


        Dim sl_ As Int32
        Dim workerid_ As Int32
        Dim workingdate_ As DateTime
        Dim room_ As String
        Dim service_ As Int32
        Dim addedtime_ As DateTime
        Dim starttime_ As DateTime
        Dim Status_ As String
        Dim BookingId_ As Int32
        Dim StoppedTime_ As DateTime
        Dim MemoNo_ As Int32
        Dim UserId_ As Int32

    End Structure


    Enum FieldName


        [sl]
        [workerid]
        [workingdate]
        [room]
        [service]
        [addedtime]
        [starttime]
        [Status]
        [BookingId]
        [StoppedTime]
        [MemoNo]
        [UserId]

    End Enum


    Public ReadOnly Property tblActiveWorker_insert
        Get
            Return <tblActiveWorker_insert><![CDATA[
  INSERT INTO [tblActiveWorker]
  (
      [sl],
      [workerid],
      [workingdate],
      [room],
      [service],
      [addedtime],
      [starttime],
      [Status],
      [BookingId],
      [StoppedTime],
      [MemoNo],
      [UserId]
  )
  VALUES
  (
      @sl_,
      @workerid_,
      @workingdate_,
      @room_,
      @service_,
      @addedtime_,
      @starttime_,
      @Status_,
      @BookingId_,
      @StoppedTime_,
      @MemoNo_,
      @UserId_
  )
]]></tblActiveWorker_insert>.Value
        End Get
    End Property


    Private ReadOnly Property tblActiveWorker_update
        Get
            Return <tblActiveWorker_update><![CDATA[
UPDATE [tblActiveWorker]
Set 
    [workerid]=@workerid_,
    [workingdate]=@workingdate_,
    [room]=@room_,
    [service]=@service_,
    [addedtime]=@addedtime_,
    [starttime]=@starttime_,
    [Status]=@Status_,
    [BookingId]=@BookingId_,
    [StoppedTime]=@StoppedTime_,
    [MemoNo]=@MemoNo_,
    [UserId]=@UserId_
 WHERE [sl]=@sl_
]]></tblActiveWorker_update>.Value
        End Get
    End Property


    Public ReadOnly Property tblActiveWorker_select
        Get
            Return <tblActiveWorker_select><![CDATA[
SELECT 
      [sl],
      [workerid],
      [workingdate],
      [room],
      [service],
      [addedtime],
      [starttime],
      [Status],
      [BookingId],
      [StoppedTime],
      [MemoNo],
      [UserId]
FROM [tblActiveWorker]
    WHERE 1=1
]]></tblActiveWorker_select>.Value
        End Get
    End Property


    Private ReadOnly Property tblActiveWorker_Delete_By_RowID
        Get
            Return <tblActiveWorker_Delete_By_RowID><![CDATA[
DELETE FROM [tblActiveWorker] WHERE [sl]=@sl_
]]></tblActiveWorker_Delete_By_RowID>.Value
        End Get
    End Property


    Private ReadOnly Property tblActiveWorker_Delete_By_SELECT
        Get
            Return <tblActiveWorker_Delete_By_SELECT><![CDATA[
DELETE FROM [tblActiveWorker] WHERE 1=1
]]></tblActiveWorker_Delete_By_SELECT>.Value
        End Get
    End Property


    Private ReadOnly Property tblActiveWorker_MAXID
        Get
            Return <tblActiveWorker_MAXID><![CDATA[
SELECT MAX([sl]) FROM [tblActiveWorker] WHERE 1=1
]]></tblActiveWorker_MAXID>.Value
        End Get
    End Property


    Function MaxID_PlusOne(Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer
        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim _MaxID As Integer = 1

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comMaxID As New SqlCommand(tblActiveWorker_MAXID, _conn)
        If Not _transac Is Nothing Then
            comMaxID.Transaction = _transac
        End If

        Try
            Dim obj As Object = comMaxID.ExecuteScalar
            _MaxID = IIf(obj Is DBNull.Value, 0, obj) + 1
        Catch ex As Exception
            comMaxID.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comMaxID.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return _MaxID
    End Function



    Function Insert(
    ByVal workerid_ As Int32,
    ByVal workingdate_ As DateTime,
    ByVal room_ As String,
    ByVal service_ As Int32,
    ByVal addedtime_ As DateTime,
    ByVal starttime_ As DateTime,
    ByVal Status_ As String,
    ByVal BookingId_ As Int32,
    ByVal StoppedTime_ As DateTime,
    ByVal MemoNo_ As Int32,
    ByVal UserId_ As Int32,
                    Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        Dim sl_ As Integer = MaxID_PlusOne(_conn, _transac)

        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comInsert As New SqlCommand(tblActiveWorker_insert, _conn)
        If Not _transac Is Nothing Then
            comInsert.Transaction = _transac
        End If

        With comInsert.Parameters
            .AddWithValue("@sl_", sl_)
            .AddWithValue("@workerid_", workerid_)
            .AddWithValue("@workingdate_", workingdate_)
            .AddWithValue("@room_", room_)
            .AddWithValue("@service_", service_)
            .AddWithValue("@addedtime_", addedtime_)
            .AddWithValue("@starttime_", starttime_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@BookingId_", BookingId_)
            .AddWithValue("@StoppedTime_", StoppedTime_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@UserId_", UserId_)

        End With


        Try
            Dim obj As Object = comInsert.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Inserted")
            End If
        Catch ex As Exception
            comInsert.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try
        comInsert.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



    Function Update(
    ByVal workerid_ As Int32,
    ByVal workingdate_ As DateTime,
    ByVal room_ As String,
    ByVal service_ As Int32,
    ByVal addedtime_ As DateTime,
    ByVal starttime_ As DateTime,
    ByVal Status_ As String,
    ByVal BookingId_ As Int32,
    ByVal StoppedTime_ As DateTime,
    ByVal MemoNo_ As Int32,
    ByVal UserId_ As Int32,
    ByVal sl_ As Int32,
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comUpdated As New SqlCommand(tblActiveWorker_update, _conn)
        If Not _transac Is Nothing Then
            comUpdated.Transaction = _transac
        End If

        With comUpdated.Parameters
            .AddWithValue("@workerid_", workerid_)
            .AddWithValue("@workingdate_", workingdate_)
            .AddWithValue("@room_", room_)
            .AddWithValue("@service_", service_)
            .AddWithValue("@addedtime_", addedtime_)
            .AddWithValue("@starttime_", starttime_)
            .AddWithValue("@Status_", Status_)
            .AddWithValue("@BookingId_", BookingId_)
            .AddWithValue("@StoppedTime_", StoppedTime_)
            .AddWithValue("@MemoNo_", MemoNo_)
            .AddWithValue("@UserId_", UserId_)
            .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comUpdated.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdated.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdated.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return sl_
    End Function




    Function Update_field(ByVal _fieldName As FieldName, ByVal value As Object, _
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName
            
            Case FieldName.sl
                fn="sl"
            Case FieldName.workerid
                fn="workerid"
            Case FieldName.workingdate
                fn="workingdate"
            Case FieldName.room
                fn="room"
            Case FieldName.service
                fn="service"
            Case FieldName.addedtime
                fn="addedtime"
            Case FieldName.starttime
                fn="starttime"
            Case FieldName.Status
                fn="Status"
            Case FieldName.BookingId
                fn="BookingId"
            Case FieldName.StoppedTime
                fn="StoppedTime"
            Case FieldName.MemoNo
                fn="MemoNo"
            Case FieldName.UserId
                fn="UserId"
        End Select

        Dim comUpdate As New SqlCommand("Update [tblActiveWorker] Set [" & fn.ToString & "]=@" & _fieldName.ToString & " WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comUpdate.Transaction = _transac
        End If
        With comUpdate.Parameters
            .Clear()
            .AddWithValue("@" & _fieldName.ToString, value)
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With


        Dim obj As Object = Nothing
        Try
            obj = comUpdate.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Updated")
            End If
        Catch ex As Exception
            comUpdate.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comUpdate.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return obj
    End Function




    Function Delete_By_SELECT(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblActiveWorker_Delete_By_SELECT & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If
        With comDelete.Parameters
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function



   Function Delete_By_RowID( _
    ByVal sl_ as int32 , _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Integer

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim comDelete As New SqlCommand(tblActiveWorker_Delete_By_RowID, _conn)
        If Not _transac Is Nothing Then
            comDelete.Transaction = _transac
        End If

        With comDelete.Parameters
                        .AddWithValue("@sl_", sl_)

        End With

        Try
            Dim obj As Object = comDelete.ExecuteNonQuery
            If obj = 0 Then
                Throw New Exception("No Records Deleted")
            End If
        Catch ex As Exception
            comDelete.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comDelete.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return sl_
    End Function



   Function Selection_One_Row( _
    ByVal sl_ as int32 , _
                   Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

         Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblActiveWorker_Select & "  AND [sl]=@sl_"

        With comSelection.Parameters
                        .AddWithValue("@sl_", sl_)

        End With
        Dim daSelection As New SqlDataAdapter(comSelection)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
            With return_field
                
if not dt.Rows(0).Item("sl") is dbnull.value then : .sl_ = dt.Rows(0).Item("sl") : end if
if not dt.Rows(0).Item("workerid") is dbnull.value then : .workerid_ = dt.Rows(0).Item("workerid") : end if
if not dt.Rows(0).Item("workingdate") is dbnull.value then : .workingdate_ = dt.Rows(0).Item("workingdate") : end if
if not dt.Rows(0).Item("room") is dbnull.value then : .room_ = dt.Rows(0).Item("room") : end if
if not dt.Rows(0).Item("service") is dbnull.value then : .service_ = dt.Rows(0).Item("service") : end if
if not dt.Rows(0).Item("addedtime") is dbnull.value then : .addedtime_ = dt.Rows(0).Item("addedtime") : end if
if not dt.Rows(0).Item("starttime") is dbnull.value then : .starttime_ = dt.Rows(0).Item("starttime") : end if
if not dt.Rows(0).Item("Status") is dbnull.value then : .Status_ = dt.Rows(0).Item("Status") : end if
if not dt.Rows(0).Item("BookingId") is dbnull.value then : .BookingId_ = dt.Rows(0).Item("BookingId") : end if
if not dt.Rows(0).Item("StoppedTime") is dbnull.value then : .StoppedTime_ = dt.Rows(0).Item("StoppedTime") : end if
if not dt.Rows(0).Item("MemoNo") is dbnull.value then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : end if
if not dt.Rows(0).Item("UserId") is dbnull.value then : .UserId_ = dt.Rows(0).Item("UserId") : end if
            End With


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

        Return return_field
    End Function




    Function Selection_One_Row_Select(Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Fields

        Dim dt As New DataTable
        Dim return_field As New Fields
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
        comSelection.CommandText = tblActiveWorker_Select & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), "")

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
            With return_field
                
if not dt.Rows(0).Item("sl") is dbnull.value then : .sl_ = dt.Rows(0).Item("sl") : end if
if not dt.Rows(0).Item("workerid") is dbnull.value then : .workerid_ = dt.Rows(0).Item("workerid") : end if
if not dt.Rows(0).Item("workingdate") is dbnull.value then : .workingdate_ = dt.Rows(0).Item("workingdate") : end if
if not dt.Rows(0).Item("room") is dbnull.value then : .room_ = dt.Rows(0).Item("room") : end if
if not dt.Rows(0).Item("service") is dbnull.value then : .service_ = dt.Rows(0).Item("service") : end if
if not dt.Rows(0).Item("addedtime") is dbnull.value then : .addedtime_ = dt.Rows(0).Item("addedtime") : end if
if not dt.Rows(0).Item("starttime") is dbnull.value then : .starttime_ = dt.Rows(0).Item("starttime") : end if
if not dt.Rows(0).Item("Status") is dbnull.value then : .Status_ = dt.Rows(0).Item("Status") : end if
if not dt.Rows(0).Item("BookingId") is dbnull.value then : .BookingId_ = dt.Rows(0).Item("BookingId") : end if
if not dt.Rows(0).Item("StoppedTime") is dbnull.value then : .StoppedTime_ = dt.Rows(0).Item("StoppedTime") : end if
if not dt.Rows(0).Item("MemoNo") is dbnull.value then : .MemoNo_ = dt.Rows(0).Item("MemoNo") : end if
if not dt.Rows(0).Item("UserId") is dbnull.value then : .UserId_ = dt.Rows(0).Item("UserId") : end if
            End With


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

        Return return_field
    End Function




    Function SelectScalar(ByVal _fieldName As FieldName, _
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As Object


        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If

        Dim fn As String = ""
        Select Case _fieldName
            
            Case FieldName.sl
                fn="sl"
            Case FieldName.workerid
                fn="workerid"
            Case FieldName.workingdate
                fn="workingdate"
            Case FieldName.room
                fn="room"
            Case FieldName.service
                fn="service"
            Case FieldName.addedtime
                fn="addedtime"
            Case FieldName.starttime
                fn="starttime"
            Case FieldName.Status
                fn="Status"
            Case FieldName.BookingId
                fn="BookingId"
            Case FieldName.StoppedTime
                fn="StoppedTime"
            Case FieldName.MemoNo
                fn="MemoNo"
            Case FieldName.UserId
                fn="UserId"
        End Select

        Dim comSelectScalar As New SqlCommand("SELECT TOP 1 " & fn & "  from [tblActiveWorker] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectScalar.Transaction = _transac
        End If
        With comSelectScalar.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With
        Dim obj As Object = Nothing
        Try
            obj = comSelectScalar.ExecuteScalar
        Catch ex As Exception
            comSelectScalar.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectScalar.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If
        Return obj
    End Function




    Function SelectDistinct(ByVal _fieldName As FieldName, _
                   Optional ByVal _selectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable

        Dim isDisposableItem As Boolean = False
        Dim objConn As clsConnection = Nothing
        If _conn Is Nothing Then
            objConn = New clsConnection
            _conn = objConn.connect
            isDisposableItem = True
        End If
        Dim fn As String = ""
        Select Case _fieldName
            
            Case FieldName.sl
                fn="sl"
            Case FieldName.workerid
                fn="workerid"
            Case FieldName.workingdate
                fn="workingdate"
            Case FieldName.room
                fn="room"
            Case FieldName.service
                fn="service"
            Case FieldName.addedtime
                fn="addedtime"
            Case FieldName.starttime
                fn="starttime"
            Case FieldName.Status
                fn="Status"
            Case FieldName.BookingId
                fn="BookingId"
            Case FieldName.StoppedTime
                fn="StoppedTime"
            Case FieldName.MemoNo
                fn="MemoNo"
            Case FieldName.UserId
                fn="UserId"
        End Select

        Dim comSelectDistinct As New SqlCommand("SELECT DISTINCT " & fn & "  from [tblActiveWorker] WHERE 1=1 " & IIf(_selectString <> "", IIf(_selectString.Trim.StartsWith("AND"), _selectString, " AND " & _selectString), ""), _conn)
        If Not _transac Is Nothing Then
            comSelectDistinct.Transaction = _transac
        End If
        With comSelectDistinct.Parameters
            .Clear()
            If Not _params Is Nothing Then
                For Each p As SqlParameter In _params
                    .Add(p)
                Next
            End If
        End With

        Dim dt As New DataTable
        Dim daSelection As New SqlDataAdapter(comSelectDistinct)
        Try
            daSelection.Fill(dt)
            If dt.Rows.Count = 0 Then
                'Throw New Exception("No Records Found")
            End If
        Catch ex As Exception

            comSelectDistinct.Dispose()
            daSelection.Dispose()
            If isDisposableItem Then
                objConn.Dispose()
                _conn.Dispose()
                isDisposableItem = False
            End If
            Throw ex
        End Try

        comSelectDistinct.Dispose()
        daSelection.Dispose()
        If isDisposableItem Then
            objConn.Dispose()
            _conn.Dispose()
            isDisposableItem = False
        End If

        Return dt
    End Function



End Class