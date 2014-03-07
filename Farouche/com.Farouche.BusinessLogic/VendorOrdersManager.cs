using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;

namespace com.Farouche.BusinessLogic
{
    class VendorOrderManager
    {
        public Boolean AddLineItem(VendorOrder order, Product product, int qty)
        {
            return true;
        }
        public Boolean UpdateLineItem(VendorOrderLineItem item, int newQtyOrdered)
        {
            return true;
        }
        public Boolean DeleteLineItem(VendorOrderLineItem item)
        {
            return true;
        }
        public Boolean UpdateShipmentsReceived(VendorOrder order, int qtyReceived)
        {
            return true;
        }
        public Boolean AddVendorOrder(VendorOrder order)
        {
            return true;
        }
        public VendorOrder getVendorOrder(int VendorOrderID)
        {
            return new VendorOrder();
        }
        
    }
}
