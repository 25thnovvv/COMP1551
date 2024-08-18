using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    // AdminSalary class is a UserControl that handles the display and update of admin salary data.
    public partial class AdminSalary : UserControl
    {
        // Connection string for database access, retrieved from configuration.
        private readonly string connectionString = ConnectConfig.connection;

        // Constructor initializes the component and displays admin data.
        public AdminSalary()
        {
            InitializeComponent();

            displayAdmins();  // Load admin data into the DataGridView.

            disableFields();  // Disable input fields initially.
        }

        // Refreshes the admin data and disables fields (thread-safe).
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            displayAdmins();  // Reload admin data.
            disableFields();  // Ensure input fields are disabled.
        }

        // Disables all input fields related to admin details.
        public void disableFields()
        {
            salary_adminid.Enabled = false;
            salary_adminname.Enabled = false;
            salary_admingender.Enabled = false;
            salary_adminemail.Enabled = false;
            salary_adminphone.Enabled = false;
            salary_adminrole.Enabled = false;
        }

        // Populates the DataGridView with a list of admin salary data.
        public void displayAdmins()
        {
            List<AdminSalaryData> listData = AdminSalaryData.salaryAdminListData();
            dataGridView1.DataSource = listData;
        }

        // Updates the salary and other related data for a specific admin in the database.
        private void UpdateSalary()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open(); // Open the database connection.

                    // SQL query to update admin salary and additional fields.
                    string updateData = "UPDATE admins SET salary = @salary, admin_worktype = @adminWorktype, admin_workinghours = @admin_Workinghours" +
                        ", update_date = @updateData WHERE admin_id = @adminID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        // Add parameters to the SQL command.
                        cmd.Parameters.AddWithValue("@salary", salary_adminsalary.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminWorktype", salary_adminworktype.Text.Trim());
                        cmd.Parameters.AddWithValue("@admin_Workinghours", salary_adminworkinghours.Text.Trim());
                        cmd.Parameters.AddWithValue("@updateData", DateTime.Today);
                        cmd.Parameters.AddWithValue("@adminID", salary_adminid.Text.Trim());

                        cmd.ExecuteNonQuery(); // Execute the SQL command.
                        displayAdmins(); // Refresh the DataGridView.
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

        // Validates that all required fields are filled.
        private bool AreFieldsValid()
        {
            return !string.IsNullOrWhiteSpace(salary_adminid.Text) &&
                   !string.IsNullOrWhiteSpace(salary_adminname.Text) &&
                   !string.IsNullOrWhiteSpace(salary_admingender.Text) &&
                   !string.IsNullOrWhiteSpace(salary_adminemail.Text) &&
                   !string.IsNullOrWhiteSpace(salary_adminphone.Text) &&
                   !string.IsNullOrWhiteSpace(salary_adminrole.Text) &&
                   !string.IsNullOrWhiteSpace(salary_adminsalary.Text) &&
                   !string.IsNullOrWhiteSpace(salary_adminworktype.Text) &&
                   !string.IsNullOrWhiteSpace(salary_adminworkinghours.Text);
        }

        // Clears all input fields.
        public void ClearFields()
        {
            salary_adminid.Text = "";
            salary_adminname.Text = "";
            salary_admingender.Text = "";
            salary_adminemail.Text = "";
            salary_adminphone.Text = "";
            salary_adminrole.Text = "";
            salary_adminworktype.SelectedIndex = -1;
            salary_adminworkinghours.Text = "";
            salary_adminsalary.Text = "";
        }

        // Handles cell click events in the DataGridView to populate input fields with selected admin data.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                salary_adminid.Text = row.Cells[0].Value.ToString();
                salary_adminname.Text = row.Cells[1].Value.ToString();
                salary_admingender.Text = row.Cells[2].Value.ToString();
                salary_adminemail.Text = row.Cells[3].Value.ToString();
                salary_adminphone.Text = row.Cells[4].Value.ToString();
                salary_adminrole.Text = row.Cells[5].Value.ToString();
                salary_adminworktype.Text = row.Cells[6].Value.ToString();
                salary_adminworkinghours.Text = row.Cells[7].Value.ToString();
                salary_adminsalary.Text = row.Cells[8].Value.ToString();
            }
        }

        // Clears input fields when the "Clear" button is clicked.
        private void salary_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Validates fields and updates admin salary when the "Update" button is clicked.
        private void salary_updateBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                var result = MessageBox.Show($"Are you sure you want to UPDATE admin ID: {salary_adminid.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    UpdateSalary();
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
