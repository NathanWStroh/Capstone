using System;

//Author: Andrew
//Date Created: 2/23/2014
//Last Modified: 3/1/2014 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 
* 
*/

namespace com.Farouche.Commons
{
    public class ShippingOrderLineItem
    {
        private int _shippingOrderId;
        private int _productID;
        private String _productName;
        private int _quantity;
        private String _productLocation;
        private Boolean _isPicked;

        public ShippingOrderLineItem()
        {
        }

        public ShippingOrderLineItem(int shippingOrderId, int productId)
        {
            this.ShippingOrderID = shippingOrderId;
            this.ProductId = productId;
        }

        public int ShippingOrderID
        {
            get
            {
                return _shippingOrderId;
            }
            set
            {
                _shippingOrderId = value;
            }
        }
        public int ProductId
        {
            get
            {
                return _productID;
            }
            set
            {
                _productID = value;
            }
        }
        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                _productName = value;
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }
        public String ProductLocation
        {
            get
            {
                return _productLocation;
            }
            set
            {
                _productLocation = value;
            }
        }
        public Boolean IsPicked
        {
            get
            {
                return _isPicked;
            }
            set
            {
                _isPicked = value;
            }
        }
        public override string ToString()
        {
            return string.Format("ShippingOrderID: {0}, ProductId: {1}, ProductName, {2}, Quantity: {3}, ProductLocation: {4}, IsPicked: {5}", ShippingOrderID, ProductId, ProductName, Quantity, ProductLocation, IsPicked);
        }
        public Type GetType()
        {
            throw new NotImplementedException();
        }
        public string ToXml()
        {
            throw new NotImplementedException();
        }
    }
}
