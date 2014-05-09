using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms.VisualStyles;
using com.Farouche.Commons;

namespace com.Farouche.DataAccess
{
    public class VendorOrderDAL : DatabaseConnection
    {

        public static List<VendorOrder> GetAll(SqlConnection connection)
        {
            List<VendorOrder> allOrders = new List<VendorOrder>();
            connection = connection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllVendorOrders", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                var myReader = mySqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        var newVendorOrder = new VendorOrder(myReader.GetInt32(0), myReader.GetInt32(1))
                         {
                             DateOrdered = (DateTime)myReader.GetSqlDateTime(2),
                             NumberOfShipments = myReader.GetInt32(3),
                             Finalized = myReader.GetBoolean(4),
                             Active = myReader.GetBoolean(5)
                         };
                        allOrders.Add(newVendorOrder);
                    };
                }
                myReader.Close();

            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("DatabaseException"), ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("SqlException"), ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("Exception"), ex);
            }
            finally
            {

                connection.Close();
            }
            return allOrders;

        }
        public static List<VendorOrder> GetAllOpenOrders(SqlConnection connection)
        {
            List<VendorOrder> allOpenOrders = new List<VendorOrder>();
            connection = connection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllOpenVendorOrders", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                connection.Open();
                var myReader = mySqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        var newVendorOrder = new VendorOrder(myReader.GetInt32(0), myReader.GetInt32(1))
                        {
                            DateOrdered = (DateTime)myReader.GetSqlDateTime(2),
                            NumberOfShipments = myReader.GetInt32(3),
                            Finalized = myReader.GetBoolean(4)
                        };
                        allOpenOrders.Add(newVendorOrder);
                    };
                }
                myReader.Close();
            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("DatabaseException"), ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("SqlException"), ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("Exception"), ex);
            }
            finally
            {
                connection.Close();
            }
            return allOpenOrders;
        }
        public static List<VendorOrder> GetAllOpenOrdersByVendor(int VendorOrderID, SqlConnection connection)
        {
            List<VendorOrder> allOpenOrders = new List<VendorOrder>();
            connection = connection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllOpenVendorOrdersByVendor", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@VendorId", VendorOrderID);
                connection.Open();
                var myReader = mySqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        var newVendorOrder = new VendorOrder(myReader.GetInt32(0), myReader.GetInt32(1))
                        {
                            DateOrdered = (DateTime)myReader.GetSqlDateTime(2),
                            NumberOfShipments = myReader.GetInt32(3),
                            Finalized = myReader.GetBoolean(4)
                        };
                        allOpenOrders.Add(newVendorOrder);
                    };
                }
                myReader.Close();
            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("DatabaseException"), ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("SqlException"), ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("Exception"), ex);
            }
            finally
            {
                connection.Close();
            }
            return allOpenOrders;
        }
        public static VendorOrder GetVendorOrder(int VendorOrderID, SqlConnection connection)
        {
            VendorOrder newVendorOrder;
            connection = connection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetVendorOrder", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@VendorOrderId", VendorOrderID);
                connection.Open();
                var myReader = mySqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        newVendorOrder = new VendorOrder(myReader.GetInt32(0), myReader.GetInt32(1))
                        {
                            DateOrdered = (DateTime)myReader.GetSqlDateTime(2),
                            NumberOfShipments = myReader.GetInt32(3),
                            Finalized = myReader.GetBoolean(4),
                            Active = myReader.GetBoolean(5)
                        };
                        return newVendorOrder;
                    };
                }
                myReader.Close();
            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("DatabaseException"), ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("SqlException"), ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("Exception"), ex);
            }
            finally
            {
                connection.Close();
            }
                throw new ApplicationException("Vendor Order: " + VendorOrderID + ", not found");
        }
        public static bool Update(VendorOrder oldVendorOrder, VendorOrder newVendorOrder, SqlConnection connection)
        {
            connection = connection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateVendorOrder", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@VendorOrderID", newVendorOrder.Id);
                mySqlCommand.Parameters.AddWithValue("@VendorID", newVendorOrder.VendorID);
                mySqlCommand.Parameters.AddWithValue("@AmountOfShipments", newVendorOrder.NumberOfShipments);
                mySqlCommand.Parameters.AddWithValue("@Finalized", newVendorOrder.Finalized);
                mySqlCommand.Parameters.AddWithValue("@orig_AmountOfShipments", oldVendorOrder.NumberOfShipments);
                mySqlCommand.Parameters.AddWithValue("@orig_Finalized", oldVendorOrder.Finalized);
                connection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("DatabaseException"), ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("SqlException"), ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("Exception"), ex);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public static bool Add(VendorOrder order, SqlConnection connection)
        {
            connection = connection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_InsertVendorOrder", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@VendorID", order.VendorID);
                //mySqlCommand.Parameters.AddWithValue("@DateOrdered", order.DateOrdered.ToString("yyyy-MM-dd HH:mm:ss"));
                mySqlCommand.Parameters.AddWithValue("@NumberOfShipments", order.NumberOfShipments);
                connection.Open();
                if (mySqlCommand.ExecuteNonQuery() == 1)
                {
                    return true;
                }
            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("DatabaseException"), ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("SqlException"), ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("Exception"), ex);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public static VendorOrder GetVendorOrderByVendorAndDate(int vendorId, SqlConnection connection)
        {
            VendorOrder newVendorOrder;
            connection = connection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetVendorOrderByVendorAndDate", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@VendorId", vendorId);
                connection.Open();
                var myReader = mySqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        newVendorOrder = new VendorOrder(myReader.GetInt32(0), myReader.GetInt32(1))
                        {
                            DateOrdered = (DateTime)myReader.GetSqlDateTime(2),
                            NumberOfShipments = myReader.GetInt32(3),
                            Finalized = myReader.GetBoolean(4),
                            Active = myReader.GetBoolean(5)
                        };
                        return newVendorOrder;
                    };
                }
                myReader.Close();
            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("DatabaseException"), ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("SqlException"), ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("Exception"), ex);
            }
            finally
            {
                connection.Close();
            }

            throw new ApplicationException("Vendor Order from vendor: "
                    + vendorId + "not found");
        }
    }
}
