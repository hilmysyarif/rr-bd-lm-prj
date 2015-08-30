<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuspensions
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgActiveBooking = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SERVICEWORKER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ROOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SERVICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMELEFT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMEADDED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.BookingID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgActiveBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(697, 35)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 361)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(697, 58)
        Me.Panel2.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(12, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(124, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "GO BACK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgActiveBooking)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 35)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(697, 326)
        Me.Panel3.TabIndex = 2
        '
        'dgActiveBooking
        '
        Me.dgActiveBooking.AllowUserToAddRows = False
        Me.dgActiveBooking.AllowUserToDeleteRows = False
        Me.dgActiveBooking.AllowUserToResizeRows = False
        Me.dgActiveBooking.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgActiveBooking.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgActiveBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgActiveBooking.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.SERVICEWORKER, Me.ROOM, Me.SERVICE, Me.TIMELEFT, Me.TIMEADDED, Me.Column6, Me.Column8, Me.Column7, Me.BookingID})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgActiveBooking.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgActiveBooking.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgActiveBooking.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgActiveBooking.EnableHeadersVisualStyles = False
        Me.dgActiveBooking.Location = New System.Drawing.Point(0, 0)
        Me.dgActiveBooking.MultiSelect = False
        Me.dgActiveBooking.Name = "dgActiveBooking"
        Me.dgActiveBooking.RowHeadersVisible = False
        Me.dgActiveBooking.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgActiveBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgActiveBooking.Size = New System.Drawing.Size(697, 326)
        Me.dgActiveBooking.TabIndex = 11
        '
        'Column1
        '
        Me.Column1.HeaderText = "WorkerID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        Me.Column1.Width = 5
        '
        'SERVICEWORKER
        '
        Me.SERVICEWORKER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.NullValue = Nothing
        Me.SERVICEWORKER.DefaultCellStyle = DataGridViewCellStyle2
        Me.SERVICEWORKER.FillWeight = 304.5685!
        Me.SERVICEWORKER.HeaderText = "SP"
        Me.SERVICEWORKER.Name = "SERVICEWORKER"
        '
        'ROOM
        '
        Me.ROOM.FillWeight = 31.81049!
        Me.ROOM.HeaderText = "ROOM"
        Me.ROOM.Name = "ROOM"
        Me.ROOM.Width = 47
        '
        'SERVICE
        '
        Me.SERVICE.FillWeight = 31.81049!
        Me.SERVICE.HeaderText = "SERVICE"
        Me.SERVICE.Name = "SERVICE"
        Me.SERVICE.Width = 55
        '
        'TIMELEFT
        '
        Me.TIMELEFT.FillWeight = 31.81049!
        Me.TIMELEFT.HeaderText = "TIME LEFT"
        Me.TIMELEFT.Name = "TIMELEFT"
        Me.TIMELEFT.Width = 65
        '
        'TIMEADDED
        '
        Me.TIMEADDED.HeaderText = "DATE"
        Me.TIMEADDED.Name = "TIMEADDED"
        Me.TIMEADDED.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "ActiveSL"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "STATUS"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Visible = False
        '
        'Column7
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Green
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column7.HeaderText = ""
        Me.Column7.Name = "Column7"
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column7.Text = "ACTIVATE"
        Me.Column7.ToolTipText = "ACTIVATE"
        Me.Column7.Width = 90
        '
        'BookingID
        '
        Me.BookingID.HeaderText = "BookingID"
        Me.BookingID.Name = "BookingID"
        Me.BookingID.ReadOnly = True
        Me.BookingID.Visible = False
        '
        'frmSuspensions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 419)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmSuspensions"
        Me.Text = "Suspensions"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgActiveBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgActiveBooking As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SERVICEWORKER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ROOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SERVICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMELEFT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMEADDED As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents BookingID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
