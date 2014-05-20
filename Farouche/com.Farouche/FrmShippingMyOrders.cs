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
    public partial class FrmShippingMyOrders : Form
    {
        private readonly AccessToken _myAccessToken;
        private ShippingOrderManager _myOrderManager;
        public static FrmShippingMyOrders Instance;
        private int _sortColumn = -1;

        public FrmShippingMyOrders(AccessToken accToken)
        {
            InitializeComponent();
            var RoleAccess = new RoleAccess(accToken, this);
           
            _myAccessToken = accToken;
            _myOrderManager = new ShippingOrderManager();
            RefreshMyOrdersView();
            Instance = this;
        }//End FrmShippingMyOrders(.)

        private void FrmShippingMyOrders_Load(object sender, EventArgs e)
        {
            RefreshMyOrdersView();

        }//End FrmShippingMyOrders_Load(..)

        private void RefreshMyOrdersView()
        {
            PopulateOrderListView(lvMyOrders, _myOrderManager.GetOrdersByUserId(_myAccessToken.Id));
        }//End of RefreshMyOrdersView()

        private void PopulateOrderListView(ListView lv, List<ShippingOrder> orderList)
        {
            btnDetails.Enabled = false;
            _myOrderManager.Orders = orderList;
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var order in _myOrderManager.Orders)
            {
                if (order.Picked == false)
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
            }
            lv.Columns.Add("OrderID");
            lv.Columns.Add("Vendor");
            lv.Columns.Add("UserID");
            lv.Columns.Add("FirstName");
            lv.Columns.Add("LastName");
            lv.Columns.Add("Picked");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of PopulateOrderListView(..)

        private void btnDetails_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedOrder = this.lvMyOrders.SelectedItems;
            try
            {
                int selectedOrderId = Convert.ToInt32(selectedOrder[0].SubItems[0].Text);
                InitPick(selectedOrderId);
                RefreshMyOrdersView();
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Please select an order from the list", "No Order Selected");
            }
        }//End btnDetails_Click(..)

        private void InitPick(int selectedOrderId)
        {
            FrmViewOrderDetails details = new FrmViewOrderDetails(_myOrderManager.GetOrderByID(selectedOrderId).ID, _myAccessToken);
            details.ShowDialog();
        }//End InitPick(.)

        private void FrmShippingMyOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }//End of FrmShippingMyOrders_FormClosed(..)

        private void lvMyOrders_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine whether the column is the same as the last column clicked.
            if (e.Column != _sortColumn)
            {
                // Set the sort column to the new column.
                _sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lvMyOrders.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lvMyOrders.Sorting == SortOrder.Ascending)
                    lvMyOrders.Sorting = SortOrder.Descending;
                else
                    lvMyOrders.Sorting = SortOrder.Ascending;
            }
            // Call the sort method to manually sort.
            lvMyOrders.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer object.
            this.lvMyOrders.ListViewItemSorter = new ListViewItemComparer(e.Column, lvMyOrders.Sorting);
        }//End lvMyOrders_ColumnClick(..)

        private void lvMyOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDetails.Enabled = true;
        }//End lvMyOrders_SelectedIndexChanged(..)
    }
}
