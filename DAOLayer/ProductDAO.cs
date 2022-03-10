using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace DAOLayer
{
    public class ProductDAO : IProductDAO
    {
        public const string GET_PRODUCT_LIST = "select Product_ID, Product_Type,Product_Name,Product_Cost," +
            "Product_MFGDate,Product_ExpDate from Product";
        public List<Product> ReadAllProduct()
        {
            bool hasRecords = false;

            List<Product> productList = new List<Product>();

            try
            {
                SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = GET_PRODUCT_LIST
                };

                using (sqlConnection)
                {
                    sqlCommand.Prepare();
                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Product product = new Product();
                            product.ProductID = Convert.ToInt32(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_ID")));
                            product.ProductType = Convert.ToString(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Type")));
                            product.ProductName = Convert.ToString(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Name")));
                            product.ProductPrice = Convert.ToInt64(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Cost")));
                            product.ProductMFGDate = Convert.ToDateTime(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_MFGDate")));
                            if (sqlDataReader["Product_ExpDate"]!=DBNull.Value)
                                product.ProductExpiryDate = Convert.ToDateTime(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_ExpDate")));
                            else
                                product.ProductExpiryDate = DateTime.Now;

                            productList.Add(product);
                            hasRecords = true;
                        }
                    }
                    sqlDataReader.Close();
                }
                if (hasRecords==true)
                {
                    return productList;
                }
                else
                    return null;
            }
            catch (Exception ex )
            {

                throw new BusinessException(ex.Message);
            }
            
        }

        
    }
}
