using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using com.Farouche.Commmons;
using com.Farouche.DataAccess;

//Author: Adam
//Date Created: 1/31/2014
//Last Modified: 02/07/2014
//Last Modified By: Adam Chandler

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/07/2014   Adam                          0.0.2         Updated to use the same connection.
* 02/07/2014   Adam                          0.0.1b        Updated method names and class name.
* 
*/
namespace com.Farouche.BusinessLogic
{
    public class VendorSourceItemManager : DatabaseConnection
    {
        private readonly SqlConnection _connection = GetInventoryDbConnection();
        //Error Checking Will Need To Be Added
        public List<VendorSourceItem> GetAllVendorSourceItems()
        {
            var vendorSrcItemList = VendorSourceItemDAL.GetAllVendorSourceItems(_connection);

            return vendorSrcItemList;
        }

        public Boolean AddVendorSourceItem(VendorSourceItem vendorSrcItem)
        {
            //Do error checking here
            return VendorSourceItemDAL.AddVendorSourceItem(vendorSrcItem, _connection);
        }
        public List<VendorSourceItem> GetVendorSourceItemsByVendor(int vendorId)
        {
            var vendorSrcItemList = VendorSourceItemDAL.GetVendorSourceItemsByVendor(vendorId, _connection);

            return vendorSrcItemList;
        }

        public List<VendorSourceItem> GetVendorSourceItemsByProduct(int productId)
        {
            var vendorSrcItemList = VendorSourceItemDAL.GetVendorSourceItemsByProduct(productId, _connection);

            return vendorSrcItemList;
        }

        public VendorSourceItem GetVendorSourceItem(int vendorSrcItemId)
        {
            return VendorSourceItemDAL.GetVendorSourceItem(vendorSrcItemId, _connection);
        }
        public Boolean UpdateVendorSourceItem(VendorSourceItem vendorSrcItem, VendorSourceItem origVendorSrcItem)
        {
            return VendorSourceItemDAL.UpdateVendorSourceItem(vendorSrcItem, origVendorSrcItem, _connection);
        }
        public Boolean DeactivateVendorSourceItem(VendorSourceItem vendorSrcItem)
        {
            return VendorSourceItemDAL.DeactivateVendorSourceItem(vendorSrcItem, _connection);
        }
        public Boolean ReactivateVendorSourceItem(VendorSourceItem vendorSrcItem)
        {
            return VendorSourceItemDAL.ReactivateVendorSourceItem(vendorSrcItem, _connection);
        }
        public Boolean DeleteVendorSourceItem(VendorSourceItem vendorSrcItem)
        {
            return VendorSourceItemDAL.DeleteVendorSourceItem(vendorSrcItem, _connection);
        }
    }
}
