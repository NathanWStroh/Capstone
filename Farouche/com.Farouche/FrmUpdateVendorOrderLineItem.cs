using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

namespace com.Farouche
{
    public partial class FrmUpdateVendorOrderLineItem : Form
    {
        private VendorOrderLineItem item;
        private VendorOrderLineItem updateItem;
        private ReceivingManager _receivingManager;
        private readonly AccessToken _myAccessToken;

        public FrmUpdateVendorOrderLineItem(VendorOrderLineItem item, string vendorName, int vendorID, AccessToken acctkn)
        {
            InitializeComponent();

            
            this.item = item;
            txtLineItemProductID.Text = item.ProductID.ToString();
            txtLineItemProductName.Text = item.Name;
            txtLineItemQuantityOrdered.Text = item.QtyOrdered.ToString();
            upDownQuantityDamaged.Value = 0;
            upDownQuantityReceived.Value = 0;
            txtLineItemVendorID.Text = vendorID.ToString();
            txtLineItemVendorOrderID.Text = item.VendorOrderId.ToString();
            txtLineItemVendorName.Text = vendorName;
            txtLineItemVendorName.ReadOnly = true;
            txtLineItemProductID.ReadOnly = true;
            txtLineItemProductName.ReadOnly = true;
            txtLineItemVendorID.ReadOnly = true;
            txtLineItemVendorOrderID.ReadOnly = true;
            txtLineItemQuantityOrdered.ReadOnly = true;

           

        }

        private void FrmUpdateVendorOrderLineItem_Load(object sender, EventArgs e)
        {
            
        }

        private void btnUpdateLineItem_Click(object sender, EventArgs e)
        {
            
            ReceivingManager _receivingManger = new ReceivingManager();
            int productId = Int32.Parse(txtLineItemProductID.Text);
            int vendorOrderId = Int32.Parse(txtLineItemVendorOrderID.Text);

            //int quantityDamaged = 
            
            VendorOrderLineItem oldLineItem = new VendorOrderLineItem(vendorOrderId, productId);
            oldLineItem.QtyReceived = item.QtyReceived;
            oldLineItem.QtyOrdered = item.QtyOrdered;
            oldLineItem.QtyDamaged = item.QtyDamaged;
            updateItem = new VendorOrderLineItem(vendorOrderId, productId);
            updateItem.Name = txtLineItemProductName.Text;
            updateItem.QtyDamaged = Int32.Parse(upDownQuantityDamaged.Value.ToString());
            updateItem.QtyOrdered = Int32.Parse(txtLineItemQuantityOrdered.Text);
            updateItem.QtyReceived = Int32.Parse(upDownQuantityReceived.Value.ToString());
            


            _receivingManager = new ReceivingManager();
            //_receivingManager.UpdateQtyDamaged(oldLineItem, updateItem);
            _receivingManager.UpdateQtyReceived(updateItem, oldLineItem);
            //_receivingManager.UpdateQtyDamaged(updateItem, oldLineItem);
            
            

            MessageBox.Show("Quantity Fields Updated");
           
            this.Close();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        
    }
}
