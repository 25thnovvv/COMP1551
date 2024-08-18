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

namespace DesktopInformationSystem
{
    // The Admin class represents the UserControl for managing admin-related data within the desktop information system.
    public partial class Admin : UserControl
    {
        // Connection string to the SQL database, used for database operations.
        private readonly string connectionString = ConnectConfig.connection;

        // Constructor for the Admin class, initializes the UserControl components and displays admin data.
        public Admin()
        {
            InitializeComponent();
            DisplayAdminData();
        }

        // Refreshes the data displayed in the DataGridView by reloading the admin data.
        private void RefreshData()
        {
            // If the method is called from a different thread, invoke it on the UI thread.
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DisplayAdminData();
        }

        // Displays the admin data by fetching it from the database and binding it to the DataGridView.
        public void DisplayAdminData()
        {
            // Fetches a list of admin data using a helper method and binds it to the DataGridView.
            List<AdminData> listData = AdminData.GetAdminListData();
            dataGridView1.DataSource = listData;
        }

        // Adds a new admin to the database using the data entered in the form fields.
        private void AddAdmin()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    // SQL query to insert a new admin record into the database.
                    string insertData = "INSERT INTO admins " +
                        "(admin_id, admin_name, admin_gender, admin_email, admin_phone, admin_worktype, admin_workinghours, admin_role, salary, insert_date, status) " +
                        "VALUES (@adminID, @adminName, @adminGender, @adminEmail, @adminPhone, @adminWorktype, @adminWorkinghours, @adminRole, @salary, @insertDate, @status)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        // Parameters are added to avoid SQL injection and properly format the query.
                        cmd.Parameters.AddWithValue("@adminID", admin_id.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminName", admin_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminGender", admin_gender.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminEmail", admin_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminPhone", admin_phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminRole", admin_role.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminWorktype", admin_worktype.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminWorkinghours", admin_workinghours.Text.Trim());
                        cmd.Parameters.AddWithValue("@salary", 0);  // Default salary is set to 0.
                        cmd.Parameters.AddWithValue("@insertDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@status", admin_status.Text.Trim());

                        // Executes the insert query.
                        cmd.ExecuteNonQuery();

                        // Refreshes the admin data displayed in the DataGridView.
                        DisplayAdminData();

                        // Displays a success message to the user.
                        MessageBox.Show("Added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clears the form fields after the admin is added.
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                // Displays an error message if there is an exception during the operation.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Checks if the entered admin ID already exists in the database.
        private bool IsAdminIDTaken()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    // SQL query to check if an admin with the entered ID already exists and is not marked as deleted.
                    string checkEmID = "SELECT COUNT(*) FROM admins WHERE admin_id = @teID AND delete_date IS NULL";

                    using (SqlCommand checkEm = new SqlCommand(checkEmID, connect))
                    {
                        checkEm.Parameters.AddWithValue("@teID", admin_id.Text.Trim());

                        // Executes the query and returns true if the ID is taken, false otherwise.
                        int count = (int)checkEm.ExecuteScalar();
                        return count >= 1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Displays an error message if there is an exception during the operation.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Updates an existing admin record in the database with the data entered in the form fields.
        private void UpdateAdmin()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    // SQL query to update an existing admin record in the database.
                    string updateData = "UPDATE admins SET admin_name = @adminName, admin_gender = @adminGender, admin_email = @adminEmail, admin_phone = @adminPhone, admin_role = @adminRole, admin_worktype = @adminWorktype, admin_workinghours = @adminWorkinghours, update_date = @updateDate, status = @status WHERE admin_id = @adminID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        // Parameters are added to avoid SQL injection and properly format the query.
                        cmd.Parameters.AddWithValue("@adminName", admin_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminGender", admin_gender.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminEmail", admin_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminPhone", admin_phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminRole", admin_role.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminWorktype", admin_worktype.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminWorkinghours", admin_workinghours.Text.Trim());
                        cmd.Parameters.AddWithValue("@updateDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@status", admin_status.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminID", admin_id.Text.Trim());

                        // Executes the update query.
                        cmd.ExecuteNonQuery();

                        // Refreshes the admin data displayed in the DataGridView.
                        DisplayAdminData();

                        // Displays a success message to the user.
                        MessageBox.Show("Updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clears the form fields after the admin is updated.
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                // Displays an error message if there is an exception during the operation.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Marks an admin record as deleted by setting the delete date in the database.
        private void DeleteAdmin()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    // SQL query to mark an admin record as deleted by setting the delete date.
                    string updateData = "UPDATE admins SET delete_date = @deleteDate WHERE admin_id = @adminID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        // Parameters are added to avoid SQL injection and properly format the query.
                        cmd.Parameters.AddWithValue("@deleteDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@adminID", admin_id.Text.Trim());

                        // Executes the update query.
                        cmd.ExecuteNonQuery();

                        // Refreshes the admin data displayed in the DataGridView.
                        DisplayAdminData();

                        // Displays a success message to the user.
                        MessageBox.Show("Deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clears the form fields after the admin is deleted.
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                // Displays an error message if there is an exception during the operation.
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Validates the form fields to ensure all required fields are filled.
        private bool AreFieldsValid()
        {
            return !string.IsNullOrWhiteSpace(admin_id.Text) &&
                   !string.IsNullOrWhiteSpace(admin_name.Text) &&
                   !string.IsNullOrWhiteSpace(admin_gender.Text) &&
                   !string.IsNullOrWhiteSpace(admin_email.Text) &&
                   !string.IsNullOrWhiteSpace(admin_phone.Text) &&
                   !string.IsNullOrWhiteSpace(admin_role.Text) &&
                   !string.IsNullOrWhiteSpace(admin_worktype.Text) &&
                   !string.IsNullOrWhiteSpace(admin_workinghours.Text) &&
                   !string.IsNullOrWhiteSpace(admin_status.Text);
        }

        // Clears all the input fields in the form.
        private void ClearFields()
        {
            admin_id.Clear();
            admin_name.Clear();
            admin_gender.SelectedIndex = -1;  // Resets the dropdown selection.
            admin_email.Clear();
            admin_phone.Clear();
            admin_role.SelectedIndex = -1;  // Resets the dropdown selection.
            admin_worktype.SelectedIndex = -1;  // Resets the dropdown selection.
            admin_workinghours.Clear();
            admin_status.SelectedIndex = -1;  // Resets the dropdown selection.
        }

        // Event handler for when a cell in the DataGridView is clicked.
        // It populates the form fields with the data from the selected row.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Ensures the clicked cell is not a header.
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populates the form fields with the data from the selected row.
                admin_id.Text = row.Cells[1].Value.ToString();
                admin_name.Text = row.Cells[2].Value.ToString();
                admin_gender.Text = row.Cells[3].Value.ToString();
                admin_email.Text = row.Cells[4].Value.ToString();
                admin_phone.Text = row.Cells[5].Value.ToString();
                admin_role.Text = row.Cells[6].Value.ToString();
                admin_worktype.Text = row.Cells[8].Value.ToString();
                admin_workinghours.Text = row.Cells[9].Value.ToString();
                admin_status.Text = row.Cells[10].Value.ToString();
            }
        }

        // Event handler for the "Add" button click event.
        // Adds a new admin if all fields are valid and the admin ID is not already taken.
        private void admin_addBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())  // Checks if all required fields are filled.
            {
                if (IsAdminIDTaken())  // Checks if the admin ID is already taken.
                {
                    // Displays an error message if the admin ID is already taken.
                    MessageBox.Show($"{admin_id.Text.Trim()} is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AddAdmin();  // Adds the new admin if the ID is not taken.
                }
            }
            else
            {
                // Displays an error message if any required fields are empty.
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the "Update" button click event.
        // Updates the selected admin record if all fields are valid and the user confirms the action.
        private void admin_updateBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())  // Checks if all required fields are filled.
            {
                // Asks for confirmation before updating the admin record.
                var result = MessageBox.Show($"Are you sure you want to UPDATE admin ID: {admin_id.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)  // If the user confirms, the admin record is updated.
                {
                    UpdateAdmin();
                }
                else
                {
                    // Displays a message if the update action is canceled.
                    MessageBox.Show("Cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Displays an error message if any required fields are empty.
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the "Delete" button click event.
        // Deletes the selected admin record if all fields are valid and the user confirms the action.
        private void admin_deleteBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())  // Checks if all required fields are filled.
            {
                // Asks for confirmation before deleting the admin record.
                var result = MessageBox.Show($"Are you sure you want to DELETE admin ID: {admin_id.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)  // If the user confirms, the admin record is deleted.
                {
                    DeleteAdmin();
                }
                else
                {
                    // Displays a message if the delete action is canceled.
                    MessageBox.Show("Cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // Displays an error message if any required fields are empty.
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handler for the "Clear" button click event.
        // Clears all the input fields in the form.
        private void admin_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
