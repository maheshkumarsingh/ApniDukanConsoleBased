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
        #region SQL Queries for Products
        public const string GET_PRODUCT_LIST = "select Product_ID, Product_Type,Product_Name,Product_Cost," +
            "Product_MFGDate,Product_ExpDate from Product";
        
        public const string GET_PRODUCT_BY_ID =
            "select Product_ID, Product_Type,Product_Name,Product_Cost," +
            "Product_MFGDate,Product_ExpDate from Product where Product_ID = @ProductID ;";
        public const string ADD_NEW_Product =
            "insert into Product(Product_Type,Product_Name, Product_Cost,Product_MFGDate,Product_ExpDate) values" +
            "(@ProductType, @ProductName, @ProductPrice, @ProductMFGDate, @ProductExpiryDate);";
        public const string UPDATE_PRODUCT_BY_ID
            = "update Product set Product_Cost = @ProductPrice where Product_ID = @ProductID";
        public const string DELETE_PRODUCT_BY_ID
            = "delete from Product where Product_ID = @ProductID";


        #endregion


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

        public Product SearchProductByID(int id)
        {
            bool hasRecords = false;
            Product product = null;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = GET_PRODUCT_BY_ID
                };

                using (sqlConnection)
                {
                    sqlCommand.Prepare();
                    SqlParameter ProductID = new SqlParameter("@ProductID",SqlDbType.Int);
                    ProductID.Value = id;
                    ProductID.Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add(ProductID);

                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SingleRow);


                    if (sqlDataReader.HasRows)
                    {
                        sqlDataReader.Read();
                        
                            product = new Product();
                            product.ProductID = Convert.ToInt32(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_ID")));
                            product.ProductType = Convert.ToString(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Type")));
                            product.ProductName = Convert.ToString(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Name")));
                            product.ProductPrice = Convert.ToInt64(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Cost")));
                            product.ProductMFGDate = Convert.ToDateTime(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_MFGDate")));
                            if (sqlDataReader["Product_ExpDate"]!=DBNull.Value)
                                product.ProductExpiryDate = Convert.ToDateTime(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_ExpDate")));
                            else
                                product.ProductExpiryDate = DateTime.Now;

                            hasRecords = true;
                        
                    }
                    sqlDataReader.Close();
                }
                if (hasRecords==true)
                {
                    return product;
                }
                else
                    return null;
            }
            catch (Exception ex )
            {

                throw new BusinessException(ex.Message);
            }


            //throw new NotImplementedException();
        }


        #region Sort By Query Old Method
        //public List<Product> SortProductsByPrice(List<Product> products)
        //{
        //    bool hasRecords = false;

        //    List<Product> productList = new List<Product>();

        //    try
        //    {
        //        SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);
        //        SqlCommand sqlCommand = new SqlCommand
        //        {
        //            Connection = sqlConnection,
        //            CommandType = CommandType.Text,
        //            CommandText = SORT_PRODUCT_BY_PRICE
        //        };

        //        using (sqlConnection)
        //        {
        //            sqlCommand.Prepare();
        //            sqlConnection.Open();

        //            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        //            if (sqlDataReader.HasRows)
        //            {
        //                while (sqlDataReader.Read())
        //                {
        //                    Product product = new Product();
        //                    product.ProductID = Convert.ToInt32(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_ID")));
        //                    product.ProductType = Convert.ToString(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Type")));
        //                    product.ProductName = Convert.ToString(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Name")));
        //                    product.ProductPrice = Convert.ToInt64(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Cost")));
        //                    product.ProductMFGDate = Convert.ToDateTime(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_MFGDate")));
        //                    if (sqlDataReader["Product_ExpDate"]!=DBNull.Value)
        //                        product.ProductExpiryDate = Convert.ToDateTime(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_ExpDate")));
        //                    else
        //                        product.ProductExpiryDate = DateTime.Now;

        //                    productList.Add(product);
        //                    hasRecords = true;
        //                }
        //            }
        //            sqlDataReader.Close();
        //        }
        //        if (hasRecords==true)
        //        {
        //            return productList;
        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new BusinessException(ex.Message);
        //    }

        //    //throw new NotImplementedException();
        //}
        //public List<Product> SortProductsByMFGDates(List<Product> products)
        //{
        //    bool hasRecords = false;

        //    List<Product> productList = new List<Product>();

        //    try
        //    {
        //        SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);
        //        SqlCommand sqlCommand = new SqlCommand
        //        {
        //            Connection = sqlConnection,
        //            CommandType = CommandType.Text,
        //            CommandText = SORT_PRODUCT_BY_MFGDates
        //        };

        //        using (sqlConnection)
        //        {
        //            sqlCommand.Prepare();
        //            sqlConnection.Open();

        //            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

        //            if (sqlDataReader.HasRows)
        //            {
        //                while (sqlDataReader.Read())
        //                {
        //                    Product product = new Product();
        //                    product.ProductID = Convert.ToInt32(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_ID")));
        //                    product.ProductType = Convert.ToString(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Type")));
        //                    product.ProductName = Convert.ToString(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Name")));
        //                    product.ProductPrice = Convert.ToInt64(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_Cost")));
        //                    product.ProductMFGDate = Convert.ToDateTime(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_MFGDate")));
        //                    if (sqlDataReader["Product_ExpDate"]!=DBNull.Value)
        //                        product.ProductExpiryDate = Convert.ToDateTime(sqlDataReader.GetValue(sqlDataReader.GetOrdinal("Product_ExpDate")));
        //                    else
        //                        product.ProductExpiryDate = DateTime.Now;

        //                    productList.Add(product);
        //                    hasRecords = true;
        //                }
        //            }
        //            sqlDataReader.Close();
        //        }
        //        if (hasRecords==true)
        //        {
        //            return productList;
        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new BusinessException(ex.Message);
        //    }

        //    //throw new NotImplementedException();
        //}
        #endregion
        public int AddProduct(Product product)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = ADD_NEW_Product
                };

                SqlParameter ProductType = new SqlParameter("@ProductType", SqlDbType.NVarChar);
                SqlParameter ProductName = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                SqlParameter ProductPrice = new SqlParameter("@ProductPrice", SqlDbType.Float);
                SqlParameter ProductMFGDate = new SqlParameter("@ProductMFGDate", SqlDbType.Date);
                SqlParameter ProductExpiryDate = new SqlParameter("@ProductExpiryDate", SqlDbType.Date);

                ProductType.Value = product.ProductType;
                ProductName.Value = product.ProductName;
                ProductPrice.Value = product.ProductPrice;
                ProductMFGDate.Value = product.ProductMFGDate;
                ProductExpiryDate.Value = product.ProductExpiryDate;

                sqlCommand.Parameters.Add(ProductType);
                sqlCommand.Parameters.Add(ProductName);
                sqlCommand.Parameters.Add(ProductPrice);
                sqlCommand.Parameters.Add(ProductMFGDate);
                sqlCommand.Parameters.Add(ProductExpiryDate);

                using (sqlConnection)
                {
                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result>=1)
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

        public int UpdateProductByID(int id, Int64 price)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = UPDATE_PRODUCT_BY_ID
                };

                using (sqlConnection)
                {
                    sqlCommand.Prepare();
                    SqlParameter ProductPrice = new SqlParameter("@ProductPrice", SqlDbType.Float);
                    SqlParameter ProductID = new SqlParameter("@ProductID", SqlDbType.Int);
                    ProductPrice.Value = price;
                    ProductPrice.Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add(ProductPrice);
                    ProductID.Value = id;
                    ProductPrice.Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add(ProductID);

                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result >=1)
                        return result;
                    else return -1;
                }
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message);
            }
            //throw new NotImplementedException();
        }

        public int DeleteProductByID(int id)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(Helper.ConnectionString);
                SqlCommand sqlCommand = new SqlCommand
                {
                    Connection = sqlConnection,
                    CommandType = CommandType.Text,
                    CommandText = DELETE_PRODUCT_BY_ID
                };

                using (sqlConnection)
                {
                    sqlCommand.Prepare();
                    SqlParameter ProductID = new SqlParameter("@ProductID", SqlDbType.Int);
                    ProductID.Value = id;
                    ProductID.Direction = ParameterDirection.Input;
                    sqlCommand.Parameters.Add(ProductID);

                    sqlConnection.Open();
                    int result = sqlCommand.ExecuteNonQuery();
                    if (result >=1)
                        return result;
                    else return -1;
                }
            }
            catch (Exception ex)
            {

                throw new BusinessException(ex.Message);
            }
            throw new NotImplementedException();
        }
    }
}
