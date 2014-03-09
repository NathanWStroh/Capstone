using System;
using System.Collections.Generic;

//Author: Andrew
//Date Created: 2/23/2014
//Last Modified: 3/8/2014 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 3/6/14       Andrew                                      Added _userFirstName & _userLastName
* 
*/

namespace com.Farouche.Commons
{
    public class ShippingOrder
    {
        private int _Id;
        private int _purchaseOrderId;
        private int? _userId; // picker or packer
        private string _userLastName;
        private string _userFirstName; // picker or packer name, not in Shipping Order table, comes from users table?
        private Boolean _picked; //when picked is switched to true, _userID should be set to null
        private DateTime? _shipDate;
        private int _shippingTermId;
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
        public int? UserId
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
        public string UserLastName
        {
            get
            {
                return _userLastName;
            }
            set
            {
                _userLastName = value;
            }
        }
        public string UserFirstName
        {
            get 
            {
                return _userFirstName; 
            }
            set 
            {
                _userFirstName = value; 
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
            return string.Format("Id: {0}, PurchaseOrderId: {1}, UserId: {2}, UserLastName: {3}, UserFirstName: {4}, Picked: {5}, ShipDate: {6}, ShippingTermsId: {7}, ShippingTermsDesc: {8}, ShippingVendorName: {9}, ShipToName: {10}, ShipToAddress: {11}, ShipToCity: {12}, ShipToState: {13}, ShipToZip: {14}", ID, PurchaseOrderId, UserId, UserLastName, UserFirstName, Picked, ShipDate, ShippingTermId, ShippingTermDesc, ShippingVendorName, ShipToName, ShipToAddress, ShipToCity, ShipToState, ShipToZip);
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