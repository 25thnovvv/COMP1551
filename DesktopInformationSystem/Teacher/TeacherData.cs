using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace DesktopInformationSystem
{
    class TeacherData : Person
    {
        public int ID { get; set; }
        public string TeacherID { get; set; }
        public string TeacherSubject1 { get; set; }
        public string TeacherSubject2 { get; set; }
        public int Salary { get; set; }

        private static readonly string ConnectionString = ConnectConfig.connection;

        // Parameterless constructor
        public TeacherData()
        {
        }

        // Parameterized constructor
        public TeacherData(string name, string gender, string email, string phone, string role, string status, string teacherID, string teacherSubject1, string teacherSubject2, int salary)
            : base(name, gender, email, phone, role, status)
        {
            TeacherID = teacherID;
            TeacherSubject1 = teacherSubject1;
            TeacherSubject2 = teacherSubject2;
            Salary = salary;
        }

        public static List<TeacherData> GetTeacherListData()
        {
            List<TeacherData> listdata = new List<TeacherData>();

            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM teachers WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            TeacherData teacher = new TeacherData
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("id")),
                                Name = reader["teacher_name"].ToString(),
                                Gender = reader["teacher_gender"].ToString(),
                                Email = reader["teacher_email"].ToString(),
                                Phone = reader["teacher_phone"].ToString(),
                                Role = reader["teacher_role"].ToString(),
                                Status = reader["status"].ToString(),
                                TeacherID = reader["teacher_id"].ToString(),
                                TeacherSubject1 = reader["teacher_subject1"].ToString(),
                                TeacherSubject2 = reader["teacher_subject2"].ToString(),
                                Salary = reader.GetInt32(reader.GetOrdinal("salary"))
                            };

                            listdata.Add(teacher);
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

        public static List<TeacherData> GetSalaryTeacherListData()
        {
            List<TeacherData> listdata = new List<TeacherData>();

            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM teachers WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            TeacherData teacher = new TeacherData
                            {
                                Name = reader["teacher_name"].ToString(),
                                Role = reader["teacher_role"].ToString(),
                                TeacherID = reader["teacher_id"].ToString(),
                                Salary = reader.GetInt32(reader.GetOrdinal("salary"))
                            };

                            listdata.Add(teacher);
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
