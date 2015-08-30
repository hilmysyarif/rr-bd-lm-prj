<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVoucherAdd
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.txtSave = New System.Windows.Forms.Button()
        Me.btnBCK = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.DateTimePicker()
        Me.txtValue = New Room_Rent.NumericTextBox()
        Me.txtValid = New Room_Rent.NumericTextBox()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.txtRefID = New System.Windows.Forms.TextBox()
        Me.txtVoucherNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(551, 34)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnNew)
        Me.Panel2.Controls.Add(Me.txtSave)
        Me.Panel2.Controls.Add(Me.btnBCK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 314)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(551, 50)
        Me.Panel2.TabIndex = 2
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(328, 6)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 37)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "NEW"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'txtSave
        '
        Me.txtSave.Location = New System.Drawing.Point(409, 6)
        Me.txtSave.Name = "txtSave"
        Me.txtSave.Size = New System.Drawing.Size(130, 37)
        Me.txtSave.TabIndex = 0
        Me.txtSave.Text = "SAVE && PRINT"
        Me.txtSave.UseVisualStyleBackColor = True
        '
        'btnBCK
        '
        Me.btnBCK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBCK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBCK.Location = New System.Drawing.Point(12, 6)
        Me.btnBCK.Name = "btnBCK"
        Me.btnBCK.Size = New System.Drawing.Size(104, 37)
        Me.btnBCK.TabIndex = 2
        Me.btnBCK.Text = "GO BACK"
        Me.btnBCK.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtDate)
        Me.Panel3.Controls.Add(Me.txtValue)
        Me.Panel3.Controls.Add(Me.txtValid)
        Me.Panel3.Controls.Add(Me.txtComments)
        Me.Panel3.Controls.Add(Me.txtRefID)
        Me.Panel3.Controls.Add(Me.txtVoucherNo)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 34)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(551, 280)
        Me.Panel3.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(384, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(125, 9)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = " PS : Put '0'('Zero') for NO EXPIRY"
        '
        'txtDate
        '
        Me.txtDate.CustomFormat = "dd/MM/yyyy"
        Me.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.txtDate.Location = New System.Drawing.Point(242, 94)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(139, 26)
        Me.txtDate.TabIndex = 1
        '
        'txtValue
        '
        Me.txtValue.AllowSpace = False
        Me.txtValue.DecimalSeparator = False
        Me.txtValue.GroupSeperator = False
        Me.txtValue.Location = New System.Drawing.Point(242, 152)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Negative = False
        Me.txtValue.Size = New System.Drawing.Size(139, 26)
        Me.txtValue.Space = False
        Me.txtValue.TabIndex = 3
        Me.txtValue.Text = "0.00"
        Me.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValid
        '
        Me.txtValid.AllowSpace = False
        Me.txtValid.DecimalSeparator = False
        Me.txtValid.GroupSeperator = False
        Me.txtValid.Location = New System.Drawing.Point(242, 123)
        Me.txtValid.Name = "txtValid"
        Me.txtValid.Negative = False
        Me.txtValid.Size = New System.Drawing.Size(139, 26)
        Me.txtValid.Space = False
        Me.txtValid.TabIndex = 2
        Me.txtValid.Text = "0"
        Me.txtValid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(242, 181)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(139, 26)
        Me.txtComments.TabIndex = 4
        '
        'txtRefID
        '
        Me.txtRefID.Location = New System.Drawing.Point(242, 65)
        Me.txtRefID.Name = "txtRefID"
        Me.txtRefID.Size = New System.Drawing.Size(139, 26)
        Me.txtRefID.TabIndex = 0
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.Location = New System.Drawing.Point(242, 36)
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.ReadOnly = True
        Me.txtVoucherNo.Size = New System.Drawing.Size(139, 26)
        Me.txtVoucherNo.TabIndex = 0
        Me.txtVoucherNo.TabStop = False
        Me.txtVoucherNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(65, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Comment :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(384, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Days"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(65, 126)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Valid For :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(65, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Value :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(65, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Date :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Reference ID :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "GIFT VOUCHER NO."
        '
        'frmVoucherAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnBCK
        Me.ClientSize = New System.Drawing.Size(551, 364)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "frmVoucherAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vouchers"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents txtSave As System.Windows.Forms.Button
    Friend WithEvents btnBCK As System.Windows.Forms.Button
    Friend WithEvents txtRefID As System.Windows.Forms.TextBox
    Friend WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtValue As Room_Rent.NumericTextBox
    Friend WithEvents txtValid As Room_Rent.NumericTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
End Class
