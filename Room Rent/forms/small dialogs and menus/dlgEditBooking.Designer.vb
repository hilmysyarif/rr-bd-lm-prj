<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgEditBooking
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
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnExtend = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnEditBooking = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblPayment = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnReadLoad = New System.Windows.Forms.Button()
        Me.btnSwapSP = New System.Windows.Forms.Button()
        Me.btnSwapRoom = New System.Windows.Forms.Button()
        Me.btnAdjustTime = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblAdjustTime = New System.Windows.Forms.Label()
        Me.btnPlusTime = New System.Windows.Forms.Button()
        Me.btnMinusTime = New System.Windows.Forms.Button()
        Me.lblLeftTime = New System.Windows.Forms.Label()
        Me.btnAddClient = New System.Windows.Forms.Button()
        Me.btnPauseStart = New System.Windows.Forms.Button()
        Me.btnChangeService = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnChangeRoom = New System.Windows.Forms.Button()
        Me.btnChangeWorker = New System.Windows.Forms.Button()
        Me.btnSuspend = New System.Windows.Forms.Button()
        Me.btnRemoveWorker = New System.Windows.Forms.Button()
        Me.lblBookingInfo = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK_Button.Location = New System.Drawing.Point(437, 178)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(6)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(218, 37)
        Me.OK_Button.TabIndex = 9
        Me.OK_Button.Text = "ADD SP"
        Me.OK_Button.UseVisualStyleBackColor = True
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancel_Button.Location = New System.Drawing.Point(16, 214)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(6)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(197, 37)
        Me.Cancel_Button.TabIndex = 15
        Me.Cancel_Button.Text = "GO BACK"
        Me.Cancel_Button.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(12, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(78, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'btnExtend
        '
        Me.btnExtend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExtend.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtend.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExtend.Location = New System.Drawing.Point(874, 214)
        Me.btnExtend.Margin = New System.Windows.Forms.Padding(6)
        Me.btnExtend.Name = "btnExtend"
        Me.btnExtend.Size = New System.Drawing.Size(197, 37)
        Me.btnExtend.TabIndex = 0
        Me.btnExtend.Text = "EXTEND"
        Me.btnExtend.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(112, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(499, 246)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Choose an Option"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Location = New System.Drawing.Point(653, 214)
        Me.Button2.Margin = New System.Windows.Forms.Padding(6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(222, 37)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "RESET"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DimGray
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnEditBooking)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnReadLoad)
        Me.Panel1.Controls.Add(Me.btnSwapSP)
        Me.Panel1.Controls.Add(Me.btnSwapRoom)
        Me.Panel1.Controls.Add(Me.btnAdjustTime)
        Me.Panel1.Controls.Add(Me.lblTotal)
        Me.Panel1.Controls.Add(Me.lblAdjustTime)
        Me.Panel1.Controls.Add(Me.btnPlusTime)
        Me.Panel1.Controls.Add(Me.btnMinusTime)
        Me.Panel1.Controls.Add(Me.lblLeftTime)
        Me.Panel1.Controls.Add(Me.Cancel_Button)
        Me.Panel1.Controls.Add(Me.btnAddClient)
        Me.Panel1.Controls.Add(Me.btnPauseStart)
        Me.Panel1.Controls.Add(Me.btnChangeService)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnChangeRoom)
        Me.Panel1.Controls.Add(Me.btnChangeWorker)
        Me.Panel1.Controls.Add(Me.btnSuspend)
        Me.Panel1.Controls.Add(Me.btnRemoveWorker)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.btnExtend)
        Me.Panel1.Controls.Add(Me.OK_Button)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 337)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1077, 259)
        Me.Panel1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(437, 22)
        Me.Button1.Margin = New System.Windows.Forms.Padding(6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(218, 50)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "CANCEL BOOKING" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "*USER ERROR*"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnEditBooking
        '
        Me.btnEditBooking.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditBooking.Location = New System.Drawing.Point(437, 70)
        Me.btnEditBooking.Margin = New System.Windows.Forms.Padding(6)
        Me.btnEditBooking.Name = "btnEditBooking"
        Me.btnEditBooking.Size = New System.Drawing.Size(218, 37)
        Me.btnEditBooking.TabIndex = 22
        Me.btnEditBooking.Text = "EDIT BOOKING"
        Me.btnEditBooking.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblPayment)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(196, 87)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Payments"
        '
        'lblPayment
        '
        Me.lblPayment.Location = New System.Drawing.Point(90, 24)
        Me.lblPayment.Name = "lblPayment"
        Me.lblPayment.Size = New System.Drawing.Size(88, 51)
        Me.lblPayment.TabIndex = 0
        Me.lblPayment.Text = "0.00" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0.00" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0.00"
        Me.lblPayment.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 51)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = ":" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ":" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 51)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cash" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Card" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Voucher"
        '
        'btnReadLoad
        '
        Me.btnReadLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReadLoad.Location = New System.Drawing.Point(16, 84)
        Me.btnReadLoad.Margin = New System.Windows.Forms.Padding(6)
        Me.btnReadLoad.Name = "btnReadLoad"
        Me.btnReadLoad.Size = New System.Drawing.Size(197, 36)
        Me.btnReadLoad.TabIndex = 20
        Me.btnReadLoad.Text = "READ LOUD"
        Me.btnReadLoad.UseVisualStyleBackColor = True
        '
        'btnSwapSP
        '
        Me.btnSwapSP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSwapSP.Location = New System.Drawing.Point(437, 106)
        Me.btnSwapSP.Margin = New System.Windows.Forms.Padding(6)
        Me.btnSwapSP.Name = "btnSwapSP"
        Me.btnSwapSP.Size = New System.Drawing.Size(218, 37)
        Me.btnSwapSP.TabIndex = 11
        Me.btnSwapSP.Text = "SWAP SP"
        Me.btnSwapSP.UseVisualStyleBackColor = True
        '
        'btnSwapRoom
        '
        Me.btnSwapRoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSwapRoom.Location = New System.Drawing.Point(16, 35)
        Me.btnSwapRoom.Margin = New System.Windows.Forms.Padding(6)
        Me.btnSwapRoom.Name = "btnSwapRoom"
        Me.btnSwapRoom.Size = New System.Drawing.Size(196, 37)
        Me.btnSwapRoom.TabIndex = 11
        Me.btnSwapRoom.Text = "SWAP ROOM"
        Me.btnSwapRoom.UseVisualStyleBackColor = True
        Me.btnSwapRoom.Visible = False
        '
        'btnAdjustTime
        '
        Me.btnAdjustTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjustTime.Location = New System.Drawing.Point(952, 36)
        Me.btnAdjustTime.Margin = New System.Windows.Forms.Padding(6)
        Me.btnAdjustTime.Name = "btnAdjustTime"
        Me.btnAdjustTime.Size = New System.Drawing.Size(119, 71)
        Me.btnAdjustTime.TabIndex = 14
        Me.btnAdjustTime.Text = "ADJUST LEFT TIME"
        Me.btnAdjustTime.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Location = New System.Drawing.Point(705, 83)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(194, 25)
        Me.lblTotal.TabIndex = 19
        Me.lblTotal.Text = "0 Mins"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAdjustTime
        '
        Me.lblAdjustTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAdjustTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAdjustTime.Location = New System.Drawing.Point(705, 59)
        Me.lblAdjustTime.Name = "lblAdjustTime"
        Me.lblAdjustTime.Size = New System.Drawing.Size(194, 25)
        Me.lblAdjustTime.TabIndex = 19
        Me.lblAdjustTime.Text = "0 Mins"
        Me.lblAdjustTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPlusTime
        '
        Me.btnPlusTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPlusTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlusTime.Location = New System.Drawing.Point(899, 36)
        Me.btnPlusTime.Margin = New System.Windows.Forms.Padding(6)
        Me.btnPlusTime.Name = "btnPlusTime"
        Me.btnPlusTime.Size = New System.Drawing.Size(55, 71)
        Me.btnPlusTime.TabIndex = 13
        Me.btnPlusTime.Text = "+"
        Me.btnPlusTime.UseVisualStyleBackColor = True
        '
        'btnMinusTime
        '
        Me.btnMinusTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinusTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinusTime.Location = New System.Drawing.Point(653, 36)
        Me.btnMinusTime.Margin = New System.Windows.Forms.Padding(6)
        Me.btnMinusTime.Name = "btnMinusTime"
        Me.btnMinusTime.Size = New System.Drawing.Size(52, 71)
        Me.btnMinusTime.TabIndex = 12
        Me.btnMinusTime.Text = "-"
        Me.btnMinusTime.UseVisualStyleBackColor = True
        '
        'lblLeftTime
        '
        Me.lblLeftTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLeftTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLeftTime.Location = New System.Drawing.Point(705, 35)
        Me.lblLeftTime.Name = "lblLeftTime"
        Me.lblLeftTime.Size = New System.Drawing.Size(194, 25)
        Me.lblLeftTime.TabIndex = 17
        Me.lblLeftTime.Text = "0 Mins Left"
        Me.lblLeftTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnAddClient
        '
        Me.btnAddClient.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddClient.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAddClient.Location = New System.Drawing.Point(874, 106)
        Me.btnAddClient.Margin = New System.Windows.Forms.Padding(6)
        Me.btnAddClient.Name = "btnAddClient"
        Me.btnAddClient.Size = New System.Drawing.Size(197, 37)
        Me.btnAddClient.TabIndex = 3
        Me.btnAddClient.Text = "ADD CLIENT"
        Me.btnAddClient.UseVisualStyleBackColor = True
        '
        'btnPauseStart
        '
        Me.btnPauseStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPauseStart.Location = New System.Drawing.Point(653, 106)
        Me.btnPauseStart.Margin = New System.Windows.Forms.Padding(6)
        Me.btnPauseStart.Name = "btnPauseStart"
        Me.btnPauseStart.Size = New System.Drawing.Size(222, 37)
        Me.btnPauseStart.TabIndex = 7
        Me.btnPauseStart.Text = "PAUSE BOOKING"
        Me.btnPauseStart.UseVisualStyleBackColor = True
        '
        'btnChangeService
        '
        Me.btnChangeService.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangeService.Enabled = False
        Me.btnChangeService.Location = New System.Drawing.Point(874, 142)
        Me.btnChangeService.Margin = New System.Windows.Forms.Padding(6)
        Me.btnChangeService.Name = "btnChangeService"
        Me.btnChangeService.Size = New System.Drawing.Size(197, 37)
        Me.btnChangeService.TabIndex = 2
        Me.btnChangeService.Text = "CHANGE SERVICE"
        Me.btnChangeService.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Maroon
        Me.btnCancel.Location = New System.Drawing.Point(653, 142)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(6)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(222, 37)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "CANCEL BOOKING"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnChangeRoom
        '
        Me.btnChangeRoom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangeRoom.Location = New System.Drawing.Point(874, 178)
        Me.btnChangeRoom.Margin = New System.Windows.Forms.Padding(6)
        Me.btnChangeRoom.Name = "btnChangeRoom"
        Me.btnChangeRoom.Size = New System.Drawing.Size(197, 37)
        Me.btnChangeRoom.TabIndex = 1
        Me.btnChangeRoom.Text = "CHANGE ROOM"
        Me.btnChangeRoom.UseVisualStyleBackColor = True
        '
        'btnChangeWorker
        '
        Me.btnChangeWorker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChangeWorker.Location = New System.Drawing.Point(437, 142)
        Me.btnChangeWorker.Margin = New System.Windows.Forms.Padding(6)
        Me.btnChangeWorker.Name = "btnChangeWorker"
        Me.btnChangeWorker.Size = New System.Drawing.Size(218, 37)
        Me.btnChangeWorker.TabIndex = 10
        Me.btnChangeWorker.Text = "CHANGE SP"
        Me.btnChangeWorker.UseVisualStyleBackColor = True
        '
        'btnSuspend
        '
        Me.btnSuspend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSuspend.Location = New System.Drawing.Point(653, 178)
        Me.btnSuspend.Margin = New System.Windows.Forms.Padding(6)
        Me.btnSuspend.Name = "btnSuspend"
        Me.btnSuspend.Size = New System.Drawing.Size(222, 37)
        Me.btnSuspend.TabIndex = 5
        Me.btnSuspend.Text = "SUSPEND"
        Me.btnSuspend.UseVisualStyleBackColor = True
        '
        'btnRemoveWorker
        '
        Me.btnRemoveWorker.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveWorker.Location = New System.Drawing.Point(437, 214)
        Me.btnRemoveWorker.Margin = New System.Windows.Forms.Padding(6)
        Me.btnRemoveWorker.Name = "btnRemoveWorker"
        Me.btnRemoveWorker.Size = New System.Drawing.Size(217, 37)
        Me.btnRemoveWorker.TabIndex = 8
        Me.btnRemoveWorker.Text = "REMOVE SP"
        Me.btnRemoveWorker.UseVisualStyleBackColor = True
        '
        'lblBookingInfo
        '
        Me.lblBookingInfo.Location = New System.Drawing.Point(617, 9)
        Me.lblBookingInfo.Name = "lblBookingInfo"
        Me.lblBookingInfo.Size = New System.Drawing.Size(371, 246)
        Me.lblBookingInfo.TabIndex = 2
        Me.lblBookingInfo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dlgEditBooking
        '
        Me.AcceptButton = Me.btnExtend
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(1077, 596)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblBookingInfo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgEditBooking"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnExtend As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnRemoveWorker As System.Windows.Forms.Button
    Friend WithEvents btnSuspend As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnChangeRoom As System.Windows.Forms.Button
    Friend WithEvents btnChangeWorker As System.Windows.Forms.Button
    Friend WithEvents btnChangeService As System.Windows.Forms.Button
    Friend WithEvents lblBookingInfo As System.Windows.Forms.Label
    Friend WithEvents btnPauseStart As System.Windows.Forms.Button
    Friend WithEvents btnAddClient As System.Windows.Forms.Button
    Friend WithEvents lblLeftTime As System.Windows.Forms.Label
    Friend WithEvents btnPlusTime As System.Windows.Forms.Button
    Friend WithEvents btnMinusTime As System.Windows.Forms.Button
    Friend WithEvents lblAdjustTime As System.Windows.Forms.Label
    Friend WithEvents btnAdjustTime As System.Windows.Forms.Button
    Friend WithEvents btnSwapRoom As System.Windows.Forms.Button
    Friend WithEvents btnSwapSP As System.Windows.Forms.Button
    Friend WithEvents btnReadLoad As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPayment As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnEditBooking As System.Windows.Forms.Button
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
