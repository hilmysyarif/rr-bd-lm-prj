<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWorkerLogin
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("fvxcv cbbcvbcvb")
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("cvbcvbcvbcvb")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("cvbcvxcvxcbcvb")
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtSPName = New System.Windows.Forms.TextBox()
        Me.btnNewSp = New System.Windows.Forms.Button()
        Me.lstActiveProvider = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.lblDCDate = New System.Windows.Forms.Label()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.btnAddDC = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtSPName)
        Me.GroupBox3.Controls.Add(Me.btnNewSp)
        Me.GroupBox3.Controls.Add(Me.lstActiveProvider)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 0)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox3.Size = New System.Drawing.Size(395, 395)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SPs"
        '
        'txtSPName
        '
        Me.txtSPName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSPName.Location = New System.Drawing.Point(9, 27)
        Me.txtSPName.Name = "txtSPName"
        Me.txtSPName.Size = New System.Drawing.Size(375, 29)
        Me.txtSPName.TabIndex = 11
        '
        'btnNewSp
        '
        Me.btnNewSp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewSp.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewSp.Location = New System.Drawing.Point(9, 335)
        Me.btnNewSp.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNewSp.Name = "btnNewSp"
        Me.btnNewSp.Size = New System.Drawing.Size(375, 57)
        Me.btnNewSp.TabIndex = 10
        Me.btnNewSp.Text = "New SP"
        Me.btnNewSp.UseVisualStyleBackColor = True
        '
        'lstActiveProvider
        '
        Me.lstActiveProvider.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstActiveProvider.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3})
        Me.lstActiveProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstActiveProvider.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstActiveProvider.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
        Me.lstActiveProvider.Location = New System.Drawing.Point(9, 58)
        Me.lstActiveProvider.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lstActiveProvider.MultiSelect = False
        Me.lstActiveProvider.Name = "lstActiveProvider"
        Me.lstActiveProvider.Size = New System.Drawing.Size(375, 274)
        Me.lstActiveProvider.TabIndex = 9
        Me.lstActiveProvider.UseCompatibleStateImageBehavior = False
        Me.lstActiveProvider.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 280
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Location = New System.Drawing.Point(203, 510)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(199, 57)
        Me.btnLogin.TabIndex = 2
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'lblDCDate
        '
        Me.lblDCDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDCDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDCDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblDCDate.Location = New System.Drawing.Point(7, 397)
        Me.lblDCDate.Name = "lblDCDate"
        Me.lblDCDate.Size = New System.Drawing.Size(395, 108)
        Me.lblDCDate.TabIndex = 3
        Me.lblDCDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(408, 12)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(655, 555)
        Me.WebBrowser1.TabIndex = 4
        '
        'btnAddDC
        '
        Me.btnAddDC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddDC.Location = New System.Drawing.Point(6, 510)
        Me.btnAddDC.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnAddDC.Name = "btnAddDC"
        Me.btnAddDC.Size = New System.Drawing.Size(189, 57)
        Me.btnAddDC.TabIndex = 5
        Me.btnAddDC.Text = "GO BACK"
        Me.btnAddDC.UseVisualStyleBackColor = True
        '
        'frmWorkerLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 581)
        Me.Controls.Add(Me.btnAddDC)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.lblDCDate)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.GroupBox3)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmWorkerLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lstActiveProvider As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents lblDCDate As System.Windows.Forms.Label
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents btnAddDC As System.Windows.Forms.Button
    Friend WithEvents btnNewSp As System.Windows.Forms.Button
    Friend WithEvents txtSPName As System.Windows.Forms.TextBox
End Class
