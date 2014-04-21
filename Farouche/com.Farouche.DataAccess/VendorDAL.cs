using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using com.Farouche.Commons;
//Author: Andrew Willhoit
//Date Created: 1/31/2014
//Last Modified: 02/9/2014 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/09/2014  Andrew                       0.0.2          Updated to pass in connection, added CRUD methods
* 02/07/2014  Andrew                       0.0.1b         Updated to latest coding standards
* 02/07/2014   Adam                        0.0.1b         Updated Instantiation of new objects to use id as parameter
*/
namespace com.Farouche.DataAccess
{
    public class VendorDAL : DatabaseConnection
    {

        public static Boolean AddVendor(Vendor vendor, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                SqlCommand mySqlCommand = new SqlCommand("proc_InsertIntoVendor", myConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("@Name", vendor.Name);
                mySqlCommand.Parameters.AddWithValue("@Address", vendor.Address);
                mySqlCommand.Parameters.AddWithValue("@City", vendor.City);
                mySqlCommand.Parameters.AddWithValue("@State", vendor.State);
                mySqlCommand.Parameters.AddWithValue("@Country", vendor.Country);
                mySqlCommand.Parameters.AddWithValue("@Zip", vendor.Zip);
                mySqlCommand.Parameters.AddWithValue("@Phone", vendor.Phone);
                mySqlCommand.Parameters.AddWithValue("@Contact", vendor.Contact);
                mySqlCommand.Parameters.AddWithValue("@ContactEmail", vendor.ContactEmail);

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
        } // end AddVendorObject(..)

        public static Vendor GetVendor(int vendorId, SqlConnection myConnection)  //untested - 2/6/14 AJW
        {
            Vendor vendor = new Vendor();
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                SqlCommand mySqlCommand = new SqlCommand("proc_GetVendor", myConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("@VendorID", vendorId);
                myConnection.Open();

                SqlDataReader mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {

                    while (mySqlReader.Read())
                    {
                        vendor = new Vendor(mySqlReader.GetInt32(0));
                        vendor.Name = mySqlReader.GetString(1);
                        vendor.Address = mySqlReader.GetString(2);
                        vendor.City = mySqlReader.GetString(3);
                        vendor.State = mySqlReader.GetString(4);
                        vendor.Country = mySqlReader.GetString(5);
                        vendor.Zip = mySqlReader.GetString(6);
                        vendor.Phone = mySqlReader.GetString(7);
                        vendor.Contact = mySqlReader.GetString(8);
                        vendor.ContactEmail = mySqlReader.GetString(9);
                        vendor.Active = (Boolean)mySqlReader.GetSqlBoolean(10);
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

            return vendor;
        } // end GetVendor(..)

        public static List<Vendor> GetAllVendors(SqlConnection myConnection)
        {
            List<Vendor> VendorList = new List<Vendor>();
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                SqlCommand mySqlCommand = new SqlCommand("proc_GetVendors", myConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                myConnection.Open();

                SqlDataReader mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    Vendor vendor;
                    while (mySqlReader.Read())
                    {
                        vendor = new Vendor(mySqlReader.GetInt32(0));
                        vendor.Name = mySqlReader.GetString(1);
                        vendor.Address = mySqlReader.GetString(2);
                        vendor.City = mySqlReader.GetString(3);
                        vendor.State = mySqlReader.GetString(4);
                        vendor.Country = mySqlReader.GetString(5);
                        vendor.Zip = mySqlReader.GetString(6);
                        vendor.Phone = mySqlReader.GetString(7);
                        vendor.Contact = mySqlReader.GetString(8);
                        vendor.ContactEmail = mySqlReader.GetString(9);
                        vendor.Active = (Boolean)mySqlReader.GetSqlBoolean(10);

                        VendorList.Add(vendor);
                        vendor = null;
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

            return VendorList;
        } // end GetAllVendors(.)

        public static List<Vendor> GetAllVendorsByActive(Boolean active, SqlConnection myConnection)
        {
            List<Vendor> VendorList = new List<Vendor>();
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                SqlCommand mySqlCommand = new SqlCommand("proc_GetVendorsByActive", myConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("Active", active ? 1 : 0);
                myConnection.Open();

                SqlDataReader mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    Vendor vendor;
                    while (mySqlReader.Read())
                    {
                        vendor = new Vendor(mySqlReader.GetInt32(0));
                        vendor.Name = mySqlReader.GetString(1);
                        vendor.Address = mySqlReader.GetString(2);
                        vendor.City = mySqlReader.GetString(3);
                        vendor.State = mySqlReader.GetString(4);
                        vendor.Country = mySqlReader.GetString(5);
                        vendor.Zip = mySqlReader.GetString(6);
                        vendor.Phone = mySqlReader.GetString(7);
                        vendor.Contact = mySqlReader.GetString(8);
                        vendor.ContactEmail = mySqlReader.GetString(9);
                        vendor.Active = (Boolean)mySqlReader.GetSqlBoolean(10);

                        VendorList.Add(vendor);
                        vendor = null;
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

            return VendorList;
        } // end GetAllVendorsByActive(..)

        public static Boolean UpdateVendor(Vendor vendor, Vendor origVendor, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                SqlCommand mySqlCommand = new SqlCommand("proc_UpdateVendor", myConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("@Name", vendor.Name);
                mySqlCommand.Parameters.AddWithValue("@Address", vendor.Address);
                mySqlCommand.Parameters.AddWithValue("@City", vendor.City);
                mySqlCommand.Parameters.AddWithValue("@State", vendor.State);
                mySqlCommand.Parameters.AddWithValue("@Country", vendor.Contact);
                mySqlCommand.Parameters.AddWithValue("@Zip", vendor.Zip);
                mySqlCommand.Parameters.AddWithValue("@Phone", vendor.Phone);
                mySqlCommand.Parameters.AddWithValue("@Contact", vendor.Contact);
                mySqlCommand.Parameters.AddWithValue("@ContactEmail", vendor.ContactEmail);
                mySqlCommand.Parameters.AddWithValue("@original_VendorID", origVendor.Id);
                mySqlCommand.Parameters.AddWithValue("@original_Name", origVendor.Name);
                mySqlCommand.Parameters.AddWithValue("@original_Address", origVendor.Address);
                mySqlCommand.Parameters.AddWithValue("@original_City", origVendor.City);
                mySqlCommand.Parameters.AddWithValue("@original_State", origVendor.State);
                mySqlCommand.Parameters.AddWithValue("@original_Country", origVendor.Country);
                mySqlCommand.Parameters.AddWithValue("@original_Zip", origVendor.Zip);
                mySqlCommand.Parameters.AddWithValue("@original_Phone", origVendor.Phone);
                mySqlCommand.Parameters.AddWithValue("@original_Contact", origVendor.Contact);
                mySqlCommand.Parameters.AddWithValue("@original_ContactEmail", origVendor.ContactEmail);
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
        } // end UpdateVendor(...)

        public static bool DeactivateVendor(Vendor vendor, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                SqlCommand mySqlCommand = new SqlCommand("proc_DeactivateVendor", myConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("@VendorID", vendor.Id);
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
        } // end DeactivateVendor(..)

        public static bool ReactivateVendor(Vendor vendor, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                SqlCommand mySqlCommand = new SqlCommand("proc_ReactivateVendor", myConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("@VendorID", vendor.Id);
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
        } // end ReactivateVendor(..)

        public static bool DeleteVendor(Vendor vendor, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                SqlCommand mySqlCommand = new SqlCommand("proc_DeleteVendor", myConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                mySqlCommand.Parameters.AddWithValue("@VendorID", vendor.Id);
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
        } // end DeleteVendor(..)
    } // end class VendorData
} // end namespace
