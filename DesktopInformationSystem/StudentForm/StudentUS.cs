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
    // StudentUS is a UserControl that manages and displays student data within the system.
    public partial class StudentUS : UserControl
    {
        // Connection string for connecting to the database, retrieved from the configuration.
        private readonly string connectionString = ConnectConfig.connection;

        // Constructor initializes the component and displays student data.
        public StudentUS()
        {
            InitializeComponent(); // Sets up the form’s controls and layout.

            DisplayStudentData(); // Load and display student data.
            disableFields(); // Disable input fields to make them read-only.
        }

        // RefreshData method ensures that the student data display is updated on the UI thread.
        private void RefreshData()
        {
            if (InvokeRequired)
            {
                // If the method is called from a non-UI thread, invoke it on the UI thread.
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DisplayStudentData(); // Reload the student data.
            disableFields(); // Ensure input fields remain disabled.
        }

        // Disables all input fields related to student details, making them read-only.
        public void disableFields()
        {
            student_id.Enabled = false;
            student_name.Enabled = false;
            student_gender.Enabled = false;
            student_email.Enabled = false;
            student_phone.Enabled = false;
            student_role.Enabled = false;
            student_status.Enabled = false;
            student_currentsubject1.Enabled = false;
            student_currentsubject2.Enabled = false;
            student_studiedsubject1.Enabled = false;
            student_studiedsubject2.Enabled = false;
        }

        // Displays student data by populating the DataGridView with data from the StudentData source.
        public void DisplayStudentData()
        {
            // Fetch student data from the data source.
            List<StudentData> listData = StudentData.GetStudentListData();
            // Bind the fetched data to the DataGridView for display.
            student_studentData.DataSource = listData;
        }

        // Validates if all required input fields are filled with non-empty values.
        private bool AreFieldsValid()
        {
            // Check that none of the fields are null or whitespace.
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

        // Handles the cell click event in the DataGridView to populate input fields with the selected student's data.
        private void student_studentData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                // Get the selected row from the DataGridView.
                DataGridViewRow row = student_studentData.Rows[e.RowIndex];
                // Populate the input fields with the data from the selected row.
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
    }
}
