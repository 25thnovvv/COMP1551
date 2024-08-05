using DesktopInformationSystem;
using System;
using System.Collections.Generic;
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