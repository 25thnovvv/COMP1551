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
    // The Signup class handles user registration for the application.
    public partial class Signup : Form
    {
        // Create a connection to the SQL database using a connection string from ConnectConfig.
        SqlConnection connect = new SqlConnection(ConnectConfig.connection);

        // Constructor for the Signup form, initializes the form components.
        public Signup()
        {
            InitializeComponent();
        }

        // Event handler for when the "Login Here" link is clicked.
        // This opens the Login form and hides the current Signup form.
        private void signup_loginhere_Click(object sender, EventArgs e)
        {
            Login lForm = new Login();
            lForm.Show();
            this.Hide();
        }

        // Event handler for the close button, exits the application when clicked.
        private void signup_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Event handler for the signup button.
        // Validates user input, checks if the username already exists in the database,
        // and if not, inserts the new user data into the database.
        private void signup_btn_Click(object sender, EventArgs e)
        {
            // Check if any of the required fields are empty, display an error message if so.
            if (signup_email.Text == "" || signup_username.Text == "" || signup_password.Text == "")
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

                        // SQL query to check if the username already exists in the login table.
                        String checkUsername = "SELECT * FROM login WHERE username = '"
                            + signup_username.Text.Trim() + "'";

                        // Using statement ensures that the SqlCommand is disposed of after use.
                        using (SqlCommand checkUser = new SqlCommand(checkUsername, connect))
                        {
                            // SqlDataAdapter is used to fill a DataTable with the results of the SQL query.
                            SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            // If a matching username is found, display an error message.
                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show(signup_username.Text + " already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                // SQL query to insert new user data into the login table.
                                string insertData = "INSERT INTO login (email, username, password, role, date_created) " +
                                    "VALUES(@email, @username, @pass, @role, @date)";

                                // Get the current date to store in the date_created field.
                                DateTime date = DateTime.Today;

                                // Using statement ensures that the SqlCommand is disposed of after use.
                                using (SqlCommand cmd = new SqlCommand(insertData, connect))
                                {
                                    // Add parameters to the SQL query to prevent SQL injection.
                                    cmd.Parameters.AddWithValue("@email", signup_email.Text.Trim());
                                    cmd.Parameters.AddWithValue("@username", signup_username.Text.Trim());
                                    cmd.Parameters.AddWithValue("@pass", signup_password.Text.Trim());
                                    cmd.Parameters.AddWithValue("@role", signup_role.Text.Trim());
                                    cmd.Parameters.AddWithValue("@date", date);

                                    // Execute the SQL query to insert the new user data.
                                    cmd.ExecuteNonQuery();

                                    // Display a success message and open the Login form.
                                    MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    Login lForm = new Login();
                                    lForm.Show();
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Catch any exceptions that occur during the connection or query execution and display an error message.
                        MessageBox.Show("Error connecting Database: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connect.Close(); // Ensure the database connection is closed after the operation.
                    }
                }
            }
        }

        // Event handler for the "Show Password" checkbox.
        // Toggles the visibility of the password characters in the password field.
        private void signup_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (signup_showpass.Checked)
            {
                signup_password.PasswordChar = '\0'; // Shows the password characters.
            }
            else
            {
                signup_password.PasswordChar = '*'; // Hides the password characters.
            }
        }
    }
}
