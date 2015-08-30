<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFinal
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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.grpDoorCharges = New System.Windows.Forms.GroupBox()
        Me.btnNoCharge = New System.Windows.Forms.Button()
        Me.btnLounge = New System.Windows.Forms.Button()
        Me.btnPrivate = New System.Windows.Forms.Button()
        Me.grpPayment = New System.Windows.Forms.GroupBox()
        Me.pnlPaymentMode = New System.Windows.Forms.Panel()
        Me.btnCard = New System.Windows.Forms.Button()
        Me.btnCash = New System.Windows.Forms.Button()
        Me.lblTotalPrice = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpDoorCharges.SuspendLayout()
        Me.grpPayment.SuspendLayout()
        Me.pnlPaymentMode.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBack.Location = New System.Drawing.Point(96, 446)
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
        Me.btnNext.Location = New System.Drawing.Point(429, 446)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(162, 56)
        Me.btnNext.TabIndex = 9
        Me.btnNext.Text = "Finish"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'grpDoorCharges
        '
        Me.grpDoorCharges.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpDoorCharges.Controls.Add(Me.btnNoCharge)
        Me.grpDoorCharges.Controls.Add(Me.btnLounge)
        Me.grpDoorCharges.Controls.Add(Me.btnPrivate)
        Me.grpDoorCharges.Location = New System.Drawing.Point(93, 34)
        Me.grpDoorCharges.Name = "grpDoorCharges"
        Me.grpDoorCharges.Size = New System.Drawing.Size(227, 276)
        Me.grpDoorCharges.TabIndex = 11
        Me.grpDoorCharges.TabStop = False
        Me.grpDoorCharges.Text = "DOOR CHARGES"
        '
        'btnNoCharge
        '
        Me.btnNoCharge.BackColor = System.Drawing.Color.Red
        Me.btnNoCharge.Location = New System.Drawing.Point(50, 188)
        Me.btnNoCharge.Name = "btnNoCharge"
        Me.btnNoCharge.Size = New System.Drawing.Size(127, 62)
        Me.btnNoCharge.TabIndex = 1
        Me.btnNoCharge.Tag = "0.00"
        Me.btnNoCharge.Text = "NO CHARGE"
        Me.btnNoCharge.UseVisualStyleBackColor = False
        '
        'btnLounge
        '
        Me.btnLounge.Location = New System.Drawing.Point(50, 114)
        Me.btnLounge.Name = "btnLounge"
        Me.btnLounge.Size = New System.Drawing.Size(127, 62)
        Me.btnLounge.TabIndex = 1
        Me.btnLounge.Tag = "20.00"
        Me.btnLounge.Text = "LOUNGE"
        Me.btnLounge.UseVisualStyleBackColor = True
        '
        'btnPrivate
        '
        Me.btnPrivate.Location = New System.Drawing.Point(50, 40)
        Me.btnPrivate.Name = "btnPrivate"
        Me.btnPrivate.Size = New System.Drawing.Size(127, 62)
        Me.btnPrivate.TabIndex = 0
        Me.btnPrivate.Tag = "10.00"
        Me.btnPrivate.Text = "PRIVATE"
        Me.btnPrivate.UseVisualStyleBackColor = True
        '
        'grpPayment
        '
        Me.grpPayment.Controls.Add(Me.pnlPaymentMode)
        Me.grpPayment.Location = New System.Drawing.Point(367, 34)
        Me.grpPayment.Name = "grpPayment"
        Me.grpPayment.Size = New System.Drawing.Size(227, 206)
        Me.grpPayment.TabIndex = 12
        Me.grpPayment.TabStop = False
        Me.grpPayment.Text = "PAYMENT"
        '
        'pnlPaymentMode
        '
        Me.pnlPaymentMode.Controls.Add(Me.btnCard)
        Me.pnlPaymentMode.Controls.Add(Me.btnCash)
        Me.pnlPaymentMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPaymentMode.Location = New System.Drawing.Point(3, 22)
        Me.pnlPaymentMode.Name = "pnlPaymentMode"
        Me.pnlPaymentMode.Size = New System.Drawing.Size(221, 181)
        Me.pnlPaymentMode.TabIndex = 5
        '
        'btnCard
        '
        Me.btnCard.Location = New System.Drawing.Point(47, 92)
        Me.btnCard.Name = "btnCard"
        Me.btnCard.Size = New System.Drawing.Size(127, 62)
        Me.btnCard.TabIndex = 1
        Me.btnCard.Text = "CARD"
        Me.btnCard.UseVisualStyleBackColor = True
        '
        'btnCash
        '
        Me.btnCash.BackColor = System.Drawing.Color.Red
        Me.btnCash.Location = New System.Drawing.Point(47, 18)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(127, 62)
        Me.btnCash.TabIndex = 0
        Me.btnCash.Text = "CASH"
        Me.btnCash.UseVisualStyleBackColor = False
        '
        'lblTotalPrice
        '
        Me.lblTotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPrice.ForeColor = System.Drawing.Color.Red
        Me.lblTotalPrice.Location = New System.Drawing.Point(110, 397)
        Me.lblTotalPrice.Name = "lblTotalPrice"
        Me.lblTotalPrice.Size = New System.Drawing.Size(422, 31)
        Me.lblTotalPrice.TabIndex = 4
        Me.lblTotalPrice.Text = "$0.00"
        Me.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblTotalPrice.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(279, 363)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TOTAL:"
        Me.Label1.Visible = False
        '
        'frmFinal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(642, 519)
        Me.Controls.Add(Me.grpPayment)
        Me.Controls.Add(Me.grpDoorCharges)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lblTotalPrice)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFinal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Final"
        Me.grpDoorCharges.ResumeLayout(False)
        Me.grpPayment.ResumeLayout(False)
        Me.pnlPaymentMode.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents grpDoorCharges As System.Windows.Forms.GroupBox
    Friend WithEvents btnLounge As System.Windows.Forms.Button
    Friend WithEvents btnPrivate As System.Windows.Forms.Button
    Friend WithEvents grpPayment As System.Windows.Forms.GroupBox
    Friend WithEvents pnlPaymentMode As System.Windows.Forms.Panel
    Friend WithEvents btnCard As System.Windows.Forms.Button
    Friend WithEvents btnCash As System.Windows.Forms.Button
    Friend WithEvents lblTotalPrice As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNoCharge As System.Windows.Forms.Button
End Class
