<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectSPClearFinished
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
        Me.grpServiceProvider = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.lstServiceProvider = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grpServiceProvider.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpServiceProvider
        '
        Me.grpServiceProvider.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpServiceProvider.Controls.Add(Me.Button1)
        Me.grpServiceProvider.Controls.Add(Me.btnNext)
        Me.grpServiceProvider.Controls.Add(Me.lstServiceProvider)
        Me.grpServiceProvider.Location = New System.Drawing.Point(12, 16)
        Me.grpServiceProvider.Name = "grpServiceProvider"
        Me.grpServiceProvider.Size = New System.Drawing.Size(604, 652)
        Me.grpServiceProvider.TabIndex = 3
        Me.grpServiceProvider.TabStop = False
        Me.grpServiceProvider.Text = "Service Providers"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 594)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 52)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "GO BACK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(437, 594)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(161, 52)
        Me.btnNext.TabIndex = 9
        Me.btnNext.Text = "OK"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'lstServiceProvider
        '
        Me.lstServiceProvider.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstServiceProvider.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstServiceProvider.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstServiceProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstServiceProvider.FullRowSelect = True
        Me.lstServiceProvider.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstServiceProvider.Location = New System.Drawing.Point(3, 16)
        Me.lstServiceProvider.Name = "lstServiceProvider"
        Me.lstServiceProvider.Size = New System.Drawing.Size(595, 572)
        Me.lstServiceProvider.TabIndex = 6
        Me.lstServiceProvider.UseCompatibleStateImageBehavior = False
        Me.lstServiceProvider.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 600
        '
        'frmSelectSPClearFinished
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 681)
        Me.Controls.Add(Me.grpServiceProvider)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectSPClearFinished"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Service Providers"
        Me.grpServiceProvider.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpServiceProvider As System.Windows.Forms.GroupBox
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lstServiceProvider As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
