using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

//Author: Ben
//Date Created: 4/4/2014
//Last Modified: 4/4/2014
//Last Modified By: Ben Grimes

/*
*                               Changelog
* Date         By               Ticket          Version          Description
* 04/19/2014   Kaleb Wendel                                      Adjusted class to implement a singleton pattern so only one form can be instantiated.
*/

namespace com.Farouche
{
    public partial class FrmShippingAllOrders : Form
    {
        private readonly AccessToken _myAccessToken;
        private ShippingOrderManager _myOrderManager;
        public static FrmShippingAllOrders Instance;

        public FrmShippingAllOrders(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _myOrderManager = new ShippingOrderManager();
            PopulateMasterListView(lvAllOrders, _myOrderManager.GetAllShippingOrders());
            Instance = this;
        }

        private void FrmShippingAllOrders_Load(object sender, EventArgs e)
        {
            PopulateMasterListView(lvAllOrders, _myOrderManager.GetAllShippingOrders());
        }//End btnClearUser_Click(..)

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
                        PopulateMasterListView(lvAllOrders, _myOrderManager.GetAllShippingOrders());
                    }
                    else
                    {
                        MessageBox.Show("Cannot complete operation.", "Operation Failed");
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }
        }//btnClearUser_Click(..)

        private void btnAssignUser_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedOrderId = (int)this.lvAllOrders.SelectedIndices[0] + 1;
                ShippingOrder currentOrder = _myOrderManager.GetOrderByID(selectedOrderId);
                if (currentOrder.Picked == true || currentOrder.UserId.HasValue)
                {
                    MessageBox.Show("That order is already assigned to someone.", "Cannot Change Employee");
                }
                else if (currentOrder.Picked == true && currentOrder.UserId.HasValue)
                {
                    MessageBox.Show("That order has already shipped.", "Cannot Change Employee");
                }
                else
                {
                    int employee = int.Parse(txtUserId.Text);
                    Boolean success = _myOrderManager.UpdateUserId(currentOrder, employee);
                    if (success == true)
                    {
                        PopulateMasterListView(lvAllOrders, _myOrderManager.GetAllShippingOrders());
                        txtUserId.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Cannot complete operation.", "Operation Failed");
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }
        }//End btnAssignUser_Click(..)

        private void FrmShippingAllOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }//End FrmShippingAllOrders_FormClosed(..)

        private void btnUserDirectory_Click(object sender, EventArgs e)
        {
            frmEmployeeDirectory employeeReport = new frmEmployeeDirectory();
            employeeReport.ShowDialog();
            employeeReport = null;
        }//End btnUserDirectory_Click(..)
    }
}
