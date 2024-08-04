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
    public partial class Salary : UserControl
    {
        private readonly string connectionString = ConnectConfig.connection;

        public Salary()
        {
            InitializeComponent();

            displayTeachers();

            disableFields();
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            displayTeachers();

            disableFields();
        }

        public void disableFields()
        {
            salary_teacherid.Enabled = false;
            salary_teachername.Enabled = false;
            salary_teachergender.Enabled = false;
            salary_teacherrole.Enabled = false;
        }

        public void displayTeachers()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    string selectData = "SELECT teacher_id, teacher_name, teacher_gender, teacher_role, salary, status FROM teachers WHERE status = 'Active' AND delete_date IS NULL";
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
                    string updateData = "UPDATE teachers SET salary = @salary, update_date = @updateData WHERE teacher_id = @teacherID";

                    using (SqlCommand cmd = new SqlCommand(updateData, connect))
                    {
                        cmd.Parameters.AddWithValue("@salary", salary_teachersalary.Text.Trim());
                        cmd.Parameters.AddWithValue("@updateData", DateTime.Today);
                        cmd.Parameters.AddWithValue("@teacherID", salary_teacherid.Text.Trim());

                        cmd.ExecuteNonQuery();
                        displayTeachers();
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
            return !string.IsNullOrWhiteSpace(salary_teacherid.Text) &&
                   !string.IsNullOrWhiteSpace(salary_teachername.Text) &&
                   !string.IsNullOrWhiteSpace(salary_teachergender.Text) &&
                   !string.IsNullOrWhiteSpace(salary_teacherrole.Text) &&
                   !string.IsNullOrWhiteSpace(salary_teachersalary.Text);
 
        }

        public void ClearFields()
        {
            salary_teacherid.Text = "";
            salary_teachername.Text = "";
            salary_teachergender.Text = "";
            salary_teacherrole.Text = "";
            salary_teachersalary.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                salary_teacherid.Text = row.Cells["teacher_id"].Value.ToString();
                salary_teachername.Text = row.Cells["teacher_name"].Value.ToString();
                salary_teachergender.Text = row.Cells["teacher_gender"].Value.ToString();
                salary_teacherrole.Text = row.Cells["teacher_role"].Value.ToString();
                salary_teachersalary.Text = row.Cells["salary"].Value.ToString();   
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
                var result = MessageBox.Show($"Are you sure you want to UPDATE teacher ID: {salary_teacherid.Text.Trim()}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

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
