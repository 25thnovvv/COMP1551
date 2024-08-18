using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DesktopInformationSystem
{
    // AdminSalaryData class inherits from the Person class.
    class AdminSalaryData : Person
    {
        // Properties specific to the AdminSalaryData class.
        public string AdminID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string AdminWorktype { get; set; }
        public string AdminWorkinghours { get; set; }
        public int Salary { get; set; }
        public string Status { get; set; }

        // Connection string for the database.
        private static readonly string ConnectionString = ConnectConfig.connection;

        // Default constructor.
        public AdminSalaryData()
        {
        }

        // Parameterized constructor for initializing an instance with specific values.
        public AdminSalaryData(string name, string gender, string email, string phone, string role, string status, string adminID, string adminWorktype, string adminWorkinghours, int salary)
            : base(name, gender, email, phone, role, status)
        {
            // Assigning values to the properties.
            AdminID = adminID;
            AdminWorktype = adminWorktype;
            AdminWorkinghours = adminWorkinghours;
            Salary = salary;
        }

        // Static method to retrieve a list of active admin salary data from the database.
        public static List<AdminSalaryData> salaryAdminListData()
        {
            // List to store the retrieved admin salary data.
            List<AdminSalaryData> listdata = new List<AdminSalaryData>();

            // Using a SqlConnection to connect to the database.
            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    // Opening the database connection.
                    connect.Open();

                    // SQL query to select active admin data where delete_date is null.
                    string selectData = "SELECT * FROM admins WHERE status = 'Active' AND delete_date IS NULL";

                    // Using SqlCommand to execute the query.
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        // Executing the query and reading the results.
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Iterating through the results.
                        while (reader.Read())
                        {
                            // Creating a new AdminSalaryData object for each record.
                            AdminSalaryData salary = new AdminSalaryData
                            {
                                // Assigning values from the database to the properties.
                                AdminID = reader["admin_id"].ToString(),
                                Name = reader["admin_name"].ToString(),
                                Gender = reader["admin_gender"].ToString(),
                                Email = reader["admin_email"].ToString(),
                                Phone = reader["admin_phone"].ToString(),
                                Role = reader["admin_role"].ToString(),
                                AdminWorktype = reader["admin_worktype"].ToString(),
                                AdminWorkinghours = reader["admin_workinghours"].ToString(),
                                Salary = reader.GetInt32(reader.GetOrdinal("salary")),
                                Status = reader["status"].ToString()
                            };

                            // Adding the object to the list.
                            listdata.Add(salary);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handling any errors that occur during database operations.
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            // Returning the list of admin salary data.
            return listdata;
        }
    }
}