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
    public partial class FrmShippingPickList : Form
    {
        private readonly AccessToken _myAccessToken;
        private ShippingOrderManager _myOrderManager;
        public static FrmShippingPickList Instance;

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
                if (!order.UserId.HasValue)
                {
                    var item = new ListViewItem();
                    item.Text = order.ID.ToString();
                    item.SubItems.Add(order.ShippingVendorName);
                    item.SubItems.Add(" ");
                    item.SubItems.Add(" ");
                    item.SubItems.Add(" ");
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

        private void btnStartPick_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedOrder = (int)this.lvPickList.SelectedIndices[0] + 1;
                ShippingOrder myOrder = _myOrderManager.GetOrderByID(selectedOrder);
                if (!myOrder.UserId.Equals(_myAccessToken.UserID) && myOrder.UserId.HasValue)
                {
                    MessageBox.Show("Ownership belongs to another", "Already Assigned");
                }
                else
                {
                    Boolean success = _myOrderManager.UpdateUserId(myOrder, _myAccessToken.UserID);
                    if (success == true)
                    {
                        InitPick(selectedOrder);
                        RefreshPickView();
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
    }
}
