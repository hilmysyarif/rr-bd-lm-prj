<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjustReport
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ntxtTotalBookin = New System.Windows.Forms.NumericUpDown()
        Me.ntxtCashBookings = New System.Windows.Forms.NumericUpDown()
        Me.txtTotalBooking = New System.Windows.Forms.TextBox()
        Me.txtTotalCash = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.ntxtTotalBookin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ntxtCashBookings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(107, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Bookings :"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(107, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Total Cash Amount :"
        '
        'ntxtTotalBookin
        '
        Me.ntxtTotalBookin.Location = New System.Drawing.Point(409, 43)
        Me.ntxtTotalBookin.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.ntxtTotalBookin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ntxtTotalBookin.Name = "ntxtTotalBookin"
        Me.ntxtTotalBookin.Size = New System.Drawing.Size(120, 29)
        Me.ntxtTotalBookin.TabIndex = 0
        Me.ntxtTotalBookin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ntxtTotalBookin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ntxtTotalBookin.Visible = False
        '
        'ntxtCashBookings
        '
        Me.ntxtCashBookings.DecimalPlaces = 2
        Me.ntxtCashBookings.Location = New System.Drawing.Point(409, 44)
        Me.ntxtCashBookings.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.ntxtCashBookings.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.ntxtCashBookings.Name = "ntxtCashBookings"
        Me.ntxtCashBookings.Size = New System.Drawing.Size(120, 29)
        Me.ntxtCashBookings.TabIndex = 1
        Me.ntxtCashBookings.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ntxtCashBookings.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtTotalBooking
        '
        Me.txtTotalBooking.Location = New System.Drawing.Point(289, 43)
        Me.txtTotalBooking.Name = "txtTotalBooking"
        Me.txtTotalBooking.ReadOnly = True
        Me.txtTotalBooking.Size = New System.Drawing.Size(114, 29)
        Me.txtTotalBooking.TabIndex = 4
        Me.txtTotalBooking.TabStop = False
        Me.txtTotalBooking.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalBooking.Visible = False
        '
        'txtTotalCash
        '
        Me.txtTotalCash.Location = New System.Drawing.Point(289, 44)
        Me.txtTotalCash.Name = "txtTotalCash"
        Me.txtTotalCash.ReadOnly = True
        Me.txtTotalCash.Size = New System.Drawing.Size(114, 29)
        Me.txtTotalCash.TabIndex = 5
        Me.txtTotalCash.TabStop = False
        Me.txtTotalCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(12, 122)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(185, 51)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "GO BACK"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(439, 122)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(185, 51)
        Me.btnDone.TabIndex = 2
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(298, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "ORIGINAL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(415, 16)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "ADJUSTED"
        '
        'frmAdjustReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 185)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtTotalCash)
        Me.Controls.Add(Me.txtTotalBooking)
        Me.Controls.Add(Me.ntxtCashBookings)
        Me.Controls.Add(Me.ntxtTotalBookin)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAdjustReport"
        Me.ShowInTaskbar = False
        Me.Text = "Adjust Report"
        CType(Me.ntxtTotalBookin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ntxtCashBookings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ntxtTotalBookin As System.Windows.Forms.NumericUpDown
    Friend WithEvents ntxtCashBookings As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtTotalBooking As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCash As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
