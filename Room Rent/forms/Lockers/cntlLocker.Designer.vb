<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cntlLocker
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblLockerDetails = New System.Windows.Forms.Label()
        Me.lblBookingDetails = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblLockerDetails
        '
        Me.lblLockerDetails.AutoSize = True
        Me.lblLockerDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblLockerDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLockerDetails.Location = New System.Drawing.Point(0, 0)
        Me.lblLockerDetails.MaximumSize = New System.Drawing.Size(200, 100)
        Me.lblLockerDetails.Name = "lblLockerDetails"
        Me.lblLockerDetails.Padding = New System.Windows.Forms.Padding(5, 3, 5, 0)
        Me.lblLockerDetails.Size = New System.Drawing.Size(194, 48)
        Me.lblLockerDetails.TabIndex = 0
        Me.lblLockerDetails.Text = "asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd"
        '
        'lblBookingDetails
        '
        Me.lblBookingDetails.AutoSize = True
        Me.lblBookingDetails.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblBookingDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBookingDetails.Location = New System.Drawing.Point(0, 48)
        Me.lblBookingDetails.MaximumSize = New System.Drawing.Size(200, 100)
        Me.lblBookingDetails.Name = "lblBookingDetails"
        Me.lblBookingDetails.Padding = New System.Windows.Forms.Padding(5, 4, 5, 0)
        Me.lblBookingDetails.Size = New System.Drawing.Size(61, 19)
        Me.lblBookingDetails.TabIndex = 1
        Me.lblBookingDetails.Text = "Label2"
        '
        'cntlLocker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblBookingDetails)
        Me.Controls.Add(Me.lblLockerDetails)
        Me.Name = "cntlLocker"
        Me.Size = New System.Drawing.Size(200, 130)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLockerDetails As System.Windows.Forms.Label
    Friend WithEvents lblBookingDetails As System.Windows.Forms.Label

End Class
