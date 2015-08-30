<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSPIncomeReport
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
        Me.Button6 = New System.Windows.Forms.Button()
        Me.dgDailyWorkerWise = New System.Windows.Forms.DataGridView()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.Button7 = New System.Windows.Forms.Button()
        CType(Me.dgDailyWorkerWise, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Location = New System.Drawing.Point(827, 520)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(127, 53)
        Me.Button6.TabIndex = 20
        Me.Button6.Tag = "GO BACK"
        Me.Button6.Text = "PRINT"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'dgDailyWorkerWise
        '
        Me.dgDailyWorkerWise.AllowUserToAddRows = False
        Me.dgDailyWorkerWise.AllowUserToDeleteRows = False
        Me.dgDailyWorkerWise.AllowUserToResizeRows = False
        Me.dgDailyWorkerWise.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDailyWorkerWise.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDailyWorkerWise.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgDailyWorkerWise.Location = New System.Drawing.Point(12, 12)
        Me.dgDailyWorkerWise.Name = "dgDailyWorkerWise"
        Me.dgDailyWorkerWise.RowHeadersWidth = 10
        Me.dgDailyWorkerWise.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgDailyWorkerWise.Size = New System.Drawing.Size(1276, 502)
        Me.dgDailyWorkerWise.TabIndex = 19
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker4.Location = New System.Drawing.Point(960, 545)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.Size = New System.Drawing.Size(159, 26)
        Me.DateTimePicker4.TabIndex = 18
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.Location = New System.Drawing.Point(1125, 520)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(127, 53)
        Me.Button7.TabIndex = 17
        Me.Button7.Tag = "GO BACK"
        Me.Button7.Text = "REFRESH"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'frmWorkerIncomeReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1300, 577)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.dgDailyWorkerWise)
        Me.Controls.Add(Me.DateTimePicker4)
        Me.Controls.Add(Me.Button7)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmWorkerIncomeReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SP Income Report"
        CType(Me.dgDailyWorkerWise, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents dgDailyWorkerWise As System.Windows.Forms.DataGridView
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button7 As System.Windows.Forms.Button
End Class
