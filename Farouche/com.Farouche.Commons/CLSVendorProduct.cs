using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Farouche.Commons
{
    public class CLSVendorProduct : Entity
    {
        private int _vendorID;
        private string _vendorName;
        private int _productID;
        private string _shortDesc;
        private string _description;
        private Decimal _unitCost;

        public CLSVendorProduct(int vendorID, string vendorName, int productID, string shortDesc, string description, Decimal unitCost)
        {
            _vendorID = vendorID;
            _vendorName = vendorName;
            _productID = productID;
            _shortDesc = shortDesc;
            _description = description;
            _unitCost = unitCost;
        }

        public CLSVendorProduct()
        {
            _vendorID = 0;
            _vendorName = "";
            _productID = 0;
            _shortDesc = "";
            _description = "";
            _unitCost = 0;
        }

        public CLSVendorProduct(int vendorID)
        {
            _vendorID = vendorID;
        }

        public int vendorID
        {
            get
            {
                return _vendorID;
            }
            set
            {
                _vendorID = value;
            }
        }

        public string vendorName
        {
            get 
            {
                return _vendorName;
            }
            set
            {
                _vendorName = value;
            }
        }

        public int productID
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

        public string shortDesc
        {
            get
            {
                return _shortDesc;
            }
            set
            {
                _shortDesc = value;
            }
        }

        public string description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public Decimal unitCost
        {
            get
            {
                return _unitCost;
            }
            set
            {
                _unitCost = value;
            }
        }

        public override string ToString()
        {
            return string.Format("VendorID: {0}, VendorName: {1}, ProductID: {2}, ShortDesc: {3}, Description: {4}, UnitCost: {5}", vendorID, vendorName, productID, shortDesc, description, unitCost);
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
