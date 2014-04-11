using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Farouche.Commons
{
    public class CLSLineItem : Entity
    {
        private int _shippingOrderId;
        private int _productId;
        private string _productName;
        private int _quantity;
        private string _productLocation;
        private bool _isPicked;

        public CLSLineItem(int shippingOrderId, int productId, string productName, int quantity, string productLocation, bool isPicked)
        {
            _shippingOrderId = shippingOrderId;
            _productId = productId;
            _productName = productName;
            _quantity = quantity;
            _productLocation = productLocation;
            _isPicked = isPicked;
        }

        public CLSLineItem()
        {
            _shippingOrderId = 0;
            _productId = 0;
            _productName = "";
            _quantity = 0;
            _productLocation = "";
            _isPicked = false;
        }

        public CLSLineItem(int shippingOrderId)
        {
            _shippingOrderId = shippingOrderId;
        }
        public int ShippingOrderId
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
                return _productId;
            }
            set
            {
                _productId = value;
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
        public string ProductLocation
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
        public bool IsPicked
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
            return string.Format("ShippingOrderID: {0}, ProductId: {1}, ProductName, {2}, Quantity: {3}, ProductLocation: {4}, IsPicked: {5}", Id, ProductId, ProductName, Quantity, ProductLocation, IsPicked);
        }
        public override Type GetType()
        {
            throw new NotImplementedException();
        }
        public override string ToXml()
        {
            throw new NotImplementedException();
        }
    }
}
