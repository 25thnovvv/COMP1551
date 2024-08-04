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
    public partial class Admin : UserControl
    {
        private readonly string connectionString = ConnectConfig.connection;

        public Admin()
        {
            InitializeComponent();
            DisplayAdminData();
        }

        private void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DisplayAdminData();
        }

        public void DisplayAdminData()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string selectData = "SELECT * FROM admins WHERE delete_date IS NULL";
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
        private void AddAdmin()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string insertData = "INSERT INTO admins " +
                        "(admin_id, admin_name, admin_gender, admin_email, admin_phone, admin_worktype, admin_workinghours, admin_role, salary, insert_date, status) " +
                        "VALUES (@adminID, @adminName, @adminGender, @adminEmail, @adminPhone, @adminWorktype, @adminWorkinghours, @adminRole, @salary, @insertDate, @status)";

                    using (SqlCommand cmd = new SqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@adminID", admin_id.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminName", admin_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminGender", admin_gender.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminEmail", admin_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminPhone", admin_phone.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminRole", admin_role.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminWorktype", admin_worktype.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminWorkinghours", admin_workinghours.Text.Trim());
                        cmd.Parameters.AddWithValue("@salary", 0);
                        cmd.Parameters.AddWithValue("@insertDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@status", admin_status.Text.Trim());

                        cmd.ExecuteNonQuery();
                        DisplayAdminData();
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
        private bool IsAdminIDTaken()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string checkEmID = "SELECT COUNT(*) FROM admins WHERE admin_id = @teID AND delete_date IS NULL";

                    using (SqlCommand checkEm = new SqlCommand(checkEmID, connect))
                    {
                        checkEm.Parameters.AddWithValue("@teID", admin_id.Text.Trim());
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
        private void UpdateAdmin()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string updateData = "UPDATE admins SET admin_name = @adminName, admin_gender = @adminGender, admin_email = @adminEmail, admin_phone = @adminPhone, admin_role = @adminRole, admin_worktype = @adminWorktype, admin_workinghours = @adminWorkinghours, update_date = @updateDate, status = @status WHERE admin_id = @adminID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
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

                        cmd.ExecuteNonQuery();
                        DisplayAdminData();
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
        private void DeleteAdmin()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string updateData = "UPDATE admins SET delete_date = @deleteDate WHERE admin_id = @adminID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@deleteDate", DateTime.Today);
                        cmd.Parameters.AddWithValue("@adminID", admin_id.Text.Trim());

                        cmd.ExecuteNonQuery();
                        DisplayAdminData();
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

        private void ClearFields()
        {
            admin_id.Clear();
            admin_name.Clear();
            admin_gender.SelectedIndex = -1;
            admin_email.Clear();
            admin_phone.Clear();
            admin_role.SelectedIndex = -1;
            admin_worktype.SelectedIndex = -1;
            admin_workinghours.Clear();
            admin_status.SelectedIndex = -1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                admin_id.Text = row.Cells["admin_id"].Value.ToString();
                admin_name.Text = row.Cells["admin_name"].Value.ToString();
                admin_gender.Text = row.Cells["admin_gender"].Value.ToString();
                admin_email.Text = row.Cells["admin_email"].Value.ToString();
                admin_phone.Text = row.Cells["admin_phone"].Value.ToString();
                admin_role.Text = row.Cells["admin_role"].Value.ToString();
                admin_worktype.Text = row.Cells["admin_worktype"].Value.ToString();
                admin_workinghours.Text = row.Cells["admin_workinghours"].Value.ToString();
                admin_status.Text = row.Cells["status"].Value.ToString();
            }
        }

        private void admin_addBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                if (IsAdminIDTaken())
                {
                    MessageBox.Show($"{admin_id.Text.Trim()} is already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    AddAdmin();
                }
            }
            else
            {
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void admin_updateBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                var result = MessageBox.Show($"Are you sure you want to UPDATE admin ID: {admin_id.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    UpdateAdmin();
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

        private void admin_deleteBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                var result = MessageBox.Show($"Are you sure you want to DELETE admin ID: {admin_id.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    DeleteAdmin();
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

        private void admin_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}