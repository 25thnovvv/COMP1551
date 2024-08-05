using DesktopInformationSystem;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopInformationSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
















/*else if (!signup_email.Text.EndsWith("@gmail.com"))
{
    MessageBox.Show("Please use a @gmail.com email address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
}*/

/*-------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

/*private bool IsEmailValid(string email)
{
    return email.EndsWith("@gmail.com");
}

if (!IsEmailValid(teacher_email.Text.Trim()))
{
    MessageBox.Show("Please use a @gmail.com email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    return;
}*/

/*-------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

/*teacher1.DisplayTeacherData();
admin1.DisplayAdminData();
salary1.displayTeachers();
adminSalary1.displayAdmins();*/

/*-------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
/*public void DisplayTeacherData(string sortBy = "")
  {
    try
    {
        using (SqlConnection connect = new SqlConnection(connectionString))
        {
            connect.Open();
            string selectData = "SELECT * FROM teachers WHERE delete_date IS NULL";

            if (!string.IsNullOrEmpty(sortBy))
            {
                selectData += $" ORDER BY {sortBy}";
            }

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


{
    string sortBy = cb_sort.SelectedItem.ToString();

    switch (sortBy)
    {
        case "ID":
            DisplayTeacherData("teacher_id");
            break;
        case "Name":
            DisplayTeacherData("teacher_name");
            break;
        default:
            DisplayTeacherData();
            break;
    }
}*/