using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace DesktopInformationSystem
{
    // The Student class represents the user control for managing student data within the application.
    // This class handles the display, insertion, updating, and deletion of student records.
    public partial class Student : UserControl
    {
        // Connection string used to connect to the SQL database.
        private readonly string connectionString = ConnectConfig.connection;

        // Constructor that initializes the user control and displays the student data.
        public Student()
        {
            InitializeComponent();

            // Load and display student data when the control is initialized.
            DisplayStudentData();
        }

        // Method to refresh the data displayed in the student data grid.
        // If the method is called from a different thread, it uses Invoke to marshal the call to the UI thread.
        private void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData); // Invoke the method on the UI thread if necessary.
                return;
            }
            DisplayStudentData(); // Refresh the student data display.
        }

        // Method to fetch and display student data from the database in the DataGridView.
        public void DisplayStudentData()
        {
            // Retrieve the list of students from the database.
            List<StudentData> listData = StudentData.GetStudentListData();

            // Set the data source of the DataGridView to the list of students.
            student_studentData.DataSource = listData;
        }

        // Method to add a new student to the database.
        private void AddStudent()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open(); // Open the database connection.

                    // SQL query to insert a new student record into the students table.
                    string insertData = "INSERT INTO students " +
                        "(student_id, student_name, student_gender, student_email, student_phone, student_currentsubject1, student_currentsubject2, student_studiedsubject1, student_studiedsubject2, student_role, insert_date, status) " +
                        "VALUES (@studentID, @studentName, @studentGender, @studentEmail, @studentPhone, @studentCurrentsubject1, @studentCurrentsubject2, @studentStudiedsubject1, @studentStudiedsubject2, @studentRole, @insertDate, @status)";

                    // Command to execute the SQL query, with parameters to prevent SQL injection.
                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        // Add values from the input fields to the SQL command parameters.
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

                        cmd.ExecuteNonQuery(); // Execute the SQL command to insert the new student.

                        DisplayStudentData(); // Refresh the student data display.
                        MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields(); // Clear the input fields after adding the student.
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong during the database operation.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to check if the student ID entered already exists in the database.
        private bool IsStudentIDTaken()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open(); // Open the database connection.

                    // SQL query to count the number of records with the same student ID that are not marked as deleted.
                    string checkEmID = "SELECT COUNT(*) FROM students WHERE student_id = @teID AND delete_date IS NULL";

                    using (SqlCommand checkEm = new SqlCommand(checkEmID, connect))
                    {
                        checkEm.Parameters.AddWithValue("@teID", student_id.Text.Trim()); // Add the student ID parameter.

                        // Execute the query and return true if the ID is already taken (count >= 1).
                        int count = (int)checkEm.ExecuteScalar();
                        return count >= 1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong during the database operation.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Method to update an existing student record in the database.
        private void UpdateStudent()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open(); // Open the database connection.

                    // SQL query to update the student record with the provided data.
                    string updateData = "UPDATE students SET student_name = @studentName, student_gender = @studentGender, student_email = @studentEmail, student_phone = @studentPhone, student_role = @studentRole, student_currentsubject1 = @studentCurrentsubject1, student_currentsubject2 = @studentCurrentsubject2, student_studiedsubject1 = @studentStudiedsubject1, student_studiedsubject2 = @studentStudiedsubject2, update_date = @updateDate, status = @status WHERE student_id = @studentID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        // Add values from the input fields to the SQL command parameters.
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

                        cmd.ExecuteNonQuery(); // Execute the SQL command to update the student record.

                        DisplayStudentData(); // Refresh the student data display.
                        MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields(); // Clear the input fields after updating the student.
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong during the database operation.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to delete a student record from the database by marking it with a delete date.
        private void DeleteStudent()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open(); // Open the database connection.

                    // SQL query to mark the student record as deleted by setting the delete_date field.
                    string updateData = "UPDATE students SET delete_date = @deleteDate WHERE student_id = @studentID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@deleteDate", DateTime.Today); // Add the delete date parameter.
                        cmd.Parameters.AddWithValue("@studentID", student_id.Text.Trim()); // Add the student ID parameter.

                        cmd.ExecuteNonQuery(); // Execute the SQL command to mark the student as deleted.

                        DisplayStudentData(); // Refresh the student data display.
                        MessageBox.Show("Deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearFields(); // Clear the input fields after deleting the student.
                    }
                }
            }
            catch (Exception ex)
            {
                // Display an error message if something goes wrong during the database operation.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to validate that all required fields are filled before performing any operations.
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

        // Method to clear all the input fields on the form.
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

        // Event handler for selecting a row in the DataGridView.
        // Populates the input fields with the selected student's data.
        private void student_studentData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = student_studentData.Rows[e.RowIndex];

                // Fill the input fields with the data from the selected row.
                student_id.Text = row.Cells[1].Value.ToString();
                student_name.Text = row.Cells[2].Value.ToString();
                student_gender.Text = row.Cells[3].Value.ToString();
                student_email.Text = row.Cells[4].Value.ToString();
                student_phone.Text = row.Cells[5].Value.ToString();
                student_role.Text = row.Cells[6].Value.ToString();
                student_currentsubject1.Text = row.Cells[7].Value.ToString();
                student_currentsubject2.Text = row.Cells[8].Value.ToString();
                student_studiedsubject1.Text = row.Cells[9].Value.ToString();
                student_studiedsubject2.Text = row.Cells[10].Value.ToString();
                student_status.Text = row.Cells[11].Value.ToString();
            }
        }

        // Event handler for the "Add" button click event.
        // Validates the fields and adds a new student if the ID is not taken.
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

        // Event handler for the "Clear" button click event.
        // Clears all input fields.
        private void student_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Event handler for the "Update" button click event.
        // Validates the fields and updates the student record if the user confirms.
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

        // Event handler for the "Delete" button click event.
        // Validates the fields and deletes the student record if the user confirms.
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
