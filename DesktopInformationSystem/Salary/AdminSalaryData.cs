using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DesktopInformationSystem
{
    class AdminSalaryData : Person
    {
        public string AdminID { get; set; }
        public string AdminWorktype { get; set; }
        public string AdminWorkinghours { get; set; }   
        public int Salary { get; set; }

        private static readonly string ConnectionString = ConnectConfig.connection;

        public AdminSalaryData()
        {
        }

        public AdminSalaryData(string name, string gender, string email, string phone, string role, string status, string adminID, string adminWorktype, string adminWorkinghours, int salary)
            : base(name, gender, email, phone, role, status)
        {
            AdminID = adminID;
            AdminWorktype = adminWorktype;
            AdminWorkinghours = adminWorkinghours;
            Salary = salary;
        }

        public static List<AdminSalaryData> salaryAdminListData()
        {
            List<AdminSalaryData> listdata = new List<AdminSalaryData>();

            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM admins WHERE status = 'Active' AND delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AdminSalaryData salary = new AdminSalaryData
                            {
                                Name = reader["admin_name"].ToString(),
                                Gender = reader["admin_gender"].ToString(),
                                Role = reader["admin_role"].ToString(),
                                AdminID = reader["admin_id"].ToString(),
                                AdminWorktype = reader["admin_worktype"].ToString(),
                                AdminWorkinghours = reader["admin_workinghours"].ToString(),
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
