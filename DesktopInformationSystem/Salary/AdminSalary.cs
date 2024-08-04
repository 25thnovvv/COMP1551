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
    public partial class AdminSalary : UserControl
    {
        private readonly string connectionString = ConnectConfig.connection;

        public AdminSalary()
        {
            InitializeComponent();

            displayAdmins();

            disableFields();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            displayAdmins();

            disableFields();
        }

        public void disableFields()
        {
            salary_adminid.Enabled = false;
            salary_adminname.Enabled = false;
            salary_admingender.Enabled = false;
            salary_adminrole.Enabled = false;
        }

        public void displayAdmins()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string selectData = "SELECT admin_id, admin_name, admin_gender, admin_role, admin_worktype, admin_workinghours, salary, status FROM admins WHERE status = 'Active' AND delete_date IS NULL";
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
        private void UpdateSalary()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string updateData = "UPDATE admins SET salary = @salary, admin_worktype = @adminWorktype, admin_workinghours = @admin_Workinghours" +
                        ",update_date = @updateData WHERE admin_id = @adminID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@salary", salary_adminsalary.Text.Trim());
                        cmd.Parameters.AddWithValue("@adminWorktype", salary_adminworktype.Text.Trim());
                        cmd.Parameters.AddWithValue("@admin_Workinghours", salary_adminworkinghours.Text.Trim());
                        cmd.Parameters.AddWithValue("@updateData", DateTime.Today);
                        cmd.Parameters.AddWithValue("@adminID", salary_adminid.Text.Trim());

                        cmd.ExecuteNonQuery();
                        displayAdmins();
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
        private bool AreFieldsValid()
        {
            return !string.IsNullOrWhiteSpace(salary_adminid.Text) &&
                   !string.IsNullOrWhiteSpace(salary_adminname.Text) &&
                   !string.IsNullOrWhiteSpace(salary_admingender.Text) &&
                   !string.IsNullOrWhiteSpace(salary_adminrole.Text) &&
                   !string.IsNullOrWhiteSpace(salary_adminsalary.Text)&&
                   !string.IsNullOrWhiteSpace(salary_adminworktype.Text)&&
                   !string.IsNullOrWhiteSpace(salary_adminworkinghours.Text);
        }
        public void ClearFields()
        {
            salary_adminid.Text = "";
            salary_adminname.Text = "";
            salary_admingender.Text = "";
            salary_adminrole.Text = "";
            salary_adminworktype.SelectedIndex = -1;
            salary_adminworkinghours.Text = "";
            salary_adminsalary.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                salary_adminid.Text = row.Cells["admin_id"].Value.ToString();
                salary_adminname.Text = row.Cells["admin_name"].Value.ToString();
                salary_admingender.Text = row.Cells["admin_gender"].Value.ToString();
                salary_adminrole.Text = row.Cells["admin_role"].Value.ToString();
                salary_adminsalary.Text = row.Cells["salary"].Value.ToString();
                salary_adminworktype.Text = row.Cells["admin_worktype"].Value.ToString();
                salary_adminworkinghours.Text = row.Cells["admin_workinghours"].Value.ToString();
            }
        }

        private void salary_clearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void salary_updateBtn_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                var result = MessageBox.Show($"Are you sure you want to UPDATE teacher ID: {salary_adminid.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
