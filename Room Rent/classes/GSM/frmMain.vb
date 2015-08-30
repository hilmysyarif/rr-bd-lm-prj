Imports System.Data.OleDb
Public Class frmMain

    Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\db\sms.accdb;Persist Security Info=True")

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            conn.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        My.Application.ChangeCulture("en-GB")
        My.Application.ChangeUICulture("en-GB")

        txtCaste.Text = "General"
        txtDob.Value = Today
        ent1.Value = Today
        ent2.Value = Today
        dob1.Value = Today
        dob2.Value = Today
        Try

            conn.Close()
            conn.Open()
            generateID()
        Catch ex As Exception

            MsgBox("Error opening database connection", MsgBoxStyle.Information, "Information")

            Exit Sub

        End Try
        srCaste.Text = "All Caste"
        getItems(srCity, "City")
        getItems(srPersu, "Persuing")
        getItems(srQuali, "Qualification")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim da As New OleDbDataAdapter("select * from [Member] where 1=1 " & IIf(srCaste.Text <> "All Caste", " and caste='" & srCaste.Text & "'", "") & _
                                          IIf(srCity.Text <> "All City", " and City='" & srCity.Text & "'", "") & _
                                          IIf(srPersu.Text <> "All Persuing", " and Persuing='" & srPersu.Text & "'", "") & _
                                          IIf(srQuali.Text <> "All Qualification", " and Qualification='" & srQuali.Text & "'", ""), conn)
        If ent.Checked Then
            da.SelectCommand.CommandText += " and [EntryDate] between @ent1 and @ent2"
            da.SelectCommand.Parameters.Add("@ent1", OleDbType.Date).Value = ent1.Value
            da.SelectCommand.Parameters.Add("@ent2", OleDbType.Date).Value = ent2.Value.AddDays(1).AddSeconds(-1)
        End If

        If ent.Checked Then
            da.SelectCommand.CommandText += " and [Date of Birth] between @dob1 and @dob2"
            da.SelectCommand.Parameters.Add("@dob1", OleDbType.Date).Value = dob1.Value
            da.SelectCommand.Parameters.Add("@dob2", OleDbType.Date).Value = dob2.Value.AddDays(1).AddSeconds(-1)
        End If
        da.SelectCommand.CommandText += " Order By ID"
        Dim dt As New DataTable
        Try
            da.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
        End Try
    End Sub
    Sub getItems(ByRef obj As ComboBox, ByVal fld As String)
        Try
            obj.Items.Clear()
        Catch ex As Exception
        End Try
        Try
            Dim da As New OleDbDataAdapter("select distinct([" & fld & "]) as [" & fld & "] from [Member]", conn)
            Dim dt As New DataTable
            da.Fill(dt)
            Dim dr1 As DataRow = dt.NewRow
            dr1(0) = "All " & fld
            dt.Rows.InsertAt(dr1, 0)

            'Dim dr As DataRow = dt.NewRow
            'dr(0) = "Select " & fld
            'dt.Rows.InsertAt(dr, 0)

            obj.DataSource = dt
            obj.DisplayMember = fld

            obj.SelectedIndex = 0

        Catch ex As Exception

        End Try

    End Sub


    Sub generateID()
        Dim comID As New OleDbCommand("Select max(id) from [Member]", conn)
        txtID.Text = 1
        Try
            txtID.Text = comID.ExecuteScalar + 1
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        generateID()
        txtName.Text = ""
        txtFather.Text = ""
        txtAddress.Text = ""
        txtCity.Text = ""
        txtCaste.Text = "General"
        txtPin.Text = ""
        txtDob.Value = Today
        cmdPersuing.Text = ""
        cmbQuali.Text = ""
        txtPhoneO.Text = ""
        txtPhoneP.Text = ""
        txtRemarks.Text = ""
        btnSave.Text = "Save"
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Not IsNumeric(txtPhoneO.Text) Or txtPhoneO.Text.Length = 0) And txtPhoneO.Text <> "" Then
            MsgBox("Invalid Own Phone No", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        If Not IsNumeric(txtPhoneP.Text) Or txtPhoneP.Text.Length = 0 Then
            MsgBox("Invalid Parent Phone No", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        If txtName.Text = "" Then
            MsgBox("Invalid Name", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

        If txtFather.Text = "" Then
            MsgBox("Invalid Father Name", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        If txtPhoneO.Text <> "" Then
            Try
                Dim ComCountPh As New OleDbCommand("Select Count ([Phone Own]) from [Member] where [Phone Own]=@Phone_Own and [ID]<> @ID", conn)
                ComCountPh.Parameters.AddWithValue("@Phone_Parent", txtPhoneP.Text)
                ComCountPh.Parameters.AddWithValue("@ID", Val(txtID.Text))
                If ComCountPh.ExecuteScalar > 0 Then
                    MsgBox("Own Phone No. already exists", MsgBoxStyle.Information, "Information")
                    Exit Sub
                End If
            Catch ex As Exception
            End Try
        End If

        Try
            Dim ComCountPh As New OleDbCommand("Select Count ([Phone Own]) from [Member] where [Phone Parent]=@Phone_Parent and [ID]<> @ID", conn)
           ComCountPh.Parameters.AddWithValue("@Phone_Parent", txtPhoneP.Text)
            ComCountPh.Parameters.AddWithValue("@ID", Val(txtID.Text))
            If ComCountPh.ExecuteScalar > 0 Then
                MsgBox("Parent Phone No. already exists", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        Try
            If btnSave.Text = "Update" Then
                Dim comInsert As New OleDbCommand("UPDATE  [Member] " & _
                                                                              " SET " & _
                                                                              "[Name]=@Name," & _
                                                                              "[FatherName]=@FatherName," & _
                                                                              "[Address]=@Address," & _
                                                                              "[City]=@City," & _
                                                                              "[Caste]=@Caste," & _
                                                                              "[PIN]=@PIN," & _
                                                                              "[Date of Birth]=@Date_of_Birth," & _
                                                                              "[Persuing]=@Persuing," & _
                                                                              "[Qualification]=@Qualification," & _
                                                                              "[Phone Own]=@Phone_Own," & _
                                                                              "[Phone Parent]=@Phone_Parent," & _
                                                                              "[Remarks]=@Remarks" & _
                                                                              " WHERE [ID]=@ID", conn)
                comInsert.Parameters.Clear()
                comInsert.Parameters.AddWithValue("@Name", txtName.Text)
                comInsert.Parameters.AddWithValue("@FatherName", txtFather.Text)
                comInsert.Parameters.AddWithValue("@Address", txtAddress.Text)
                comInsert.Parameters.AddWithValue("@City", txtCity.Text)
                comInsert.Parameters.AddWithValue("@Caste", txtCaste.Text)
                comInsert.Parameters.AddWithValue("@PIN", txtPin.Text)
                comInsert.Parameters.Add("@Date_of_Birth", OleDbType.Date).Value = txtDob.Value
                comInsert.Parameters.AddWithValue("@Persuing", cmdPersuing.Text)
                comInsert.Parameters.AddWithValue("@Qualification", cmbQuali.Text)
                comInsert.Parameters.AddWithValue("@Phone_Own", txtPhoneO.Text)
                comInsert.Parameters.AddWithValue("@Phone_Parent", txtPhoneP.Text)
                comInsert.Parameters.AddWithValue("@Remarks", txtRemarks.Text)
                comInsert.Parameters.AddWithValue("@ID", Val(txtID.Text))
                comInsert.ExecuteNonQuery()
                btnSave.Text = "Update"

                MsgBox("Updated", MsgBoxStyle.Information, "Info")


            Else


                Dim comInsert As New OleDbCommand("Insert" & _
                                                    " INTO " & _
                                                    " [Member] " & _
                                                    "(" & _
                                                    "[ID]," & _
                                                    "[Name]," & _
                                                    "[FatherName]," & _
                                                    "[Address]," & _
                                                    "[City]," & _
                                                    "[Caste]," & _
                                                    "[PIN]," & _
                                                    "[Date of Birth]," & _
                                                    "[Persuing]," & _
                                                    "[Qualification]," & _
                                                    "[Phone Own]," & _
                                                    "[Phone Parent]," & _
                                                    "[Remarks]" & _
                                                    ")" & _
                                                    "values " & _
                                                    "(" & _
                                                    "@ID," & _
                                                    "@Name," & _
                                                    "@FatherName," & _
                                                    "@Address," & _
                                                    "@City," & _
                                                    "@Caste," & _
                                                    "@PIN," & _
                                                    "@Date_of_Birth," & _
                                                    "@Persuing," & _
                                                    "@Qualification," & _
                                                    "@Phone_Own," & _
                                                    "@Phone_Parent," & _
                                                    "@Remarks" & _
                                                    ")", conn)
                comInsert.Parameters.Clear()
                comInsert.Parameters.AddWithValue("@ID", Val(txtID.Text))
                comInsert.Parameters.AddWithValue("@Name", txtName.Text)
                comInsert.Parameters.AddWithValue("@FatherName", txtFather.Text)
                comInsert.Parameters.AddWithValue("@Address", txtAddress.Text)
                comInsert.Parameters.AddWithValue("@City", txtCity.Text)
                comInsert.Parameters.AddWithValue("@Caste", txtCaste.Text)
                comInsert.Parameters.AddWithValue("@PIN", txtPin.Text)
                comInsert.Parameters.Add("@Date_of_Birth", OleDbType.Date).Value = txtDob.Value
                comInsert.Parameters.AddWithValue("@Persuing", cmdPersuing.Text)
                comInsert.Parameters.AddWithValue("@Qualification", cmbQuali.Text)
                comInsert.Parameters.AddWithValue("@Phone_Own", txtPhoneO.Text)
                comInsert.Parameters.AddWithValue("@Phone_Parent", txtPhoneP.Text)
                comInsert.Parameters.AddWithValue("@Remarks", txtRemarks.Text)
                comInsert.ExecuteNonQuery()
                btnSave.Text = "Update"
                MsgBox("Saved", MsgBoxStyle.Information, "Info")
            End If

        Catch ex As Exception '
            MsgBox("Not Saved", MsgBoxStyle.Information, "Information")
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim id As String = InputBox("Open ID", "Open", "")
        If IsNumeric(id) And id <> "" Then
            Open(id)
        End If


    End Sub
    Sub Open(ByVal id As String)
        Try
            Dim da As New OleDbDataAdapter("select * from [Member] where id=" & id, conn)
            Dim dt As New DataTable
            Try
                da.Fill(dt)
                Dim dr As DataRow = dt.Rows(0)
                txtID.Text = dr("ID")
                txtName.Text = dr("Name")
                txtFather.Text = dr("FatherName")
                txtAddress.Text = dr("Address")
                txtCity.Text = dr("City")
                txtCaste.Text = dr("Caste")
                txtPin.Text = dr("PIN")
                txtDob.Value = dr("Date of Birth")
                cmdPersuing.Text = dr("Persuing")
                cmbQuali.Text = dr("Qualification")
                txtPhoneO.Text = dr("Phone Own")
                txtPhoneP.Text = dr("Phone Parent")
                txtRemarks.Text = dr("Remarks")
                btnSave.Text = "Update"
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ent.CheckedChanged
        ent1.Enabled = ent.Checked
        ent2.Enabled = ent.Checked
    End Sub

    Private Sub dob_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dob.CheckedChanged
        dob1.Enabled = dob.Checked
        dob2.Enabled = dob.Checked
    End Sub

    Private Sub TabControl2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedIndex = 1 Then
            getItems(srCity, "City")
            getItems(srPersu, "Persuing")
            getItems(srQuali, "Qualification")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        For i = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).Cells(0).Value = "Y"
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        For i = 0 To DataGridView1.RowCount - 1
            DataGridView1.Rows(i).Cells(0).Value = "N"
        Next
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If frmSMSDailog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim msg As String = frmSMSDailog.RichTextBox1.Text
            If msg <> "" Then
                Dim __List As New List(Of SMS_Client)
                Dim i As Integer = 0
                Dim c = 0
                For i = 0 To DataGridView1.RowCount - 1
                    Try
                        If DataGridView1.Rows(i).Cells(0).Value = "Y" Then
                            Dim __ListItem As New SMS_Client

                            Dim naam As String = DataGridView1.Rows(i).Cells(2).Value
                            Try
                                If naam.Split(" ")(0).Trim.Length > 2 Then
                                    naam = naam.Split(" ")(0).Trim
                                End If
                            Catch ex As Exception
                            End Try
                            __ListItem.MSG__ = frmSMSDailog.RichTextBox2.Text.Trim & " " & naam.Trim & "," & vbNewLine & frmSMSDailog.RichTextBox1.Text.Trim
                            __ListItem.No__ = DataGridView1.Rows(i).Cells(11).Value
                            c += 1
                            __List.Add(__ListItem)
                        End If
                    Catch ex As Exception
                    End Try
                Next
                Dim frm As New frmBulkSMS(__List)
            End If
        End If

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If frmSMSDailog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim msg As String = frmSMSDailog.RichTextBox1.Text
            If msg <> "" Then
                Dim Nos(DataGridView1.RowCount) As String
                Dim i As Integer = 0
                Dim c = 0
                Dim __List As New List(Of SMS_Client)
                For i = 0 To DataGridView1.RowCount - 1
                    Try
                        If DataGridView1.Rows(i).Cells(0).Value = "Y" Then
                            Dim __ListItem As New SMS_Client
                            Dim naam As String = DataGridView1.Rows(i).Cells(2).Value
                            Try
                                If naam.Split(" ")(0).Trim.Split.Length > 2 Then
                                    naam = naam.Split(" ")(0).Trim
                                End If
                            Catch ex As Exception
                            End Try


                            __ListItem.MSG__ = frmSMSDailog.RichTextBox2.Text.Trim & " " & naam.Trim & "," & vbNewLine & frmSMSDailog.RichTextBox1.Text.Trim
                            __ListItem.No__ = DataGridView1.Rows(i).Cells(12).Value
                            c += 1
                            __List.Add(__ListItem)

                        End If
                    Catch ex As Exception
                    End Try
                Next
                Dim frm As New frmBulkSMS(__List)
            End If
        End If
    End Sub












    'Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
    '    CheckRefresh()
    'End Sub
    'Dim isRef As Boolean = False
    'Sub CheckRefresh()
    '    Dim cnt As Integer = 0
    '    Dim ind As Integer = 0
    '    For i = 0 To DataGridView1.Rows.Count - 1
    '        If Not DataGridView1.Rows(i).Cells(0).Value Is Nothing Then
    '            If DataGridView1.Rows(i).Cells(0).Value.ToString = "Y" Then
    '                cnt += 1
    '            Else
    '                ind += 1
    '            End If
    '        Else
    '            ind += 1
    '        End If
    '    Next
    '    isRef = True
    '    If ind = 0 Then
    '        CheckBox2.CheckState = CheckState.Checked
    '    ElseIf cnt = 0 Then
    '        CheckBox2.CheckState = CheckState.Unchecked
    '    Else
    '        CheckBox2.CheckState = CheckState.Indeterminate
    '    End If
    '    isRef = False
    'End Sub

    'Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
    '    If Not isRef Then
    '        For i = 0 To DataGridView1.Rows.Count - 1
    '            DataGridView1.Rows(i).Cells(0).Value = IIf(CheckBox2.Checked, "Y", "N")
    '        Next
    '    End If
    'End Sub

    'Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
    '    DataGridView1.EndEdit()
    'End Sub

    'Private Sub DataGridView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseUp
    '    DataGridView1.EndEdit()
    'End Sub
    'Dim isFirstCel As Boolean = False
    'Private Sub dgList_RowStateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView1.RowStateChanged
    '    If Not isFirstCel Then
    '        e.Row.Cells(0).Value = IIf(e.Row.Selected, "Y", "N")
    '    End If
    '    CheckRefresh()
    'End Sub

    'Private Sub DataGridView1_CellMouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown
    '    If e.RowIndex >= 0 Then
    '        If e.ColumnIndex <> 0 Then
    '            'DataGridView1.Rows(e.RowIndex).Cells(0).Value = IIf(DataGridView1.Rows(e.RowIndex).Selected, 1, 0)
    '            'CheckRefresh()
    '            isFirstCel = False
    '        Else
    '            isFirstCel = True
    '        End If
    '    End If
    'End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim str1 As String = InputBox("Enter From Row No", "Enter Number only", "1")
        If Not IsNumeric(str1) Then
            MsgBox("Enter valid no", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        Dim str2 As String = InputBox("Enter To Row No", "Enter Number only", DataGridView1.RowCount.ToString)
        If Not IsNumeric(str2) Then
            MsgBox("Enter valid no", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        For i = 0 To DataGridView1.RowCount - 1
            If (i + 1) >= Val(str1) And (i + 1) <= Val(str2) Then
                DataGridView1.Rows(i).Cells(0).Value = "Y"
            Else
                DataGridView1.Rows(i).Cells(0).Value = "N"
            End If
        Next
    End Sub
End Class
