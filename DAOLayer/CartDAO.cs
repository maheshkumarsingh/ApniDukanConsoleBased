using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Utilities;
using System.Data;
namespace DAOLayer
{
    public class CartDAO : ICartDAO
    {
        #region SQL Queries
        public const string INSERT_INTO_CART =
            "insert into Cart(User_ID, Product_ID,Cart_CreatedDate) " +
            "values (@UserEmail, @ProductID, @CartCreatedDate); ";
        public const string READ_CART_BY_USEREMAILID =
            "select Cart_ID ,User_ID,p.Product_ID,Product_Type ,Product_Name," +
            "Product_Cost,Product_MFGDate,Product_ExpDate from Cart c join " +
            "Product p on c.Product_ID= p.Product_ID where c.User_ID = " +
            "@UserMailID;";
        #endregion
        public int InsertIntoCart(Cart cart)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = INSERT_INTO_CART
                };
                SqlParameter UserEmail = new SqlParameter("@UserEmail", SqlDbType.NVarChar);
                SqlParameter ProductID = new SqlParameter("@ProductID", SqlDbType.Int);
                SqlParameter CartCreatedDate = new SqlParameter("@CartCreatedDate", SqlDbType.Date);

                UserEmail.Value = cart.UserMailID;
                ProductID.Value = cart.ProductObj.ProductID;
                CartCreatedDate.Value = cart.CartCreatedDate;

                sqlCommand.Parameters.Add(UserEmail);
                sqlCommand.Parameters.Add(ProductID);
                sqlCommand.Parameters.Add(CartCreatedDate);

                using (sqlConnection)
                {
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if(result>=1)
                        return result;
                    else
                        return -1;
                }
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message);
            }
            //throw new NotImplementedException();
        }

        public List<Cart> ReadCartByUserEmailID(string userID)
        {
            bool hasMatchingRecords = false;

            List<Cart> cartList = new List<Cart>();
            Cart cart  = null;

            try
            {
                SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = READ_CART_BY_USEREMAILID
                };

                using (sqlConnection)
                {
                    SqlParameter UserMailID = new SqlParameter("@UserMailID", SqlDbType.NVarChar);
                    UserMailID.Value = userID;
                    UserMailID.Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add(UserMailID);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            cart = new Cart();
                            cart.CartID = Convert.ToInt16(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Cart_ID")));
                            cart.UserMailID = userID;
                            Product product = new Product();
                            //product.ProductID = Convert.ToInt16(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("p.Product_ID")));
                            product.ProductType = Convert.ToString(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Type")));
                            product.ProductName = Convert.ToString(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Name")));
                            product.ProductPrice = Convert.ToInt64(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Cost")));
                            product.ProductMFGDate = Convert.ToDateTime(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_MFGDate")));
                            hasMatchingRecords = true;
                            cart.ProductObj = product;
                            cartList.Add(cart);
                        }

                    }
                }
                if (cartList.Count!=0 && hasMatchingRecords!=false)
                {
                    return cartList;
                }else
                    return null;
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message);
            }
            //throw new NotImplementedException();
        }
    }
}
