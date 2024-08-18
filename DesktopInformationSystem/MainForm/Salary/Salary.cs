using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace DesktopInformationSystem
{
    // The Salary class is a UserControl that manages teacher salary information in the system.
    public partial class Salary : UserControl
    {
        // Connection string for connecting to the SQL database.
        private readonly string connectionString = ConnectConfig.connection;

        // Constructor for initializing the Salary UserControl.
        public Salary()
        {
            InitializeComponent(); // Initialize the form's components.
            displayTeachers(); // Load and display the teachers' salary data.
            disableFields(); // Disable input fields for viewing purposes only.
        }

        // Refreshes the data and disables input fields if required.
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData); // Ensure that the method is invoked on the UI thread.
                return;
            }
            displayTeachers(); // Refresh the displayed teacher data.
            disableFields(); // Disable input fields.
        }

        // Disables input fields to make them read-only.
        public void disableFields()
        {
            salary_teacherid.Enabled = false;
            salary_teachername.Enabled = false;
            salary_teachergender.Enabled = false;
            salary_teacheremail.Enabled = false;
            salary_teacherphone.Enabled = false;
            salary_teacherrole.Enabled = false;
        }

        // Retrieves and displays the list of teachers and their salaries.
        public void displayTeachers()
        {
            List<SalaryData> listData = SalaryData.SalaryTeacherListData(); // Fetch the teacher salary data.
            dataGridView1.DataSource = listData; // Bind the data to the DataGridView.
        }

        // Updates the salary of a teacher in the database.
        private void UpdateSalary()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open(); // Open the database connection.
                    string updateData = "UPDATE teachers SET salary = @salary, update_date = @updateData WHERE teacher_id = @teacherID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        // Set parameters for the SQL command.
                        cmd.Parameters.AddWithValue("@salary", salary_teachersalary.Text.Trim());
                        cmd.Parameters.AddWithValue("@updateData", DateTime.Today);
                        cmd.Parameters.AddWithValue("@teacherID", salary_teacherid.Text.Trim());

                        cmd.ExecuteNonQuery(); // Execute the update command.
                        displayTeachers(); // Refresh the teacher data display.
                        MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields(); // Clear input fields.
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validates if all input fields are filled out.
        private bool AreFieldsValid()
        {
            return !string.IsNullOrWhiteSpace(salary_teacherid.Text) &&
                   !string.IsNullOrWhiteSpace(salary_teachername.Text) &&
                   !string.IsNullOrWhiteSpace(salary_teachergender.Text) &&
                   !string.IsNullOrWhiteSpace(salary_teacheremail.Text) &&
                   !string.IsNullOrWhiteSpace(salary_teacherphone.Text) &&
                   !string.IsNullOrWhiteSpace(salary_teacherrole.Text) &&
                   !string.IsNullOrWhiteSpace(salary_teachersalary.Text);
        }

        // Clears all input fields.
        public void ClearFields()
        {
            salary_teacherid.Text = "";
            salary_teachername.Text = "";
            salary_teachergender.Text = "";
            salary_teacheremail.Text = "";
            salary_teacherphone.Text = "";
            salary_teacherrole.Text = "";
            salary_teachersalary.Text = "";
        }

        // Handles the cell click event of the DataGridView to populate fields with selected teacher data.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Populate the fields with the selected row data.
                salary_teacherid.Text = row.Cells[0].Value.ToString();
                salary_teachername.Text = row.Cells[1].Value.ToString();
                salary_teachergender.Text = row.Cells[2].Value.ToString();
                salary_teacheremail.Text = row.Cells[3].Value.ToString();
                salary_teacherphone.Text = row.Cells[4].Value.ToString();
                salary_teacherrole.Text = row.Cells[5].Value.ToString();
                salary_teachersalary.Text = row.Cells[6].Value.ToString();
            }
        }

        // Clears all input fields when the clear button is clicked.
        private void salary_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Updates the salary when the update button is clicked, after confirming the operation.
        private void salary_updateBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                var result = MessageBox.Show($"Are you sure you want to UPDATE teacher ID: {salary_teacherid.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    UpdateSalary(); // Call UpdateSalary method.
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
