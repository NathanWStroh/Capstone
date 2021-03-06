﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using com.Farouche.Commons;
using System.Data;

//Author: 
//Date Created: 04/10/14
//Last Modified: 04/10/14
//Last Modified By: Adam Chandler

/*
 *                               Changelog
 * Date         By          Ticket          Version         Description
 *  04/10/14  Adam                                         Added Class and GetAllApplicationVariable Method
 * 
 *
*/

namespace com.Farouche.DataAccess
{
    public class ApplicationVariablesDAL : DatabaseConnection
    {
        public static Dictionary<String, String> GetAllApplicationVariables()
        {
            var appVariables = new Dictionary<String, String>();
            var connection = GetInventoryDbConnection();
            try
            {
                connection.Open();
                SqlCommand sqlCmd = new SqlCommand("proc_GetAllApplicationVariables", connection);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var key = reader.GetString(reader.GetOrdinal("Key"));
                        var value = reader.GetString(reader.GetOrdinal("Value"));
                        appVariables.Add(key, value);
                    }
                }
                reader.Close();
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

            return appVariables;
        }
    }
}
