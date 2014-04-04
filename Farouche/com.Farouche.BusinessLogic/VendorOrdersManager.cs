using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using System.Data.SqlClient;
using com.Farouche.DataAccess;

namespace com.Farouche.BusinessLogic
{
    class VendorOrderManager : DatabaseConnection
    {
        private readonly SqlConnection _connection = GetInventoryDbConnection();
        public bool AddLineItem(VendorOrder order, Product product, int qty)
        {
            if (order == null) throw new ApplicationException("Vendor Order is null");
            if (product == null) throw new ApplicationException("Product cannot be null");
            if (qty == null) qty = 0;
            VendorOrderLineItem lineItem = new VendorOrderLineItem(order.Id, product.Id);
            lineItem.QtyOrdered = qty;
            var result = VendorOrderLineItemDAL.Add(lineItem, _connection);
            if (result)
            {
                order.AddLineItem(lineItem);
            }
            return result;
        }
        public bool UpdateLineItem(VendorOrderLineItem item, int newQtyOrdered)
        {
            if (item == null) throw new ApplicationException("VendorOrderLineItem cannot be null");
            if (newQtyOrdered == null) newQtyOrdered = 0;
            var oldLineItem = item;
            item.QtyOrdered = newQtyOrdered;
            var result = VendorOrderLineItemDAL.Update(oldLineItem, item, _connection);
            return result;
        }
        public bool DeleteLineItem(VendorOrderLineItem item)
        {
            if (item == null) throw new ApplicationException("Cannot delete a null item");
            //need to check and see if stored procedure exsists
            return true;
        }
        public bool UpdateShipmentsReceived(VendorOrder order, int qtyReceived)
        {
			if(order == null) throw new ApplicationException("VendorOrder cannot be null");
			if(qtyReceived + order.ShipmentsReceived < 0) throw new ApplicationException("Total quantity of shipments received cannot be negative");
			var oldOrder = order;
            order.ShipmentsReceived += qtyReceived;
            var result = VendorOrderDAL.Update(oldOrder, order, _connection);
            return result;
        }
        public bool AddVendorOrder(VendorOrder order)
        {
            if (order == null) throw new ApplicationException("Order cannot be null");
            if(order.DateOrdered == null) order.DateOrdered = DateTime.Now;
            var result = VendorOrderDAL.Add(order, _connection);
            if (result)
            {
                var newVendorOrder = VendorOrderDAL.GetVendorOrderByVendorAndDate(order.VendorID, order.DateOrdered, _connection);
                if (order.LineItems != null)
                {
                    foreach (var item in order.LineItems)
                    {
                        VendorOrderLineItemDAL.Add(item, _connection);
                    }
                }
            }
            return result;
        }
        
        public VendorOrder getVendorOrder(int VendorOrderID)
        {
            if (VendorOrderID < 0) throw new ApplicationException("VendorOrderID must be positive");
            return VendorOrderDAL.GetVendorOrder(VendorOrderID, _connection);
        }
        public Boolean FinalizeVendorOrder(VendorOrder order)
        {
            if (order == null) throw new ApplicationException("VendorOrder cannot be null");
            var oldOrder = order;
            order.Finalized = true;
            var result = VendorOrderDAL.Update(oldOrder, order, _connection);
            return result;
        }

    }
}
