using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using com.Farouche.Commons;
using com.Farouche.DataAccess;

//Author: Kaleb W
//Date Created: 3/5/2014
//Last Modified: 3/6/2014
//Last Modified By: Kaleb W

/*
 *                               Changelog
 * Date         By          Ticket          Version         Description
 * 
*/

namespace com.Farouche.BusinessLogic
{
    public class ShippingOrderLineItemManager : DatabaseConnection
    {
        //Cretates a new connection.
        private readonly SqlConnection _connection = GetInventoryDbConnection();
        //Private member used to store the list of orders.
        private List<ShippingOrderLineItem> _lineItems = null;
        //Private member used to store a single line item.
        private ShippingOrderLineItem _lineItem = null;

        //Used to retrieve the list of line items.
        public List<ShippingOrderLineItem> LineItems
        {
            get
            {
                return _lineItems;
            }
            set
            {
                _lineItems = value;
            }
        }//End of LineItems sets/gets.

        //Used to retrieve the list of line items.
        public ShippingOrderLineItem LineItem
        {
            get
            {
                return _lineItem;
            }
            set
            {
                _lineItem = value;
            }
        }//End of LineItems sets/gets.

        public bool Insert(ShippingOrderLineItem lineItem)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderLineItemDAL.AddShippingOrderLineItems(lineItem, _connection);
        }//End of Insert(.)

        public bool Update(ShippingOrderLineItem lineItem, ShippingOrderLineItem originalLineItem)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderLineItemDAL.UpdateShippingOrderLineItem(lineItem, originalLineItem, _connection);
        }//End of Update(..)

        public bool UpdatePickedTrue(ShippingOrderLineItem lineItem)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderLineItemDAL.PickShippingOrderLineItem(lineItem, _connection);
            //Need to decrement available inventory for this line item by the quantity.
        }//End of UpdatePickedTrue(.)

        //When would this be called?
        public bool UpdatePickedFalse(ShippingOrderLineItem lineItem)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderLineItemDAL.UnpickShippingOrderLineItem(lineItem, _connection);
            //Need to increment available inventory for this line item by the quantity.
        }//End of UpdatePickedFalse(.)

        public List<ShippingOrderLineItem> GetLineItems()
        {
            //Need to do error checking... Try/Catch.
            LineItems = ShippingOrderLineItemDAL.GetAllShippingOrderLineItems(_connection);
            return LineItems;
        }//End of GetLineItems()

        public ShippingOrderLineItem GetLineItem(int productID, int shippingOrderID)
        {
            //Need to do error checking... Try/Catch.
            LineItem = ShippingOrderLineItemDAL.GetShippingOrderLineItemById(productID, shippingOrderID, _connection);
            return LineItem;
        }//End of GetLineItem(.)

        public List<ShippingOrderLineItem> GetLineItemsByID(int shippingOrderID)
        { 
            //Need to do error checking... Try/Catch.
            LineItems = ShippingOrderLineItemDAL.GetShippingOrderLineItemsById(shippingOrderID, _connection);
            return LineItems;
        }
    }//End of class.
}//End of namespace.
