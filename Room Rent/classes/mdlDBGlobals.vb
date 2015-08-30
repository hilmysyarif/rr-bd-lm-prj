Public Module mdlDBGlobals
    Public MySettings As cls_tblSettings = Nothing
    Public DcFolder As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "DcFiles")

    Public Function LoadWorkers(ByVal lst As ListView, ByVal tp As BookingType)
        lst.Items.Clear()
        Dim objBooking As New cls_Temp_tblBookings
        Dim SELECTSTRING As String = ""
        Dim lstp As New List(Of SQLParameter)
        Select Case tp
            Case BookingType.ALL
            Case BookingType.ACTIVE_PREBOOKING
                SELECTSTRING = IIf(tp = BookingType.ALL, "", " GETDATE() BETWEEN [Scheduledate] and DATEADD(Minute,[Service],[Scheduledate])")
            Case BookingType.QUEUE_PREBOOKING
                lstp.Add(New SQLParameter("d1", SqlDbType.DateTime) With {.Value = Today})
                lstp.Add(New SQLParameter("d1", SqlDbType.DateTime) With {.Value = Today.AddDays(1).AddSeconds(-1)})
                SELECTSTRING = IIf(tp = BookingType.ALL, "", " [Scheduledate] BETWEEN @d1 and @d2")
            Case BookingType.STOPPED
                SELECTSTRING = IIf(tp = BookingType.ALL, "", " [Status]='" + tp.ToString + "'")
            Case BookingType.COMPLETED
                SELECTSTRING = IIf(tp = BookingType.ALL, "", " [Status]='" + tp.ToString + "'")
        End Select
        Dim dt As DataTable = objBooking.Selection(cls_Temp_tblBookings.SelectionType.ServiceProvider, SELECTSTRING, lstp)
        For i = 0 To dt.Rows.Count - 1
            Dim drItem As System.Data.DataRow = dt.Rows(i)
            Dim li As New ListViewItem
            li.Text = drItem("WorkerName").ToString
            li.Tag = drItem("WorkerID").ToString
            lst.Items.Add(li)
        Next
        Return Nothing
    End Function

    Public Enum BookingType
        ALL
        QUEUE_PREBOOKING
        ACTIVE_PREBOOKING
        STOPPED
        COMPLETED
        QUEUE_HOME_PAGE_MULTILINE
        QUEUE_HOME_PAGE_MULTILINE_TODAY_12HRS
    End Enum
    Public Function LoadBookings(ByVal dg As DataGridView, Optional ByVal tp As BookingType = BookingType.ALL)
        dg.Rows.Clear()
        Dim objPreBookings As New cls_Temp_tblBookings
        Dim SELECTSTRING As String = ""
        Dim lst As New List(Of SQLParameter)
        Select Case tp
            Case BookingType.ALL
                SELECTSTRING = ""
            Case BookingType.ACTIVE_PREBOOKING
                SELECTSTRING = IIf(tp = BookingType.ALL, "", " GETDATE() BETWEEN [Scheduledate] and DATEADD(Minute,[Service],[Scheduledate]) AND BookingType='PREBOOKING' and a.[room] not in (" & RoomVisibleQuerySelection & ")")

            Case BookingType.QUEUE_PREBOOKING
                lst.Add(New SqlParameter("d2", SqlDbType.DateTime) With {.Value = Now.AddHours(12).AddSeconds(-1)})
                SELECTSTRING = IIf(tp = BookingType.ALL, "", " [Scheduledate]> @d2 AND BookingType='PREBOOKING' and a.[room] not in (" & RoomVisibleQuerySelection & ")")

            Case BookingType.STOPPED
                SELECTSTRING = IIf(tp = BookingType.ALL, "", " [Status]='" + tp.ToString + "' and a.[room] not in (" & RoomVisibleQuerySelection & ")")
            Case BookingType.COMPLETED
                SELECTSTRING = IIf(tp = BookingType.ALL, "", " [Status]='" + tp.ToString + "' and a.[room] not in (" & RoomVisibleQuerySelection & ")")
            Case BookingType.QUEUE_HOME_PAGE_MULTILINE
                lst.Add(New SQLParameter("d1", SqlDbType.DateTime) With {.Value = Now.AddMinutes(-1)})
                lst.Add(New SQLParameter("d2", SqlDbType.DateTime) With {.Value = Today.AddDays(1000).AddSeconds(-1)})
                SELECTSTRING = IIf(tp = BookingType.ALL, "", " [Scheduledate] BETWEEN @d1 and @d2 and [CustomerName]<>'' AND BookingType='PREBOOKING' and a.[room] not in (" & RoomVisibleQuerySelection & ") Order by [Scheduledate]")

            Case BookingType.QUEUE_HOME_PAGE_MULTILINE_TODAY_12HRS
                lst.Add(New SQLParameter("d1", SqlDbType.DateTime) With {.Value = Now.AddMinutes(-1)})
                lst.Add(New SQLParameter("d2", SqlDbType.DateTime) With {.Value = Now.AddHours(12)})
                SELECTSTRING = IIf(tp = BookingType.ALL, "", " [Scheduledate] BETWEEN @d1 and @d2 and [CustomerName]<>'' AND BookingType='PREBOOKING' and a.[room] not in (" & RoomVisibleQuerySelection & ") Order by [Scheduledate]")
        End Select
        Dim dt As DataTable = objPreBookings.Selection(cls_Temp_tblBookings.SelectionType.All_View, SELECTSTRING, lst)
        For i = 0 To dt.Rows.Count - 1
            Dim drItem As System.Data.DataRow = dt.Rows(i)
            If tp = BookingType.QUEUE_PREBOOKING Or tp = BookingType.QUEUE_HOME_PAGE_MULTILINE Or tp = BookingType.QUEUE_HOME_PAGE_MULTILINE_TODAY_12HRS Then
                dg.Rows.Add("", _
                      drItem("BookingID"), _
                    IIf(dg.Columns(2).HeaderText.Trim <> "SP", drItem("ServiceProvider").ToString + " " + vbNewLine + drItem("MobileNo").ToString, drItem("ServiceProvider").ToString), _
                      CDate(drItem("Scheduledate")).ToString("dd MMM HH:mm") + " " + vbNewLine + drItem("Service").ToString + " Mins", _
                      drItem("CustomerName").ToString + " " + vbNewLine + drItem("Phone").ToString, _
                      drItem("Worker_status").ToString + " " + vbNewLine + drItem("Client_status").ToString, _
                      IIf(drItem("Worker_status").ToString = "", "PENDING", drItem("Worker_status").ToString), _
                      IIf(drItem("Client_status").ToString = "", "PENDING", drItem("Client_status").ToString), _
                      drItem("Scheduledate"), _
                      drItem("Service").ToString + " Mins", _
                      drItem("CustomerName"), _
                      drItem("Phone"), _
                      drItem("ServiceProvider").ToString, _
                      drItem("MobileNo").ToString)
            Else
                dg.Rows.Add(drItem("ServiceProvider"), _
                      drItem("Room"), _
                      drItem("Service").ToString + " Mins", _
                      drItem("Service").ToString + " Mins", _
                      drItem("Scheduledate"), _
                      drItem("DoorName"), _
                      drItem("DoorCharge"), _
                      drItem("BookingID"))
                If dg.ColumnCount = 9 Then
                    dg.Rows(dg.Rows.Count - 1).Cells(8).Value = drItem("Status")
                End If
            End If
            dg.Rows(dg.Rows.Count - 1).DefaultCellStyle.BackColor = QueuedPreBooking
            If Not tp = BookingType.QUEUE_HOME_PAGE_MULTILINE Then
                dg.Rows(dg.Rows.Count - 1).Height = 45
            End If
        Next
        Return Nothing
    End Function

    Public Sub FillComBoBox(ByVal cmb As ComboBox, ByVal tablename As String, ByVal display As String, ByVal value As String, Optional ByVal selectstring As String = "")
        Dim objConn As New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLDataAdapter(" Select [" & display & "],[" & value & "] from [" & tablename & "] Where 1=1 " & IIf(selectstring.Trim <> "", IIf(selectstring.StartsWith("AND"), selectstring, " AND " & selectstring), "") & " Order by [" & display & "]", conn)
        Dim dt As New DataTable
        da.Fill(dt)
        Dim dr As DataRow = dt.NewRow
        dr(0) = "-Select-"
        dr(1) = "0"
        dt.Rows.InsertAt(dr, 0)
        cmb.DisplayMember = display
        cmb.ValueMember = value
        cmb.DataSource = dt
    End Sub

    Public Function ExecuteAdapter(ByVal Query As String, Optional ByVal Parameters As List(Of SqlParameter) = Nothing, Optional ByRef conn As SqlConnection = Nothing) As DataTable
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SQLCommand("", conn)
        comSelect.CommandText = Query
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



    Public Function ExecuteSQL_Scalar(ByVal Query As String, Optional ByVal Parameters As List(Of SqlParameter) = Nothing, Optional ByRef conn As SqlConnection = Nothing) As Object
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SqlCommand("", conn)
        comSelect.CommandText = Query
        If Parameters IsNot Nothing Then
            comSelect.Parameters.AddRange(Parameters.ToArray)
        End If

        Dim dtSelect As Object = Nothing
        Try
            dtSelect = comSelect.ExecuteScalar
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            dtSelect.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        Return dtSelect
    End Function



    Public Function ExecuteSQL_Query(ByVal Query As String, Optional ByVal Parameters As List(Of SqlParameter) = Nothing, Optional ByRef conn As SqlConnection = Nothing) As Object
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comSelect As New SqlCommand("", conn)
        comSelect.CommandText = Query
        If Parameters IsNot Nothing Then
            comSelect.Parameters.AddRange(Parameters.ToArray)
        End If

        Dim dtSelect As Object = Nothing
        Try
            dtSelect = comSelect.ExecuteNonQuery
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            dtSelect.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        Return dtSelect
    End Function

    Function MyShift() As String 
        Select Case MyShiftType()
            Case cls_tblLookUp.PriceType.DAY
                MyShift = "DAY SHIFT"
            Case cls_tblLookUp.PriceType.NIGHT
                MyShift = "NIGHT SHIFT"
            Case cls_tblLookUp.PriceType.EVENING
                MyShift = "EVENING SHIFT"
            Case Else
                MyShift = "DAY SHIFT"
        End Select
    End Function
    Function MyShiftDayPrice() As String
        Dim PriceTyp As cls_tblLookUp.PriceType = MyShiftType()
        If MySettings.OtherSettings.DayPrice Then
            PriceTyp = cls_tblLookUp.PriceType.NIGHT
        End If
        Select Case PriceTyp
            Case cls_tblLookUp.PriceType.DAY
                MyShiftDayPrice = "DAY SHIFT"
            Case cls_tblLookUp.PriceType.NIGHT
                MyShiftDayPrice = "NIGHT SHIFT"
            Case cls_tblLookUp.PriceType.EVENING
                MyShiftDayPrice = "EVENING SHIFT"
            Case Else
                MyShiftDayPrice = "DAY SHIFT"
        End Select
    End Function

    Function MyShiftType() As cls_tblLookUp.PriceType

        Try
            'Calulate Day time from Settings
            Dim day_start As Date = Today.AddHours(Val(MySettings.Day_Start.Split(":")(0))).AddMinutes(Val(MySettings.Day_Start.Split(":")(1)))
            Dim day_end As Date = Today.AddHours(Val(MySettings.Day_End.Split(":")(0))).AddMinutes(Val(MySettings.Day_End.Split(":")(1)))

            'Calculate day time in case of Start time greater than end time
            If day_end < day_start Then
                If day_start < Now Then
                    day_end = day_end.AddDays(1)
                Else
                    day_start = day_start.AddDays(-1)
                End If
            End If

            'Calulate evening time from Settings
            Dim eve_start As Date = Today.AddHours(Val(MySettings.Eve_Start.Split(":")(0))).AddMinutes(Val(MySettings.Eve_Start.Split(":")(1)))
            Dim eve_end As Date = Today.AddHours(Val(MySettings.Eve_End.Split(":")(0))).AddMinutes(Val(MySettings.Eve_End.Split(":")(1)))

            'Calculate evening time in case of Start time greater than end time
            If eve_end < eve_start Then
                If eve_start < Now Then
                    eve_end = eve_end.AddDays(1)
                Else
                    eve_start = eve_start.AddDays(-1)
                End If
            End If

            If Now >= day_start And Now <= day_end Then
                MyShiftType = cls_tblLookUp.PriceType.DAY
            ElseIf MySettings.Shifts_3_enabled AndAlso Now >= eve_start And Now <= eve_end Then
                MyShiftType = cls_tblLookUp.PriceType.EVENING
            Else
                MyShiftType = cls_tblLookUp.PriceType.NIGHT
            End If
        Catch ex As Exception
            MyShiftType = cls_tblLookUp.PriceType.DAY
        End Try
    End Function

End Module
