using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

/*
*                               Changelog
* Date         By               Ticket          Version          Description
* 04/19/2014   Kaleb Wendel                                      Adjusted class to implement a singleton pattern so only one form can be instantiated.
*/

namespace com.Farouche
{
    public partial class FrmShippingVendor : Form
    {
        private readonly AccessToken _myAccessToken;
        private ShippingVendorManager _myVendorManager;
        public static FrmShippingVendor Instance;

        public FrmShippingVendor(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _myVendorManager = new ShippingVendorManager();
            PopulateVendorListView(this.lvShippingVendors, _myVendorManager.GetVendors());
            Instance = this;
        }

        private void FrmShippingVendor_Load(object sender, EventArgs e)
        {
            //Populates the active combo box. 
            this.PopulateActiveCombo();
            PopulateVendorListView(this.lvShippingVendors, _myVendorManager.GetVendors());
            SetDefaults();
        }//End FrmShippingVendor_Load(..)

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
        private void SetDefaults()
        {
            btnUpdateVendor.Enabled = false;
            btnDeactivateVendor.Enabled = false;
            btnActivateVendor.Enabled = false;
        }//End of setDefaults()

        private void lvShippingVendors_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvShippingVendors.SelectedItems[0].Index;
            ShippingVendor thisVendor = _myVendorManager.ShippingVendors[currentIndex];
            if (thisVendor.Active == true)
            {
                btnActivateVendor.Enabled = false;
                btnDeactivateVendor.Enabled = true;
            }
            else
            {
                btnActivateVendor.Enabled = true;
                btnDeactivateVendor.Enabled = false;
            }
            btnUpdateVendor.Enabled = true;
        }//End of lvShippingVendors_Click(..)

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            FrmAddShippingVendor form = new FrmAddShippingVendor();
            form.ShowDialog();
            SetDefaults();
            PopulateVendorListView(this.lvShippingVendors, _myVendorManager.GetVendors());
        }//End of btnAddVendor_Click(..)

        private void btnUpdateVendor_Click(object sender, EventArgs e)
        {
            var currentIndex = this.lvShippingVendors.SelectedIndices[0];
            FrmUpdateShippingVendor form = new FrmUpdateShippingVendor(_myVendorManager.ShippingVendors[currentIndex]);
            form.ShowDialog();
            SetDefaults();
            PopulateVendorListView(this.lvShippingVendors, _myVendorManager.GetVendors());
        }//End of btnUpdateVendor_Click(..)

        private void FrmShippingVendor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }//End of FrmShippingVendor_FormClosed(..)
    }
}
