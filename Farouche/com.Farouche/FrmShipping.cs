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
        private ShippingOrderManager _myOrderManager;

        public FrmShipping(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _myVendorManager = new ShippingVendorManager();
            _myTermManager = new ShippingTermManager();
            _myOrderManager = new ShippingOrderManager();
        }//End FrmShipping(.)

        private void FrmShipping_Load(object sender, EventArgs e)
        {
            Text += "                         " + _myAccessToken.FirstName + " " + _myAccessToken.LastName + " logged in as a " + _myAccessToken.Title;

            //Populates the active combo box. 
            this.PopulateActiveCombo();
            RefreshOrderViews();
            //Populate the vendor list view.
            PopulateVendorListView(this.lvShippingVendors, _myVendorManager.GetVendors());
        }//End FrmShipping_Load(..)

        private void RefreshOrderViews()
        {
            //populateListView(lvAllOrders, _myOrderManager.Get
            PopulateOrderListView(lvPickList, _myOrderManager.GetNonPickedOrders());
            PopulateOrderListView(lvMyOrders, _myOrderManager.GetOrdersByUserId(_myAccessToken.UserID));
            PopulateOrderListView(lvPackList, _myOrderManager.GetPickedOrders());
        }//End of refresh()

        private void PopulateOrderListView(ListView lv, List<ShippingOrder> orderList)
        {
            _myOrderManager.Orders = orderList;
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var order in orderList)
            {
                var item = new ListViewItem();
                item.Text = order.ID.ToString();
                item.SubItems.Add(order.ShippingVendorName);
                item.SubItems.Add(order.Picked.ToString());
                lv.Items.Add(item);
            }
            lv.Columns.Add("OrderID");
            lv.Columns.Add("Vendor");
            lv.Columns.Add("Picked");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of populateListView(..)

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

        //Populates a list view.
        private void PopulateTermListView(ListView lv, List<ShippingTerm> termList)
        {
            _myTermManager.ShippingTerms = termList;
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var term in termList)
            {
                var item = new ListViewItem();
                item.Text = term.Id.ToString();
                item.SubItems.Add(term.ShippingVendorId.ToString());
                if (term.Description.Length > 25)
                {
                    item.SubItems.Add(term.Description.Substring(0,25));
                }
                else
                {
                    item.SubItems.Add(term.Description);
                }
                lv.Items.Add(item);
            }
            lv.Columns.Add("Term ID");
            lv.Columns.Add("Vendor ID");
            lv.Columns.Add("Description");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of PopulateVendorListView(..)

        //Restores default control properties.
        private void setDefaults()
        {
            btnUpdateVendor.Enabled = false;
            btnDeactivateVendor.Enabled = false;
            btnActivateVendor.Enabled = false;
            btnUpdateTerm.Enabled = false;
            btnActivateTerm.Enabled = false;
            btnDeactivateTerm.Enabled = false;
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
            form.ShowDialog();
            setDefaults();
            PopulateVendorListView(this.lvShippingVendors, _myVendorManager.GetVendors());
        }//End of btnAddVendor_Click(..)

        private void btnUpdateVendor_Click(object sender, EventArgs e)
        {
            var currentIndex = this.lvShippingVendors.SelectedIndices[0];
            FrmUpdateShippingVendor form = new FrmUpdateShippingVendor(_myVendorManager.ShippingVendors[currentIndex]);
            form.ShowDialog();
            setDefaults();
            PopulateVendorListView(this.lvShippingVendors, _myVendorManager.GetVendors());
        }//End of btnUpdateVendor_Click(..)

        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            FrmAddShippingTerm form = new FrmAddShippingTerm();
            form.ShowDialog();
            setDefaults();
            PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
        }//End of btnAddTerm_Click(..)

        private void btnUpdateTerm_Click(object sender, EventArgs e)
        {
            var currentIndex = this.lvShippingTerms.SelectedIndices[0];
            FrmUpdateShippingTerm form = new FrmUpdateShippingTerm(_myTermManager.ShippingTerms[currentIndex]);
            form.ShowDialog();
            setDefaults();
            PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
        }//End of btnUpdateTerm_Click(..)

        //Navigation event handlers for the application.
        private void btnVendor_Click(object sender, EventArgs e)
        {
            FrmVendor form = new FrmVendor(_myAccessToken);
            form.Show();
            Close();
        }//End of btnVendor_Click(..)

        private void btnVendorSource_Click(object sender, EventArgs e)
        {
            FrmVendorSource form = new FrmVendorSource(_myAccessToken);
            form.Show();
            Close();
        }//End of btnVendorSource_Click(..)

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            Close();
        }//End of btnLogout_Click(..)

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmProduct form = new FrmProduct(_myAccessToken);
            form.Show();
            Close();
        }//End of btnProduct_click(..)

        private void tabControlShipping_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControlShipping.SelectedIndex)
            {
                case 0:
                    PopulateVendorListView(this.lvShippingVendors, _myVendorManager.GetVendors());
                    setDefaults();
                    break;
                case 1:
                    PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
                    setDefaults();
                    break;
            }
        }//End of tabControlShipping_SelectedIndexChanged(..)

        private void lvShippingTerms_Click(object sender, EventArgs e)
        {
            btnUpdateTerm.Enabled = true;
        }//End of lvShippingTerms_Click(..)

        private void btnDetails_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedOrder = this.lvMyOrders.Items[0].Index;
                FrmViewOrderDetails myForm = new FrmViewOrderDetails(_myOrderManager.Orders[selectedOrder], _myAccessToken);
                myForm.Show();
                Hide();
            }
            catch
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }
        }//End btnDetails(..)

        private void btnStartPick_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedOrder = this.lvPickList.Items[0].Index;
                Boolean success = _myOrderManager.UpdateUserId(_myOrderManager.Orders[selectedOrder], _myAccessToken.UserID);
                if (success == true)
                {
                    FrmViewOrderDetails myForm = new FrmViewOrderDetails(_myOrderManager.Orders[selectedOrder], _myAccessToken);
                    myForm.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Order already taken by another employee", "Please Refresh");
                }
            }
            catch
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }
        }//End btnStartPick(..)

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshOrderViews();
        }//End btnRefresh(..)

        private void btnPackComplete_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedOrder = this.lvPackList.Items[0].Index;
                Boolean success = _myOrderManager.UpdateShippedDate(_myOrderManager.Orders[selectedOrder]);
                if (success == true)
                {
                    MessageBox.Show("Now Printing Pack Slip", "Packing Complete");
                }
                else
                {
                    MessageBox.Show("Cannot complete action.", "Please Refresh");
                }
            }
            catch
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }
        }//End of btnPackComplete_Click(..)

        private void btnClearUser_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedOrder = this.lvAllOrders.Items[0].Index;
                Boolean success = _myOrderManager.ClearUserId(_myOrderManager.Orders[selectedOrder]);
                if (success == true)
                {
                    MessageBox.Show("EmployeeID removed from selected order.", "Action Complete");
                }
                else
                {
                    MessageBox.Show("Cannot complete action.", "Please Refresh");
                }
            }
            catch
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }

        }//End of btnClearUser_Click(..)

    }
}
