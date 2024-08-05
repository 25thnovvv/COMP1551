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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void Student_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = true;
            teacher1.Visible = false;
            salary1.Visible = false;
            admin1.Visible = false;
            adminSalary1.Visible = false;
        }

        private void Teachers_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = false;
            salary1.Visible = false;
            teacher1.Visible = true;
            admin1.Visible = false;
            adminSalary1.Visible = false;
        }

        private void Admin_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = false;
            teacher1.Visible = false;
            salary1.Visible = false;
            admin1.Visible = true;
            adminSalary1.Visible = false;
        }

        private void Teachersalary_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = false;
            teacher1.Visible = false;
            salary1.Visible = true;
            admin1.Visible = false;
            adminSalary1.Visible = false; 
        }

        private void Adminsalary_btn_Click(object sender, EventArgs e)
        {
            student1.Visible = false;
            teacher1.Visible = false;
            salary1.Visible = false;
            admin1.Visible = false;
            adminSalary1.Visible = true;
        }

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
    }
}
