using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;

namespace com.Farouche.DataAccess
{
    public class VendorOrderDAL
    {
        public static List<VendorOrder> getAll()
        {
            return new List<VendorOrder>();
        }
        public static List<VendorOrder> getAllOpenOrders()
        {
            return new List<VendorOrder>();
        }
        public static List<VendorOrder> getAllOpenOrdersByVendor()
        {
            return new List<VendorOrder>();
        }
		public static VendorOrder getVendorOrder(int VendorOrderID){
			return new VendorOrder();
		}
		public static bool Update(VendorOrder oldVendorOrder, VendorOrder newVendorOrder, SqlConnection connection)
		{
			return true;
		}
		public static bool Add(VendorOrder order)
		{
			return true;
		}
		
    }
}
