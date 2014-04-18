using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using com.Farouche.Commons;

//Author: Ben
//Date Created: 4/10/2014
//Last Modified: 4/10/2014
//Last Modified By: Ben Grimes

namespace com.Farouche.DataAccess
{
    public class ReportingDAL : DatabaseConnection
    {
        public static List<CLSPackDetails> FetchCLSPackDetails(ShippingOrder order, SqlConnection myConnection)
        {
            List<CLSPackDetails> reportLines = new List<CLSPackDetails>();
            SqlConnection conn = myConnection;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_GetCLSPackDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ShippingOrderId", order.ID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reportLine = new CLSPackDetails(reader.GetInt32(0))
                        {
                            ShippingTermId = reader.GetInt32(1),
                            ShippingVendorId = reader.GetInt32(2),
                            ShippingDescription = reader.GetString(3),
                            ShippingVendorName = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            ShippingTermDescription = reader.GetString(5),
                            ProductId = reader.GetInt32(6),
                            ProductName = reader.GetString(7),
                            Quantity = reader.GetInt32(8),
                            ShipDate = reader.GetDateTime(9),
                            ShipToName = reader.IsDBNull(10) ? "" : reader.GetString(10),
                            ShipToAddress = reader.IsDBNull(11) ? "" : reader.GetString(11),
                            ShipToCity = reader.IsDBNull(12) ? "" : reader.GetString(12),
                            ShipToState = reader.IsDBNull(13) ? "" : reader.GetString(13),
                            ShipToZip = reader.IsDBNull(14) ? "" : reader.GetString(14)
                        };
                        reportLines.Add(reportLine);
                    }
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SqlException. " + ex.Message);
            }
            catch (DataException ex)
            {
                Console.WriteLine("DataException. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GeneralException. " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return reportLines;
        }
    }
}
