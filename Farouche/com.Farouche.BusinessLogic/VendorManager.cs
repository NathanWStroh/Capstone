using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using com.Farouche.DataAccess;
using com.Farouche.Commons;
//Author: Andrew Willhoit
//Date Created: 1/31/2014
//Last Modified: 02/09/2014
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/09/2014   Andrew                        0.0.2         Updated to use same connection, added CRUD methods
* 02/07/2014   Adam                          0.0.1b        Updated method names and class name.
*/

namespace com.Farouche.BusinessLogic
{
    public class VendorManager : DatabaseConnection
    {
        private readonly SqlConnection _connection = GetInventoryDbConnection();


        public List<Vendor> GetVendors()
        {
            List<Vendor> vendorList = VendorDAL.GetAllVendors(_connection);
            return vendorList;
        }

        public List<Vendor> GetVendorsByActive(Boolean active)
        {
            List<Vendor> vendorList = VendorDAL.GetAllVendorsByActive(active, _connection);
            return vendorList;
        }

        public Vendor GetVendor(int vendorId)
        {
            return VendorDAL.GetVendor(vendorId, _connection);
        }

        public Boolean UpdateVendor(Vendor vendor, Vendor origVendor)
        {
            return VendorDAL.UpdateVendor(vendor, origVendor, _connection);
        }

        public Boolean DeactivateVendor(Vendor vendor)
        {
            return VendorDAL.DeactivateVendor(vendor, _connection);
        }

        public Boolean ReactivateVendor(Vendor vendor)
        {
            return VendorDAL.ReactivateVendor(vendor, _connection);
        }

        public Boolean DeleteVendor(Vendor vendor)
        {
            return VendorDAL.DeleteVendor(vendor, _connection);
        }

        // add a vendor to the DB
        public Boolean AddVendor(Vendor vendor)
        {
            return VendorDAL.AddVendor(vendor, _connection);
        }
    }
}
