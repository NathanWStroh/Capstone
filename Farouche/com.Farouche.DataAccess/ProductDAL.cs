using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using com.Farouche.Commons;
//Author: Caleb
//Date Created: 1/31/2014
//Last Modified: 1/31/2014
//Last Modified By: Adam Chandler

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 1/31/2014   Adam                          0.0.1b         Updated Instantiation of new objects to use id as parameter
*/
namespace com.Farouche.DataAccess
{
    public class ProductDAL : DatabaseConnection
    {
        public static Boolean InsertProduct(Product product, SqlConnection connection)
        {
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("sp_InsertIntoProducts", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@OnHand", product.reserved);
                sqlCmd.Parameters.AddWithValue("@Available", product.available);
                sqlCmd.Parameters.AddWithValue("@Description", product.description);
                sqlCmd.Parameters.AddWithValue("@Location", product.location);
                sqlCmd.Parameters.AddWithValue("@UnitPrice", product.unitPrice);
                sqlCmd.Parameters.AddWithValue("@ShortDesc", product.Name);
                sqlCmd.Parameters.AddWithValue("@ReorderThreshold", product._reorderThreshold);
                sqlCmd.Parameters.AddWithValue("@ReorderAmount", product._reorderAmount);
                sqlCmd.Parameters.AddWithValue("@ShippingDimensions", product._shippingDemensions);
                sqlCmd.Parameters.AddWithValue("@ShippingWeight", product._shippingWeight);
                sqlCmd.Parameters.AddWithValue("@Active", product.Active ? 1 : 0);


                //If the procedure returns 1 set to true, if 0 remain false.
                if (sqlCmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException. " + ex.Message);
            }
            catch (DataException ex)
            {
                Console.WriteLine("DataException. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GeneralException. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }//End of insertProduct(..)

        public static Boolean UpdateProduct(Product product, Product originalProduct, SqlConnection connection)
        {
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("sp_UpdateProducts", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProductID", product.Id);
                sqlCmd.Parameters.AddWithValue("@OnHand", product.reserved);
                sqlCmd.Parameters.AddWithValue("@Available", product.available);
                sqlCmd.Parameters.AddWithValue("@Description", product.description);
                sqlCmd.Parameters.AddWithValue("@Location", product.location);
                sqlCmd.Parameters.AddWithValue("@UnitPrice", product.unitPrice);
                sqlCmd.Parameters.AddWithValue("@ShortDesc", product.Name);
                sqlCmd.Parameters.AddWithValue("@ReorderThreshold", product._reorderThreshold);
                sqlCmd.Parameters.AddWithValue("@ReorderAmount", product._reorderAmount);
                sqlCmd.Parameters.AddWithValue("@ShippingDimensions", product._shippingDemensions);
                sqlCmd.Parameters.AddWithValue("@ShippingWeight", product._shippingWeight);
                sqlCmd.Parameters.AddWithValue("@Active", product.Active);
                sqlCmd.Parameters.AddWithValue("@OriginalOnHand", originalProduct.reserved);
                sqlCmd.Parameters.AddWithValue("@OriginalAvailable", originalProduct.available);
                sqlCmd.Parameters.AddWithValue("@OriginalDescription", originalProduct.description);
                sqlCmd.Parameters.AddWithValue("@OriginalLocation", originalProduct.location);
                sqlCmd.Parameters.AddWithValue("@OriginalUnitPrice", originalProduct.unitPrice);
                sqlCmd.Parameters.AddWithValue("@OriginalShortDesc", originalProduct.Name);
                sqlCmd.Parameters.AddWithValue("@OriginalReorderThreshold", originalProduct._reorderThreshold);
                sqlCmd.Parameters.AddWithValue("@OriginalReorderAmount", originalProduct._reorderAmount);
                sqlCmd.Parameters.AddWithValue("@OriginalShippingDimensions", originalProduct._shippingDemensions);
                sqlCmd.Parameters.AddWithValue("@OriginalShippingWeight", originalProduct._shippingWeight);
                sqlCmd.Parameters.AddWithValue("@OriginalActive", originalProduct.Active);

                //If the procedure returns 1 set to true, if 0 remain false.
                if (sqlCmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException. " + ex.Message);
            }
            catch (DataException ex)
            {
                Console.WriteLine("DataException. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GeneralException. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }//End of updateProduct(...)

        public static Boolean ReactivateProduct(Product product, SqlConnection connection)
        {
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("sp_ReactivateProduct", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProductID", product.Id);

                //If the procedure returns 1 set to true, if 0 remain false.
                if (sqlCmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException. " + ex.Message);
            }
            catch (DataException ex)
            {
                Console.WriteLine("DataException. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GeneralException. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }//End of reactivateProduct(..)

        public static Boolean DeactivateProduct(Product product, SqlConnection connection)
        {
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("sp_DeactivateProduct", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProductID", product.Id);

                //If the procedure returns 1 set to true, if 0 remain false.
                if (sqlCmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException. " + ex.Message);
            }
            catch (DataException ex)
            {
                Console.WriteLine("DataException. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GeneralException. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }//End of deactivateProduct(..)

        public static Boolean DeleteProduct(Product product, SqlConnection connection)
        {
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("sp_DeleteProduct", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProductID", product.Id);
                sqlCmd.Parameters.AddWithValue("@OnHand", product.reserved);
                sqlCmd.Parameters.AddWithValue("@Available", product.available);
                sqlCmd.Parameters.AddWithValue("@Description", product.description);
                sqlCmd.Parameters.AddWithValue("@Location", product.location);
                sqlCmd.Parameters.AddWithValue("@UnitPrice", product.unitPrice);
                sqlCmd.Parameters.AddWithValue("@ShortDesc", product.Name);
                sqlCmd.Parameters.AddWithValue("@ReorderThreshold", product._reorderThreshold);
                sqlCmd.Parameters.AddWithValue("@ReorderAmount", product._reorderAmount);
                sqlCmd.Parameters.AddWithValue("@ShippingDimensions", product._shippingDemensions);
                sqlCmd.Parameters.AddWithValue("@ShippingWeight", product._shippingWeight);
                sqlCmd.Parameters.AddWithValue("@Active", product.Active);

                //If the procedure returns 1 set to true, if 0 remain false.
                if (sqlCmd.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException. " + ex.Message);
            }
            catch (DataException ex)
            {
                Console.WriteLine("DataException. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GeneralException. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }//End of deleteProduct(..)

        public static List<Product> FetchProducts(SqlConnection connection)
        {
            List<Product> products = new List<Product>();
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("sp_GetProducts", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                //Creates the reader object by ExecutingReader on the cmd object.
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Product product;
                    while (reader.Read())
                    {
                        product = new Product(reader.GetInt32(0))
                        {
                            available = reader.GetInt32(1),
                            reserved = reader.GetInt32(2),
                            description = reader.GetString(3),
                            location = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            unitPrice = (Decimal)reader.GetSqlMoney(5),
                            Name = reader.GetString(6),
                            _reorderThreshold = reader.GetInt32(7),
                            _reorderAmount = reader.GetInt32(8),
                            _shippingDemensions = reader.GetString(9),
                            _shippingWeight = reader.GetDouble(10),
                            Active = reader.GetBoolean(11)
                        };
                        //Add the current product to the list.
                        products.Add(product);
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException. " + ex.Message);
            }
            catch (DataException ex)
            {
                Console.WriteLine("DataException. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GeneralException. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return products;
        }//End of fetchProducts(.)

        public static Product FetchProduct(int productId, SqlConnection connection)
        {
            Product myProduct = null;
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("sp_GetProduct", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProductID", productId);

                //Creates the reader object by ExecutingReader on the cmd object.
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        myProduct = new Product(reader.GetInt32(0))
                        {
                            available = reader.GetInt32(1),
                            reserved = reader.GetInt32(2),
                            description = reader.GetString(3),
                            location = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            unitPrice = (Decimal)reader.GetSqlMoney(5),
                            Name = reader.GetString(6),
                            _reorderThreshold = reader.GetInt32(7),
                            _reorderAmount = reader.GetInt32(8),
                            _shippingDemensions = reader.GetString(9),
                            _shippingWeight = reader.GetDouble(10),
                            Active = reader.GetBoolean(11)
                        };
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException. " + ex.Message);
            }
            catch (DataException ex)
            {
                Console.WriteLine("DataException. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GeneralException. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return myProduct;
        }//End of fetchProduct(..)

        public static List<Product> FetchProductsByActive(Boolean activeState, SqlConnection connection)
        {
            List<Product> products = new List<Product>();
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("sp_GetProductsByActive", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Active", activeState ? 1 : 0);

                //Creates the reader object by ExecutingReader on the cmd object.
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                         var product = new Product(reader.GetInt32(0))
                        {
                            available = reader.GetInt32(1),
                            reserved = reader.GetInt32(2),
                            description = reader.GetString(3),
                            location = reader.IsDBNull(4) ? "" : reader.GetString(4), 
                            unitPrice = (Decimal)reader.GetSqlMoney(5),
                            Name = reader.GetString(6),
                            _reorderThreshold = reader.GetInt32(7),
                            _reorderAmount = reader.GetInt32(8),
                            _shippingDemensions = reader.GetString(9),
                            _shippingWeight = reader.GetDouble(10),
                            Active = reader.GetBoolean(11)
                        };
                        //Add the current product to the list.
                        products.Add(product);
                        //Null the product reference.
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException. " + ex.Message);
            }
            catch (DataException ex)
            {
                Console.WriteLine("DataException. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GeneralException. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return products;
        }//End of fetchProductsByActive(..)
    }
}