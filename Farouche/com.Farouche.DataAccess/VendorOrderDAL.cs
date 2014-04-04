using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms.VisualStyles;
using com.Farouche.Commons;

namespace com.Farouche.DataAccess
{
    public class VendorOrderDAL : DatabaseConnection
    {
        public static List<VendorOrder> GetAll(SqlConnection myConnection)
        {
            var vendorOrderList = new List<VendorOrder>();

            myConnection = myConnection ?? GetInventoryDbConnection();

            try
            {
                var mySqlCommand = new SqlCommand("proc_GetAllVendorOrders", myConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                myConnection.Open();

                var mySqlReader = mySqlCommand.ExecuteReader();
                if (mySqlReader.HasRows)
                {
                    while (mySqlReader.Read())
                    {
                        var vendorOrder = new VendorOrder()
                        {
                            VendorOrderID = mySqlReader.GetInt32(0),
                            VendorID = mySqlReader.GetInt32(1),
                            Name = mySqlReader.GetString(2),
                            DateOrdered = mySqlReader.GetString(3),
                            NumberOfShipments = mySqlReader.GetInt32(4)
                        };
                        vendorOrderList.Add(vendorOrder);
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

            return vendorOrderList;
        }

        public static List<VendorOrder> GetAllByVendor(Vendor vendor)
        {
            throw new NotImplementedException();
        }
    }
}
