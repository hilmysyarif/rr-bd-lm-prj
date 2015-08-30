<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVoucherLink
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnBCK = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.MyNumericKeyBoard1 = New Room_Rent.MyNumericKeyBoard()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericTextBox1 = New Room_Rent.NumericTextBox()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.txtRefID = New System.Windows.Forms.TextBox()
        Me.txtVoucherNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(464, 40)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnNew)
        Me.Panel2.Controls.Add(Me.btnBCK)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 465)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(464, 50)
        Me.Panel2.TabIndex = 0
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(377, 8)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 37)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "OK"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnBCK
        '
        Me.btnBCK.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBCK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBCK.Location = New System.Drawing.Point(7, 8)
        Me.btnBCK.Name = "btnBCK"
        Me.btnBCK.Size = New System.Drawing.Size(104, 37)
        Me.btnBCK.TabIndex = 1
        Me.btnBCK.Text = "GO BACK"
        Me.btnBCK.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.MyNumericKeyBoard1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.NumericTextBox1)
        Me.Panel3.Controls.Add(Me.btnFind)
        Me.Panel3.Controls.Add(Me.txtRefID)
        Me.Panel3.Controls.Add(Me.txtVoucherNo)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.lblMessage)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 40)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(464, 425)
        Me.Panel3.TabIndex = 1
        '
        'MyNumericKeyBoard1
        '
        Me.MyNumericKeyBoard1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyNumericKeyBoard1.Location = New System.Drawing.Point(30, 182)
        Me.MyNumericKeyBoard1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MyNumericKeyBoard1.Name = "MyNumericKeyBoard1"
        Me.MyNumericKeyBoard1.Size = New System.Drawing.Size(405, 245)
        Me.MyNumericKeyBoard1.TabIndex = 6
        Me.MyNumericKeyBoard1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(36, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Amount :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NumericTextBox1
        '
        Me.NumericTextBox1.AllowSpace = False
        Me.NumericTextBox1.DecimalSeparator = False
        Me.NumericTextBox1.GroupSeperator = False
        Me.NumericTextBox1.Location = New System.Drawing.Point(213, 137)
        Me.NumericTextBox1.Name = "NumericTextBox1"
        Me.NumericTextBox1.Negative = False
        Me.NumericTextBox1.Size = New System.Drawing.Size(139, 26)
        Me.NumericTextBox1.Space = False
        Me.NumericTextBox1.TabIndex = 3
        Me.NumericTextBox1.Text = "0.00"
        '
        'btnFind
        '
        Me.btnFind.Location = New System.Drawing.Point(377, 15)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(75, 37)
        Me.btnFind.TabIndex = 2
        Me.btnFind.Text = "FIND"
        Me.btnFind.UseVisualStyleBackColor = True
        '
        'txtRefID
        '
        Me.txtRefID.Location = New System.Drawing.Point(213, 37)
        Me.txtRefID.Name = "txtRefID"
        Me.txtRefID.Size = New System.Drawing.Size(139, 26)
        Me.txtRefID.TabIndex = 1
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.Location = New System.Drawing.Point(213, 8)
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(139, 26)
        Me.txtVoucherNo.TabIndex = 0
        Me.txtVoucherNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Reference ID :"
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(40, 66)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(389, 68)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Available Balance : $ 0.00"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "GIFT VOUCHER NO."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(80, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "OR"
        '
        'frmVoucherLink
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnBCK
        Me.ClientSize = New System.Drawing.Size(464, 515)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmVoucherLink"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Voucher"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtRefID As System.Windows.Forms.TextBox
    Friend WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnBCK As System.Windows.Forms.Button
    Friend WithEvents btnFind As System.Windows.Forms.Button
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumericTextBox1 As Room_Rent.NumericTextBox
    Friend WithEvents MyNumericKeyBoard1 As Room_Rent.MyNumericKeyBoard
End Class
