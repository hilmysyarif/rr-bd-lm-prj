<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDoorChargeReport
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
        Me.Button10 = New System.Windows.Forms.Button()
        Me.btnPrintDoorDaily = New System.Windows.Forms.Button()
        Me.dgDailyDoor = New System.Windows.Forms.DataGridView()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.btnRefreshDoorCharge = New System.Windows.Forms.Button()
        CType(Me.dgDailyDoor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button10
        '
        Me.Button10.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button10.Location = New System.Drawing.Point(698, 517)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(127, 53)
        Me.Button10.TabIndex = 18
        Me.Button10.Tag = "GO BACK"
        Me.Button10.Text = "CHART"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'btnPrintDoorDaily
        '
        Me.btnPrintDoorDaily.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintDoorDaily.Location = New System.Drawing.Point(831, 517)
        Me.btnPrintDoorDaily.Name = "btnPrintDoorDaily"
        Me.btnPrintDoorDaily.Size = New System.Drawing.Size(127, 53)
        Me.btnPrintDoorDaily.TabIndex = 17
        Me.btnPrintDoorDaily.Tag = "GO BACK"
        Me.btnPrintDoorDaily.Text = "PRINT"
        Me.btnPrintDoorDaily.UseVisualStyleBackColor = True
        '
        'dgDailyDoor
        '
        Me.dgDailyDoor.AllowUserToAddRows = False
        Me.dgDailyDoor.AllowUserToDeleteRows = False
        Me.dgDailyDoor.AllowUserToResizeRows = False
        Me.dgDailyDoor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDailyDoor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDailyDoor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgDailyDoor.Location = New System.Drawing.Point(12, 12)
        Me.dgDailyDoor.Name = "dgDailyDoor"
        Me.dgDailyDoor.RowHeadersWidth = 10
        Me.dgDailyDoor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDailyDoor.Size = New System.Drawing.Size(1281, 499)
        Me.dgDailyDoor.TabIndex = 16
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(964, 542)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(159, 26)
        Me.DateTimePicker2.TabIndex = 15
        '
        'btnRefreshDoorCharge
        '
        Me.btnRefreshDoorCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefreshDoorCharge.Location = New System.Drawing.Point(1129, 517)
        Me.btnRefreshDoorCharge.Name = "btnRefreshDoorCharge"
        Me.btnRefreshDoorCharge.Size = New System.Drawing.Size(127, 53)
        Me.btnRefreshDoorCharge.TabIndex = 14
        Me.btnRefreshDoorCharge.Tag = "GO BACK"
        Me.btnRefreshDoorCharge.Text = "REFRESH"
        Me.btnRefreshDoorCharge.UseVisualStyleBackColor = True
        '
        'frmDoorChargeReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1305, 574)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.btnPrintDoorDaily)
        Me.Controls.Add(Me.dgDailyDoor)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.btnRefreshDoorCharge)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmDoorChargeReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Door Charge Report"
        CType(Me.dgDailyDoor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents btnPrintDoorDaily As System.Windows.Forms.Button
    Friend WithEvents dgDailyDoor As System.Windows.Forms.DataGridView
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnRefreshDoorCharge As System.Windows.Forms.Button
End Class
