using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApniDukan
{
    public class Employee
    {
        public string EmployeeEmail { get; set; }

        public string EmployeePassword { get; set; }

        public string EmployeeName { get; set; }

        public DateTime EmployeeJoinDate { get; set; }

        public override string ToString()
        {
           return String.Format("\n{0,-20} {1,-30} {2,-30} {3,-10}", "Welcome", EmployeeName, EmployeeEmail,EmployeeJoinDate.ToShortDateString());
        }

    }
}
