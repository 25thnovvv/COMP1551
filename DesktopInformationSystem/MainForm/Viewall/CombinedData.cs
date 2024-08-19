using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopInformationSystem
{
    // CombinedData class serves as a data model to encapsulate various attributes 
    // that use to represent combined information about students, teachers, 
    // and admins in the system.
    class CombinedData
    {
        public int ID { get; set; }
        public string RoleType { get; set; }
        public string IDNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string CurrentSubject1 { get; set; }
        public string CurrentSubject2 { get; set; }
        public string StudiedSubject1 { get; set; }
        public string StudiedSubject2 { get; set; }
        public string WorkType { get; set; }
        public string WorkingHours { get; set; }
        public int? Salary { get; set; }
        public string Status { get; set; }
    }
}
