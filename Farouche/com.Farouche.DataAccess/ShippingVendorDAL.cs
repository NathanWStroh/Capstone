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
 * 4/1/2014     Kaleb                                       Adjusted to account for Active when reading in from the DB.
 * 
 * 4/1/2014     Kaleb                                       Adjusted class to account for activating/deactivating a shipping vendor.
*/

namespace com.Farouche.DataAccess
{
    public class ShippingVendorDAL : DatabaseConnection
    {


        public static bool AddShippingVendor(ShippingVendor shippingVendor, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_InsertIntoShippingVendors", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@name", shippingVendor.Name);
                mySqlCommand.Parameters.AddWithValue("@address", shippingVendor.Address);
                mySqlCommand.Parameters.AddWithValue("@city", shippingVendor.City);
                mySqlCommand.Parameters.AddWithValue("@state", shippingVendor.State);
                mySqlCommand.Parameters.AddWithValue("@country", shippingVendor.Country);
                mySqlCommand.Parameters.AddWithValue("@zip", shippingVendor.Zip);
                mySqlCommand.Parameters.AddWithValue("@phone", shippingVendor.Phone);
                mySqlCommand.Parameters.AddWithValue("@contact", shippingVendor.Contact);
                mySqlCommand.Parameters.AddWithValue("@contactEmail", shippingVendor.ContactEmail);
                myConnection.Open();
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
                myConnection.Close();
            }
            return false; 
        }// end AddShippingVendor


        public static bool UpdateShippingVendor(ShippingVendor shippingVendor,ShippingVendor origShippingVendor, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_UpdateShippingVendor", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                mySqlCommand.Parameters.AddWithValue("@name", shippingVendor.Name);
                mySqlCommand.Parameters.AddWithValue("@address", shippingVendor.Address);
                mySqlCommand.Parameters.AddWithValue("@city", shippingVendor.City);
                mySqlCommand.Parameters.AddWithValue("@state", shippingVendor.State);
                mySqlCommand.Parameters.AddWithValue("@country", shippingVendor.Country);
                mySqlCommand.Parameters.AddWithValue("@zip", shippingVendor.Zip);
                mySqlCommand.Parameters.AddWithValue("@phone", shippingVendor.Phone);
                mySqlCommand.Parameters.AddWithValue("@contact", shippingVendor.Contact);
                mySqlCommand.Parameters.AddWithValue("@contactEmail", shippingVendor.ContactEmail);

                mySqlCommand.Parameters.AddWithValue("@orig_ShippingVendorID", origShippingVendor.Id);
                mySqlCommand.Parameters.AddWithValue("@orig_Name", origShippingVendor.Name);
                mySqlCommand.Parameters.AddWithValue("@orig_Address", origShippingVendor.Address);
                mySqlCommand.Parameters.AddWithValue("@orig_City", origShippingVendor.City);
                mySqlCommand.Parameters.AddWithValue("@orig_State", origShippingVendor.State);
                mySqlCommand.Parameters.AddWithValue("@orig_Country", origShippingVendor.Country);
                mySqlCommand.Parameters.AddWithValue("@orig_Zip", origShippingVendor.Zip);
                mySqlCommand.Parameters.AddWithValue("@orig_Phone", origShippingVendor.Phone);
                mySqlCommand.Parameters.AddWithValue("@orig_Contact", origShippingVendor.Contact);
                mySqlCommand.Parameters.AddWithValue("@orig_ContactEmail", origShippingVendor.ContactEmail);

                myConnection.Open();
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
                myConnection.Close();
            }
            return false;
        }// end UpdateShippingVendor
           

        public static ShippingVendor GetShippingVendorById(int id, SqlConnection myConnection)
        {
            var shippingVendor = new ShippingVendor();
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetShippingVendorByID", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@shippingVendorID", id);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {

                    while (mySqlReader.Read())
                    {
                        shippingVendor = new ShippingVendor(mySqlReader.GetInt32(0))
                        {
                            Name = mySqlReader.GetString(1),
                            Address = mySqlReader.GetString(2),
                            City = mySqlReader.GetString(3),
                            State = mySqlReader.GetString(4),
                            Country = mySqlReader.GetString(5),
                            Zip = mySqlReader.GetString(6),
                            Phone = mySqlReader.GetString(7),
                            Contact = mySqlReader.GetString(8),
                            ContactEmail = mySqlReader.GetString(9),
                            Active = mySqlReader.GetBoolean(10)
                        };
                    }
                }
                mySqlReader.Close();

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
                myConnection.Close();
            }

            return shippingVendor;
        }// end GetShippingVendorById
            

        public static List<ShippingVendor> GetAllShippingVendors(SqlConnection myConnection)
        {
            var shippingVendorList = new List<ShippingVendor>();

            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllShippingVendors", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var shippingVendor = new ShippingVendor(mySqlReader.GetInt32(0))
                        {
                            Name = mySqlReader.GetString(1),
                            Address = mySqlReader.GetString(2),
                            City = mySqlReader.GetString(3),
                            State = mySqlReader.GetString(4),
                            Country = mySqlReader.GetString(5),
                            Zip = mySqlReader.GetString(6),
                            Phone = mySqlReader.GetString(7),
                            Contact = mySqlReader.GetString(8),
                            ContactEmail = mySqlReader.GetString(9),
                            Active = mySqlReader.GetBoolean(10)
                        };

                        //Add item to list
                        shippingVendorList.Add(shippingVendor);
                    }
                }
                mySqlReader.Close();
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
                myConnection.Close();
            }

            return shippingVendorList;
        }// end GetAllShippingVendors

        public static List<ShippingVendor> GetVendorsByActive(Boolean activeState, SqlConnection myConnection)
        {
            var shippingVendorList = new List<ShippingVendor>();
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetShippingVendorsByActive", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@Active", activeState ? 1 : 0);
                myConnection.Open();
                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var shippingVendor = new ShippingVendor(mySqlReader.GetInt32(0))
                        {
                            Name = mySqlReader.GetString(1),
                            Address = mySqlReader.GetString(2),
                            City = mySqlReader.GetString(3),
                            State = mySqlReader.GetString(4),
                            Country = mySqlReader.GetString(5),
                            Zip = mySqlReader.GetString(6),
                            Phone = mySqlReader.GetString(7),
                            Contact = mySqlReader.GetString(8),
                            ContactEmail = mySqlReader.GetString(9),
                            Active = mySqlReader.GetBoolean(10)
                        };

                        //Add item to list
                        shippingVendorList.Add(shippingVendor);
                    }
                }
                mySqlReader.Close();
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
                myConnection.Close();
            }
            return shippingVendorList;
        }//End of FetchTermsByActive(..)

        public static Boolean ReactivateVendor(ShippingVendor vendor, SqlConnection connection)
        {
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("proc_ActivateShippingVendor", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ShippingVendorId", vendor.Id);

                //If the procedure returns 1 set to true, if 0 remain false.
                if (sqlCmd.ExecuteNonQuery() == 1)
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
                conn.Close();
            }
            return false;
        }

        public static Boolean DeactivateVendor(ShippingVendor vendor, SqlConnection connection)
        {
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("proc_DeactivateShippingVendor", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ShippingVendorId", vendor.Id);

                //If the procedure returns 1 set to true, if 0 remain false.
                if (sqlCmd.ExecuteNonQuery() == 1)
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
                conn.Close();
            }
            return false;
        }

        public static Boolean DeleteVendor(ShippingVendor vendor, SqlConnection connection)
        {
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("proc_DeleteShippingVendor", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ShippingVendorId", vendor.Id);
                sqlCmd.Parameters.AddWithValue("@Name", vendor.Name);
                sqlCmd.Parameters.AddWithValue("@Address", vendor.Address);
                sqlCmd.Parameters.AddWithValue("@City", vendor.City);
                sqlCmd.Parameters.AddWithValue("@State", vendor.State);
                sqlCmd.Parameters.AddWithValue("@Zip", vendor.Zip);
                sqlCmd.Parameters.AddWithValue("@Phone", vendor.Phone);
                sqlCmd.Parameters.AddWithValue("@Contact", vendor.Contact);
                sqlCmd.Parameters.AddWithValue("@ContactEmail", vendor.ContactEmail);
                sqlCmd.Parameters.AddWithValue("@Active", vendor.Active);
                //If the procedure returns 1 set to true, if 0 remain false.
                if (sqlCmd.ExecuteNonQuery() == 1)
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
                conn.Close();
            }
            return false;
        }
    }
}
