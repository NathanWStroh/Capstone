using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using com.Farouche.DataAccess;
using com.Farouche.Commons;
namespace com.Farouche.BusinessLogic
{
    public class ReceivingManager : DatabaseConnection
    {
        private readonly SqlConnection _connection = GetInventoryDbConnection();

        public List<VendorOrder> GetAllOpenOrders()
        {
            var vendorOrders = VendorOrderDAL.GetAll(_connection);
            return vendorOrders ?? new List<VendorOrder>();
        }

        public List<VendorOrder> GetAllOpenOrdersByVendor(Vendor vendor)
        {
            if (vendor == null) throw new ApplicationException("No such Vendor");
            var vendorOrders = VendorOrderDAL.GetAllByVendor(vendor);
            return vendorOrders ?? new List<VendorOrder>();
        }

        public List<VendorOrderLineItem> GetAllLineItemsByVendorOrder(VendorOrder vendorOrder)
        {
            if (vendorOrder == null) throw new ApplicationException("No such VendorOrder");
            var lineItems = VendorOrderLineItemDAL.GetAllByVendorOrder(vendorOrder, _connection);
            return lineItems ?? new List<VendorOrderLineItem>();
        }
        public List<VendorOrderLineItem> GetExceptionItemsByVendorOrder(VendorOrder vendorOrder)
        {
            if (vendorOrder == null) throw new ApplicationException("No such VendorOrder");
            var exceptionLineItems = VendorOrderLineItemDAL.GetExceptionItemsByVendorOrder(vendorOrder, _connection);
            return exceptionLineItems ?? new List<VendorOrderLineItem>();
        }

        public bool UpdateQtyDamaged(VendorOrderLineItem currentLineItem, int qty)
        {
            if (currentLineItem == null) throw new ApplicationException("VendorOrderLineItem is null");
            if (currentLineItem.QtyDamaged + qty < 0)
            {
                Console.Write("Qty Damaged can't be negative");
                throw new ApplicationException("Quantity damaged cannot be negative.");
            }
            var oldLineItem = currentLineItem;
            currentLineItem.QtyDamaged = currentLineItem.QtyDamaged + qty;
            var result = VendorOrderLineItemDAL.Update(oldLineItem, currentLineItem, _connection);
            return result;
        }
        public bool UpdateQtyReceived(VendorOrderLineItem currentLineItem, int qty)
        {
            if (currentLineItem == null) throw new ApplicationException("VendorOrderLineItem is null");
            if (currentLineItem.QtyReceived + qty < 0)
            {
                Console.Write("Qty Received can't be negative");
                throw new ApplicationException("Quantity received cannot be negative.");
            }
            var oldLineItem = currentLineItem;
            currentLineItem.QtyReceived = currentLineItem.QtyReceived + qty;
            var result = VendorOrderLineItemDAL.Update(oldLineItem, currentLineItem, _connection);
            return result;
        }

        public bool UpdateLineItemNote(VendorOrderLineItem currentLineItem, String note)
        {
            if (currentLineItem == null) throw new ApplicationException("VendorOrderLineItem is null");
            if (note == null) note = "";
            if (note.Length > 50) throw new ApplicationException("Note can only be 50 characters long.");
            var oldLineItem = currentLineItem;
            currentLineItem.Note = note;
            var result = VendorOrderLineItemDAL.Update(oldLineItem, currentLineItem, _connection);
            return result;
        }

        public bool AddNewLineItemToVendorOrder(VendorOrder vendorOrder,Product productToAdd, int qtyReceived)
        {
            if (productToAdd == null) throw new ApplicationException("Product can't be null");
            if (vendorOrder == null) throw new ApplicationException("VendorOrder can't be null");
            if (qtyReceived <= 0) throw new ApplicationException("Quantity recieved has to be greater than 0");
            var newVendorOrderLineItem = new VendorOrderLineItem(vendorOrder.Id, productToAdd.Id)
            {
                QtyOrdered = 0,
                QtyReceived = qtyReceived,
                QtyDamaged = 0
            };
            return VendorOrderLineItemDAL.Add(newVendorOrderLineItem, _connection);
        }
    }
}
