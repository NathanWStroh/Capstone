﻿//Author: Maggie John
//Date Created: 04/11/2014
//Last Modified: 04/11/2014
//Last Modified By: Nathan W Stroh

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 04-11-2014   NWS         ???             ???             Added Public to class
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using System.Data.SqlClient;
using com.Farouche.DataAccess;

namespace com.Farouche.BusinessLogic
{
    public class VendorOrderManager : DatabaseConnection
    {
        private readonly SqlConnection _connection = GetInventoryDbConnection();
        private ProductManager prodMan = new ProductManager();

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
			if(qtyReceived + order.NumberOfShipments < 0) throw new ApplicationException("Total quantity of shipments received cannot be negative");
			var oldOrder = order;
            order.NumberOfShipments += qtyReceived;
            var result = VendorOrderDAL.Update(oldOrder, order, _connection);
            return result;
        }
        public bool AddVendorOrder(VendorOrder order)
        {
            if (order == null) throw new ApplicationException("Order cannot be null");
            if (order.DateOrdered == null) order.DateOrdered = DateTime.Now;
            var result = VendorOrderDAL.Add(order, _connection);
            if (result)
            {
                var newVendorOrder = VendorOrderDAL.GetVendorOrderByVendorAndDate(order.VendorID,_connection);
                if (order.LineItems != null)
                {
                    foreach (var item in order.LineItems)
                    {
                        item.VendorOrderId = newVendorOrder.Id;
                        if (item.Note == null || item.Note == "")
                        {
                            item.Note = "no note";
                        }
                        if (VendorOrderLineItemDAL.Add(item, _connection)) {
                            prodMan.AddToOnOrder(item.QtyOrdered, item.ProductID);
                        }

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
            if (order.LineItems == null) throw new ApplicationException("VendorOrder cannot have zero line items");
            var oldOrder = new VendorOrder(order.Id, order.VendorID);
            oldOrder.Finalized = order.Finalized;
            oldOrder.NumberOfShipments = order.NumberOfShipments;
            order.Finalized = true;
            foreach (VendorOrderLineItem item in order.LineItems)
            {
                prodMan.AddToAvailable(item.QtyReceived, item.ProductID);
                prodMan.AddToOnHand(item.QtyDamaged + item.QtyReceived, item.ProductID);
                prodMan.RemoveFromOnOrder(item.QtyReceived + item.QtyDamaged, item.ProductID);
            }
            var result = VendorOrderDAL.Update(oldOrder, order, _connection);
            return result;
        }

    }
}
