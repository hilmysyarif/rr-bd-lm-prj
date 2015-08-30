Imports System.Runtime.InteropServices
Imports System.IO.Ports

Module mdlprint
    Public Class RawPrinter
        ' ----- Define the data type that supplies basic print job information to the spooler.
        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
        Public Structure DOCINFO
            <MarshalAs(UnmanagedType.LPWStr)> _
            Public pDocName As String
            <MarshalAs(UnmanagedType.LPWStr)> _
            Public pOutputFile As String
            <MarshalAs(UnmanagedType.LPWStr)> _
            Public pDataType As String
        End Structure

        ' ----- Define interfaces to the functions supplied in the DLL.
        <DllImport("winspool.drv", EntryPoint:="OpenPrinterW", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function OpenPrinter(ByVal printerName As String, ByRef hPrinter As IntPtr, ByVal printerDefaults As Integer) As Boolean
        End Function

        <DllImport("winspool.drv", EntryPoint:="ClosePrinter", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
        End Function

        <DllImport("winspool.drv", EntryPoint:="StartDocPrinterW", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Integer, ByRef documentInfo As DOCINFO) As Boolean
        End Function

        <DllImport("winspool.drv", EntryPoint:="EndDocPrinter", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
        End Function

        <DllImport("winspool.drv", EntryPoint:="StartPagePrinter", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
        End Function

        <DllImport("winspool.drv", EntryPoint:="EndPagePrinter", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
        End Function

        <DllImport("winspool.drv", EntryPoint:="WritePrinter", SetLastError:=True, CharSet:=CharSet.Unicode, ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal buffer As IntPtr, ByVal bufferLength As Integer, ByRef bytesWritten As Integer) As Boolean
        End Function

        Public Shared Function PrintRaw(ByVal printerName As String, ByVal origString As String) As Boolean
            ' ----- Send a string of  raw data to  the printer.
            Dim hPrinter As IntPtr
            Dim spoolData As New DOCINFO
            Dim dataToSend As IntPtr
            Dim dataSize As Integer
            Dim bytesWritten As Integer

            ' ----- The internal format of a .NET String is just
            '       different enough from what the printer expects
            '       that there will be a problem if we send it
            '       directly. Convert it to ANSI format before
            '       sending.
            dataSize = origString.Length()
            dataToSend = Marshal.StringToCoTaskMemAnsi(origString)

            ' ----- Prepare information for the spooler.
            spoolData.pDocName = "OpenDrawer" ' class='highlight'
            spoolData.pDataType = "RAW"

            Try
                ' ----- Open a channel to  the printer or spooler.
                Call OpenPrinter(printerName, hPrinter, 0)

                ' ----- Start a new document and Section 1.1.
                Call StartDocPrinter(hPrinter, 1, spoolData)
                Call StartPagePrinter(hPrinter)

                ' ----- Send the data to the printer.
                Call WritePrinter(hPrinter, dataToSend, _
                   dataSize, bytesWritten)

                ' ----- Close everything that we opened.
                EndPagePrinter(hPrinter)
                EndDocPrinter(hPrinter)
                ClosePrinter(hPrinter)
                PrintRaw = True
            Catch ex As Exception
                MsgBox("Error occurred: " & ex.ToString)
                PrintRaw = False
            Finally
                ' ----- Get rid of the special ANSI version.
                Marshal.FreeCoTaskMem(dataToSend)
            End Try
        End Function
    End Class
    Public Sub OpenCashDrawer2()
        'Modify DrawerCode to your receipt printer open drawer code
        Dim DrawerCode As String = Chr(27) & Chr(112) & Chr(48) & Chr(64) & Chr(64)
        'Modify PrinterName to your receipt printer name
        Dim PrinterName As String = "Your receipt printer name"
        If MyLocalSettings.ReceiptPrinter = "" Then
            Dim frm As New PrintDialog
            frm.AllowSelection = False
            frm.AllowPrintToFile = False
            frm.AllowSomePages = False
            frm.AllowSomePages = False
            PrinterName = frm.PrinterSettings.PrinterName
        Else
            PrinterName = MyLocalSettings.ReceiptPrinter
        End If

        RawPrinter.PrintRaw(PrinterName, DrawerCode)
    End Sub


    'WithEvents Port As SerialPort = _
    '          New SerialPort("COM1", 9600, Parity.None, 8, StopBits.One)


    Public Sub OpenCashDrawer()
        Dim Port As SerialPort
        Try
            Port = New SerialPort(MyLocalSettings.CashComPort, 9600, Parity.None, 8, StopBits.One)
            Port.Open()
            Port.Write("0000000000!%")
            Port.Close()
            ' MsgBox("Done")
        Catch ex As Exception
            MsgBox("Not Done")
        End Try
        Try
            Port.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub port_DataReceived(ByVal sender As Object, ByVal e As  _
    '  System.IO.Ports.SerialDataReceivedEventArgs) Handles port.DataReceived
    '    'TextBox1.Text = (port.ReadTo("!%"))
    '    'If port.ReadExisting.Length = 0 Then
    '    '    ListBox1.Items.Add(TextBox1.Text)
    '    '    TextBox1.Text = ""
    '    'End If
    'End Sub



    'Private Sub OpenCashDrawer()

    '    Dim intFileNo As Integer = FreeFile()


    '    'Use this code if you are using LPT Port
    '    FileOpen(1, "c:\escapes.txt", OpenMode.Output)

    '    PrintLine(1, Chr(27) & "p" & Chr(0) & Chr(25) & Chr(250))
    '    FileClose(1)


    '    Shell("print /d:lpt1 c:\escapes.txt", vbNormalFocus)
    '    'Use this code if you are using COM Port
    '    FileOpen(1, AppDomain.CurrentDomain.BaseDirectory & "open.txt", OpenMode.Output)
    '    PrintLine(1, Chr(27) & Chr(112) & Chr(0) & Chr(25) & Chr(250))
    '    FileClose(1)
    '    Shell("print /d:com1 open.txt", AppWinStyle.Hide)

    'End Sub


End Module