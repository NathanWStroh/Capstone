using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace com.Farouche.Commons
{
    public class VendorOrderLineItem : Entity
    {
        private int _productId;
        private int _vendorOrderId;
        private int _qtyDamaged;
        private int _qtyReceived;
        private int _qtyOrdered;
        private string _note;
        private double _lineItemTotal;

        public VendorOrderLineItem(int vendorOrderId, int productId)
        {
            ProductID = productId;
            VendorOrderId = vendorOrderId;
        }

        public int ProductID
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public int VendorOrderId
        {
            get { return _vendorOrderId; }
            set { _vendorOrderId = value; }
        }
        public double LineItemTotal
        {
            get { return _lineItemTotal; }
            set { _lineItemTotal = value; }
        }
        public int QtyOrdered
        {
            get { return _qtyOrdered; }
            set { _qtyOrdered = value; }
        }

        public int QtyReceived
        {
            get { return _qtyReceived; }
            set { _qtyReceived = value; }
        }

        public int QtyDamaged
        {
            get { return _qtyDamaged; }
            set { _qtyDamaged = value; }
        }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
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
