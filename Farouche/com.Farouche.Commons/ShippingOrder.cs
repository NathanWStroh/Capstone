using System;
using System.Collections.Generic;

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
    class ShippingOrder
    {
        private int _Id;
        private int _purchaseOrderId;
        private int _userId; // picker or packer
        private string _userName; // picker or packer name, not in Shipping Order table, comes from users table?
        private Boolean _picked; //when picked is switched to true, _userID should be set to null
        private DateTime _shipDate;
        private int _shippingTermsId;
        private string _shippingTermDesc; // not in Shipping Order table, but comes from ShippingTerm Table
        private string _shippingVendorName; // // not in ShippingOrder table, but comes from ShippingVendor table
        private string _shipToName;
        private string _shipToAddress;
        private string _shipToCity;
        private string _shipToState;
        private string _shipToZip;
        private List<ShippingOrderLineItem> _shippingOrderLineItemList;



        public ShippingOrder()
        {
        }

        public ShippingOrder(int Id)
        {
            this.ID = Id;
        }

        public int ID
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
        public int PurchaseOrderId
        {
            get
            {
                return _purchaseOrderId;
            }
            set
            {
                _purchaseOrderId = value;
            }
        }
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }
        public string UserName
        {
            get 
            {
                return _userName; 
            }
            set 
            {
                _userName = value; 
            }
        }
        public Boolean Picked
        {
            get
            {
                return _picked;
            }
            set 
            {
                _picked = value;
            }
        }
        public DateTime ShipDate
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
        public int ShippingTermsId
        { 
            get
            {
                return _shippingTermsId;
            }
            set 
            {
                _shippingTermsId = value;
            } 
        }
        // not in Shipping Order table, but comes from ShippingTerm Table
        public string ShippingTermDesc
        {
            get 
            { 
                return _shippingTermDesc; 
            }
            set 
            { 
                _shippingTermDesc = value; 
            }
        }
        // not in ShippingOrder table, but comes from ShippingVendor table
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
                _shipToAddress = value;
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
        public List<ShippingOrderLineItem> ShippingOrderLineItemList
        {
            get
            {
                return _shippingOrderLineItemList;
            }
            set
            {
                _shippingOrderLineItemList = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, PurchaseOrderId: {1}, UserId:, {2}, UserName:, {3}, Picked: {4}, ShipDate: {5}, ShippingTermsId: {6}, ShippingTermsDesc: {7}, ShippingVendorName: {8}, ShipToName: {9}, ShipToAddress: {10}, ShipToCity: {11}, ShipToState: {12}, ShipToZip: {13}, ShippingOrderLineItemList: {14}", ID, PurchaseOrderId, UserId, UserName, Picked, ShipDate, ShippingTermsId, ShippingTermDesc, ShippingVendorName, ShipToName, ShipToAddress, ShipToCity, ShipToState, ShipToZip, ShippingOrderLineItemList);
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