using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using com.Farouche.Commons;

//Author: Andrew
//Date Created: 3/2/2014
//Last Modified: 3/2/2014
//Last Modified By: Andrew Willhoit

/*
 *                               Changelog
 * Date         By          Ticket          Version         Description
 * 
 * 
 * 
*/

namespace com.Farouche.DataAccess
{
    public class ShippingOrderLineItemDAL : DatabaseConnection
    {

        public static bool AddShippingOrderLineItems(ShippingOrderLineItem lineItem, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_InsertIntoShippingOrderLineItems", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //TODO - verify these @param names are correct
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", lineItem.ShippingOrderID);
                mySqlCommand.Parameters.AddWithValue("@ProductID", lineItem.ProductId);
                mySqlCommand.Parameters.AddWithValue("@ProductName", lineItem.ProductName);
                mySqlCommand.Parameters.AddWithValue("@Quantity", lineItem.Quantity);
                mySqlCommand.Parameters.AddWithValue("@ProductLocation", lineItem.ProductLocation);
                mySqlCommand.Parameters.AddWithValue("@Picked", lineItem.IsPicked ? 1 : 0); //Change to bit, Ternary Operator 
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
        } // end AddShippingOrderLineItems(..)

	    public static bool UpdateShippingOrderLineItem(ShippingOrderLineItem lineItem, ShippingOrderLineItem origLineItem, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateShippingOrderLineItem", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", lineItem.ShippingOrderID);
                mySqlCommand.Parameters.AddWithValue("@ProductID", lineItem.ProductId);
                mySqlCommand.Parameters.AddWithValue("@ProductName", lineItem.ProductName);
                mySqlCommand.Parameters.AddWithValue("@Quantity", lineItem.Quantity);
                mySqlCommand.Parameters.AddWithValue("@ProductLocation", lineItem.ProductLocation);

                mySqlCommand.Parameters.AddWithValue("@orig_ShippingOrderID", lineItem.ShippingOrderID);
                mySqlCommand.Parameters.AddWithValue("@orig_ProductID", lineItem.ProductId);
                mySqlCommand.Parameters.AddWithValue("@orig_ProductName", lineItem.ProductName);
                mySqlCommand.Parameters.AddWithValue("@orig_Quantity", lineItem.Quantity);
                mySqlCommand.Parameters.AddWithValue("@orig_ProductLocation", lineItem.ProductLocation);

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
        } // end UpdateShippingOrderLineItem(...)


	    public static bool PickShippingOrderLineItem(ShippingOrderLineItem lineItem, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_PickShippingOrderLineItem", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", lineItem.ShippingOrderID);
                mySqlCommand.Parameters.AddWithValue("@ProductID", lineItem.ProductId);
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
        } //end PickShippingOrderLineItem(..)

	    public static bool UnpickShippingOrderLineItem(ShippingOrderLineItem lineItem, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UnpickShippingOrderLineItem", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", lineItem.ShippingOrderID);
                mySqlCommand.Parameters.AddWithValue("@ProductID", lineItem.ProductId);
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
        } //end UnpickShippingOrderLineItem(..)


	    public static List<ShippingOrderLineItem> GetAllShippingOrderLineItems(SqlConnection myConnection)
        {
            var shippingOrderLineItemList = new List<ShippingOrderLineItem>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try 
	        {	        
		        var mySqlCommand = new SqlCommand("proc_GetAllShippingOrderLineItems", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        // shippingOrderId and productId added in construction below
                        var shippingLineItem = new ShippingOrderLineItem(mySqlReader.GetInt32(0),mySqlReader.GetInt32(1))
                        {
                            ProductName = mySqlReader.GetString(2),
                            Quantity = mySqlReader.GetInt32(3),
                            ProductLocation = mySqlReader.GetString(4),
                            IsPicked = mySqlReader.GetBoolean(5)              
                        };
                
                        shippingOrderLineItemList.Add(shippingLineItem);
                    } //end while
            
                } // end if
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

            return shippingOrderLineItemList;

        } //end GetAllShippingOrderLineItems(.)


	    public static List<ShippingOrderLineItem> GetShippingOrderLineItemsById(int shippingOrderId, SqlConnection myConnection)
        {
            var shippingOrderLineItemList = new List<ShippingOrderLineItem>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetShippingOrderLineItems", myConnection);
                mySqlCommand.Parameters.AddWithValue("@shippingOrderId",shippingOrderId);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
            
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        // shippingOrderId and productId added in construction below
                        var shippingLineItem = new ShippingOrderLineItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            ProductName = mySqlReader.GetString(2),
                            Quantity = mySqlReader.GetInt32(3),
                            ProductLocation = mySqlReader.GetString(4),
                            IsPicked = mySqlReader.GetBoolean(5)
                        };

                        shippingOrderLineItemList.Add(shippingLineItem);
                    } //end while

                } // end if
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

            return shippingOrderLineItemList;

        } //end GetShippingOrderLineItemsById(..)


    } // end ShippingOrderLineItemDAL class
}
