using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms.VisualStyles;
using com.Farouche.Commons;

namespace com.Farouche.DataAccess
{
    public class VendorOrderLineItemDAL : DatabaseConnection
    {
        public static VendorOrderLineItem Get(VendorOrder vendorOrder, Product product, SqlConnection myConnection)
        {

            VendorOrderLineItem vendorOrderLineItem = null;
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetVendorOrderLineItem", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@VendorOrderID", vendorOrder.Id);
                mySqlCommand.Parameters.AddWithValue("@ProductID", product.Id);

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        vendorOrderLineItem = new VendorOrderLineItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            QtyOrdered = mySqlReader.GetInt32(2),
                            QtyReceived = mySqlReader.GetInt32(3),
                            QtyDamaged = mySqlReader.GetInt32(4)
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

            return vendorOrderLineItem;
        }
       
        public static bool Add(VendorOrderLineItem vendorOrderLineItem, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_InsertIntoVendorOrderLineItems", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@ProductID", vendorOrderLineItem.ProductID);
                mySqlCommand.Parameters.AddWithValue("@VendorOrderID", vendorOrderLineItem.VendorOrderId);
                mySqlCommand.Parameters.AddWithValue("@QtyOrdered", vendorOrderLineItem.QtyOrdered);
                mySqlCommand.Parameters.AddWithValue("@QtyReceived", vendorOrderLineItem.QtyReceived);
                mySqlCommand.Parameters.AddWithValue("@QtyDamaged", vendorOrderLineItem.QtyDamaged);
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

        public static List<VendorOrderLineItem> GetAllByVendorOrder(VendorOrder vendorOrder, SqlConnection myConnection)
        {
            var vendorOrderLineItemList = new List<VendorOrderLineItem>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllVendorOrderLineItemsByVendorOrder", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@VendorOrderID", vendorOrder.Id);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                         var vendorOrderLineItem = new VendorOrderLineItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            QtyOrdered = mySqlReader.GetInt32(2),
                            QtyReceived = mySqlReader.GetInt32(3),
                            QtyDamaged = mySqlReader.GetInt32(4)
                        };
                        vendorOrderLineItemList.Add(vendorOrderLineItem);
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

            return vendorOrderLineItemList;
        }

        public static List<VendorOrderLineItem> GetAllByVendor(VendorOrder vendorOrder, SqlConnection myConnection)
        {
            var vendorOrderLineItemList = new List<VendorOrderLineItem>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllVendorOrderLineItemsByVendor", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@VendorID", vendorOrder.VendorID);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var vendorOrderLineItem = new VendorOrderLineItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            QtyOrdered = mySqlReader.GetInt32(2),
                            QtyReceived = mySqlReader.GetInt32(3),
                            QtyDamaged = mySqlReader.GetInt32(4)
                        };
                        vendorOrderLineItemList.Add(vendorOrderLineItem);
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

            return vendorOrderLineItemList;
        }

        public static List<VendorOrderLineItem> GetAll(SqlConnection myConnection)
        {
            var vendorOrderLineItemList = new List<VendorOrderLineItem>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllVendorOrderLineItems", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var vendorOrderLineItem = new VendorOrderLineItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            QtyOrdered = mySqlReader.GetInt32(2),
                            QtyReceived = mySqlReader.GetInt32(3),
                            QtyDamaged = mySqlReader.GetInt32(4)
                        };
                        vendorOrderLineItemList.Add(vendorOrderLineItem);
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

            return vendorOrderLineItemList;
        }

        public static List<VendorOrderLineItem> GetExceptionItems(VendorOrder vendorOrder, SqlConnection myConnection)
        {
            var exceptionItemsList = new List<VendorOrderLineItem>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetExceptionItems", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var vendorOrderLineItem = new VendorOrderLineItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            QtyOrdered = mySqlReader.GetInt32(2),
                            QtyReceived = mySqlReader.GetInt32(3),
                            QtyDamaged = mySqlReader.GetInt32(4)
                        };
                        exceptionItemsList.Add(vendorOrderLineItem);
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

            return exceptionItemsList;
        }

        public static List<VendorOrderLineItem> GetExceptionItemsByVendorOrder(VendorOrder vendorOrder,SqlConnection myConnection)
        {
            var exceptionItemList = new List<VendorOrderLineItem>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetExceptionItemsByVendorOrder", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@VendorOrderID", vendorOrder.Id);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var exceptionItem = new VendorOrderLineItem(mySqlReader.GetInt32(0), mySqlReader.GetInt32(1))
                        {
                            QtyOrdered = mySqlReader.GetInt32(2),
                            QtyReceived = mySqlReader.GetInt32(3),
                            QtyDamaged = mySqlReader.GetInt32(4)
                        };
                        exceptionItemList.Add(exceptionItem);
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

            return exceptionItemList;
        }

        public static bool Update(VendorOrderLineItem oldLineItem, VendorOrderLineItem currentLineItem,SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateVendorOrderLineItems", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@ProductID", currentLineItem.ProductID);
                mySqlCommand.Parameters.AddWithValue("@VendorOrderID", currentLineItem.VendorOrderId);
                mySqlCommand.Parameters.AddWithValue("@QtyOrdered", currentLineItem.QtyOrdered);
                mySqlCommand.Parameters.AddWithValue("@QtyReceived", currentLineItem.QtyReceived);
                mySqlCommand.Parameters.AddWithValue("@QtyDamaged", currentLineItem.QtyDamaged);

                mySqlCommand.Parameters.AddWithValue("@orig_ProductID", oldLineItem.ProductID);
                mySqlCommand.Parameters.AddWithValue("@orig_VendorOrderID", oldLineItem.VendorOrderId);
                mySqlCommand.Parameters.AddWithValue("@orig_QtyOrdered", oldLineItem.QtyOrdered);
                mySqlCommand.Parameters.AddWithValue("@orig_QtyReceived", oldLineItem.QtyReceived);
                mySqlCommand.Parameters.AddWithValue("@orig_QtyDamaged", oldLineItem.QtyDamaged);
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
    }
}
