using System;

//Author: Andrew    
//Date Created: 3/2/2014
//Last Modified: 3/2/2014 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 
* 
*/

namespace com.Farouche.Commons
{
    class ShippingTerm
    {

        private int _Id;
        private int _shippingVendorID;
        private string _description;


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
        public override string ToString()
        {
            return string.Format("ID: {0}, ShippingVendorId: {1}, Description, {2}", Id, ShippingVendorId, Description);
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
