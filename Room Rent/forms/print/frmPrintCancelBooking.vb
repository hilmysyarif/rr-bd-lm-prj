Imports System.Drawing.Printing

Public Class frmPrintCancelBooking

    Private oStringFormat As StringFormat
    Dim MainFont As Font = Nothing
    Dim BrushColor As Brush = Nothing
    Dim printItems As List(Of PrintItem)
    Dim TicketNo1 As String = ""
    Dim room_ As String = ""
    Dim sp_t As String = ""
    Dim service_t As String = ""
    Dim vselectedServiceType As String = ""
    Dim datet_of As Date = Now
    Dim totalClient_ As Integer = 0
    Dim CancelAmount_ As Double = 0
    Dim width_p As Integer = 300
    Dim count As Integer = 0


    Structure PrintItem
        Dim value As String
        Dim location As Point
        Dim size As Point
        Dim font As Font
        Dim NewFormat As StringFormat
        Dim BrushColor As Brush
        Sub New(ByVal _value As String, ByVal _location As Point, ByVal _size As Point, ByVal _font As Font, ByVal _NewFormat As StringFormat, ByVal _BrushColor As Brush)
            value = _value
            location = _location
            size = _size
            font = _font
            NewFormat = _NewFormat
            BrushColor = _BrushColor
        End Sub
    End Structure


    Function SetValues() As Boolean

        MainFont = New Font("Courier New", 10, FontStyle.Regular)
        BrushColor = Brushes.Black
        printItems = New List(Of PrintItem)
        Try
            Dim topAdd As Integer = 0
            Dim heightCommon As Integer = 30

            Dim height_p As Integer = heightCommon
            printItems.Add(New PrintItem(MySettings.CompanyName, New Point(0, topAdd), New Point(width_p, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}, BrushColor))
            topAdd += height_p - 3

            height_p = heightCommon
            printItems.Add(New PrintItem(MySettings.CompanyAddress.Replace(vbNewLine, ", "), New Point(0, topAdd), New Point(width_p, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}, BrushColor))
            topAdd += height_p - 3

            height_p = heightCommon
            printItems.Add(New PrintItem("PH :" & MySettings.CompanyPhone, New Point(0, topAdd), New Point(width_p, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}, BrushColor))
            topAdd += height_p - 3

            height_p = heightCommon
            printItems.Add(New PrintItem("BOOKING/TICKET NO." & ": " & TicketNo1, New Point(20, topAdd), New Point(width_p - 40, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}, BrushColor))
            topAdd += height_p - 3

            height_p = heightCommon + 13
            printItems.Add(New PrintItem("DATE : " & datet_of.ToString("dd/MM/yyyy (ddd)") & "  Time : " & datet_of.ToString("hh:mm:ss tt"), New Point(20, topAdd), New Point(width_p - 40, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}, BrushColor))
            topAdd += height_p - 3


            Try
                Dim str As String = ""
                For Each workerName As String In sp_t.Split(",")
                    If workerName.Trim <> "" Then
                        If str = "" Then
                            height_p = heightCommon
                            printItems.Add(New PrintItem("SERVICE PROVIDER".PadRight(16, ". ") & ": " & workerName.Trim, New Point(20, topAdd), New Point(width_p - 40, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}, BrushColor))
                            topAdd += height_p - 3
                        Else
                            height_p = heightCommon
                            printItems.Add(New PrintItem(" ".PadRight(16, "  ") & ": " & workerName.Trim, New Point(20, topAdd), New Point(width_p - 40, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}, BrushColor))
                            topAdd += height_p - 3
                        End If
                        str += workerName.Trim
                    End If
                Next
            Catch ex As Exception
            End Try

            If totalClient_ > 1 Then
                height_p = heightCommon
                printItems.Add(New PrintItem("TOTAL CLIENT".PadRight(16, ". ") & ":  " & totalClient_.ToString, New Point(20, topAdd), New Point(width_p - 40, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}, BrushColor))
                topAdd += height_p - 3
            End If

            height_p = heightCommon
            printItems.Add(New PrintItem("ROOM".PadRight(16, ". ") & ": " & room_, New Point(20, topAdd), New Point(width_p - 40, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}, BrushColor))
            topAdd += height_p - 3

            height_p = heightCommon
            printItems.Add(New PrintItem("SERVICE".PadRight(16, ". ") & ": " & service_t & IIf(MySettings.SpecialServiceEnabled, " " & vselectedServiceType, ""), New Point(20, topAdd), New Point(width_p - 40, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}, BrushColor))
            topAdd += height_p - 3

            height_p = heightCommon
            printItems.Add(New PrintItem("CANCELLATION FEE".PadRight(16, ". ") & ": " & currency & CancelAmount_.ToString("0.00"), New Point(20, topAdd), New Point(width_p - 40, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}, BrushColor))
            topAdd += height_p - 3

            height_p = heightCommon
            printItems.Add(New PrintItem("CANCELLED", New Point(20, topAdd), New Point(width_p - 40, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}, BrushColor))
            topAdd += height_p - 3

            height_p = 5
            printItems.Add(New PrintItem(".................................................", New Point(0, topAdd - 5), New Point(width_p, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}, BrushColor))
            topAdd += height_p

            height_p = heightCommon
            printItems.Add(New PrintItem("WELCOME TO " & MySettings.CompanyName, New Point(0, topAdd), New Point(width_p, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}, BrushColor))
            topAdd += height_p

            If MySettings.MemoFooter1.Trim <> "" Then
                height_p = heightCommon
                printItems.Add(New PrintItem(MySettings.MemoFooter1, New Point(0, topAdd), New Point(width_p, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}, BrushColor))
                topAdd += height_p - 3
            End If

            If MySettings.MemoFooter2.Trim <> "" Then
                height_p = heightCommon
                printItems.Add(New PrintItem(MySettings.MemoFooter2, New Point(0, topAdd), New Point(width_p, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}, BrushColor))
                topAdd += height_p - 3
            End If

            If MySettings.MemoFooter3.Trim <> "" Then
                height_p = heightCommon
                printItems.Add(New PrintItem(MySettings.MemoFooter3, New Point(0, topAdd), New Point(width_p, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Near}, BrushColor))
                topAdd += height_p - 3
            End If

            topAdd += 350
            height_p = heightCommon
            printItems.Add(New PrintItem("*****", New Point(0, topAdd), New Point(width_p, height_p), MainFont, New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Far}, BrushColor))
            topAdd += height_p - 3

        Catch ex As Exception
        End Try
        Return True
    End Function

    Public Sub Print(ByVal CashMemoNumber As String, _
                             ByVal dateofbook As Date, _
                             ByVal service_time As String, _
                             ByVal room As String, ByVal totalClient As Integer, ByVal sp As String, _
                             ByVal Reportprinter2 As String, _
                             ByVal isPreview As Boolean, _
                             ByVal ServiceType As String, _
                             ByVal CancelAmount As Double)
        'If MsgBox("Are you sure?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, "Info") = MsgBoxResult.Yes Then
        Try
            TicketNo1 = CashMemoNumber
            datet_of = dateofbook
            service_t = service_time
            room_ = room
            sp_t = sp
            totalClient_ = totalClient
            CancelAmount_ = CancelAmount
            vselectedServiceType = ServiceType
            SetValues()
            If Reportprinter2 <> "" Then
                PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName = Reportprinter2
            End If

            Dim printerformat As System.Drawing.Printing.PaperSize
            Dim PrinterObj As New System.Drawing.Printing.PrinterSettings
            PrinterObj.PrinterName = PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName
            For Each printerformat In PrinterObj.PaperSizes()
                Try
                    If "Envelope" = printerformat.PaperName Then
                        PrintDocument1.DefaultPageSettings.PaperSize = printerformat
                        Exit For
                    End If
                Catch ex As Exception
                End Try
            Next

            PrintDocument1.DefaultPageSettings.Landscape = False
            PrintDocument1.DefaultPageSettings.Margins.Top = 15
            PrintDocument1.DefaultPageSettings.Margins.Left = 30
            PrintDocument1.DefaultPageSettings.Margins.Bottom = 30
            PrintDocument1.DefaultPageSettings.Margins.Right = 30

            Me.PageSetupDialog1.PageSettings = PrintDocument1.DefaultPageSettings
            Me.PageSetupDialog1.PageSettings = PrintDocument1.DefaultPageSettings
            Me.PageSetupDialog1.PrinterSettings = PrintDocument1.PrinterSettings
            If isPreview Then
                Me.PrintPreviewControl1.Document = Me.PrintDocument1
                Me.WindowState = FormWindowState.Maximized
                Me.ShowDialog()
            Else
                PrintDocument1.Print()
            End If


        Catch ex As Exception
        End Try

    End Sub

    Sub clear()
        oStringFormat = Nothing
    End Sub
    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        oStringFormat = New StringFormat
        oStringFormat.Alignment = StringAlignment.Near
        oStringFormat.LineAlignment = StringAlignment.Far
        oStringFormat.Trimming = StringTrimming.EllipsisCharacter


    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        For Each dr As PrintItem In printItems
            e.Graphics.DrawString(dr.value, dr.font, dr.BrushColor, New Rectangle(dr.location.X, dr.location.Y, dr.size.X, dr.size.Y), dr.NewFormat)
        Next
        e.HasMorePages = False
    End Sub

    Private Sub Slider1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Slider1.ValueChanged
        PrintPreviewControl1.Zoom = Me.Slider1.Value / 100
    End Sub

    Private Sub ButtonX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonX1.Click

        PrintDialog1.AllowSomePages = False
        PrintDialog1.UseEXDialog = True
        PrintDialog1.AllowSelection = False
        'PrintDialog1. = False
        PrintDialog1.PrinterSettings = Me.PrintDocument1.DefaultPageSettings.PrinterSettings()

        'c = PrintDialog1.PrinterSettings.MaximumCopies
        If Me.PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.PrintDocument1.DefaultPageSettings.PrinterSettings = PrintDialog1.PrinterSettings ' Printing.PrintRange.SomePages
            PrintDocument1.DocumentName = "Ticket No : " & TicketNo1.ToString & " Printed on - " & Format(Now, "dd/MM/yy HH:mm:ss tt")
            Me.PrintDocument1.Print()
        End If
    End Sub


    Private Sub ButtonX6_Click(ByVal sender As System.Object, ByVal et As System.EventArgs) Handles ButtonX6.Click
        If Me.PageSetupDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PrintDocument1.DefaultPageSettings.Landscape = PageSetupDialog1.PageSettings.Landscape
            PrintDocument1.DefaultPageSettings.PaperSize = PageSetupDialog1.PageSettings.PaperSize
            PrintDocument1.DefaultPageSettings.Margins.Top = PageSetupDialog1.PageSettings.Margins.Top '+ 13 + m1
            PrintDocument1.DefaultPageSettings.Margins.Left = PageSetupDialog1.PageSettings.Margins.Left
            PrintDocument1.DefaultPageSettings.Margins.Bottom = PageSetupDialog1.PageSettings.Margins.Bottom '+ 5 + m2
            PrintDocument1.DefaultPageSettings.Margins.Right = PageSetupDialog1.PageSettings.Margins.Right
            PrintDocument1.DefaultPageSettings.PrinterSettings.PrinterName = PageSetupDialog1.PrinterSettings.PrinterName
            clear()
            Me.PrintPreviewControl1.InvalidatePreview()

        End If
    End Sub


    Private Sub frmPrintCashMemo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TopMost = IsAllTopMostForm
        'PrintPreview(0, "")
        Me.PrintPreviewControl1.Document = Me.PrintDocument1
    End Sub
End Class