<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgPreBookingEditMenu
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
        Me.btnConfirmClient = New System.Windows.Forms.Button()
        Me.btnConfirmSP = New System.Windows.Forms.Button()
        Me.btnReschedule = New System.Windows.Forms.Button()
        Me.btnChangeSP = New System.Windows.Forms.Button()
        Me.btnDeleteCancelBooking = New System.Windows.Forms.Button()
        Me.btnGoBack = New System.Windows.Forms.Button()
        Me.btnStartBooking = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnConfirmClient
        '
        Me.btnConfirmClient.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmClient.Location = New System.Drawing.Point(39, 16)
        Me.btnConfirmClient.Name = "btnConfirmClient"
        Me.btnConfirmClient.Size = New System.Drawing.Size(201, 77)
        Me.btnConfirmClient.TabIndex = 0
        Me.btnConfirmClient.Text = "Confirm Client"
        Me.btnConfirmClient.UseVisualStyleBackColor = True
        '
        'btnConfirmSP
        '
        Me.btnConfirmSP.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmSP.Location = New System.Drawing.Point(39, 99)
        Me.btnConfirmSP.Name = "btnConfirmSP"
        Me.btnConfirmSP.Size = New System.Drawing.Size(201, 77)
        Me.btnConfirmSP.TabIndex = 2
        Me.btnConfirmSP.Text = "Confirm SP"
        Me.btnConfirmSP.UseVisualStyleBackColor = True
        '
        'btnReschedule
        '
        Me.btnReschedule.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReschedule.Location = New System.Drawing.Point(39, 182)
        Me.btnReschedule.Name = "btnReschedule"
        Me.btnReschedule.Size = New System.Drawing.Size(201, 77)
        Me.btnReschedule.TabIndex = 4
        Me.btnReschedule.Text = "Re-Schedule"
        Me.btnReschedule.UseVisualStyleBackColor = True
        '
        'btnChangeSP
        '
        Me.btnChangeSP.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChangeSP.Location = New System.Drawing.Point(246, 16)
        Me.btnChangeSP.Name = "btnChangeSP"
        Me.btnChangeSP.Size = New System.Drawing.Size(201, 77)
        Me.btnChangeSP.TabIndex = 1
        Me.btnChangeSP.Text = "Change SP"
        Me.btnChangeSP.UseVisualStyleBackColor = True
        '
        'btnDeleteCancelBooking
        '
        Me.btnDeleteCancelBooking.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteCancelBooking.Location = New System.Drawing.Point(246, 99)
        Me.btnDeleteCancelBooking.Name = "btnDeleteCancelBooking"
        Me.btnDeleteCancelBooking.Size = New System.Drawing.Size(201, 77)
        Me.btnDeleteCancelBooking.TabIndex = 3
        Me.btnDeleteCancelBooking.Text = "Delete/Cancel Booking"
        Me.btnDeleteCancelBooking.UseVisualStyleBackColor = True
        '
        'btnGoBack
        '
        Me.btnGoBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGoBack.Location = New System.Drawing.Point(39, 265)
        Me.btnGoBack.Name = "btnGoBack"
        Me.btnGoBack.Size = New System.Drawing.Size(408, 77)
        Me.btnGoBack.TabIndex = 6
        Me.btnGoBack.Text = "GO BACK"
        Me.btnGoBack.UseVisualStyleBackColor = True
        '
        'btnStartBooking
        '
        Me.btnStartBooking.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartBooking.Location = New System.Drawing.Point(246, 182)
        Me.btnStartBooking.Name = "btnStartBooking"
        Me.btnStartBooking.Size = New System.Drawing.Size(201, 77)
        Me.btnStartBooking.TabIndex = 5
        Me.btnStartBooking.Text = "Start Booking"
        Me.btnStartBooking.UseVisualStyleBackColor = True
        '
        'dlgPreBookingEditMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 359)
        Me.Controls.Add(Me.btnStartBooking)
        Me.Controls.Add(Me.btnGoBack)
        Me.Controls.Add(Me.btnDeleteCancelBooking)
        Me.Controls.Add(Me.btnChangeSP)
        Me.Controls.Add(Me.btnReschedule)
        Me.Controls.Add(Me.btnConfirmSP)
        Me.Controls.Add(Me.btnConfirmClient)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgPreBookingEditMenu"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit PreBooking"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnConfirmClient As System.Windows.Forms.Button
    Friend WithEvents btnConfirmSP As System.Windows.Forms.Button
    Friend WithEvents btnReschedule As System.Windows.Forms.Button
    Friend WithEvents btnChangeSP As System.Windows.Forms.Button
    Friend WithEvents btnDeleteCancelBooking As System.Windows.Forms.Button
    Friend WithEvents btnGoBack As System.Windows.Forms.Button
    Friend WithEvents btnStartBooking As System.Windows.Forms.Button
End Class
