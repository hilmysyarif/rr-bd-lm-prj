'Class Version : 1.0.0.2
'Created Dated : 14/01/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Public Class cls_Temp_tblPayment
Inherits Database_Table_code_class_tblPayment

    Enum SelectionType
        All = 0
    End Enum
    Function Selection(Optional ByVal _selection_type As SelectionType = SelectionType.All, Optional ByVal _SelectString As String = "", Optional ByVal _params As List(Of SqlParameter) = Nothing, Optional ByVal _conn As SqlConnection = Nothing, Optional ByVal _transac As SqlTransaction = Nothing) As DataTable
        Dim dt As New DataTable
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

        Select Case _selection_type
            Case SelectionType.All
                comSelection.CommandText = tblPayment_Select & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

        End Select

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

        Return dt
    End Function

    Private ReadOnly Property tblBookingPayments_DELETE_q_2 As String
        Get
            Return <tblBookingPayments_SELECT><![CDATA[
                DELETE FROM
                    [tblPayment] 
                WHERE 1=1
                    ]]></tblBookingPayments_SELECT>.Value
        End Get
    End Property

    Public Function tblBookingPayments_DELETE_2(ByVal SelectString As String, Optional ByVal Parameters As List(Of SqlParameter) = Nothing) As Integer
        Dim ret As Integer = 0
        Dim objConn As clsConnection = New clsConnection
        Dim conn As SQLConnection = objConn.connect
        Dim da As New SQLCommand(tblBookingPayments_DELETE_q_2 & IIf(SelectString.Trim <> "", IIf(SelectString.ToUpper.Trim.StartsWith("AND"), " ", " AND ") & SelectString, ""), conn)
        If Parameters IsNot Nothing Then
            da.Parameters.AddRange(Parameters.ToArray)
        End If
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