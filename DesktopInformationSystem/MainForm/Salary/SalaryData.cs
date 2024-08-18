using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DesktopInformationSystem
{
    // The SalaryData class extends the Person class and is used to manage teacher salary data.
    class SalaryData : Person
    {
        // Properties representing the teacher's details.
        public string TeacherID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public int Salary { get; set; }
        public string Status { get; set; }

        // Connection string for connecting to the SQL database.
        private static readonly string ConnectionString = ConnectConfig.connection;

        // Default constructor.
        public SalaryData()
        {
        }

        // Parameterized constructor to initialize SalaryData with specific values.
        public SalaryData(string name, string gender, string email, string phone, string role, string status, string teacherID, int salary)
            : base(name, gender, email, phone, role, status)
        {
            TeacherID = teacherID;
            Salary = salary;
        }

        // Retrieves a list of active teachers' salary data from the database.
        public static List<SalaryData> SalaryTeacherListData()
        {
            List<SalaryData> listdata = new List<SalaryData>();

            // Using a connection to the database.
            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open(); // Open the database connection.
                    // SQL query to select active teachers who have not been marked for deletion.
                    string selectData = "SELECT * FROM Teachers WHERE status = 'Active' AND delete_date IS NULL";

                    // Execute the SQL query.
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader(); // Read the data.

                        // Read each row from the result set.
                        while (reader.Read())
                        {
                            // Create a new SalaryData object for each row.
                            SalaryData salary = new SalaryData
                            {
                                TeacherID = reader["teacher_id"].ToString(),
                                Name = reader["teacher_name"].ToString(),
                                Gender = reader["teacher_gender"].ToString(),
                                Email = reader["teacher_email"].ToString(),
                                Phone = reader["teacher_phone"].ToString(),
                                Role = reader["teacher_role"].ToString(),
                                Salary = reader.GetInt32(reader.GetOrdinal("salary")),
                                Status = reader["status"].ToString()
                            };

                            listdata.Add(salary); // Add the object to the list.
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message); // Handle any exceptions and output error message.
                }
            }
            return listdata; // Return the list of salary data.
        }
    }
}
