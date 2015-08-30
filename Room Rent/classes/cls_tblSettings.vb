Imports Newtonsoft.Json

Public Class cls_tblSettings

    Dim vReceiptPrinterName As String
    Dim vCompanyName As String
    Dim vCompanyAddress As String
    Dim vCompanyPhone As String
    Dim vMemoFooter1 As String
    Dim vMemoFooter2 As String
    Dim vMemoFooter3 As String
    'Dim vRoomCharge As String
    Dim vPassword As String
    Dim vSurcharge As Double = 0
    Dim vSP_Percentage As Double = 0
    Dim vSP_Percentage_Night As Double = 0
    Dim vDay_Start As String
    Dim vDay_End As String


    Dim vEncryted As Boolean
    Dim vPassHint As String
    Dim vSpecialServiceEnabled As Boolean

    Dim vEve_Start As String
    Dim vEve_End As String
    Dim vShifts_3_enabled As Boolean
    Dim vContra As Boolean
    Dim vContra_Password As String
    Dim vOtherSettings As OtherSetiings_S



    Structure OtherSetiings_S
        Dim EscortServices As List(Of String)
        Dim CancelFees As Double
        Dim DayPrice As Boolean
        Dim DayPricePassword As String
        Dim CancelFeesAfter1Hr As Double
        Dim MembershipFee As Double
        Dim SameEscortPrice As Boolean
        Dim EscortService As Boolean


        Dim EFT_P As Double
        Dim VISA_P As Double
        Dim MASTERCARD_P As Double
        Dim AMEX_P As Double
        Dim OTHRCARD_P As Double
        Dim PauseResumePassword As String
        Dim TimeAdjustPassword As String
        Dim MultipleEscortPrice As Boolean
        Dim RoomType As String
        Dim BOND_FEES As Double
        Dim Membership As Boolean
        Dim OnlyDeluxForEscort As Boolean
        Dim StartDate As Date
        Dim Adjust_Cashamount As Double
        Dim Adjust_TotalBooks As Double
        Dim DoorPrivateDay As Double
        Dim DoorPrivateIntroDay As Double
        Dim DoorLoungeDay As Double
        Dim DoorPrivateNight As Double
        Dim DoorPrivateIntroNight As Double
        Dim DoorLoungeNight As Double



        Dim CancellationPassword As String
    End Structure

    Enum Fields
        ReceiptPrinterName
        CompanyName
        CompanyAddress
        CompanyPhone
        MemoFooter1
        MemoFooter2
        MemoFooter3
        RoomCharge
        Password
        Surcharge
        SP_Percentage
        SP_Percentage_Night
        Day_start
        Day_end
        Encryted
        PassHint
        SpecialServiceEnabled
        Eve_start
        Eve_End
        Shifts_3_enabled
        Contra
        Contra_Password
        OtherSettings
    End Enum

    Sub New()
        vReceiptPrinterName = SelectScalar(Fields.ReceiptPrinterName)
        vCompanyName = SelectScalar(Fields.CompanyName)
        vCompanyAddress = SelectScalar(Fields.CompanyAddress)
        vCompanyPhone = SelectScalar(Fields.CompanyPhone)
        vMemoFooter1 = SelectScalar(Fields.MemoFooter1)
        vMemoFooter2 = SelectScalar(Fields.MemoFooter2)
        vMemoFooter3 = SelectScalar(Fields.MemoFooter3)
        'vRoomCharge = SelectScalar(Fields.RoomCharge)
        vPassword = SelectScalar(Fields.Password)
        vSurcharge = SelectScalar(Fields.Surcharge)
        vSP_Percentage = SelectScalar(Fields.SP_Percentage)
        vSP_Percentage_Night = SelectScalar(Fields.SP_Percentage_Night)
        vDay_Start = SelectScalar(Fields.Day_start)
        vDay_End = SelectScalar(Fields.Day_end)
        vEncryted = SelectScalar(Fields.Encryted)
        vPassHint = SelectScalar(Fields.PassHint)
        vSpecialServiceEnabled = SelectScalar(Fields.SpecialServiceEnabled)
        vEve_Start = SelectScalar(Fields.Eve_start)
        vEve_End = SelectScalar(Fields.Eve_End)
        vShifts_3_enabled = SelectScalar(Fields.Shifts_3_enabled)
        vContra = SelectScalar(Fields.Contra)
        vContra_Password = SelectScalar(Fields.Contra_Password)

        Try
            Dim OtStr As String = SelectScalar(Fields.OtherSettings).ToString
            vOtherSettings = JsonConvert.DeserializeObject(Of OtherSetiings_S)(OtStr)
            If Not OtStr.Contains("EFT_P") Then
                vOtherSettings.EFT_P = 5.5
            End If
            If Not OtStr.Contains("VISA_P") Then
                vOtherSettings.VISA_P = 12.1
            End If
            If Not OtStr.Contains("MASTERCARD_P") Then
                vOtherSettings.MASTERCARD_P = 12.1
            End If
            If Not OtStr.Contains("AMEX_P") Then
                vOtherSettings.AMEX_P = 12.1
            End If
            If Not OtStr.Contains("OTHRCARD_P") Then
                vOtherSettings.OTHRCARD_P = 20
            End If

            If Not OtStr.Contains("RoomType") Then
                vOtherSettings.RoomType = "6 ROOMS"
            End If

        Catch ex As Exception
            'Try
            '    vOtherSettings = JsonConvert.DeserializeObject(Of OtherSetiings_S)("{""EscortServices"":[""180"",""240"",""120"",""300""],"EscortService":true}")
            'Catch ex1 As Exception
            'End Try
            vOtherSettings = New OtherSetiings_S
            vOtherSettings.EscortServices = New List(Of String) From {"180", "240", "120", "300"}
            vOtherSettings.EFT_P = 5.5
            vOtherSettings.VISA_P = 12.1
            vOtherSettings.MASTERCARD_P = 12.1
            vOtherSettings.AMEX_P = 12.1
            vOtherSettings.OTHRCARD_P = 20
            vOtherSettings.EscortService = True
            vOtherSettings.MultipleEscortPrice = True
            vOtherSettings.RoomType = "6 ROOMS"
            vOtherSettings.BOND_FEES = 300.0
            vOtherSettings.DoorLoungeDay = 10
            vOtherSettings.DoorLoungeNight = 20
            vOtherSettings.DoorPrivateDay = 20
            vOtherSettings.DoorPrivateNight = 20
            vOtherSettings.RoomType = "6 ROOMS"



        End Try
    End Sub

    'Property ReceiptPrinterName As String
    '    Get
    '        Dim ss As String = vReceiptPrinterName
    '        Return ss
    '    End Get
    '    Set(ByVal value As String)
    '        Update(Fields.ReceiptPrinterName, value)
    '        vReceiptPrinterName = value
    '    End Set
    'End Property

    Property CompanyName As String
        Get
            Return vCompanyName
        End Get
        Set(ByVal value As String)
            Update(Fields.CompanyName, value)
            vCompanyName = value
        End Set
    End Property

    Property CompanyAddress As String
        Get
            Return vCompanyAddress
        End Get
        Set(ByVal value As String)
            Update(Fields.CompanyAddress, value)
            vCompanyAddress = value
        End Set
    End Property
    Property CompanyPhone As String
        Get
            Return vCompanyPhone
        End Get
        Set(ByVal value As String)
            Update(Fields.CompanyPhone, value)
            vCompanyPhone = value
        End Set
    End Property
    Property MemoFooter1 As String
        Get
            Return vMemoFooter1
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Property MemoFooter2 As String
        Get
            Return vMemoFooter2
        End Get
        Set(ByVal value As String)
            Update(Fields.MemoFooter2, value)
            vMemoFooter2 = value
        End Set
    End Property
    Property MemoFooter3 As String
        Get
            Return vMemoFooter3
        End Get
        Set(ByVal value As String)
            Update(Fields.MemoFooter3, value)
            vMemoFooter3 = value
        End Set
    End Property
    'Property RoomCharge As String
    '    Get
    '        Return vRoomCharge
    '    End Get
    '    Set(ByVal value As String)
    '        Update(Fields.RoomCharge, value)
    '        vRoomCharge = value
    '    End Set
    'End Property

    Property Password As String
        Get
            Return vPassword
        End Get
        Set(ByVal value As String)
            Update(Fields.Password, value)
            vPassword = value
        End Set
    End Property

    Property Surcharge As Double
        Get
            Return vSurcharge
        End Get
        Set(ByVal value As Double)
            Update(Fields.Surcharge, value)
            vSurcharge = value
        End Set
    End Property

    Property SP_Percentage As Double
        Get
            Return vSP_Percentage
        End Get
        Set(ByVal value As Double)
            Update(Fields.SP_Percentage, value)
            vSP_Percentage = value
        End Set
    End Property

    Property SP_Percentage_Night As Double
        Get
            Return vSP_Percentage_Night
        End Get
        Set(ByVal value As Double)
            Update(Fields.SP_Percentage_Night, value)
            vSP_Percentage_Night = value
        End Set
    End Property

    Property Day_Start As String
        Get
            Return vDay_Start
        End Get
        Set(ByVal value As String)
            Update(Fields.Day_start, value)
            vDay_Start = value
        End Set
    End Property

    Property Day_End As String
        Get
            Return vDay_End
        End Get
        Set(ByVal value As String)
            Update(Fields.Day_end, value)
            vDay_End = value
        End Set
    End Property
    Property Encryted As Boolean
        Get
            Return vEncryted
        End Get
        Set(ByVal value As Boolean)
            Update(Fields.Encryted, value)
            vEncryted = value
        End Set
    End Property
    Property PassHint As String
        Get
            Return vPassHint
        End Get
        Set(ByVal value As String)
            Update(Fields.PassHint, value)
            vPassHint = value
        End Set
    End Property
    Property SpecialServiceEnabled As Boolean
        Get
            Return vSpecialServiceEnabled
        End Get
        Set(ByVal value As Boolean)
            Update(Fields.SpecialServiceEnabled, value)
            vSpecialServiceEnabled = value
        End Set
    End Property
    Property Eve_Start As String
        Get
            Return vEve_Start
        End Get
        Set(ByVal value As String)
            Update(Fields.Eve_start, value)
            vEve_Start = value
        End Set
    End Property
    Property Eve_End As String
        Get
            Return vEve_End
        End Get
        Set(ByVal value As String)
            Update(Fields.Eve_End, value)
            vEve_End = value
        End Set
    End Property
    Property Shifts_3_enabled As Boolean
        Get
            Return vShifts_3_enabled
        End Get
        Set(ByVal value As Boolean)
            Update(Fields.Shifts_3_enabled, value)
            vShifts_3_enabled = value
        End Set
    End Property
    Property Contra_Password As String
        Get
            Return vContra_Password
        End Get
        Set(ByVal value As String)
            Update(Fields.Contra_Password, value)
            vContra_Password = value
        End Set
    End Property
    Property Contra As Boolean
        Get
            Return vContra
        End Get
        Set(ByVal value As Boolean)
            Update(Fields.Contra, value)
            vContra = value
        End Set
    End Property
    Property OtherSettings As OtherSetiings_S
        Get
            Return vOtherSettings
        End Get
        Set(ByVal value As OtherSetiings_S)
            Update(Fields.OtherSettings, JsonConvert.SerializeObject(value))
            vOtherSettings = value
        End Set
    End Property

    Public Function Update( _
                           ByVal fl As Fields, _
                           ByVal value As String, _
                           Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As Integer
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SqlCommand("UPDATE [tblSettings] SET [" & fl.ToString & "]=@" & fl.ToString, conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        With comInsert.Parameters
            .AddWithValue("@" & fl.ToString, value)
        End With
        Dim obj
        Try
            obj = comInsert.ExecuteNonQuery
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comInsert.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comInsert.Dispose()
        If Val(obj) <= 0 Then
            Throw New Exception("No Record Inserted")
        End If
        Return 0

    End Function
    Public Function SelectScalar( _
                            ByVal fl As Fields, _
                            Optional ByRef conn As SqlConnection = Nothing, Optional ByRef transact As SqlTransaction = Nothing) As String
        Dim isDisposeConn As Boolean = False
        Dim objConn As clsConnection = Nothing
        If conn Is Nothing Then
            objConn = New clsConnection
            conn = objConn.connect
            isDisposeConn = True
        End If
        Dim comInsert As New SqlCommand("SELECT [" & fl.ToString & "] FROM [tblSettings]", conn)
        If transact IsNot Nothing Then
            comInsert.Transaction = transact
        End If
        Dim obj
        Try
            obj = comInsert.ExecuteScalar
        Catch ex As Exception
            If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
            comInsert.Dispose()
            Throw ex
        End Try
        If isDisposeConn Then conn.Close() : conn.Dispose() : objConn.Dispose()
        comInsert.Dispose()
        Return obj.ToString
    End Function
End Class
