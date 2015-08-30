<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServiceTime
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
        Me.grpService = New System.Windows.Forms.GroupBox()
        Me.btnCustomMin = New System.Windows.Forms.Button()
        Me.btn120Min = New System.Windows.Forms.Button()
        Me.btn90Min = New System.Windows.Forms.Button()
        Me.btn60Min = New System.Windows.Forms.Button()
        Me.btn45Min = New System.Windows.Forms.Button()
        Me.btn30Min = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.grpService.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpService
        '
        Me.grpService.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.grpService.Controls.Add(Me.btnCustomMin)
        Me.grpService.Controls.Add(Me.btn120Min)
        Me.grpService.Controls.Add(Me.btn90Min)
        Me.grpService.Controls.Add(Me.btn60Min)
        Me.grpService.Controls.Add(Me.btn45Min)
        Me.grpService.Controls.Add(Me.btn30Min)
        Me.grpService.Location = New System.Drawing.Point(101, 17)
        Me.grpService.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpService.Name = "grpService"
        Me.grpService.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grpService.Size = New System.Drawing.Size(440, 345)
        Me.grpService.TabIndex = 5
        Me.grpService.TabStop = False
        '
        'btnCustomMin
        '
        Me.btnCustomMin.Enabled = False
        Me.btnCustomMin.Location = New System.Drawing.Point(224, 239)
        Me.btnCustomMin.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCustomMin.Name = "btnCustomMin"
        Me.btnCustomMin.Size = New System.Drawing.Size(193, 95)
        Me.btnCustomMin.TabIndex = 5
        Me.btnCustomMin.Tag = ""
        Me.btnCustomMin.Text = "CUSTOM"
        Me.btnCustomMin.UseVisualStyleBackColor = True
        '
        'btn120Min
        '
        Me.btn120Min.Location = New System.Drawing.Point(224, 134)
        Me.btn120Min.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn120Min.Name = "btn120Min"
        Me.btn120Min.Size = New System.Drawing.Size(193, 95)
        Me.btn120Min.TabIndex = 4
        Me.btn120Min.Tag = "120"
        Me.btn120Min.Text = "120 MINS"
        Me.btn120Min.UseVisualStyleBackColor = True
        '
        'btn90Min
        '
        Me.btn90Min.Location = New System.Drawing.Point(224, 29)
        Me.btn90Min.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn90Min.Name = "btn90Min"
        Me.btn90Min.Size = New System.Drawing.Size(193, 95)
        Me.btn90Min.TabIndex = 3
        Me.btn90Min.Tag = "90"
        Me.btn90Min.Text = "90 MINS"
        Me.btn90Min.UseVisualStyleBackColor = True
        '
        'btn60Min
        '
        Me.btn60Min.Location = New System.Drawing.Point(23, 241)
        Me.btn60Min.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn60Min.Name = "btn60Min"
        Me.btn60Min.Size = New System.Drawing.Size(193, 95)
        Me.btn60Min.TabIndex = 2
        Me.btn60Min.Tag = "60"
        Me.btn60Min.Text = "60 MINS"
        Me.btn60Min.UseVisualStyleBackColor = True
        '
        'btn45Min
        '
        Me.btn45Min.Location = New System.Drawing.Point(23, 136)
        Me.btn45Min.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn45Min.Name = "btn45Min"
        Me.btn45Min.Size = New System.Drawing.Size(193, 95)
        Me.btn45Min.TabIndex = 1
        Me.btn45Min.Tag = "45"
        Me.btn45Min.Text = "45 MINS"
        Me.btn45Min.UseVisualStyleBackColor = True
        '
        'btn30Min
        '
        Me.btn30Min.BackColor = System.Drawing.Color.Red
        Me.btn30Min.Location = New System.Drawing.Point(23, 31)
        Me.btn30Min.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btn30Min.Name = "btn30Min"
        Me.btn30Min.Size = New System.Drawing.Size(193, 95)
        Me.btn30Min.TabIndex = 0
        Me.btn30Min.Tag = "30"
        Me.btn30Min.Text = "30 MINS"
        Me.btn30Min.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBack.Location = New System.Drawing.Point(93, 375)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(162, 56)
        Me.btnBack.TabIndex = 10
        Me.btnBack.Text = "<<Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNext.Location = New System.Drawing.Point(391, 375)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(162, 56)
        Me.btnNext.TabIndex = 9
        Me.btnNext.Text = "Next>>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'frmServiceTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 477)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.grpService)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServiceTime"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Service"
        Me.grpService.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpService As System.Windows.Forms.GroupBox
    Friend WithEvents btnCustomMin As System.Windows.Forms.Button
    Friend WithEvents btn120Min As System.Windows.Forms.Button
    Friend WithEvents btn90Min As System.Windows.Forms.Button
    Friend WithEvents btn60Min As System.Windows.Forms.Button
    Friend WithEvents btn45Min As System.Windows.Forms.Button
    Friend WithEvents btn30Min As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
End Class
