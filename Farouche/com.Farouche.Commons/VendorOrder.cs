using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Farouche.Commons
{
    public class VendorOrder : Entity
    {
        private string _dateOrdered;
        private int _numberOfShipments;
        private int _vendorOrderID;

        public int VendorOrderID
        {
            get { return _vendorOrderID; }
            set { _vendorOrderID = value; }
        }

        public string DateOrdered
        {
            get { return _dateOrdered; }
            set { _dateOrdered = value; }
        }
        

        public int NumberOfShipments
        {
            get { return _numberOfShipments; }
            set { _numberOfShipments = value; }
        }

        public VendorOrder(int vendorId, int productId)
        {
            this.ProductID = productId;
            this.VendorID = vendorId;
        }

        public VendorOrder()
        {
            // TODO: Complete member initialization
        }
        public int ProductID;
        public int VendorID;

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override string ToXml()
        {
            throw new NotImplementedException();
        }

        public override Type GetType()
        {
            throw new NotImplementedException();
        }
    }
}
