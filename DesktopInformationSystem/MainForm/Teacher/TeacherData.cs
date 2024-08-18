using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DesktopInformationSystem
{
    // TeacherData class inherits from Person and represents teacher-related data.
    // It includes properties for teacher details and methods for retrieving teacher data from the database.
    class TeacherData : Person
    {
        // Properties to hold teacher-specific data.
        public int ID { get; set; }
        public string TeacherID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public int Salary { get; set; }
        public string TeacherSubject1 { get; set; }
        public string TeacherSubject2 { get; set; }
        public string Status { get; set; }

        // Connection string for connecting to the SQL database.
        private static readonly string ConnectionString = ConnectConfig.connection;

        // Default constructor.
        public TeacherData()
        {
        }

        // Parameterized constructor to initialize a TeacherData object with specific values.
        public TeacherData(string name, string gender, string email, string phone, string role, string status, string teacherID, string teacherSubject1, string teacherSubject2, int salary)
            : base(name, gender, email, phone, role, status)
        {
            TeacherID = teacherID;
            TeacherSubject1 = teacherSubject1;
            TeacherSubject2 = teacherSubject2;
            Salary = salary;
        }

        // Static method to retrieve a list of teacher data from the database.
        public static List<TeacherData> GetTeacherListData()
        {
            // Create a list to hold TeacherData objects.
            List<TeacherData> listdata = new List<TeacherData>();

            // Establish a connection to the SQL database.
            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open(); // Open the database connection.
                    // SQL query to select all records from the teachers table where delete_date is NULL (not deleted).
                    string selectData = "SELECT * FROM teachers WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        // Execute the query and obtain a SqlDataReader.
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Read each record from the reader and map it to a TeacherData object.
                        while (reader.Read())
                        {
                            TeacherData teacher = new TeacherData
                            {
                                // Initialize the TeacherData object with values from the database.
                                ID = reader.GetInt32(reader.GetOrdinal("id")),
                                TeacherID = reader["teacher_id"].ToString(),
                                Name = reader["teacher_name"].ToString(),
                                Gender = reader["teacher_gender"].ToString(),
                                Email = reader["teacher_email"].ToString(),
                                Phone = reader["teacher_phone"].ToString(),
                                Role = reader["teacher_role"].ToString(),
                                Status = reader["status"].ToString(),
                                TeacherSubject1 = reader["teacher_subject1"].ToString(),
                                TeacherSubject2 = reader["teacher_subject2"].ToString(),
                                Salary = reader.GetInt32(reader.GetOrdinal("salary"))
                            };

                            // Add the TeacherData object to the list.
                            listdata.Add(teacher);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during database operations.
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            // Return the list of TeacherData objects.
            return listdata;
        }
    }
}
