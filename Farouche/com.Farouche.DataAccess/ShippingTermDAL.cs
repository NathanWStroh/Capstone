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
 * 4/1/2014     Kaleb                                       Adjusted to account for ShippingVendorName and Active when reading in from the DB.
 * 
 * 4/1/2014     Kaleb                                       Adjusted class to account for activating/deactivating a shipping term.
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
                mySqlCommand.Parameters.AddWithValue("@shippingVendorID",shippingTerm.ShippingVendorId);
                mySqlCommand.Parameters.AddWithValue("@description", shippingTerm.Description);
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
                mySqlCommand.Parameters.AddWithValue("@shippingVendorID", shippingTerm.ShippingVendorId);
                mySqlCommand.Parameters.AddWithValue("@description", shippingTerm.Description);

                mySqlCommand.Parameters.AddWithValue("@orig_ShippingTermID", origShippingTerm.Id);
                mySqlCommand.Parameters.AddWithValue("@orig_ShippingVendorID", origShippingTerm.ShippingVendorId);
                mySqlCommand.Parameters.AddWithValue("@orig_Description", origShippingTerm.Description);

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
        }// end UpdateShippingTerms


        public static ShippingTerm GetShippingTermsById(int id, SqlConnection myConnection)
        {
            var shippingTerm = new ShippingTerm();
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_GetShippingTermsByID", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                mySqlCommand.Parameters.AddWithValue("@shippingTermID", id);
                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {

                    while (mySqlReader.Read())
                    {
                        shippingTerm = new ShippingTerm(mySqlReader.GetInt32(0))
                        {
                           ShippingVendorId = mySqlReader.GetInt32(1),
                           Description = mySqlReader.GetString(2),
                           ShippingVendorName = mySqlReader.GetString(3),
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
                            Description = mySqlReader.GetString(2),
                            ShippingVendorName = mySqlReader.GetString(3),
                            Active = mySqlReader.GetBoolean(4)
                        };
                        //Add item to list
                        shippingTermList.Add(shippingTerm);
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

            return shippingTermList;
        }//end GetAllShippingTerms

        public static List<ShippingTerm> FetchTermsByActive(Boolean activeState, SqlConnection myConnection)
        {
            var shippingTermList = new List<ShippingTerm>();
            myConnection = myConnection ?? GetInventoryDbConnection();
            try
            {
                var mySqlCommand = new SqlCommand("proc_FetchTermsByActive", myConnection)
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
                        var shippingTerm = new ShippingTerm(mySqlReader.GetInt32(0))
                        {
                            ShippingVendorId = mySqlReader.GetInt32(1),
                            Description = mySqlReader.GetString(2),
                            ShippingVendorName = mySqlReader.GetString(3),
                            Active = mySqlReader.GetBoolean(4)
                        };
                        //Add item to list
                        shippingTermList.Add(shippingTerm);
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
            return shippingTermList;
        }//End of FetchTermsByActive(..)

        public static Boolean ReactivateTerm(ShippingTerm term, SqlConnection connection)
        {
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("proc_ReactivateTerm", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ShippingTermId", term.Id);

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

        public static Boolean DeactivateTerm(ShippingTerm term, SqlConnection connection)
        {
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("proc_DeactivateTerm", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ShippingTermId", term.Id);

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

        public static Boolean DeleteTerm(ShippingTerm term, SqlConnection connection)
        {
            //?? Null-coalescing operator.
            //If the connection is null a new connection will be returned.
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                //Establishes the connection.
                conn.Open();
                //Creates the command object, passing the SP and connection object.
                SqlCommand sqlCmd = new SqlCommand("proc_DeleteTerm", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Id", term.Id);
                sqlCmd.Parameters.AddWithValue("@ShippingVendorId", term.ShippingVendorId);
                sqlCmd.Parameters.AddWithValue("@Active", term.Active);
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
