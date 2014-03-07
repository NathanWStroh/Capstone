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
                //TODO - verify these @param names are correct
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", shippingOrder.ID);
                mySqlCommand.Parameters.AddWithValue("@ProductID", shippingOrder.PurchaseOrderId);
                mySqlCommand.Parameters.AddWithValue("@ProductName", shippingOrder.UserId);
                mySqlCommand.Parameters.AddWithValue("@Picked", shippingOrder.Picked ? 1 : 0); //Change to bit, Ternary Operator 
                mySqlCommand.Parameters.AddWithValue("@ShipDate", (SqlDateTime)shippingOrder.ShipDate);
                mySqlCommand.Parameters.AddWithValue("@ShippingTermID", shippingOrder.ShippingTermId);
                mySqlCommand.Parameters.AddWithValue("@ShipToName", shippingOrder.ShipToName);
                mySqlCommand.Parameters.AddWithValue("@ShipToAddress", shippingOrder.ShipToAddress);
                mySqlCommand.Parameters.AddWithValue("@ShipToCity", shippingOrder.ShipToCity);
                mySqlCommand.Parameters.AddWithValue("@ShipToState", shippingOrder.ShipToState);
                mySqlCommand.Parameters.AddWithValue("@ShipToZip", shippingOrder.ShipToZip);

                // need a way to add shippingOrder.ShippingOrderLineItemList to database???

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
                //TODO - verify these @param names are correct
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", shippingOrder.ID);
                mySqlCommand.Parameters.AddWithValue("@ProductID", shippingOrder.PurchaseOrderId);
                mySqlCommand.Parameters.AddWithValue("@ProductName", shippingOrder.UserId);
                mySqlCommand.Parameters.AddWithValue("@Picked", shippingOrder.Picked ? 1 : 0); //Change to bit, Ternary Operator 
                mySqlCommand.Parameters.AddWithValue("@ShipDate", (SqlDateTime)shippingOrder.ShipDate);
                mySqlCommand.Parameters.AddWithValue("@ShippingTermID", shippingOrder.ShippingTermId);
                mySqlCommand.Parameters.AddWithValue("@ShipToName", shippingOrder.ShipToName);
                mySqlCommand.Parameters.AddWithValue("@ShipToAddress", shippingOrder.ShipToAddress);
                mySqlCommand.Parameters.AddWithValue("@ShipToCity", shippingOrder.ShipToCity);
                mySqlCommand.Parameters.AddWithValue("@ShipToState", shippingOrder.ShipToState);
                mySqlCommand.Parameters.AddWithValue("@ShipToZip", shippingOrder.ShipToZip);

                mySqlCommand.Parameters.AddWithValue("@orig_ShippingOrderID", origShippingOrder.ID);
                mySqlCommand.Parameters.AddWithValue("@orig_ProductID", origShippingOrder.PurchaseOrderId);
                mySqlCommand.Parameters.AddWithValue("@orig_ProductName", origShippingOrder.UserId);
                mySqlCommand.Parameters.AddWithValue("@orig_Picked", origShippingOrder.Picked ? 1 : 0); //Change to bit, Ternary Operator 
                mySqlCommand.Parameters.AddWithValue("@orig_ShipDate", (SqlDateTime)origShippingOrder.ShipDate);
                mySqlCommand.Parameters.AddWithValue("@orig_ShippingTermID", origShippingOrder.ShippingTermId);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipToName", origShippingOrder.ShipToName);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipToAddress", origShippingOrder.ShipToAddress);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipToCity", origShippingOrder.ShipToCity);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipToState", origShippingOrder.ShipToState);
                mySqlCommand.Parameters.AddWithValue("@orig_ShipToZip", origShippingOrder.ShipToZip);

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
                var mySqlCommand = new SqlCommand("proc_PickShippingOrder", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //TODO - verify these @param names are correct
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", shippingOrder.ID);
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
                var mySqlCommand = new SqlCommand("proc_UnpickShippingOrder", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //TODO - verify these @param names are correct
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", shippingOrder.ID);
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
                var mySqlCommand = new SqlCommand("proc_ShipShippingOrder", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //TODO - verify these @param names are correct
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", shippingOrder.ID);
                mySqlCommand.Parameters.AddWithValue("@ShipDate", shippingOrder.ShipDate);
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
                var mySqlCommand = new SqlCommand("proc_UnpickShippingOrder", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //TODO - verify these @param names are correct
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", shippingOrder.ID);
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
                var mySqlCommand = new SqlCommand("proc_AssignShippingOrder", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //TODO - verify these @param names are correct
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", shippingOrder.ID);
                mySqlCommand.Parameters.AddWithValue("@NewUserID", newUserId);
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
                var mySqlCommand = new SqlCommand("proc_UnassignShippingOrder", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //TODO - verify these @param names are correct
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", shippingOrder.ID);
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
                            UserId = mySqlReader.GetInt32(2),
                            UserName = mySqlReader.GetString(3),
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(4),
                            ShipDate = (DateTime)mySqlReader.GetSqlDateTime(5),
                            ShippingTermId = mySqlReader.GetInt32(6),
                            ShippingTermDesc = mySqlReader.GetString(7),
                            ShippingVendorName = mySqlReader.GetString(8),
                            ShipToName = mySqlReader.GetString(9),
                            ShipToAddress = mySqlReader.GetString(10),
                            ShipToState = mySqlReader.GetString(11),
                            ShipToZip = mySqlReader.GetString(12)

                        };
                        //populates the LineItemsList
                        shippingOrder.ShippingOrderLineItemList = ShippingOrderLineItemDAL.GetShippingOrderLineItemsById(shippingOrder.ID,myConnection);
                       
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
                            UserId = mySqlReader.GetInt32(2),
                            UserName = mySqlReader.GetString(3),
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(4),
                            ShipDate = (DateTime)mySqlReader.GetSqlDateTime(5),
                            ShippingTermId = mySqlReader.GetInt32(6),
                            ShippingTermDesc = mySqlReader.GetString(7),
                            ShippingVendorName = mySqlReader.GetString(8),
                            ShipToName = mySqlReader.GetString(9),
                            ShipToAddress = mySqlReader.GetString(10),
                            ShipToState = mySqlReader.GetString(11),
                            ShipToZip = mySqlReader.GetString(12)

                        };
                        //populates the LineItemsList
                        shippingOrder.ShippingOrderLineItemList = ShippingOrderLineItemDAL.GetShippingOrderLineItemsById(shippingOrder.ID, myConnection);

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
                            UserId = mySqlReader.GetInt32(2),
                            UserName = mySqlReader.GetString(3),
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(4),
                            ShipDate = (DateTime)mySqlReader.GetSqlDateTime(5),
                            ShippingTermId = mySqlReader.GetInt32(6),
                            ShippingTermDesc = mySqlReader.GetString(7),
                            ShippingVendorName = mySqlReader.GetString(8),
                            ShipToName = mySqlReader.GetString(9),
                            ShipToAddress = mySqlReader.GetString(10),
                            ShipToState = mySqlReader.GetString(11),
                            ShipToZip = mySqlReader.GetString(12)

                        };
                        //populates the LineItemsList
                        shippingOrder.ShippingOrderLineItemList = ShippingOrderLineItemDAL.GetShippingOrderLineItemsById(shippingOrder.ID, myConnection);

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
                            UserId = mySqlReader.GetInt32(2),
                            UserName = mySqlReader.GetString(3),
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(4),
                            ShipDate = (DateTime)mySqlReader.GetSqlDateTime(5),
                            ShippingTermId = mySqlReader.GetInt32(6),
                            ShippingTermDesc = mySqlReader.GetString(7),
                            ShippingVendorName = mySqlReader.GetString(8),
                            ShipToName = mySqlReader.GetString(9),
                            ShipToAddress = mySqlReader.GetString(10),
                            ShipToState = mySqlReader.GetString(11),
                            ShipToZip = mySqlReader.GetString(12)

                        };
                        //populates the LineItemsList
                        shippingOrder.ShippingOrderLineItemList = ShippingOrderLineItemDAL.GetShippingOrderLineItemsById(shippingOrder.ID, myConnection);

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
                            UserId = mySqlReader.GetInt32(2),
                            UserName = mySqlReader.GetString(3),
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(4),
                            ShipDate = (DateTime)mySqlReader.GetSqlDateTime(5),
                            ShippingTermId = mySqlReader.GetInt32(6),
                            ShippingTermDesc = mySqlReader.GetString(7),
                            ShippingVendorName = mySqlReader.GetString(8),
                            ShipToName = mySqlReader.GetString(9),
                            ShipToAddress = mySqlReader.GetString(10),
                            ShipToState = mySqlReader.GetString(11),
                            ShipToZip = mySqlReader.GetString(12)

                        };
                        //populates the LineItemsList
                        shippingOrder.ShippingOrderLineItemList = ShippingOrderLineItemDAL.GetShippingOrderLineItemsById(shippingOrder.ID, myConnection);

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

                var mySqlCommand = new SqlCommand("proc_GetShippingOrderById", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@ShippingOrderID", shippingOrderId);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0))
                        {
                            PurchaseOrderId = mySqlReader.GetInt32(1),
                            UserId = mySqlReader.GetInt32(2),
                            UserName = mySqlReader.GetString(3),
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(4),
                            ShipDate = (DateTime)mySqlReader.GetSqlDateTime(5),
                            ShippingTermId = mySqlReader.GetInt32(6),
                            ShippingTermDesc = mySqlReader.GetString(7),
                            ShippingVendorName = mySqlReader.GetString(8),
                            ShipToName = mySqlReader.GetString(9),
                            ShipToAddress = mySqlReader.GetString(10),
                            ShipToState = mySqlReader.GetString(11),
                            ShipToZip = mySqlReader.GetString(12)
                        };

                        //populates the LineItemsList
                        shippingOrder.ShippingOrderLineItemList = ShippingOrderLineItemDAL.GetShippingOrderLineItemsById(shippingOrder.ID, myConnection);
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

                var mySqlCommand = new SqlCommand("proc_GetShippingOrder", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@PurchaseOrderID", purchaseOrderId);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        shippingOrder = new ShippingOrder(mySqlReader.GetInt32(0))
                        {
                            PurchaseOrderId = mySqlReader.GetInt32(1),
                            UserId = mySqlReader.GetInt32(2),
                            UserName = mySqlReader.GetString(3),
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(4),
                            ShipDate = (DateTime)mySqlReader.GetSqlDateTime(5),
                            ShippingTermId = mySqlReader.GetInt32(6),
                            ShippingTermDesc = mySqlReader.GetString(7),
                            ShippingVendorName = mySqlReader.GetString(8),
                            ShipToName = mySqlReader.GetString(9),
                            ShipToAddress = mySqlReader.GetString(10),
                            ShipToState = mySqlReader.GetString(11),
                            ShipToZip = mySqlReader.GetString(12)
                        };

                        //populates the LineItemsList
                        shippingOrder.ShippingOrderLineItemList = ShippingOrderLineItemDAL.GetShippingOrderLineItemsById(shippingOrder.ID, myConnection);
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
                            UserId = mySqlReader.GetInt32(2),
                            UserName = mySqlReader.GetString(3),
                            Picked = (Boolean)mySqlReader.GetSqlBoolean(4),
                            ShipDate = (DateTime)mySqlReader.GetSqlDateTime(5),
                            ShippingTermId = mySqlReader.GetInt32(6),
                            ShippingTermDesc = mySqlReader.GetString(7),
                            ShippingVendorName = mySqlReader.GetString(8),
                            ShipToName = mySqlReader.GetString(9),
                            ShipToAddress = mySqlReader.GetString(10),
                            ShipToState = mySqlReader.GetString(11),
                            ShipToZip = mySqlReader.GetString(12)

                        };
                        //populates the LineItemsList
                        shippingOrder.ShippingOrderLineItemList = ShippingOrderLineItemDAL.GetShippingOrderLineItemsById(shippingOrder.ID, myConnection);

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
