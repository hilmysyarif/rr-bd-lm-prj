Imports System.IO

Public Class cls_tblActiveWorker


    Private ReadOnly Property tblActiveWorker_tblActiveWorker_MAXSL As String
        Get
            Return <tblActiveWorker_INSERT><![CDATA[
                SELECT MAX([SL]) FROM [tblActiveWorker]
                    ]]></tblActiveWorker_INSERT>.Value
        End Get
    End Property

    Private ReadOnly Property tblActiveWorker_tblActiveWorker_INSERT As String
        Get
            Return <tblActiveWorker_INSERT><![CDATA[
                INSERT INTO [tblActiveWorker]
                (
                    [SL],
                    [WorkerID],
                    [workingdate],
                    [room],
                    [service],
                    [starttime],
                    [Status], 
                    [BookingId],
                    [MemoNo]
                )
                VALUES
                (
                    @SL,
                    @WorkerID,
                    @workingdate,
                    @room,
                    @service,
                    @starttime,
                    @Status, 
                    @BookingId,
                    @MemoNo
                )
                    ]]></tblActiveWorker_INSERT>.Value
        End Get

    End Property


    Public Function MaxID_tblActiveWorker(Optional ByRef conn As SQLConnection = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim ID As Integer = 1 ' 1 states that, the ID field will start from 1
        Dim comID As New SQLCommand(tblActiveWorker_tblActiveWorker_MAXSL, conn)
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

    Public Function Insert_tblActiveWorker( _
                          ByVal WorkerID As String, _
                          ByVal WorkingDate As Date, _
                          ByVal Room As String, _
                          ByVal Service As Integer, _
                          ByVal starttime As Date, _
                          ByVal Status As String, _
                          ByVal BookingId As Integer, _
                          ByVal MemoNO As Integer, _
                          Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim sl As Integer = MaxID_tblActiveWorker(conn)

        Dim comInsert As New SQLCommand(tblActiveWorker_tblActiveWorker_INSERT, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If

        With comInsert.Parameters
            .Clear()
            .AddWithValue("@sl", sl)
            .AddWithValue("@WorkerID", Val(WorkerID))
            .Add("@WorkingDate", SqlDbType.DateTime).Value = WorkingDate
            .AddWithValue("@room", Room)
            .AddWithValue("@Service", Service)
            .Add("@starttime", SqlDbType.DateTime).Value = starttime
            .AddWithValue("@Status", Status)
            .AddWithValue("@BookingId", BookingId)
            .AddWithValue("@MemoNO", MemoNO)
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
        Return WorkerID
    End Function

    Private ReadOnly Property tblActiveWorker_tblActiveWorker_DELETE As String
        Get
            Return <tblActiveWorker_INSERT><![CDATA[
                DELETE FROM [tblActiveWorker] WHERE [WorkerID]=@WorkerID and [workingdate]=@workingdate and [Room]=''
                     ]]></tblActiveWorker_INSERT>.Value
        End Get
    End Property
    Public Function Delete_tblActiveWorker(ByVal WorkerID As String, ByVal WorkingDate As Date, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblActiveWorker_tblActiveWorker_DELETE, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@WorkerID", WorkerID)
            .AddWithValue("@WorkingDate", WorkingDate)
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
        Return Val(obj)
    End Function

    Private ReadOnly Property tblActiveWorker_tblActiveWorker_START As String
        Get
            Return <tblActiveWorker_INSERT><![CDATA[
                UPDATE [tblActiveWorker] SET [STATUS]='STARTED',[StartTime]=GETDATE() WHERE [BookingID]=@BookingID
                     ]]></tblActiveWorker_INSERT>.Value
        End Get
    End Property

    Public Function Start_tblActiveWorker(ByVal BookingID As Integer, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comUpdate As New SQLCommand(tblActiveWorker_tblActiveWorker_START, conn)
        If transact IsNot Nothing Then
            comUpdate.Transaction = transact
        End If
        With comUpdate.Parameters
            .AddWithValue("@BookingID", BookingID)
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
        Return Val(obj)
    End Function

    Private ReadOnly Property tblActiveWorker_tblActiveWorker_DELETE2 As String
        Get
            Return <tblActiveWorker_INSERT><![CDATA[
                DELETE FROM [tblActiveWorker] WHERE [Sl]=@sl
                     ]]></tblActiveWorker_INSERT>.Value
        End Get
    End Property

    Public Function Delete_tblActiveWorker(ByVal ActiveSl As String, Optional ByRef conn As SQLConnection = Nothing, Optional ByRef transact As SQLTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comDelete As New SQLCommand(tblActiveWorker_tblActiveWorker_DELETE2, conn)
        If transact IsNot Nothing Then
            comDelete.Transaction = transact
        End If
        With comDelete.Parameters
            .AddWithValue("@Sl", ActiveSl)
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
        Return Val(obj)
    End Function

    Public ReadOnly Property tblActiveWorker_tblActiveWorker_SELECT As String
        Get
            Return <tblActiveWorker_tblActiveWorker_SELECT><![CDATA[

                   SELECT 

                       a.[SL],
                       a.[WorkerID],
                       b.[WorkerName],
                       a.[WorkerID],
                       a.[workingdate],
                       a.[room],
                       isnull(c.serv1,0) as [service],
                       a.[starttime], 
                       a.[Status],
                       a.[BookingId],
                       c.[st],
                       d.TotalClient,
                       isnull(e.Time ,0) as [PMinute],
                       isnull(f.Status,'') as [PStatus],
                       ISNULL(f.pausedtime,getdate()) as [PausedTime], 
                       isnull(c.Extended ,'') as [Extended],
                       d.DisplayBookingId

                   FROM 
                       [tblActiveWorker] a 
                   LEFT OUTER JOIN 
                       [tblWorkers] b on a.workerid= b.workerid
                   LEFT OUTER JOIN 
                        (select sum(Service) as [serv1],workerid as wi,max(servicetype) as st,bookingid as bi,case when count(sl) > 1 then 'E' else '' end as Extended  from [tblExtraService] group by workerid,bookingid)  c  on a.workerid= c.wi and a.bookingid = c.bi
                   LEFT OUTER JOIN 
						tblBookings d on a.BookingId = d.BookingID 
				   LEFT OUTER JOIN
						(select a.BookingId , a.workerid , SUM(case when b.status='RESUMED' or b.status='ADJUST' then DATEDIFF(SECOND ,(case when b.PausedTime < a.starttime AND b.status<>'ADJUST' then a.starttime else b.PausedTime end), resumetime)/60 else 0 end )as [Time]   from tblActiveWorker a left outer join tblBookingPause b on a.BookingId = b.BookingId group by a.BookingId , a.workerid ) e  on a.BookingId = e.BookingID and a.workerid = e.workerid 
                   LEFT OUTER JOIN
						(select BookingId, status, PausedTime from tblBookingPause where ItemSl in (select MAX(itemsl) from tblBookingPause group by BookingId)  ) f  on a.BookingId = f.BookingID 
                   LEFT OUTER JOIN
						(select  ROW_NUMBER() over (order by MAX(ssss)) as sl, BookingId from (select *,DateAdd(Minute,c.serv1,a.starttime) as ssss FROM [tblActiveWorker] a LEFT OUTER JOIN (select sum(Service) as [serv1],workerid as wi,bookingid as bi  from [tblExtraService] group by workerid,bookingid)  c  on a.workerid= c.wi and a.bookingid = c.bi) a group by a.BookingId ) g  on a.BookingId = g.BookingID 
                   Where a.BookingId Not in (Select BookingId from tblBookingStatus)   


    ]]></tblActiveWorker_tblActiveWorker_SELECT>.Value
        End Get
    End Property

    Enum WorkerTypeDG
        Active = 0
        All = 1
        Queue = 2
        Suspended = 3
    End Enum

    Public Sub LoadWorkersInDG(ByVal dg As DataGridView, Optional ByVal tp As WorkerTypeDG = WorkerTypeDG.Active)

        dg.Rows.Clear()

        Dim SELECTSTRING As String = ""
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLDataAdapter("", conn)

        Select Case tp
            Case WorkerTypeDG.Active
                SELECTSTRING = " AND GETDATE() BETWEEN DATEADD(Minute,-1,a.[starttime]) and @Date1 and a.[starttime] between @Date2 and @Date3 and a.[Room]<>'' and (a.[Status]='' OR a.[Status]='STARTED') and a.[room] not in (" & RoomVisibleQuerySelection & ") Order by  a.Status desc, g.sl,DateAdd(Minute,c.serv1,a.starttime) desc"
                da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime).Value = Today.AddDays(1).AddSeconds(-1)
                da.SelectCommand.Parameters.Add("@Date2", SqlDbType.DateTime).Value = Today.AddDays(-1000)
                da.SelectCommand.Parameters.Add("@Date3", SqlDbType.DateTime).Value = Today.AddDays(1).AddSeconds(-1)
            Case WorkerTypeDG.Suspended
                SELECTSTRING = " AND GETDATE() BETWEEN DATEADD(Minute,-1,a.[starttime]) and @Date1 and a.[starttime] between @Date2 and @Date3 and a.[Room]<>'' and ((a.[Status] like 'Suspended%') or a.BookingId in (Select BookingID from tblBookingStatus Where Status='SUSPEND')) and a.[room] not in (" & RoomVisibleQuerySelection & ") Order by a.BookingID,DateAdd(Minute,c.serv1,a.starttime) desc"
                da.SelectCommand.Parameters.Add("@Date1", SqlDbType.DateTime).Value = Today.AddDays(1).AddSeconds(-1)
                da.SelectCommand.Parameters.Add("@Date2", SqlDbType.DateTime).Value = Today.AddDays(-1000)
                da.SelectCommand.Parameters.Add("@Date3", SqlDbType.DateTime).Value = Today.AddDays(1).AddSeconds(-1)
            Case WorkerTypeDG.All
                SELECTSTRING = " AND  a.[starttime]>NOW()  and a.[room] not in (" & RoomVisibleQuerySelection & ")"
            Case WorkerTypeDG.Queue
                SELECTSTRING = " AND ((a.[Room]='' and a.[Status]='') OR  a.[Status]='QUEUE')  and a.[room] not in (" & RoomVisibleQuerySelection & ")"
        End Select

        Dim newQuery As String = tblActiveWorker_tblActiveWorker_SELECT + SELECTSTRING
        da.SelectCommand.CommandText = newQuery
        Dim dt As New DataTable
        da.Fill(dt)
        Dim addedRowConter As Integer = 0
        Dim LastBookingID As Integer = 0
        Dim objBooking As New cls_Temp_tblBookings


        For i = 0 To dt.Rows.Count - 1
            Dim drItem As System.Data.DataRow = dt.Rows(i)
            Dim Sty As String = "S"
            Try
                Sty = drItem("ST").ToString.Substring(0, 1).ToUpper()
            Catch ex As Exception
            End Try
            Dim Extended As String = ""
            Try
                Extended = drItem("Extended").ToString.Substring(0, 1).ToUpper()
            Catch ex As Exception
            End Try
            If Extended <> "" Then
                Extended = " (" & Extended & ")"
            End If

            Select Case tp
                Case WorkerTypeDG.Queue
                    Dim cn As String = ""
                    Try
                        cn = objBooking.SelectDistinct(Database_Table_code_class_tblBookings.FieldName.CustomerName, "BookingID=" & drItem("BookingID").ToString).Rows(0).Item(0)
                    Catch ex As Exception
                    End Try

                    If LastBookingID <> drItem("BookingID") Then
                        LastBookingID = drItem("BookingID")
                        dg.Rows.Add(drItem("WorkerID"), _
                                                            drItem("WorkerName"), _
                                                            drItem("Room"), _
                                                            drItem("Service").ToString + " Mins", _
                                                            drItem("Service").ToString + " Mins", _
                                                            drItem("starttime").ToString, _
                                                            drItem("sl"), _
                                                            cn, _
                                                            drItem("DisplayBookingId"))
                        dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = IIf(drItem("status") = "STARTED", ActiveStarted(0), ActiveNotStarted(0))
                        dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.ForeColor = IIf(drItem("status") = "STARTED", ActiveStarted(1), ActiveNotStarted(1))
                        addedRowConter = dg.RowCount
                        dg.Rows(dg.Rows.Count - 1).Height = 40
                    Else
                        dg.Rows(addedRowConter - 1).Cells(0).Value = dg.Rows(addedRowConter - 1).Cells(0).Value.ToString & "," & drItem("WorkerID").ToString
                        dg.Rows(addedRowConter - 1).Cells(1).Value = dg.Rows(addedRowConter - 1).Cells(1).Value.ToString & vbNewLine & drItem("WorkerName").ToString  '+ "(" + drItem("Service").ToString + "/" + drItem("Service").ToString & IIf(MySettings.SpecialServiceEnabled, " " & drItem("ST").ToString.Substring(0, 1).ToUpper, "") + ")"
                        dg.Rows(addedRowConter - 1).Cells(5).Value = dg.Rows(addedRowConter - 1).Cells(5).Value.ToString & vbNewLine & drItem("starttime").ToString
                        dg.Rows(addedRowConter - 1).Cells(6).Value = dg.Rows(addedRowConter - 1).Cells(6).Value.ToString & "," & drItem("sl").ToString
                        dg.Rows(dg.Rows.Count - 1).Height += 15
                    End If
                Case WorkerTypeDG.Active
                    If LastBookingID <> drItem("BookingID") Then
                        LastBookingID = drItem("BookingID")
                        dg.Rows.Add(drItem("WorkerID"), _
                                            drItem("WorkerName") + Extended + " (" + drItem("Service").ToString + "/" + drItem("Service").ToString & IIf(MySettings.SpecialServiceEnabled, " " & Sty, "") + ")", _
                                            drItem("Room"), _
                                            drItem("Service").ToString + " Mins", _
                                           (Val(drItem("Service").ToString) + Val(drItem("PMinute").ToString)).ToString + " Mins", _
                                            drItem("starttime").ToString, _
                                            drItem("sl"), _
                                            drItem("status"), _
                                            IIf(drItem("status") = "STARTED", IIf(drItem("PStatus") = "PAUSED", "RESUME", "RESET"), "ACTIVATE"), drItem("BookingID"), drItem("TotalClient"), _
                                            drItem("PMinute"), _
                                            drItem("PStatus"), _
                                            drItem("PausedTime"), _
                                            drItem("DisplayBookingId"))
                        If drItem("PStatus") = "PAUSED" Then
                            dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = PausedBooking(0)
                            dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.ForeColor = PausedBooking(1)
                        Else
                            dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = IIf(drItem("status") = "STARTED", ActiveStarted(0), ActiveNotStarted(0))
                            dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.ForeColor = IIf(drItem("status") = "STARTED", ActiveStarted(1), ActiveNotStarted(1))
                        End If
                        addedRowConter = dg.RowCount
                        dg.Rows(dg.Rows.Count - 1).Height = 40
                    Else
                        dg.Rows(addedRowConter - 1).Cells(0).Value = dg.Rows(addedRowConter - 1).Cells(0).Value.ToString & "," & drItem("WorkerID").ToString
                        dg.Rows(addedRowConter - 1).Cells(1).Value = dg.Rows(addedRowConter - 1).Cells(1).Value.ToString & vbNewLine & drItem("WorkerName").ToString + Extended + " (" + drItem("Service").ToString + "/" + drItem("Service").ToString & IIf(MySettings.SpecialServiceEnabled, " " & Sty, "") + ")"
                        dg.Rows(addedRowConter - 1).Cells(5).Value = dg.Rows(addedRowConter - 1).Cells(5).Value.ToString & vbNewLine & drItem("starttime").ToString
                        dg.Rows(addedRowConter - 1).Cells(6).Value = dg.Rows(addedRowConter - 1).Cells(6).Value.ToString & "," & drItem("sl").ToString
                        Try
                            dg.Rows(addedRowConter - 1).Cells(11).Value = dg.Rows(addedRowConter - 1).Cells(11).Value.ToString & "," & drItem("PMinute").ToString
                        Catch ex As Exception
                        End Try
                        dg.Rows(dg.Rows.Count - 1).Height += 15
                    End If
                Case WorkerTypeDG.Suspended
                    If LastBookingID <> drItem("BookingID") Then
                        LastBookingID = drItem("BookingID")
                        dg.Rows.Add(drItem("WorkerID"), _
                                    drItem("WorkerName") + "(" + drItem("Service").ToString + "/" + drItem("Service").ToString + ")", _
                                    drItem("Room"), _
                                    drItem("Service").ToString + " Mins", _
                                    drItem("Service").ToString + " Mins", _
                                    drItem("starttime").ToString, _
                                    drItem("sl"), _
                                    drItem("status"), _
                                    IIf(drItem("status") = "STARTED", "RESET", "ACTIVATE"), drItem("BookingID"))
                        dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = IIf(drItem("status") = "STARTED", ActiveStarted(0), ActiveNotStarted(0))
                        dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.ForeColor = IIf(drItem("status") = "STARTED", ActiveStarted(1), ActiveNotStarted(1))
                        addedRowConter += 1
                        dg.Rows(dg.Rows.Count - 1).Height = 40
                    Else
                        dg.Rows(addedRowConter - 1).Cells(0).Value = dg.Rows(addedRowConter - 1).Cells(0).Value.ToString & "," & drItem("WorkerID").ToString
                        dg.Rows(addedRowConter - 1).Cells(1).Value = dg.Rows(addedRowConter - 1).Cells(1).Value.ToString & vbNewLine & drItem("WorkerName").ToString + "(" + drItem("Service").ToString + "/" + drItem("Service").ToString + ")"
                        dg.Rows(addedRowConter - 1).Cells(5).Value = dg.Rows(addedRowConter - 1).Cells(5).Value.ToString & vbNewLine & drItem("starttime").ToString
                        dg.Rows(addedRowConter - 1).Cells(6).Value = dg.Rows(addedRowConter - 1).Cells(6).Value.ToString & "," & drItem("sl").ToString
                        dg.Rows(dg.Rows.Count - 1).Height += 15
                    End If

                Case Else
                    dg.Rows.Add(drItem("WorkerID"), _
                                drItem("WorkerName"), _
                                drItem("Room"), _
                                drItem("Service").ToString + " Mins", _
                                drItem("Service").ToString + " Mins", _
                                drItem("starttime"), _
                                drItem("sl"))

                    dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = ActiveStarted(0)
                    dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.ForeColor = ActiveStarted(1)
                    dg.Rows(dg.Rows.Count - 1).Height = 45
            End Select

        Next

        Try
            da.Dispose()
            dt.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Public Function tblActiveWorker_Selection(Optional ByVal SelectType As Integer = 0, Optional ByVal SelectString As String = "", Optional ByVal Parameters As List(Of SQLParameter) = Nothing, Optional ByRef conn As SQLConnection = Nothing) As DataTable

        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing

        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If

        Dim comSelect As New SQLCommand("", conn)
        Select Case SelectType
            Case 0
                comSelect.CommandText = tblActiveWorker_tblActiveWorker_SELECT & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("AND"), " ", " AND ") & SelectString, "")
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

    Private ReadOnly Property tblActiveWorker_tblActiveWorker_MinQueueID As String
        Get
            Return <tblActiveWorker_tblActiveWorker_SELECT><![CDATA[

                SELECT 
                    Min([SL])
                FROM 
                    [tblActiveWorker]  
                WHERE
                    [Room]='' AND [WorkerId]=@WorkerId

                    ]]></tblActiveWorker_tblActiveWorker_SELECT>.Value
        End Get
    End Property

    Public Function GetFirstActiveID(ByVal WorkerID As Integer) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblActiveWorker_tblActiveWorker_MinQueueID, conn)
        da.Parameters.Add("@WorkerId", SqlDbType.Int).Value = WorkerID
        ret = da.ExecuteScalar
        Try
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret
    End Function

    Private ReadOnly Property tblActiveWorker_tblActiveWorker_Update As String
        Get
            Return <tblActiveWorker_tblActiveWorker_SELECT><![CDATA[
                UPDATE
                    [tblActiveWorker] 
                SET
                    [Room]=@Room , [starttime]=GETDATE()
                WHERE
                    [Sl]=@Sl

                    ]]></tblActiveWorker_tblActiveWorker_SELECT>.Value
        End Get
    End Property

    Public Function tblActiveWorker_Update(ByVal Sl As Integer, ByVal Room As String) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblActiveWorker_tblActiveWorker_Update, conn)
        da.Parameters.AddWithValue("@Room", Room)
        da.Parameters.Add("@Sl", SqlDbType.Int).Value = Sl
        ret = da.ExecuteNonQuery
        Try
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret

    End Function

    Private ReadOnly Property tblActiveWorker_tblActiveWorker_Update_BookingID_workerID As String
        Get
            Return <tblActiveWorker_tblActiveWorker_SELECT><![CDATA[

                UPDATE
                    [tblActiveWorker]
                SET
                    [Room]=@Room ,[starttime]=GETDATE()
                WHERE
                    [WorkerID]=@WorkerID and [BookingID]=@BookingID

                    ]]></tblActiveWorker_tblActiveWorker_SELECT>.Value
        End Get
    End Property

    Public Function tblActiveWorker_Update_BookingID_workerID(ByVal WorkerID As Integer, ByVal BookingID As Integer, ByVal Room As String) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblActiveWorker_tblActiveWorker_Update_BookingID_workerID, conn)
        da.Parameters.AddWithValue("@Room", Room)
        da.Parameters.Add("@WorkerID", SqlDbType.Int).Value = WorkerID
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

    Private ReadOnly Property tblActiveWorker_tblActiveWorker_Update2 As String
        Get
            Return <tblActiveWorker_tblActiveWorker_SELECT><![CDATA[
                UPDATE
                    [tblActiveWorker] 
                SET
                    [Status]=@Status ,[StoppedTime]=@StoppedTime 
                 WHERE [Sl]=@Sl

                    ]]></tblActiveWorker_tblActiveWorker_SELECT>.Value
        End Get
    End Property

    Public Function tblActiveWorker_Update_STatus(ByVal Sl As Integer, ByVal Status As String) As Integer

        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""
        Dim objConn As clsConnection = New clsConnection

        Dim conn As SQLConnection = objConn.connect
        Dim da As New SqlCommand(tblActiveWorker_tblActiveWorker_Update2, conn)
        da.Parameters.AddWithValue("@Status", Status)
        da.Parameters.Add("@StoppedTime", SqlDbType.DateTime).Value = Now
        da.Parameters.Add("@Sl", SqlDbType.Int).Value = Sl
        ret = da.ExecuteNonQuery
        Try
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret
    End Function

    Private ReadOnly Property tblActiveWorker_tblActiveWorker_Update_By_BookingID As String
        Get
            Return <tblActiveWorker_tblActiveWorker_SELECT><![CDATA[
                UPDATE
                    [tblActiveWorker] 
                SET
                    [Status]=@Status,[StoppedTime]=@StoppedTime 
                 WHERE [BookingID]=@BookingID

                    ]]></tblActiveWorker_tblActiveWorker_SELECT>.Value
        End Get
    End Property

    Public Function tblActiveWorker_Update_By_BookingID(ByVal BookingID As Integer, ByVal Status As String) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblActiveWorker_tblActiveWorker_Update_By_BookingID, conn)
        da.Parameters.AddWithValue("@Status", Status)
        da.Parameters.Add("@StoppedTime", SqlDbType.DateTime).Value = Now
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

    Private ReadOnly Property tblActiveWorker_tblActiveWorker_Update_room_By_BookingID_WORKERID As String
        Get
            Return <tblActiveWorker_tblActiveWorker_SELECT><![CDATA[
                UPDATE
                    [tblActiveWorker] 
                SET
                    [Status]=@Status,[StoppedTime]=@StoppedTime 
                 WHERE [BookingID]=@BookingID and [WorkerId]=@WorkerID

                    ]]></tblActiveWorker_tblActiveWorker_SELECT>.Value
        End Get
    End Property

    Public Function tblActiveWorker_Update_room_By_BookingID_WorkerID(ByVal BookingID As Integer, ByVal WorkerID As Integer, ByVal Status As String) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblActiveWorker_tblActiveWorker_Update_room_By_BookingID_WORKERID, conn)
        da.Parameters.AddWithValue("@Status", Status)
        da.Parameters.Add("@StoppedTime", SqlDbType.DateTime).Value = Now
        da.Parameters.Add("@BookingID", SqlDbType.Int).Value = BookingID
        da.Parameters.Add("@WorkerId", SqlDbType.Int).Value = WorkerID
        ret = da.ExecuteNonQuery
        Try
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret
    End Function
    Private ReadOnly Property tblActiveWorker_tblActiveWorker_Update_CHANGE_WORKER As String
        Get
            Return <tblActiveWorker_tblActiveWorker_SELECT><![CDATA[
                UPDATE
                    [tblActiveWorker] 
                SET
                    [WorkerId]=@WorkerID1
                 WHERE [BookingID]=@BookingID and [WorkerId]=@WorkerID
                    ]]></tblActiveWorker_tblActiveWorker_SELECT>.Value
        End Get
    End Property
    Public Function tblActiveWorker_Update_CHANGE_WORKER(ByVal BookingID As Integer, ByVal WorkerID As Integer, ByVal NewWorkerID As Integer) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SqlConnection = objConn.connect
        Dim da As New SqlCommand(tblActiveWorker_tblActiveWorker_Update_CHANGE_WORKER, conn)
        da.Parameters.Add("@WorkerId1", SqlDbType.Int).Value = NewWorkerID
        da.Parameters.Add("@BookingID", SqlDbType.Int).Value = BookingID
        da.Parameters.Add("@WorkerId", SqlDbType.Int).Value = WorkerID
        ret = da.ExecuteNonQuery
        Try
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret
    End Function
    Private ReadOnly Property tblActiveWorker_tblActiveWorker_Update3 As String
        Get
            Return <tblActiveWorker_tblActiveWorker_SELECT><![CDATA[
                UPDATE
                    [tblActiveWorker] 
                SET
                    [Service]=[Service] + @Service 
                 WHERE [Sl]=@Sl
                    ]]></tblActiveWorker_tblActiveWorker_SELECT>.Value
        End Get
    End Property

    Public Function tblActiveWorker_Update_EXTENDSERVICE(ByVal Sl As Integer, ByVal Service As Integer) As Integer
        Dim ret As Integer = 0
        Dim SELECTSTRING As String = ""

        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblActiveWorker_tblActiveWorker_Update3, conn)
        da.Parameters.AddWithValue("@Service", Service)
        da.Parameters.Add("@Sl", SqlDbType.Int).Value = Sl
        ret = da.ExecuteNonQuery
        Try
            da.Dispose()
            conn.Close()
            conn.Dispose()
        Catch ex As Exception
        End Try
        Return ret
    End Function
    Function GetActiveBookingIDByRoom(_room As String) As Integer
        Dim _bookingId As Integer = 0
        Dim SELECTSTRING As String = ""
        SELECTSTRING = " AND GETDATE() BETWEEN DATEADD(Minute,-1,a.[starttime]) and @Date1 and a.[starttime] between @Date2 and @Date3 and a.[Room]<>'' and (a.[Status]='' OR a.[Status]='STARTED') and a.[room] in ('" & _room & "') Order by  a.Status desc, g.sl,DateAdd(Minute,c.serv1,a.starttime) desc"
        Dim ParamList As New List(Of SqlParameter)
        ParamList.Add(New SqlParameter("@Date1", Today.AddDays(1).AddSeconds(-1)))
        ParamList.Add(New SqlParameter("@Date2", Today.AddDays(-1000)))
        ParamList.Add(New SqlParameter("@Date3", Today.AddDays(1).AddSeconds(-1)))
        _bookingId = tblActiveWorker_Selection(0, SELECTSTRING, ParamList).Rows(0).Item("BookingId")
        Return _bookingId
    End Function

    Function GetActiveWorkerIDsByBookingID(_bookingId As Integer) As List(Of Integer)
        Dim RetList As New List(Of Integer)
        Dim SELECTSTRING As String = ""
        SELECTSTRING = " AND GETDATE() BETWEEN DATEADD(Minute,-1,a.[starttime]) and @Date1 and a.[starttime] between @Date2 and @Date3 and a.[Room]<>'' and (a.[Status]='' OR a.[Status]='STARTED') and a.[BookingId] in (" & _bookingId.ToString & ") Order by  a.Status desc, g.sl,DateAdd(Minute,c.serv1,a.starttime) desc"
        Dim ParamList As New List(Of SqlParameter)
        ParamList.Add(New SqlParameter("@Date1", Today.AddDays(1).AddSeconds(-1)))
        ParamList.Add(New SqlParameter("@Date2", Today.AddDays(-1000)))
        ParamList.Add(New SqlParameter("@Date3", Today.AddDays(1).AddSeconds(-1)))
        For Each dr As DataRow In tblActiveWorker_Selection(0, SELECTSTRING, ParamList).Rows
            RetList.Add(dr("WorkerID"))
        Next
        Return RetList
    End Function


    Function GetActiveBookingIDByWorkerID(_WorkerID As Integer) As Integer
        Dim _bookingId As Integer = 0
        Dim SELECTSTRING As String = ""
        SELECTSTRING = " AND GETDATE() BETWEEN DATEADD(Minute,-1,a.[starttime]) and @Date1 and a.[starttime] between @Date2 and @Date3 and a.[Room]<>'' and (a.[Status]='' OR a.[Status]='STARTED') and a.[WorkerID] in (" & _WorkerID & ") Order by  a.Status desc, g.sl,DateAdd(Minute,c.serv1,a.starttime) desc"
        Dim ParamList As New List(Of SqlParameter)
        ParamList.Add(New SqlParameter("@Date1", Today.AddDays(1).AddSeconds(-1)))
        ParamList.Add(New SqlParameter("@Date2", Today.AddDays(-1000)))
        ParamList.Add(New SqlParameter("@Date3", Today.AddDays(1).AddSeconds(-1)))
        _bookingId = tblActiveWorker_Selection(0, SELECTSTRING, ParamList).Rows(0).Item("BookingId")
        Return _bookingId
    End Function
End Class
