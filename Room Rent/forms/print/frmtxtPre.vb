Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports System.Drawing.FontFamily

Public Class frmtxtPre

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fileExists As Boolean
        filePath = My.Application.Info.DirectoryPath & "\db\Test.txt"
        fileExists = My.Computer.FileSystem.FileExists(filePath)
        If fileExists Then
            My.Computer.FileSystem.DeleteFile(filePath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End If
        My.Computer.FileSystem.WriteAllText(filePath, String.Empty, False)
        My.Computer.FileSystem.WriteAllText(filePath, txtMemo.Text, True)
        filePath = filePath
        Printing()
        End Sub

    Private printFont As Font
    Private streamToPrint As StreamReader
    Private Shared filePath As String

    ' The PrintPage event is raised for each page to be printed.
    Private Sub pd_PrintPage(ByVal sender As Object, ByVal ev As PrintPageEventArgs)
        Dim linesPerPage As Single = 0
        Dim yPos As Single = 0
        Dim count As Integer = 0
        Dim leftMargin As Single = ev.MarginBounds.Left
        Dim topMargin As Single = ev.MarginBounds.Top
        Dim line As String = Nothing

        ' Calculate the number of lines per page.
        linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics)

        ' Iterate over the file, printing each line.
        While count < linesPerPage
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
            ev.HasMorePages = False
        End If
    End Sub

    ' Print the file.
    Public Sub Printing()
        Try
            streamToPrint = New StreamReader(filePath)
            Try
                If p_page = "3 Inch" Then
                    'printFont = New Font("Fixedsys", 8)
                    'printFont = New Font("Fixedsys Excelsior 3.01", 8)
                    'printFont = New Font("Fixedsys Excelsior 3.01", 8)
                    'printFont = New Font("Fixedsys Excelsior 3.01", 8)

                    ' printFont = New Font("Lucida Console", 8)
                    Try
                        ' printFont = New Font("Fixedsys Neo+", 10)
                        printFont = New Font(p_font, p_s3)

                    Catch ex As Exception
                        printFont = New Font("Lucida Console", 8)

                    End Try
                Else
                    'printFont = New Font("Fixedsys", 10)
                    'printFont = New Font("Fixedsys Excelsior 3.01", 10)
                    'printFont = New Font("Fixedsys Excelsior 3.01", 10)
                    'printFont = New Font("Fixedsys Excelsior 3.01", 10)
                    'printFont = New Font("Fixedsys Excelsior 3.01", 10)
                    'printFont = New Font("Lucida Console", 10)
                    Try
                        printFont = New Font(p_font, p_s4)
                    Catch ex As Exception
                        printFont = New Font("Lucida Console", 10)
                    End Try
                    '     printFont = New Font("kroeger 06_56", 10)
                End If
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf pd_PrintPage
                ' Print the document.
                Try
                    pd.DefaultPageSettings.Margins.Top = 3
                    pd.DefaultPageSettings.Margins.Left = 1
                    pd.DefaultPageSettings.Margins.Bottom = 1
                    pd.DefaultPageSettings.Margins.Right = 1
                    pd.PrinterSettings.PrinterName = MySettings.ReceiptPrinterName
                Catch ex As Exception
                End Try
                pd.Print()
            Finally
                streamToPrint.Close()
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub 'Printing    

    Private Sub frmtxtPre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If p_page = "3 Inch" Then
            'Me.txtMemo.Font = New System.Drawing.Font("Fixedsys", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMemo.Font = New System.Drawing.Font("Lucida Console", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Else
            'Me.txtMemo.Font = New System.Drawing.Font("Fixedsys", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMemo.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            '  Me.txtMemo.Font = New System.Drawing.Font("kroeger 06_56", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            Me.txtMemo.Font = New System.Drawing.Font(ComboBox1.Text, 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim fileExists As Boolean
        filePath = My.Application.Info.DirectoryPath & "\db\Test.txt"
        fileExists = My.Computer.FileSystem.FileExists(filePath)
        If fileExists Then
            My.Computer.FileSystem.DeleteFile(filePath, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        End If
        My.Computer.FileSystem.WriteAllText(filePath, String.Empty, False)
        My.Computer.FileSystem.WriteAllText(filePath, txtMemo.Text, True)
        Dim psi As New ProcessStartInfo

        psi.UseShellExecute = True

        psi.Verb = "print"

        psi.WindowStyle = ProcessWindowStyle.Hidden

        psi.Arguments = MySettings.ReceiptPrinterName
        ' psi.
        psi.FileName = filePath ' Here specify a document to be printed
        Process.Start(psi)

    End Sub
End Class