using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using com.Farouche.Commons;
//Author: Adam
//Date Created: 1/31/2014
//Last Modified: 2/14/2014
//Last Modified By: Adam Chandler

/*
 *                               Changelog
 * Date         By          Ticket          Version         Description
 * 2/14/2014   Adam                          0.0.2         Updated to use mintQtyToOrder,itemsPerCase and removal of pk id
 * 02/7/2014   Adam                          0.0.1b        Removed myConnection being passed in from Manager
 * 
*/
namespace com.Farouche.DataAccess
{
    public class VendorSourceItemDAL : DatabaseConnection
    {
        public static bool AddVendorSourceItem(VendorSourceItem vendorSrcItem, SqlConnection myConnection)
        {
            //Questional usage of ?? its incase myConnection comes in null it will grab a new connection.
            //Thoughts?
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("sp_InsertIntoVendorSourceItems", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@productID", vendorSrcItem.ProductID);
                mySqlCommand.Parameters.AddWithValue("@vendorID", vendorSrcItem.VendorID);
                mySqlCommand.Parameters.AddWithValue("@unitCost", vendorSrcItem.UnitCost);
                mySqlCommand.Parameters.AddWithValue("@minQtyToOrder", vendorSrcItem.MinQtyToOrder);
                mySqlCommand.Parameters.AddWithValue("@itemsPerCase", vendorSrcItem.ItemsPerCase);
                mySqlCommand.Parameters.AddWithValue("@active", vendorSrcItem.Active ? 1 : 0); //Change to bit, Ternary Operator 
                myConnection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (DataException ex)
            {
                Console.WriteLine("A Data Exception Has Occurred." + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("A Database Connection Error Has occurred." + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Unknown Exception has occurred." + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return false;
        }
        public static bool UpdateVendorSourceItem(VendorSourceItem vendorSrcItem, VendorSourceItem origVendorSrcItem, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                //Talk about checking data first in sql, Passing the old data and verifiy its still the same.
                var mySqlCommand = new SqlCommand("sp_UpdateVendorSourceItem", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@productID", vendorSrcItem.ProductID);
                mySqlCommand.Parameters.AddWithValue("@vendorID", vendorSrcItem.VendorID);
                mySqlCommand.Parameters.AddWithValue("@unitCost", vendorSrcItem.UnitCost);
                mySqlCommand.Parameters.AddWithValue("@minQtyToOrder", vendorSrcItem.MinQtyToOrder);
                mySqlCommand.Parameters.AddWithValue("@itemsPerCase", vendorSrcItem.ItemsPerCase);
                mySqlCommand.Parameters.AddWithValue("@orig_productID", origVendorSrcItem.ProductID);
                mySqlCommand.Parameters.AddWithValue("@orig_vendorID", origVendorSrcItem.VendorID);
                mySqlCommand.Parameters.AddWithValue("@orig_unitCost", origVendorSrcItem.UnitCost);
                mySqlCommand.Parameters.AddWithValue("@orig_minQtyToOrder", origVendorSrcItem.MinQtyToOrder);
                mySqlCommand.Parameters.AddWithValue("@orig_itemsPerCase", origVendorSrcItem.ItemsPerCase);
                myConnection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }

            }
            catch (DataException ex)
            {
                Console.WriteLine("A Data Exception Has Occurred." + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("A Database Connection Error Has occurred." + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Unknown Exception has occurred." + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return false;
        }
        public static bool DeactivateVendorSourceItem(VendorSourceItem vendorSrcItem, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_DeactivateVendorSourceItem", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@productID", vendorSrcItem.ProductID);
                mySqlCommand.Parameters.AddWithValue("@vendorID", vendorSrcItem.VendorID);
                myConnection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }

            }
            catch (DataException ex)
            {
                Console.WriteLine("A Data Exception Has Occurred." + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("A Database Connection Error Has occurred." + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Unknown Exception has occurred." + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return false;
        }
        public static bool ReactivateVendorSourceItem(VendorSourceItem vendorSrcItem, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("sp_ReactivateVendorSourceItem", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@productID", vendorSrcItem.ProductID);
                mySqlCommand.Parameters.AddWithValue("@vendorID", vendorSrcItem.VendorID);
                myConnection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }

            }
            catch (DataException ex)
            {
                Console.WriteLine("A Data Exception Has Occurred." + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("A Database Connection Error Has occurred." + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Unknown Exception has occurred." + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return false;
        }
        //Deletes VendorSourceItem, Two Step delete. 
        public static bool DeleteVendorSourceItem(VendorSourceItem vendorSrcItem, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_DeleteVendorSourceItem", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@productID", vendorSrcItem.ProductID);
                mySqlCommand.Parameters.AddWithValue("@vendorID", vendorSrcItem.VendorID);
                myConnection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }

            }
            catch (DataException ex)
            {
                Console.WriteLine("A Data Exception Has Occurred." + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("A Database Connection Error Has occurred." + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Unknown Exception has occurred." + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }
            return false;
        }

        public static List<VendorSourceItem> GetAllVendorSourceItems(SqlConnection myConnection)
        {
            var vendorSourceItemList = new List<VendorSourceItem>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllVendorSourceItems", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var vendorSrcItem = new VendorSourceItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            UnitCost = (Decimal) mySqlReader.GetSqlMoney(2),
                            MinQtyToOrder = mySqlReader.GetInt32(3),
                            ItemsPerCase =  mySqlReader.GetInt32(4),
                            Active = true
                        };

                        //Add item to list
                        vendorSourceItemList.Add(vendorSrcItem);

                    }

                }

                mySqlReader.Close();

            }
            catch (DataException ex)
            {
                Console.WriteLine("A Data Exception Has Occurred." + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("A Database Connection Error Has occurred." + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Unknown Exception has occurred." + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return vendorSourceItemList;
        }
        public static VendorSourceItem GetVendorSourceItem(int vendorSrcItemId, SqlConnection myConnection)
        {
            var vendorSrcItem = new VendorSourceItem();
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("sp_GetVendorSourceItem", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@productID", vendorSrcItem.ProductID);
                mySqlCommand.Parameters.AddWithValue("@vendorID", vendorSrcItem.VendorID);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {

                    while (mySqlReader.Read())
                    {
                        vendorSrcItem = new VendorSourceItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            UnitCost = (Decimal) mySqlReader.GetSqlMoney(2),
                            MinQtyToOrder = mySqlReader.GetInt32(3),
                            ItemsPerCase = mySqlReader.GetInt32(4),
                            Active = (Boolean) mySqlReader.GetSqlBoolean(5)
                        };
                    }

                }

                mySqlReader.Close();

            }
            catch (DataException ex)
            {
                Console.WriteLine("A Data Exception Has Occurred." + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("A Database Connection Error Has occurred." + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Unknown Exception has occurred." + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return vendorSrcItem;
        }
        public static List<VendorSourceItem> GetVendorSourceItemsByVendor(int vendorId, SqlConnection myConnection)
        {
            var vendorSourceItemList = new List<VendorSourceItem>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("sp_GetVendorSourceItemsByVendor", myConnection);
                mySqlCommand.Parameters.AddWithValue("@vendorID", vendorId);
                mySqlCommand.CommandType = CommandType.StoredProcedure;

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var vendorSrcItem = new VendorSourceItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            UnitCost = (Decimal) mySqlReader.GetSqlMoney(2),
                            MinQtyToOrder = mySqlReader.GetInt32(3),
                            ItemsPerCase = mySqlReader.GetInt32(4),
                            Active = true
                        };

                        //Add item to list
                        vendorSourceItemList.Add(vendorSrcItem);
                    }

                }

                mySqlReader.Close();

            }
            catch (DataException ex)
            {
                Console.WriteLine("A Data Exception Has Occurred." + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("A Database Connection Error Has occurred." + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Unknown Exception has occurred." + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return vendorSourceItemList;
        }
        public static List<VendorSourceItem> GetVendorSourceItemsByProduct(int productId, SqlConnection myConnection)
        {
            var vendorSourceItemList = new List<VendorSourceItem>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("sp_GetVendorSourceItemsByProduct", myConnection);
                mySqlCommand.Parameters.AddWithValue("@productID", productId);
                mySqlCommand.CommandType = CommandType.StoredProcedure;

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var vendorSrcItem = new VendorSourceItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            UnitCost = (Decimal) mySqlReader.GetSqlMoney(2),
                            MinQtyToOrder = mySqlReader.GetInt32(3),
                            ItemsPerCase = mySqlReader.GetInt32(4),
                            Name = mySqlReader.GetString(5),
                            Active = true
                        };

                        //Add item to list
                        vendorSourceItemList.Add(vendorSrcItem);
                    }

                }

                mySqlReader.Close();

            }
            catch (DataException ex)
            {
                Console.WriteLine("A Data Exception Has Occurred." + ex.Message);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("A Database Connection Error Has occurred." + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Unknown Exception has occurred." + ex.Message);
            }
            finally
            {
                myConnection.Close();
            }

            return vendorSourceItemList;
        }
    }

}
