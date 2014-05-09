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
            var vendorOrders = VendorOrderDAL.GetAllOpenOrdersByVendor(vendor.Id, _connection);
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

        public bool UpdateQtyDamaged(VendorOrderLineItem currentLineItem, VendorOrderLineItem oldLineItem)
        {
            if (currentLineItem == null) throw new ApplicationException("VendorOrderLineItem is null");
            if (currentLineItem.QtyDamaged < 0)
            {
                Console.Write("Qty Damaged can't be negative");
                throw new ApplicationException("Quantity damaged cannot be negative.");
            }
            currentLineItem.QtyReceived = oldLineItem.QtyReceived;
            currentLineItem.QtyDamaged = oldLineItem.QtyDamaged + currentLineItem.QtyDamaged;
            var result = VendorOrderLineItemDAL.Update(oldLineItem, currentLineItem, _connection);
            return result;
        }
        public bool UpdateQtyReceived(VendorOrderLineItem currentLineItem, VendorOrderLineItem oldLineItem)
        {
            if (currentLineItem == null) throw new ApplicationException("VendorOrderLineItem is null");
            if (currentLineItem.QtyReceived < 0 || currentLineItem.QtyDamaged < 0)
            {
                Console.Write("Qty Entered can't be negative");
                throw new ApplicationException("Quantity fields cannot be negative.");
            }

                currentLineItem.QtyDamaged = oldLineItem.QtyDamaged + currentLineItem.QtyDamaged;
      
   
          
                currentLineItem.QtyReceived = oldLineItem.QtyReceived + currentLineItem.QtyReceived;
            
            
            var result = VendorOrderLineItemDAL.Update(oldLineItem, currentLineItem, _connection);
            return result;
        }

        public bool UpdateLineItemNote(VendorOrderLineItem currentLineItem, String note)
        {
            if (currentLineItem == null) throw new ApplicationException("VendorOrderLineItem is null");
            if (note == null) note = "";
            if (note.Length > 250) throw new ApplicationException("Note can only be 250 characters long.");
            var oldLineItem = currentLineItem;
            currentLineItem.Note = note;
            var result = VendorOrderLineItemDAL.UpdateNote(currentLineItem, _connection);
            return result;
        }

        public bool AddNewLineItemToVendorOrder(VendorOrder vendorOrder,Product productToAdd, int qtyReceived, string note, int qtyDamaged)
        {
            if (productToAdd == null) throw new ApplicationException("Product can't be null");
            if (vendorOrder == null) throw new ApplicationException("VendorOrder can't be null");
            if (qtyReceived <= 0) throw new ApplicationException("Quantity recieved has to be greater than 0");
            var newVendorOrderLineItem = new VendorOrderLineItem(vendorOrder.Id, productToAdd.Id)
            {
                QtyOrdered = 0,
                QtyReceived = qtyReceived,
                QtyDamaged = qtyDamaged,
                Note = note
            };
            return VendorOrderLineItemDAL.Add(newVendorOrderLineItem, _connection);
        }
    }
}
