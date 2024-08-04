using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace DesktopInformationSystem
{
    public partial class Student : UserControl
    {
        private readonly string connectionString = ConnectConfig.connection;
        public Student()
        {
            InitializeComponent();

            DisplayStudentData();
        }
        private void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DisplayStudentData();
        }

        public void DisplayStudentData()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string selectData = "SELECT * FROM students WHERE delete_date IS NULL";
                    SqlDataAdapter adapter = new SqlDataAdapter(selectData, connect);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    student_studentData.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddStudent()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string insertData = "INSERT INTO students " +
                        "(student_id, student_name, student_gender, student_email, student_phone, student_currentsubject1, student_currentsubject2, student_studiedsubject1, student_studiedsubject2, student_role, insert_date, status) " +
                        "VALUES (@studentID, @studentName, @studentGender, @studentEmail, @studentPhone, @studentCurrentsubject1, @studentCurrentsubject2, @studentStudiedsubject1, @studentStudiedsubject2, @studentRole, @insertDate, @status)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@studentID", student_id.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentName", student_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentGender", student_gender.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentEmail", student_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentPhone", student_phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentRole", student_role.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentCurrentsubject1", student_currentsubject1.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentCurrentsubject2", student_currentsubject2.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentStudiedsubject1", student_studiedsubject1.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentStudiedsubject2", student_studiedsubject2.Text.Trim());
                        cmd.Parameters.AddWithValue("@insertDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@status", student_status.Text.Trim());

                        cmd.ExecuteNonQuery();
                        DisplayStudentData();
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

        private bool IsStudentIDTaken()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string checkEmID = "SELECT COUNT(*) FROM students WHERE student_id = @teID AND delete_date IS NULL";

                    using (SqlCommand checkEm = new SqlCommand(checkEmID, connect))
                    {
                        checkEm.Parameters.AddWithValue("@teID", student_id.Text.Trim());
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
        private void UpdateStudent()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString)) 
                {
                    connect.Open();
                    string updateData = "UPDATE students SET student_name = @studentName, student_gender = @studentGender, student_email = @studentEmail, student_phone = @studentPhone, student_role = @studentRole, student_currentsubject1 = @studentCurrentsubject1, student_currentsubject2 = @studentCurrentsubject2, student_studiedsubject1 = @studentStudiedsubject1, student_studiedsubject2 = @studentStudiedsubject2, update_date = @updateDate, status = @status WHERE student_id = @studentID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@studentName", student_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentGender", student_gender.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentEmail", student_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentPhone", student_phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentRole", student_role.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentCurrentsubject1", student_currentsubject1.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentCurrentsubject2", student_currentsubject2.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentStudiedsubject1", student_studiedsubject1.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentStudiedsubject2", student_studiedsubject2.Text.Trim());
                        cmd.Parameters.AddWithValue("@updateDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@status", student_status.Text.Trim());
                        cmd.Parameters.AddWithValue("@studentID", student_id.Text.Trim());

                        cmd.ExecuteNonQuery();
                        DisplayStudentData();
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
        private void DeleteStudent()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string updateData = "UPDATE students SET delete_date = @deleteDate WHERE student_id = @studentID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@deleteDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@studentID", student_id.Text.Trim());

                        cmd.ExecuteNonQuery();
                        DisplayStudentData();
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
            return !string.IsNullOrWhiteSpace(student_id.Text) &&
                   !string.IsNullOrWhiteSpace(student_name.Text) &&
                   !string.IsNullOrWhiteSpace(student_gender.Text) &&
                   !string.IsNullOrWhiteSpace(student_email.Text) &&
                   !string.IsNullOrWhiteSpace(student_phone.Text) &&
                   !string.IsNullOrWhiteSpace(student_role.Text) &&
                   !string.IsNullOrWhiteSpace(student_currentsubject1.Text) &&
                   !string.IsNullOrWhiteSpace(student_currentsubject2.Text) &&
                   !string.IsNullOrWhiteSpace(student_studiedsubject1.Text) &&
                   !string.IsNullOrWhiteSpace(student_studiedsubject2.Text) &&
                   !string.IsNullOrWhiteSpace(student_status.Text);
        }
        private void ClearFields()
        {
            student_id.Clear();
            student_name.Clear();
            student_gender.SelectedIndex = -1;
            student_email.Clear();
            student_phone.Clear();
            student_role.SelectedIndex = -1;
            student_currentsubject1.SelectedIndex = -1;
            student_currentsubject2.SelectedIndex = -1;
            student_studiedsubject1.SelectedIndex = -1;
            student_studiedsubject2.SelectedIndex = -1;
            student_status.SelectedIndex = -1;
        }

        private void student_studentData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = student_studentData.Rows[e.RowIndex];
                student_id.Text = row.Cells["student_id"].Value.ToString();
                student_name.Text = row.Cells["student_name"].Value.ToString();
                student_gender.Text = row.Cells["student_gender"].Value.ToString();
                student_email.Text = row.Cells["student_email"].Value.ToString();
                student_phone.Text = row.Cells["student_phone"].Value.ToString();
                student_role.Text = row.Cells["student_role"].Value.ToString();
                student_currentsubject1.Text = row.Cells["student_currentsubject1"].Value.ToString();
                student_currentsubject2.Text = row.Cells["student_currentsubject2"].Value.ToString();
                student_studiedsubject1.Text = row.Cells["student_studiedsubject1"].Value.ToString();
                student_studiedsubject2.Text = row.Cells["student_studiedsubject2"].Value.ToString();
                student_status.Text = row.Cells["status"].Value.ToString();
            }
        }

        private void student_addBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                if (IsStudentIDTaken())
                {
                    MessageBox.Show($"{student_id.Text.Trim()} is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AddStudent();
                }
            }
            else
            {
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void student_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void student_updateBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                var result = MessageBox.Show($"Are you sure you want to UPDATE student ID: {student_id.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    UpdateStudent();
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

        private void student_deleteBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                var result = MessageBox.Show($"Are you sure you want to DELETE student ID: {student_id.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    DeleteStudent();
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
    }
}
