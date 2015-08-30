Imports System.Globalization

Public Class NumericTextBox
    Inherits TextBox
    Private SpaceOK As Boolean = False
    Private NegativeOK As Boolean = False
    Private GroupSeperatorOK As Boolean = False
    Private DecimalSeparatorOK As Boolean = False



    Public Property Space As Boolean
        Get
            Return SpaceOK
        End Get
        Set(ByVal value As Boolean)
            SpaceOK = value
        End Set
    End Property
    Public Property Negative As Boolean
        Get
            Return NegativeOK
        End Get
        Set(ByVal value As Boolean)
            NegativeOK = value
        End Set
    End Property
    Public Property GroupSeperator As Boolean
        Get
            Return GroupSeperatorOK
        End Get
        Set(ByVal value As Boolean)
            GroupSeperatorOK = value
        End Set
    End Property
    Public Property DecimalSeparator As Boolean
        Get
            Return DecimalSeparatorOK
        End Get
        Set(ByVal value As Boolean)
            DecimalSeparatorOK = value
        End Set
    End Property

    ' Restricts the entry of characters to digits (including hex), 
    ' the negative sign, the e decimal point, and editing keystrokes (backspace). 
    Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)

        Dim vnumberFormatInfo As NumberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat
        Dim vdecimalSeparator As String = vnumberFormatInfo.NumberDecimalSeparator
        Dim vgroupSeparator As String = vnumberFormatInfo.NumberGroupSeparator
        Dim vnegativeSign As String = vnumberFormatInfo.NegativeSign

        If vgroupSeparator = CChar(ChrW(160)).ToString() Then
            vgroupSeparator = " "
        End If

        Dim keyInput As String = e.KeyChar.ToString()

        If [Char].IsDigit(e.KeyChar) Then
            ' Digits are OK 
        ElseIf Me.DecimalSeparatorOK AndAlso keyInput.Equals(vdecimalSeparator) Then
            ' Decimal separator is OK 
            If Text.Contains(vdecimalSeparator) Then
                e.Handled = True
            End If
        ElseIf Me.GroupSeperatorOK AndAlso keyInput.Equals(vgroupSeparator) Then
            ' Group separator is OK 
            If Text.EndsWith(vgroupSeparator) OrElse Text.Trim = "" Then
                e.Handled = True
            End If
        ElseIf Me.NegativeOK AndAlso keyInput.Equals(vnegativeSign) Then
            ' Negative Sign  is OK 
            If Text.Contains(vnegativeSign) OrElse Text.Trim <> "" Then
                e.Handled = True
            End If
        ElseIf e.KeyChar = vbBack Then
            ' Backspace key is OK 
            '    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0) 
            '    { 
            '     // Let the edit control handle control and alt key combinations 
            '    } 
        ElseIf Me.SpaceOK AndAlso e.KeyChar = " "c Then

        Else
            ' Consume this invalid key and beep.
            e.Handled = True
        End If

    End Sub


    Public ReadOnly Property IntValue() As Integer
        Get
            Return Int32.Parse(Me.Text)
        End Get
    End Property


    Public ReadOnly Property DecimalValue() As Decimal
        Get
            Return [Decimal].Parse(Me.Text)
        End Get
    End Property


    Public Property AllowSpace() As Boolean

        Get
            Return Me.SpaceOK
        End Get
        Set(ByVal value As Boolean)
            Me.SpaceOK = value
        End Set
    End Property
End Class