using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

//Author: Kaleb
//Date Created: 3/6/2014
//Last Modified: 3/6/2014
//Last Modified By: Steven Schuette

/*
 *                               Changelog
 * Date         By          Ticket          Version         Description
 * 
*/

namespace com.Farouche.Presentation
{
    public partial class FrmShipping : Form
    {
        private readonly AccessToken _myAccessToken;
        private ShippingVendorManager _myVendorManager;
        private ShippingTermManager _myTermManager; 

        public FrmShipping(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _myVendorManager = new ShippingVendorManager();
            _myTermManager = new ShippingTermManager();
        }

        private void FrmShipping_Load(object sender, EventArgs e)
        {
            Text += "                         " + _myAccessToken.FirstName + " " + _myAccessToken.LastName + " logged in as a " + _myAccessToken.Title;

            //Populates the active combo box. 
            this.PopulateActiveCombo();

            //Populate the vendor list view.
            PopulateVendorListView(this.lvShippingVendors, _myVendorManager.GetVendors());
        }

        //Populates the Active combo box.
        //Postcondition: The combo box will hold the values (Yes, No, Both).
        private void PopulateActiveCombo()
        {
            Active active;
            for (int i = 1; i >= 0; i--)
            {
                active = (Active)i;
                this.cbVendorStatusSearch.Items.Add(active);
            }
            this.cbVendorStatusSearch.Items.Add("Both");
            this.cbVendorStatusSearch.SelectedIndex = 0;
        }//End of populateActiveCombo()

        //Populates a list view.
        private void PopulateVendorListView(ListView lv, List<ShippingVendor> vendorList)
        {
            _myVendorManager.ShippingVendors = vendorList;
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var vendor in vendorList)
            {
                var item = new ListViewItem();
                item.Text = vendor.Id.ToString();
                item.SubItems.Add(vendor.Name);
                item.SubItems.Add(vendor.Address);
                item.SubItems.Add(vendor.City);
                item.SubItems.Add(vendor.State);
                item.SubItems.Add(vendor.Zip);
                item.SubItems.Add(vendor.Country);
                item.SubItems.Add(vendor.Phone);
                item.SubItems.Add(vendor.Contact);
                item.SubItems.Add(vendor.ContactEmail);
                lv.Items.Add(item);
            }
            lv.Columns.Add("Vendor ID");
            lv.Columns.Add("Name");
            lv.Columns.Add("Address");
            lv.Columns.Add("City");
            lv.Columns.Add("State");
            lv.Columns.Add("Zip");
            lv.Columns.Add("Country");
            lv.Columns.Add("Phone");
            lv.Columns.Add("Contact");
            lv.Columns.Add("Email");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of PopulateVendorListView(..)

        //Restores default control properties.
        private void setDefaults()
        {
            btnUpdateVendor.Enabled = false;
            btnDeactivateVendor.Enabled = false;
            btnActivateVendor.Enabled = false;
        }//End of setDefaults()

        private void lvShippingVendors_Click(object sender, EventArgs e)
        {
            //int currentIndex = this.lvShippingVendors.SelectedItems[0].Index;
            //ShippingVendor thisVendor = _myVendorManager.ShippingVendors[currentIndex];
            //if (thisVendor.Active == true)
            //{
            //    btnActivateVendor.Enabled = false;
            //    btnDeactivateVendor.Enabled = true;
            //}
            //else
            //{
            //    btnActivateVendor.Enabled = true;
            //    btnDeactivateVendor.Enabled = false;
            //}
            btnUpdateVendor.Enabled = true;
        }//End of lvShippingVendors_Click(..)

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            FrmAddShippingVendor form = new FrmAddShippingVendor();
            form.Show();
        }

        private void btnUpdateVendor_Click(object sender, EventArgs e)
        {
            FrmUpdateShippingVendor form = new FrmUpdateShippingVendor();
            form.Show();
        }

        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            FrmAddShippingTerm form = new FrmAddShippingTerm();
            form.Show();
        }

        private void btnUpdateTerm_Click(object sender, EventArgs e)
        {
            FrmUpdateShippingTerm form = new FrmUpdateShippingTerm();
            form.Show();
        }

        //Navigation event handlers for the application.
        private void btnVendor_Click(object sender, EventArgs e)
        {
            FrmVendor form = new FrmVendor(_myAccessToken);
            form.Show();
            Close();
        }

        private void btnVendorSource_Click(object sender, EventArgs e)
        {
            FrmVendorSource form = new FrmVendorSource(_myAccessToken);
            form.Show();
            Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            Close();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmProduct form = new FrmProduct(_myAccessToken);
            form.Show();
            Close();
        }
    }
}
