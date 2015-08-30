<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLockers2
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgLockers = New System.Windows.Forms.DataGridView()
        CType(Me.dgLockers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(624, 452)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(148, 56)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "GO BACK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(12, 452)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(148, 56)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "REFRESH"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dgLockers
        '
        Me.dgLockers.AllowUserToAddRows = False
        Me.dgLockers.AllowUserToDeleteRows = False
        Me.dgLockers.AllowUserToResizeColumns = False
        Me.dgLockers.AllowUserToResizeRows = False
        Me.dgLockers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgLockers.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgLockers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgLockers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgLockers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLockers.ColumnHeadersVisible = False
        Me.dgLockers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgLockers.Location = New System.Drawing.Point(12, 12)
        Me.dgLockers.MultiSelect = False
        Me.dgLockers.Name = "dgLockers"
        Me.dgLockers.RowHeadersVisible = False
        Me.dgLockers.Size = New System.Drawing.Size(759, 434)
        Me.dgLockers.TabIndex = 4
        '
        'frmLockers2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(784, 513)
        Me.Controls.Add(Me.dgLockers)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmLockers2"
        Me.Text = "Lockers"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgLockers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dgLockers As System.Windows.Forms.DataGridView
End Class
