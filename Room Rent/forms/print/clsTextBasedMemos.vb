Imports System.IO
Imports System.Drawing.Printing

Public Class clsTextBasedMemos
    Enum memotype
        INSTANT ' INSTANT- Print Door Charge 
        BOOKING 
    End Enum
    Function PrintMemo(ByVal BookingID As String, _
                            ByVal WorkerNames As String, _
                             ByVal service As String, _
                             ByVal room As String, _
                             ByVal door As String, _
                             ByVal doorch As Double, _
                             ByVal amount As Double, _
                             ByVal currency As String, _
                             ByVal paymode As String, _
                             ByVal tip As Double, _
                             ByVal cashout As Double, _
                             ByVal surcharge As Double, _
                             ByVal voucher As Double, _
                             ByVal cash As Double, _
                             ByVal card As Double, _
                             ByVal Reportprinter2 As String, _
                             ByVal shift_fee As Double, _
                             ByVal type As memotype, _
                             ByVal isPreview As Boolean) As String
        Dim OutPutString As String = ""
        Try
            Dim topAdd As Integer = 0
            'Middle
            OutPutString += "".PadLeft(CInt((32 - MySettings.CompanyName.Length) / 2)) & MySettings.CompanyName & vbNewLine
            OutPutString += "".PadLeft(Math.Floor((32 - MySettings.CompanyAddress.Replace(vbNewLine, ", ").Length) / 2)) & MySettings.CompanyAddress.Replace(vbNewLine, ", ") & vbNewLine
            OutPutString += "".PadLeft(Math.Floor((32 - ("PH :" & MySettings.CompanyPhone).Length) / 2)) & ("PH :" & MySettings.CompanyPhone) & vbNewLine

            OutPutString += "   " & "BOOK/TICKET NO." & ": " & BookingID & vbNewLine
            OutPutString += "   " & "DATE : " & Now.ToString("dd/MM/yyyy (ddd)") & vbNewLine
            OutPutString += "   " & "Time : " & Now.ToString("hh:mm:ss tt") & vbNewLine
            OutPutString += "".PadLeft(32, ".") & vbNewLine
            If type = memotype.BOOKING Then
                OutPutString += "   " & "DURATION".PadRight(16, ". ") & ": " & service & vbNewLine
                OutPutString += "   " & "ROOM".PadRight(16, ". ") & ": " & room & vbNewLine
                ' OutPutString += "   " & "SERVICE PROVIDER".PadRight(16, ". ") & ": " & WorkerNAmes & vbNewLine
                Try
                    Dim str As String = ""
                    For Each workerName As String In WorkerNAmes.Split(",")
                        If workerName.Trim <> "" Then
                            If str = "" Then
                                str += "   " & "SERVICE PROVIDER".PadRight(16, ". ") & ": " & workerName & vbNewLine
                            Else
                                str += "   " & " ".PadRight(16, "  ") & ": " & workerName & vbNewLine
                            End If
                        End If

                    Next
                    OutPutString += str
                Catch ex As Exception
                End Try
            End If

            If type = memotype.INSTANT Then
                OutPutString += "   " & "DOOR CHARGE".PadRight(16, ". ") & ": " & (currency + doorch.ToString("0.00")).PadLeft(8) & vbNewLine
                OutPutString += "   " & "DOOR".PadRight(16, ". ") & ": " & door & vbNewLine
                If shift_fee > 1 Then
                    OutPutString += "   " & "TICKET QTY".PadRight(16, ". ") & ": " & shift_fee.ToString("0").PadLeft(8) & vbNewLine
                End If
            End If
            OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + amount.ToString("0.00")).PadLeft(8) & vbNewLine
            If tip > 0 Then
                OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + tip.ToString("0.00")).PadLeft(8) & vbNewLine
            End If
            If type = memotype.BOOKING And shift_fee > 0 Then
                OutPutString += "   " & "SHIFT FEE".PadRight(16, ". ") & ": " & (currency + shift_fee.ToString("0.00")).PadLeft(8) & vbNewLine
            End If



            If type = memotype.BOOKING And cashout > 0 Then
                OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + cashout.ToString("0.00")).PadLeft(8) & vbNewLine
            End If
            If type = memotype.BOOKING Then
                If tip + cashout + shift_fee > 0 Then
                    OutPutString += "   " & "GRAND TOTAL".PadRight(16, ". ") & ": " & (currency + (amount + tip + cashout + shift_fee).ToString("0.00")).PadLeft(8) & vbNewLine
                End If
            ElseIf type = memotype.INSTANT Then
                If tip + cashout > 0 Then
                    OutPutString += "   " & "GRAND TOTAL".PadRight(16, ". ") & ": " & (currency + (amount + tip + cashout).ToString("0.00")).PadLeft(8) & vbNewLine
                End If
            End If

            OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & paymode & vbNewLine
            If cash > 0 Then
                OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + cash.ToString("0.00")).PadLeft(8) & vbNewLine
            End If
            If card > 0 Then
                OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + card.ToString("0.00")).PadLeft(8) & vbNewLine
                OutPutString += "   " & "SURCHARGE".PadRight(16, ". ") & ": " & (currency + surcharge.ToString("0.00")).PadLeft(8) & vbNewLine
            End If
            If voucher > 0 Then
                OutPutString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + voucher.ToString("0.00")).PadLeft(8) & vbNewLine
            End If
            OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + (cash + card + voucher + surcharge).ToString("0.00")).PadLeft(8) & vbNewLine

            OutPutString += "".PadLeft(32, ".") & vbNewLine

            'Middle

            OutPutString += "".PadLeft(Math.Floor((32 - ("WELCOME TO " & MySettings.CompanyName).Length) / 2)) & ("WELCOME TO " & MySettings.CompanyName) & vbNewLine

            If MySettings.MemoFooter1.Trim <> "" Then
                OutPutString += "".PadLeft(Math.Floor((32 - MySettings.MemoFooter1.Length) / 2)) & MySettings.MemoFooter1 & vbNewLine
            End If

            If MySettings.MemoFooter2.Trim <> "" Then
                OutPutString += "".PadLeft(Math.Floor((32 - MySettings.MemoFooter2.Length) / 2)) & MySettings.MemoFooter2 & vbNewLine
            End If

            If MySettings.MemoFooter3.Trim <> "" Then
                OutPutString += "".PadLeft(Math.Floor((32 - MySettings.MemoFooter3.Length) / 2)) & MySettings.MemoFooter3 & vbNewLine
            End If

        Catch ex As Exception
        End Try

        Printing(Reportprinter2, OutPutString, IIf(type = memotype.INSTANT, "Door Ticket No : ", "Memo No - ") & BookingID)
        Return OutPutString

    End Function


    Function PrintMerchandiseBill(ByVal BillNo As Integer, _
                             ByVal currency As String, _
                             ByVal Reportprinter2 As String, _
                         ByVal isPreview As Boolean) As String
        Dim objProduct As New cls_tblProducts
        Dim objBill As New cls_tblBill
        Dim objBillItems As New cls_tblBillItems
        Dim objPayment As New cls_tblPayment

        Dim drBill As DataRow = objBill.Selection(cls_tblBill.SelectionType.ALL, "BillID=" & BillNo).Rows(0)
        Dim dtBillItems As DataTable = objBillItems.Selection(cls_tblBillItems.SelectionType.ALL, "BillID=" & BillNo)
        Dim drBPaymnet As DataRow = objPayment.Selection(cls_tblPayment.SelectionTransac_Type.ALL, "Transc_ID=" & BillNo.ToString & " And Transac_Type='MERCHANDISE_SALE'").Rows(0)

        Dim OutPutString As String = ""
        Try
            Dim topAdd As Integer = 0
            'Middle
            OutPutString += "".PadLeft(CInt((32 - MySettings.CompanyName.Length) / 2)) & MySettings.CompanyName & vbNewLine
            OutPutString += "".PadLeft(Math.Floor((32 - MySettings.CompanyAddress.Replace(vbNewLine, ", ").Length) / 2)) & MySettings.CompanyAddress.Replace(vbNewLine, ", ") & vbNewLine
            OutPutString += "".PadLeft(Math.Floor((32 - ("PH :" & MySettings.CompanyPhone).Length) / 2)) & ("PH :" & MySettings.CompanyPhone) & vbNewLine

            OutPutString += "   " & "BILL NO." & ": " & BillNo.ToString & vbNewLine
            OutPutString += "   " & "DATE : " & Now.ToString("dd/MM/yyyy (ddd)") & vbNewLine
            OutPutString += "   " & "Time : " & Now.ToString("hh:mm:ss tt") & vbNewLine

            OutPutString += "".PadLeft(32, ".") & vbNewLine
            OutPutString += "   " & "SL ITEM    QTY  PRICE TOTAL" & vbNewLine
            Dim cnt As Integer = 1
            For Each dr As DataRow In dtBillItems.Rows
                Dim item As String = objProduct.Selection(cls_tblProducts.SelectionType.ALL, "ProductID=" & dr("ProductID")).Rows(0).Item("ProductName").ToString
                OutPutString += "   " & cnt.ToString.PadRight(2) & IIf(item.Length > 8, item.Substring(0, 8), item).ToString.PadRight(9) & dr("QTY").ToString.PadLeft(3) & dr("Price").ToString.PadLeft(6) & dr("SubTotal").ToString.PadLeft(7) & vbNewLine
                cnt += 1
            Next


            OutPutString += "".PadLeft(32, ".") & vbNewLine
            OutPutString += "   " & "TOTAL".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("TotalAmount")).ToString("0.00")).PadLeft(8) & vbNewLine

            'OutPutString += "   " & "TIP".PadRight(16, ". ") & ": " & (currency + drBPaymnet("tip").ToString("0.00")).PadLeft(8) & vbNewLine
            'OutPutString += "   " & "CASH OUT".PadRight(16, ". ") & ": " & (currency + cashout.ToString("0.00")).PadLeft(8) & vbNewLine

            'OutPutString += "   " & "GRAND TOTAL".PadRight(16, ". ") & ": " & (currency + (amount + ).ToString("0.00")).PadLeft(8) & vbNewLine
            OutPutString += "   " & "PAYMENT METHOD".PadRight(16, ". ") & ": " & drBPaymnet("PaymentMode") & vbNewLine
            If Val(drBPaymnet("CASH")) > 0 Then
                OutPutString += "   " & "CASH PAYMENT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("CASH")).ToString("0.00")).PadLeft(8) & vbNewLine

            End If
            If Val(drBPaymnet("CARD")) > 0 Then
                OutPutString += "   " & "CARD PAYMENT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("CARD")).ToString("0.00")).PadLeft(8) & vbNewLine
                OutPutString += "   " & "SURCHARGE".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("SURCHARGE_AMT")).ToString("0.00")).PadLeft(8) & vbNewLine

            End If
            If Val(drBPaymnet("VoucherAmount")) > 0 Then
                OutPutString += "   " & "VOUCHER PAYMENT".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("VoucherAmount")).ToString("0.00")).PadLeft(8) & vbNewLine

            End If
            OutPutString += "   " & "AMOUNT PAYABLE".PadRight(16, ". ") & ": " & (currency + Val(drBPaymnet("CASH") + drBPaymnet("CARD") + drBPaymnet("VoucherAmount") + drBPaymnet("SURCHARGE_AMT")).ToString("0.00")).PadLeft(8) & vbNewLine

            OutPutString += "".PadLeft(32, ".") & vbNewLine

            'Middle

            OutPutString += "".PadLeft(Math.Floor((32 - ("WELCOME TO " & MySettings.CompanyName).Length) / 2)) & ("WELCOME TO " & MySettings.CompanyName) & vbNewLine

            If MySettings.MemoFooter1.Trim <> "" Then
                OutPutString += "".PadLeft(Math.Floor((32 - MySettings.MemoFooter1.Length) / 2)) & MySettings.MemoFooter1 & vbNewLine
            End If

            If MySettings.MemoFooter2.Trim <> "" Then
                OutPutString += "".PadLeft(Math.Floor((32 - MySettings.MemoFooter2.Length) / 2)) & MySettings.MemoFooter2 & vbNewLine
            End If

            If MySettings.MemoFooter3.Trim <> "" Then
                OutPutString += "".PadLeft(Math.Floor((32 - MySettings.MemoFooter3.Length) / 2)) & MySettings.MemoFooter3 & vbNewLine
            End If

        Catch ex As Exception
        End Try

        Printing(Reportprinter2, OutPutString, "Bill No - " & BillNo)
        Return OutPutString
    End Function


    Private printFont As Font
    Private streamToPrint As StringReader 
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
    Public Sub Printing(ByVal PrinterName_ As String, ByVal TextToPrint As String, Optional ByVal DocName As String = "")
        Try
            streamToPrint = New StringReader(TextToPrint)
            Try
                Try
                    'printFont = New Font("Fixedsys", 10)
                    printFont = New Font("Fixedsys Neo+", 10)
                Catch ex As Exception
                    printFont = New Font("Lucida Console", 10)
                End Try
                Dim pd As New PrintDocument()
                AddHandler pd.PrintPage, AddressOf pd_PrintPage
                Try
                    Dim printerformat As System.Drawing.Printing.PaperSize
                    Dim PrinterObj As New System.Drawing.Printing.PrinterSettings
                    PrinterObj.PrinterName = pd.DefaultPageSettings.PrinterSettings.PrinterName
                    For Each printerformat In PrinterObj.PaperSizes()
                        Try
                            If "Envelope" = printerformat.PaperName Then
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
