using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Farouche.Commons
{
    public class VendorOrder : Entity
    {
        private int _vendorId;
		private DateTime _dateOrdered;
		private int _shipmentsReceived;
		private List<VendorOrderLineItem> _lineItems;
        private bool _finalized;
        private double _orderTotal;
        public VendorOrder(int vendorId)
        {
            VendorID = vendorId;
            LineItems = new List<VendorOrderLineItem>();
        }
        public VendorOrder(int id, int vendorId)
        {
			Id = id;
            VendorID = vendorId;
            LineItems = new List<VendorOrderLineItem>();
        }
		public int VendorID 
		{
			get {return _vendorId;}
			set {_vendorId = value;}
		}
		public int ShipmentsReceived 
		{
			get {return _shipmentsReceived;}
			set {_shipmentsReceived = value;}
		}
		public List<VendorOrderLineItem> LineItems 
		{
			get{return _lineItems;}
			set{_lineItems = value;}
		}
        public bool Finalized
        {
            get { return _finalized; }
            set{_finalized = value;}
        }
        public DateTime DateOrdered
        {
            get { return _dateOrdered; }
            set { _dateOrdered = value; }
        }
        public double OrderTotal
        {
            get 
            {
                _orderTotal = 0.0;
                foreach (var item in _lineItems)
                {
                    _orderTotal += item.LineItemTotal; 
                }
                return _orderTotal;
            }
            set { _orderTotal = value; }
        }
		public void AddLineItem(VendorOrderLineItem lineItem)
		{
			_lineItems.Add(lineItem);
		}
        public void RemoveLineItem(VendorOrderLineItem lineItem)
        {
            if (_lineItems.Contains(lineItem))
            {
                _lineItems.Remove(lineItem);
            }
            else
            {
                //not sure if we need to throw this. 
                throw new ApplicationException("line item doesn't exsist");
            }
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
