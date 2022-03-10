using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using DAOLayer;
using Entities;

namespace BusinessLayer
{
    public class UserBL
    {
        UserDAO userDAO = new UserDAO();
        public bool CheackUserCredential(string userEmail)
        {
            //apply regex pattern
            bool isValid = false;
            try
            {
                MailAddress address = new MailAddress(userEmail);
                isValid = (address.Address == userEmail);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            if (!isValid)
                Console.WriteLine("Email ID format is not correct:(");

            return isValid;
        }

        public User ReadUserByEmailID(string userEmailID)
        {

            return userDAO.ReadUserByEmailID(userEmailID);
        }

        public int InsertUser(User user)
        {
            return userDAO.InsertUser(user);
        }
    }
}
