<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHome
    Inherits Room_Rent.frmMainMaster

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
        Me.components = New System.ComponentModel.Container()
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("fvxcv cbbcvbcvb")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("cvbcvbcvbcvb")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("cvbcvxcvxcbcvb")
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("fvxcv cbbcvbcvb")
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("cvbcvbcvbcvb")
        Dim ListViewItem6 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("cvbcvxcvxcbcvb")
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("fvxcv cbbcvbcvb")
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("cvbcvbcvbcvb")
        Dim ListViewItem9 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("cvbcvxcvxcbcvb")
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCheckIn = New System.Windows.Forms.Button()
        Me.lstServiceProvider = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lstQueuedProvider = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lstActiveProvider = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnMerchandise = New System.Windows.Forms.Button()
        Me.btnBooking = New System.Windows.Forms.Button()
        Me.dgQueuedBooking = New System.Windows.Forms.DataGridView()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.tmrTimeLeftCounter = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SERVICEWORKER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ROOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SERVICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMELEFT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMEADDED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Door = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgQueuedBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnCheckIn)
        Me.GroupBox1.Controls.Add(Me.lstServiceProvider)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 406)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SERVICE PROVIDERS AVAILABLE"
        '
        'btnCheckIn
        '
        Me.btnCheckIn.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCheckIn.Location = New System.Drawing.Point(123, 363)
        Me.btnCheckIn.Name = "btnCheckIn"
        Me.btnCheckIn.Size = New System.Drawing.Size(98, 37)
        Me.btnCheckIn.TabIndex = 8
        Me.btnCheckIn.Text = "Check IN"
        Me.btnCheckIn.UseVisualStyleBackColor = True
        '
        'lstServiceProvider
        '
        Me.lstServiceProvider.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstServiceProvider.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstServiceProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstServiceProvider.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstServiceProvider.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
        Me.lstServiceProvider.Location = New System.Drawing.Point(7, 17)
        Me.lstServiceProvider.MultiSelect = False
        Me.lstServiceProvider.Name = "lstServiceProvider"
        Me.lstServiceProvider.Size = New System.Drawing.Size(331, 340)
        Me.lstServiceProvider.TabIndex = 7
        Me.lstServiceProvider.UseCompatibleStateImageBehavior = False
        Me.lstServiceProvider.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 280
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lstQueuedProvider)
        Me.GroupBox2.Location = New System.Drawing.Point(368, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(344, 406)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "QUEUED PROVIDERS"
        '
        'lstQueuedProvider
        '
        Me.lstQueuedProvider.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstQueuedProvider.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.lstQueuedProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstQueuedProvider.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstQueuedProvider.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem4, ListViewItem5, ListViewItem6})
        Me.lstQueuedProvider.Location = New System.Drawing.Point(6, 17)
        Me.lstQueuedProvider.MultiSelect = False
        Me.lstQueuedProvider.Name = "lstQueuedProvider"
        Me.lstQueuedProvider.Size = New System.Drawing.Size(332, 382)
        Me.lstQueuedProvider.TabIndex = 8
        Me.lstQueuedProvider.UseCompatibleStateImageBehavior = False
        Me.lstQueuedProvider.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = ""
        Me.ColumnHeader2.Width = 280
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lstActiveProvider)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(349, 203)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "ACTIVE PROVIDERS"
        '
        'lstActiveProvider
        '
        Me.lstActiveProvider.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstActiveProvider.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lstActiveProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstActiveProvider.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstActiveProvider.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem7, ListViewItem8, ListViewItem9})
        Me.lstActiveProvider.Location = New System.Drawing.Point(6, 17)
        Me.lstActiveProvider.MultiSelect = False
        Me.lstActiveProvider.Name = "lstActiveProvider"
        Me.lstActiveProvider.Size = New System.Drawing.Size(337, 180)
        Me.lstActiveProvider.TabIndex = 9
        Me.lstActiveProvider.UseCompatibleStateImageBehavior = False
        Me.lstActiveProvider.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 280
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.GroupBox6)
        Me.GroupBox4.Location = New System.Drawing.Point(1073, 69)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(216, 406)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.Button3)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(204, 207)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 40)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "$0.00"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 29)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "TOTAL"
        '
        'Button3
        '
        Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button3.Location = New System.Drawing.Point(29, 167)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(142, 37)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "PRINT"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button2.Location = New System.Drawing.Point(29, 55)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(142, 37)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "CARD"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Location = New System.Drawing.Point(29, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(142, 37)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "CASH"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox6.Controls.Add(Me.Button7)
        Me.GroupBox6.Controls.Add(Me.Button6)
        Me.GroupBox6.Controls.Add(Me.btnMerchandise)
        Me.GroupBox6.Controls.Add(Me.btnBooking)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 215)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(204, 184)
        Me.GroupBox6.TabIndex = 3
        Me.GroupBox6.TabStop = False
        '
        'Button7
        '
        Me.Button7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button7.Location = New System.Drawing.Point(29, 141)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(142, 37)
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "ADMINISTRATION"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button6.Location = New System.Drawing.Point(29, 98)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(142, 37)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "MISCELLANEOUS"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btnMerchandise
        '
        Me.btnMerchandise.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnMerchandise.Location = New System.Drawing.Point(29, 55)
        Me.btnMerchandise.Name = "btnMerchandise"
        Me.btnMerchandise.Size = New System.Drawing.Size(142, 37)
        Me.btnMerchandise.TabIndex = 8
        Me.btnMerchandise.Text = "MERCHANDISE SALES"
        Me.btnMerchandise.UseVisualStyleBackColor = True
        '
        'btnBooking
        '
        Me.btnBooking.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBooking.Location = New System.Drawing.Point(29, 12)
        Me.btnBooking.Name = "btnBooking"
        Me.btnBooking.Size = New System.Drawing.Size(142, 37)
        Me.btnBooking.TabIndex = 8
        Me.btnBooking.Text = "PRE BOOKING"
        Me.btnBooking.UseVisualStyleBackColor = True
        '
        'dgQueuedBooking
        '
        Me.dgQueuedBooking.AllowUserToAddRows = False
        Me.dgQueuedBooking.AllowUserToDeleteRows = False
        Me.dgQueuedBooking.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgQueuedBooking.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgQueuedBooking.BackgroundColor = System.Drawing.SystemColors.ControlLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgQueuedBooking.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgQueuedBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgQueuedBooking.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SERVICEWORKER, Me.ROOM, Me.SERVICE, Me.TIMELEFT, Me.TIMEADDED, Me.Door, Me.Column1, Me.Column2, Me.STATUS})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgQueuedBooking.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgQueuedBooking.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgQueuedBooking.Location = New System.Drawing.Point(6, 19)
        Me.dgQueuedBooking.Name = "dgQueuedBooking"
        Me.dgQueuedBooking.RowHeadersVisible = False
        Me.dgQueuedBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgQueuedBooking.Size = New System.Drawing.Size(337, 171)
        Me.dgQueuedBooking.TabIndex = 10
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.dgQueuedBooking)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(349, 199)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "QUEUE BOOKING"
        '
        'tmrTimeLeftCounter
        '
        Me.tmrTimeLeftCounter.Interval = 20000
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Location = New System.Drawing.Point(718, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(349, 406)
        Me.Panel1.TabIndex = 8
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox7)
        Me.SplitContainer1.Size = New System.Drawing.Size(349, 406)
        Me.SplitContainer1.SplitterDistance = 203
        Me.SplitContainer1.TabIndex = 3
        '
        'SERVICEWORKER
        '
        Me.SERVICEWORKER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        DataGridViewCellStyle2.NullValue = Nothing
        Me.SERVICEWORKER.DefaultCellStyle = DataGridViewCellStyle2
        Me.SERVICEWORKER.HeaderText = "SERVICE WORKER"
        Me.SERVICEWORKER.Name = "SERVICEWORKER"
        Me.SERVICEWORKER.Width = 130
        '
        'ROOM
        '
        Me.ROOM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ROOM.HeaderText = "ROOM"
        Me.ROOM.Name = "ROOM"
        Me.ROOM.Width = 65
        '
        'SERVICE
        '
        Me.SERVICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SERVICE.HeaderText = "SERVICE"
        Me.SERVICE.Name = "SERVICE"
        Me.SERVICE.Width = 78
        '
        'TIMELEFT
        '
        Me.TIMELEFT.HeaderText = "TIME LEFT"
        Me.TIMELEFT.Name = "TIMELEFT"
        Me.TIMELEFT.Visible = False
        '
        'TIMEADDED
        '
        Me.TIMEADDED.HeaderText = "DATE"
        Me.TIMEADDED.Name = "TIMEADDED"
        Me.TIMEADDED.ReadOnly = True
        '
        'Door
        '
        Me.Door.HeaderText = "DOOR"
        Me.Door.Name = "Door"
        Me.Door.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "DOORCHARGE"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "BOOKINGID"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'STATUS
        '
        Me.STATUS.HeaderText = "STATUS"
        Me.STATUS.Name = "STATUS"
        Me.STATUS.ReadOnly = True
        Me.STATUS.Visible = False
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 487)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmHome"
        Me.Text = "Home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgQueuedBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lstServiceProvider As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstQueuedProvider As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstActiveProvider As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCheckIn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btnMerchandise As System.Windows.Forms.Button
    Friend WithEvents btnBooking As System.Windows.Forms.Button
    Friend WithEvents dgQueuedBooking As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents tmrTimeLeftCounter As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SERVICEWORKER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ROOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SERVICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMELEFT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMEADDED As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Door As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STATUS As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
