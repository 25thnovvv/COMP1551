using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopInformationSystem
{
    // The MainForm class serves as the primary interface for navigating the desktop information system.
    public partial class MainForm : Form
    {
        // Constructor for the MainForm class, initializes the form components.
        public MainForm()
        {
            InitializeComponent();
        }

        // Event handler for the "Student" button click.
        // It shows the student data control and hides other controls.
        private void Student_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = true;
            teacher1.Visible = false;
            salary1.Visible = false;
            admin1.Visible = false;
            adminSalary1.Visible = false;
            viewall1.Visible = false;

            // Calls a method to display student data.
            student1.DisplayStudentData();
        }

        // Event handler for the "Teacher" button click.
        // It shows the teacher data control and hides other controls.
        private void Teachers_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = false;
            salary1.Visible = false;
            teacher1.Visible = true;
            admin1.Visible = false;
            adminSalary1.Visible = false;
            viewall1.Visible = false;

            // Calls a method to display teacher data.
            teacher1.DisplayTeacherData();
        }

        // Event handler for the "Admin" button click.
        // It shows the admin data control and hides other controls.
        private void Admin_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = false;
            teacher1.Visible = false;
            salary1.Visible = false;
            admin1.Visible = true;
            adminSalary1.Visible = false;
            viewall1.Visible = false;

            // Calls a method to display admin data.
            admin1.DisplayAdminData();
        }

        // Event handler for the "Teacher Salary" button click.
        // It shows the teacher salary control and hides other controls.
        private void Teachersalary_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = false;
            teacher1.Visible = false;
            salary1.Visible = true;
            admin1.Visible = false;
            adminSalary1.Visible = false;
            viewall1.Visible = false;

            // Calls a method to display teacher salary data.
            salary1.displayTeachers();
        }

        // Event handler for the "Admin Salary" button click.
        // It shows the admin salary control and hides other controls.
        private void Adminsalary_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = false;
            teacher1.Visible = false;
            salary1.Visible = false;
            admin1.Visible = false;
            adminSalary1.Visible = true;
            viewall1.Visible = false;

            // Calls a method to display admin salary data.
            adminSalary1.displayAdmins();
        }

        // Event handler for the "Logout" button click.
        // It prompts the user to confirm if they want to logout and, if confirmed, returns to the login form.
        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                Login lForm = new Login();
                lForm.Show();
                this.Hide();
            }
        }

        // Event handler for the "View All" button click.
        // It shows the view all data control and hides other controls.
        private void Viewall_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = false;
            teacher1.Visible = false;
            salary1.Visible = false;
            admin1.Visible = false;
            adminSalary1.Visible = false;
            viewall1.Visible = true;
        }
    }
}
