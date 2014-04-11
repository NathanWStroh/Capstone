using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using com.Farouche.Commons;

//Author: Andrew
//Date Created: 3/2/2014
//Last Modified: 3/8/2014
//Last Modified By: Andrew Willhoit

/*
 *                               Changelog
 * Date         By          Ticket          Version         Description
 * 3/6/14       Andrew                                      Fixed methods
 * 
 * 
*/

namespace com.Farouche.DataAccess
{
    public class ShippingOrderDAL : DatabaseConnection
    {

        public static bool AddShippingOrder(ShippingOrder shippingOrder, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_InsertIntoShippingOrders", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                mySqlCommand.Parameters.AddWithValue("@purchaseOrderID", shippingOrder.PurchaseOrderId);
                mySqlCommand.Parameters.AddWithValue("@userID", shippingOrder.UserId ?? Convert.DBNull); //could be null
                mySqlCommand.Parameters.AddWithValue("@picked", shippingOrder.Picked ? 1 : 0);
                mySqlCommand.Parameters.AddWithValue("@shipDate", (shippingOrder.ShipDate) ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@shippingTermID", shippingOrder.ShippingTermId);                   
                mySqlCommand.Parameters.AddWithValue("@shipToName", shippingOrder.ShipToName ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@shipToAddress", shippingOrder.ShipToAddress ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@shipToCity", shippingOrder.ShipToCity ?? Convert.DBNull); 
                mySqlCommand.Parameters.AddWithValue("@shipToState", shippingOrder.ShipToState ?? Convert.DBNull); 
                mySqlCommand.Parameters.AddWithValue("@shipToZip", shippingOrder.ShipToZip ?? Convert.DBNull); 


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

        } //end AddShippingOrder

        public static bool UpdateShippingOrder(ShippingOrder shippingOrder, ShippingOrder origShippingOrder, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateShippingOrder", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                mySqlCommand.Parameters.AddWithValue("@purchaseOrderID", shippingOrder.PurchaseOrderId);
                mySqlCommand.Parameters.AddWithValue("@userID", shippingOrder.UserId ?? Convert.DBNull); //could be null
                mySqlCommand.Parameters.AddWithValue("@picked", shippingOrder.Picked ? 1 : 0);
                mySqlCommand.Parameters.AddWithValue("@shipDate", (shippingOrder.ShipDate) ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@shippingTermID", shippingOrder.ShippingTermId);
                mySqlCommand.Parameters.AddWithValue("@shipToName", shippingOrder.ShipToName ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@shipToAddress", shippingOrder.ShipToAddress ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@shipToCity", shippingOrder.ShipToCity ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@shipToState", shippingOrder.ShipToState ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@shipToZip", shippingOrder.ShipToZip ?? Convert.DBNull); 

                mySqlCommand.Parameters.AddWithValue("@orig_ShippingOrderID", origShippingOrder.ID);
                mySqlCommand.Parameters.AddWithValue("@orig_PurchaseOrderID", origShippingOrder.PurchaseOrderId);
                mySqlCommand.Parameters.AddWithValue("@orig_UserID", origShippingOrder.UserId ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@orig_Picked", origShippingOrder.Picked ? 1 : 0);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipDate", (origShippingOrder.ShipDate) ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@orig_ShippingTermID", origShippingOrder.ShippingTermId);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipToName", origShippingOrder.ShipToName ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipToAddress", origShippingOrder.ShipToAddress ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipToCity", origShippingOrder.ShipToCity ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipToState", origShippingOrder.ShipToState ?? Convert.DBNull);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipToZip", origShippingOrder.ShipToZip ?? Convert.DBNull); 

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
        } // end UpdateShippingOrder(...)


        public static bool PickShippingOrder(ShippingOrder shippingOrder, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateShippingOrderPicked", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                mySqlCommand.Parameters.AddWithValue("@shippingOrderID", shippingOrder.ID);
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
        } // end PickShippingOrder


        public static bool UnpickShippingOrder(ShippingOrder shippingOrder, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateShippingOrderRemovePicked", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                mySqlCommand.Parameters.AddWithValue("@shippingOrderID", shippingOrder.ID);
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
        } // end UnpickShippingOrder

        // set ShipDate to date shipped
        public static bool ShipShippingOrder(ShippingOrder shippingOrder, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateShippingOrderShipDate", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                mySqlCommand.Parameters.AddWithValue("@shippingOrderID", shippingOrder.ID);
                mySqlCommand.Parameters.AddWithValue("@shipDate", DateTime.Now);
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
        } // end ShipShippingOrder

        // set ShipDate back to null, in case of accidental shipped status
        public static bool UnshipShippingOrder(ShippingOrder shippingOrder, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateShippingOrderRemoveShipDate", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                mySqlCommand.Parameters.AddWithValue("@shippingOrderID", shippingOrder.ID);
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
        } // end unshipShippingOrder


        public static bool AssignShippingOrder(ShippingOrder shippingOrder, int newUserId, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateShippingOrderUser", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
               
                mySqlCommand.Parameters.AddWithValue("@shippingOrderID", shippingOrder.ID);
                mySqlCommand.Parameters.AddWithValue("@newUserID", newUserId);
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
        } // end AssignShippingOrder

        //set userID back to null 
        public static bool UnassignShippingOrder(ShippingOrder shippingOrder, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateShippingOrderRemoveUser", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                mySqlCommand.Parameters.AddWithValue("@shippingOrderID", shippingOrder.ID);
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
        } // end UnassignShippingOrder



        public static List<ShippingOrder> GetAllShippingOrders(SqlConnection myConnection)
        {
            var shippingOrderList = new List<ShippingOrder>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllShippingOrders", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0))
                        {
                            PurchaseOrderId = mySqlReader.GetInt32(1),
                            UserId = mySqlReader[2] as int?,
                            UserLastName = mySqlReader[3] as string,
                            UserFirstName = mySqlReader[4] as string,
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(5),
                            ShipDate = mySqlReader[6] as DateTime?,
                            ShippingTermId = mySqlReader.GetInt32(7),
                            ShippingTermDesc = mySqlReader.GetString(8),
                            ShippingVendorName = mySqlReader.GetString(9),
                            ShipToName = mySqlReader[10] as string,
                            ShipToAddress = mySqlReader[11] as string,
                            ShipToCity = mySqlReader[12] as string,
                            ShipToState = mySqlReader[13] as string,
                            ShipToZip = mySqlReader[14] as string
                        };

                        //var shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0));
                        //shippingOrder.PurchaseOrderId = mySqlReader.GetInt32(1);
                        //shippingOrder.UserId = mySqlReader[2] as int?;
                        //shippingOrder.UserLastName = mySqlReader[3] as string;
                        //shippingOrder.UserFirstName = mySqlReader[4] as string;
                        //shippingOrder.Picked = (Boolean)mySqlReader.GetSqlBoolean(5);
                        //shippingOrder.ShipDate = mySqlReader[6] as DateTime?;
                        //shippingOrder.ShippingTermId = mySqlReader.GetInt32(7);
                        //shippingOrder.ShippingTermDesc = mySqlReader.GetString(8);
                        //shippingOrder.ShippingVendorName = mySqlReader.GetString(9);
                        //shippingOrder.ShipToName = mySqlReader[10] as string;
                        //shippingOrder.ShipToAddress = mySqlReader[11] as string;
                        //shippingOrder.ShipToCity = mySqlReader[12] as string;
                        //shippingOrder.ShipToState = mySqlReader[13] as string;
                        //shippingOrder.ShipToZip = mySqlReader[14] as string;


                        //Add item to list
                        shippingOrderList.Add(shippingOrder);

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
                Console.WriteLine("An Unknown Exception has occurred." + ex.Message + ex.StackTrace);
            }
            finally
            {
                myConnection.Close();
            }

            return shippingOrderList;
        } // end GetAllShippingOrders(..)

        public static List<ShippingOrder> GetAllShippingOrdersPicked(SqlConnection myConnection)
        {
            var shippingOrderList = new List<ShippingOrder>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllShippingOrdersPicked", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0))
                        {
                            PurchaseOrderId = mySqlReader.GetInt32(1),
                            UserId = mySqlReader[2] as int?,
                            UserLastName = mySqlReader[3] as string,
                            UserFirstName = mySqlReader[4] as string,
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(5),
                            ShipDate = mySqlReader[6] as DateTime?,
                            ShippingTermId = mySqlReader.GetInt32(7),
                            ShippingTermDesc = mySqlReader.GetString(8),
                            ShippingVendorName = mySqlReader.GetString(9),
                            ShipToName = mySqlReader[10] as string,
                            ShipToAddress = mySqlReader[11] as string,
                            ShipToCity = mySqlReader[12] as string,
                            ShipToState = mySqlReader[13] as string,
                            ShipToZip = mySqlReader[14] as string
                        };

                        //Add item to list
                        shippingOrderList.Add(shippingOrder);
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

            return shippingOrderList;
        } // end GetAllShippingOrdersPicked(..)

        public static List<ShippingOrder> GetAllShippingOrdersNotPicked(SqlConnection myConnection)
        {
            var shippingOrderList = new List<ShippingOrder>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllShippingOrdersNotPicked", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0))
                        {
                            PurchaseOrderId = mySqlReader.GetInt32(1),
                            UserId = mySqlReader[2] as int?,
                            UserLastName = mySqlReader[3] as string,
                            UserFirstName = mySqlReader[4] as string,
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(5),
                            ShipDate = mySqlReader[6] as DateTime?,
                            ShippingTermId = mySqlReader.GetInt32(7),
                            ShippingTermDesc = mySqlReader.GetString(8),
                            ShippingVendorName = mySqlReader.GetString(9),
                            ShipToName = mySqlReader[10] as string,
                            ShipToAddress = mySqlReader[11] as string,
                            ShipToCity = mySqlReader[12] as string,
                            ShipToState = mySqlReader[13] as string,
                            ShipToZip = mySqlReader[14] as string
                        };

                        //Add item to list
                        shippingOrderList.Add(shippingOrder);
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

            return shippingOrderList;
        } // end GetAllShippingOrdersNotPicked(..)


        public static List<ShippingOrder> GetAllShippingOrdersShipped(SqlConnection myConnection)
        {
            var shippingOrderList = new List<ShippingOrder>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllShippingOrdersShipped", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0))
                        {
                            PurchaseOrderId = mySqlReader.GetInt32(1),
                            UserId = mySqlReader[2] as int?,
                            UserLastName = mySqlReader[3] as string,
                            UserFirstName = mySqlReader[4] as string,
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(5),
                            ShipDate = mySqlReader[6] as DateTime?,
                            ShippingTermId = mySqlReader.GetInt32(7),
                            ShippingTermDesc = mySqlReader.GetString(8),
                            ShippingVendorName = mySqlReader.GetString(9),
                            ShipToName = mySqlReader[10] as string,
                            ShipToAddress = mySqlReader[11] as string,
                            ShipToCity = mySqlReader[12] as string,
                            ShipToState = mySqlReader[13] as string,
                            ShipToZip = mySqlReader[14] as string
                        };

                        //Add item to list
                        shippingOrderList.Add(shippingOrder);
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

            return shippingOrderList;
        } // end GetAllShippingOrdersShipped(..)

        public static List<ShippingOrder> GetAllShippingOrdersNotShipped(SqlConnection myConnection)
        {
            var shippingOrderList = new List<ShippingOrder>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllShippingOrdersNotShipped", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0))
                        {
                            PurchaseOrderId = mySqlReader.GetInt32(1),
                            UserId = mySqlReader[2] as int?,
                            UserLastName = mySqlReader[3] as string,
                            UserFirstName = mySqlReader[4] as string,
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(5),
                            ShipDate = mySqlReader[6] as DateTime?,
                            ShippingTermId = mySqlReader.GetInt32(7),
                            ShippingTermDesc = mySqlReader.GetString(8),
                            ShippingVendorName = mySqlReader.GetString(9),
                            ShipToName = mySqlReader[10] as string,
                            ShipToAddress = mySqlReader[11] as string,
                            ShipToCity = mySqlReader[12] as string,
                            ShipToState = mySqlReader[13] as string,
                            ShipToZip = mySqlReader[14] as string
                        };

                        //Add item to list
                        shippingOrderList.Add(shippingOrder);

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

            return shippingOrderList;
        } // end GetAllShippingOrdersNotShipped(..)


        public static ShippingOrder GetShippingOrderById(int shippingOrderId, SqlConnection myConnection)
        {
            var shippingOrder = new ShippingOrder();
            myConnection = myConnection ?? GetInventoryDbConnection();

            try
            {

                var mySqlCommand = new SqlCommand("proc_GetShippingOrderByID", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@shippingOrderID", shippingOrderId);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0))
                        {
                            PurchaseOrderId = mySqlReader.GetInt32(1),
                            UserId = mySqlReader[2] as int?,
                            UserLastName = mySqlReader[3] as string,
                            UserFirstName = mySqlReader[4] as string,
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(5),
                            ShipDate = mySqlReader[6] as DateTime?,
                            ShippingTermId = mySqlReader.GetInt32(7),
                            ShippingTermDesc = mySqlReader.GetString(8),
                            ShippingVendorName = mySqlReader.GetString(9),
                            ShipToName = mySqlReader[10] as string,
                            ShipToAddress = mySqlReader[11] as string,
                            ShipToCity = mySqlReader[12] as string,
                            ShipToState = mySqlReader[13] as string,
                            ShipToZip = mySqlReader[14] as string
                        };

                        //shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0));
                        //shippingOrder.PurchaseOrderId = mySqlReader.GetInt32(1);
                        //shippingOrder.UserId = mySqlReader.GetInt32(2);
                        //shippingOrder.UserLastName = mySqlReader.GetString(3);
                        //shippingOrder.UserFirstName = mySqlReader.GetString(4);
                        //shippingOrder.Picked = (Boolean)mySqlReader.GetSqlBoolean(5);
                        //shippingOrder.ShipDate = mySqlReader.GetDateTime(6);
                        //shippingOrder.ShippingTermId = mySqlReader.GetInt32(7);
                        //shippingOrder.ShippingTermDesc = mySqlReader.GetString(8);
                        //shippingOrder.ShippingVendorName = mySqlReader.GetString(9);
                        //shippingOrder.ShipToName = mySqlReader[10] as string;
                        //shippingOrder.ShipToAddress = mySqlReader[11] as string;
                        //shippingOrder.ShipToCity = mySqlReader[12] as string;
                        //shippingOrder.ShipToState = mySqlReader[13] as string;
                        //shippingOrder.ShipToZip = mySqlReader[14] as string;

                    } // end while

                
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

            return shippingOrder;

        } // end GetShippingOrderById




        public static ShippingOrder GetShippingOrderByPurchaseOrderId(int purchaseOrderId, SqlConnection myConnection)
        {
            var shippingOrder = new ShippingOrder();
            myConnection = myConnection ?? GetInventoryDbConnection();

            try
            {

                var mySqlCommand = new SqlCommand("proc_GetShippingOrderByPurchaseOrderID", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@purchaseOrderID", purchaseOrderId);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0))
                        {
                            PurchaseOrderId = mySqlReader.GetInt32(1),
                            UserId = mySqlReader[2] as int?,
                            UserLastName = mySqlReader[3] as string,
                            UserFirstName = mySqlReader[4] as string,
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(5),
                            ShipDate = mySqlReader[6] as DateTime?,
                            ShippingTermId = mySqlReader.GetInt32(7),
                            ShippingTermDesc = mySqlReader.GetString(8),
                            ShippingVendorName = mySqlReader.GetString(9),
                            ShipToName = mySqlReader[10] as string,
                            ShipToAddress = mySqlReader[11] as string,
                            ShipToCity = mySqlReader[12] as string,
                            ShipToState = mySqlReader[13] as string,
                            ShipToZip = mySqlReader[14] as string
                        };

                    } // end while


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

            return shippingOrder;

        } // end GetShippingOrderByPurchaseId


        public static List<ShippingOrder> GetAllShippingOrdersByEmployee(int userID, SqlConnection myConnection)
        {
            var shippingOrderList = new List<ShippingOrder>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllShippingOrdersByEmployee", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@userID", userID);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0))
                        {
                            PurchaseOrderId = mySqlReader.GetInt32(1),
                            UserId = mySqlReader[2] as int?,
                            UserLastName = mySqlReader[3] as string,
                            UserFirstName = mySqlReader[4] as string,
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(5),
                            ShipDate = mySqlReader[6] as DateTime?,
                            ShippingTermId = mySqlReader.GetInt32(7),
                            ShippingTermDesc = mySqlReader.GetString(8),
                            ShippingVendorName = mySqlReader.GetString(9),
                            ShipToName = mySqlReader[10] as string,
                            ShipToAddress = mySqlReader[11] as string,
                            ShipToCity = mySqlReader[12] as string,
                            ShipToState = mySqlReader[13] as string,
                            ShipToZip = mySqlReader[14] as string
                        };

                        //Add item to list
                        shippingOrderList.Add(shippingOrder);

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

            return shippingOrderList;
        } // end GetAllShippingOrdersByEmployee(..)




    } // end ShippingOrderDAL class
}
