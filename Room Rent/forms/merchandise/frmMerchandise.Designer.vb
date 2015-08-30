<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMerchandise
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpCategory = New System.Windows.Forms.GroupBox()
        Me.dgCategory = New System.Windows.Forms.DataGridView()
        Me.btnStock = New System.Windows.Forms.Button()
        Me.btnItems = New System.Windows.Forms.Button()
        Me.grpItems = New System.Windows.Forms.GroupBox()
        Me.dgProducs = New System.Windows.Forms.DataGridView()
        Me.grpCart = New System.Windows.Forms.GroupBox()
        Me.dgCart = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grpCategory.SuspendLayout()
        CType(Me.dgCategory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpItems.SuspendLayout()
        CType(Me.dgProducs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCart.SuspendLayout()
        CType(Me.dgCart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpCategory
        '
        Me.grpCategory.Controls.Add(Me.dgCategory)
        Me.grpCategory.Controls.Add(Me.btnStock)
        Me.grpCategory.Controls.Add(Me.btnItems)
        Me.grpCategory.Controls.Add(Me.Button1)
        Me.grpCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCategory.Location = New System.Drawing.Point(3, 3)
        Me.grpCategory.Name = "grpCategory"
        Me.grpCategory.Size = New System.Drawing.Size(275, 474)
        Me.grpCategory.TabIndex = 8
        Me.grpCategory.TabStop = False
        Me.grpCategory.Text = "CATEGORY"
        '
        'dgCategory
        '
        Me.dgCategory.AllowUserToAddRows = False
        Me.dgCategory.AllowUserToDeleteRows = False
        Me.dgCategory.AllowUserToResizeColumns = False
        Me.dgCategory.AllowUserToResizeRows = False
        Me.dgCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgCategory.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgCategory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCategory.ColumnHeadersVisible = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCategory.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCategory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCategory.Location = New System.Drawing.Point(3, 16)
        Me.dgCategory.MultiSelect = False
        Me.dgCategory.Name = "dgCategory"
        Me.dgCategory.RowHeadersVisible = False
        Me.dgCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCategory.Size = New System.Drawing.Size(269, 308)
        Me.dgCategory.TabIndex = 0
        '
        'btnStock
        '
        Me.btnStock.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStock.Location = New System.Drawing.Point(3, 324)
        Me.btnStock.Name = "btnStock"
        Me.btnStock.Size = New System.Drawing.Size(269, 49)
        Me.btnStock.TabIndex = 9
        Me.btnStock.Text = "ADD STOCK"
        Me.btnStock.UseVisualStyleBackColor = True
        '
        'btnItems
        '
        Me.btnItems.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItems.Location = New System.Drawing.Point(3, 373)
        Me.btnItems.Name = "btnItems"
        Me.btnItems.Size = New System.Drawing.Size(269, 49)
        Me.btnItems.TabIndex = 9
        Me.btnItems.Text = "ADD ITEMS"
        Me.btnItems.UseVisualStyleBackColor = True
        '
        'grpItems
        '
        Me.grpItems.Controls.Add(Me.dgProducs)
        Me.grpItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpItems.Location = New System.Drawing.Point(284, 3)
        Me.grpItems.Name = "grpItems"
        Me.grpItems.Size = New System.Drawing.Size(275, 474)
        Me.grpItems.TabIndex = 8
        Me.grpItems.TabStop = False
        Me.grpItems.Text = "PRODUCT"
        '
        'dgProducs
        '
        Me.dgProducs.AllowUserToAddRows = False
        Me.dgProducs.AllowUserToDeleteRows = False
        Me.dgProducs.AllowUserToResizeColumns = False
        Me.dgProducs.AllowUserToResizeRows = False
        Me.dgProducs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgProducs.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgProducs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgProducs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgProducs.ColumnHeadersVisible = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(5)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgProducs.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgProducs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgProducs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgProducs.Location = New System.Drawing.Point(3, 16)
        Me.dgProducs.MultiSelect = False
        Me.dgProducs.Name = "dgProducs"
        Me.dgProducs.RowHeadersVisible = False
        Me.dgProducs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgProducs.Size = New System.Drawing.Size(269, 455)
        Me.dgProducs.TabIndex = 1
        '
        'grpCart
        '
        Me.grpCart.Controls.Add(Me.dgCart)
        Me.grpCart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpCart.Location = New System.Drawing.Point(565, 3)
        Me.grpCart.Name = "grpCart"
        Me.grpCart.Size = New System.Drawing.Size(286, 474)
        Me.grpCart.TabIndex = 8
        Me.grpCart.TabStop = False
        Me.grpCart.Text = "CART"
        '
        'dgCart
        '
        Me.dgCart.AllowUserToAddRows = False
        Me.dgCart.AllowUserToDeleteRows = False
        Me.dgCart.AllowUserToResizeColumns = False
        Me.dgCart.AllowUserToResizeRows = False
        Me.dgCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgCart.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgCart.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCart.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCart.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column10})
        Me.dgCart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCart.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCart.Location = New System.Drawing.Point(3, 16)
        Me.dgCart.Name = "dgCart"
        Me.dgCart.RowHeadersVisible = False
        Me.dgCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCart.Size = New System.Drawing.Size(280, 455)
        Me.dgCart.TabIndex = 1
        '
        'Column4
        '
        Me.Column4.HeaderText = "CARTITEMID"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Visible = False
        '
        'Column5
        '
        Me.Column5.HeaderText = "ITEM"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "QTY"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "PRICE"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "SUB TOTAL"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "ADD"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "LESS"
        Me.Column10.Name = "Column10"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grpCategory, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grpCart, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.grpItems, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(854, 480)
        Me.TableLayoutPanel1.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(3, 422)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(269, 49)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "GO BACK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMerchandise
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 480)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmMerchandise"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mechandise"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grpCategory.ResumeLayout(False)
        CType(Me.dgCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpItems.ResumeLayout(False)
        CType(Me.dgProducs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCart.ResumeLayout(False)
        CType(Me.dgCart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpCategory As System.Windows.Forms.GroupBox
    Friend WithEvents grpItems As System.Windows.Forms.GroupBox
    Friend WithEvents grpCart As System.Windows.Forms.GroupBox
    Friend WithEvents dgCategory As System.Windows.Forms.DataGridView
    Friend WithEvents dgProducs As System.Windows.Forms.DataGridView
    Friend WithEvents dgCart As System.Windows.Forms.DataGridView
    Friend WithEvents btnItems As System.Windows.Forms.Button
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents btnStock As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
