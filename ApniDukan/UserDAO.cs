using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Data.SqlClient;
namespace ApniDukan
{
    public class UserDAO
    {
        public int CreateUser(UserMaster usermaster)
        {
            
            return 0;
        }

        public UserMaster ReadUserByEmailID(string userEmailid)
        {
            SqlConnection sqlConnection = new SqlConnection(DBConnection.ConnectionString);
            sqlConnection.Open();

            string selectquery = "select user_id, user_fName, user_lName, user_emailID, " +
                "user_password, user_contact,user_joinedDate from UserMaster where " +
                "user_emailID='"+userEmailid+"';";
            SqlCommand sqlCommand = new SqlCommand(selectquery, sqlConnection);
            SqlDataReader datareader = sqlCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);

            UserMaster usermaster = new UserMaster();
            if (datareader.HasRows)
            {
                datareader.Read();

                if(datareader["user_id"]!= DBNull.Value)
                    usermaster.UserId = Convert.ToInt32(datareader["user_id"].ToString().Trim());
                if (datareader["user_fName"]!= DBNull.Value)
                    usermaster.UserFName = datareader["user_fName"].ToString().Trim();
                if (datareader["user_lName"]!= DBNull.Value)
                    usermaster.UserLName= datareader["user_lName"].ToString().Trim() ;
                if (datareader["user_emailID"]!= DBNull.Value)
                    usermaster.UserEmail = datareader["user_emailID"].ToString().Trim();
                if (datareader["user_password"]!= DBNull.Value)
                    usermaster.UserPassword = datareader["user_password"].ToString();
                if (datareader["user_contact"]!= DBNull.Value)
                    usermaster.UserConatct = Convert.ToDouble(datareader["user_contact"].ToString().Trim());
                if (datareader["user_joinedDate"]!= DBNull.Value)
                    usermaster.UserJoinedDate = Convert.ToDateTime(datareader["user_joinedDate"].ToString()) ;
            }
            return usermaster;

        }
    }
}
