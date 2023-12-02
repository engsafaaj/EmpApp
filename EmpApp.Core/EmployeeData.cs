using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpApp.Core
{
    public class EmployeeData
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MotherName { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }
}
