Imports System.Net.NetworkInformation

Public Class clsMAC_Address
    Public ValidNICs As New List(Of String) ' From {"000C2947CF2C", "000C29EF0208"}

    Function isValidNIC() As Boolean
        Dim ret As Boolean = False
        Dim cnt As Integer = 0
        For Each nic As String In ValidNICs
            If MACs.Contains(nic) Then
                cnt += 1
            End If
        Next
        ret = cnt > 0
        Return ret
    End Function

    Function MACs() As List(Of String)
        Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
        Dim l As New List(Of String)
        For Each n As NetworkInterface In nics
            If n.GetPhysicalAddress.ToString <> "" AndAlso Not l.Contains(n.GetPhysicalAddress.ToString) Then
                l.Add(n.GetPhysicalAddress.ToString)
            End If
        Next
        Return l
    End Function
End Class
