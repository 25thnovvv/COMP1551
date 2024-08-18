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
    // The Login class is a form that handles the user login process for the application.
    public partial class Login : Form
    {
        // Create a connection to the SQL database using a connection string from ConnectConfig.
        SqlConnection connect = new SqlConnection(ConnectConfig.connection);

        // Constructor for the Login form, initializes the form components.
        public Login()
        {
            InitializeComponent();
        }

        // Event handler for when the "Register Here" link is clicked.
        // This opens the Signup form for new user registration and hides the current login form.
        private void login_registerhere_Click(object sender, EventArgs e)
        {
            Signup sForm = new Signup();
            sForm.Show();
            this.Hide();
        }

        // Event handler for the close button, exits the application when clicked.
        private void login_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Event handler for the "Show Password" checkbox.
        // Toggles the visibility of the password characters in the password field.
        private void login_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (login_showpass.Checked)
            {
                login_password.PasswordChar = '\0'; // Shows the password characters.
            }
            else
            {
                login_password.PasswordChar = '*'; // Hides the password characters.
            }
        }

        // Event handler for the login button.
        // Validates user input, connects to the database, and verifies the user's credentials.
        private void login_btn_Click(object sender, EventArgs e)
        {
            // Check if username or password fields are empty, display an error message if so.
            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // If the connection to the database is not already open, attempt to open it.
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open(); // Open the database connection.

                        // SQL query to select user data based on the provided username, password, and role.
                        String selectData = "SELECT * FROM login WHERE username = @username AND password = @pass AND role = @role";

                        // Using statement ensures that the SqlCommand is disposed of after use.
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            // Add parameters to the SQL query to prevent SQL injection.
                            cmd.Parameters.AddWithValue("@username", login_username.Text);
                            cmd.Parameters.AddWithValue("@pass", login_password.Text);
                            cmd.Parameters.AddWithValue("@role", login_role.Text);

                            // SqlDataAdapter is used to fill a DataTable with the results of the SQL query.
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            // Check if the query returned any results (i.e., if the credentials are correct).
                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Logged In successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Get the user's role from the returned data.
                                string role = table.Rows[0]["role"].ToString();

                                // Open the appropriate form based on the user's role.
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

                                this.Hide(); // Hide the login form.
                            }
                            else
                            {
                                // If no matching data is found, display an error message.
                                MessageBox.Show("Incorrect Username/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Catch any exceptions that occur during the connection or query execution and display an error message.
                        MessageBox.Show("Error Connecting: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close(); // Ensure the database connection is closed after the operation.
                    }
                }
            }
        }
    }
}
