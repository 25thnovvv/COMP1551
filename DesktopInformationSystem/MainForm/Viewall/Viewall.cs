using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopInformationSystem
{
    public partial class Viewall : UserControl
    {
        private readonly string connectionString = ConnectConfig.connection;

        // Constructor initializes the component and displays all data.
        public Viewall()
        {
            InitializeComponent();
            DisplayAllData();
        }

        // RefreshData method ensures that the data display is updated on the UI thread.
        private void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DisplayAllData();
        }

        // DisplayAllData method fetches and displays combined data from students, teachers, and admins.
        private void DisplayAllData()
        {
            List<CombinedData> allData = GetAllData();
            dataGridView1.DataSource = allData;
        }

        // GetAllData method aggregates data from students, teachers, and admins into a single list.
        private List<CombinedData> GetAllData()
        {
            List<CombinedData> combinedList = new List<CombinedData>();

            // Fetch student data and convert to CombinedData instances.
            List<StudentData> studentList = StudentData.GetStudentListData();
            foreach (var student in studentList)
            {
                combinedList.Add(new CombinedData
                {
                    ID = student.ID,
                    RoleType = "Student",
                    IDNumber = student.StudentID,
                    Name = student.Name,
                    Gender = student.Gender,
                    Email = student.Email,
                    Phone = student.Phone,
                    Role = student.Role,
                    CurrentSubject1 = student.StudentCurrentSubject1,
                    CurrentSubject2 = student.StudentCurrentSubject2,
                    StudiedSubject1 = student.StudentStudiedSubject1,
                    StudiedSubject2 = student.StudentStudiedSubject2,
                    Status = student.Status
                });
            }

            // Fetch teacher data and convert to CombinedData instances.
            List<TeacherData> teacherList = TeacherData.GetTeacherListData();
            foreach (var teacher in teacherList)
            {
                combinedList.Add(new CombinedData
                {
                    ID = teacher.ID,
                    RoleType = "Teacher",
                    IDNumber = teacher.TeacherID,
                    Name = teacher.Name,
                    Gender = teacher.Gender,
                    Email = teacher.Email,
                    Phone = teacher.Phone,
                    Role = teacher.Role,
                    CurrentSubject1 = teacher.TeacherSubject1,
                    CurrentSubject2 = teacher.TeacherSubject2,
                    Salary = teacher.Salary,
                    Status = teacher.Status
                });
            }

            // Fetch admin data and convert to CombinedData instances.
            List<AdminData> adminList = AdminData.GetAdminListData();
            foreach (var admin in adminList)
            {
                combinedList.Add(new CombinedData
                {
                    ID = admin.ID,
                    RoleType = "Admin",
                    IDNumber = admin.AdminID,
                    Name = admin.Name,
                    Gender = admin.Gender,
                    Email = admin.Email,
                    Phone = admin.Phone,
                    Role = admin.Role,
                    WorkType = admin.AdminWorktype, 
                    WorkingHours = admin.AdminWorkinghours,
                    Salary = admin.Salary,
                    Status = admin.Status
                });
            }
            return combinedList;
        }
    }
}
