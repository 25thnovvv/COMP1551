using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopInformationSystem
{
    // AdminData class represents an admin in the system and inherits from the Person class.
    // It contains additional properties specific to admins and provides methods for handling admin data.
    class AdminData : Person
    {
        // Properties representing the admin's data fields.
        public int ID { set; get; }                      
        public string AdminID { set; get; }              
        public string Name { set; get; }                 
        public string Gender { set; get; }               
        public string Email { set; get; }                
        public string Phone { set; get; }               
        public string Role { set; get; }                 
        public int Salary { set; get; }                  
        public string AdminWorktype { set; get; }        
        public string AdminWorkinghours { set; get; }  
        public string Status { set; get; }              

        // Connection string for the SQL database, used for database operations.
        private static readonly string ConnectionString = ConnectConfig.connection;

        // Default constructor for the AdminData class.
        public AdminData()
        {
        }

        // Parameterized constructor for creating an AdminData object with specific values.
        public AdminData(string name, string gender, string email, string phone, string role, string status, string adminID, string adminWorktype, string adminWorkinghours, int salary)
            : base(name, gender, email, phone, role, status)
        {
            // Initializes the properties with the provided values.
            AdminID = adminID;
            AdminWorktype = adminWorktype;
            AdminWorkinghours = adminWorkinghours;
            Salary = salary;
        }

        // Static method to retrieve a list of all admins from the database.
        // Returns a List<AdminData> containing the admin records.
        public static List<AdminData> GetAdminListData()
        {
            // List to hold the retrieved admin data.
            List<AdminData> listdata = new List<AdminData>();

            // Establishes a connection to the SQL database using the connection string.
            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open(); // Opens the database connection.

                    // SQL query to select all admin records that have not been marked as deleted (delete_date IS NULL).
                    string selectData = "SELECT * FROM admins WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        // Executes the query and retrieves the data using a SqlDataReader.
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Reads each record from the database and populates the AdminData object.
                        while (reader.Read())
                        {
                            AdminData admin = new AdminData
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("id")),                   // Retrieves the ID from the database.
                                Name = reader["admin_name"].ToString(),                        // Retrieves the admin's name.
                                Gender = reader["admin_gender"].ToString(),                    // Retrieves the admin's gender.
                                Email = reader["admin_email"].ToString(),                      // Retrieves the admin's email.
                                Phone = reader["admin_phone"].ToString(),                      // Retrieves the admin's phone number.
                                Role = reader["admin_role"].ToString(),                        // Retrieves the admin's role.
                                Status = reader["status"].ToString(),                          // Retrieves the admin's status.
                                AdminID = reader["admin_id"].ToString(),                       // Retrieves the admin's unique identifier.
                                AdminWorktype = reader["admin_worktype"].ToString(),           // Retrieves the admin's work type.
                                AdminWorkinghours = reader["admin_workinghours"].ToString(),   // Retrieves the admin's working hours.
                                Salary = reader.GetInt32(reader.GetOrdinal("salary"))          // Retrieves the admin's salary.
                            };

                            // Adds the populated AdminData object to the list.
                            listdata.Add(admin);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handles any exceptions that occur during database operations and outputs the error message.
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            // Returns the list of admin data.
            return listdata;
        }
    }
}
