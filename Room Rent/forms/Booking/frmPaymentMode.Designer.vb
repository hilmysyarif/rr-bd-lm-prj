<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaymentMode
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
        Me.grpPaymentMode = New System.Windows.Forms.GroupBox()
        Me.btnCardCash = New System.Windows.Forms.Button()
        Me.btnCard = New System.Windows.Forms.Button()
        Me.btnCash = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpPaymentMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpPaymentMode
        '
        Me.grpPaymentMode.Controls.Add(Me.btnCardCash)
        Me.grpPaymentMode.Controls.Add(Me.btnCard)
        Me.grpPaymentMode.Controls.Add(Me.btnCash)
        Me.grpPaymentMode.Location = New System.Drawing.Point(34, 82)
        Me.grpPaymentMode.Name = "grpPaymentMode"
        Me.grpPaymentMode.Size = New System.Drawing.Size(321, 205)
        Me.grpPaymentMode.TabIndex = 13
        Me.grpPaymentMode.TabStop = False
        Me.grpPaymentMode.Text = "PAYMENT MODE"
        '
        'btnCardCash
        '
        Me.btnCardCash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCardCash.Location = New System.Drawing.Point(16, 138)
        Me.btnCardCash.Name = "btnCardCash"
        Me.btnCardCash.Size = New System.Drawing.Size(290, 50)
        Me.btnCardCash.TabIndex = 4
        Me.btnCardCash.Text = "CARD/CASH"
        Me.btnCardCash.UseVisualStyleBackColor = True
        '
        'btnCard
        '
        Me.btnCard.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCard.Location = New System.Drawing.Point(16, 82)
        Me.btnCard.Name = "btnCard"
        Me.btnCard.Size = New System.Drawing.Size(290, 50)
        Me.btnCard.TabIndex = 3
        Me.btnCard.Text = "CARD"
        Me.btnCard.UseVisualStyleBackColor = True
        '
        'btnCash
        '
        Me.btnCash.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCash.Location = New System.Drawing.Point(16, 26)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(290, 50)
        Me.btnCash.TabIndex = 2
        Me.btnCash.Text = "CASH"
        Me.btnCash.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBack.Location = New System.Drawing.Point(15, 298)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(162, 56)
        Me.btnBack.TabIndex = 15
        Me.btnBack.Text = "GO BACK"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNext.Location = New System.Drawing.Point(219, 298)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(162, 56)
        Me.btnNext.TabIndex = 14
        Me.btnNext.Text = "OK"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(31, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(324, 38)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Total : 120.00"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPaymentMode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 364)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.grpPaymentMode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaymentMode"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Mode"
        Me.grpPaymentMode.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpPaymentMode As System.Windows.Forms.GroupBox
    Friend WithEvents btnCardCash As System.Windows.Forms.Button
    Friend WithEvents btnCard As System.Windows.Forms.Button
    Friend WithEvents btnCash As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
