Imports System.IO
Imports Newtonsoft.Json

Public Module mdlGlobals
#Region "Variables"

    Public UpdateRequired As Boolean = True
    Dim __isRainBow As Boolean = False
    Dim __isSite2ButtonsVisible As Boolean = True
    Public RoomVisibleQuerySelection As String = "'***NOTHING***'"
    Public IsAllTopMostForm As Boolean = False ' True
    Public currency As String = "$"
    Public isSoundOn As Boolean = True
    Public mySpeaker As Speech.Synthesis.SpeechSynthesizer
    Dim VisibleRooms As Integer = 15

    'Database Connection Details
    Public dbName As String = "dbRent"
    Public dbServername As String = "BIDYUT-LAPTOP"
    Public dbUserName As String = "sa"
    Public dbPassword As String = "Kumar"

    Public MyConnectionString As String = ""
    Public zp As String = "Cr+GWDHQs6QuDGIZlWIWxQ=="

    'Public HoldRoomText As String = "PENDING"
    'Public EscortRoomText As String = "ESCORT"

    <Serializable()>
    Structure LocalSetting
        Dim ReceiptPrinter As String
        Dim ReportPrinter As String
        Dim SpeechSpeaker As Boolean
        Dim LastVersion As String
        Dim ThisVersion As String
        Dim EmailUserName As String
        Dim EmailPass As String
        Dim CashComPort As String
    End Structure

    Structure WarningTimes
        Dim FirstWarningRoom As Integer
        Dim SecondWarningRoom As Integer
        Dim ThirdWarningRoom As Integer
        Dim LastWarningRoom As Integer
        Dim FirstWarningEscort As Integer
        Dim SecondWarningEscort As Integer
        Dim ThirdWarningEscort As Integer
        Dim LastWarningEscort As Integer
    End Structure

    Public MyLocalSettings As LocalSetting = Nothing

    Dim localSettingsFile As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "localsettings.ini")

    Public Sub LoadLocalSettings()
        Try
            If IO.File.Exists(localSettingsFile) Then
                MyLocalSettings = JsonConvert.DeserializeObject(Of LocalSetting)(IO.File.ReadAllText(localSettingsFile))
            Else
                MyLocalSettings = New LocalSetting
                MyLocalSettings.ReceiptPrinter = ""
                MyLocalSettings.ReportPrinter = ""
                MyLocalSettings.SpeechSpeaker = True
                MyLocalSettings.LastVersion = ""
                MyLocalSettings.ThisVersion = "1.0.0.89"
                SaveLocalSettings()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SaveLocalSettings()
        Try
            IO.File.WriteAllText(localSettingsFile, JsonConvert.SerializeObject(MyLocalSettings), System.Text.Encoding.ASCII)
        Catch ex As Exception
        End Try
    End Sub

    Public Structure connectionInfo
        Dim dbName As String
        Dim dbServername As String
        Dim dbUserName As String
        Dim dbPassword As String
    End Structure

    Public Property isRainBow As Boolean
        Set(ByVal value As Boolean)
            __isRainBow = value
            frmHome.SetRainbow()
        End Set
        Get
            Return __isRainBow
        End Get
    End Property

    Public Property isSite2ButtonsVisible As Boolean
        Set(ByVal value As Boolean)
            __isSite2ButtonsVisible = value
            Dim str As String = ""
            Dim objRooms As New cls_Temp_tblRoom
            For Each dr As DataRow In objRooms.Selection().Rows
                If dr("Sl").ToString >= 10 And dr("Sl").ToString <= 15 Then
                    If str <> "" Then
                        str += ","
                    End If
                    str += "'" & dr("Room").ToString & "'"
                End If
            Next
            RoomVisibleQuerySelection = IIf(__isSite2ButtonsVisible, "'***NOTHING***'", str)
            frmHome.SetButtonVisible()
            frmMAP.SetButtonVisible()
        End Set
        Get
            Return __isSite2ButtonsVisible
        End Get
    End Property

#End Region
#Region "Subroutines"

#End Region
#Region "Function"
    Public Function ByteArray2File(ByRef ByAr() As Byte, ByVal extension As String) As String
        If ByAr Is Nothing Then
            Return ""
        Else
            Dim byteData() As Byte = ByAr
            Dim imag As String = extension
            Dim oFileStream As System.IO.FileStream
            oFileStream = New System.IO.FileStream(imag, System.IO.FileMode.Create)
            oFileStream.Write(byteData, 0, byteData.Length)
            oFileStream.Flush()
            oFileStream.Close()
            oFileStream.Dispose()
            ByAr = Nothing
            byteData = Nothing
            Return imag
        End If
    End Function

    Public Function FileToByteArray(ByVal _FileName As String) As Byte()
        Dim _Buffer() As Byte = Nothing
        Try
            'Open file for reading
            Dim _FileStream As New System.IO.FileStream(_FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            'attach filestream to binary reader
            Dim _BinaryReader As New System.IO.BinaryReader(_FileStream)
            'get total byte length of the file
            Dim _TotalBytes As Long = New System.IO.FileInfo(_FileName).Length
            'read entire file into buffer
            _Buffer = _BinaryReader.ReadBytes(CInt(Fix(_TotalBytes)))
            'close file reader
            _FileStream.Close()
            _FileStream.Dispose()
            _BinaryReader.Close()
        Catch _Exception As Exception
        End Try
        Return _Buffer
    End Function

    Public Function DeveloperPC() As Boolean
        Return (My.Computer.Name.ToUpper = "BIDYUT" And My.User.Name.ToUpper = "BIDYUT\ME") Or (My.Computer.Name.ToUpper = "BIDYUT-LAPTOP" And My.User.Name.ToUpper = "BIDYUT-LAPTOP\BIDYUT DAS") Or (My.Computer.Name.ToUpper = "BIDYUT" And My.User.Name.ToUpper = "BIDYUT\BIDYUTME")
    End Function

    Function MsgBox(ByVal Message As String) As MsgBoxResult
        ' Microsoft.VisualBasic.MsgBox(Message)
        Dim frm As New dlgMessage
        frm.Label1.Text = Message
        frm.Text = My.Application.Info.Title
        Return frm.ShowDialog
    End Function

    Function MsgBox(ByVal Message As String, ByVal Typ As MsgBoxStyle, ByVal Title As String) As MsgBoxResult
        Dim gg() As Integer = SplitBinaryNumber(Typ)
        ' Dim i As Integer =  MsgBoxStyle.
        ' Return MsgBoxResult.Ok
        Dim IconI As MsgBoxStyle = Nothing
        Dim ButtonI As MsgBoxStyle = Nothing

        If gg.Contains(MsgBoxStyle.Information) Then
            IconI = MsgBoxStyle.Information
        End If
        If gg.Contains(MsgBoxStyle.Question) Then
            IconI = MsgBoxStyle.Question
        End If
        If gg.Contains(MsgBoxStyle.Critical) Then
            IconI = MsgBoxStyle.Critical
        End If
        If gg.Contains(MsgBoxStyle.Exclamation) Or (gg.Contains(MsgBoxStyle.Critical) And gg.Contains(MsgBoxStyle.Question)) Then
            IconI = MsgBoxStyle.Exclamation
        End If

        Dim isDoubleButton As Boolean = False
        If gg.Contains(MsgBoxStyle.YesNo) Then
            ButtonI = MsgBoxStyle.YesNo
            isDoubleButton = True
        End If
        If gg.Contains(MsgBoxStyle.OkCancel) Then
            ButtonI = MsgBoxStyle.OkCancel
            isDoubleButton = True
        End If

        If gg.Contains(MsgBoxStyle.RetryCancel) Or (gg.Contains(MsgBoxStyle.YesNo) And gg.Contains(MsgBoxStyle.OkCancel)) Then
            ButtonI = MsgBoxStyle.RetryCancel
            isDoubleButton = True
        End If

        If isDoubleButton Then
            Dim frm As New dlgMessage2
            frm.Label1.Text = Message
            frm.Text = Title
            frm.IconI = IconI
            frm.ButtonI = ButtonI
            Return frm.ShowDialog
        Else
            Dim frm As New dlgMessage
            frm.Label1.Text = Message
            frm.Text = Title
            frm.IconI = IconI
            Return frm.ShowDialog
        End If

        ' Return Microsoft.VisualBasic.MsgBox(Message, Typ, Title)
    End Function
    Function SplitBinaryNumber(ByVal no As Integer) As Integer()
        Dim ll As New List(Of Integer)
        Dim lastvalue As Integer = 0
        While no >= 1
            lastvalue = 0
            Dim Binry As Integer = 1
            While True
                If no < Binry Then
                    ll.Add(lastvalue)
                    no = no - lastvalue
                    Exit While
                End If
                lastvalue = Binry
                Binry = Binry * 2
            End While
        End While
        Return ll.ToArray
    End Function

    'Sub Main(ByVal File_Path As String)
    '    Try
    '        Dim compact_file As String = ""
    '        'compact file path, a temp file
    '        compact_file = AppDomain.CurrentDomain.BaseDirectory & "db1.mdb"
    '        'First check the file u want to compact exists or not
    '        If File.Exists(File_Path) Then
    '            Dim db As New dao.DBEngine()
    '            'CompactDatabase has two parameters, creates a copy of 
    '            'compact DB at the Destination path
    '            db.CompactDatabase(File_Path, compact_file)
    '        End If
    '        'restore the original file from the compacted file
    '        If File.Exists(compact_file) Then
    '            File.Delete(File_Path)
    '            File.Move(compact_file, File_Path)
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    Function CalculateGST(IncludingGSTAmount As Double, Optional GST_P As Double = 10) As Double
        Dim GST As Double = 0
        GST = IncludingGSTAmount * ((GST_P / 100) / ((GST_P + 100) / 100))
        Return GST
    End Function

    Public Function IsNull(obj As Object, vall As Object) As Object
        If obj Is Nothing Then
            Return vall
        Else
            Return obj
        End If
    End Function

#End Region
End Module
