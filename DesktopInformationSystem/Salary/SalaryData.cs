using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DesktopInformationSystem
{
    class SalaryData : Person
    {
        public string TeacherID { get; set; }
        public int Salary { get; set; }

        private static readonly string ConnectionString = ConnectConfig.connection;

        // Parameterless constructor
        public SalaryData()
        {
        }

        // Parameterized constructor
        public SalaryData(string name, string gender, string email, string phone, string role, string status, string teacherID, int salary)
            : base(name, gender, email, phone, role, status)
        {
            TeacherID = teacherID;
            Salary = salary;
        }

        public static List<SalaryData> salaryTeacherListData()
        {
            List<SalaryData> listdata = new List<SalaryData>();

            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM Teachers WHERE status = 'Active' AND delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            SalaryData salary = new SalaryData
                            {
                                Name = reader["teacher_name"].ToString(),
                                Gender = reader["teacher_gender"].ToString(),
                                Role = reader["teacher_role"].ToString(),
                                TeacherID = reader["teacher_id"].ToString(),
                                Salary = reader.GetInt32(reader.GetOrdinal("salary"))
                            };

                            listdata.Add(salary);
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
