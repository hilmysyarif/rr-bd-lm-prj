<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWorkerLookUp
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
        Me.GrpBox_Available = New System.Windows.Forms.GroupBox()
        Me.lstAvailable = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GrpBox_DC_14_Days = New System.Windows.Forms.GroupBox()
        Me.LstDC_14_Days = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GrpBox_DC_NOT_Updated = New System.Windows.Forms.GroupBox()
        Me.LstNotUpdated = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GrpBox_Suspended = New System.Windows.Forms.GroupBox()
        Me.LstSuspended = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Bttn_Checkin = New System.Windows.Forms.Button()
        Me.btnAddPeople = New System.Windows.Forms.Button()
        Me.lnlCust = New System.Windows.Forms.LinkLabel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.GrpBox_Available.SuspendLayout()
        Me.GrpBox_DC_14_Days.SuspendLayout()
        Me.GrpBox_DC_NOT_Updated.SuspendLayout()
        Me.GrpBox_Suspended.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBox_Available
        '
        Me.GrpBox_Available.Controls.Add(Me.lstAvailable)
        Me.GrpBox_Available.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpBox_Available.ForeColor = System.Drawing.Color.DarkGreen
        Me.GrpBox_Available.Location = New System.Drawing.Point(0, 0)
        Me.GrpBox_Available.Name = "GrpBox_Available"
        Me.GrpBox_Available.Size = New System.Drawing.Size(331, 409)
        Me.GrpBox_Available.TabIndex = 0
        Me.GrpBox_Available.TabStop = False
        Me.GrpBox_Available.Text = "AVAILABLE"
        '
        'lstAvailable
        '
        Me.lstAvailable.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstAvailable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstAvailable.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAvailable.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstAvailable.Location = New System.Drawing.Point(3, 16)
        Me.lstAvailable.MultiSelect = False
        Me.lstAvailable.Name = "lstAvailable"
        Me.lstAvailable.Size = New System.Drawing.Size(325, 390)
        Me.lstAvailable.TabIndex = 7
        Me.lstAvailable.UseCompatibleStateImageBehavior = False
        Me.lstAvailable.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 280
        '
        'GrpBox_DC_14_Days
        '
        Me.GrpBox_DC_14_Days.Controls.Add(Me.LstDC_14_Days)
        Me.GrpBox_DC_14_Days.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpBox_DC_14_Days.ForeColor = System.Drawing.Color.Gold
        Me.GrpBox_DC_14_Days.Location = New System.Drawing.Point(0, 0)
        Me.GrpBox_DC_14_Days.Name = "GrpBox_DC_14_Days"
        Me.GrpBox_DC_14_Days.Size = New System.Drawing.Size(331, 433)
        Me.GrpBox_DC_14_Days.TabIndex = 1
        Me.GrpBox_DC_14_Days.TabStop = False
        Me.GrpBox_DC_14_Days.Text = "DC IN 14 DAYS"
        '
        'LstDC_14_Days
        '
        Me.LstDC_14_Days.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2})
        Me.LstDC_14_Days.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstDC_14_Days.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstDC_14_Days.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LstDC_14_Days.Location = New System.Drawing.Point(3, 16)
        Me.LstDC_14_Days.MultiSelect = False
        Me.LstDC_14_Days.Name = "LstDC_14_Days"
        Me.LstDC_14_Days.Size = New System.Drawing.Size(325, 414)
        Me.LstDC_14_Days.TabIndex = 8
        Me.LstDC_14_Days.UseCompatibleStateImageBehavior = False
        Me.LstDC_14_Days.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = ""
        Me.ColumnHeader2.Width = 280
        '
        'GrpBox_DC_NOT_Updated
        '
        Me.GrpBox_DC_NOT_Updated.Controls.Add(Me.LstNotUpdated)
        Me.GrpBox_DC_NOT_Updated.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpBox_DC_NOT_Updated.ForeColor = System.Drawing.Color.Gold
        Me.GrpBox_DC_NOT_Updated.Location = New System.Drawing.Point(0, 0)
        Me.GrpBox_DC_NOT_Updated.Name = "GrpBox_DC_NOT_Updated"
        Me.GrpBox_DC_NOT_Updated.Size = New System.Drawing.Size(331, 503)
        Me.GrpBox_DC_NOT_Updated.TabIndex = 2
        Me.GrpBox_DC_NOT_Updated.TabStop = False
        Me.GrpBox_DC_NOT_Updated.Text = "DC NOT UPDATED"
        '
        'LstNotUpdated
        '
        Me.LstNotUpdated.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.LstNotUpdated.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstNotUpdated.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstNotUpdated.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LstNotUpdated.Location = New System.Drawing.Point(3, 16)
        Me.LstNotUpdated.MultiSelect = False
        Me.LstNotUpdated.Name = "LstNotUpdated"
        Me.LstNotUpdated.Size = New System.Drawing.Size(325, 484)
        Me.LstNotUpdated.TabIndex = 9
        Me.LstNotUpdated.UseCompatibleStateImageBehavior = False
        Me.LstNotUpdated.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 280
        '
        'GrpBox_Suspended
        '
        Me.GrpBox_Suspended.Controls.Add(Me.LstSuspended)
        Me.GrpBox_Suspended.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GrpBox_Suspended.ForeColor = System.Drawing.Color.Red
        Me.GrpBox_Suspended.Location = New System.Drawing.Point(0, 0)
        Me.GrpBox_Suspended.Name = "GrpBox_Suspended"
        Me.GrpBox_Suspended.Size = New System.Drawing.Size(333, 503)
        Me.GrpBox_Suspended.TabIndex = 3
        Me.GrpBox_Suspended.TabStop = False
        Me.GrpBox_Suspended.Text = "SUSPENDED"
        '
        'LstSuspended
        '
        Me.LstSuspended.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4})
        Me.LstSuspended.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LstSuspended.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LstSuspended.ForeColor = System.Drawing.Color.Black
        Me.LstSuspended.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LstSuspended.Location = New System.Drawing.Point(3, 16)
        Me.LstSuspended.MultiSelect = False
        Me.LstSuspended.Name = "LstSuspended"
        Me.LstSuspended.Size = New System.Drawing.Size(327, 484)
        Me.LstSuspended.TabIndex = 10
        Me.LstSuspended.UseCompatibleStateImageBehavior = False
        Me.LstSuspended.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = ""
        Me.ColumnHeader4.Width = 280
        '
        'Bttn_Checkin
        '
        Me.Bttn_Checkin.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Bttn_Checkin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bttn_Checkin.Location = New System.Drawing.Point(0, 459)
        Me.Bttn_Checkin.Name = "Bttn_Checkin"
        Me.Bttn_Checkin.Size = New System.Drawing.Size(331, 44)
        Me.Bttn_Checkin.TabIndex = 4
        Me.Bttn_Checkin.Text = "LOGIN"
        Me.Bttn_Checkin.UseVisualStyleBackColor = True
        Me.Bttn_Checkin.Visible = False
        '
        'btnAddPeople
        '
        Me.btnAddPeople.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnAddPeople.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddPeople.Location = New System.Drawing.Point(0, 409)
        Me.btnAddPeople.Name = "btnAddPeople"
        Me.btnAddPeople.Size = New System.Drawing.Size(331, 44)
        Me.btnAddPeople.TabIndex = 5
        Me.btnAddPeople.Text = "ADD/EDIT/DELETE SP"
        Me.btnAddPeople.UseVisualStyleBackColor = True
        '
        'lnlCust
        '
        Me.lnlCust.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lnlCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnlCust.Location = New System.Drawing.Point(0, 433)
        Me.lnlCust.Name = "lnlCust"
        Me.lnlCust.Size = New System.Drawing.Size(331, 26)
        Me.lnlCust.TabIndex = 8
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1350, 509)
        Me.TableLayoutPanel1.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GrpBox_Suspended)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(1014, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(333, 503)
        Me.Panel4.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.GrpBox_DC_NOT_Updated)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(677, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(331, 503)
        Me.Panel3.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GrpBox_DC_14_Days)
        Me.Panel2.Controls.Add(Me.lnlCust)
        Me.Panel2.Controls.Add(Me.Bttn_Checkin)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(340, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(331, 503)
        Me.Panel2.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GrpBox_Available)
        Me.Panel1.Controls.Add(Me.btnAddPeople)
        Me.Panel1.Controls.Add(Me.btnBack)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 503)
        Me.Panel1.TabIndex = 0
        '
        'btnBack
        '
        Me.btnBack.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(0, 453)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(331, 50)
        Me.btnBack.TabIndex = 8
        Me.btnBack.Tag = "GO BACK"
        Me.btnBack.Text = "GO BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'frmWorkerLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 509)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmWorkerLookUp"
        Me.Text = "SP LOOK UP"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpBox_Available.ResumeLayout(False)
        Me.GrpBox_DC_14_Days.ResumeLayout(False)
        Me.GrpBox_DC_NOT_Updated.ResumeLayout(False)
        Me.GrpBox_Suspended.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBox_Available As System.Windows.Forms.GroupBox
    Friend WithEvents lstAvailable As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GrpBox_DC_14_Days As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBox_DC_NOT_Updated As System.Windows.Forms.GroupBox
    Friend WithEvents GrpBox_Suspended As System.Windows.Forms.GroupBox
    Friend WithEvents LstDC_14_Days As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LstNotUpdated As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LstSuspended As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Bttn_Checkin As System.Windows.Forms.Button
    Friend WithEvents btnAddPeople As System.Windows.Forms.Button
    Friend WithEvents lnlCust As System.Windows.Forms.LinkLabel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnBack As System.Windows.Forms.Button

End Class
