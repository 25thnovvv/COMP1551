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
    // TeacherUS is a UserControl that provides functionality for managing and displaying teacher data within the system.
    public partial class TeacherUS : UserControl
    {
        // Connection string for connecting to the database, retrieved from the configuration.
        private readonly string connectionString = ConnectConfig.connection;

        // Constructor initializes the component and sets up the initial display and state.
        public TeacherUS()
        {
            InitializeComponent(); // Configures the form’s controls and layout.
            DisplayTeacherData(); // Load and display teacher data in the DataGridView.
            disableFields(); // Disable input fields to make them read-only.
        }

        // RefreshData method updates the teacher data display on the UI thread.
        private void RefreshData()
        {
            if (InvokeRequired)
            {
                // If the method is called from a non-UI thread, invoke it on the UI thread.
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DisplayTeacherData(); // Reload teacher data.
            disableFields(); // Ensure input fields remain disabled.
        }

        // Displays teacher data by populating the DataGridView with data from the TeacherData source.
        public void DisplayTeacherData()
        {
            // Fetch teacher data from the data source.
            List<TeacherData> listData = TeacherData.GetTeacherListData();
            // Bind the fetched data to the DataGridView for display.
            dataGridView1.DataSource = listData;
        }

        // Disables all input fields related to teacher details, making them read-only.
        public void disableFields()
        {
            teacher_id.Enabled = false;
            teacher_name.Enabled = false;
            teacher_gender.Enabled = false;
            teacher_email.Enabled = false;
            teacher_phone.Enabled = false;
            teacher_role.Enabled = false;
            teacher_salary.Enabled = false;
            teacher_subject1.Enabled = false;
            teacher_subject2.Enabled = false;
            teacher_status.Enabled = false;
        }

        // Validates if all required input fields are filled with non-empty values.
        private bool AreFieldsValid()
        {
            // Check that none of the fields are null or whitespace.
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

        // Handles the cell click event in the DataGridView to populate input fields with the selected teacher's data.
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                // Get the selected row from the DataGridView.
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                // Populate the input fields with the data from the selected row.
                teacher_id.Text = row.Cells[1].Value.ToString();
                teacher_name.Text = row.Cells[2].Value.ToString();
                teacher_gender.Text = row.Cells[3].Value.ToString();
                teacher_email.Text = row.Cells[4].Value.ToString();
                teacher_phone.Text = row.Cells[5].Value.ToString();
                teacher_role.Text = row.Cells[6].Value.ToString();
                teacher_salary.Text = row.Cells[7].Value.ToString();
                teacher_subject1.Text = row.Cells[8].Value.ToString();
                teacher_subject2.Text = row.Cells[9].Value.ToString();
                teacher_status.Text = row.Cells[10].Value.ToString();
            }
        }
    }
}
