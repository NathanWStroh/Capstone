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
        private AccessToken _myAccessToken;

        public FrmViewOrderDetails(ShippingOrder order, AccessToken accToken)
        {
            InitializeComponent();
            _myAccessToken = accToken;
            _myOrder = order;
            _myOrderDetails = new ShippingOrderLineItemManager();
        }// End FrmViewOrderDetails(..)

        public void FrmViewOrderDetails_Load(object sender, EventArgs e)
        {
            PopulateListView(lvItemsForPick, _myOrderDetails.GetLineItemsByID(_myOrder.ID), false);
            PopulateListView(lvItemsForPick, _myOrderDetails.GetLineItemsByID(_myOrder.ID), true);
        }// End FrmViewOrderDetails_Load(..)

        private void PopulateListView(ListView lv, List<ShippingOrderLineItem> orderItemList, Boolean value)
        {
            foreach (var orderItem in orderItemList)
            {
                if (orderItem.IsPicked == value)
                {
                    lv.Items.Clear();
                    lv.Columns.Clear();
                    var item = new ListViewItem();
                    item.Text = orderItem.ProductId.ToString();
                    item.SubItems.Add(orderItem.ProductName);
                    item.SubItems.Add(orderItem.Quantity.ToString());
                    item.SubItems.Add(orderItem.ProductLocation);
                    lv.Items.Add(item);
                }
            }
            lv.Columns.Add("ProductID");
            lv.Columns.Add("Name");
            lv.Columns.Add("Quantity");
            lv.Columns.Add("Location");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of PopulateListView(..)

        private void BtnPrintDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Printing order details to nearest printer...", "Printing");
        }//End of BtnPrintDetails_Click(..)

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            Boolean success = _myOrderManager.UpdatePickedTrue(_myOrder);
            if (success == true)
            {
                if(lvItemsForPick.Items.Count.Equals(0))
                {
                    //MessageBox.Show("Order has been sent to packing queue", "Ready for Packing");
                    //frmViewOrder myForm = new frmViewOrder(_myAccessToken);
                    //myForm.Show();
                    //Hide();
                }
                else
                {
                    MessageBox.Show("Not all items for this order have been picked", "Slacker!");
                }
            }
            else
            { 
                MessageBox.Show("Action Could Not Be Completed", "Error");
            }
        }//End of BtnComplete_Click(..)

        private void BtnPick_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedItem = this.lvItemsForPick.Items[0].Index;
                Boolean success = _myOrderDetails.UpdatePickedTrue(_myOrderDetails.LineItems[selectedItem]);
                if (success == true)
                {
                    PopulateListView(lvItemsForPick, _myOrderDetails.GetLineItemsByID(_myOrder.ID), false);
                    PopulateListView(lvPickedItems, _myOrderDetails.GetLineItemsByID(_myOrder.ID), true);
                }
                else
                {
                    MessageBox.Show("Action could not be completed", "Error");
                }
            }
            catch
            {
                MessageBox.Show("Please select an item from the list", "No Item Selected");
            }
        }// End BtnPick_Click(..)

        private void BtnUnpick_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedItem = this.lvItemsForPick.Items[0].Index;
                Boolean success = _myOrderDetails.UpdatePickedFalse(_myOrderDetails.LineItems[selectedItem]);
                if (success == true)
                {
                    PopulateListView(lvItemsForPick, _myOrderDetails.GetLineItemsByID(_myOrder.ID), false);
                    PopulateListView(lvPickedItems, _myOrderDetails.GetLineItemsByID(_myOrder.ID), true);
                }
                else
                {
                    MessageBox.Show("Action could not be completed", "Error");
                }
            }
            catch
            {
                MessageBox.Show("Please select an item from the list", "No Item Selected");
            }
        }//End of BtnUnpick_Click(..)
    }
}
