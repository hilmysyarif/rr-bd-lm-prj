<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddMerchandise
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.txtProductCategory = New System.Windows.Forms.ComboBox()
        Me.txtBrand = New System.Windows.Forms.ComboBox()
        Me.txtUnit = New System.Windows.Forms.ComboBox()
        Me.txtExpireType = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgProducts = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtMinimumStock = New Room_Rent.NumericTextBox()
        Me.txtExpire = New Room_Rent.NumericTextBox()
        Me.txtTAX = New Room_Rent.NumericTextBox()
        Me.txtPrice = New Room_Rent.NumericTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Name :"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(81, 90)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Product Category:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(81, 124)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Brand :"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(81, 158)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Price :"
        '
        'txtProduct
        '
        Me.txtProduct.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtProduct.Location = New System.Drawing.Point(241, 25)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(278, 26)
        Me.txtProduct.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(81, 191)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Unit Symbol :"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(81, 224)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Tax :"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(81, 255)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Barcode :"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(81, 287)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Expire Duration:"
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(81, 321)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(234, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Minimum Stock Alert On/Below :"
        Me.Label9.Visible = False
        '
        'lblUnit
        '
        Me.lblUnit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(440, 322)
        Me.lblUnit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(0, 20)
        Me.lblUnit.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(95, 342)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(149, 9)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Put (-1) to Hide from Minimum Stock Alert"
        Me.Label11.Visible = False
        '
        'txtBarcode
        '
        Me.txtBarcode.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBarcode.Location = New System.Drawing.Point(241, 252)
        Me.txtBarcode.MaxLength = 15
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(192, 26)
        Me.txtBarcode.TabIndex = 7
        '
        'txtProductCategory
        '
        Me.txtProductCategory.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtProductCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtProductCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtProductCategory.FormattingEnabled = True
        Me.txtProductCategory.Location = New System.Drawing.Point(241, 87)
        Me.txtProductCategory.Name = "txtProductCategory"
        Me.txtProductCategory.Size = New System.Drawing.Size(278, 28)
        Me.txtProductCategory.TabIndex = 2
        '
        'txtBrand
        '
        Me.txtBrand.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtBrand.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtBrand.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.txtBrand.FormattingEnabled = True
        Me.txtBrand.Location = New System.Drawing.Point(241, 121)
        Me.txtBrand.Name = "txtBrand"
        Me.txtBrand.Size = New System.Drawing.Size(278, 28)
        Me.txtBrand.TabIndex = 3
        '
        'txtUnit
        '
        Me.txtUnit.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtUnit.FormattingEnabled = True
        Me.txtUnit.Location = New System.Drawing.Point(241, 188)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(70, 28)
        Me.txtUnit.TabIndex = 5
        '
        'txtExpireType
        '
        Me.txtExpireType.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtExpireType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtExpireType.FormattingEnabled = True
        Me.txtExpireType.Items.AddRange(New Object() {"NA", "Days", "Months", "Years"})
        Me.txtExpireType.Location = New System.Drawing.Point(347, 284)
        Me.txtExpireType.Name = "txtExpireType"
        Me.txtExpireType.Size = New System.Drawing.Size(86, 28)
        Me.txtExpireType.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(294, 224)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 20)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "%"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(221, 158)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 20)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "$"
        '
        'dgProducts
        '
        Me.dgProducts.AllowUserToAddRows = False
        Me.dgProducts.AllowUserToDeleteRows = False
        Me.dgProducts.AllowUserToResizeColumns = False
        Me.dgProducts.AllowUserToResizeRows = False
        Me.dgProducts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgProducts.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.dgProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgProducts.Location = New System.Drawing.Point(15, 378)
        Me.dgProducts.MultiSelect = False
        Me.dgProducts.Name = "dgProducts"
        Me.dgProducts.RowHeadersVisible = False
        Me.dgProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProducts.Size = New System.Drawing.Size(703, 427)
        Me.dgProducts.TabIndex = 11
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSave.Location = New System.Drawing.Point(610, 221)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 62)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(609, 294)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(88, 62)
        Me.btnDelete.TabIndex = 12
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'txtMinimumStock
        '
        Me.txtMinimumStock.AllowSpace = False
        Me.txtMinimumStock.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtMinimumStock.DecimalSeparator = False
        Me.txtMinimumStock.GroupSeperator = False
        Me.txtMinimumStock.Location = New System.Drawing.Point(333, 318)
        Me.txtMinimumStock.MaxLength = 3
        Me.txtMinimumStock.Name = "txtMinimumStock"
        Me.txtMinimumStock.Negative = False
        Me.txtMinimumStock.Size = New System.Drawing.Size(100, 26)
        Me.txtMinimumStock.Space = False
        Me.txtMinimumStock.TabIndex = 10
        Me.txtMinimumStock.Visible = False
        '
        'txtExpire
        '
        Me.txtExpire.AllowSpace = False
        Me.txtExpire.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtExpire.DecimalSeparator = False
        Me.txtExpire.Enabled = False
        Me.txtExpire.GroupSeperator = False
        Me.txtExpire.Location = New System.Drawing.Point(241, 284)
        Me.txtExpire.MaxLength = 3
        Me.txtExpire.Name = "txtExpire"
        Me.txtExpire.Negative = False
        Me.txtExpire.Size = New System.Drawing.Size(100, 26)
        Me.txtExpire.Space = False
        Me.txtExpire.TabIndex = 8
        '
        'txtTAX
        '
        Me.txtTAX.AllowSpace = False
        Me.txtTAX.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtTAX.DecimalSeparator = False
        Me.txtTAX.GroupSeperator = False
        Me.txtTAX.Location = New System.Drawing.Point(241, 221)
        Me.txtTAX.MaxLength = 5
        Me.txtTAX.Name = "txtTAX"
        Me.txtTAX.Negative = False
        Me.txtTAX.Size = New System.Drawing.Size(47, 26)
        Me.txtTAX.Space = False
        Me.txtTAX.TabIndex = 6
        '
        'txtPrice
        '
        Me.txtPrice.AllowSpace = False
        Me.txtPrice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPrice.DecimalSeparator = True
        Me.txtPrice.GroupSeperator = False
        Me.txtPrice.Location = New System.Drawing.Point(241, 155)
        Me.txtPrice.MaxLength = 8
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Negative = False
        Me.txtPrice.Size = New System.Drawing.Size(113, 26)
        Me.txtPrice.Space = False
        Me.txtPrice.TabIndex = 4
        Me.txtPrice.Text = "0.00"
        Me.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Location = New System.Drawing.Point(610, 149)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 62)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "GO BACK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtCode
        '
        Me.txtCode.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtCode.Location = New System.Drawing.Point(241, 55)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(278, 26)
        Me.txtCode.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(81, 58)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(114, 20)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Product Code :"
        '
        'Column1
        '
        Me.Column1.FillWeight = 40.0!
        Me.Column1.HeaderText = "Edit"
        Me.Column1.Name = "Column1"
        Me.Column1.Text = "Edit"
        Me.Column1.UseColumnTextForButtonValue = True
        Me.Column1.Width = 43
        '
        'frmAddMerchandise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 817)
        Me.Controls.Add(Me.txtCode)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgProducts)
        Me.Controls.Add(Me.txtExpireType)
        Me.Controls.Add(Me.txtUnit)
        Me.Controls.Add(Me.txtBrand)
        Me.Controls.Add(Me.txtProductCategory)
        Me.Controls.Add(Me.txtMinimumStock)
        Me.Controls.Add(Me.txtExpire)
        Me.Controls.Add(Me.txtTAX)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.txtProduct)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblUnit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddMerchandise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Merchandise"
        CType(Me.dgProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice As Room_Rent.NumericTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMinimumStock As Room_Rent.NumericTextBox
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTAX As Room_Rent.NumericTextBox
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents txtExpire As Room_Rent.NumericTextBox
    Friend WithEvents txtProductCategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtBrand As System.Windows.Forms.ComboBox
    Friend WithEvents txtUnit As System.Windows.Forms.ComboBox
    Friend WithEvents txtExpireType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dgProducts As System.Windows.Forms.DataGridView
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn
End Class
