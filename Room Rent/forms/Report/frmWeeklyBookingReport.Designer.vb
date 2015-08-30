<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWeeklyBookingReport
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
        Me.Button8 = New System.Windows.Forms.Button()
        Me.DateTimePicker5 = New System.Windows.Forms.DateTimePicker()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.dgWeeklyBooking = New System.Windows.Forms.DataGridView()
        CType(Me.dgWeeklyBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.Location = New System.Drawing.Point(705, 505)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(127, 53)
        Me.Button8.TabIndex = 21
        Me.Button8.Tag = "GO BACK"
        Me.Button8.Text = "PRINT"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'DateTimePicker5
        '
        Me.DateTimePicker5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker5.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker5.Location = New System.Drawing.Point(838, 530)
        Me.DateTimePicker5.Name = "DateTimePicker5"
        Me.DateTimePicker5.Size = New System.Drawing.Size(159, 26)
        Me.DateTimePicker5.TabIndex = 20
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button9.Location = New System.Drawing.Point(1003, 505)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(127, 53)
        Me.Button9.TabIndex = 19
        Me.Button9.Tag = "GO BACK"
        Me.Button9.Text = "REFRESH"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'dgWeeklyBooking
        '
        Me.dgWeeklyBooking.AllowUserToAddRows = False
        Me.dgWeeklyBooking.AllowUserToDeleteRows = False
        Me.dgWeeklyBooking.AllowUserToResizeRows = False
        Me.dgWeeklyBooking.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgWeeklyBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgWeeklyBooking.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgWeeklyBooking.Location = New System.Drawing.Point(12, 12)
        Me.dgWeeklyBooking.Name = "dgWeeklyBooking"
        Me.dgWeeklyBooking.RowHeadersWidth = 10
        Me.dgWeeklyBooking.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgWeeklyBooking.Size = New System.Drawing.Size(1138, 487)
        Me.dgWeeklyBooking.TabIndex = 18
        '
        'frmWeeklyBookingReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1162, 570)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.DateTimePicker5)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.dgWeeklyBooking)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmWeeklyBookingReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Weekly Booking Report"
        CType(Me.dgWeeklyBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker5 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents dgWeeklyBooking As System.Windows.Forms.DataGridView
End Class
