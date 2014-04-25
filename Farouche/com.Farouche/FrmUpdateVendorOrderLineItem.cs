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
        
        public FrmUpdateVendorOrderLineItem(VendorOrderLineItem item)
        {
            InitializeComponent();
            this.item = item;
            txtLineItemProductID.Text = item.ProductID.ToString();
            txtLineItemProductName.Text = item.Name;
            txtLineItemQuantityOrdered.Text = item.QtyOrdered.ToString();
            upDownQuantityDamaged.Value = Decimal.Parse(item.QtyDamaged.ToString());
            upDownQuantityReceived.Value = Decimal.Parse(item.QtyReceived.ToString());
            txtLineItemVendorID.Text = item.Id.ToString();
            txtLineItemVendorName.Text = item.LineItemTotal.ToString();
            txtLineItemVendorOrderID.Text = item.VendorOrderId.ToString();
        }

        private void FrmUpdateVendorOrderLineItem_Load(object sender, EventArgs e)
        {
            
        }

        private void btnUpdateLineItem_Click(object sender, EventArgs e)
        {
            
            
            int productId = Int32.Parse(txtLineItemProductID.Text);
            int vendorOrderId = Int32.Parse(txtLineItemVendorOrderID.Text);

            updateItem = new VendorOrderLineItem(vendorOrderId, productId);
            updateItem.Name = txtLineItemProductName.Text;
            updateItem.QtyDamaged = Int32.Parse(upDownQuantityDamaged.Value.ToString());
            updateItem.QtyOrdered = Int32.Parse(txtLineItemQuantityOrdered.Text);
            updateItem.QtyReceived = Int32.Parse(upDownQuantityReceived.Value.ToString());
            updateItem.LineItemTotal = Double.Parse(txtLineItemVendorName.Text);

            int quantityReceived = updateItem.QtyReceived;
            int quantityDamaged = updateItem.QtyDamaged;
            _receivingManager = new ReceivingManager();
            _receivingManager.UpdateQtyDamaged(updateItem, quantityReceived);
            _receivingManager.UpdateQtyReceived(updateItem, quantityDamaged);

        }



        
    }
}
