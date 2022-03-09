using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net.Mail;

namespace ApniDukan
{
    public class EmployeeBL
    {
        EmployeeDAO employeeDAO;
        public Employee IsEmployeeEmail(string employeeUserId)
        {
            bool isValid = false;
            try
            {
                MailAddress address = new MailAddress(employeeUserId);
                isValid = (address.Address == employeeUserId);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            employeeDAO = new EmployeeDAO();
            if(!isValid)
                Console.WriteLine("Email ID format is not correct:(");
            return employeeDAO.ReadEmployee(employeeUserId);
        }

        public bool IsEmployeePassword(string password)
        {
            return true;
        }
    }
}
