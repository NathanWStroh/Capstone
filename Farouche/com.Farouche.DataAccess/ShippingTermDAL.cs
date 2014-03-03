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
    public class ShippingTermDAL : DatabaseConnection
    {
        public static bool AddShippingTerm(ShippingTerm shippingTerm, SqlConnection myConnection)
        {
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_InsertIntoShippingTerm", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@ShippingTermID", shippingTerm.Id);
                mySqlCommand.Parameters.AddWithValue("@ShippingVendorID",shippingTerm.ShippingVendorId);
                mySqlCommand.Parameters.AddWithValue("@Description", shippingTerm.Description);
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
        }//end AddShippingTerm
	

	public static bool UpdateShippingTerms(ShippingTerm shippingTerm, ShippingTerm origShippingTerm, SqlConnection myConnection)
    {
        myConnection = myConnection ?? GetInventoryDbConnection();
        try
        {
            var mySqlCommand = new SqlCommand("proc_UpdateShippingTerm", myConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            mySqlCommand.Parameters.AddWithValue("@ShippingTermID", shippingTerm.Id);
            mySqlCommand.Parameters.AddWithValue("@ShippingVendorID", shippingTerm.ShippingVendorId);
            mySqlCommand.Parameters.AddWithValue("@Description", shippingTerm.Description);

            mySqlCommand.Parameters.AddWithValue("@ShippingTermID", origShippingTerm.Id);
            mySqlCommand.Parameters.AddWithValue("@ShippingVendorID", origShippingTerm.ShippingVendorId);
            mySqlCommand.Parameters.AddWithValue("@Description", origShippingTerm.Description);

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
    }// end UpdateShippingTerms


	public static ShippingTerm GetShippingTermsById(int id, SqlConnection myConnection)
    {
        var shippingTerm = new ShippingTerm();
        myConnection = myConnection ?? GetInventoryDbConnection();
        try
        {
            var mySqlCommand = new SqlCommand("proc_getshippingTermsByID", myConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            mySqlCommand.Parameters.AddWithValue("@ShippingTermID", id);
            myConnection.Open();

            var mySqlReader = mySqlCommand.ExecuteReader();
            if (mySqlReader.HasRows)
            {

                while (mySqlReader.Read())
                {
                    shippingTerm = new ShippingTerm(mySqlReader.GetInt32(0))
                    {
                       ShippingVendorId = mySqlReader.GetInt32(1),
                        Description = mySqlReader.GetString(2)
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

        return shippingTerm;
    }//end GetShippingTermsById

	public static List<ShippingTerm> GetAllShippingTerms(SqlConnection myConnection)
    {
        var shippingTermList = new List<ShippingTerm>();

        myConnection = myConnection ?? GetInventoryDbConnection();
        try
        {
            var mySqlCommand = new SqlCommand("proc_GetAllShippingTerms", myConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            myConnection.Open();

            var mySqlReader = mySqlCommand.ExecuteReader();
            if (mySqlReader.HasRows)
            {
                while (mySqlReader.Read())
                {
                    var shippingTerm = new ShippingTerm(mySqlReader.GetInt32(0))
                    {
                        ShippingVendorId = mySqlReader.GetInt32(1),
                        Description = mySqlReader.GetString(2)
                    };

                    //Add item to list
                    shippingTermList.Add(shippingTerm);
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

        return shippingTermList;
    }//end GetAllShippingTerms

		


    }
}
