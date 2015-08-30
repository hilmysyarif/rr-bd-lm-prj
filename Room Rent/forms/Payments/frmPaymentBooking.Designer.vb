<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentBooking
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
        Me.lblTot = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblSP = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnVouchers = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtHouse2 = New Room_Rent.NumericTextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtWorkerAmount = New Room_Rent.NumericTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtHouse = New Room_Rent.NumericTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
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
        Me.Label21 = New System.Windows.Forms.Label()
        Me.btnContra = New System.Windows.Forms.Button()
        Me.btnDayPrice = New System.Windows.Forms.Button()
        Me.btnExcludeRoomExtra = New System.Windows.Forms.Button()
        Me.txtDoor = New Room_Rent.NumericTextBox()
        Me.txtTotalExGST = New Room_Rent.NumericTextBox()
        Me.txtGST = New Room_Rent.NumericTextBox()
        Me.txtUpgrade = New Room_Rent.NumericTextBox()
        Me.MyNumericKeyBoard1 = New Room_Rent.MyNumericKeyBoard()
        Me.txtVoucherAmount = New Room_Rent.NumericTextBox()
        Me.txtGrandTotal = New Room_Rent.NumericTextBox()
        Me.txtSurchargeAmt = New Room_Rent.NumericTextBox()
        Me.txtAmountPaid = New Room_Rent.NumericTextBox()
        Me.txtShiftFee = New Room_Rent.NumericTextBox()
        Me.txtCashOut = New Room_Rent.NumericTextBox()
        Me.txtSurchrgeP = New Room_Rent.NumericTextBox()
        Me.txtTip = New Room_Rent.NumericTextBox()
        Me.txtTotalInGST = New Room_Rent.NumericTextBox()
        Me.txtCard = New Room_Rent.NumericTextBox()
        Me.txtCash = New Room_Rent.NumericTextBox()
        Me.grpPaymentMode.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.grpPaymentMode.Location = New System.Drawing.Point(67, 59)
        Me.grpPaymentMode.Name = "grpPaymentMode"
        Me.grpPaymentMode.Size = New System.Drawing.Size(607, 80)
        Me.grpPaymentMode.TabIndex = 0
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
        Me.btnBack.Location = New System.Drawing.Point(5, 449)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(162, 112)
        Me.btnBack.TabIndex = 21
        Me.btnBack.Text = "GO BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(590, 449)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(162, 112)
        Me.btnNext.TabIndex = 20
        Me.btnNext.Text = "OK"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'lblTot
        '
        Me.lblTot.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTot.Location = New System.Drawing.Point(491, 2)
        Me.lblTot.Name = "lblTot"
        Me.lblTot.Size = New System.Drawing.Size(265, 55)
        Me.lblTot.TabIndex = 0
        Me.lblTot.Text = "Total : 120.00" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Total : 120.00"
        Me.lblTot.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(398, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 26)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "CASH"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(398, 233)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 26)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "CARD"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(398, 376)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(140, 26)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "PAYABLE AMT"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(79, 201)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(140, 26)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "TOTAL"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(79, 294)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 26)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "TIP"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(78, 264)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 26)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "CASH OUT"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(79, 357)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(185, 26)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "GRAND TOTAL"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(590, 297)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 26)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "%"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.lblSP)
        Me.Panel1.Controls.Add(Me.lblTot)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(760, 53)
        Me.Panel1.TabIndex = 19
        '
        'lblSP
        '
        Me.lblSP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSP.Location = New System.Drawing.Point(3, 4)
        Me.lblSP.Name = "lblSP"
        Me.lblSP.Size = New System.Drawing.Size(486, 46)
        Me.lblSP.TabIndex = 0
        Me.lblSP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 712)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(760, 22)
        Me.StatusStrip1.TabIndex = 20
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(398, 265)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(140, 26)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "VOUCHER AMT"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnVouchers
        '
        Me.btnVouchers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVouchers.Location = New System.Drawing.Point(663, 264)
        Me.btnVouchers.Name = "btnVouchers"
        Me.btnVouchers.Size = New System.Drawing.Size(30, 28)
        Me.btnVouchers.TabIndex = 23
        Me.btnVouchers.Text = "+"
        Me.btnVouchers.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtHouse2)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtWorkerAmount)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtHouse)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(68, 145)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(606, 50)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SPLIT INFO"
        '
        'txtHouse2
        '
        Me.txtHouse2.AllowSpace = False
        Me.txtHouse2.DecimalSeparator = False
        Me.txtHouse2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHouse2.GroupSeperator = False
        Me.txtHouse2.Location = New System.Drawing.Point(476, 18)
        Me.txtHouse2.Name = "txtHouse2"
        Me.txtHouse2.Negative = False
        Me.txtHouse2.ReadOnly = True
        Me.txtHouse2.Size = New System.Drawing.Size(120, 26)
        Me.txtHouse2.Space = False
        Me.txtHouse2.TabIndex = 1
        Me.txtHouse2.TabStop = False
        Me.txtHouse2.Text = "0.00"
        Me.txtHouse2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(330, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(172, 26)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = "HOUSE"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWorkerAmount
        '
        Me.txtWorkerAmount.AllowSpace = False
        Me.txtWorkerAmount.DecimalSeparator = False
        Me.txtWorkerAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWorkerAmount.GroupSeperator = False
        Me.txtWorkerAmount.Location = New System.Drawing.Point(163, 18)
        Me.txtWorkerAmount.Name = "txtWorkerAmount"
        Me.txtWorkerAmount.Negative = False
        Me.txtWorkerAmount.ReadOnly = True
        Me.txtWorkerAmount.Size = New System.Drawing.Size(120, 26)
        Me.txtWorkerAmount.Space = False
        Me.txtWorkerAmount.TabIndex = 0
        Me.txtWorkerAmount.TabStop = False
        Me.txtWorkerAmount.Text = "0.00"
        Me.txtWorkerAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 26)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "SP"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHouse
        '
        Me.txtHouse.AllowSpace = False
        Me.txtHouse.DecimalSeparator = False
        Me.txtHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHouse.GroupSeperator = False
        Me.txtHouse.Location = New System.Drawing.Point(307, 18)
        Me.txtHouse.Name = "txtHouse"
        Me.txtHouse.Negative = False
        Me.txtHouse.ReadOnly = True
        Me.txtHouse.Size = New System.Drawing.Size(120, 26)
        Me.txtHouse.Space = False
        Me.txtHouse.TabIndex = 0
        Me.txtHouse.TabStop = False
        Me.txtHouse.Text = "0.00"
        Me.txtHouse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtHouse.Visible = False
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(685, 131)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(140, 26)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "DOOR"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Visible = False
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(79, 357)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(140, 26)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "SHIFT FEE"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label12.Visible = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(395, 296)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 28)
        Me.Button1.TabIndex = 10
        Me.Button1.TabStop = False
        Me.Button1.Text = "ADMIN FEE"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(79, 326)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 26)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "UPGRADE"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.pnlCards.Location = New System.Drawing.Point(364, 321)
        Me.pnlCards.Name = "pnlCards"
        Me.pnlCards.Size = New System.Drawing.Size(305, 49)
        Me.pnlCards.TabIndex = 17
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
        Me.Label20.Location = New System.Drawing.Point(257, 38)
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
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(78, 233)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(140, 26)
        Me.Label21.TabIndex = 32
        Me.Label21.Text = "GST @ 10%"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnContra
        '
        Me.btnContra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnContra.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContra.Location = New System.Drawing.Point(231, 389)
        Me.btnContra.Name = "btnContra"
        Me.btnContra.Size = New System.Drawing.Size(120, 50)
        Me.btnContra.TabIndex = 19
        Me.btnContra.Text = "CONTRA"
        Me.btnContra.UseVisualStyleBackColor = True
        '
        'btnDayPrice
        '
        Me.btnDayPrice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDayPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDayPrice.Location = New System.Drawing.Point(67, 389)
        Me.btnDayPrice.Name = "btnDayPrice"
        Me.btnDayPrice.Size = New System.Drawing.Size(158, 50)
        Me.btnDayPrice.TabIndex = 18
        Me.btnDayPrice.Text = "DAY PRICE"
        Me.btnDayPrice.UseVisualStyleBackColor = True
        '
        'btnExcludeRoomExtra
        '
        Me.btnExcludeRoomExtra.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExcludeRoomExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcludeRoomExtra.Location = New System.Drawing.Point(366, 405)
        Me.btnExcludeRoomExtra.Name = "btnExcludeRoomExtra"
        Me.btnExcludeRoomExtra.Size = New System.Drawing.Size(298, 34)
        Me.btnExcludeRoomExtra.TabIndex = 36
        Me.btnExcludeRoomExtra.Text = "EXCLUDE EXTRA ROOM AMOUNT"
        Me.btnExcludeRoomExtra.UseVisualStyleBackColor = True
        Me.btnExcludeRoomExtra.Visible = False
        '
        'txtDoor
        '
        Me.txtDoor.AllowSpace = False
        Me.txtDoor.DecimalSeparator = False
        Me.txtDoor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDoor.GroupSeperator = False
        Me.txtDoor.Location = New System.Drawing.Point(689, 160)
        Me.txtDoor.Name = "txtDoor"
        Me.txtDoor.Negative = False
        Me.txtDoor.ReadOnly = True
        Me.txtDoor.Size = New System.Drawing.Size(88, 26)
        Me.txtDoor.Space = False
        Me.txtDoor.TabIndex = 0
        Me.txtDoor.TabStop = False
        Me.txtDoor.Text = "0.00"
        Me.txtDoor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtDoor.Visible = False
        '
        'txtTotalExGST
        '
        Me.txtTotalExGST.AllowSpace = False
        Me.txtTotalExGST.DecimalSeparator = False
        Me.txtTotalExGST.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalExGST.GroupSeperator = False
        Me.txtTotalExGST.Location = New System.Drawing.Point(231, 201)
        Me.txtTotalExGST.Name = "txtTotalExGST"
        Me.txtTotalExGST.Negative = False
        Me.txtTotalExGST.ReadOnly = True
        Me.txtTotalExGST.Size = New System.Drawing.Size(120, 26)
        Me.txtTotalExGST.Space = False
        Me.txtTotalExGST.TabIndex = 2
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
        Me.txtGST.Location = New System.Drawing.Point(231, 233)
        Me.txtGST.Name = "txtGST"
        Me.txtGST.Negative = False
        Me.txtGST.ReadOnly = True
        Me.txtGST.Size = New System.Drawing.Size(120, 26)
        Me.txtGST.Space = False
        Me.txtGST.TabIndex = 3
        Me.txtGST.TabStop = False
        Me.txtGST.Text = "0.00"
        Me.txtGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUpgrade
        '
        Me.txtUpgrade.AllowSpace = False
        Me.txtUpgrade.DecimalSeparator = True
        Me.txtUpgrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUpgrade.GroupSeperator = False
        Me.txtUpgrade.Location = New System.Drawing.Point(231, 326)
        Me.txtUpgrade.Name = "txtUpgrade"
        Me.txtUpgrade.Negative = False
        Me.txtUpgrade.Size = New System.Drawing.Size(120, 26)
        Me.txtUpgrade.Space = False
        Me.txtUpgrade.TabIndex = 5
        Me.txtUpgrade.Text = "0.00"
        Me.txtUpgrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MyNumericKeyBoard1
        '
        Me.MyNumericKeyBoard1.Location = New System.Drawing.Point(176, 450)
        Me.MyNumericKeyBoard1.Name = "MyNumericKeyBoard1"
        Me.MyNumericKeyBoard1.Size = New System.Drawing.Size(405, 257)
        Me.MyNumericKeyBoard1.TabIndex = 26
        '
        'txtVoucherAmount
        '
        Me.txtVoucherAmount.AllowSpace = False
        Me.txtVoucherAmount.DecimalSeparator = False
        Me.txtVoucherAmount.Enabled = False
        Me.txtVoucherAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoucherAmount.GroupSeperator = False
        Me.txtVoucherAmount.Location = New System.Drawing.Point(544, 265)
        Me.txtVoucherAmount.Name = "txtVoucherAmount"
        Me.txtVoucherAmount.Negative = False
        Me.txtVoucherAmount.ReadOnly = True
        Me.txtVoucherAmount.Size = New System.Drawing.Size(120, 26)
        Me.txtVoucherAmount.Space = False
        Me.txtVoucherAmount.TabIndex = 9
        Me.txtVoucherAmount.TabStop = False
        Me.txtVoucherAmount.Text = "0.00"
        Me.txtVoucherAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.AllowSpace = False
        Me.txtGrandTotal.DecimalSeparator = False
        Me.txtGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.GroupSeperator = False
        Me.txtGrandTotal.Location = New System.Drawing.Point(231, 357)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.Negative = False
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(120, 26)
        Me.txtGrandTotal.Space = False
        Me.txtGrandTotal.TabIndex = 6
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
        Me.txtSurchargeAmt.Location = New System.Drawing.Point(608, 297)
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
        Me.txtAmountPaid.Location = New System.Drawing.Point(544, 376)
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
        'txtShiftFee
        '
        Me.txtShiftFee.AllowSpace = False
        Me.txtShiftFee.DecimalSeparator = False
        Me.txtShiftFee.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShiftFee.GroupSeperator = False
        Me.txtShiftFee.Location = New System.Drawing.Point(231, 357)
        Me.txtShiftFee.Name = "txtShiftFee"
        Me.txtShiftFee.Negative = False
        Me.txtShiftFee.Size = New System.Drawing.Size(120, 26)
        Me.txtShiftFee.Space = False
        Me.txtShiftFee.TabIndex = 2
        Me.txtShiftFee.Text = "0.00"
        Me.txtShiftFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtShiftFee.Visible = False
        '
        'txtCashOut
        '
        Me.txtCashOut.AllowSpace = False
        Me.txtCashOut.DecimalSeparator = True
        Me.txtCashOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCashOut.GroupSeperator = False
        Me.txtCashOut.Location = New System.Drawing.Point(231, 264)
        Me.txtCashOut.Name = "txtCashOut"
        Me.txtCashOut.Negative = False
        Me.txtCashOut.Size = New System.Drawing.Size(120, 26)
        Me.txtCashOut.Space = False
        Me.txtCashOut.TabIndex = 1
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
        Me.txtSurchrgeP.Location = New System.Drawing.Point(544, 297)
        Me.txtSurchrgeP.Name = "txtSurchrgeP"
        Me.txtSurchrgeP.Negative = False
        Me.txtSurchrgeP.Size = New System.Drawing.Size(50, 26)
        Me.txtSurchrgeP.Space = False
        Me.txtSurchrgeP.TabIndex = 11
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
        Me.txtTip.Location = New System.Drawing.Point(231, 294)
        Me.txtTip.Name = "txtTip"
        Me.txtTip.Negative = False
        Me.txtTip.Size = New System.Drawing.Size(120, 26)
        Me.txtTip.Space = False
        Me.txtTip.TabIndex = 4
        Me.txtTip.Text = "0.00"
        Me.txtTip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalInGST
        '
        Me.txtTotalInGST.AllowSpace = False
        Me.txtTotalInGST.DecimalSeparator = False
        Me.txtTotalInGST.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalInGST.GroupSeperator = False
        Me.txtTotalInGST.Location = New System.Drawing.Point(689, 102)
        Me.txtTotalInGST.Name = "txtTotalInGST"
        Me.txtTotalInGST.Negative = False
        Me.txtTotalInGST.ReadOnly = True
        Me.txtTotalInGST.Size = New System.Drawing.Size(120, 26)
        Me.txtTotalInGST.Space = False
        Me.txtTotalInGST.TabIndex = 0
        Me.txtTotalInGST.TabStop = False
        Me.txtTotalInGST.Text = "0.00"
        Me.txtTotalInGST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalInGST.Visible = False
        '
        'txtCard
        '
        Me.txtCard.AllowSpace = False
        Me.txtCard.DecimalSeparator = True
        Me.txtCard.Enabled = False
        Me.txtCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCard.GroupSeperator = False
        Me.txtCard.Location = New System.Drawing.Point(544, 233)
        Me.txtCard.Name = "txtCard"
        Me.txtCard.Negative = False
        Me.txtCard.Size = New System.Drawing.Size(120, 26)
        Me.txtCard.Space = False
        Me.txtCard.TabIndex = 8
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
        Me.txtCash.Location = New System.Drawing.Point(544, 201)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.Negative = False
        Me.txtCash.Size = New System.Drawing.Size(120, 26)
        Me.txtCash.Space = False
        Me.txtCash.TabIndex = 7
        Me.txtCash.Text = "0.00"
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmPaymentBooking
        '
        Me.AcceptButton = Me.btnNext
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnBack
        Me.ClientSize = New System.Drawing.Size(760, 734)
        Me.Controls.Add(Me.btnExcludeRoomExtra)
        Me.Controls.Add(Me.btnDayPrice)
        Me.Controls.Add(Me.btnContra)
        Me.Controls.Add(Me.txtDoor)
        Me.Controls.Add(Me.txtTotalExGST)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtGST)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtUpgrade)
        Me.Controls.Add(Me.MyNumericKeyBoard1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtVoucherAmount)
        Me.Controls.Add(Me.txtGrandTotal)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtSurchargeAmt)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAmountPaid)
        Me.Controls.Add(Me.txtShiftFee)
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
        Me.Controls.Add(Me.btnVouchers)
        Me.Controls.Add(Me.pnlCards)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaymentBooking"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment"
        Me.grpPaymentMode.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents lblTot As System.Windows.Forms.Label
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtShiftFee As Room_Rent.NumericTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtWorkerAmount As Room_Rent.NumericTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtDoor As Room_Rent.NumericTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtHouse As Room_Rent.NumericTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MyNumericKeyBoard1 As Room_Rent.MyNumericKeyBoard
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtUpgrade As Room_Rent.NumericTextBox
    Friend WithEvents btnEftPos As System.Windows.Forms.PictureBox
    Friend WithEvents btnVisa As System.Windows.Forms.PictureBox
    Friend WithEvents btnMasterCard As System.Windows.Forms.PictureBox
    Friend WithEvents btnAmex As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCards As System.Windows.Forms.Panel
    Friend WithEvents btnOthers As System.Windows.Forms.PictureBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtGST As Room_Rent.NumericTextBox
    Friend WithEvents txtTotalExGST As Room_Rent.NumericTextBox
    Friend WithEvents btnContra As System.Windows.Forms.Button
    Friend WithEvents btnDayPrice As System.Windows.Forms.Button
    Friend WithEvents lblSP As System.Windows.Forms.Label
    Friend WithEvents btnExcludeRoomExtra As System.Windows.Forms.Button
    Friend WithEvents txtHouse2 As Room_Rent.NumericTextBox
End Class
