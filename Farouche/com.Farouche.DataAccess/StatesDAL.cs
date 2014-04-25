using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using com.Farouche.Commons;
using System.Data;

//Author: 
//Date Created: 3/28/14
//Last Modified: 3/28/14
//Last Modified By: Adam Chandler

/*
*                               Changelog
* Date         By          Ticket          Version         Description
*  3/28/14  Adam                                           Added Class
* 
*                                                         
*/

namespace com.Farouche.DataAccess
{
    public class StatesDAL : DatabaseConnection
    {
        public static Dictionary<int, State> GetAllStates(SqlConnection connection)
        {
            Dictionary<int, State> states = new Dictionary<int, State>();
            SqlConnection conn = connection ?? GetInventoryDbConnection();
            try
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("proc_GetAllStates", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        var state = new State(reader.GetInt32(0))
                        {
                            StateCode = reader.GetString(reader.GetOrdinal("StateCode")),
                            StateName = reader.GetString(reader.GetOrdinal("StateName")),
                            FirstZipCode = reader.GetInt32(reader.GetOrdinal("FirstZipCode")),
                            LastZipCode = reader.GetInt32(reader.GetOrdinal("LastZipCode"))
                        };
                        states.Add(state.Id, state);
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
                conn.Close();
            }




            return states;
        }
    }
}