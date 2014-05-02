using System;

//Author: Andrew    
//Date Created: 3/2/2014
//Last Modified: 3/8/2014 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 5/1/2014     Kaleb                                       Adjusted class to include _shippingVendorName.
* 
*/

namespace com.Farouche.Commons
{
    public class ShippingTerm : Entity
    {

        private int _shippingVendorID;
        private string _description;
        private string _shippingVendorName;

        public ShippingTerm()
        {
        }

        public ShippingTerm(int Id)
        {
            this.Id = Id;
        }
        public int Id
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
        public int ShippingVendorId
        {
            get
            {
                return _shippingVendorID;
            }
            set
            {
                _shippingVendorID = value;
            }
        }
        public string Description
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
        public override string ToString()
        {
            return string.Format("ID: {0}, ShippingVendorId: {1}, Description, {2}", Id, ShippingVendorId, Description);
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
