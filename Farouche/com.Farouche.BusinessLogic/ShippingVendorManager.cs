using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.Commons;
using com.Farouche.DataAccess;
using System.Data.SqlClient;

//Author: Kaleb W
//Date Created: 3/5/2014
//Last Modified: 3/5/2014
//Last Modified By: Kaleb W

/*
 *                               Changelog
 * Date         By          Ticket          Version         Description
 * 
*/

namespace com.Farouche.BusinessLogic
{
    public class ShippingVendorManager : DatabaseConnection
    {
        //Cretates a new connection.
        private readonly SqlConnection _connection = GetInventoryDbConnection();
        //Private member used to store the list of vendors.
        private List<ShippingVendor> _shippingVendors = null;
        //Private member used to store a single vendor.
        private ShippingVendor _shippingVendor = null;

        //Used to retrieve the list of vendors.
        public List<ShippingVendor> ShippingVendors
        {
            get
            {
                return _shippingVendors;
            }
            set
            {
                _shippingVendors = value;
            }
        }//End of ShippingVendors sets/gets.

        //Used to retrieve a single vendor.
        public ShippingVendor ShippingVendor
        {
            get
            {
                return _shippingVendor;
            }
            set
            {
                _shippingVendor = value;
            }
        }//End of ShippingVendor sets/gets.

        public bool Insert(ShippingVendor vendor)
        {
            //Need to do error checking... Try/Catch.
            return ShippingVendorDAL.AddShippingVendor(vendor, _connection);
        }//End of Insert(.)

        public bool Update(ShippingVendor vendor, ShippingVendor originalVendor)
        {
            //Need to do error checking... Try/Catch.
            return ShippingVendorDAL.UpdateShippingVendor(vendor, originalVendor, _connection);
        }//End of Update(..)

        public ShippingVendor GetVendorById(int vendorId)
        {
            //Need to do error checking... Try/Catch.
            ShippingVendor = ShippingVendorDAL.GetShippingVendorById(vendorId, _connection);
            return ShippingVendor;
        }//End of GetVendorById(.)

        public List<ShippingVendor> GetVendors()
        {
            //Need to do error checking... Try/Catch.
            ShippingVendors = ShippingVendorDAL.GetAllShippingVendors(_connection);
            return ShippingVendors;
        }//End of GetVendors(.)

        public List<ShippingVendor> GetShippingVendorsByActive(Boolean activeState)
        {
            ShippingVendors = ShippingVendorDAL.GetVendorsByActive(activeState, _connection);
            return ShippingVendors;
        }

        public Boolean ReactivateVendor(ShippingVendor shippingVendor)
        {
            if (shippingVendor == null) throw new ArgumentException("The shipping vendor was null, therefore it cannot be set to active.");
            return ShippingVendorDAL.ReactivateVendor(shippingVendor, _connection);
        }

        public Boolean DeactivateVendor(ShippingVendor shippingVendor)
        {
            if (shippingVendor == null) throw new ArgumentException("The shipping vendor was null, therefore it cannot be set to inactive.");
            return ShippingVendorDAL.DeactivateVendor(shippingVendor, _connection);
        }

        public Boolean DeleteVendor(ShippingVendor shippingVendor)
        {
            if (shippingVendor == null) throw new ArgumentException("The shipping vendor was null, therefore it could not be deleted.");
            return ShippingVendorDAL.DeleteVendor(shippingVendor, _connection);
        }
    }//End of class.
}//End of namespace.
