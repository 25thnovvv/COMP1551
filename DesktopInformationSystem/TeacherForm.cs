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
    public partial class TeacherForm : Form
    {
        public TeacherForm()
        {
            InitializeComponent();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            {
                DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    Login lForm = new Login();
                    lForm.Show();
                    this.Hide();
                }
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Teachers_btn_Click(object sender, EventArgs e)
        {
            salary1.Visible = false;
            teacher1.Visible = true;
        }

        private void Teachersalary_btn_Click(object sender, EventArgs e)
        {
            teacher1.Visible = false;
            salary1.Visible = true;
        }
    }
}
