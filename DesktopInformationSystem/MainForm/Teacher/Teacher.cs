using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DesktopInformationSystem
{
    public partial class Teacher : UserControl
    {
        // Connection string for connecting to the SQL database.
        private readonly string connectionString = ConnectConfig.connection;

        // Constructor initializes the Teacher user control and displays teacher data.
        public Teacher()
        {
            InitializeComponent();
            DisplayTeacherData(); // Load teacher data when the control is initialized.
        }

        // Refreshes the teacher data displayed on the form. 
        // If invoked from a different thread, ensures the method is executed on the UI thread.
        private void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DisplayTeacherData();
        }

        // Displays teacher data in the DataGridView control.
        public void DisplayTeacherData()
        {
            // Retrieves a list of teacher data from the TeacherData class.
            List<TeacherData> listData = TeacherData.GetTeacherListData();
            // Binds the data to the DataGridView for display.
            dataGridView1.DataSource = listData;
        }

        // Adds a new teacher record to the database.
        private void AddTeacher()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    // SQL command to insert a new teacher record.
                    string insertData = "INSERT INTO teachers " +
                        "(teacher_id, teacher_name, teacher_gender, teacher_email, teacher_phone, teacher_subject1, teacher_subject2, teacher_role, salary, insert_date, status) " +
                        "VALUES (@teacherID, @teacherName, @teacherGender, @teacherEmail, @teacherPhone, @teacherSubject1, @teacherSubject2, @teacherRole, @salary, @insertDate, @status)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        // Adding parameters with values from text fields to prevent SQL injection.
                        cmd.Parameters.AddWithValue("@teacherID", teacher_id.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherName", teacher_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherGender", teacher_gender.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherEmail", teacher_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherPhone", teacher_phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherRole", teacher_role.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherSubject1", teacher_subject1.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherSubject2", teacher_subject2.Text.Trim());
                        cmd.Parameters.AddWithValue("@salary", 0); // Default salary value.
                        cmd.Parameters.AddWithValue("@insertDate", DateTime.Today); // Current date.
                        cmd.Parameters.AddWithValue("@status", teacher_status.Text.Trim());

                        cmd.ExecuteNonQuery(); // Execute the insert command.
                        DisplayTeacherData(); // Refresh the displayed data.
                        MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields(); // Clear the input fields.
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Checks if a teacher ID is already taken in the database.
        private bool IsTeacherIDTaken()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    // SQL command to count the number of records with the same teacher ID.
                    string checkEmID = "SELECT COUNT(*) FROM teachers WHERE teacher_id = @teID AND delete_date IS NULL";

                    using (SqlCommand checkEm = new SqlCommand(checkEmID, connect))
                    {
                        checkEm.Parameters.AddWithValue("@teID", teacher_id.Text.Trim());
                        int count = (int)checkEm.ExecuteScalar(); // Get the count of records.
                        return count >= 1; // Return true if the ID is found.
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Updates an existing teacher record in the database.
        private void UpdateTeacher()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    // SQL command to update a teacher record.
                    string updateData = "UPDATE teachers SET teacher_name = @teacherName, teacher_gender = @teacherGender, teacher_email = @teacherEmail, teacher_phone = @teacherPhone, teacher_role = @teacherRole, teacher_subject1 = @teacherSubject1, teacher_subject2 = @teacherSubject2, update_date = @updateDate, status = @status WHERE teacher_id = @teacherID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        // Adding parameters with values from text fields to prevent SQL injection.
                        cmd.Parameters.AddWithValue("@teacherName", teacher_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherGender", teacher_gender.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherEmail", teacher_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherPhone", teacher_phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherRole", teacher_role.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherSubject1", teacher_subject1.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherSubject2", teacher_subject2.Text.Trim());
                        cmd.Parameters.AddWithValue("@updateDate", DateTime.Today); // Current date.
                        cmd.Parameters.AddWithValue("@status", teacher_status.Text.Trim());
                        cmd.Parameters.AddWithValue("@teacherID", teacher_id.Text.Trim());

                        cmd.ExecuteNonQuery(); // Execute the update command.
                        DisplayTeacherData(); // Refresh the displayed data.
                        MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields(); // Clear the input fields.
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Marks a teacher record as deleted by setting the delete_date field.
        private void DeleteTeacher()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    // SQL command to update the delete_date field for a teacher record.
                    string updateData = "UPDATE teachers SET delete_date = @deleteDate WHERE teacher_id = @teacherID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@deleteDate", DateTime.Today); // Current date.
                        cmd.Parameters.AddWithValue("@teacherID", teacher_id.Text.Trim());

                        cmd.ExecuteNonQuery(); // Execute the update command.
                        DisplayTeacherData(); // Refresh the displayed data.
                        MessageBox.Show("Deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields(); // Clear the input fields.
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if an exception occurs.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validates that all required fields are filled in.
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

        // Clears all input fields on the form.
        private void ClearFields()
        {
            teacher_id.Clear();
            teacher_name.Clear();
            teacher_gender.SelectedIndex = -1; // Reset combo box selection.
            teacher_email.Clear();
            teacher_phone.Clear();
            teacher_role.SelectedIndex = -1; // Reset combo box selection.
            teacher_subject1.SelectedIndex = -1; // Reset combo box selection.
            teacher_subject2.SelectedIndex = -1; // Reset combo box selection.
            teacher_status.SelectedIndex = -1; // Reset combo box selection.
        }

        // Event handler for the Add button click event.
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

        // Event handler for the Update button click event.
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

        // Event handler for the Delete button click event.
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

        // Event handler for the Clear button click event.
        private void teacher_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields(); // Clear all input fields.
        }

        // Event handler for cell click event in the DataGridView.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Populate input fields with data from the selected row.
                teacher_id.Text = row.Cells[1].Value.ToString();
                teacher_name.Text = row.Cells[2].Value.ToString();
                teacher_gender.Text = row.Cells[3].Value.ToString();
                teacher_email.Text = row.Cells[4].Value.ToString();
                teacher_phone.Text = row.Cells[5].Value.ToString();
                teacher_role.Text = row.Cells[6].Value.ToString();
                teacher_subject1.Text = row.Cells[8].Value.ToString();
                teacher_subject2.Text = row.Cells[9].Value.ToString();
                teacher_status.Text = row.Cells[10].Value.ToString();
            }
        }
    }
}
