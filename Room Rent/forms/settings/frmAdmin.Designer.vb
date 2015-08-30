<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMemoPrinter = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkOnlyDeluxe = New System.Windows.Forms.CheckBox()
        Me.chkEscortShiftPrice = New System.Windows.Forms.CheckBox()
        Me.chkEscortServices = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtNightStop = New System.Windows.Forms.MaskedTextBox()
        Me.txtNightStart = New System.Windows.Forms.MaskedTextBox()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.txtEveningShiftEndTime = New System.Windows.Forms.MaskedTextBox()
        Me.txtEveingShiftStartTime = New System.Windows.Forms.MaskedTextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.lblEvening = New System.Windows.Forms.Label()
        Me.txtDay_End = New System.Windows.Forms.MaskedTextBox()
        Me.txtDay_start = New System.Windows.Forms.MaskedTextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.chk3Shift = New System.Windows.Forms.CheckBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtSP_Percentage_night = New System.Windows.Forms.TextBox()
        Me.chkSameEscortPrice = New System.Windows.Forms.CheckBox()
        Me.chkSpecial = New System.Windows.Forms.CheckBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSP_Percentage = New System.Windows.Forms.TextBox()
        Me.txtFooter3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFooter2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFooter1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.txtCompany = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtCompanyAdd = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.cmbReportPrinter = New System.Windows.Forms.ComboBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.cmbRoomType = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dgRoom = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgPrice = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSavePrice = New System.Windows.Forms.Button()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.btnUser = New System.Windows.Forms.Button()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.btnGenerateCancellationPassword = New System.Windows.Forms.Button()
        Me.txtCancellationPassword = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtPasswordHint = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnChangePassword = New System.Windows.Forms.Button()
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.txtOldPassword = New System.Windows.Forms.TextBox()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnNewLocker = New System.Windows.Forms.Button()
        Me.btnSaveLocker = New System.Windows.Forms.Button()
        Me.txtLockerDes = New System.Windows.Forms.TextBox()
        Me.txtLockerPrice = New System.Windows.Forms.TextBox()
        Me.txtLockerNAme = New System.Windows.Forms.TextBox()
        Me.txtLockerNumber = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgLocker = New System.Windows.Forms.DataGridView()
        Me.LockerNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Name2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnPeriodicRevenueReport = New System.Windows.Forms.Button()
        Me.btnAnalysisReport = New System.Windows.Forms.Button()
        Me.btnSummaryReport = New System.Windows.Forms.Button()
        Me.btnWorkerIncome = New System.Windows.Forms.Button()
        Me.btnDoorChargeReport = New System.Windows.Forms.Button()
        Me.btnWorkerActivity = New System.Windows.Forms.Button()
        Me.btnCancelledBookingsReport = New System.Windows.Forms.Button()
        Me.btnWeeklyBookingReport = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.btnDoorChargeOverall = New System.Windows.Forms.Button()
        Me.btnDialyBooking = New System.Windows.Forms.Button()
        Me.btnSuspendedBookingsReport = New System.Windows.Forms.Button()
        Me.btnCompletedBookingsReport = New System.Windows.Forms.Button()
        Me.btnDayActivity = New System.Windows.Forms.Button()
        Me.btnRoomAcitvity = New System.Windows.Forms.Button()
        Me.btnHourlyTrafficReport = New System.Windows.Forms.Button()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.btnSavePremiumSevices = New System.Windows.Forms.Button()
        Me.txtpp444 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp44 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp333 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp33 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp222 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp22 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp111 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp11 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp4 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp3 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp2 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp1 = New System.Windows.Forms.NumericUpDown()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtpp777 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp77 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp666 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp66 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp555 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp55 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp7 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp6 = New System.Windows.Forms.NumericUpDown()
        Me.txtpp5 = New System.Windows.Forms.NumericUpDown()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.txtResetPrice = New System.Windows.Forms.Button()
        Me.btnLookUpPriceGenerator = New System.Windows.Forms.Button()
        Me.cmbServiceType = New System.Windows.Forms.ComboBox()
        Me.btnPrintLookUps = New System.Windows.Forms.Button()
        Me.dgCustom = New System.Windows.Forms.DataGridView()
        Me.Sl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SP_Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HouseAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbCustomType = New System.Windows.Forms.ComboBox()
        Me.cmbServiceCustom = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnNewCustom = New System.Windows.Forms.Button()
        Me.btnSaveCustom = New System.Windows.Forms.Button()
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.txtCustomHouseAmount = New System.Windows.Forms.TextBox()
        Me.txtCustomRate = New System.Windows.Forms.TextBox()
        Me.txtCustomSpAmount = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtNoWorker = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtNoClient = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.btnEscortServices = New System.Windows.Forms.Button()
        Me.chkEscort = New System.Windows.Forms.CheckBox()
        Me.TabPage16 = New System.Windows.Forms.TabPage()
        Me.btnClearBookingTables = New System.Windows.Forms.Button()
        Me.btnCancellationFee = New System.Windows.Forms.Button()
        Me.btnPremiumServices = New System.Windows.Forms.Button()
        Me.btnSpeakON = New System.Windows.Forms.Button()
        Me.btnSpeakOFF = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnRollBack = New System.Windows.Forms.Button()
        Me.btnResetDatabase = New System.Windows.Forms.Button()
        Me.btnResetConnection = New System.Windows.Forms.Button()
        Me.btnClearDB = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.txtEscortBondFees = New System.Windows.Forms.NumericUpDown()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txtOthersCard = New System.Windows.Forms.NumericUpDown()
        Me.txtAMEX = New System.Windows.Forms.NumericUpDown()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.txtMASTERCARD = New System.Windows.Forms.NumericUpDown()
        Me.txtVISA = New System.Windows.Forms.NumericUpDown()
        Me.txtEFT = New System.Windows.Forms.NumericUpDown()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtMemBershipFees = New System.Windows.Forms.NumericUpDown()
        Me.txtCancelFee2 = New System.Windows.Forms.NumericUpDown()
        Me.txtCancelFee1 = New System.Windows.Forms.NumericUpDown()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.btnSaveFees = New System.Windows.Forms.Button()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.chkMembership = New System.Windows.Forms.CheckBox()
        Me.btnSavePassword = New System.Windows.Forms.Button()
        Me.txtAdjustpass = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.txtPauseResumePassword = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.chkDayPrice = New System.Windows.Forms.CheckBox()
        Me.txtDayPricePass = New System.Windows.Forms.TextBox()
        Me.txtContraPass = New System.Windows.Forms.TextBox()
        Me.chkContra = New System.Windows.Forms.CheckBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.txtComPort = New System.Windows.Forms.TextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgRoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgLocker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabPage12.SuspendLayout()
        CType(Me.txtpp444, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp333, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp222, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp111, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp777, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp77, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp666, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp66, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp555, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtpp5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgCustom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage16.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEscortBondFees, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        CType(Me.txtOthersCard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAMEX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMASTERCARD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVISA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEFT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMemBershipFees, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCancelFee2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCancelFee1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage9.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Memo Printer"
        '
        'cmbMemoPrinter
        '
        Me.cmbMemoPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMemoPrinter.FormattingEnabled = True
        Me.cmbMemoPrinter.Location = New System.Drawing.Point(147, 25)
        Me.cmbMemoPrinter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbMemoPrinter.Name = "cmbMemoPrinter"
        Me.cmbMemoPrinter.Size = New System.Drawing.Size(353, 28)
        Me.cmbMemoPrinter.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(330, 517)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(127, 50)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage12)
        Me.TabControl1.Controls.Add(Me.TabPage16)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Controls.Add(Me.TabPage9)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1287, 733)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Company Settings"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.Controls.Add(Me.chkOnlyDeluxe)
        Me.GroupBox1.Controls.Add(Me.chkEscortShiftPrice)
        Me.GroupBox1.Controls.Add(Me.chkEscortServices)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.txtSP_Percentage_night)
        Me.GroupBox1.Controls.Add(Me.chkSameEscortPrice)
        Me.GroupBox1.Controls.Add(Me.chkSpecial)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSP_Percentage)
        Me.GroupBox1.Controls.Add(Me.txtFooter3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFooter2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFooter1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtPhone)
        Me.GroupBox1.Controls.Add(Me.txtCompany)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.txtCompanyAdd)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Location = New System.Drawing.Point(154, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(786, 587)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'chkOnlyDeluxe
        '
        Me.chkOnlyDeluxe.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOnlyDeluxe.Location = New System.Drawing.Point(202, 477)
        Me.chkOnlyDeluxe.Name = "chkOnlyDeluxe"
        Me.chkOnlyDeluxe.Size = New System.Drawing.Size(476, 23)
        Me.chkOnlyDeluxe.TabIndex = 19
        Me.chkOnlyDeluxe.Text = "Only DELUXE for ESCORT service"
        Me.chkOnlyDeluxe.UseVisualStyleBackColor = True
        '
        'chkEscortShiftPrice
        '
        Me.chkEscortShiftPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkEscortShiftPrice.Location = New System.Drawing.Point(202, 455)
        Me.chkEscortShiftPrice.Name = "chkEscortShiftPrice"
        Me.chkEscortShiftPrice.Size = New System.Drawing.Size(476, 23)
        Me.chkEscortShiftPrice.TabIndex = 18
        Me.chkEscortShiftPrice.Text = "Different Price of ESCORT Services in different SHIFT"
        Me.chkEscortShiftPrice.UseVisualStyleBackColor = True
        '
        'chkEscortServices
        '
        Me.chkEscortServices.AutoSize = True
        Me.chkEscortServices.Location = New System.Drawing.Point(180, 409)
        Me.chkEscortServices.Name = "chkEscortServices"
        Me.chkEscortServices.Size = New System.Drawing.Size(158, 24)
        Me.chkEscortServices.TabIndex = 16
        Me.chkEscortServices.Text = "ESCORT Services"
        Me.chkEscortServices.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtNightStop)
        Me.GroupBox4.Controls.Add(Me.txtNightStart)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Controls.Add(Me.txtEveningShiftEndTime)
        Me.GroupBox4.Controls.Add(Me.txtEveingShiftStartTime)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.Label41)
        Me.GroupBox4.Controls.Add(Me.lblEvening)
        Me.GroupBox4.Controls.Add(Me.txtDay_End)
        Me.GroupBox4.Controls.Add(Me.txtDay_start)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.Label38)
        Me.GroupBox4.Controls.Add(Me.Label42)
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Controls.Add(Me.chk3Shift)
        Me.GroupBox4.Controls.Add(Me.Label36)
        Me.GroupBox4.Location = New System.Drawing.Point(170, 222)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(454, 125)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Shift Times (24 Hrs format)"
        '
        'txtNightStop
        '
        Me.txtNightStop.Enabled = False
        Me.txtNightStop.Location = New System.Drawing.Point(344, 92)
        Me.txtNightStop.Mask = "00:00"
        Me.txtNightStop.Name = "txtNightStop"
        Me.txtNightStop.Size = New System.Drawing.Size(55, 26)
        Me.txtNightStop.TabIndex = 18
        Me.txtNightStop.Text = "0900"
        Me.txtNightStop.ValidatingType = GetType(Date)
        '
        'txtNightStart
        '
        Me.txtNightStart.Enabled = False
        Me.txtNightStart.Location = New System.Drawing.Point(252, 92)
        Me.txtNightStart.Mask = "00:00"
        Me.txtNightStart.Name = "txtNightStart"
        Me.txtNightStart.Size = New System.Drawing.Size(55, 26)
        Me.txtNightStart.TabIndex = 17
        Me.txtNightStart.Text = "2100"
        Me.txtNightStart.ValidatingType = GetType(Date)
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Enabled = False
        Me.Label48.Location = New System.Drawing.Point(311, 95)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(27, 20)
        Me.Label48.TabIndex = 20
        Me.Label48.Text = "To"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Enabled = False
        Me.Label49.Location = New System.Drawing.Point(200, 95)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(46, 20)
        Me.Label49.TabIndex = 19
        Me.Label49.Text = "From"
        '
        'txtEveningShiftEndTime
        '
        Me.txtEveningShiftEndTime.Location = New System.Drawing.Point(344, 64)
        Me.txtEveningShiftEndTime.Mask = "00:00"
        Me.txtEveningShiftEndTime.Name = "txtEveningShiftEndTime"
        Me.txtEveningShiftEndTime.Size = New System.Drawing.Size(55, 26)
        Me.txtEveningShiftEndTime.TabIndex = 4
        Me.txtEveningShiftEndTime.Text = "2100"
        Me.txtEveningShiftEndTime.ValidatingType = GetType(Date)
        Me.txtEveningShiftEndTime.Visible = False
        '
        'txtEveingShiftStartTime
        '
        Me.txtEveingShiftStartTime.Location = New System.Drawing.Point(252, 64)
        Me.txtEveingShiftStartTime.Mask = "00:00"
        Me.txtEveingShiftStartTime.Name = "txtEveingShiftStartTime"
        Me.txtEveingShiftStartTime.Size = New System.Drawing.Size(55, 26)
        Me.txtEveingShiftStartTime.TabIndex = 3
        Me.txtEveingShiftStartTime.Text = "0900"
        Me.txtEveingShiftStartTime.ValidatingType = GetType(Date)
        Me.txtEveingShiftStartTime.Visible = False
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(311, 67)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(27, 20)
        Me.Label39.TabIndex = 16
        Me.Label39.Text = "To"
        Me.Label39.Visible = False
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(200, 67)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(46, 20)
        Me.Label41.TabIndex = 15
        Me.Label41.Text = "From"
        Me.Label41.Visible = False
        '
        'lblEvening
        '
        Me.lblEvening.AutoSize = True
        Me.lblEvening.Location = New System.Drawing.Point(6, 67)
        Me.lblEvening.Name = "lblEvening"
        Me.lblEvening.Size = New System.Drawing.Size(149, 20)
        Me.lblEvening.TabIndex = 14
        Me.lblEvening.Text = "Evening Shift Time :"
        Me.lblEvening.Visible = False
        '
        'txtDay_End
        '
        Me.txtDay_End.Location = New System.Drawing.Point(344, 36)
        Me.txtDay_End.Mask = "00:00"
        Me.txtDay_End.Name = "txtDay_End"
        Me.txtDay_End.Size = New System.Drawing.Size(55, 26)
        Me.txtDay_End.TabIndex = 2
        Me.txtDay_End.Text = "2100"
        Me.txtDay_End.ValidatingType = GetType(Date)
        '
        'txtDay_start
        '
        Me.txtDay_start.Location = New System.Drawing.Point(252, 36)
        Me.txtDay_start.Mask = "00:00"
        Me.txtDay_start.Name = "txtDay_start"
        Me.txtDay_start.Size = New System.Drawing.Size(55, 26)
        Me.txtDay_start.TabIndex = 1
        Me.txtDay_start.Text = "0900"
        Me.txtDay_start.ValidatingType = GetType(Date)
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(311, 39)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(27, 20)
        Me.Label40.TabIndex = 3
        Me.Label40.Text = "To"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(200, 39)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(46, 20)
        Me.Label38.TabIndex = 3
        Me.Label38.Text = "From"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(6, 92)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(129, 20)
        Me.Label42.TabIndex = 2
        Me.Label42.Text = "Night Shift Time :"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(6, 39)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(181, 20)
        Me.Label37.TabIndex = 2
        Me.Label37.Text = "Day/Morning Shift Time :"
        '
        'chk3Shift
        '
        Me.chk3Shift.AutoSize = True
        Me.chk3Shift.Location = New System.Drawing.Point(220, 12)
        Me.chk3Shift.Name = "chk3Shift"
        Me.chk3Shift.Size = New System.Drawing.Size(137, 24)
        Me.chk3Shift.TabIndex = 0
        Me.chk3Shift.Text = "3 Shift Enabled"
        Me.chk3Shift.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(183, 33)
        Me.Label36.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(242, 13)
        Me.Label36.TabIndex = 12
        Me.Label36.Text = "Remaining Time will automically used as Night Shift"
        Me.Label36.Visible = False
        '
        'txtSP_Percentage_night
        '
        Me.txtSP_Percentage_night.Enabled = False
        Me.txtSP_Percentage_night.Location = New System.Drawing.Point(514, 254)
        Me.txtSP_Percentage_night.Name = "txtSP_Percentage_night"
        Me.txtSP_Percentage_night.Size = New System.Drawing.Size(88, 26)
        Me.txtSP_Percentage_night.TabIndex = 7
        Me.txtSP_Percentage_night.Text = "66.67"
        Me.txtSP_Percentage_night.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSP_Percentage_night.Visible = False
        '
        'chkSameEscortPrice
        '
        Me.chkSameEscortPrice.Enabled = False
        Me.chkSameEscortPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSameEscortPrice.Location = New System.Drawing.Point(202, 434)
        Me.chkSameEscortPrice.Name = "chkSameEscortPrice"
        Me.chkSameEscortPrice.Size = New System.Drawing.Size(368, 23)
        Me.chkSameEscortPrice.TabIndex = 15
        Me.chkSameEscortPrice.Text = "ESCORT Prices are same as ROOM Prices"
        Me.chkSameEscortPrice.UseVisualStyleBackColor = True
        '
        'chkSpecial
        '
        Me.chkSpecial.AutoSize = True
        Me.chkSpecial.Location = New System.Drawing.Point(180, 353)
        Me.chkSpecial.Name = "chkSpecial"
        Me.chkSpecial.Size = New System.Drawing.Size(148, 24)
        Me.chkSpecial.TabIndex = 7
        Me.chkSpecial.Text = "Special Services "
        Me.chkSpecial.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(199, 380)
        Me.Label35.MaximumSize = New System.Drawing.Size(250, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(216, 26)
        Me.Label35.TabIndex = 11
        Me.Label35.Text = "Enables Service type eg. Delux Service and Standard Service"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(162, 257)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(263, 20)
        Me.Label26.TabIndex = 6
        Me.Label26.Text = "Service Provider Percentage (Night):"
        Me.Label26.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Enabled = False
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(601, 257)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(24, 20)
        Me.Label28.TabIndex = 8
        Me.Label28.Text = "%"
        Me.Label28.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(162, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Company Name :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(162, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Company Address :"
        '
        'txtSP_Percentage
        '
        Me.txtSP_Percentage.Enabled = False
        Me.txtSP_Percentage.Location = New System.Drawing.Point(514, 225)
        Me.txtSP_Percentage.Name = "txtSP_Percentage"
        Me.txtSP_Percentage.Size = New System.Drawing.Size(88, 26)
        Me.txtSP_Percentage.TabIndex = 3
        Me.txtSP_Percentage.Text = "44.29"
        Me.txtSP_Percentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtSP_Percentage.Visible = False
        '
        'txtFooter3
        '
        Me.txtFooter3.Location = New System.Drawing.Point(366, 193)
        Me.txtFooter3.Name = "txtFooter3"
        Me.txtFooter3.Size = New System.Drawing.Size(259, 26)
        Me.txtFooter3.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(162, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Phone :"
        '
        'txtFooter2
        '
        Me.txtFooter2.Location = New System.Drawing.Point(366, 161)
        Me.txtFooter2.Name = "txtFooter2"
        Me.txtFooter2.Size = New System.Drawing.Size(259, 26)
        Me.txtFooter2.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(162, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(159, 20)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Memo Footer Text 1 :"
        '
        'txtFooter1
        '
        Me.txtFooter1.Location = New System.Drawing.Point(366, 129)
        Me.txtFooter1.Name = "txtFooter1"
        Me.txtFooter1.Size = New System.Drawing.Size(259, 26)
        Me.txtFooter1.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(162, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(159, 20)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Memo Footer Text 2 :"
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(366, 97)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(259, 26)
        Me.txtPhone.TabIndex = 2
        '
        'txtCompany
        '
        Me.txtCompany.Location = New System.Drawing.Point(366, 33)
        Me.txtCompany.Name = "txtCompany"
        Me.txtCompany.Size = New System.Drawing.Size(259, 26)
        Me.txtCompany.TabIndex = 0
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(162, 228)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(254, 20)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "Service Provider Percentage (Day):"
        Me.Label29.Visible = False
        '
        'txtCompanyAdd
        '
        Me.txtCompanyAdd.Location = New System.Drawing.Point(366, 65)
        Me.txtCompanyAdd.Name = "txtCompanyAdd"
        Me.txtCompanyAdd.Size = New System.Drawing.Size(259, 26)
        Me.txtCompanyAdd.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(162, 196)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 20)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Memo Footer Text 3 :"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Enabled = False
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(601, 228)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(24, 20)
        Me.Label30.TabIndex = 5
        Me.Label30.Text = "%"
        Me.Label30.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Printer/Cashdrawer Settings"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox2.Controls.Add(Me.txtComPort)
        Me.GroupBox2.Controls.Add(Me.Label82)
        Me.GroupBox2.Controls.Add(Me.cmbReportPrinter)
        Me.GroupBox2.Controls.Add(Me.Label47)
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.cmbMemoPrinter)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(350, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(579, 332)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(37, 111)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(171, 20)
        Me.Label82.TabIndex = 8
        Me.Label82.Text = "Cash Drawer Com Port"
        '
        'cmbReportPrinter
        '
        Me.cmbReportPrinter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbReportPrinter.FormattingEnabled = True
        Me.cmbReportPrinter.Location = New System.Drawing.Point(147, 63)
        Me.cmbReportPrinter.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbReportPrinter.Name = "cmbReportPrinter"
        Me.cmbReportPrinter.Size = New System.Drawing.Size(353, 28)
        Me.cmbReportPrinter.TabIndex = 1
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(37, 66)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(108, 20)
        Me.Label47.TabIndex = 7
        Me.Label47.Text = "Report Printer"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(226, 227)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(127, 50)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "&Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Room"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label81)
        Me.Panel2.Controls.Add(Me.cmbRoomType)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.dgRoom)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1273, 694)
        Me.Panel2.TabIndex = 6
        '
        'Label81
        '
        Me.Label81.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(394, 13)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(104, 20)
        Me.Label81.TabIndex = 3
        Me.Label81.Text = "Room Layout"
        '
        'cmbRoomType
        '
        Me.cmbRoomType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRoomType.FormattingEnabled = True
        Me.cmbRoomType.Items.AddRange(New Object() {"6 ROOMS", "9 ROOMS", "15 ROOMS"})
        Me.cmbRoomType.Location = New System.Drawing.Point(507, 10)
        Me.cmbRoomType.Name = "cmbRoomType"
        Me.cmbRoomType.Size = New System.Drawing.Size(258, 28)
        Me.cmbRoomType.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(1130, 635)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(127, 50)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "&Save"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dgRoom
        '
        Me.dgRoom.AllowUserToAddRows = False
        Me.dgRoom.AllowUserToDeleteRows = False
        Me.dgRoom.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dgRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRoom.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column6, Me.Column9, Me.Column10})
        Me.dgRoom.Location = New System.Drawing.Point(133, 44)
        Me.dgRoom.Name = "dgRoom"
        Me.dgRoom.Size = New System.Drawing.Size(1007, 394)
        Me.dgRoom.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "sl"
        Me.Column1.FillWeight = 20.0!
        Me.Column1.HeaderText = "SL"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Room"
        Me.Column2.HeaderText = "Room Name"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "AdditonalCharge"
        Me.Column3.HeaderText = "Additonal Price"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "FullName"
        Me.Column6.HeaderText = "Full Name"
        Me.Column6.Name = "Column6"
        '
        'Column9
        '
        Me.Column9.DataPropertyName = "AddlSP_Fee"
        Me.Column9.HeaderText = "SP Additional Charge"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.DataPropertyName = "AddlHouse_Fee"
        Me.Column10.HeaderText = "House Additional Charge"
        Me.Column10.Name = "Column10"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Panel1)
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Price"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgPrice)
        Me.Panel1.Controls.Add(Me.btnSavePrice)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1273, 694)
        Me.Panel1.TabIndex = 6
        '
        'dgPrice
        '
        Me.dgPrice.AllowUserToAddRows = False
        Me.dgPrice.AllowUserToDeleteRows = False
        Me.dgPrice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.dgPrice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPrice.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Column4})
        Me.dgPrice.Location = New System.Drawing.Point(292, 21)
        Me.dgPrice.Name = "dgPrice"
        Me.dgPrice.Size = New System.Drawing.Size(688, 431)
        Me.dgPrice.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "sl"
        Me.DataGridViewTextBoxColumn1.FillWeight = 20.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "SL"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Service"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Service"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "dayprice"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Day Price"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "nightprice"
        Me.Column4.HeaderText = "Night Price"
        Me.Column4.Name = "Column4"
        '
        'btnSavePrice
        '
        Me.btnSavePrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSavePrice.Location = New System.Drawing.Point(1141, 635)
        Me.btnSavePrice.Name = "btnSavePrice"
        Me.btnSavePrice.Size = New System.Drawing.Size(127, 50)
        Me.btnSavePrice.TabIndex = 1
        Me.btnSavePrice.Text = "Save"
        Me.btnSavePrice.UseVisualStyleBackColor = True
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.btnUser)
        Me.TabPage5.Controls.Add(Me.GroupBox12)
        Me.TabPage5.Controls.Add(Me.GroupBox3)
        Me.TabPage5.Location = New System.Drawing.Point(4, 29)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Security"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'btnUser
        '
        Me.btnUser.Location = New System.Drawing.Point(551, 432)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(165, 79)
        Me.btnUser.TabIndex = 6
        Me.btnUser.Text = "Users"
        Me.btnUser.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox12.Controls.Add(Me.btnGenerateCancellationPassword)
        Me.GroupBox12.Controls.Add(Me.txtCancellationPassword)
        Me.GroupBox12.Location = New System.Drawing.Point(645, 15)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(466, 328)
        Me.GroupBox12.TabIndex = 1
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Booking Cancellation Password"
        '
        'btnGenerateCancellationPassword
        '
        Me.btnGenerateCancellationPassword.Location = New System.Drawing.Point(70, 151)
        Me.btnGenerateCancellationPassword.Name = "btnGenerateCancellationPassword"
        Me.btnGenerateCancellationPassword.Size = New System.Drawing.Size(327, 82)
        Me.btnGenerateCancellationPassword.TabIndex = 1
        Me.btnGenerateCancellationPassword.Text = "Generate"
        Me.btnGenerateCancellationPassword.UseVisualStyleBackColor = True
        '
        'txtCancellationPassword
        '
        Me.txtCancellationPassword.BackColor = System.Drawing.SystemColors.Info
        Me.txtCancellationPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCancellationPassword.Location = New System.Drawing.Point(70, 62)
        Me.txtCancellationPassword.Name = "txtCancellationPassword"
        Me.txtCancellationPassword.Size = New System.Drawing.Size(327, 83)
        Me.txtCancellationPassword.TabIndex = 0
        Me.txtCancellationPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox3.Controls.Add(Me.Label43)
        Me.GroupBox3.Controls.Add(Me.txtPasswordHint)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.btnChangePassword)
        Me.GroupBox3.Controls.Add(Me.txtConfirmPassword)
        Me.GroupBox3.Controls.Add(Me.txtNewPassword)
        Me.GroupBox3.Controls.Add(Me.txtOldPassword)
        Me.GroupBox3.Location = New System.Drawing.Point(167, 17)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(466, 328)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Change Admin Password"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(25, 135)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(111, 20)
        Me.Label43.TabIndex = 4
        Me.Label43.Text = "Password Hint"
        '
        'txtPasswordHint
        '
        Me.txtPasswordHint.Location = New System.Drawing.Point(202, 132)
        Me.txtPasswordHint.Name = "txtPasswordHint"
        Me.txtPasswordHint.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswordHint.Size = New System.Drawing.Size(232, 26)
        Me.txtPasswordHint.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 103)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(172, 20)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Confirm New Password"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(113, 20)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "New Password"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 20)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Old Password"
        '
        'btnChangePassword
        '
        Me.btnChangePassword.Location = New System.Drawing.Point(202, 236)
        Me.btnChangePassword.Name = "btnChangePassword"
        Me.btnChangePassword.Size = New System.Drawing.Size(166, 67)
        Me.btnChangePassword.TabIndex = 4
        Me.btnChangePassword.Text = "&Change Password"
        Me.btnChangePassword.UseVisualStyleBackColor = True
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(202, 100)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmPassword.Size = New System.Drawing.Size(232, 26)
        Me.txtConfirmPassword.TabIndex = 2
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Location = New System.Drawing.Point(202, 68)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(232, 26)
        Me.txtNewPassword.TabIndex = 1
        '
        'txtOldPassword
        '
        Me.txtOldPassword.Location = New System.Drawing.Point(202, 36)
        Me.txtOldPassword.Name = "txtOldPassword"
        Me.txtOldPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtOldPassword.Size = New System.Drawing.Size(232, 26)
        Me.txtOldPassword.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.Panel3)
        Me.TabPage6.Location = New System.Drawing.Point(4, 29)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Locker Settings"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.btnNewLocker)
        Me.Panel3.Controls.Add(Me.btnSaveLocker)
        Me.Panel3.Controls.Add(Me.txtLockerDes)
        Me.Panel3.Controls.Add(Me.txtLockerPrice)
        Me.Panel3.Controls.Add(Me.txtLockerNAme)
        Me.Panel3.Controls.Add(Me.txtLockerNumber)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.dgLocker)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1273, 694)
        Me.Panel3.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(72, 91)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 13)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "*"
        '
        'Label15
        '
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(77, 62)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "*"
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(145, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "*"
        '
        'btnNewLocker
        '
        Me.btnNewLocker.Location = New System.Drawing.Point(620, 117)
        Me.btnNewLocker.Name = "btnNewLocker"
        Me.btnNewLocker.Size = New System.Drawing.Size(75, 26)
        Me.btnNewLocker.TabIndex = 5
        Me.btnNewLocker.Text = "&New"
        Me.btnNewLocker.UseVisualStyleBackColor = True
        '
        'btnSaveLocker
        '
        Me.btnSaveLocker.Location = New System.Drawing.Point(539, 117)
        Me.btnSaveLocker.Name = "btnSaveLocker"
        Me.btnSaveLocker.Size = New System.Drawing.Size(75, 26)
        Me.btnSaveLocker.TabIndex = 4
        Me.btnSaveLocker.Text = "&Save"
        Me.btnSaveLocker.UseVisualStyleBackColor = True
        '
        'txtLockerDes
        '
        Me.txtLockerDes.Location = New System.Drawing.Point(162, 117)
        Me.txtLockerDes.Name = "txtLockerDes"
        Me.txtLockerDes.Size = New System.Drawing.Size(371, 26)
        Me.txtLockerDes.TabIndex = 3
        '
        'txtLockerPrice
        '
        Me.txtLockerPrice.Location = New System.Drawing.Point(162, 88)
        Me.txtLockerPrice.Name = "txtLockerPrice"
        Me.txtLockerPrice.Size = New System.Drawing.Size(371, 26)
        Me.txtLockerPrice.TabIndex = 2
        '
        'txtLockerNAme
        '
        Me.txtLockerNAme.Location = New System.Drawing.Point(162, 59)
        Me.txtLockerNAme.Name = "txtLockerNAme"
        Me.txtLockerNAme.Size = New System.Drawing.Size(371, 26)
        Me.txtLockerNAme.TabIndex = 1
        '
        'txtLockerNumber
        '
        Me.txtLockerNumber.Location = New System.Drawing.Point(162, 30)
        Me.txtLockerNumber.Name = "txtLockerNumber"
        Me.txtLockerNumber.Size = New System.Drawing.Size(371, 26)
        Me.txtLockerNumber.TabIndex = 0
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(31, 91)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 20)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Price   :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(31, 120)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 20)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Description :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(31, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 20)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Name    :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(31, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(133, 20)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Locker Number   :"
        '
        'dgLocker
        '
        Me.dgLocker.AllowUserToAddRows = False
        Me.dgLocker.AllowUserToDeleteRows = False
        Me.dgLocker.AllowUserToOrderColumns = True
        Me.dgLocker.AllowUserToResizeRows = False
        Me.dgLocker.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLocker.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLocker.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLocker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLocker.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LockerNumber, Me.Name2, Me.Price, Me.Description, Me.Edit, Me.Delete, Me.Column5})
        Me.dgLocker.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgLocker.Location = New System.Drawing.Point(6, 149)
        Me.dgLocker.Name = "dgLocker"
        Me.dgLocker.Size = New System.Drawing.Size(1262, 480)
        Me.dgLocker.TabIndex = 6
        '
        'LockerNumber
        '
        Me.LockerNumber.DataPropertyName = "LockerNumber"
        Me.LockerNumber.HeaderText = "Locker Number"
        Me.LockerNumber.Name = "LockerNumber"
        Me.LockerNumber.ReadOnly = True
        '
        'Name2
        '
        Me.Name2.DataPropertyName = "LockerName"
        Me.Name2.HeaderText = "Name"
        Me.Name2.Name = "Name2"
        Me.Name2.ReadOnly = True
        '
        'Price
        '
        Me.Price.DataPropertyName = "Price"
        Me.Price.HeaderText = "Price"
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        '
        'Edit
        '
        Me.Edit.HeaderText = "Edit"
        Me.Edit.Name = "Edit"
        Me.Edit.ReadOnly = True
        Me.Edit.Text = "Edit"
        Me.Edit.UseColumnTextForButtonValue = True
        '
        'Delete
        '
        Me.Delete.HeaderText = "Delete"
        Me.Delete.Name = "Delete"
        Me.Delete.ReadOnly = True
        Me.Delete.Text = "Delete"
        Me.Delete.UseColumnTextForButtonValue = True
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.HeaderText = ""
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.Panel4)
        Me.TabPage7.Location = New System.Drawing.Point(4, 29)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Reporting"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox7)
        Me.Panel4.Controls.Add(Me.GroupBox6)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1273, 694)
        Me.Panel4.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox7.Controls.Add(Me.Button14)
        Me.GroupBox7.Controls.Add(Me.Button15)
        Me.GroupBox7.Controls.Add(Me.Button16)
        Me.GroupBox7.Controls.Add(Me.Button17)
        Me.GroupBox7.Location = New System.Drawing.Point(16, 11)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(385, 617)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Charts"
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(21, 25)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(171, 95)
        Me.Button14.TabIndex = 0
        Me.Button14.Text = "Weekly Collection of Door Charge"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(196, 25)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(171, 95)
        Me.Button15.TabIndex = 1
        Me.Button15.Text = "Weekly Collection of Booking"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(196, 126)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(171, 95)
        Me.Button16.TabIndex = 3
        Me.Button16.Text = "Daily SP Income"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(21, 126)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(171, 95)
        Me.Button17.TabIndex = 2
        Me.Button17.Text = "Split Report"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox6.Controls.Add(Me.Button4)
        Me.GroupBox6.Controls.Add(Me.Button1)
        Me.GroupBox6.Controls.Add(Me.btnPeriodicRevenueReport)
        Me.GroupBox6.Controls.Add(Me.btnAnalysisReport)
        Me.GroupBox6.Controls.Add(Me.btnSummaryReport)
        Me.GroupBox6.Controls.Add(Me.btnWorkerIncome)
        Me.GroupBox6.Controls.Add(Me.btnDoorChargeReport)
        Me.GroupBox6.Controls.Add(Me.btnWorkerActivity)
        Me.GroupBox6.Controls.Add(Me.btnCancelledBookingsReport)
        Me.GroupBox6.Controls.Add(Me.btnWeeklyBookingReport)
        Me.GroupBox6.Controls.Add(Me.Button18)
        Me.GroupBox6.Controls.Add(Me.btnDoorChargeOverall)
        Me.GroupBox6.Controls.Add(Me.btnDialyBooking)
        Me.GroupBox6.Controls.Add(Me.btnSuspendedBookingsReport)
        Me.GroupBox6.Controls.Add(Me.btnCompletedBookingsReport)
        Me.GroupBox6.Controls.Add(Me.btnDayActivity)
        Me.GroupBox6.Controls.Add(Me.btnRoomAcitvity)
        Me.GroupBox6.Controls.Add(Me.btnHourlyTrafficReport)
        Me.GroupBox6.Location = New System.Drawing.Point(407, 11)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(849, 617)
        Me.GroupBox6.TabIndex = 1
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Reports"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(21, 433)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(171, 95)
        Me.Button4.TabIndex = 15
        Me.Button4.Text = "My Periodic Financial Revenue Transaction Report"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(21, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(171, 95)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Periodic Revenue Report"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnPeriodicRevenueReport
        '
        Me.btnPeriodicRevenueReport.Location = New System.Drawing.Point(489, 516)
        Me.btnPeriodicRevenueReport.Name = "btnPeriodicRevenueReport"
        Me.btnPeriodicRevenueReport.Size = New System.Drawing.Size(171, 95)
        Me.btnPeriodicRevenueReport.TabIndex = 13
        Me.btnPeriodicRevenueReport.Text = "Periodic Revenue Report"
        Me.btnPeriodicRevenueReport.UseVisualStyleBackColor = True
        Me.btnPeriodicRevenueReport.Visible = False
        '
        'btnAnalysisReport
        '
        Me.btnAnalysisReport.Location = New System.Drawing.Point(21, 126)
        Me.btnAnalysisReport.Name = "btnAnalysisReport"
        Me.btnAnalysisReport.Size = New System.Drawing.Size(171, 95)
        Me.btnAnalysisReport.TabIndex = 4
        Me.btnAnalysisReport.Text = "Revenue Transaction Report"
        Me.btnAnalysisReport.UseVisualStyleBackColor = True
        '
        'btnSummaryReport
        '
        Me.btnSummaryReport.Location = New System.Drawing.Point(21, 227)
        Me.btnSummaryReport.Name = "btnSummaryReport"
        Me.btnSummaryReport.Size = New System.Drawing.Size(171, 95)
        Me.btnSummaryReport.TabIndex = 8
        Me.btnSummaryReport.Text = "House Summary"
        Me.btnSummaryReport.UseVisualStyleBackColor = True
        '
        'btnWorkerIncome
        '
        Me.btnWorkerIncome.Location = New System.Drawing.Point(489, 227)
        Me.btnWorkerIncome.Name = "btnWorkerIncome"
        Me.btnWorkerIncome.Size = New System.Drawing.Size(171, 95)
        Me.btnWorkerIncome.TabIndex = 14
        Me.btnWorkerIncome.Text = "SP Split"
        Me.btnWorkerIncome.UseVisualStyleBackColor = True
        '
        'btnDoorChargeReport
        '
        Me.btnDoorChargeReport.Location = New System.Drawing.Point(489, 25)
        Me.btnDoorChargeReport.Name = "btnDoorChargeReport"
        Me.btnDoorChargeReport.Size = New System.Drawing.Size(171, 95)
        Me.btnDoorChargeReport.TabIndex = 3
        Me.btnDoorChargeReport.Text = "Door Charge "
        Me.btnDoorChargeReport.UseVisualStyleBackColor = True
        '
        'btnWorkerActivity
        '
        Me.btnWorkerActivity.Location = New System.Drawing.Point(666, 126)
        Me.btnWorkerActivity.Name = "btnWorkerActivity"
        Me.btnWorkerActivity.Size = New System.Drawing.Size(171, 95)
        Me.btnWorkerActivity.TabIndex = 10
        Me.btnWorkerActivity.Text = "SP Activity"
        Me.btnWorkerActivity.UseVisualStyleBackColor = True
        '
        'btnCancelledBookingsReport
        '
        Me.btnCancelledBookingsReport.Location = New System.Drawing.Point(311, 429)
        Me.btnCancelledBookingsReport.Name = "btnCancelledBookingsReport"
        Me.btnCancelledBookingsReport.Size = New System.Drawing.Size(171, 95)
        Me.btnCancelledBookingsReport.TabIndex = 2
        Me.btnCancelledBookingsReport.Text = "Cancelled Bookings"
        Me.btnCancelledBookingsReport.UseVisualStyleBackColor = True
        '
        'btnWeeklyBookingReport
        '
        Me.btnWeeklyBookingReport.Location = New System.Drawing.Point(311, 227)
        Me.btnWeeklyBookingReport.Name = "btnWeeklyBookingReport"
        Me.btnWeeklyBookingReport.Size = New System.Drawing.Size(171, 95)
        Me.btnWeeklyBookingReport.TabIndex = 7
        Me.btnWeeklyBookingReport.Text = "Weekly Booking Report"
        Me.btnWeeklyBookingReport.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(21, 328)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(171, 95)
        Me.Button18.TabIndex = 9
        Me.Button18.Text = "Training Adjustment Report"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'btnDoorChargeOverall
        '
        Me.btnDoorChargeOverall.Location = New System.Drawing.Point(489, 126)
        Me.btnDoorChargeOverall.Name = "btnDoorChargeOverall"
        Me.btnDoorChargeOverall.Size = New System.Drawing.Size(171, 95)
        Me.btnDoorChargeOverall.TabIndex = 11
        Me.btnDoorChargeOverall.Text = "Door Charge (Overall)"
        Me.btnDoorChargeOverall.UseVisualStyleBackColor = True
        '
        'btnDialyBooking
        '
        Me.btnDialyBooking.Location = New System.Drawing.Point(311, 126)
        Me.btnDialyBooking.Name = "btnDialyBooking"
        Me.btnDialyBooking.Size = New System.Drawing.Size(171, 95)
        Me.btnDialyBooking.TabIndex = 5
        Me.btnDialyBooking.Text = "Daily Booking Report"
        Me.btnDialyBooking.UseVisualStyleBackColor = True
        '
        'btnSuspendedBookingsReport
        '
        Me.btnSuspendedBookingsReport.Location = New System.Drawing.Point(311, 328)
        Me.btnSuspendedBookingsReport.Name = "btnSuspendedBookingsReport"
        Me.btnSuspendedBookingsReport.Size = New System.Drawing.Size(171, 95)
        Me.btnSuspendedBookingsReport.TabIndex = 6
        Me.btnSuspendedBookingsReport.Text = "Suspended Bookings"
        Me.btnSuspendedBookingsReport.UseVisualStyleBackColor = True
        '
        'btnCompletedBookingsReport
        '
        Me.btnCompletedBookingsReport.Location = New System.Drawing.Point(311, 25)
        Me.btnCompletedBookingsReport.Name = "btnCompletedBookingsReport"
        Me.btnCompletedBookingsReport.Size = New System.Drawing.Size(171, 95)
        Me.btnCompletedBookingsReport.TabIndex = 1
        Me.btnCompletedBookingsReport.Text = "Completed Bookings"
        Me.btnCompletedBookingsReport.UseVisualStyleBackColor = True
        '
        'btnDayActivity
        '
        Me.btnDayActivity.Enabled = False
        Me.btnDayActivity.Location = New System.Drawing.Point(666, 25)
        Me.btnDayActivity.Name = "btnDayActivity"
        Me.btnDayActivity.Size = New System.Drawing.Size(171, 95)
        Me.btnDayActivity.TabIndex = 13
        Me.btnDayActivity.Text = "Day Activity"
        Me.btnDayActivity.UseVisualStyleBackColor = True
        '
        'btnRoomAcitvity
        '
        Me.btnRoomAcitvity.Location = New System.Drawing.Point(666, 227)
        Me.btnRoomAcitvity.Name = "btnRoomAcitvity"
        Me.btnRoomAcitvity.Size = New System.Drawing.Size(171, 95)
        Me.btnRoomAcitvity.TabIndex = 12
        Me.btnRoomAcitvity.Text = "Room Activity"
        Me.btnRoomAcitvity.UseVisualStyleBackColor = True
        '
        'btnHourlyTrafficReport
        '
        Me.btnHourlyTrafficReport.Enabled = False
        Me.btnHourlyTrafficReport.Location = New System.Drawing.Point(665, 516)
        Me.btnHourlyTrafficReport.Name = "btnHourlyTrafficReport"
        Me.btnHourlyTrafficReport.Size = New System.Drawing.Size(171, 95)
        Me.btnHourlyTrafficReport.TabIndex = 5
        Me.btnHourlyTrafficReport.Text = "Hourly Traffic Report"
        Me.btnHourlyTrafficReport.UseVisualStyleBackColor = True
        Me.btnHourlyTrafficReport.Visible = False
        '
        'TabPage12
        '
        Me.TabPage12.Controls.Add(Me.btnSavePremiumSevices)
        Me.TabPage12.Controls.Add(Me.txtpp444)
        Me.TabPage12.Controls.Add(Me.txtpp44)
        Me.TabPage12.Controls.Add(Me.txtpp333)
        Me.TabPage12.Controls.Add(Me.txtpp33)
        Me.TabPage12.Controls.Add(Me.txtpp222)
        Me.TabPage12.Controls.Add(Me.txtpp22)
        Me.TabPage12.Controls.Add(Me.txtpp111)
        Me.TabPage12.Controls.Add(Me.txtpp11)
        Me.TabPage12.Controls.Add(Me.txtpp4)
        Me.TabPage12.Controls.Add(Me.txtpp3)
        Me.TabPage12.Controls.Add(Me.txtpp2)
        Me.TabPage12.Controls.Add(Me.txtpp1)
        Me.TabPage12.Controls.Add(Me.Label56)
        Me.TabPage12.Controls.Add(Me.Label57)
        Me.TabPage12.Controls.Add(Me.Label58)
        Me.TabPage12.Controls.Add(Me.Label59)
        Me.TabPage12.Controls.Add(Me.Label50)
        Me.TabPage12.Controls.Add(Me.Label51)
        Me.TabPage12.Controls.Add(Me.Label52)
        Me.TabPage12.Controls.Add(Me.txtpp777)
        Me.TabPage12.Controls.Add(Me.txtpp77)
        Me.TabPage12.Controls.Add(Me.txtpp666)
        Me.TabPage12.Controls.Add(Me.txtpp66)
        Me.TabPage12.Controls.Add(Me.txtpp555)
        Me.TabPage12.Controls.Add(Me.txtpp55)
        Me.TabPage12.Controls.Add(Me.txtpp7)
        Me.TabPage12.Controls.Add(Me.txtpp6)
        Me.TabPage12.Controls.Add(Me.txtpp5)
        Me.TabPage12.Controls.Add(Me.Label53)
        Me.TabPage12.Controls.Add(Me.Label54)
        Me.TabPage12.Controls.Add(Me.Label55)
        Me.TabPage12.Controls.Add(Me.txtResetPrice)
        Me.TabPage12.Controls.Add(Me.btnLookUpPriceGenerator)
        Me.TabPage12.Controls.Add(Me.cmbServiceType)
        Me.TabPage12.Controls.Add(Me.btnPrintLookUps)
        Me.TabPage12.Controls.Add(Me.dgCustom)
        Me.TabPage12.Controls.Add(Me.cmbCustomType)
        Me.TabPage12.Controls.Add(Me.cmbServiceCustom)
        Me.TabPage12.Controls.Add(Me.Label32)
        Me.TabPage12.Controls.Add(Me.Label45)
        Me.TabPage12.Controls.Add(Me.Label34)
        Me.TabPage12.Controls.Add(Me.Label18)
        Me.TabPage12.Controls.Add(Me.Label19)
        Me.TabPage12.Controls.Add(Me.Label20)
        Me.TabPage12.Controls.Add(Me.btnNewCustom)
        Me.TabPage12.Controls.Add(Me.btnSaveCustom)
        Me.TabPage12.Controls.Add(Me.txtMessage)
        Me.TabPage12.Controls.Add(Me.txtCustomHouseAmount)
        Me.TabPage12.Controls.Add(Me.txtCustomRate)
        Me.TabPage12.Controls.Add(Me.txtCustomSpAmount)
        Me.TabPage12.Controls.Add(Me.Label27)
        Me.TabPage12.Controls.Add(Me.Label31)
        Me.TabPage12.Controls.Add(Me.txtNoWorker)
        Me.TabPage12.Controls.Add(Me.Label25)
        Me.TabPage12.Controls.Add(Me.Label44)
        Me.TabPage12.Controls.Add(Me.Label33)
        Me.TabPage12.Controls.Add(Me.txtNoClient)
        Me.TabPage12.Controls.Add(Me.Label21)
        Me.TabPage12.Controls.Add(Me.Label22)
        Me.TabPage12.Controls.Add(Me.Label23)
        Me.TabPage12.Controls.Add(Me.Label24)
        Me.TabPage12.Controls.Add(Me.Label60)
        Me.TabPage12.Controls.Add(Me.btnEscortServices)
        Me.TabPage12.Controls.Add(Me.chkEscort)
        Me.TabPage12.Location = New System.Drawing.Point(4, 29)
        Me.TabPage12.Name = "TabPage12"
        Me.TabPage12.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage12.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage12.TabIndex = 7
        Me.TabPage12.Text = "Price Lookups"
        Me.TabPage12.UseVisualStyleBackColor = True
        '
        'btnSavePremiumSevices
        '
        Me.btnSavePremiumSevices.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSavePremiumSevices.Location = New System.Drawing.Point(1176, 81)
        Me.btnSavePremiumSevices.Name = "btnSavePremiumSevices"
        Me.btnSavePremiumSevices.Size = New System.Drawing.Size(95, 91)
        Me.btnSavePremiumSevices.TabIndex = 53
        Me.btnSavePremiumSevices.Text = "Save Premium Prices"
        Me.btnSavePremiumSevices.UseVisualStyleBackColor = True
        '
        'txtpp444
        '
        Me.txtpp444.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp444.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp444.Location = New System.Drawing.Point(1056, 85)
        Me.txtpp444.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp444.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp444.Name = "txtpp444"
        Me.txtpp444.ReadOnly = True
        Me.txtpp444.Size = New System.Drawing.Size(109, 23)
        Me.txtpp444.TabIndex = 33
        Me.txtpp444.TabStop = False
        Me.txtpp444.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp44
        '
        Me.txtpp44.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp44.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp44.Location = New System.Drawing.Point(940, 85)
        Me.txtpp44.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp44.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp44.Name = "txtpp44"
        Me.txtpp44.Size = New System.Drawing.Size(109, 23)
        Me.txtpp44.TabIndex = 46
        Me.txtpp44.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp333
        '
        Me.txtpp333.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp333.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp333.Location = New System.Drawing.Point(1056, 63)
        Me.txtpp333.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp333.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp333.Name = "txtpp333"
        Me.txtpp333.ReadOnly = True
        Me.txtpp333.Size = New System.Drawing.Size(109, 23)
        Me.txtpp333.TabIndex = 31
        Me.txtpp333.TabStop = False
        Me.txtpp333.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp33
        '
        Me.txtpp33.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp33.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp33.Location = New System.Drawing.Point(940, 63)
        Me.txtpp33.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp33.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp33.Name = "txtpp33"
        Me.txtpp33.Size = New System.Drawing.Size(109, 23)
        Me.txtpp33.TabIndex = 44
        Me.txtpp33.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp222
        '
        Me.txtpp222.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp222.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp222.Location = New System.Drawing.Point(1056, 41)
        Me.txtpp222.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp222.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp222.Name = "txtpp222"
        Me.txtpp222.ReadOnly = True
        Me.txtpp222.Size = New System.Drawing.Size(109, 23)
        Me.txtpp222.TabIndex = 30
        Me.txtpp222.TabStop = False
        Me.txtpp222.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp22
        '
        Me.txtpp22.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp22.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp22.Location = New System.Drawing.Point(940, 41)
        Me.txtpp22.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp22.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp22.Name = "txtpp22"
        Me.txtpp22.Size = New System.Drawing.Size(109, 23)
        Me.txtpp22.TabIndex = 42
        Me.txtpp22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp111
        '
        Me.txtpp111.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp111.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp111.Location = New System.Drawing.Point(1056, 19)
        Me.txtpp111.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp111.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp111.Name = "txtpp111"
        Me.txtpp111.ReadOnly = True
        Me.txtpp111.Size = New System.Drawing.Size(109, 23)
        Me.txtpp111.TabIndex = 32
        Me.txtpp111.TabStop = False
        Me.txtpp111.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp11
        '
        Me.txtpp11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp11.Location = New System.Drawing.Point(940, 19)
        Me.txtpp11.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp11.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp11.Name = "txtpp11"
        Me.txtpp11.Size = New System.Drawing.Size(109, 23)
        Me.txtpp11.TabIndex = 40
        Me.txtpp11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp4
        '
        Me.txtpp4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp4.Location = New System.Drawing.Point(825, 85)
        Me.txtpp4.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp4.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp4.Name = "txtpp4"
        Me.txtpp4.Size = New System.Drawing.Size(109, 23)
        Me.txtpp4.TabIndex = 45
        Me.txtpp4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp3
        '
        Me.txtpp3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp3.Location = New System.Drawing.Point(825, 63)
        Me.txtpp3.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp3.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp3.Name = "txtpp3"
        Me.txtpp3.Size = New System.Drawing.Size(109, 23)
        Me.txtpp3.TabIndex = 43
        Me.txtpp3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp2
        '
        Me.txtpp2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp2.Location = New System.Drawing.Point(825, 41)
        Me.txtpp2.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp2.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp2.Name = "txtpp2"
        Me.txtpp2.Size = New System.Drawing.Size(109, 23)
        Me.txtpp2.TabIndex = 41
        Me.txtpp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp1
        '
        Me.txtpp1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp1.Location = New System.Drawing.Point(825, 19)
        Me.txtpp1.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp1.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp1.Name = "txtpp1"
        Me.txtpp1.Size = New System.Drawing.Size(109, 23)
        Me.txtpp1.TabIndex = 28
        Me.txtpp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label56
        '
        Me.Label56.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(725, 109)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(74, 20)
        Me.Label56.TabIndex = 24
        Me.Label56.Text = "Thursday"
        '
        'Label57
        '
        Me.Label57.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(725, 64)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(69, 20)
        Me.Label57.TabIndex = 23
        Me.Label57.Text = "Tuesday"
        '
        'Label58
        '
        Me.Label58.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(725, 42)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(65, 20)
        Me.Label58.TabIndex = 29
        Me.Label58.Text = "Monday"
        '
        'Label59
        '
        Me.Label59.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(725, 1)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(114, 40)
        Me.Label59.TabIndex = 38
        Me.Label59.Text = "Prenium Prices" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Sunday"
        '
        'Label50
        '
        Me.Label50.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(1082, 2)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(44, 20)
        Me.Label50.TabIndex = 22
        Me.Label50.Text = "Total"
        '
        'Label51
        '
        Me.Label51.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(959, 2)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(56, 20)
        Me.Label51.TabIndex = 34
        Me.Label51.Text = "House"
        '
        'Label52
        '
        Me.Label52.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(861, 2)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(30, 20)
        Me.Label52.TabIndex = 35
        Me.Label52.Text = "SP"
        '
        'txtpp777
        '
        Me.txtpp777.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp777.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp777.Location = New System.Drawing.Point(1056, 151)
        Me.txtpp777.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp777.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp777.Name = "txtpp777"
        Me.txtpp777.ReadOnly = True
        Me.txtpp777.Size = New System.Drawing.Size(109, 23)
        Me.txtpp777.TabIndex = 36
        Me.txtpp777.TabStop = False
        Me.txtpp777.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp77
        '
        Me.txtpp77.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp77.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp77.Location = New System.Drawing.Point(940, 151)
        Me.txtpp77.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp77.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp77.Name = "txtpp77"
        Me.txtpp77.Size = New System.Drawing.Size(109, 23)
        Me.txtpp77.TabIndex = 52
        Me.txtpp77.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp666
        '
        Me.txtpp666.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp666.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp666.Location = New System.Drawing.Point(1056, 129)
        Me.txtpp666.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp666.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp666.Name = "txtpp666"
        Me.txtpp666.ReadOnly = True
        Me.txtpp666.Size = New System.Drawing.Size(109, 23)
        Me.txtpp666.TabIndex = 37
        Me.txtpp666.TabStop = False
        Me.txtpp666.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp66
        '
        Me.txtpp66.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp66.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp66.Location = New System.Drawing.Point(940, 129)
        Me.txtpp66.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp66.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp66.Name = "txtpp66"
        Me.txtpp66.Size = New System.Drawing.Size(109, 23)
        Me.txtpp66.TabIndex = 50
        Me.txtpp66.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp555
        '
        Me.txtpp555.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp555.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp555.Location = New System.Drawing.Point(1056, 107)
        Me.txtpp555.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp555.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp555.Name = "txtpp555"
        Me.txtpp555.ReadOnly = True
        Me.txtpp555.Size = New System.Drawing.Size(109, 23)
        Me.txtpp555.TabIndex = 39
        Me.txtpp555.TabStop = False
        Me.txtpp555.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp55
        '
        Me.txtpp55.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp55.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp55.Location = New System.Drawing.Point(940, 107)
        Me.txtpp55.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp55.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp55.Name = "txtpp55"
        Me.txtpp55.Size = New System.Drawing.Size(109, 23)
        Me.txtpp55.TabIndex = 48
        Me.txtpp55.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp7
        '
        Me.txtpp7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp7.Location = New System.Drawing.Point(825, 151)
        Me.txtpp7.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp7.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp7.Name = "txtpp7"
        Me.txtpp7.Size = New System.Drawing.Size(109, 23)
        Me.txtpp7.TabIndex = 51
        Me.txtpp7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp6
        '
        Me.txtpp6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp6.Location = New System.Drawing.Point(825, 129)
        Me.txtpp6.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp6.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp6.Name = "txtpp6"
        Me.txtpp6.Size = New System.Drawing.Size(109, 23)
        Me.txtpp6.TabIndex = 49
        Me.txtpp6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtpp5
        '
        Me.txtpp5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtpp5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpp5.Location = New System.Drawing.Point(825, 107)
        Me.txtpp5.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtpp5.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.txtpp5.Name = "txtpp5"
        Me.txtpp5.Size = New System.Drawing.Size(109, 23)
        Me.txtpp5.TabIndex = 47
        Me.txtpp5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label53
        '
        Me.Label53.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(726, 86)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(93, 20)
        Me.Label53.TabIndex = 27
        Me.Label53.Text = "Wednesday"
        '
        'Label54
        '
        Me.Label54.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(725, 153)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(73, 20)
        Me.Label54.TabIndex = 26
        Me.Label54.Text = "Saturday"
        '
        'Label55
        '
        Me.Label55.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(725, 131)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(52, 20)
        Me.Label55.TabIndex = 25
        Me.Label55.Text = "Friday"
        '
        'txtResetPrice
        '
        Me.txtResetPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResetPrice.Location = New System.Drawing.Point(859, 639)
        Me.txtResetPrice.Name = "txtResetPrice"
        Me.txtResetPrice.Size = New System.Drawing.Size(290, 50)
        Me.txtResetPrice.TabIndex = 12
        Me.txtResetPrice.Text = "Reset Above listed prices"
        Me.txtResetPrice.UseVisualStyleBackColor = True
        '
        'btnLookUpPriceGenerator
        '
        Me.btnLookUpPriceGenerator.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnLookUpPriceGenerator.Location = New System.Drawing.Point(540, 9)
        Me.btnLookUpPriceGenerator.Name = "btnLookUpPriceGenerator"
        Me.btnLookUpPriceGenerator.Size = New System.Drawing.Size(156, 82)
        Me.btnLookUpPriceGenerator.TabIndex = 10
        Me.btnLookUpPriceGenerator.Text = "Lookup Price Generator"
        Me.btnLookUpPriceGenerator.UseVisualStyleBackColor = True
        '
        'cmbServiceType
        '
        Me.cmbServiceType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServiceType.FormattingEnabled = True
        Me.cmbServiceType.Items.AddRange(New Object() {"STANDARD"})
        Me.cmbServiceType.Location = New System.Drawing.Point(379, 66)
        Me.cmbServiceType.Name = "cmbServiceType"
        Me.cmbServiceType.Size = New System.Drawing.Size(147, 28)
        Me.cmbServiceType.TabIndex = 3
        '
        'btnPrintLookUps
        '
        Me.btnPrintLookUps.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintLookUps.Location = New System.Drawing.Point(1155, 639)
        Me.btnPrintLookUps.Name = "btnPrintLookUps"
        Me.btnPrintLookUps.Size = New System.Drawing.Size(116, 50)
        Me.btnPrintLookUps.TabIndex = 13
        Me.btnPrintLookUps.Text = "Print"
        Me.btnPrintLookUps.UseVisualStyleBackColor = True
        '
        'dgCustom
        '
        Me.dgCustom.AllowUserToAddRows = False
        Me.dgCustom.AllowUserToDeleteRows = False
        Me.dgCustom.AllowUserToOrderColumns = True
        Me.dgCustom.AllowUserToResizeRows = False
        Me.dgCustom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCustom.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCustom.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgCustom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCustom.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Sl, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.TotalAmount, Me.SP_Amount, Me.HouseAmount, Me.DataGridViewTextBoxColumn7, Me.DataGridViewButtonColumn1, Me.DataGridViewButtonColumn2, Me.Column7, Me.Column8, Me.Column11, Me.DataGridViewTextBoxColumn8})
        Me.dgCustom.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCustom.Location = New System.Drawing.Point(19, 185)
        Me.dgCustom.Name = "dgCustom"
        Me.dgCustom.Size = New System.Drawing.Size(1252, 450)
        Me.dgCustom.TabIndex = 11
        '
        'Sl
        '
        Me.Sl.DataPropertyName = "sl"
        Me.Sl.HeaderText = "Sl"
        Me.Sl.Name = "Sl"
        Me.Sl.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Client"
        Me.DataGridViewTextBoxColumn4.HeaderText = "#Clients"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Worker"
        Me.DataGridViewTextBoxColumn5.HeaderText = "#SP"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 80
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Service"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Service"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 80
        '
        'TotalAmount
        '
        Me.TotalAmount.DataPropertyName = "TotalAmount"
        Me.TotalAmount.HeaderText = "Total"
        Me.TotalAmount.Name = "TotalAmount"
        Me.TotalAmount.ReadOnly = True
        Me.TotalAmount.Width = 80
        '
        'SP_Amount
        '
        Me.SP_Amount.DataPropertyName = "sp_amount"
        Me.SP_Amount.HeaderText = "SP"
        Me.SP_Amount.Name = "SP_Amount"
        Me.SP_Amount.ReadOnly = True
        Me.SP_Amount.Width = 80
        '
        'HouseAmount
        '
        Me.HouseAmount.DataPropertyName = "house_amount"
        Me.HouseAmount.HeaderText = "House"
        Me.HouseAmount.Name = "HouseAmount"
        Me.HouseAmount.ReadOnly = True
        Me.HouseAmount.Width = 80
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Type"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Shift"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.HeaderText = "Edit"
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.ReadOnly = True
        Me.DataGridViewButtonColumn1.Text = "Edit"
        Me.DataGridViewButtonColumn1.UseColumnTextForButtonValue = True
        '
        'DataGridViewButtonColumn2
        '
        Me.DataGridViewButtonColumn2.HeaderText = "Delete"
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.ReadOnly = True
        Me.DataGridViewButtonColumn2.Text = "Delete"
        Me.DataGridViewButtonColumn2.UseColumnTextForButtonValue = True
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "servicetype"
        Me.Column7.HeaderText = "Type"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 120
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "room"
        Me.Column8.HeaderText = "ROOM"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.DataPropertyName = "CreatedDate"
        DataGridViewCellStyle3.Format = "dd/MM/yyyy HH:mm"
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column11.HeaderText = "Updated Date"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 140
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.HeaderText = ""
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'cmbCustomType
        '
        Me.cmbCustomType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbCustomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCustomType.FormattingEnabled = True
        Me.cmbCustomType.Items.AddRange(New Object() {"DAY", "NIGHT"})
        Me.cmbCustomType.Location = New System.Drawing.Point(155, 96)
        Me.cmbCustomType.Name = "cmbCustomType"
        Me.cmbCustomType.Size = New System.Drawing.Size(371, 28)
        Me.cmbCustomType.TabIndex = 4
        '
        'cmbServiceCustom
        '
        Me.cmbServiceCustom.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cmbServiceCustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServiceCustom.FormattingEnabled = True
        Me.cmbServiceCustom.Items.AddRange(New Object() {"--Select--", "20 Mins", "30 Mins", "45 Mins", "60 Mins", "90 Mins", "120 Mins", "150 Mins", "180 Mins", "210 Mins", "240 Mins", "300 Mins", "360 Mins", "420 Mins", "480 Mins", "540 Mins", "600 Mins", "660 Mins", "720 Mins", "1440 Mins", "2160 Mins"})
        Me.cmbServiceCustom.Location = New System.Drawing.Point(155, 66)
        Me.cmbServiceCustom.Name = "cmbServiceCustom"
        Me.cmbServiceCustom.Size = New System.Drawing.Size(153, 28)
        Me.cmbServiceCustom.TabIndex = 2
        '
        'Label32
        '
        Me.Label32.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(68, 130)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(10, 13)
        Me.Label32.TabIndex = 20
        Me.Label32.Text = "*"
        '
        'Label45
        '
        Me.Label45.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label45.ForeColor = System.Drawing.Color.Red
        Me.Label45.Location = New System.Drawing.Point(352, 69)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(10, 13)
        Me.Label45.TabIndex = 20
        Me.Label45.Text = "*"
        '
        'Label34
        '
        Me.Label34.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label34.ForeColor = System.Drawing.Color.Red
        Me.Label34.Location = New System.Drawing.Point(68, 100)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(10, 13)
        Me.Label34.TabIndex = 20
        Me.Label34.Text = "*"
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(88, 71)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(10, 13)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "*"
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(130, 13)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 13)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "*"
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label20.ForeColor = System.Drawing.Color.Red
        Me.Label20.Location = New System.Drawing.Point(126, 41)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(10, 13)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "*"
        '
        'btnNewCustom
        '
        Me.btnNewCustom.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNewCustom.Location = New System.Drawing.Point(451, 155)
        Me.btnNewCustom.Name = "btnNewCustom"
        Me.btnNewCustom.Size = New System.Drawing.Size(75, 26)
        Me.btnNewCustom.TabIndex = 9
        Me.btnNewCustom.Text = "Clear"
        Me.btnNewCustom.UseVisualStyleBackColor = True
        '
        'btnSaveCustom
        '
        Me.btnSaveCustom.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSaveCustom.Location = New System.Drawing.Point(370, 155)
        Me.btnSaveCustom.Name = "btnSaveCustom"
        Me.btnSaveCustom.Size = New System.Drawing.Size(75, 26)
        Me.btnSaveCustom.TabIndex = 8
        Me.btnSaveCustom.Text = "Save"
        Me.btnSaveCustom.UseVisualStyleBackColor = True
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(184, 219)
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.Size = New System.Drawing.Size(371, 26)
        Me.txtMessage.TabIndex = 5
        Me.txtMessage.Visible = False
        '
        'txtCustomHouseAmount
        '
        Me.txtCustomHouseAmount.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCustomHouseAmount.Location = New System.Drawing.Point(441, 126)
        Me.txtCustomHouseAmount.Name = "txtCustomHouseAmount"
        Me.txtCustomHouseAmount.ReadOnly = True
        Me.txtCustomHouseAmount.Size = New System.Drawing.Size(85, 26)
        Me.txtCustomHouseAmount.TabIndex = 7
        Me.txtCustomHouseAmount.Text = "0"
        '
        'txtCustomRate
        '
        Me.txtCustomRate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCustomRate.Location = New System.Drawing.Point(155, 126)
        Me.txtCustomRate.Name = "txtCustomRate"
        Me.txtCustomRate.Size = New System.Drawing.Size(85, 26)
        Me.txtCustomRate.TabIndex = 5
        Me.txtCustomRate.Text = "0"
        '
        'txtCustomSpAmount
        '
        Me.txtCustomSpAmount.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCustomSpAmount.Location = New System.Drawing.Point(283, 126)
        Me.txtCustomSpAmount.Name = "txtCustomSpAmount"
        Me.txtCustomSpAmount.Size = New System.Drawing.Size(85, 26)
        Me.txtCustomSpAmount.TabIndex = 6
        Me.txtCustomSpAmount.Text = "0"
        '
        'Label27
        '
        Me.Label27.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(375, 130)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(64, 20)
        Me.Label27.TabIndex = 11
        Me.Label27.Text = "House :"
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(30, 129)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(56, 20)
        Me.Label31.TabIndex = 11
        Me.Label31.Text = "Rate  :"
        '
        'txtNoWorker
        '
        Me.txtNoWorker.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNoWorker.Location = New System.Drawing.Point(155, 10)
        Me.txtNoWorker.Name = "txtNoWorker"
        Me.txtNoWorker.Size = New System.Drawing.Size(371, 26)
        Me.txtNoWorker.TabIndex = 0
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(244, 130)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 20)
        Me.Label25.TabIndex = 11
        Me.Label25.Text = "SP :"
        '
        'Label44
        '
        Me.Label44.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(314, 69)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(59, 20)
        Me.Label44.TabIndex = 11
        Me.Label44.Text = "Type   :"
        '
        'Label33
        '
        Me.Label33.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(30, 100)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(59, 20)
        Me.Label33.TabIndex = 11
        Me.Label33.Text = "Type   :"
        '
        'txtNoClient
        '
        Me.txtNoClient.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtNoClient.Location = New System.Drawing.Point(155, 38)
        Me.txtNoClient.Name = "txtNoClient"
        Me.txtNoClient.Size = New System.Drawing.Size(371, 26)
        Me.txtNoClient.TabIndex = 1
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(30, 71)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(77, 20)
        Me.Label21.TabIndex = 11
        Me.Label21.Text = "Service   :"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(53, 222)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(82, 20)
        Me.Label22.TabIndex = 14
        Me.Label22.Text = "Message :"
        Me.Label22.Visible = False
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(30, 13)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(92, 20)
        Me.Label23.TabIndex = 13
        Me.Label23.Text = "No of SP    :"
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(30, 41)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(115, 20)
        Me.Label24.TabIndex = 10
        Me.Label24.Text = "No of Clients   :"
        '
        'Label60
        '
        Me.Label60.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label60.BackColor = System.Drawing.Color.DarkGray
        Me.Label60.Location = New System.Drawing.Point(714, 0)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(1, 200)
        Me.Label60.TabIndex = 54
        '
        'btnEscortServices
        '
        Me.btnEscortServices.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnEscortServices.Location = New System.Drawing.Point(540, 100)
        Me.btnEscortServices.Name = "btnEscortServices"
        Me.btnEscortServices.Size = New System.Drawing.Size(156, 81)
        Me.btnEscortServices.TabIndex = 5
        Me.btnEscortServices.Text = "Es&cort Extension Services"
        Me.btnEscortServices.UseVisualStyleBackColor = True
        '
        'chkEscort
        '
        Me.chkEscort.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.chkEscort.AutoSize = True
        Me.chkEscort.Location = New System.Drawing.Point(155, 153)
        Me.chkEscort.Name = "chkEscort"
        Me.chkEscort.Size = New System.Drawing.Size(94, 24)
        Me.chkEscort.TabIndex = 55
        Me.chkEscort.Text = "ESCORT"
        Me.chkEscort.UseVisualStyleBackColor = True
        '
        'TabPage16
        '
        Me.TabPage16.Controls.Add(Me.btnClearBookingTables)
        Me.TabPage16.Controls.Add(Me.btnCancellationFee)
        Me.TabPage16.Controls.Add(Me.btnPremiumServices)
        Me.TabPage16.Controls.Add(Me.btnSpeakON)
        Me.TabPage16.Controls.Add(Me.btnSpeakOFF)
        Me.TabPage16.Controls.Add(Me.GroupBox5)
        Me.TabPage16.Location = New System.Drawing.Point(4, 29)
        Me.TabPage16.Name = "TabPage16"
        Me.TabPage16.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage16.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage16.TabIndex = 8
        Me.TabPage16.Text = "Options"
        Me.TabPage16.UseVisualStyleBackColor = True
        '
        'btnClearBookingTables
        '
        Me.btnClearBookingTables.Location = New System.Drawing.Point(385, 522)
        Me.btnClearBookingTables.Name = "btnClearBookingTables"
        Me.btnClearBookingTables.Size = New System.Drawing.Size(165, 79)
        Me.btnClearBookingTables.TabIndex = 8
        Me.btnClearBookingTables.Text = "Clear Booking Tables"
        Me.btnClearBookingTables.UseVisualStyleBackColor = True
        '
        'btnCancellationFee
        '
        Me.btnCancellationFee.Location = New System.Drawing.Point(214, 522)
        Me.btnCancellationFee.Name = "btnCancellationFee"
        Me.btnCancellationFee.Size = New System.Drawing.Size(165, 79)
        Me.btnCancellationFee.TabIndex = 3
        Me.btnCancellationFee.Text = "Cancellation Fee"
        Me.btnCancellationFee.UseVisualStyleBackColor = True
        Me.btnCancellationFee.Visible = False
        '
        'btnPremiumServices
        '
        Me.btnPremiumServices.Location = New System.Drawing.Point(43, 522)
        Me.btnPremiumServices.Name = "btnPremiumServices"
        Me.btnPremiumServices.Size = New System.Drawing.Size(165, 79)
        Me.btnPremiumServices.TabIndex = 2
        Me.btnPremiumServices.Text = "&Premium Services"
        Me.btnPremiumServices.UseVisualStyleBackColor = True
        Me.btnPremiumServices.Visible = False
        '
        'btnSpeakON
        '
        Me.btnSpeakON.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSpeakON.Location = New System.Drawing.Point(765, 138)
        Me.btnSpeakON.Name = "btnSpeakON"
        Me.btnSpeakON.Size = New System.Drawing.Size(165, 79)
        Me.btnSpeakON.TabIndex = 4
        Me.btnSpeakON.Text = "Turn On &Speaker"
        Me.btnSpeakON.UseVisualStyleBackColor = True
        '
        'btnSpeakOFF
        '
        Me.btnSpeakOFF.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSpeakOFF.Location = New System.Drawing.Point(765, 53)
        Me.btnSpeakOFF.Name = "btnSpeakOFF"
        Me.btnSpeakOFF.Size = New System.Drawing.Size(165, 79)
        Me.btnSpeakOFF.TabIndex = 1
        Me.btnSpeakOFF.Text = "Turn Off &Speaker"
        Me.btnSpeakOFF.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox5.Controls.Add(Me.btnRollBack)
        Me.GroupBox5.Controls.Add(Me.btnResetDatabase)
        Me.GroupBox5.Controls.Add(Me.btnResetConnection)
        Me.GroupBox5.Controls.Add(Me.btnClearDB)
        Me.GroupBox5.Controls.Add(Me.btnExport)
        Me.GroupBox5.Controls.Add(Me.btnImport)
        Me.GroupBox5.Location = New System.Drawing.Point(348, 17)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(390, 302)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Database Options"
        '
        'btnRollBack
        '
        Me.btnRollBack.Location = New System.Drawing.Point(195, 206)
        Me.btnRollBack.Name = "btnRollBack"
        Me.btnRollBack.Size = New System.Drawing.Size(165, 79)
        Me.btnRollBack.TabIndex = 7
        Me.btnRollBack.Text = "Rollback App Update"
        Me.btnRollBack.UseVisualStyleBackColor = True
        '
        'btnResetDatabase
        '
        Me.btnResetDatabase.Location = New System.Drawing.Point(24, 206)
        Me.btnResetDatabase.Name = "btnResetDatabase"
        Me.btnResetDatabase.Size = New System.Drawing.Size(165, 79)
        Me.btnResetDatabase.TabIndex = 6
        Me.btnResetDatabase.Text = "Reset Database"
        Me.btnResetDatabase.UseVisualStyleBackColor = True
        '
        'btnResetConnection
        '
        Me.btnResetConnection.Location = New System.Drawing.Point(195, 121)
        Me.btnResetConnection.Name = "btnResetConnection"
        Me.btnResetConnection.Size = New System.Drawing.Size(165, 79)
        Me.btnResetConnection.TabIndex = 3
        Me.btnResetConnection.Text = "&Reset Database Connection"
        Me.btnResetConnection.UseVisualStyleBackColor = True
        '
        'btnClearDB
        '
        Me.btnClearDB.Location = New System.Drawing.Point(195, 36)
        Me.btnClearDB.Name = "btnClearDB"
        Me.btnClearDB.Size = New System.Drawing.Size(165, 79)
        Me.btnClearDB.TabIndex = 1
        Me.btnClearDB.Text = "C&lear Database"
        Me.btnClearDB.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(24, 36)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(165, 79)
        Me.btnExport.TabIndex = 0
        Me.btnExport.Text = "&Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(24, 121)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(165, 79)
        Me.btnImport.TabIndex = 2
        Me.btnImport.Text = "&Import"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.GroupBox8)
        Me.TabPage8.Location = New System.Drawing.Point(4, 29)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage8.TabIndex = 9
        Me.TabPage8.Text = "Fees"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox8.Controls.Add(Me.GroupBox11)
        Me.GroupBox8.Controls.Add(Me.txtEscortBondFees)
        Me.GroupBox8.Controls.Add(Me.Label70)
        Me.GroupBox8.Controls.Add(Me.GroupBox10)
        Me.GroupBox8.Controls.Add(Me.txtMemBershipFees)
        Me.GroupBox8.Controls.Add(Me.txtCancelFee2)
        Me.GroupBox8.Controls.Add(Me.txtCancelFee1)
        Me.GroupBox8.Controls.Add(Me.Label64)
        Me.GroupBox8.Controls.Add(Me.Label63)
        Me.GroupBox8.Controls.Add(Me.Label62)
        Me.GroupBox8.Controls.Add(Me.btnSaveFees)
        Me.GroupBox8.Location = New System.Drawing.Point(253, 36)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(772, 478)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.NumericUpDown6)
        Me.GroupBox11.Controls.Add(Me.Label80)
        Me.GroupBox11.Controls.Add(Me.NumericUpDown5)
        Me.GroupBox11.Controls.Add(Me.Label79)
        Me.GroupBox11.Controls.Add(Me.Label78)
        Me.GroupBox11.Controls.Add(Me.NumericUpDown4)
        Me.GroupBox11.Controls.Add(Me.Label76)
        Me.GroupBox11.Controls.Add(Me.NumericUpDown3)
        Me.GroupBox11.Controls.Add(Me.Label75)
        Me.GroupBox11.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox11.Controls.Add(Me.Label74)
        Me.GroupBox11.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox11.Controls.Add(Me.Label73)
        Me.GroupBox11.Controls.Add(Me.Label77)
        Me.GroupBox11.Location = New System.Drawing.Point(546, 22)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(206, 273)
        Me.GroupBox11.TabIndex = 7
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Door Charges"
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.DecimalPlaces = 2
        Me.NumericUpDown6.Location = New System.Drawing.Point(118, 221)
        Me.NumericUpDown6.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Size = New System.Drawing.Size(77, 26)
        Me.NumericUpDown6.TabIndex = 12
        Me.NumericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(1, 225)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(94, 20)
        Me.Label80.TabIndex = 11
        Me.Label80.Text = "Private Intro"
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.DecimalPlaces = 2
        Me.NumericUpDown5.Location = New System.Drawing.Point(123, 98)
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(77, 26)
        Me.NumericUpDown5.TabIndex = 12
        Me.NumericUpDown5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(6, 102)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(94, 20)
        Me.Label79.TabIndex = 11
        Me.Label79.Text = "Private Intro"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(78, 19)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(43, 20)
        Me.Label78.TabIndex = 10
        Me.Label78.Text = "DAY"
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.DecimalPlaces = 2
        Me.NumericUpDown4.Location = New System.Drawing.Point(123, 69)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(77, 26)
        Me.NumericUpDown4.TabIndex = 9
        Me.NumericUpDown4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(6, 73)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(57, 20)
        Me.Label76.TabIndex = 8
        Me.Label76.Text = "Private"
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.DecimalPlaces = 2
        Me.NumericUpDown3.Location = New System.Drawing.Point(118, 193)
        Me.NumericUpDown3.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(77, 26)
        Me.NumericUpDown3.TabIndex = 7
        Me.NumericUpDown3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(1, 195)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(57, 20)
        Me.Label75.TabIndex = 6
        Me.Label75.Text = "Private"
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.DecimalPlaces = 2
        Me.NumericUpDown2.Location = New System.Drawing.Point(118, 164)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(77, 26)
        Me.NumericUpDown2.TabIndex = 5
        Me.NumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(1, 168)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(63, 20)
        Me.Label74.TabIndex = 4
        Me.Label74.Text = "Lounge"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.DecimalPlaces = 2
        Me.NumericUpDown1.Location = New System.Drawing.Point(123, 41)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(77, 26)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(6, 45)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(63, 20)
        Me.Label73.TabIndex = 2
        Me.Label73.Text = "Lounge"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(62, 141)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(59, 20)
        Me.Label77.TabIndex = 10
        Me.Label77.Text = "NIGHT"
        '
        'txtEscortBondFees
        '
        Me.txtEscortBondFees.DecimalPlaces = 2
        Me.txtEscortBondFees.Location = New System.Drawing.Point(411, 324)
        Me.txtEscortBondFees.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtEscortBondFees.Name = "txtEscortBondFees"
        Me.txtEscortBondFees.Size = New System.Drawing.Size(120, 26)
        Me.txtEscortBondFees.TabIndex = 6
        Me.txtEscortBondFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(22, 326)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(335, 20)
        Me.Label70.TabIndex = 5
        Me.Label70.Text = "Escort Private/residential non-refundable bond"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtOthersCard)
        Me.GroupBox10.Controls.Add(Me.txtAMEX)
        Me.GroupBox10.Controls.Add(Me.Label71)
        Me.GroupBox10.Controls.Add(Me.Label72)
        Me.GroupBox10.Controls.Add(Me.txtMASTERCARD)
        Me.GroupBox10.Controls.Add(Me.txtVISA)
        Me.GroupBox10.Controls.Add(Me.txtEFT)
        Me.GroupBox10.Controls.Add(Me.Label67)
        Me.GroupBox10.Controls.Add(Me.Label68)
        Me.GroupBox10.Controls.Add(Me.Label69)
        Me.GroupBox10.Location = New System.Drawing.Point(22, 125)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(514, 193)
        Me.GroupBox10.TabIndex = 3
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Admin Fees (%)"
        '
        'txtOthersCard
        '
        Me.txtOthersCard.DecimalPlaces = 2
        Me.txtOthersCard.Location = New System.Drawing.Point(389, 148)
        Me.txtOthersCard.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtOthersCard.Name = "txtOthersCard"
        Me.txtOthersCard.Size = New System.Drawing.Size(120, 26)
        Me.txtOthersCard.TabIndex = 4
        Me.txtOthersCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAMEX
        '
        Me.txtAMEX.DecimalPlaces = 2
        Me.txtAMEX.Location = New System.Drawing.Point(389, 116)
        Me.txtAMEX.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtAMEX.Name = "txtAMEX"
        Me.txtAMEX.Size = New System.Drawing.Size(120, 26)
        Me.txtAMEX.TabIndex = 3
        Me.txtAMEX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(0, 150)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(76, 20)
        Me.Label71.TabIndex = 9
        Me.Label71.Text = "OTHERS"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(0, 118)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(55, 20)
        Me.Label72.TabIndex = 11
        Me.Label72.Text = "AMEX"
        '
        'txtMASTERCARD
        '
        Me.txtMASTERCARD.DecimalPlaces = 2
        Me.txtMASTERCARD.Location = New System.Drawing.Point(390, 84)
        Me.txtMASTERCARD.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtMASTERCARD.Name = "txtMASTERCARD"
        Me.txtMASTERCARD.Size = New System.Drawing.Size(120, 26)
        Me.txtMASTERCARD.TabIndex = 2
        Me.txtMASTERCARD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtVISA
        '
        Me.txtVISA.DecimalPlaces = 2
        Me.txtVISA.Location = New System.Drawing.Point(390, 52)
        Me.txtVISA.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtVISA.Name = "txtVISA"
        Me.txtVISA.Size = New System.Drawing.Size(120, 26)
        Me.txtVISA.TabIndex = 1
        Me.txtVISA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEFT
        '
        Me.txtEFT.DecimalPlaces = 2
        Me.txtEFT.Location = New System.Drawing.Point(390, 20)
        Me.txtEFT.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtEFT.Name = "txtEFT"
        Me.txtEFT.Size = New System.Drawing.Size(120, 26)
        Me.txtEFT.TabIndex = 0
        Me.txtEFT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(1, 86)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(122, 20)
        Me.Label67.TabIndex = 4
        Me.Label67.Text = "MASTERCARD"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(1, 54)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(47, 20)
        Me.Label68.TabIndex = 3
        Me.Label68.Text = "VISA"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(1, 22)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(39, 20)
        Me.Label69.TabIndex = 5
        Me.Label69.Text = "EFT"
        '
        'txtMemBershipFees
        '
        Me.txtMemBershipFees.DecimalPlaces = 2
        Me.txtMemBershipFees.Location = New System.Drawing.Point(412, 86)
        Me.txtMemBershipFees.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtMemBershipFees.Name = "txtMemBershipFees"
        Me.txtMemBershipFees.Size = New System.Drawing.Size(120, 26)
        Me.txtMemBershipFees.TabIndex = 2
        Me.txtMemBershipFees.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCancelFee2
        '
        Me.txtCancelFee2.DecimalPlaces = 2
        Me.txtCancelFee2.Location = New System.Drawing.Point(412, 52)
        Me.txtCancelFee2.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtCancelFee2.Name = "txtCancelFee2"
        Me.txtCancelFee2.Size = New System.Drawing.Size(120, 26)
        Me.txtCancelFee2.TabIndex = 1
        Me.txtCancelFee2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCancelFee1
        '
        Me.txtCancelFee1.DecimalPlaces = 2
        Me.txtCancelFee1.Location = New System.Drawing.Point(412, 20)
        Me.txtCancelFee1.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.txtCancelFee1.Name = "txtCancelFee1"
        Me.txtCancelFee1.Size = New System.Drawing.Size(120, 26)
        Me.txtCancelFee1.TabIndex = 0
        Me.txtCancelFee1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(23, 88)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(136, 20)
        Me.Label64.TabIndex = 1
        Me.Label64.Text = "Membership Fees"
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(23, 54)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(299, 20)
        Me.Label63.TabIndex = 1
        Me.Label63.Text = "Cancellation Fees ( Above 1 Hr Booking )"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(23, 22)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(349, 20)
        Me.Label62.TabIndex = 1
        Me.Label62.Text = "Cancellation Fees ( Below 1 Hr or 1 Hr Booking )"
        '
        'btnSaveFees
        '
        Me.btnSaveFees.Location = New System.Drawing.Point(368, 401)
        Me.btnSaveFees.Name = "btnSaveFees"
        Me.btnSaveFees.Size = New System.Drawing.Size(178, 71)
        Me.btnSaveFees.TabIndex = 4
        Me.btnSaveFees.Text = "Save"
        Me.btnSaveFees.UseVisualStyleBackColor = True
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.GroupBox9)
        Me.TabPage9.Location = New System.Drawing.Point(4, 29)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(1279, 700)
        Me.TabPage9.TabIndex = 10
        Me.TabPage9.Text = "Other Settings"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox9.Controls.Add(Me.btnEdit)
        Me.GroupBox9.Controls.Add(Me.chkMembership)
        Me.GroupBox9.Controls.Add(Me.btnSavePassword)
        Me.GroupBox9.Controls.Add(Me.txtAdjustpass)
        Me.GroupBox9.Controls.Add(Me.Label66)
        Me.GroupBox9.Controls.Add(Me.Label61)
        Me.GroupBox9.Controls.Add(Me.txtPauseResumePassword)
        Me.GroupBox9.Controls.Add(Me.Label46)
        Me.GroupBox9.Controls.Add(Me.Label65)
        Me.GroupBox9.Controls.Add(Me.chkDayPrice)
        Me.GroupBox9.Controls.Add(Me.txtDayPricePass)
        Me.GroupBox9.Controls.Add(Me.txtContraPass)
        Me.GroupBox9.Controls.Add(Me.chkContra)
        Me.GroupBox9.Location = New System.Drawing.Point(165, 32)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(803, 564)
        Me.GroupBox9.TabIndex = 17
        Me.GroupBox9.TabStop = False
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(40, 477)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(165, 63)
        Me.btnEdit.TabIndex = 19
        Me.btnEdit.Text = "Edit Merchandises"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'chkMembership
        '
        Me.chkMembership.AutoSize = True
        Me.chkMembership.Location = New System.Drawing.Point(492, 154)
        Me.chkMembership.Name = "chkMembership"
        Me.chkMembership.Size = New System.Drawing.Size(169, 24)
        Me.chkMembership.TabIndex = 18
        Me.chkMembership.Text = "Enable Membership"
        Me.chkMembership.UseVisualStyleBackColor = True
        '
        'btnSavePassword
        '
        Me.btnSavePassword.Location = New System.Drawing.Point(283, 479)
        Me.btnSavePassword.Name = "btnSavePassword"
        Me.btnSavePassword.Size = New System.Drawing.Size(269, 61)
        Me.btnSavePassword.TabIndex = 17
        Me.btnSavePassword.Text = "Save"
        Me.btnSavePassword.UseVisualStyleBackColor = True
        '
        'txtAdjustpass
        '
        Me.txtAdjustpass.Location = New System.Drawing.Point(306, 66)
        Me.txtAdjustpass.Name = "txtAdjustpass"
        Me.txtAdjustpass.Size = New System.Drawing.Size(134, 26)
        Me.txtAdjustpass.TabIndex = 15
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(91, 69)
        Me.Label66.MaximumSize = New System.Drawing.Size(200, 0)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(198, 60)
        Me.Label66.TabIndex = 16
        Me.Label66.Text = "Active Booking Remaining Time Adjustment Password"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(497, 125)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(78, 20)
        Me.Label61.TabIndex = 14
        Me.Label61.Text = "Password"
        '
        'txtPauseResumePassword
        '
        Me.txtPauseResumePassword.Location = New System.Drawing.Point(306, 34)
        Me.txtPauseResumePassword.Name = "txtPauseResumePassword"
        Me.txtPauseResumePassword.Size = New System.Drawing.Size(134, 26)
        Me.txtPauseResumePassword.TabIndex = 15
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(497, 66)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(78, 20)
        Me.Label46.TabIndex = 14
        Me.Label46.Text = "Password"
        Me.Label46.Visible = False
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(91, 37)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(191, 20)
        Me.Label65.TabIndex = 16
        Me.Label65.Text = "Resume/Pause Password"
        '
        'chkDayPrice
        '
        Me.chkDayPrice.AutoSize = True
        Me.chkDayPrice.Location = New System.Drawing.Point(492, 95)
        Me.chkDayPrice.Name = "chkDayPrice"
        Me.chkDayPrice.Size = New System.Drawing.Size(201, 24)
        Me.chkDayPrice.TabIndex = 10
        Me.chkDayPrice.Text = "Enable Day Price Button"
        Me.chkDayPrice.UseVisualStyleBackColor = True
        '
        'txtDayPricePass
        '
        Me.txtDayPricePass.Location = New System.Drawing.Point(577, 122)
        Me.txtDayPricePass.Name = "txtDayPricePass"
        Me.txtDayPricePass.Size = New System.Drawing.Size(134, 26)
        Me.txtDayPricePass.TabIndex = 11
        Me.txtDayPricePass.Visible = False
        '
        'txtContraPass
        '
        Me.txtContraPass.Location = New System.Drawing.Point(577, 63)
        Me.txtContraPass.Name = "txtContraPass"
        Me.txtContraPass.Size = New System.Drawing.Size(134, 26)
        Me.txtContraPass.TabIndex = 9
        Me.txtContraPass.Visible = False
        '
        'chkContra
        '
        Me.chkContra.AutoSize = True
        Me.chkContra.Location = New System.Drawing.Point(492, 36)
        Me.chkContra.Name = "chkContra"
        Me.chkContra.Size = New System.Drawing.Size(130, 24)
        Me.chkContra.TabIndex = 8
        Me.chkContra.Text = "Enable Contra"
        Me.chkContra.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(14, 671)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(127, 50)
        Me.btnBack.TabIndex = 1
        Me.btnBack.Tag = "GO BACK"
        Me.btnBack.Text = "GO &BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'txtComPort
        '
        Me.txtComPort.Location = New System.Drawing.Point(214, 108)
        Me.txtComPort.Name = "txtComPort"
        Me.txtComPort.Size = New System.Drawing.Size(286, 26)
        Me.txtComPort.TabIndex = 9
        Me.txtComPort.Text = "COM7"
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1287, 733)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administration"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgRoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgLocker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.TabPage12.ResumeLayout(False)
        Me.TabPage12.PerformLayout()
        CType(Me.txtpp444, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp333, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp222, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp111, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp777, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp77, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp666, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp66, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp555, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtpp5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgCustom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage16.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEscortBondFees, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.txtOthersCard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAMEX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMASTERCARD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVISA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEFT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMemBershipFees, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCancelFee2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCancelFee1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage9.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbMemoPrinter As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents btnChangePassword As System.Windows.Forms.Button
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtOldPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgRoom As System.Windows.Forms.DataGridView
    Friend WithEvents dgPrice As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFooter2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFooter1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents txtCompany As System.Windows.Forms.TextBox
    Friend WithEvents txtCompanyAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFooter3 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnSavePrice As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents dgLocker As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtLockerDes As System.Windows.Forms.TextBox
    Friend WithEvents txtLockerNAme As System.Windows.Forms.TextBox
    Friend WithEvents txtLockerNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnNewLocker As System.Windows.Forms.Button
    Friend WithEvents btnSaveLocker As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtLockerPrice As System.Windows.Forms.TextBox
    Friend WithEvents LockerNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Name2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Delete As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage12 As System.Windows.Forms.TabPage
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnNewCustom As System.Windows.Forms.Button
    Friend WithEvents btnSaveCustom As System.Windows.Forms.Button
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents txtNoWorker As System.Windows.Forms.TextBox
    Friend WithEvents txtNoClient As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents dgCustom As System.Windows.Forms.DataGridView
    Friend WithEvents cmbServiceCustom As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustomHouseAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomSpAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtSP_Percentage As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtCustomRate As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomType As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtSP_Percentage_night As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents txtDay_End As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtDay_start As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents btnCompletedBookingsReport As System.Windows.Forms.Button
    Friend WithEvents btnSuspendedBookingsReport As System.Windows.Forms.Button
    Friend WithEvents btnCancelledBookingsReport As System.Windows.Forms.Button
    Friend WithEvents btnSummaryReport As System.Windows.Forms.Button
    Friend WithEvents TabPage16 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnResetConnection As System.Windows.Forms.Button
    Friend WithEvents btnClearDB As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnSpeakOFF As System.Windows.Forms.Button
    Friend WithEvents btnSpeakON As System.Windows.Forms.Button
    Friend WithEvents btnWorkerActivity As System.Windows.Forms.Button
    Friend WithEvents btnRoomAcitvity As System.Windows.Forms.Button
    Friend WithEvents btnDayActivity As System.Windows.Forms.Button
    Friend WithEvents btnHourlyTrafficReport As System.Windows.Forms.Button
    Friend WithEvents btnWeeklyBookingReport As System.Windows.Forms.Button
    Friend WithEvents btnDoorChargeOverall As System.Windows.Forms.Button
    Friend WithEvents btnWorkerIncome As System.Windows.Forms.Button
    Friend WithEvents btnDialyBooking As System.Windows.Forms.Button
    Friend WithEvents btnDoorChargeReport As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnAnalysisReport As System.Windows.Forms.Button
    Friend WithEvents btnPeriodicRevenueReport As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents chk3Shift As System.Windows.Forms.CheckBox
    Friend WithEvents txtEveningShiftEndTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtEveingShiftStartTime As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents lblEvening As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtPasswordHint As System.Windows.Forms.TextBox
    Friend WithEvents cmbServiceType As System.Windows.Forms.ComboBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents btnPrintLookUps As System.Windows.Forms.Button
    Friend WithEvents btnLookUpPriceGenerator As System.Windows.Forms.Button
    Friend WithEvents txtResetPrice As System.Windows.Forms.Button
    Friend WithEvents btnPremiumServices As System.Windows.Forms.Button
    Friend WithEvents btnEscortServices As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancellationFee As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbReportPrinter As System.Windows.Forms.ComboBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents txtNightStop As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNightStart As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents btnResetDatabase As System.Windows.Forms.Button
    Friend WithEvents txtpp444 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp44 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp333 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp33 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp222 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp22 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp111 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp11 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtpp777 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp77 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp666 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp66 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp555 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp55 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp7 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp6 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtpp5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents btnSavePremiumSevices As System.Windows.Forms.Button
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents btnUser As System.Windows.Forms.Button
    Friend WithEvents btnRollBack As System.Windows.Forms.Button
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents btnSaveFees As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txtMemBershipFees As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtCancelFee2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtCancelFee1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkEscort As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage9 As System.Windows.Forms.TabPage
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnClearBookingTables As System.Windows.Forms.Button
    Friend WithEvents Sl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SP_Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HouseAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn2 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPauseResumePassword As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents btnSavePassword As System.Windows.Forms.Button
    Friend WithEvents txtAdjustpass As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents txtOthersCard As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtAMEX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents txtMASTERCARD As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtVISA As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtEFT As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents chkEscortShiftPrice As System.Windows.Forms.CheckBox
    Friend WithEvents chkEscortServices As System.Windows.Forms.CheckBox
    Friend WithEvents chkSameEscortPrice As System.Windows.Forms.CheckBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtDayPricePass As System.Windows.Forms.TextBox
    Friend WithEvents txtContraPass As System.Windows.Forms.TextBox
    Friend WithEvents chkDayPrice As System.Windows.Forms.CheckBox
    Friend WithEvents chkContra As System.Windows.Forms.CheckBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents chkSpecial As System.Windows.Forms.CheckBox
    Friend WithEvents cmbRoomType As System.Windows.Forms.ComboBox
    Friend WithEvents chkOnlyDeluxe As System.Windows.Forms.CheckBox
    Friend WithEvents txtEscortBondFees As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents chkMembership As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents NumericUpDown4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents NumericUpDown5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown6 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCancellationPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnGenerateCancellationPassword As System.Windows.Forms.Button
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents txtComPort As System.Windows.Forms.TextBox

End Class
