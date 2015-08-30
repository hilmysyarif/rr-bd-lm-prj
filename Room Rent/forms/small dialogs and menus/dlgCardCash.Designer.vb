<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dlgCardCash
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotak = New Room_Rent.NumericTextBox()
        Me.txtCard = New Room_Rent.NumericTextBox()
        Me.txtCash = New Room_Rent.NumericTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSurchrage = New Room_Rent.NumericTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSC = New Room_Rent.NumericTextBox()
        Me.txtTIP = New Room_Rent.NumericTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblPayable = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(62, 285)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(6)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(231, 49)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(6, 6)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(6)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(103, 37)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(121, 6)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(6)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(104, 37)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "GO BACK"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(39, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 24)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CASH"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(39, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 24)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CARD"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(-13, 228)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(446, 1)
        Me.Label3.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 235)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 24)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "TOTAL"
        '
        'txtTotak
        '
        Me.txtTotak.AllowSpace = False
        Me.txtTotak.DecimalSeparator = False
        Me.txtTotak.GroupSeperator = False
        Me.txtTotak.Location = New System.Drawing.Point(170, 232)
        Me.txtTotak.Name = "txtTotak"
        Me.txtTotak.Negative = False
        Me.txtTotak.ReadOnly = True
        Me.txtTotak.Size = New System.Drawing.Size(100, 29)
        Me.txtTotak.Space = False
        Me.txtTotak.TabIndex = 6
        Me.txtTotak.TabStop = False
        '
        'txtCard
        '
        Me.txtCard.AllowSpace = False
        Me.txtCard.DecimalSeparator = True
        Me.txtCard.GroupSeperator = False
        Me.txtCard.Location = New System.Drawing.Point(170, 87)
        Me.txtCard.Name = "txtCard"
        Me.txtCard.Negative = False
        Me.txtCard.Size = New System.Drawing.Size(100, 29)
        Me.txtCard.Space = False
        Me.txtCard.TabIndex = 1
        Me.txtCard.Text = "0.00"
        '
        'txtCash
        '
        Me.txtCash.AllowSpace = False
        Me.txtCash.DecimalSeparator = True
        Me.txtCash.GroupSeperator = False
        Me.txtCash.Location = New System.Drawing.Point(170, 49)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.Negative = False
        Me.txtCash.Size = New System.Drawing.Size(100, 29)
        Me.txtCash.Space = False
        Me.txtCash.TabIndex = 0
        Me.txtCash.Text = "0.00"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 24)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "SURCHARGE"
        '
        'txtSurchrage
        '
        Me.txtSurchrage.AllowSpace = False
        Me.txtSurchrage.DecimalSeparator = True
        Me.txtSurchrage.GroupSeperator = False
        Me.txtSurchrage.Location = New System.Drawing.Point(170, 122)
        Me.txtSurchrage.Name = "txtSurchrage"
        Me.txtSurchrage.Negative = False
        Me.txtSurchrage.ReadOnly = True
        Me.txtSurchrage.Size = New System.Drawing.Size(64, 29)
        Me.txtSurchrage.Space = False
        Me.txtSurchrage.TabIndex = 2
        Me.txtSurchrage.Text = "0.00"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(256, 122)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 29)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "E"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(231, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 24)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "%"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(39, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 24)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "SURCHARGE"
        '
        'txtSC
        '
        Me.txtSC.AllowSpace = False
        Me.txtSC.DecimalSeparator = True
        Me.txtSC.GroupSeperator = False
        Me.txtSC.Location = New System.Drawing.Point(170, 157)
        Me.txtSC.Name = "txtSC"
        Me.txtSC.Negative = False
        Me.txtSC.ReadOnly = True
        Me.txtSC.Size = New System.Drawing.Size(100, 29)
        Me.txtSC.Space = False
        Me.txtSC.TabIndex = 4
        Me.txtSC.TabStop = False
        Me.txtSC.Text = "0.00"
        '
        'txtTIP
        '
        Me.txtTIP.AllowSpace = False
        Me.txtTIP.DecimalSeparator = True
        Me.txtTIP.GroupSeperator = False
        Me.txtTIP.Location = New System.Drawing.Point(170, 192)
        Me.txtTIP.Name = "txtTIP"
        Me.txtTIP.Negative = False
        Me.txtTIP.Size = New System.Drawing.Size(100, 29)
        Me.txtTIP.Space = False
        Me.txtTIP.TabIndex = 5
        Me.txtTIP.Text = "0.00"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(39, 195)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 24)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "TIP"
        '
        'lblPayable
        '
        Me.lblPayable.AutoSize = True
        Me.lblPayable.Location = New System.Drawing.Point(39, 9)
        Me.lblPayable.Name = "lblPayable"
        Me.lblPayable.Size = New System.Drawing.Size(198, 24)
        Me.lblPayable.TabIndex = 8
        Me.lblPayable.Text = "Payable Amount : 0.00"
        '
        'dlgCardCash
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(302, 338)
        Me.Controls.Add(Me.lblPayable)
        Me.Controls.Add(Me.txtTIP)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTotak)
        Me.Controls.Add(Me.txtSurchrage)
        Me.Controls.Add(Me.txtSC)
        Me.Controls.Add(Me.txtCard)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCash)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Label6)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgCardCash"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Enter Cash Card Amount"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCash As Room_Rent.NumericTextBox
    Friend WithEvents txtCard As Room_Rent.NumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotak As Room_Rent.NumericTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSurchrage As Room_Rent.NumericTextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSC As Room_Rent.NumericTextBox
    Friend WithEvents txtTIP As Room_Rent.NumericTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblPayable As System.Windows.Forms.Label

End Class
