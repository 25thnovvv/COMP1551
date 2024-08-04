using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DesktopInformationSystem
{
    public partial class Teacher : UserControl
    {
        private readonly string connectionString = ConnectConfig.connection;

        public Teacher()
        {
            InitializeComponent();
            DisplayTeacherData();
        }

        private void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DisplayTeacherData();
        }

        public void DisplayTeacherData()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string selectData = "SELECT * FROM teachers WHERE delete_date IS NULL";
                    SqlDataAdapter adapter = new SqlDataAdapter(selectData, connect);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddTeacher()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string insertData = "INSERT INTO teachers " +
                        "(teacher_id, teacher_name, teacher_gender, teacher_email, teacher_phone, teacher_subject1, teacher_subject2, teacher_role, salary, insert_date, status) " +
                        "VALUES (@teacherID, @teacherName, @teacherGender, @teacherEmail, @teacherPhone, @teacherSubject1, @teacherSubject2, @teacherRole, @salary, @insertDate, @status)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@teacherID", teacher_id.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherName", teacher_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherGender", teacher_gender.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherEmail", teacher_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherPhone", teacher_phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherRole", teacher_role.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherSubject1", teacher_subject1.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherSubject2", teacher_subject2.Text.Trim());
                        cmd.Parameters.AddWithValue("@salary", 0);
                        cmd.Parameters.AddWithValue("@insertDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@status", teacher_status.Text.Trim());

                        cmd.ExecuteNonQuery();
                        DisplayTeacherData();
                        MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsTeacherIDTaken()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string checkEmID = "SELECT COUNT(*) FROM teachers WHERE teacher_id = @teID AND delete_date IS NULL";

                    using (SqlCommand checkEm = new SqlCommand(checkEmID, connect))
                    {
                        checkEm.Parameters.AddWithValue("@teID", teacher_id.Text.Trim());
                        int count = (int)checkEm.ExecuteScalar();
                        return count >= 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void UpdateTeacher()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString)) 
                {
                    connect.Open();
                    string updateData = "UPDATE teachers SET teacher_name = @teacherName, teacher_gender = @teacherGender, teacher_email = @teacherEmail, teacher_phone = @teacherPhone, teacher_role = @teacherRole, teacher_subject1 = @teacherSubject1, teacher_subject2 = @teacherSubject2, update_date = @updateDate, status = @status WHERE teacher_id = @teacherID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@teacherName", teacher_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherGender", teacher_gender.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherEmail", teacher_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherPhone", teacher_phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherRole", teacher_role.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherSubject1", teacher_subject1.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherSubject2", teacher_subject2.Text.Trim());
                        cmd.Parameters.AddWithValue("@updateDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@status", teacher_status.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherID", teacher_id.Text.Trim());

                        cmd.ExecuteNonQuery();
                        DisplayTeacherData();
                        MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteTeacher()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string updateData = "UPDATE teachers SET delete_date = @deleteDate WHERE teacher_id = @teacherID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@deleteDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@teacherID", teacher_id.Text.Trim());

                        cmd.ExecuteNonQuery();
                        DisplayTeacherData();
                        MessageBox.Show("Deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AreFieldsValid()
        {
            return !string.IsNullOrWhiteSpace(teacher_id.Text) &&
                   !string.IsNullOrWhiteSpace(teacher_name.Text) &&
                   !string.IsNullOrWhiteSpace(teacher_gender.Text) &&
                   !string.IsNullOrWhiteSpace(teacher_email.Text) &&
                   !string.IsNullOrWhiteSpace(teacher_phone.Text) &&
                   !string.IsNullOrWhiteSpace(teacher_role.Text) &&
                   !string.IsNullOrWhiteSpace(teacher_subject1.Text) &&
                   !string.IsNullOrWhiteSpace(teacher_subject2.Text) &&
                   !string.IsNullOrWhiteSpace(teacher_status.Text);
        }

        private void ClearFields()
        {
            teacher_id.Clear();
            teacher_name.Clear();
            teacher_gender.SelectedIndex = -1;
            teacher_email.Clear();
            teacher_phone.Clear();
            teacher_role.SelectedIndex = -1;
            teacher_subject1.SelectedIndex = -1;
            teacher_subject2.SelectedIndex = -1;
            teacher_status.SelectedIndex = -1;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                teacher_id.Text = row.Cells["teacher_id"].Value.ToString();
                teacher_name.Text = row.Cells["teacher_name"].Value.ToString();
                teacher_gender.Text = row.Cells["teacher_gender"].Value.ToString();
                teacher_email.Text = row.Cells["teacher_email"].Value.ToString();
                teacher_phone.Text = row.Cells["teacher_phone"].Value.ToString();
                teacher_role.Text = row.Cells["teacher_role"].Value.ToString();
                teacher_subject1.Text = row.Cells["teacher_subject1"].Value.ToString();
                teacher_subject2.Text = row.Cells["teacher_subject2"].Value.ToString();
                teacher_status.Text = row.Cells["status"].Value.ToString();
            }
        }

        private void teacher_addBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                if (IsTeacherIDTaken())
                {
                    MessageBox.Show($"{teacher_id.Text.Trim()} is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AddTeacher();
                }
            }
            else
            {
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void teacher_updateBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                var result = MessageBox.Show($"Are you sure you want to UPDATE teacher ID: {teacher_id.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    UpdateTeacher();
                }
                else
                {
                    MessageBox.Show("Cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void teacher_deleteBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                var result = MessageBox.Show($"Are you sure you want to DELETE teacher ID: {teacher_id.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    DeleteTeacher();
                }
                else
                {
                    MessageBox.Show("Cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void teacher_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                teacher_id.Text = row.Cells["teacher_id"].Value.ToString();
                teacher_name.Text = row.Cells["teacher_name"].Value.ToString();
                teacher_gender.Text = row.Cells["teacher_gender"].Value.ToString();
                teacher_email.Text = row.Cells["teacher_email"].Value.ToString();
                teacher_phone.Text = row.Cells["teacher_phone"].Value.ToString();
                teacher_role.Text = row.Cells["teacher_role"].Value.ToString();
                teacher_subject1.Text = row.Cells["teacher_subject1"].Value.ToString();
                teacher_subject2.Text = row.Cells["teacher_subject2"].Value.ToString();
                teacher_status.Text = row.Cells["status"].Value.ToString();
            }
        }
    }
}
