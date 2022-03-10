using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities;
using Utilities;

namespace DAOLayer
{
    public class EmployeeDAO
    {
        public Employee ReadEmployee(string employeeUserEmail)
        {

            SqlConnection connection = new SqlConnection(Helper.ConnectionString);
            connection.Open();
            string sqlQuery = "select Employee_Email, Employee_Password, Employee_Name, Employee_JoinDate from Employee where Employee_Email = '"+employeeUserEmail+"';";
            SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection);
            SqlDataReader datareader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);

            Employee employee = new Employee();

            if (datareader.HasRows)
            {
                datareader.Read();

                if (datareader["Employee_Email"]!=DBNull.Value)
                    employee.EmployeeEmail = datareader["Employee_Email"].ToString().Trim();
                if (datareader["Employee_Password"]!=DBNull.Value)
                    employee.EmployeePassword = datareader["Employee_Password"].ToString().Trim();
                if (datareader["Employee_Name"]!= DBNull.Value)
                    employee.EmployeeName= datareader["Employee_Name"].ToString().Trim();
                if (datareader["Employee_JoinDate"]!= DBNull.Value)
                    employee.EmployeeJoinDate = Convert.ToDateTime(datareader["Employee_JoinDate"]);
            }
            return employee;
        }

        //public bool CreateProduct(Product product)
        //{
        //    return true;
        //}
        /*
        public List<Product> ReadProduct(int productId)
        {
            return null;

        }
        public bool UpdateProduct(Product product)
        {
            return false;
        }

        public bool DeleteProduct(int productId)
        {
            return false;
        }
        
        public List<UserMaster> ReadUser(int UserId)
        {
            return null;

        }

        public bool DeleteUser(int userId)
        {
            return false ;
        }

        public List<Cart> ReadUserCart(int userId)
        {
            return null;
        }
        */
    }
}
