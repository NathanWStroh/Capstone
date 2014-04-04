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
*  3/28/14  Adam                                           Added getReorderReportData method
* 
*                                                         
*/

namespace com.Farouche.DataAccess
{
    public class ReportDAL : DatabaseConnection
    {

        public static List<Reorder> getReorderReportData(int vendorId, SqlConnection connection)
        {
            List<Reorder> reorders = new List<Reorder>();
            SqlConnection conn = connection ?? GetInventoryDbConnection();
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
                conn.Close();
            }
            return reorders;
        }


    }
}
