<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentOthers
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpPaymentMode = New System.Windows.Forms.GroupBox()
        Me.btnCardCash = New System.Windows.Forms.Button()
        Me.btnCard = New System.Windows.Forms.Button()
        Me.btnCash = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnVouchers = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.pnlCards = New System.Windows.Forms.Panel()
        Me.btnOthers = New System.Windows.Forms.PictureBox()
        Me.btnAmex = New System.Windows.Forms.PictureBox()
        Me.btnMasterCard = New System.Windows.Forms.PictureBox()
        Me.btnVisa = New System.Windows.Forms.PictureBox()
        Me.btnEftPos = New System.Windows.Forms.PictureBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotalExGST = New Room_Rent.NumericTextBox()
        Me.txtGST = New Room_Rent.NumericTextBox()
        Me.MyNumericKeyBoard1 = New Room_Rent.MyNumericKeyBoard()
        Me.txtVoucherAmount = New Room_Rent.NumericTextBox()
        Me.txtGrandTotal = New Room_Rent.NumericTextBox()
        Me.txtSurchargeAmt = New Room_Rent.NumericTextBox()
        Me.txtAmountPaid = New Room_Rent.NumericTextBox()
        Me.txtCashOut = New Room_Rent.NumericTextBox()
        Me.txtSurchrgeP = New Room_Rent.NumericTextBox()
        Me.txtTip = New Room_Rent.NumericTextBox()
        Me.txtTotalInGST = New Room_Rent.NumericTextBox()
        Me.txtCard = New Room_Rent.NumericTextBox()
        Me.txtCash = New Room_Rent.NumericTextBox()
        Me.grpPaymentMode.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlCards.SuspendLayout()
        CType(Me.btnOthers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAmex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnMasterCard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnVisa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEftPos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpPaymentMode
        '
        Me.grpPaymentMode.Controls.Add(Me.btnCardCash)
        Me.grpPaymentMode.Controls.Add(Me.btnCard)
        Me.grpPaymentMode.Controls.Add(Me.btnCash)
        Me.grpPaymentMode.Location = New System.Drawing.Point(72, 75)
        Me.grpPaymentMode.Name = "grpPaymentMode"
        Me.grpPaymentMode.Size = New System.Drawing.Size(607, 80)
        Me.grpPaymentMode.TabIndex = 5
        Me.grpPaymentMode.TabStop = False
        Me.grpPaymentMode.Text = "PAYMENT MODE"
        '
        'btnCardCash
        '
        Me.btnCardCash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCardCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCardCash.Location = New System.Drawing.Point(401, 19)
        Me.btnCardCash.Name = "btnCardCash"
        Me.btnCardCash.Size = New System.Drawing.Size(183, 50)
        Me.btnCardCash.TabIndex = 2
        Me.btnCardCash.Text = "CARD/CASH"
        Me.btnCardCash.UseVisualStyleBackColor = True
        '
        'btnCard
        '
        Me.btnCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCard.Location = New System.Drawing.Point(212, 19)
        Me.btnCard.Name = "btnCard"
        Me.btnCard.Size = New System.Drawing.Size(183, 50)
        Me.btnCard.TabIndex = 1
        Me.btnCard.Text = "CARD"
        Me.btnCard.UseVisualStyleBackColor = True
        '
        'btnCash
        '
        Me.btnCash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCash.Location = New System.Drawing.Point(23, 19)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(183, 50)
        Me.btnCash.TabIndex = 0
        Me.btnCash.Text = "CASH"
        Me.btnCash.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(13, 386)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(162, 121)
        Me.btnBack.TabIndex = 7
        Me.btnBack.Text = "GO BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(584, 386)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(162, 121)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = "OK"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(199, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 46)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total : 120.00"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(390, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 26)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "CASH"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(390, 193)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 26)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "CARD"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(390, 305)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 26)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "PAYABLE AMT"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(91, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 26)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "AMOUNT"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(91, 256)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 26)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "TIP"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(91, 288)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 26)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "CASH OUT"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(91, 320)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(185, 26)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "GRAND TOTAL"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(582, 225)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 26)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "%"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(759, 73)
        Me.Panel1.TabIndex = 19
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 647)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(759, 22)
        Me.StatusStrip1.TabIndex = 20
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(390, 225)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 26)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "VOUCHER AMT"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Visible = False
        '
        'btnVouchers
        '
        Me.btnVouchers.Enabled = False
        Me.btnVouchers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVouchers.Location = New System.Drawing.Point(656, 224)
        Me.btnVouchers.Name = "btnVouchers"
        Me.btnVouchers.Size = New System.Drawing.Size(30, 28)
        Me.btnVouchers.TabIndex = 11
        Me.btnVouchers.Text = "+"
        Me.btnVouchers.UseVisualStyleBackColor = True
        Me.btnVouchers.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(387, 224)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 28)
        Me.Button1.TabIndex = 9
        Me.Button1.TabStop = False
        Me.Button1.Text = "ADMIN FEE"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(91, 193)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(140, 26)
        Me.Label21.TabIndex = 34
        Me.Label21.Text = "GST @ 10%"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlCards
        '
        Me.pnlCards.Controls.Add(Me.btnOthers)
        Me.pnlCards.Controls.Add(Me.btnAmex)
        Me.pnlCards.Controls.Add(Me.btnMasterCard)
        Me.pnlCards.Controls.Add(Me.btnVisa)
        Me.pnlCards.Controls.Add(Me.btnEftPos)
        Me.pnlCards.Controls.Add(Me.Label20)
        Me.pnlCards.Controls.Add(Me.Label19)
        Me.pnlCards.Controls.Add(Me.Label18)
        Me.pnlCards.Controls.Add(Me.Label17)
        Me.pnlCards.Controls.Add(Me.Label16)
        Me.pnlCards.Location = New System.Drawing.Point(381, 250)
        Me.pnlCards.Name = "pnlCards"
        Me.pnlCards.Size = New System.Drawing.Size(306, 49)
        Me.pnlCards.TabIndex = 8
        '
        'btnOthers
        '
        Me.btnOthers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOthers.Image = Global.Room_Rent.My.Resources.Resources.other_card
        Me.btnOthers.Location = New System.Drawing.Point(243, 5)
        Me.btnOthers.Name = "btnOthers"
        Me.btnOthers.Size = New System.Drawing.Size(59, 33)
        Me.btnOthers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnOthers.TabIndex = 30
        Me.btnOthers.TabStop = False
        Me.btnOthers.Tag = "20"
        '
        'btnAmex
        '
        Me.btnAmex.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAmex.Image = Global.Room_Rent.My.Resources.Resources.amex
        Me.btnAmex.Location = New System.Drawing.Point(183, 5)
        Me.btnAmex.Name = "btnAmex"
        Me.btnAmex.Size = New System.Drawing.Size(59, 33)
        Me.btnAmex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAmex.TabIndex = 29
        Me.btnAmex.TabStop = False
        Me.btnAmex.Tag = "12"
        '
        'btnMasterCard
        '
        Me.btnMasterCard.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMasterCard.Image = Global.Room_Rent.My.Resources.Resources.mastercard
        Me.btnMasterCard.Location = New System.Drawing.Point(123, 5)
        Me.btnMasterCard.Name = "btnMasterCard"
        Me.btnMasterCard.Size = New System.Drawing.Size(59, 33)
        Me.btnMasterCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnMasterCard.TabIndex = 29
        Me.btnMasterCard.TabStop = False
        Me.btnMasterCard.Tag = "10"
        '
        'btnVisa
        '
        Me.btnVisa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVisa.Image = Global.Room_Rent.My.Resources.Resources.visa
        Me.btnVisa.Location = New System.Drawing.Point(63, 5)
        Me.btnVisa.Name = "btnVisa"
        Me.btnVisa.Size = New System.Drawing.Size(59, 33)
        Me.btnVisa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnVisa.TabIndex = 29
        Me.btnVisa.TabStop = False
        Me.btnVisa.Tag = "10"
        '
        'btnEftPos
        '
        Me.btnEftPos.BackColor = System.Drawing.Color.Red
        Me.btnEftPos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEftPos.Image = Global.Room_Rent.My.Resources.Resources.eftpos
        Me.btnEftPos.Location = New System.Drawing.Point(3, 5)
        Me.btnEftPos.Name = "btnEftPos"
        Me.btnEftPos.Size = New System.Drawing.Size(59, 33)
        Me.btnEftPos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnEftPos.TabIndex = 29
        Me.btnEftPos.TabStop = False
        Me.btnEftPos.Tag = "10"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(259, 38)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(28, 9)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "Others"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(199, 38)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 9)
        Me.Label19.TabIndex = 31
        Me.Label19.Text = "AMEX"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(122, 38)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 9)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "MASTER CARD"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(82, 38)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(22, 9)
        Me.Label17.TabIndex = 31
        Me.Label17.Text = "VISA"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(14, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 9)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "EFT POS"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(91, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 26)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "TOTAL"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalExGST
        '
        Me.txtTotalExGST.AllowSpace = False
        Me.txtTotalExGST.DecimalSeparator = False
        Me.txtTotalExGST.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalExGST.GroupSeperator = False
        Me.txtTotalExGST.Location = New System.Drawing.Point(243, 161)
        Me.txtTotalExGST.Name = "txtTotalExGST"
        Me.txtTotalExGST.Negative = False
        Me.txtTotalExGST.ReadOnly = True
        Me.txtTotalExGST.Size = New System.Drawing.Size(120, 26)
        Me.txtTotalExGST.Space = False
        Me.txtTotalExGST.TabIndex = 36
        Me.txtTotalExGST.TabStop = False
        Me.txtTotalExGST.Text = "0.00"
        Me.txtTotalExGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGST
        '
        Me.txtGST.AllowSpace = False
        Me.txtGST.DecimalSeparator = False
        Me.txtGST.Enabled = False
        Me.txtGST.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGST.GroupSeperator = False
        Me.txtGST.Location = New System.Drawing.Point(243, 193)
        Me.txtGST.Name = "txtGST"
        Me.txtGST.Negative = False
        Me.txtGST.ReadOnly = True
        Me.txtGST.Size = New System.Drawing.Size(120, 26)
        Me.txtGST.Space = False
        Me.txtGST.TabIndex = 33
        Me.txtGST.TabStop = False
        Me.txtGST.Text = "0.00"
        Me.txtGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MyNumericKeyBoard1
        '
        Me.MyNumericKeyBoard1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.MyNumericKeyBoard1.Location = New System.Drawing.Point(178, 386)
        Me.MyNumericKeyBoard1.Name = "MyNumericKeyBoard1"
        Me.MyNumericKeyBoard1.Size = New System.Drawing.Size(402, 258)
        Me.MyNumericKeyBoard1.TabIndex = 27
        '
        'txtVoucherAmount
        '
        Me.txtVoucherAmount.AllowSpace = False
        Me.txtVoucherAmount.DecimalSeparator = False
        Me.txtVoucherAmount.Enabled = False
        Me.txtVoucherAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoucherAmount.GroupSeperator = False
        Me.txtVoucherAmount.Location = New System.Drawing.Point(536, 225)
        Me.txtVoucherAmount.Name = "txtVoucherAmount"
        Me.txtVoucherAmount.Negative = False
        Me.txtVoucherAmount.ReadOnly = True
        Me.txtVoucherAmount.Size = New System.Drawing.Size(120, 26)
        Me.txtVoucherAmount.Space = False
        Me.txtVoucherAmount.TabIndex = 10
        Me.txtVoucherAmount.Text = "0.00"
        Me.txtVoucherAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtVoucherAmount.Visible = False
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.AllowSpace = False
        Me.txtGrandTotal.DecimalSeparator = False
        Me.txtGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.GroupSeperator = False
        Me.txtGrandTotal.Location = New System.Drawing.Point(243, 320)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.Negative = False
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(120, 26)
        Me.txtGrandTotal.Space = False
        Me.txtGrandTotal.TabIndex = 100
        Me.txtGrandTotal.TabStop = False
        Me.txtGrandTotal.Text = "0.00"
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSurchargeAmt
        '
        Me.txtSurchargeAmt.AllowSpace = False
        Me.txtSurchargeAmt.DecimalSeparator = False
        Me.txtSurchargeAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurchargeAmt.GroupSeperator = False
        Me.txtSurchargeAmt.Location = New System.Drawing.Point(600, 225)
        Me.txtSurchargeAmt.Name = "txtSurchargeAmt"
        Me.txtSurchargeAmt.Negative = False
        Me.txtSurchargeAmt.ReadOnly = True
        Me.txtSurchargeAmt.Size = New System.Drawing.Size(56, 26)
        Me.txtSurchargeAmt.Space = False
        Me.txtSurchargeAmt.TabIndex = 0
        Me.txtSurchargeAmt.TabStop = False
        Me.txtSurchargeAmt.Text = "0.00"
        Me.txtSurchargeAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmountPaid
        '
        Me.txtAmountPaid.AllowSpace = False
        Me.txtAmountPaid.DecimalSeparator = False
        Me.txtAmountPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmountPaid.GroupSeperator = False
        Me.txtAmountPaid.Location = New System.Drawing.Point(536, 305)
        Me.txtAmountPaid.Name = "txtAmountPaid"
        Me.txtAmountPaid.Negative = False
        Me.txtAmountPaid.ReadOnly = True
        Me.txtAmountPaid.Size = New System.Drawing.Size(120, 26)
        Me.txtAmountPaid.Space = False
        Me.txtAmountPaid.TabIndex = 0
        Me.txtAmountPaid.TabStop = False
        Me.txtAmountPaid.Text = "0.00"
        Me.txtAmountPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCashOut
        '
        Me.txtCashOut.AllowSpace = False
        Me.txtCashOut.DecimalSeparator = True
        Me.txtCashOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashOut.GroupSeperator = False
        Me.txtCashOut.Location = New System.Drawing.Point(243, 288)
        Me.txtCashOut.Name = "txtCashOut"
        Me.txtCashOut.Negative = False
        Me.txtCashOut.Size = New System.Drawing.Size(120, 26)
        Me.txtCashOut.Space = False
        Me.txtCashOut.TabIndex = 2
        Me.txtCashOut.Text = "0.00"
        Me.txtCashOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSurchrgeP
        '
        Me.txtSurchrgeP.AllowSpace = False
        Me.txtSurchrgeP.DecimalSeparator = True
        Me.txtSurchrgeP.Enabled = False
        Me.txtSurchrgeP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurchrgeP.GroupSeperator = False
        Me.txtSurchrgeP.Location = New System.Drawing.Point(536, 225)
        Me.txtSurchrgeP.Name = "txtSurchrgeP"
        Me.txtSurchrgeP.Negative = False
        Me.txtSurchrgeP.Size = New System.Drawing.Size(50, 26)
        Me.txtSurchrgeP.Space = False
        Me.txtSurchrgeP.TabIndex = 0
        Me.txtSurchrgeP.TabStop = False
        Me.txtSurchrgeP.Text = "10.00"
        Me.txtSurchrgeP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTip
        '
        Me.txtTip.AllowSpace = False
        Me.txtTip.DecimalSeparator = True
        Me.txtTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTip.GroupSeperator = False
        Me.txtTip.Location = New System.Drawing.Point(243, 256)
        Me.txtTip.Name = "txtTip"
        Me.txtTip.Negative = False
        Me.txtTip.Size = New System.Drawing.Size(120, 26)
        Me.txtTip.Space = False
        Me.txtTip.TabIndex = 1
        Me.txtTip.Text = "0.00"
        Me.txtTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalInGST
        '
        Me.txtTotalInGST.AllowSpace = False
        Me.txtTotalInGST.DecimalSeparator = False
        Me.txtTotalInGST.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalInGST.GroupSeperator = False
        Me.txtTotalInGST.Location = New System.Drawing.Point(243, 224)
        Me.txtTotalInGST.Name = "txtTotalInGST"
        Me.txtTotalInGST.Negative = False
        Me.txtTotalInGST.ReadOnly = True
        Me.txtTotalInGST.Size = New System.Drawing.Size(120, 26)
        Me.txtTotalInGST.Space = False
        Me.txtTotalInGST.TabIndex = 0
        Me.txtTotalInGST.TabStop = False
        Me.txtTotalInGST.Text = "0.00"
        Me.txtTotalInGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCard
        '
        Me.txtCard.AllowSpace = False
        Me.txtCard.DecimalSeparator = True
        Me.txtCard.Enabled = False
        Me.txtCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCard.GroupSeperator = False
        Me.txtCard.Location = New System.Drawing.Point(536, 193)
        Me.txtCard.Name = "txtCard"
        Me.txtCard.Negative = False
        Me.txtCard.Size = New System.Drawing.Size(120, 26)
        Me.txtCard.Space = False
        Me.txtCard.TabIndex = 4
        Me.txtCard.Text = "0.00"
        Me.txtCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCash
        '
        Me.txtCash.AllowSpace = False
        Me.txtCash.DecimalSeparator = True
        Me.txtCash.Enabled = False
        Me.txtCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCash.GroupSeperator = False
        Me.txtCash.Location = New System.Drawing.Point(536, 161)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.Negative = False
        Me.txtCash.Size = New System.Drawing.Size(120, 26)
        Me.txtCash.Space = False
        Me.txtCash.TabIndex = 3
        Me.txtCash.Text = "0.00"
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmPaymentOthers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 669)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTotalExGST)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtGST)
        Me.Controls.Add(Me.MyNumericKeyBoard1)
        Me.Controls.Add(Me.btnVouchers)
        Me.Controls.Add(Me.txtVoucherAmount)
        Me.Controls.Add(Me.txtGrandTotal)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtSurchargeAmt)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAmountPaid)
        Me.Controls.Add(Me.txtCashOut)
        Me.Controls.Add(Me.txtSurchrgeP)
        Me.Controls.Add(Me.txtTip)
        Me.Controls.Add(Me.txtTotalInGST)
        Me.Controls.Add(Me.txtCard)
        Me.Controls.Add(Me.txtCash)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.grpPaymentMode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.pnlCards)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaymentOthers"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment"
        Me.grpPaymentMode.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.pnlCards.ResumeLayout(False)
        Me.pnlCards.PerformLayout()
        CType(Me.btnOthers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAmex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnMasterCard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnVisa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEftPos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpPaymentMode As System.Windows.Forms.GroupBox
    Friend WithEvents btnCardCash As System.Windows.Forms.Button
    Friend WithEvents btnCard As System.Windows.Forms.Button
    Friend WithEvents btnCash As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCash As Room_Rent.NumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCard As Room_Rent.NumericTextBox
    Friend WithEvents txtSurchrgeP As Room_Rent.NumericTextBox
    Friend WithEvents txtAmountPaid As Room_Rent.NumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTotalInGST As Room_Rent.NumericTextBox
    Friend WithEvents txtTip As Room_Rent.NumericTextBox
    Friend WithEvents txtCashOut As Room_Rent.NumericTextBox
    Friend WithEvents txtGrandTotal As Room_Rent.NumericTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSurchargeAmt As Room_Rent.NumericTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtVoucherAmount As Room_Rent.NumericTextBox
    Friend WithEvents btnVouchers As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MyNumericKeyBoard1 As Room_Rent.MyNumericKeyBoard
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtGST As Room_Rent.NumericTextBox
    Friend WithEvents pnlCards As System.Windows.Forms.Panel
    Friend WithEvents btnOthers As System.Windows.Forms.PictureBox
    Friend WithEvents btnAmex As System.Windows.Forms.PictureBox
    Friend WithEvents btnMasterCard As System.Windows.Forms.PictureBox
    Friend WithEvents btnVisa As System.Windows.Forms.PictureBox
    Friend WithEvents btnEftPos As System.Windows.Forms.PictureBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtTotalExGST As Room_Rent.NumericTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
