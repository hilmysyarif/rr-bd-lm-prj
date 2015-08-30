Public Class aa_cyclotest
    Dim cnt As Integer = 0
    Sub Test(i As Integer)
        If cnt > 100 Then
            Exit Sub
        End If
        cnt += 1
        Select Case i
            Case 0
                Test(i * Rnd())
            Case 1
                Test(i * Rnd())
            Case 2
                Test(i * Rnd())
            Case 3
                Test(i * Rnd())
            Case 4
                Test(i * Rnd())
            Case 5
                Test(i * Rnd())
            Case 6
                Test(i * Rnd())
            Case Else
                Test(i * Rnd())
        End Select
    End Sub
End Class
