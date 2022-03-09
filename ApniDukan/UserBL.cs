﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace ApniDukan
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

        public UserMaster ReadUserByEmailID(string userEmailID)
        {

            return userDAO.ReadUserByEmailID(userEmailID);
        }

      
    }
}
