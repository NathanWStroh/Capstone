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
 *  4/05/14  Adam                                           Changed DAL Class to not use passed in connection
 *  3/28/14  Adam                                           Added GetReorderReportData method
 * 
 *
*/

namespace com.Farouche.DataAccess
{
    public class ReportDAL : DatabaseConnection
    {

        public static List<Reorder> GetReorderReportData(int vendorId)
        {
            List<Reorder> reorders = new List<Reorder>();
            SqlConnection conn = GetInventoryDbConnection();
            try
            {
                conn.Open();
                SqlCommand sqlCmd = new SqlCommand("proc_GenerateReorderReports", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@VendorID", vendorId);
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Reorder order = null;
                    while (reader.Read())
                    {

                        var product = new Product(reader.GetInt32(0))
                        {
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            _reorderThreshold = reader.GetInt32(reader.GetOrdinal("ReorderThreshold")),
                            _reorderAmount = reader.GetInt32(reader.GetOrdinal("ReorderAmount")),
                            Active = true
                        };
                        order.Product = product;
                        var vendorSrcItem = new VendorSourceItem(reader.GetInt32(reader.GetOrdinal("ProductID")), reader.GetInt32(reader.GetOrdinal("VendorID")))
                        {
                            UnitCost = (Decimal)reader.GetSqlMoney(reader.GetOrdinal("UnitCost")),
                            MinQtyToOrder = reader.GetInt32(reader.GetOrdinal("MinQtyToOrder")),
                            ItemsPerCase = reader.GetInt32(reader.GetOrdinal("ItemsPerCase")),
                            Active = true
                        };
                        order.VendorSourceItem = vendorSrcItem;
                        reorders.Add(order);
                    } 
                }
                reader.Close();
            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("DatabaseException"),ex);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("SqlException"),ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ApplicationException(Messeges.GetMessage("Exception"),ex);
            }
            finally
            {
                conn.Close();
            }
            return reorders;
        }  // end GetReorderReportData(.)


    }
}
