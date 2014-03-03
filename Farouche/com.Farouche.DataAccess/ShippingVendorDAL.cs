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
                mySqlCommand.Parameters.AddWithValue("@ShippingVendorID", shippingVendor.Id);
                mySqlCommand.Parameters.AddWithValue("@Name", shippingVendor.Name);
                mySqlCommand.Parameters.AddWithValue("@Address", shippingVendor.Address);
                mySqlCommand.Parameters.AddWithValue("@City", shippingVendor.City);
                mySqlCommand.Parameters.AddWithValue("@State", shippingVendor.State);
                mySqlCommand.Parameters.AddWithValue("@Zip", shippingVendor.Zip);
                mySqlCommand.Parameters.AddWithValue("@Phone", shippingVendor.Phone);
                mySqlCommand.Parameters.AddWithValue("@Contact", shippingVendor.Contact);
                mySqlCommand.Parameters.AddWithValue("@ContactEmail", shippingVendor.ContactEmail);
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
                mySqlCommand.Parameters.AddWithValue("@ShippingVendorID", shippingVendor.Id);
                mySqlCommand.Parameters.AddWithValue("@Name", shippingVendor.Name);
                mySqlCommand.Parameters.AddWithValue("@Address", shippingVendor.Address);
                mySqlCommand.Parameters.AddWithValue("@City", shippingVendor.City);
                mySqlCommand.Parameters.AddWithValue("@State", shippingVendor.State);
                mySqlCommand.Parameters.AddWithValue("@Zip", shippingVendor.Zip);
                mySqlCommand.Parameters.AddWithValue("@Phone", shippingVendor.Phone);
                mySqlCommand.Parameters.AddWithValue("@Contact", shippingVendor.Contact);
                mySqlCommand.Parameters.AddWithValue("@ContactEmail", shippingVendor.ContactEmail);

                mySqlCommand.Parameters.AddWithValue("@ShippingVendorID", origShippingVendor.Id);
                mySqlCommand.Parameters.AddWithValue("@Name", origShippingVendor.Name);
                mySqlCommand.Parameters.AddWithValue("@Address", origShippingVendor.Address);
                mySqlCommand.Parameters.AddWithValue("@City", origShippingVendor.City);
                mySqlCommand.Parameters.AddWithValue("@State", origShippingVendor.State);
                mySqlCommand.Parameters.AddWithValue("@Zip", origShippingVendor.Zip);
                mySqlCommand.Parameters.AddWithValue("@Phone", origShippingVendor.Phone);
                mySqlCommand.Parameters.AddWithValue("@Contact", origShippingVendor.Contact);
                mySqlCommand.Parameters.AddWithValue("@ContactEmail", origShippingVendor.ContactEmail);

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
                mySqlCommand.Parameters.AddWithValue("@ShippingVendorID", id);
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
                            Country = mySqlReader.GetString(4),
                            State = mySqlReader.GetString(5),
                            Zip = mySqlReader.GetString(6),
                            Phone = mySqlReader.GetString(7),
                            Contact = mySqlReader.GetString(8),
                            ContactEmail = mySqlReader.GetString(9)


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
                            Country = mySqlReader.GetString(4),
                            State = mySqlReader.GetString(5),
                            Zip = mySqlReader.GetString(6),
                            Phone = mySqlReader.GetString(7),
                            Contact = mySqlReader.GetString(8),
                            ContactEmail = mySqlReader.GetString(9) 
                        };

                        //Add item to list
                        shippingVendorList.Add(shippingVendor);
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

            return shippingVendorList;
        }// end GetAllShippingVendors
            
    }
}
