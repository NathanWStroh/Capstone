using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
using System.Drawing.Printing;
//Author: Ben Grimes
//Created: 3/5/14
//Last Edited By:
//Last Edited Date:

namespace com.Farouche
{
    public partial class FrmViewOrderDetails : Form
    {
        private ShippingOrderLineItemManager _myOrderDetails;
        private ShippingOrderManager _myOrderManager;
        private ShippingOrder _myOrder;
        private List<ShippingOrderLineItem> pickList;
        private int _myOrderId;
        private AccessToken _myAccessToken;

        public FrmViewOrderDetails(int orderId, AccessToken accToken)
        {
            InitializeComponent();
            Text += "                 Details for Order #" + _myOrderId;  
            _myAccessToken = accToken;
            _myOrderId = orderId;
            _myOrderDetails = new ShippingOrderLineItemManager();
            _myOrderManager = new ShippingOrderManager();
            PopulateLineItemLists();
        }// End FrmViewOrderDetails(..)

        private void PopulateLineItemLists()
        {
            PopulateListViews(lvItemsForPick, _myOrderDetails.GetLineItemsByID(_myOrderId), false);
            PopulateListViews(lvPickedItems, _myOrderDetails.GetLineItemsByID(_myOrderId), true);
        }//PopulateLineItemLists()

        private void PopulateListViews(ListView lv, List<ShippingOrderLineItem> orderItemList, Boolean value)
        {
            lv.Items.Clear();
            lv.Columns.Clear();
            _myOrderDetails.LineItems = orderItemList;
            pickList = new List<ShippingOrderLineItem>();
            foreach (var orderItem in _myOrderDetails.LineItems)
            {
                if (orderItem.IsPicked == value)
                {
                    var item = new ListViewItem();
                    item.Text = orderItem.ProductId.ToString();
                    item.SubItems.Add(orderItem.ProductName);
                    item.SubItems.Add(orderItem.Quantity.ToString());
                    item.SubItems.Add(orderItem.ProductLocation);
                    lv.Items.Add(item);
                    pickList.Add(orderItem);
                }
            }
            lv.Columns.Add("ProductID");
            lv.Columns.Add("Name");
            lv.Columns.Add("Quantity");
            lv.Columns.Add("Location");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of PopulateListViews...)

        private void BtnPrintDetails_Click(object sender, EventArgs e)
        {
            frmPrintOrderDetails print = new frmPrintOrderDetails(_myOrderId);
            print.Show();
        }//End of BtnPrintDetails_Click(..)

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            _myOrder = _myOrderManager.GetOrderByID(_myOrderId);
            Boolean success = _myOrderManager.UpdatePickedTrue(_myOrder);
            Boolean success2 = _myOrderManager.ClearUserId(_myOrderManager.GetOrderByID(_myOrderId));
            if (success == true && success2 == true)
            {
                if(lvItemsForPick.Items.Count.Equals(0))
                {
                    Close();
                    MessageBox.Show("Order has been sent to shipping.", "Pick Complete");
                }
            }
            else
            {
                if (success == false)
                {
                    MessageBox.Show("Error picking order.", "Pick Fail");
                }
                if (success == false)
                {
                    MessageBox.Show("Error shifting ownership.", "Ownership Change Fail");
                }
            }
        }//End of BtnComplete_Click(..)

        private void BtnPick_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedItem = this.lvItemsForPick.SelectedIndices[0];
                int selectedItemId = Convert.ToInt32(lvItemsForPick.Items[selectedItem].Text);
                ShippingOrderLineItem currentItem = _myOrderDetails.GetLineItem(selectedItemId, _myOrderId);
                Boolean success = _myOrderDetails.UpdatePickedTrue(currentItem);
                if (success == true)
                {
                    PopulateLineItemLists();
                }
                else
                {
                    MessageBox.Show("Action could not be completed", "Error");
                }
                if (lvItemsForPick.Items.Count.Equals(0))
                {
                    btnComplete.Enabled = true;
                }
            }
            catch(ArgumentNullException)
            {
                MessageBox.Show("Please select an item from the list", "No Item Selected");
            }
        }// End BtnPick_Click(..)

        private void BtnUnpick_Click(object sender, EventArgs e)
        {
            try
            {
            int selectedItem = this.lvPickedItems.SelectedIndices[0];
                int selectedItemId = Convert.ToInt32(lvPickedItems.Items[selectedItem].Text);
                ShippingOrderLineItem currentItem = _myOrderDetails.GetLineItem(selectedItemId, _myOrderId);
                Boolean success = _myOrderDetails.UpdatePickedFalse(currentItem);
                if (success == true)
                {
                    PopulateLineItemLists();
                }
                else
                {
                    MessageBox.Show("Action could not be completed", "Error");
                }
                if (lvItemsForPick.Items.Count > 0)
                {
                    btnComplete.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Please select an item from the list", "No Item Selected");
            }
        }

        private void FrmViewOrderDetails_Load_1(object sender, EventArgs e)
        {

        }

      //End of BtnUnpick_Click(..)
    }
}
