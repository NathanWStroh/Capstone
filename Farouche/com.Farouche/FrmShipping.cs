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
            Text += "                         " + _myAccessToken.FirstName + " " + _myAccessToken.LastName + " logged in as a " + _myAccessToken.Role.Name;

            //Populates the active combo box. 
            this.PopulateActiveCombo();
            RefreshOrderViews();
            //Populate the vendor list view.
            PopulateVendorListView(this.lvShippingVendors, _myVendorManager.GetVendors());
        }//End FrmShipping_Load(..)

        private void RefreshOrderViews()
        {
            PopulateMasterListView(lvAllOrders, _myOrderManager.GetAllShippingOrders());
            PopulateOrderListView(lvPickList, _myOrderManager.GetNonPickedOrders());
            PopulateOrderListView(lvMyOrders, _myOrderManager.GetOrdersByUserId(_myAccessToken.UserID));
            PopulatePackListView(lvPackList, _myOrderManager.GetPickedOrders());
        }//End of refresh()

        private void PopulateMasterListView(ListView lv, List<ShippingOrder> orderlist)
        {
            _myOrderManager.Orders = orderlist;
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var order in _myOrderManager.Orders)
            {
                var item = new ListViewItem();
                item.Text = order.ID.ToString();
                item.SubItems.Add(order.ShippingVendorName);
                item.SubItems.Add(order.ShippingTermDesc);
                if (order.UserId.HasValue)
                {
                    item.SubItems.Add(order.UserId.ToString());
                    item.SubItems.Add(order.UserFirstName.ToString());
                    item.SubItems.Add(order.UserLastName.ToString());
                }
                else
                {
                    item.SubItems.Add(" ");
                    item.SubItems.Add(" ");
                    item.SubItems.Add(" ");
                }
                item.SubItems.Add(order.Picked.ToString());
                item.SubItems.Add(order.ShipDate.ToString());
                lv.Items.Add(item);
            }
            lv.Columns.Add("OrderID");
            lv.Columns.Add("Vendor");
            lv.Columns.Add("ShipTerm");
            lv.Columns.Add("UserID");
            lv.Columns.Add("FirstName");
            lv.Columns.Add("LastName");
            lv.Columns.Add("Picked");
            lv.Columns.Add("ShipDate");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End PopulateMasterListView(..)

        private void PopulatePackListView(ListView lv, List<ShippingOrder> orderList)
        {
            _myOrderManager.Orders = orderList;
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var order in _myOrderManager.Orders)
            {
                if (!order.UserId.HasValue)
                {
                    var item = new ListViewItem();
                    item.Text = order.ID.ToString();
                    item.SubItems.Add(order.ShippingVendorName);
                    item.SubItems.Add(order.ShippingTermDesc);
                    item.SubItems.Add(order.ShipToName);
                    item.SubItems.Add(order.ShipToAddress);
                    item.SubItems.Add(order.ShipToCity);
                    item.SubItems.Add(order.ShipToState);
                    item.SubItems.Add(order.ShipToZip);
                    item.SubItems.Add(order.Picked.ToString());
                    lv.Items.Add(item);
                }
            }
            lv.Columns.Add("OrderID");
            lv.Columns.Add("Vendor");
            lv.Columns.Add("ShipTerm");
            lv.Columns.Add("CustomerName");
            lv.Columns.Add("Address");
            lv.Columns.Add("City");
            lv.Columns.Add("State");
            lv.Columns.Add("ZipCode");
            lv.Columns.Add("Picked");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End PopulatePackListView(..)

        private void PopulateOrderListView(ListView lv, List<ShippingOrder> orderList)
        {
            _myOrderManager.Orders = orderList;
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var order in _myOrderManager.Orders)
            {
                var item = new ListViewItem();
                item.Text = order.ID.ToString();
                item.SubItems.Add(order.ShippingVendorName);
                if (order.UserId.HasValue)
                {
                    item.SubItems.Add(order.UserId.ToString());
                    item.SubItems.Add(order.UserFirstName.ToString());
                    item.SubItems.Add(order.UserLastName.ToString());
                }
                else
                {
                    item.SubItems.Add(" ");
                    item.SubItems.Add(" ");
                    item.SubItems.Add(" ");
                }
                item.SubItems.Add(order.Picked.ToString());
                lv.Items.Add(item);
            }
            lv.Columns.Add("OrderID");
            lv.Columns.Add("Vendor");
            lv.Columns.Add("UserID");
            lv.Columns.Add("FirstName");
            lv.Columns.Add("LastName");
            lv.Columns.Add("Picked");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of PopulateOrderListView(..)

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
        private void SetDefaults()
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

        private void btnAddTerm_Click(object sender, EventArgs e)
        {
            FrmAddShippingTerm form = new FrmAddShippingTerm();
            form.ShowDialog();
            SetDefaults();
            PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
        }//End of btnAddTerm_Click(..)

        private void btnUpdateTerm_Click(object sender, EventArgs e)
        {
            var currentIndex = this.lvShippingTerms.SelectedIndices[0];
            FrmUpdateShippingTerm form = new FrmUpdateShippingTerm(_myTermManager.ShippingTerms[currentIndex]);
            form.ShowDialog();
            SetDefaults();
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
                    SetDefaults();
                    break;
                case 1:
                    PopulateTermListView(this.lvShippingTerms, _myTermManager.GetTerms());
                    SetDefaults();
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
                int selectedOrder = (int)this.lvMyOrders.SelectedIndices[0] + 1;
                InitPick(selectedOrder);
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }
        }//End btnDetails(..)

        private void InitPick(int selectedOrder)
        {
            FrmViewOrderDetails details = new FrmViewOrderDetails(_myOrderManager.GetOrderByID(selectedOrder).ID, _myAccessToken);
            details.FormClosed += new FormClosedEventHandler(Details_FormClosed);
            details.Show();
        }//End initPick(.)

        private void Details_FormClosed(object sender, EventArgs e)
        {
            RefreshOrderViews();
        }

        private void btnStartPick_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedOrder = (int)this.lvPickList.SelectedIndices[0] + 1;
                ShippingOrder myOrder = _myOrderManager.GetOrderByID(selectedOrder);
                if(myOrder.UserId.HasValue)
                {
                    MessageBox.Show("Ownership belongs to another", "Already Assigned");
                }
                else
                {
                    Boolean success = _myOrderManager.UpdateUserId(myOrder, _myAccessToken.UserID);
                    if (success == true)
                    {
                       RefreshOrderViews();
                       InitPick(selectedOrder);
                    }
                    else
                    {
                       MessageBox.Show("Ownership of pick to you has failed", "Assignment Failed");
                       RefreshOrderViews();
                    }
                }
            }
            catch(ArgumentOutOfRangeException)
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
                int selectedOrder = (int)this.lvPackList.SelectedIndices[0] + 1;
                ShippingOrder currentOrder = _myOrderManager.GetOrderByID(selectedOrder);
                Boolean success = _myOrderManager.UpdateShippedDate(currentOrder);
                _myOrderManager.UpdateUserId(currentOrder, _myAccessToken.UserID);
                if (success == true)
                {
                    MessageBox.Show("Now Printing Pack Slip", "Packing Complete");
                    RefreshOrderViews();
                }
                else
                {
                    MessageBox.Show("Cannot complete action.", "Please Refresh");
                    RefreshOrderViews();
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }
        }//End of btnPackComplete_Click(..)

        private void btnClearUser_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedOrderId = (int)this.lvAllOrders.SelectedIndices[0] + 1;
                ShippingOrder currentOrder = _myOrderManager.GetOrderByID(selectedOrderId);
                if (currentOrder.Picked == true && currentOrder.UserId.HasValue)
                {
                    MessageBox.Show("That order has already been shipped.", "Cannot Change Employee");
                }
                else
                {
                    Boolean success = _myOrderManager.ClearUserId(currentOrder);
                    if (success == true)
                    {
                        RefreshOrderViews();
                    }
                    else
                    {
                        MessageBox.Show("Cannot complete operation.", "Operation Failed");
                    }
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }

        }//End of btnClearUser_Click(..)

    }
}
