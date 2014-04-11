using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using com.Farouche.DataAccess;
using System.Data.SqlClient;

//Author: Kaleb W
//Date Created: 3/4/2014
//Last Modified: 3/6/2014
//Last Modified By: Kaleb W

/*
 *                               Changelog
 * Date         By          Ticket          Version         Description
 * 
*/

namespace com.Farouche.BusinessLogic
{
    public class ShippingOrderManager : DatabaseConnection
    {
        //Cretates a new connection.
        private readonly SqlConnection _connection = GetInventoryDbConnection();
        //Private member used to store the list of orders.
        private List<ShippingOrder> _orders = null;
        //Private member used to store a single order.
        private ShippingOrder _order = null;

        //Used to retrieve the list of orders.
        public List<ShippingOrder> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
            }
        }//End of Orders sets/gets.

        //Used to retrieve the list of orders.
        public ShippingOrder Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
            }
        }//End of Orders sets/gets.

        public bool Insert(ShippingOrder order)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderDAL.AddShippingOrder(order, _connection);
        }//End of Insert(.)

        public bool Update(ShippingOrder order, ShippingOrder originalOrder)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderDAL.UpdateShippingOrder(order, originalOrder, _connection);
        }//End of Update(..)

        public bool UpdatePickedTrue(ShippingOrder order)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderDAL.PickShippingOrder(order, _connection);
            //Should also clear the current UserId.

            //Can also call ShippingOrderDAL.UnpickShippingOrder... When would this be done?
            //If necessary add logic to determine which method is called.
        }//End of UpdatePickedTrue(.)

        //When would this be done?
        public bool UpdatePickedFalse(ShippingOrder order)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderDAL.UnpickShippingOrder(order, _connection);
        }//End of UpdatePickedFalse(.)

        public bool UpdateShippedDate(ShippingOrder order)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderDAL.ShipShippingOrder(order, _connection);
            //Need to update on-hand inventory for all line items once the shipped date is set.
        }//End of UpdateShippedDate(.)

        //When would this be done?
        public bool ClearShippedDate(ShippingOrder order)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderDAL.UnshipShippingOrder(order, _connection);
        }//End of ClearShippedDate(.)

        public bool UpdateUserId(ShippingOrder order, int employeeID)
        {
            //If the UserId of the current ShippingOrder is the same value as the new value do not call the update procedure.
            if(order.UserId.Equals(employeeID))
            {
                return false;
            }
            else
            {
                //Need to do error checking... Try/Catch.
                return ShippingOrderDAL.AssignShippingOrder(order, employeeID, _connection);
            }
        }//End of UpdateUserId..)

        public bool ClearUserId(ShippingOrder order)
        {
            //Need to do error checking... Try/Catch.
            return ShippingOrderDAL.UnassignShippingOrder(order, _connection);
        }//End of ClearUserId(.)

        //Gets orders used for the picking work queue.
        public List<ShippingOrder> GetNonPickedOrders()
        {
            //Need to do error checking... Try/Catch.
            this.Orders = ShippingOrderDAL.GetAllShippingOrdersNotPicked(_connection);
            return Orders;
        }//End of GetNonPickedOrders()

        //Gets orders used for the packing work queue.
        public List<ShippingOrder> GetPickedOrders()
        {
            //Need to do error checking... Try/Catch.
            this.Orders = ShippingOrderDAL.GetAllShippingOrdersPicked(_connection);
            return Orders;
        }//End of GetPickedOrders()

        //Gets orders used for the employee work queue.
        public List<ShippingOrder> GetOrdersByUserId(int employeeID)
        {
            //Need to do error checking... Try/Catch.
            this.Orders = ShippingOrderDAL.GetAllShippingOrdersByEmployee(employeeID, _connection);
            return Orders;
        }//End of GetOrdersByUserId(.)

        public ShippingOrder GetOrderByID(int orderID)
        {
            //Need to do error checking... Try/Catch.
            this.Order = ShippingOrderDAL.GetShippingOrderById(orderID, _connection);
            return Order;
        }//End of GetOrderByUserID(.)

        //Are these additional methods needed?

        public List<ShippingOrder> GetAllShippingOrders()
        {
            this.Orders = ShippingOrderDAL.GetAllShippingOrders(_connection);
            return Orders;
        }
        //GetAllShippingOrdersShipped?
        //GetAllShippingOrdersNotShipped?
        //GetShippingOrderByPurchaseOrderId?
    
    }//End of class.
}//End of namespace.
