using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopInformationSystem
{
    class AdminData : Person
    {
        public int ID { set; get; }
        public string AdminID { set; get; }
        public string AdminWorktype { set; get; }
        public string AdminWorkinghours { set; get; }
        public int Salary { set; get; }

        private static readonly string ConnectionString = ConnectConfig.connection;

        // Parameterless constructor
        public AdminData()
        {
        }
        public AdminData(string name, string gender, string email, string phone, string role, string status, string adminID, string adminWorktype, string adminWorkinghours, int salary)
            : base(name, gender, email, phone, role, status)
        {
            AdminID = adminID;
            AdminWorktype = adminWorktype;
            AdminWorkinghours = adminWorkinghours;
            Salary = salary;
        }

        public static List<AdminData> GetAdminListData()
        {
            List<AdminData> listdata = new List<AdminData>();

            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM admins WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AdminData admin = new AdminData
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("id")),
                                Name = reader["admin_name"].ToString(),
                                Gender = reader["admin_gender"].ToString(),
                                Email = reader["admin_email"].ToString(),
                                Phone = reader["admin_phone"].ToString(),
                                Role = reader["admin_role"].ToString(),
                                Status = reader["status"].ToString(),
                                AdminID = reader["admin_id"].ToString(),
                                AdminWorktype = reader["admin_worktype"].ToString(),
                                AdminWorkinghours = reader["admin_workinghours"].ToString(),
                                Salary = reader.GetInt32(reader.GetOrdinal("salary"))
                            };

                            listdata.Add(admin);
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

        public static List<AdminData> GetSalaryAdminListData()
        {
            List<AdminData> listdata = new List<AdminData>();

            using (SqlConnection connect = new SqlConnection(ConnectionString))
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM admins WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            AdminData admin = new AdminData
                            {
                                Name = reader["admin_name"].ToString(),
                                Role = reader["admin_role"].ToString(),
                                AdminID = reader["admin_id"].ToString(),
                                Salary = reader.GetInt32(reader.GetOrdinal("salary"))
                            };

                            listdata.Add(admin);
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
