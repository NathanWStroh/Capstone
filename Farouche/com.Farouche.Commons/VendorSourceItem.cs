using System;

//Author: Adam
//Date Created: 1/31/2014
//Last Modified: 2/14/2014 
//Last Modified By: Adam Chandler

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 2/14/2014   Adam                          0.0.2         Updated to use mintQtyToOrder,itemsPerCase and removal of pk id
* 1/31/2014   Adam                          0.0.1b        Updated VendorSourceItem to inherit Entity
*/
namespace com.Farouche.Commons
{
    public class VendorSourceItem:Entity
    {
        private int _productId;
        private int _vendorId;
        private Decimal _unitCost;
        private int _minQtyToOrder;
        private int _itemsPerCase;

        public VendorSourceItem(int vendorId,int productId)
        {
            this.ProductID = productId;
            VendorID = vendorId;
        }

        public VendorSourceItem()
        {
        }

        public int ProductID
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
        public int VendorID
        {
            get
            {
                return _vendorId;
            }
            set
            {
                _vendorId = value;
            }
        }
        public int MinQtyToOrder
        {
            get
            {
                return _minQtyToOrder;
            }
            set
            {
                _minQtyToOrder = value;
            }
        }
        public int ItemsPerCase
        {
            get
            {
                return _itemsPerCase;
            }
            set
            {
                _itemsPerCase = value;
            }
        }
        public Decimal UnitCost
        {
            get
            {
                return _unitCost;
            }
            set
            {
                _unitCost= value;
            }
        }
        public override string ToString()
        {
            return string.Format("ID: {0}, VendorId: {1}, ProductId, {2}, UnitCost: {3}, MinQty: {4}", Id, VendorID, ProductID, UnitCost, MinQtyToOrder);
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
