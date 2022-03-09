using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DatabaseConnection;
using BusinessException;

namespace ApniDukan
{
    public class UserDAO
    {
        #region SQL - Constants
        public const string ADD_USER = "insert into UserMaster " +
            "(User_FName,User_LName,User_Email,User_Password,User_Contact,User_JoinedDate)" +
            "values (@User_FName,@User_LName,@User_Email,@User_Password,@User_Contact,@User_JoinedDate)";

        public const string READ_USER ="select User_ID, User_FName, User_LName, User_Email, " +
                    "User_Password, User_Contact,User_JoinedDate from UserMaster where " +
                    "User_Email= @User_Email";
        #endregion
        public int InsertUser(User user)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);

                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = ADD_USER
                };
                SqlParameter User_FName = new SqlParameter("@User_FName", SqlDbType.NVarChar);
                SqlParameter User_LName = new SqlParameter("@User_LName", SqlDbType.NVarChar);
                SqlParameter User_Email = new SqlParameter("@User_Email", SqlDbType.NVarChar);
                SqlParameter User_Password = new SqlParameter("@User_Password", SqlDbType.NVarChar);
                SqlParameter User_Contact = new SqlParameter("@User_Contact", SqlDbType.BigInt);
                SqlParameter User_JoinedDate = new SqlParameter("@User_JoinedDate", SqlDbType.Date);

                User_FName.Value = user.UserFName;
                User_LName.Value= user.UserLName;
                User_Email.Value = user.UserEmail;
                User_Password.Value = user.UserPassword;
                User_Contact.Value= user.UserConatct;
                User_JoinedDate.Value= user.UserJoinedDate;

                sqlCommand.Parameters.Add(User_FName);
                sqlCommand.Parameters.Add(User_LName);
                sqlCommand.Parameters.Add(User_Email);
                sqlCommand.Parameters.Add(User_Password);
                sqlCommand.Parameters.Add(User_Contact);
                sqlCommand.Parameters.Add(User_JoinedDate);

                using (sqlConnection)
                {
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result>1)
                        return result;
                    else
                        return -1;
                }
            }
            catch (Exception ex)
            {

                throw new ExceptionClass(ex.Message);
            }
        }

        public User ReadUserByEmailID(string userEmailid)
        {
            bool hasMatchingRecords= false;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType= CommandType.Text,
                    CommandText = READ_USER
                };
                using (sqlConnection)
                {
                    sqlCommand.Prepare();
                    SqlParameter User_Email = new SqlParameter("@User_Email", SqlDbType.NVarChar);
                    User_Email.Value = userEmailid;
                    User_Email.Direction= ParameterDirection.Input;
                    sqlCommand.Parameters.Add(User_Email);

                    sqlConnection.Open();
                    SqlDataReader datareader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);
                    User user = new User();
                    if (datareader.HasRows)
                    {
                        datareader.Read();

                        if (datareader["User_ID"]!= DBNull.Value)
                            user.UserId = Convert.ToInt32(datareader["User_ID"].ToString().Trim());
                        if (datareader["User_FName"]!= DBNull.Value)
                            user.UserFName = datareader["User_FName"].ToString().Trim();
                        if (datareader["User_LName"]!= DBNull.Value)
                            user.UserLName= datareader["User_LName"].ToString().Trim();
                        if (datareader["User_Email"]!= DBNull.Value)
                            user.UserEmail = datareader["User_Email"].ToString().Trim();
                        if (datareader["User_Password"]!= DBNull.Value)
                            user.UserPassword = datareader["User_Password"].ToString();
                        if (datareader["User_Contact"]!= DBNull.Value)
                            user.UserConatct = Convert.ToDouble(datareader["User_Contact"].ToString().Trim());
                        if (datareader["User_JoinedDate"]!= DBNull.Value)
                            user.UserJoinedDate = Convert.ToDateTime(datareader["User_JoinedDate"].ToString());
                        hasMatchingRecords = true;
                    }
                    if (hasMatchingRecords==true)
                        return user;
                    else
                        return null;
                }
                
            }
            catch (Exception ex)
            {
                throw new ExceptionClass(ex.Message);
            }
        }
    }
}
