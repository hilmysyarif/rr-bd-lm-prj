<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectClientMember
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblServiceProvider = New System.Windows.Forms.LinkLabel()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lstServiceProvider = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAddServiceProvider = New System.Windows.Forms.Button()
        Me.grpServiceProvider.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpServiceProvider
        '
        Me.grpServiceProvider.Controls.Add(Me.Button2)
        Me.grpServiceProvider.Controls.Add(Me.txtPhone)
        Me.grpServiceProvider.Controls.Add(Me.Label2)
        Me.grpServiceProvider.Controls.Add(Me.TextBox1)
        Me.grpServiceProvider.Controls.Add(Me.Label3)
        Me.grpServiceProvider.Controls.Add(Me.txtName)
        Me.grpServiceProvider.Controls.Add(Me.Label1)
        Me.grpServiceProvider.Controls.Add(Me.btnBack)
        Me.grpServiceProvider.Controls.Add(Me.lblServiceProvider)
        Me.grpServiceProvider.Controls.Add(Me.btnNext)
        Me.grpServiceProvider.Location = New System.Drawing.Point(12, 16)
        Me.grpServiceProvider.Name = "grpServiceProvider"
        Me.grpServiceProvider.Size = New System.Drawing.Size(290, 228)
        Me.grpServiceProvider.TabIndex = 0
        Me.grpServiceProvider.TabStop = False
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(178, 37)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(92, 52)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Find"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtPhone
        '
        Me.txtPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPhone.Location = New System.Drawing.Point(75, 127)
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(195, 26)
        Me.txtPhone.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Phone"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(106, 10)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(164, 26)
        Me.TextBox1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 20)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Member ID"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(75, 95)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(195, 26)
        Me.txtName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Name"
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(32, 159)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(114, 52)
        Me.btnBack.TabIndex = 3
        Me.btnBack.Text = "GO BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblServiceProvider
        '
        Me.lblServiceProvider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblServiceProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServiceProvider.Location = New System.Drawing.Point(328, 96)
        Me.lblServiceProvider.Name = "lblServiceProvider"
        Me.lblServiceProvider.Size = New System.Drawing.Size(270, 32)
        Me.lblServiceProvider.TabIndex = 10
        Me.lblServiceProvider.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblServiceProvider.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(152, 159)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(118, 52)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "OK"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(359, 333)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(153, 52)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "REMOVE"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'lstServiceProvider
        '
        Me.lstServiceProvider.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lstServiceProvider.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstServiceProvider.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstServiceProvider.Location = New System.Drawing.Point(240, 298)
        Me.lstServiceProvider.MultiSelect = False
        Me.lstServiceProvider.Name = "lstServiceProvider"
        Me.lstServiceProvider.Size = New System.Drawing.Size(251, 29)
        Me.lstServiceProvider.TabIndex = 6
        Me.lstServiceProvider.UseCompatibleStateImageBehavior = False
        Me.lstServiceProvider.View = System.Windows.Forms.View.Details
        Me.lstServiceProvider.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 280
        '
        'btnAddServiceProvider
        '
        Me.btnAddServiceProvider.Location = New System.Drawing.Point(200, 333)
        Me.btnAddServiceProvider.Name = "btnAddServiceProvider"
        Me.btnAddServiceProvider.Size = New System.Drawing.Size(153, 52)
        Me.btnAddServiceProvider.TabIndex = 3
        Me.btnAddServiceProvider.Text = "ADD NEW"
        Me.btnAddServiceProvider.UseVisualStyleBackColor = True
        Me.btnAddServiceProvider.Visible = False
        '
        'frmSelectClientMember
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 256)
        Me.Controls.Add(Me.grpServiceProvider)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnAddServiceProvider)
        Me.Controls.Add(Me.lstServiceProvider)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectClientMember"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer"
        Me.grpServiceProvider.ResumeLayout(False)
        Me.grpServiceProvider.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpServiceProvider As System.Windows.Forms.GroupBox
    Friend WithEvents lblServiceProvider As System.Windows.Forms.LinkLabel
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents lstServiceProvider As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAddServiceProvider As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
