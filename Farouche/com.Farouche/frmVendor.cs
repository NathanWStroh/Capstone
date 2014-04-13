using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
//Author: Andrew
//Date Created: 1/31/2014
//Last Modified: 02/7/2014 
//Last Modified By: Adam Chandler

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/7/2014   Adam                          0.0.1b         Updated Instantiation of new objects to use id as parameter
*/
namespace com.Farouche.Presentation
//namespace CapstoneProject
{
    public partial class FrmVendor : Form
    {
        private readonly AccessToken _myAccessToken;
        private VendorManager _myVendorManager = new VendorManager();
        private List<Vendor> _myVendorList = new List<Vendor>();

        public FrmVendor(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _myVendorList = _myVendorManager.GetVendors();
            populateListView(lvVendors, _myVendorList);
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken);
            frm.ShowDialog();
        }

        private void btnUpdateVendor_Click(object sender, EventArgs e)
        {
            //have to add 1 to current index so it grabs the proper vendor id.
            int currentIndex = this.lvVendors.SelectedIndices[0]+1;
            Vendor thisVendor = _myVendorManager.GetVendor(currentIndex);
            FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken, thisVendor);
            frm.ShowDialog();
        }
        private void populateListView(ListView lv, List<Vendor> vendorList)
        {
            try
            {
                vendorList = _myVendorList;
                lv.Clear();

                foreach (var vendor in vendorList)
                {
                    var item = new ListViewItem();
                    item.Text = vendor.Id.ToString();
                    item.SubItems.Add(vendor.Name);
                    item.SubItems.Add(vendor.Address);
                    item.SubItems.Add(vendor.City);
                    item.SubItems.Add(vendor.State);
                    item.SubItems.Add(vendor.Country);
                    item.SubItems.Add(vendor.Zip);
                    item.SubItems.Add(vendor.Contact);
                    item.SubItems.Add(vendor.ContactEmail);
                    item.SubItems.Add(vendor.Phone);
                    item.SubItems.Add(vendor.Active.ToString());
                    lv.Items.Add(item);
                }
                lv.Columns.Add("Id");
                lv.Columns.Add("Name");
                lv.Columns.Add("Address");
                lv.Columns.Add("City");
                lv.Columns.Add("State");
                lv.Columns.Add("Country");
                lv.Columns.Add("Zip Code");
                lv.Columns.Add("Contact");
                lv.Columns.Add("Contact Email");
                lv.Columns.Add("Contact Phone");
                lv.Columns.Add("Active");
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }//end of Try
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while loading the vendor listView. " + ex.ToString());
            }//end of Catch


        }
    }
}
