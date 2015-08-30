'Class Version : 1.0.0.2
'Created Dated : 14/01/2015
'Author        : Bidyut Das

Imports System.Data.SqlClient
Imports System.IO
Public Class cls_Temp_tblBillItems
Inherits Database_Table_code_class_tblBillItems

    Enum SelectionType
        All = 0
        Report = 1
    End Enum

    Public ReadOnly Property tblBillItems_select_report
        Get
            Return <tblBillItems_select><![CDATA[
SELECT 
      b.[ItemID],
      b.[BillID],
      b.[ProductId],
      c.ProductName,
      c.CodeName,
      b.[Qty],
      b.[Price],
      b.[Subtotal],
      a.BillDate, d.PaymentMode 
FROM 
tblBill a 
left outer join [tblBillItems] b on a.BillID = b.BillID 
left outer join tblProducts c on b.ProductId = c.ProductID 
left outer join tblPayment d on a.BillID = d.Transc_ID and d.Transac_Type ='MERCHANDISE_SALE'

    WHERE c.ProductID is not null and d.TOTAIL_PAID is not null
]]></tblBillItems_select>.Value
        End Get
    End Property


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
                comSelection.CommandText = tblBillItems_Select & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")
            Case SelectionType.Report
                comSelection.CommandText = tblBillItems_select_report & IIf(_SelectString <> "", IIf(_SelectString.Trim.StartsWith("AND"), _SelectString, " AND " & _SelectString), "")

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

End Class