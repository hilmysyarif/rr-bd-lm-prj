Imports System.IO
Imports System.Drawing.Printing


Public Class clsReportPrint
    Private printFont As Font
    Private streamToPrint As StringReader
    ' The PrintPage event is raised for each page to be printed.
    Dim TextToPrint1 As List(Of String)

    Dim Pagec As Integer = 0

    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing
        Dim count As Integer = 0

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

        ' Iterate over the file, printing each line.
        While count < linesPerPage - 4
            line = streamToPrint.ReadLine()
            If line Is Nothing Then
                Exit While
            End If
            yPos = topMargin + count * printFont.GetHeight(ev.Graphics)
            ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, _
                yPos, New StringFormat())
            count += 1
        End While

        ' If more lines exist, print another page.
        If (line IsNot Nothing) Then
            ev.HasMorePages = True
        Else
            If TextToPrint1.Count - 1 > Pagec Then
                Pagec += 1
                streamToPrint = New StringReader(TextToPrint1(Pagec))
                ev.HasMorePages = True
            Else
                ev.HasMorePages = False
            End If
        End If
    End Sub
    Public Sub Printing2(ByVal PrinterName_ As String, ByVal TextToPrint As List(Of String), Optional ByVal DocName As String = "", Optional ByVal PaperName As String = "A4")
        Try
            Try
                TextToPrint1 = TextToPrint
                streamToPrint = New StringReader(TextToPrint1(0))
                 printFont = New Font("Courier New", 8)
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf pd_PrintPage
                Try
                    Dim printerformat As System.Drawing.Printing.PaperSize
                    Dim PrinterObj As New System.Drawing.Printing.PrinterSettings
                    PrinterObj.PrinterName = pd.DefaultPageSettings.PrinterSettings.PrinterName
                    For Each printerformat In PrinterObj.PaperSizes()
                        Try
                            If PaperName = printerformat.PaperName Then
                                pd.DefaultPageSettings.PaperSize = printerformat
                                Exit For
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    pd.DefaultPageSettings.Margins.Top = 3
                    pd.DefaultPageSettings.Margins.Left = 1
                    pd.DefaultPageSettings.Margins.Bottom = 1
                    pd.DefaultPageSettings.Margins.Right = 1
                    pd.DefaultPageSettings.Landscape = True
                    pd.PrinterSettings.PrinterName = PrinterName_
                Catch ex As Exception
                End Try
                pd.DocumentName = DocName
                pd.Print()
            Finally
                streamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Public Sub Printing3(ByVal PrinterName_ As String, ByVal TextToPrint As List(Of String), Optional ByVal DocName As String = "", Optional ByVal PaperName As String = "A4")
        Try
            Try
                TextToPrint1 = TextToPrint
                streamToPrint = New StringReader(TextToPrint1(0))
                printFont = New Font("Courier New", 7)
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf pd_PrintPage
                Try
                    Dim printerformat As System.Drawing.Printing.PaperSize
                    Dim PrinterObj As New System.Drawing.Printing.PrinterSettings
                    PrinterObj.PrinterName = pd.DefaultPageSettings.PrinterSettings.PrinterName
                    For Each printerformat In PrinterObj.PaperSizes()
                        Try
                            If PaperName = printerformat.PaperName Then
                                pd.DefaultPageSettings.PaperSize = printerformat
                                Exit For
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    pd.DefaultPageSettings.Margins.Top = 10
                    pd.DefaultPageSettings.Margins.Left = 10
                    pd.DefaultPageSettings.Margins.Bottom = 10
                    pd.DefaultPageSettings.Margins.Right = 10
                    pd.DefaultPageSettings.Landscape = True
                    pd.PrinterSettings.PrinterName = PrinterName_
                Catch ex As Exception
                End Try
                pd.DocumentName = DocName
                pd.Print()
            Finally
                streamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
