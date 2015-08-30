<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBooking
    Inherits Room_Rent.frmMainMaster

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
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("fvxcv cbbcvbcvb")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("cvbcvbcvbcvb")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("cvbcvxcvxcbcvb")
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpServiceProvider = New System.Windows.Forms.GroupBox()
        Me.txtNewServiceProviderName = New System.Windows.Forms.TextBox()
        Me.lstServiceProvider = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnDoneServiceProvider = New System.Windows.Forms.Button()
        Me.btnDeleteServiceProvider = New System.Windows.Forms.Button()
        Me.btnAddServiceProvider = New System.Windows.Forms.Button()
        Me.grpRoom = New System.Windows.Forms.GroupBox()
        Me.btnRoom11 = New System.Windows.Forms.Button()
        Me.btnRoom10 = New System.Windows.Forms.Button()
        Me.btnRoom9 = New System.Windows.Forms.Button()
        Me.btnRoom8 = New System.Windows.Forms.Button()
        Me.btnRoom7 = New System.Windows.Forms.Button()
        Me.btnRoom6 = New System.Windows.Forms.Button()
        Me.btnRoom5 = New System.Windows.Forms.Button()
        Me.btnRoom4 = New System.Windows.Forms.Button()
        Me.btnAFR = New System.Windows.Forms.Button()
        Me.btnASI = New System.Windows.Forms.Button()
        Me.btnEGY = New System.Windows.Forms.Button()
        Me.btnPen = New System.Windows.Forms.Button()
        Me.grpService = New System.Windows.Forms.GroupBox()
        Me.btnCustomMin = New System.Windows.Forms.Button()
        Me.btn120Min = New System.Windows.Forms.Button()
        Me.btn90Min = New System.Windows.Forms.Button()
        Me.btn60Min = New System.Windows.Forms.Button()
        Me.btn45Min = New System.Windows.Forms.Button()
        Me.btn30Min = New System.Windows.Forms.Button()
        Me.grpDoorCharges = New System.Windows.Forms.GroupBox()
        Me.btnLounge = New System.Windows.Forms.Button()
        Me.btnPrivate = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.grpPayment = New System.Windows.Forms.GroupBox()
        Me.pnlPaymentMode = New System.Windows.Forms.Panel()
        Me.btnCard = New System.Windows.Forms.Button()
        Me.btnCash = New System.Windows.Forms.Button()
        Me.lblTotalPrice = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpQueuedItems = New System.Windows.Forms.GroupBox()
        Me.btnDeleteBooking = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lnkService = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lnkRoom = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lnkServiceProvider = New System.Windows.Forms.LinkLabel()
        Me.btnClearBooking = New System.Windows.Forms.Button()
        Me.lblQueuedQTY = New System.Windows.Forms.Label()
        Me.lblQueuedQtyText = New System.Windows.Forms.Label()
        Me.btnConfirm = New System.Windows.Forms.Button()
        Me.dgQueuedBooking = New System.Windows.Forms.DataGridView()
        Me.SERVICEWORKER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ROOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SERVICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMELEFT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMEADDED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Door = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmrTimeLeftCounter = New System.Windows.Forms.Timer(Me.components)
        Me.tmrRefreshActive = New System.Windows.Forms.Timer(Me.components)
        Me.grpServiceProvider.SuspendLayout()
        Me.grpRoom.SuspendLayout()
        Me.grpService.SuspendLayout()
        Me.grpDoorCharges.SuspendLayout()
        Me.grpPayment.SuspendLayout()
        Me.pnlPaymentMode.SuspendLayout()
        Me.grpQueuedItems.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgQueuedBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpServiceProvider
        '
        Me.grpServiceProvider.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpServiceProvider.Controls.Add(Me.txtNewServiceProviderName)
        Me.grpServiceProvider.Controls.Add(Me.lstServiceProvider)
        Me.grpServiceProvider.Controls.Add(Me.btnDoneServiceProvider)
        Me.grpServiceProvider.Controls.Add(Me.btnDeleteServiceProvider)
        Me.grpServiceProvider.Controls.Add(Me.btnAddServiceProvider)
        Me.grpServiceProvider.Location = New System.Drawing.Point(9, 80)
        Me.grpServiceProvider.Name = "grpServiceProvider"
        Me.grpServiceProvider.Size = New System.Drawing.Size(293, 474)
        Me.grpServiceProvider.TabIndex = 2
        Me.grpServiceProvider.TabStop = False
        Me.grpServiceProvider.Text = "SERVICE PROVIDERS (STEP 1)"
        '
        'txtNewServiceProviderName
        '
        Me.txtNewServiceProviderName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNewServiceProviderName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewServiceProviderName.Location = New System.Drawing.Point(3, 393)
        Me.txtNewServiceProviderName.Name = "txtNewServiceProviderName"
        Me.txtNewServiceProviderName.Size = New System.Drawing.Size(284, 20)
        Me.txtNewServiceProviderName.TabIndex = 7
        '
        'lstServiceProvider
        '
        Me.lstServiceProvider.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstServiceProvider.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstServiceProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstServiceProvider.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstServiceProvider.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
        Me.lstServiceProvider.Location = New System.Drawing.Point(3, 16)
        Me.lstServiceProvider.MultiSelect = False
        Me.lstServiceProvider.Name = "lstServiceProvider"
        Me.lstServiceProvider.Size = New System.Drawing.Size(284, 375)
        Me.lstServiceProvider.TabIndex = 6
        Me.lstServiceProvider.UseCompatibleStateImageBehavior = False
        Me.lstServiceProvider.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 280
        '
        'btnDoneServiceProvider
        '
        Me.btnDoneServiceProvider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDoneServiceProvider.Location = New System.Drawing.Point(196, 416)
        Me.btnDoneServiceProvider.Name = "btnDoneServiceProvider"
        Me.btnDoneServiceProvider.Size = New System.Drawing.Size(75, 52)
        Me.btnDoneServiceProvider.TabIndex = 5
        Me.btnDoneServiceProvider.Text = "DONE"
        Me.btnDoneServiceProvider.UseVisualStyleBackColor = True
        '
        'btnDeleteServiceProvider
        '
        Me.btnDeleteServiceProvider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteServiceProvider.Location = New System.Drawing.Point(105, 416)
        Me.btnDeleteServiceProvider.Name = "btnDeleteServiceProvider"
        Me.btnDeleteServiceProvider.Size = New System.Drawing.Size(75, 52)
        Me.btnDeleteServiceProvider.TabIndex = 4
        Me.btnDeleteServiceProvider.Text = "DELETE"
        Me.btnDeleteServiceProvider.UseVisualStyleBackColor = True
        '
        'btnAddServiceProvider
        '
        Me.btnAddServiceProvider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddServiceProvider.Location = New System.Drawing.Point(10, 416)
        Me.btnAddServiceProvider.Name = "btnAddServiceProvider"
        Me.btnAddServiceProvider.Size = New System.Drawing.Size(75, 52)
        Me.btnAddServiceProvider.TabIndex = 3
        Me.btnAddServiceProvider.Text = "ADD"
        Me.btnAddServiceProvider.UseVisualStyleBackColor = True
        '
        'grpRoom
        '
        Me.grpRoom.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.grpRoom.Controls.Add(Me.btnRoom11)
        Me.grpRoom.Controls.Add(Me.btnRoom10)
        Me.grpRoom.Controls.Add(Me.btnRoom9)
        Me.grpRoom.Controls.Add(Me.btnRoom8)
        Me.grpRoom.Controls.Add(Me.btnRoom7)
        Me.grpRoom.Controls.Add(Me.btnRoom6)
        Me.grpRoom.Controls.Add(Me.btnRoom5)
        Me.grpRoom.Controls.Add(Me.btnRoom4)
        Me.grpRoom.Controls.Add(Me.btnAFR)
        Me.grpRoom.Controls.Add(Me.btnASI)
        Me.grpRoom.Controls.Add(Me.btnEGY)
        Me.grpRoom.Controls.Add(Me.btnPen)
        Me.grpRoom.Enabled = False
        Me.grpRoom.Location = New System.Drawing.Point(308, 80)
        Me.grpRoom.Name = "grpRoom"
        Me.grpRoom.Size = New System.Drawing.Size(265, 230)
        Me.grpRoom.TabIndex = 3
        Me.grpRoom.TabStop = False
        Me.grpRoom.Text = "ROOM (STEP 2)"
        '
        'btnRoom11
        '
        Me.btnRoom11.Location = New System.Drawing.Point(148, 181)
        Me.btnRoom11.Name = "btnRoom11"
        Me.btnRoom11.Size = New System.Drawing.Size(105, 33)
        Me.btnRoom11.TabIndex = 11
        Me.btnRoom11.Text = "ACCOMODATION"
        Me.btnRoom11.UseVisualStyleBackColor = True
        '
        'btnRoom10
        '
        Me.btnRoom10.Location = New System.Drawing.Point(148, 148)
        Me.btnRoom10.Name = "btnRoom10"
        Me.btnRoom10.Size = New System.Drawing.Size(105, 33)
        Me.btnRoom10.TabIndex = 10
        Me.btnRoom10.Text = "ACCOMODATION"
        Me.btnRoom10.UseVisualStyleBackColor = True
        '
        'btnRoom9
        '
        Me.btnRoom9.Location = New System.Drawing.Point(148, 115)
        Me.btnRoom9.Name = "btnRoom9"
        Me.btnRoom9.Size = New System.Drawing.Size(105, 33)
        Me.btnRoom9.TabIndex = 9
        Me.btnRoom9.Text = "ACCOMODATION"
        Me.btnRoom9.UseVisualStyleBackColor = True
        '
        'btnRoom8
        '
        Me.btnRoom8.Location = New System.Drawing.Point(148, 82)
        Me.btnRoom8.Name = "btnRoom8"
        Me.btnRoom8.Size = New System.Drawing.Size(105, 33)
        Me.btnRoom8.TabIndex = 8
        Me.btnRoom8.Text = "ACCOMODATION"
        Me.btnRoom8.UseVisualStyleBackColor = True
        '
        'btnRoom7
        '
        Me.btnRoom7.Location = New System.Drawing.Point(148, 49)
        Me.btnRoom7.Name = "btnRoom7"
        Me.btnRoom7.Size = New System.Drawing.Size(105, 33)
        Me.btnRoom7.TabIndex = 7
        Me.btnRoom7.Text = "ACCOMODATION"
        Me.btnRoom7.UseVisualStyleBackColor = True
        '
        'btnRoom6
        '
        Me.btnRoom6.Location = New System.Drawing.Point(148, 16)
        Me.btnRoom6.Name = "btnRoom6"
        Me.btnRoom6.Size = New System.Drawing.Size(105, 33)
        Me.btnRoom6.TabIndex = 6
        Me.btnRoom6.Text = "ACCOMODATION"
        Me.btnRoom6.UseVisualStyleBackColor = True
        '
        'btnRoom5
        '
        Me.btnRoom5.Location = New System.Drawing.Point(13, 181)
        Me.btnRoom5.Name = "btnRoom5"
        Me.btnRoom5.Size = New System.Drawing.Size(105, 33)
        Me.btnRoom5.TabIndex = 5
        Me.btnRoom5.Text = "?????"
        Me.btnRoom5.UseVisualStyleBackColor = True
        '
        'btnRoom4
        '
        Me.btnRoom4.Location = New System.Drawing.Point(13, 148)
        Me.btnRoom4.Name = "btnRoom4"
        Me.btnRoom4.Size = New System.Drawing.Size(105, 33)
        Me.btnRoom4.TabIndex = 4
        Me.btnRoom4.Text = "?????"
        Me.btnRoom4.UseVisualStyleBackColor = True
        '
        'btnAFR
        '
        Me.btnAFR.Location = New System.Drawing.Point(13, 115)
        Me.btnAFR.Name = "btnAFR"
        Me.btnAFR.Size = New System.Drawing.Size(105, 33)
        Me.btnAFR.TabIndex = 3
        Me.btnAFR.Tag = "3.5"
        Me.btnAFR.Text = "AFR"
        Me.btnAFR.UseVisualStyleBackColor = True
        '
        'btnASI
        '
        Me.btnASI.Location = New System.Drawing.Point(13, 82)
        Me.btnASI.Name = "btnASI"
        Me.btnASI.Size = New System.Drawing.Size(105, 33)
        Me.btnASI.TabIndex = 2
        Me.btnASI.Tag = "3"
        Me.btnASI.Text = "ASI"
        Me.btnASI.UseVisualStyleBackColor = True
        '
        'btnEGY
        '
        Me.btnEGY.Location = New System.Drawing.Point(13, 49)
        Me.btnEGY.Name = "btnEGY"
        Me.btnEGY.Size = New System.Drawing.Size(105, 33)
        Me.btnEGY.TabIndex = 1
        Me.btnEGY.Tag = "2.5"
        Me.btnEGY.Text = "EGY"
        Me.btnEGY.UseVisualStyleBackColor = True
        '
        'btnPen
        '
        Me.btnPen.BackColor = System.Drawing.Color.Maroon
        Me.btnPen.Location = New System.Drawing.Point(13, 16)
        Me.btnPen.Name = "btnPen"
        Me.btnPen.Size = New System.Drawing.Size(105, 33)
        Me.btnPen.TabIndex = 0
        Me.btnPen.Tag = "2"
        Me.btnPen.Text = "PEN"
        Me.btnPen.UseVisualStyleBackColor = True
        '
        'grpService
        '
        Me.grpService.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpService.BackColor = System.Drawing.Color.Maroon
        Me.grpService.Controls.Add(Me.btnCustomMin)
        Me.grpService.Controls.Add(Me.btn120Min)
        Me.grpService.Controls.Add(Me.btn90Min)
        Me.grpService.Controls.Add(Me.btn60Min)
        Me.grpService.Controls.Add(Me.btn45Min)
        Me.grpService.Controls.Add(Me.btn30Min)
        Me.grpService.Enabled = False
        Me.grpService.Location = New System.Drawing.Point(308, 316)
        Me.grpService.Name = "grpService"
        Me.grpService.Size = New System.Drawing.Size(130, 238)
        Me.grpService.TabIndex = 4
        Me.grpService.TabStop = False
        Me.grpService.Text = "SERVICE (STEP 3)"
        '
        'btnCustomMin
        '
        Me.btnCustomMin.Location = New System.Drawing.Point(13, 184)
        Me.btnCustomMin.Name = "btnCustomMin"
        Me.btnCustomMin.Size = New System.Drawing.Size(105, 33)
        Me.btnCustomMin.TabIndex = 5
        Me.btnCustomMin.Tag = ""
        Me.btnCustomMin.Text = "CUSTOM"
        Me.btnCustomMin.UseVisualStyleBackColor = True
        '
        'btn120Min
        '
        Me.btn120Min.Location = New System.Drawing.Point(13, 151)
        Me.btn120Min.Name = "btn120Min"
        Me.btn120Min.Size = New System.Drawing.Size(105, 33)
        Me.btn120Min.TabIndex = 4
        Me.btn120Min.Tag = "120"
        Me.btn120Min.Text = "120 MINS"
        Me.btn120Min.UseVisualStyleBackColor = True
        '
        'btn90Min
        '
        Me.btn90Min.Location = New System.Drawing.Point(13, 118)
        Me.btn90Min.Name = "btn90Min"
        Me.btn90Min.Size = New System.Drawing.Size(105, 33)
        Me.btn90Min.TabIndex = 3
        Me.btn90Min.Tag = "90"
        Me.btn90Min.Text = "90 MINS"
        Me.btn90Min.UseVisualStyleBackColor = True
        '
        'btn60Min
        '
        Me.btn60Min.Location = New System.Drawing.Point(13, 85)
        Me.btn60Min.Name = "btn60Min"
        Me.btn60Min.Size = New System.Drawing.Size(105, 33)
        Me.btn60Min.TabIndex = 2
        Me.btn60Min.Tag = "60"
        Me.btn60Min.Text = "60 MINS"
        Me.btn60Min.UseVisualStyleBackColor = True
        '
        'btn45Min
        '
        Me.btn45Min.Location = New System.Drawing.Point(13, 52)
        Me.btn45Min.Name = "btn45Min"
        Me.btn45Min.Size = New System.Drawing.Size(105, 33)
        Me.btn45Min.TabIndex = 1
        Me.btn45Min.Tag = "45"
        Me.btn45Min.Text = "45 MINS"
        Me.btn45Min.UseVisualStyleBackColor = True
        '
        'btn30Min
        '
        Me.btn30Min.Location = New System.Drawing.Point(13, 19)
        Me.btn30Min.Name = "btn30Min"
        Me.btn30Min.Size = New System.Drawing.Size(105, 33)
        Me.btn30Min.TabIndex = 0
        Me.btn30Min.Tag = "30"
        Me.btn30Min.Text = "30 MINS"
        Me.btn30Min.UseVisualStyleBackColor = True
        '
        'grpDoorCharges
        '
        Me.grpDoorCharges.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpDoorCharges.BackColor = System.Drawing.Color.Olive
        Me.grpDoorCharges.Controls.Add(Me.btnLounge)
        Me.grpDoorCharges.Controls.Add(Me.btnPrivate)
        Me.grpDoorCharges.Location = New System.Drawing.Point(443, 316)
        Me.grpDoorCharges.Name = "grpDoorCharges"
        Me.grpDoorCharges.Size = New System.Drawing.Size(130, 238)
        Me.grpDoorCharges.TabIndex = 5
        Me.grpDoorCharges.TabStop = False
        Me.grpDoorCharges.Text = "DOOR CHARGES (STEP 4)"
        '
        'btnLounge
        '
        Me.btnLounge.Location = New System.Drawing.Point(13, 67)
        Me.btnLounge.Name = "btnLounge"
        Me.btnLounge.Size = New System.Drawing.Size(105, 33)
        Me.btnLounge.TabIndex = 1
        Me.btnLounge.Tag = "20.00"
        Me.btnLounge.Text = "LOUNGE"
        Me.btnLounge.UseVisualStyleBackColor = True
        '
        'btnPrivate
        '
        Me.btnPrivate.Location = New System.Drawing.Point(13, 34)
        Me.btnPrivate.Name = "btnPrivate"
        Me.btnPrivate.Size = New System.Drawing.Size(105, 33)
        Me.btnPrivate.TabIndex = 0
        Me.btnPrivate.Tag = "10.00"
        Me.btnPrivate.Text = "PRIVATE"
        Me.btnPrivate.UseVisualStyleBackColor = True
        '
        'Button23
        '
        Me.Button23.Enabled = False
        Me.Button23.Location = New System.Drawing.Point(16, 283)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(111, 38)
        Me.Button23.TabIndex = 4
        Me.Button23.Text = "PRINT"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'grpPayment
        '
        Me.grpPayment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpPayment.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.grpPayment.Controls.Add(Me.pnlPaymentMode)
        Me.grpPayment.Controls.Add(Me.Button23)
        Me.grpPayment.Controls.Add(Me.lblTotalPrice)
        Me.grpPayment.Controls.Add(Me.Label1)
        Me.grpPayment.Location = New System.Drawing.Point(579, 80)
        Me.grpPayment.Name = "grpPayment"
        Me.grpPayment.Size = New System.Drawing.Size(145, 474)
        Me.grpPayment.TabIndex = 7
        Me.grpPayment.TabStop = False
        Me.grpPayment.Text = "PAYMENT (STEP 5)"
        '
        'pnlPaymentMode
        '
        Me.pnlPaymentMode.Controls.Add(Me.btnCard)
        Me.pnlPaymentMode.Controls.Add(Me.btnCash)
        Me.pnlPaymentMode.Location = New System.Drawing.Point(11, 17)
        Me.pnlPaymentMode.Name = "pnlPaymentMode"
        Me.pnlPaymentMode.Size = New System.Drawing.Size(124, 121)
        Me.pnlPaymentMode.TabIndex = 5
        '
        'btnCard
        '
        Me.btnCard.Location = New System.Drawing.Point(5, 66)
        Me.btnCard.Name = "btnCard"
        Me.btnCard.Size = New System.Drawing.Size(111, 38)
        Me.btnCard.TabIndex = 1
        Me.btnCard.Text = "CARD"
        Me.btnCard.UseVisualStyleBackColor = True
        '
        'btnCash
        '
        Me.btnCash.Location = New System.Drawing.Point(5, 2)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(111, 38)
        Me.btnCash.TabIndex = 0
        Me.btnCash.Text = "CASH"
        Me.btnCash.UseVisualStyleBackColor = True
        '
        'lblTotalPrice
        '
        Me.lblTotalPrice.AutoSize = True
        Me.lblTotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPrice.ForeColor = System.Drawing.Color.Red
        Me.lblTotalPrice.Location = New System.Drawing.Point(21, 194)
        Me.lblTotalPrice.Name = "lblTotalPrice"
        Me.lblTotalPrice.Size = New System.Drawing.Size(82, 31)
        Me.lblTotalPrice.TabIndex = 4
        Me.lblTotalPrice.Text = "$0.00"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TOTAL:"
        '
        'grpQueuedItems
        '
        Me.grpQueuedItems.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpQueuedItems.Controls.Add(Me.btnDeleteBooking)
        Me.grpQueuedItems.Controls.Add(Me.Panel1)
        Me.grpQueuedItems.Controls.Add(Me.btnClearBooking)
        Me.grpQueuedItems.Controls.Add(Me.lblQueuedQTY)
        Me.grpQueuedItems.Controls.Add(Me.lblQueuedQtyText)
        Me.grpQueuedItems.Controls.Add(Me.btnConfirm)
        Me.grpQueuedItems.Controls.Add(Me.dgQueuedBooking)
        Me.grpQueuedItems.Location = New System.Drawing.Point(730, 80)
        Me.grpQueuedItems.Name = "grpQueuedItems"
        Me.grpQueuedItems.Size = New System.Drawing.Size(567, 474)
        Me.grpQueuedItems.TabIndex = 9
        Me.grpQueuedItems.TabStop = False
        Me.grpQueuedItems.Text = "QUEUED BOOKINGS"
        '
        'btnDeleteBooking
        '
        Me.btnDeleteBooking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteBooking.Location = New System.Drawing.Point(197, 412)
        Me.btnDeleteBooking.Name = "btnDeleteBooking"
        Me.btnDeleteBooking.Size = New System.Drawing.Size(85, 52)
        Me.btnDeleteBooking.TabIndex = 7
        Me.btnDeleteBooking.Text = "DELETE BOOKING"
        Me.btnDeleteBooking.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.lnkService)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.lnkRoom)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lnkServiceProvider)
        Me.Panel1.Location = New System.Drawing.Point(3, 364)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(558, 20)
        Me.Panel1.TabIndex = 6
        '
        'lnkService
        '
        Me.lnkService.AutoSize = True
        Me.lnkService.Dock = System.Windows.Forms.DockStyle.Left
        Me.lnkService.Location = New System.Drawing.Point(38, 0)
        Me.lnkService.Name = "lnkService"
        Me.lnkService.Size = New System.Drawing.Size(0, 13)
        Me.lnkService.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(19, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = ">>"
        '
        'lnkRoom
        '
        Me.lnkRoom.AutoSize = True
        Me.lnkRoom.Dock = System.Windows.Forms.DockStyle.Left
        Me.lnkRoom.Location = New System.Drawing.Point(19, 0)
        Me.lnkRoom.Name = "lnkRoom"
        Me.lnkRoom.Size = New System.Drawing.Size(0, 13)
        Me.lnkRoom.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ">>"
        '
        'lnkServiceProvider
        '
        Me.lnkServiceProvider.AutoSize = True
        Me.lnkServiceProvider.Dock = System.Windows.Forms.DockStyle.Left
        Me.lnkServiceProvider.Location = New System.Drawing.Point(0, 0)
        Me.lnkServiceProvider.Name = "lnkServiceProvider"
        Me.lnkServiceProvider.Size = New System.Drawing.Size(0, 13)
        Me.lnkServiceProvider.TabIndex = 0
        '
        'btnClearBooking
        '
        Me.btnClearBooking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClearBooking.Location = New System.Drawing.Point(106, 412)
        Me.btnClearBooking.Name = "btnClearBooking"
        Me.btnClearBooking.Size = New System.Drawing.Size(85, 52)
        Me.btnClearBooking.TabIndex = 5
        Me.btnClearBooking.Text = "CLEAR BOOKING"
        Me.btnClearBooking.UseVisualStyleBackColor = True
        '
        'lblQueuedQTY
        '
        Me.lblQueuedQTY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQueuedQTY.AutoSize = True
        Me.lblQueuedQTY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueuedQTY.Location = New System.Drawing.Point(549, 387)
        Me.lblQueuedQTY.Name = "lblQueuedQTY"
        Me.lblQueuedQTY.Size = New System.Drawing.Size(15, 16)
        Me.lblQueuedQTY.TabIndex = 4
        Me.lblQueuedQTY.Text = "0"
        '
        'lblQueuedQtyText
        '
        Me.lblQueuedQtyText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQueuedQtyText.AutoSize = True
        Me.lblQueuedQtyText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQueuedQtyText.Location = New System.Drawing.Point(374, 387)
        Me.lblQueuedQtyText.Name = "lblQueuedQtyText"
        Me.lblQueuedQtyText.Size = New System.Drawing.Size(160, 16)
        Me.lblQueuedQtyText.TabIndex = 3
        Me.lblQueuedQtyText.Text = "QUEUED BOOKING QTY"
        '
        'btnConfirm
        '
        Me.btnConfirm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnConfirm.Location = New System.Drawing.Point(15, 412)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.Size = New System.Drawing.Size(85, 52)
        Me.btnConfirm.TabIndex = 2
        Me.btnConfirm.Text = "CONFIRM BOOKING"
        Me.btnConfirm.UseVisualStyleBackColor = True
        '
        'dgQueuedBooking
        '
        Me.dgQueuedBooking.AllowUserToAddRows = False
        Me.dgQueuedBooking.AllowUserToDeleteRows = False
        Me.dgQueuedBooking.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgQueuedBooking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgQueuedBooking.BackgroundColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgQueuedBooking.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgQueuedBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgQueuedBooking.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SERVICEWORKER, Me.ROOM, Me.SERVICE, Me.TIMELEFT, Me.TIMEADDED, Me.Door, Me.Column1, Me.Column2, Me.STATUS})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgQueuedBooking.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgQueuedBooking.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgQueuedBooking.Location = New System.Drawing.Point(3, 16)
        Me.dgQueuedBooking.Name = "dgQueuedBooking"
        Me.dgQueuedBooking.RowHeadersVisible = False
        Me.dgQueuedBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgQueuedBooking.Size = New System.Drawing.Size(558, 342)
        Me.dgQueuedBooking.TabIndex = 0
        '
        'SERVICEWORKER
        '
        Me.SERVICEWORKER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.NullValue = Nothing
        Me.SERVICEWORKER.DefaultCellStyle = DataGridViewCellStyle2
        Me.SERVICEWORKER.HeaderText = "SERVICE WORKER"
        Me.SERVICEWORKER.Name = "SERVICEWORKER"
        Me.SERVICEWORKER.Width = 130
        '
        'ROOM
        '
        Me.ROOM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ROOM.HeaderText = "ROOM"
        Me.ROOM.Name = "ROOM"
        Me.ROOM.Width = 65
        '
        'SERVICE
        '
        Me.SERVICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SERVICE.HeaderText = "SERVICE"
        Me.SERVICE.Name = "SERVICE"
        Me.SERVICE.Width = 78
        '
        'TIMELEFT
        '
        Me.TIMELEFT.HeaderText = "TIME LEFT"
        Me.TIMELEFT.Name = "TIMELEFT"
        '
        'TIMEADDED
        '
        Me.TIMEADDED.HeaderText = "TIME ADDED"
        Me.TIMEADDED.Name = "TIMEADDED"
        Me.TIMEADDED.ReadOnly = True
        Me.TIMEADDED.Visible = False
        '
        'Door
        '
        Me.Door.HeaderText = "DOOR"
        Me.Door.Name = "Door"
        Me.Door.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "DOORCHARGE"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "BOOKINGID"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'STATUS
        '
        Me.STATUS.HeaderText = "STATUS"
        Me.STATUS.Name = "STATUS"
        Me.STATUS.ReadOnly = True
        '
        'tmrTimeLeftCounter
        '
        Me.tmrTimeLeftCounter.Interval = 20000
        '
        'tmrRefreshActive
        '
        Me.tmrRefreshActive.Enabled = True
        Me.tmrRefreshActive.Interval = 60000
        '
        'frmBooking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1306, 560)
        Me.Controls.Add(Me.grpQueuedItems)
        Me.Controls.Add(Me.grpPayment)
        Me.Controls.Add(Me.grpDoorCharges)
        Me.Controls.Add(Me.grpService)
        Me.Controls.Add(Me.grpRoom)
        Me.Controls.Add(Me.grpServiceProvider)
        Me.Name = "frmBooking"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.grpServiceProvider, 0)
        Me.Controls.SetChildIndex(Me.grpRoom, 0)
        Me.Controls.SetChildIndex(Me.grpService, 0)
        Me.Controls.SetChildIndex(Me.grpDoorCharges, 0)
        Me.Controls.SetChildIndex(Me.grpPayment, 0)
        Me.Controls.SetChildIndex(Me.grpQueuedItems, 0)
        Me.grpServiceProvider.ResumeLayout(False)
        Me.grpServiceProvider.PerformLayout()
        Me.grpRoom.ResumeLayout(False)
        Me.grpService.ResumeLayout(False)
        Me.grpDoorCharges.ResumeLayout(False)
        Me.grpPayment.ResumeLayout(False)
        Me.grpPayment.PerformLayout()
        Me.pnlPaymentMode.ResumeLayout(False)
        Me.grpQueuedItems.ResumeLayout(False)
        Me.grpQueuedItems.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgQueuedBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpServiceProvider As System.Windows.Forms.GroupBox
    Friend WithEvents txtNewServiceProviderName As System.Windows.Forms.TextBox
    Friend WithEvents lstServiceProvider As System.Windows.Forms.ListView
    Friend WithEvents btnDoneServiceProvider As System.Windows.Forms.Button
    Friend WithEvents btnDeleteServiceProvider As System.Windows.Forms.Button
    Friend WithEvents btnAddServiceProvider As System.Windows.Forms.Button
    Friend WithEvents grpRoom As System.Windows.Forms.GroupBox
    Friend WithEvents btnRoom11 As System.Windows.Forms.Button
    Friend WithEvents btnRoom10 As System.Windows.Forms.Button
    Friend WithEvents btnRoom9 As System.Windows.Forms.Button
    Friend WithEvents btnRoom8 As System.Windows.Forms.Button
    Friend WithEvents btnRoom7 As System.Windows.Forms.Button
    Friend WithEvents btnRoom6 As System.Windows.Forms.Button
    Friend WithEvents btnRoom5 As System.Windows.Forms.Button
    Friend WithEvents btnRoom4 As System.Windows.Forms.Button
    Friend WithEvents btnAFR As System.Windows.Forms.Button
    Friend WithEvents btnASI As System.Windows.Forms.Button
    Friend WithEvents btnEGY As System.Windows.Forms.Button
    Friend WithEvents btnPen As System.Windows.Forms.Button
    Friend WithEvents grpService As System.Windows.Forms.GroupBox
    Friend WithEvents btnCustomMin As System.Windows.Forms.Button
    Friend WithEvents btn120Min As System.Windows.Forms.Button
    Friend WithEvents btn90Min As System.Windows.Forms.Button
    Friend WithEvents btn60Min As System.Windows.Forms.Button
    Friend WithEvents btn45Min As System.Windows.Forms.Button
    Friend WithEvents btn30Min As System.Windows.Forms.Button
    Friend WithEvents grpDoorCharges As System.Windows.Forms.GroupBox
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents btnLounge As System.Windows.Forms.Button
    Friend WithEvents btnPrivate As System.Windows.Forms.Button
    Friend WithEvents grpPayment As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCard As System.Windows.Forms.Button
    Friend WithEvents btnCash As System.Windows.Forms.Button
    Friend WithEvents grpQueuedItems As System.Windows.Forms.GroupBox
    Friend WithEvents btnClearBooking As System.Windows.Forms.Button
    Friend WithEvents lblQueuedQTY As System.Windows.Forms.Label
    Friend WithEvents lblQueuedQtyText As System.Windows.Forms.Label
    Friend WithEvents btnConfirm As System.Windows.Forms.Button
    Friend WithEvents dgQueuedBooking As System.Windows.Forms.DataGridView
    Friend WithEvents tmrTimeLeftCounter As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lnkService As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lnkRoom As System.Windows.Forms.LinkLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lnkServiceProvider As System.Windows.Forms.LinkLabel
    Friend WithEvents btnDeleteBooking As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnlPaymentMode As System.Windows.Forms.Panel
    Friend WithEvents SERVICEWORKER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ROOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SERVICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMELEFT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMEADDED As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Door As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATUS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tmrRefreshActive As System.Windows.Forms.Timer

End Class
