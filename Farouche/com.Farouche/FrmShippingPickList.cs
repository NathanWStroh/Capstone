﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

/*
*                               Changelog
* Date         By               Ticket          Version          Description
* 04/19/2014   Kaleb Wendel                                      Adjusted class to implement a singleton pattern so only one form can be instantiated.
* 05/25/2014   Ben Grimes                                        Added column sorting to listview headers
 */

namespace com.Farouche
{
    public partial class FrmShippingPickList : Form
    {
        private readonly AccessToken _myAccessToken;
        private ShippingOrderManager _myOrderManager;
        public static FrmShippingPickList Instance;
        private int _sortColumn = -1;

        public FrmShippingPickList(AccessToken accToken)
        {
            InitializeComponent();
            _myAccessToken = accToken;
            _myOrderManager = new ShippingOrderManager();
            RefreshPickView();
            Instance = this;
        }

        private void FrmShippingPickList_Load(object sender, EventArgs e)
        {
            RefreshPickView();
        }

        private void PopulatePickListView(ListView lv, List<ShippingOrder> orderList)
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

        private void btnStartPick_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedOrder = this.lvPickList.SelectedItems;
            try
            {
                int selectedOrderId = Convert.ToInt32(selectedOrder[0].SubItems[0].Text);
                ShippingOrder myOrder = _myOrderManager.GetOrderByID(selectedOrderId);
                if(myOrder.UserId.Equals(_myAccessToken.UserID))
                {
                    MessageBox.Show("Order is already in your 'My Orders' queue", "Action Unnecessary");
                }
                else if(myOrder.UserId.HasValue)
                {
                    MessageBox.Show("Order already belongs to another person", "Action Failed");
                }
                else
                {
                    Boolean success = _myOrderManager.UpdateUserId(myOrder, _myAccessToken.UserID);
                    if (success == true)
                    {
                        RefreshPickView();
                        InitPick(selectedOrderId);
                    }
                    else
                    {
                        MessageBox.Show("Ownership of pick to you has failed", "Assignment Failed");
                        RefreshPickView();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }
        }//End btnStartPick(..)

        private void InitPick(int selectedOrder)
        {
            FrmViewOrderDetails details = new FrmViewOrderDetails(_myOrderManager.GetOrderByID(selectedOrder).ID, _myAccessToken);
            details.FormClosed += new FormClosedEventHandler(Details_FormClosed);
            details.ShowDialog();
        }//End initPick(.)

        private void Details_FormClosed(object sender, EventArgs e)
        {
            RefreshPickView();
        }

        private void RefreshPickView()
        {
            PopulatePickListView(lvPickList, _myOrderManager.GetNonPickedOrders());
        }

        private void FrmShippingPickList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

        private void lvPickList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != _sortColumn)
            {
                // Set the sort column to the new column.
                _sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lvPickList.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lvPickList.Sorting == SortOrder.Ascending)
                    lvPickList.Sorting = SortOrder.Descending;
                else
                    lvPickList.Sorting = SortOrder.Ascending;
            }
            // Call the sort method to manually sort.
            lvPickList.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer object.
            this.lvPickList.ListViewItemSorter = new ListViewItemComparer(e.Column, lvPickList.Sorting);
        }
    }
}
