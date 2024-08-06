using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DesktopInformationSystem
{
    class StudentData : Person
    {
        public int ID { set; get; }
        public string StudentID { set; get; }
        public string StudentCurrentSubject1 { set; get; }
        public string StudentCurrentSubject2 { set; get; }
        public string StudentStudiedSubject1 { set; get; }
        public string StudentStudiedSubject2 { set; get; }

        private static readonly string ConnectionString = ConnectConfig.connection;

        public StudentData()
        {
        }

        public StudentData(string name, string gender, string email, string phone, string role, string status, string studentID, string studentCurrentsubject1, string studentCurrentsubject2, string studentStudiedsubject1, string studentStudiedsubject2)
            : base(name, gender, email, phone, role, status)
        {
            StudentID = studentID;
            StudentCurrentSubject1 = studentCurrentsubject1;
            StudentCurrentSubject2 = studentCurrentsubject2;
            StudentStudiedSubject1 = studentStudiedsubject1;
            StudentStudiedSubject2 = studentStudiedsubject2;
        }
        public static List<StudentData> GetStudentListData()
        {
            List<StudentData> listdata = new List<StudentData>();

            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM students WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            StudentData student = new StudentData
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("id")),
                                Name = reader["student_name"].ToString(),
                                Gender = reader["student_gender"].ToString(),
                                Email = reader["student_email"].ToString(),
                                Phone = reader["student_phone"].ToString(),
                                Role = reader["student_role"].ToString(),
                                Status = reader["status"].ToString(),
                                StudentID = reader["student_id"].ToString(),
                                StudentCurrentSubject1 = reader["student_currentsubject1"].ToString(),
                                StudentCurrentSubject2 = reader["student_currentsubject2"].ToString(),
                                StudentStudiedSubject1 = reader["student_studiedsubject1"].ToString(),
                                StudentStudiedSubject2 = reader["student_studiedsubject2"].ToString()
                            };

                            listdata.Add(student);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return listdata;
        }
    }
}
