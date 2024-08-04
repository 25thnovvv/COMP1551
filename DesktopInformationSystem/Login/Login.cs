using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DesktopInformationSystem
{
    public partial class Login : Form
    {
        SqlConnection connect = new SqlConnection(ConnectConfig.connection);
        public Login()
        {
            InitializeComponent();
        }

        private void login_registerhere_Click(object sender, EventArgs e)
        {
            Signup sForm = new Signup();
            sForm.Show();
            this.Hide();
        }

        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (login_showpass.Checked)
            {
                login_password.PasswordChar = '\0';
            }
            else
            {
                login_password.PasswordChar = '*';
            }
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();

                        String selectData = "SELECT * FROM login WHERE username = @username AND password = @pass AND role = @role";
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@username", login_username.Text);
                            cmd.Parameters.AddWithValue("@pass", login_password.Text);
                            cmd.Parameters.AddWithValue("@role", login_role.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Logged In successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                string role = table.Rows[0]["role"].ToString();

                                if (role == "Admin")
                                {
                                    MainForm aForm = new MainForm();
                                    aForm.Show();
                                }
                                else if (role == "Teacher")
                                {
                                    TeacherForm tForm = new TeacherForm();
                                    tForm.Show();
                                }
                                else if (role == "Student")
                                {
                                    StudentForm sForm = new StudentForm();
                                    sForm.Show();
                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Connecting: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }
    }
}