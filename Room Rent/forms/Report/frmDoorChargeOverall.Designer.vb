<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDoorChargeOverall
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
        Me.Label35 = New System.Windows.Forms.Label()
        Me.dtpOvFrom = New System.Windows.Forms.DateTimePicker()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.dgDoorOverall = New System.Windows.Forms.DataGridView()
        Me.dtpOvTo = New System.Windows.Forms.DateTimePicker()
        Me.Button13 = New System.Windows.Forms.Button()
        CType(Me.dgDoorOverall, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label35
        '
        Me.Label35.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(736, 488)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(46, 20)
        Me.Label35.TabIndex = 22
        Me.Label35.Text = "From"
        '
        'dtpOvFrom
        '
        Me.dtpOvFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpOvFrom.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpOvFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOvFrom.Location = New System.Drawing.Point(786, 484)
        Me.dtpOvFrom.Name = "dtpOvFrom"
        Me.dtpOvFrom.Size = New System.Drawing.Size(181, 26)
        Me.dtpOvFrom.TabIndex = 21
        '
        'Button11
        '
        Me.Button11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button11.Location = New System.Drawing.Point(447, 490)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(127, 49)
        Me.Button11.TabIndex = 20
        Me.Button11.Tag = "GO BACK"
        Me.Button11.Text = "CHART"
        Me.Button11.UseVisualStyleBackColor = True
        Me.Button11.Visible = False
        '
        'Button12
        '
        Me.Button12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button12.Location = New System.Drawing.Point(580, 490)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(127, 49)
        Me.Button12.TabIndex = 19
        Me.Button12.Tag = "GO BACK"
        Me.Button12.Text = "PRINT"
        Me.Button12.UseVisualStyleBackColor = True
        Me.Button12.Visible = False
        '
        'dgDoorOverall
        '
        Me.dgDoorOverall.AllowUserToAddRows = False
        Me.dgDoorOverall.AllowUserToDeleteRows = False
        Me.dgDoorOverall.AllowUserToResizeRows = False
        Me.dgDoorOverall.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDoorOverall.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDoorOverall.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgDoorOverall.Location = New System.Drawing.Point(10, 10)
        Me.dgDoorOverall.Name = "dgDoorOverall"
        Me.dgDoorOverall.RowHeadersWidth = 10
        Me.dgDoorOverall.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDoorOverall.Size = New System.Drawing.Size(1131, 468)
        Me.dgDoorOverall.TabIndex = 18
        '
        'dtpOvTo
        '
        Me.dtpOvTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpOvTo.CustomFormat = "dd/MM/yyyy HH:mm:ss"
        Me.dtpOvTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOvTo.Location = New System.Drawing.Point(786, 511)
        Me.dtpOvTo.Name = "dtpOvTo"
        Me.dtpOvTo.Size = New System.Drawing.Size(181, 26)
        Me.dtpOvTo.TabIndex = 17
        '
        'Button13
        '
        Me.Button13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button13.Location = New System.Drawing.Point(1014, 488)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(127, 49)
        Me.Button13.TabIndex = 16
        Me.Button13.Tag = "GO BACK"
        Me.Button13.Text = "REFRESH"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'frmDoorChargeOverall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 545)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.dtpOvFrom)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.dgDoorOverall)
        Me.Controls.Add(Me.dtpOvTo)
        Me.Controls.Add(Me.Button13)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmDoorChargeOverall"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Overall Door Charge Report"
        CType(Me.dgDoorOverall, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents dtpOvFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents dgDoorOverall As System.Windows.Forms.DataGridView
    Friend WithEvents dtpOvTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button13 As System.Windows.Forms.Button
End Class
