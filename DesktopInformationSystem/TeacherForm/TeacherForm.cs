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
    // TeacherForm is a Windows Form that provides an interface for teacher-related actions.
    public partial class TeacherForm : Form
    {
        // Constructor initializes the form's components.
        public TeacherForm()
        {
            InitializeComponent(); // Configures the form's controls and layout.
        }

        // Event handler for the logout button click event.
        private void logout_btn_Click(object sender, EventArgs e)
        {
            // Prompt the user with a confirmation message before logging out.
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's response.
            if (check == DialogResult.Yes)
            {
                // If the user confirms, create an instance of the Login form and show it.
                Login lForm = new Login();
                lForm.Show();

                // Hide the current TeacherForm instance.
                this.Hide();
            }
        }
    }
}
