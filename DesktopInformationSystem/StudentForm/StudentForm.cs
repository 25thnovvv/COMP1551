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
    // StudentForm is a Form that represents the main interface for student-related functionalities.
    public partial class StudentForm : Form
    {
        // Constructor initializes the components of the form.
        public StudentForm()
        {
            InitializeComponent(); // Call the method that sets up the form's controls and layout.
        }

        // Event handler for the logout button click event.
        private void logout_btn_Click(object sender, EventArgs e)
        {
            // Display a confirmation message box asking if the user really wants to log out.
            DialogResult check = MessageBox.Show(
                "Are you sure you want to logout?", // Message text.
                "Confirmation Message", // Title of the message box.
                MessageBoxButtons.YesNo, // Buttons displayed on the message box.
                MessageBoxIcon.Question); // Icon displayed on the message box.

            // Check if the user clicked "Yes" in the confirmation dialog.
            if (check == DialogResult.Yes)
            {
                // Create a new instance of the Login form.
                Login lForm = new Login();
                // Show the Login form to the user.
                lForm.Show();
                // Hide the current StudentForm from view.
                this.Hide();
            }
        }
    }
}
