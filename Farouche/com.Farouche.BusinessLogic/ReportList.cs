using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using com.Farouche.DataAccess;
using System.Data.SqlClient;

namespace com.Farouche.BusinessLogic
{
    public class ReportList : DatabaseConnection
    {
        private readonly SqlConnection _connection = GetInventoryDbConnection();

        public List<ShippingOrderLineItem> FetchCLSLineItems(int myOrderId)
        {
            return ShippingOrderLineItemDAL.GetShippingOrderLineItemsById(myOrderId, _connection);
        }

        public List<CLSPackDetails> FetchPackingDetails(ShippingOrder order)
        {
            return ReportingDAL.FetchCLSPackDetails(order, _connection);
        }

        public List<CLSEmployee> GetEmployeeDirectory()
        {
            return ReportingDAL.FetchCLSEmployees(_connection);
        }
    }
}
