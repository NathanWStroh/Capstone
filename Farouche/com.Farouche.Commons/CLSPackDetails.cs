using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Farouche.Commons
{
    public class CLSPackDetails : Entity
    {
        private int _shippingTermId;
        private int _shippingVendorId;
        private string _shippingDescription;

        private string _shippingVendorName;

        private string _shippingTermDescription;

        private int _productId;
        private string _productName;

        private int _quantity;

        private DateTime? _shipDate;

        private string _shipToName;
        private string _shipToAddress;
        private string _shipToCity;
        private string _shipToState;
        private string _shipToZip;

        public CLSPackDetails(int shippingOrderId)
        {
            Id = shippingOrderId;
        }
        public int ShippingTermId
        {
            get
            {
                return _shippingTermId;
            }
            set
            {
                _shippingTermId = value;
            }
        }
        public int ShippingVendorId
        {
            get
            {
                return _shippingVendorId;
            }
            set
            {
                _shippingVendorId = value;
            }
        }
        public string ShippingDescription
        {
            get
            {
                return _shippingDescription;
            }
            set
            {
                _shippingDescription = value;
            }
        }
        public string ShippingVendorName
        {
            get
            {
                return _shippingVendorName;
            }
            set
            {
                _shippingVendorName = value;
            }
        }
        public string ShippingTermDescription
        {
            get
            {
                return _shippingTermDescription;
            }
            set
            {
                _shippingTermDescription = value;
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
        public DateTime? ShipDate
        {
            get
            {
                return _shipDate;
            }
            set
            {
                _shipDate = value;
            }
        }
        public string ShipToName
        {
            get
            {
                return _shipToName;
            }
            set
            {
                _shipToName = value;
            }
        }
        public string ShipToAddress
        {
            get
            {
                return _shipToAddress;
            }
            set
            {
                
                _shipToAddress= value;
            }
        }
        public string ShipToCity
        {
            get
            {
                return _shipToCity;
            }
            set
            {
                _shipToCity = value;
            }
        }
        public string ShipToState
        {
            get
            {
                return _shipToState;
            }
            set
            {
                _shipToState = value;
            }
        }
        public string ShipToZip
        {
            get
            {
                return _shipToZip;
            }
            set
            {
                _shipToZip = value;
            }
        }
        public override string ToString()
        {
            return string.Format("ShippingOrderID: {0} , \nShippingTermID: {1} , \nShippingVendorID: {2} , \nShippingDescription{3} , \nShippingVendorName: {4}\n , "
                            + "ShippingTermDescription: {5} , \nProductId: {6} , \nProductName: {7} , \nQuantity: {8} , \nShipDate: {9} , \nShipToName: {10} , \n"
                            + "ShipToAddress: {11} , \nShipToCity: {12} , \nShipToState: {13} , \nShipToZip: {14}", Id, ShippingTermId, ShippingVendorId, ShippingDescription,
                                ShippingVendorName, ShippingTermDescription, ProductId, ProductName, Quantity, ShipDate, ShipToName, ShipToAddress, ShipToCity, ShipToState, ShipToZip);
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
