<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectSP
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
        Me.grpServiceProvider = New System.Windows.Forms.GroupBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblServiceProvider = New System.Windows.Forms.LinkLabel()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNewServiceProviderName = New System.Windows.Forms.TextBox()
        Me.lstServiceProvider = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnDoneServiceProvider = New System.Windows.Forms.Button()
        Me.btnDeleteServiceProvider = New System.Windows.Forms.Button()
        Me.btnAddServiceProvider = New System.Windows.Forms.Button()
        Me.grpServiceProvider.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpServiceProvider
        '
        Me.grpServiceProvider.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpServiceProvider.Controls.Add(Me.btnBack)
        Me.grpServiceProvider.Controls.Add(Me.lblServiceProvider)
        Me.grpServiceProvider.Controls.Add(Me.btnNext)
        Me.grpServiceProvider.Controls.Add(Me.Label1)
        Me.grpServiceProvider.Controls.Add(Me.txtNewServiceProviderName)
        Me.grpServiceProvider.Controls.Add(Me.lstServiceProvider)
        Me.grpServiceProvider.Controls.Add(Me.btnDoneServiceProvider)
        Me.grpServiceProvider.Controls.Add(Me.btnDeleteServiceProvider)
        Me.grpServiceProvider.Controls.Add(Me.btnAddServiceProvider)
        Me.grpServiceProvider.Location = New System.Drawing.Point(12, 16)
        Me.grpServiceProvider.Name = "grpServiceProvider"
        Me.grpServiceProvider.Size = New System.Drawing.Size(604, 652)
        Me.grpServiceProvider.TabIndex = 3
        Me.grpServiceProvider.TabStop = False
        Me.grpServiceProvider.Text = "Service Providers"
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(0, 593)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(113, 52)
        Me.btnBack.TabIndex = 11
        Me.btnBack.Text = "GO BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblServiceProvider
        '
        Me.lblServiceProvider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblServiceProvider.AutoSize = True
        Me.lblServiceProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServiceProvider.Location = New System.Drawing.Point(300, 570)
        Me.lblServiceProvider.Name = "lblServiceProvider"
        Me.lblServiceProvider.Size = New System.Drawing.Size(0, 20)
        Me.lblServiceProvider.TabIndex = 10
        Me.lblServiceProvider.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(461, 593)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(124, 52)
        Me.btnNext.TabIndex = 9
        Me.btnNext.Text = "OK"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Gray
        Me.Label1.Location = New System.Drawing.Point(293, 571)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1, 74)
        Me.Label1.TabIndex = 8
        Me.Label1.Visible = False
        '
        'txtNewServiceProviderName
        '
        Me.txtNewServiceProviderName.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNewServiceProviderName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewServiceProviderName.Location = New System.Drawing.Point(3, 571)
        Me.txtNewServiceProviderName.Name = "txtNewServiceProviderName"
        Me.txtNewServiceProviderName.Size = New System.Drawing.Size(284, 20)
        Me.txtNewServiceProviderName.TabIndex = 7
        Me.txtNewServiceProviderName.Visible = False
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
        Me.lstServiceProvider.Location = New System.Drawing.Point(3, 16)
        Me.lstServiceProvider.MultiSelect = False
        Me.lstServiceProvider.Name = "lstServiceProvider"
        Me.lstServiceProvider.Size = New System.Drawing.Size(595, 548)
        Me.lstServiceProvider.TabIndex = 6
        Me.lstServiceProvider.UseCompatibleStateImageBehavior = False
        Me.lstServiceProvider.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 280
        '
        'btnDoneServiceProvider
        '
        Me.btnDoneServiceProvider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDoneServiceProvider.Location = New System.Drawing.Point(195, 594)
        Me.btnDoneServiceProvider.Name = "btnDoneServiceProvider"
        Me.btnDoneServiceProvider.Size = New System.Drawing.Size(92, 52)
        Me.btnDoneServiceProvider.TabIndex = 5
        Me.btnDoneServiceProvider.Text = "DONE"
        Me.btnDoneServiceProvider.UseVisualStyleBackColor = True
        Me.btnDoneServiceProvider.Visible = False
        '
        'btnDeleteServiceProvider
        '
        Me.btnDeleteServiceProvider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteServiceProvider.Location = New System.Drawing.Point(103, 594)
        Me.btnDeleteServiceProvider.Name = "btnDeleteServiceProvider"
        Me.btnDeleteServiceProvider.Size = New System.Drawing.Size(92, 52)
        Me.btnDeleteServiceProvider.TabIndex = 4
        Me.btnDeleteServiceProvider.Text = "DELETE"
        Me.btnDeleteServiceProvider.UseVisualStyleBackColor = True
        Me.btnDeleteServiceProvider.Visible = False
        '
        'btnAddServiceProvider
        '
        Me.btnAddServiceProvider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddServiceProvider.Location = New System.Drawing.Point(10, 594)
        Me.btnAddServiceProvider.Name = "btnAddServiceProvider"
        Me.btnAddServiceProvider.Size = New System.Drawing.Size(92, 52)
        Me.btnAddServiceProvider.TabIndex = 3
        Me.btnAddServiceProvider.Text = "ADD"
        Me.btnAddServiceProvider.UseVisualStyleBackColor = True
        Me.btnAddServiceProvider.Visible = False
        '
        'frmSelectSP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 681)
        Me.Controls.Add(Me.grpServiceProvider)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectSP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Service Providers"
        Me.grpServiceProvider.ResumeLayout(False)
        Me.grpServiceProvider.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpServiceProvider As System.Windows.Forms.GroupBox
    Friend WithEvents lblServiceProvider As System.Windows.Forms.LinkLabel
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNewServiceProviderName As System.Windows.Forms.TextBox
    Friend WithEvents lstServiceProvider As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnDoneServiceProvider As System.Windows.Forms.Button
    Friend WithEvents btnDeleteServiceProvider As System.Windows.Forms.Button
    Friend WithEvents btnAddServiceProvider As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
