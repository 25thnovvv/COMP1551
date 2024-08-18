using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DesktopInformationSystem
{
    // The StudentData class inherits from the Person class and represents the student data model.
    // It includes properties related to student information and methods for data retrieval.
    class StudentData : Person
    {
        // Properties for storing student-specific information.
        public int ID { set; get; } 
        public string StudentID { set; get; } 
        public string Name { set; get; } 
        public string Gender { set; get; } 
        public string Email { set; get; } 
        public string Phone { set; get; } 
        public string Role { set; get; } 
        public string StudentCurrentSubject1 { set; get; } 
        public string StudentCurrentSubject2 { set; get; }
        public string StudentStudiedSubject1 { set; get; } 
        public string StudentStudiedSubject2 { set; get; } 
        public string Status { set; get; } 

        // Static field to store the connection string for the SQL database.
        private static readonly string ConnectionString = ConnectConfig.connection;

        // Default constructor for the StudentData class.
        public StudentData()
        {
        }

        // Constructor that initializes a StudentData object with the provided values.
        public StudentData(string name, string gender, string email, string phone, string role, string status, string studentID, string studentCurrentsubject1, string studentCurrentsubject2, string studentStudiedsubject1, string studentStudiedsubject2)
            : base(name, gender, email, phone, role, status) // Calls the base class constructor.
        {
            StudentID = studentID;
            StudentCurrentSubject1 = studentCurrentsubject1;
            StudentCurrentSubject2 = studentCurrentsubject2;
            StudentStudiedSubject1 = studentStudiedsubject1;
            StudentStudiedSubject2 = studentStudiedsubject2;
        }

        // Static method to retrieve a list of student data from the database.
        public static List<StudentData> GetStudentListData()
        {
            // Create a list to hold student data objects.
            List<StudentData> listdata = new List<StudentData>();

            // Establish a connection to the SQL database using the connection string.
            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open(); // Open the connection to the database.

                    // SQL query to select all student records where the delete_date is NULL (i.e., not deleted).
                    string selectData = "SELECT * FROM students WHERE delete_date IS NULL";

                    // Create a SQL command object to execute the query.
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        // Execute the query and obtain a data reader.
                        SqlDataReader reader = cmd.ExecuteReader();

                        // Read each record from the data reader.
                        while (reader.Read())
                        {
                            // Create a new StudentData object and populate it with data from the current record.
                            StudentData student = new StudentData
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("id")), // Get the ID from the database.
                                Name = reader["student_name"].ToString(), // Get the student's name.
                                Gender = reader["student_gender"].ToString(), // Get the student's gender.
                                Email = reader["student_email"].ToString(), // Get the student's email.
                                Phone = reader["student_phone"].ToString(), // Get the student's phone number.
                                Role = reader["student_role"].ToString(), // Get the student's role.
                                Status = reader["status"].ToString(), // Get the student's status.
                                StudentID = reader["student_id"].ToString(), // Get the student ID.
                                StudentCurrentSubject1 = reader["student_currentsubject1"].ToString(), // Get the student's current subject 1.
                                StudentCurrentSubject2 = reader["student_currentsubject2"].ToString(), // Get the student's current subject 2.
                                StudentStudiedSubject1 = reader["student_studiedsubject1"].ToString(), // Get the student's studied subject 1.
                                StudentStudiedSubject2 = reader["student_studiedsubject2"].ToString() // Get the student's studied subject 2.
                            };

                            // Add the populated StudentData object to the list.
                            listdata.Add(student);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log any errors that occur during data retrieval.
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            // Return the list of student data.
            return listdata;
        }
    }
}
