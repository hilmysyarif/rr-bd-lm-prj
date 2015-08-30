<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectSMSGateway
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rdbWay2sms = New System.Windows.Forms.RadioButton()
        Me.rdbModem = New System.Windows.Forms.RadioButton()
        Me.rdbApi = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(311, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Gateway"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rdbWay2sms
        '
        Me.rdbWay2sms.AutoSize = True
        Me.rdbWay2sms.Checked = True
        Me.rdbWay2sms.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbWay2sms.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rdbWay2sms.Location = New System.Drawing.Point(32, 31)
        Me.rdbWay2sms.Name = "rdbWay2sms"
        Me.rdbWay2sms.Size = New System.Drawing.Size(102, 17)
        Me.rdbWay2sms.TabIndex = 1
        Me.rdbWay2sms.TabStop = True
        Me.rdbWay2sms.Text = "way2sms.com"
        Me.rdbWay2sms.UseVisualStyleBackColor = True
        Me.rdbWay2sms.Visible = False
        '
        'rdbModem
        '
        Me.rdbModem.AutoSize = True
        Me.rdbModem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbModem.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rdbModem.Location = New System.Drawing.Point(32, 54)
        Me.rdbModem.Name = "rdbModem"
        Me.rdbModem.Size = New System.Drawing.Size(182, 17)
        Me.rdbModem.TabIndex = 1
        Me.rdbModem.Text = "Modem/Phone/USB Dongle"
        Me.rdbModem.UseVisualStyleBackColor = True
        '
        'rdbApi
        '
        Me.rdbApi.AutoSize = True
        Me.rdbApi.Enabled = False
        Me.rdbApi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbApi.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.rdbApi.Location = New System.Drawing.Point(32, 77)
        Me.rdbApi.Name = "rdbApi"
        Me.rdbApi.Size = New System.Drawing.Size(73, 17)
        Me.rdbApi.TabIndex = 1
        Me.rdbApi.Text = "SMS Api"
        Me.rdbApi.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(224, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "&Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(224, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "&OK"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(88, 106)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(136, 21)
        Me.ComboBox1.TabIndex = 4
        Me.ComboBox1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Location = New System.Drawing.Point(12, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Select Port"
        Me.Label2.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(224, 105)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "Test SMS"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'SelectSMSGateway
        '
        Me.AcceptButton = Me.Button2
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(311, 139)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.rdbApi)
        Me.Controls.Add(Me.rdbModem)
        Me.Controls.Add(Me.rdbWay2sms)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SelectSMSGateway"
        Me.Opacity = 0.75R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SelectSMSGateway"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdbWay2sms As System.Windows.Forms.RadioButton
    Friend WithEvents rdbModem As System.Windows.Forms.RadioButton
    Friend WithEvents rdbApi As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
