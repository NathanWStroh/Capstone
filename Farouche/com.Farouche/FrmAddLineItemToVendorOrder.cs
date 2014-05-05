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
    public partial class FrmAddLineItemToVendorOrder : Form
    {
        VendorOrder vendorOrder;
        public FrmAddLineItemToVendorOrder(VendorOrder vendorOrder)
        {
            InitializeComponent();
            this.vendorOrder = vendorOrder;
            txtVendorOrderID.Text = vendorOrder.Id.ToString();
            VendorManager _vendorManager = new VendorManager();

            var vendor = vendorOrder.VendorID;
            txtVendorName.Text = _vendorManager.GetVendor(vendorOrder.VendorID).Name;
            txtVendorID.Text = vendorOrder.VendorID.ToString();
            txtVendorName.ReadOnly = true;
            txtVendorID.ReadOnly = true;
            fillProductDropDown(vendorOrder.VendorID);
            
        }
        private void fillProductDropDown(Int32 vendorID)
        {
            cbProductName.Items.Clear();
            List<VendorSourceItem> vendorSourceItemList = new List<VendorSourceItem>();
            VendorSourceItemManager _vendorSourceItemManager = new VendorSourceItemManager();
            vendorSourceItemList = _vendorSourceItemManager.GetVendorSourceItemsByVendor(vendorID);
            ProductManager _productManager = new ProductManager();
            
            
            foreach (VendorSourceItem v in vendorSourceItemList)
            {
                cbProductName.Items.Add(v.ProductID + " " + _productManager.GetProduct(v.ProductID).Name);
            }

            
        }

        


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void cbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProductName.Text == null)
            {
                return;
            }
            //else
            //{

            //    cbProductName.Items.Clear();
            //    List<VendorSourceItem> vendorSourceItemList = new List<VendorSourceItem>();
            //    VendorSourceItemManager _vendorSourceItemManager = new VendorSourceItemManager();
            //    int index = cbVendorName.SelectedItem.ToString().IndexOf(" ");
            //    Int32 vendorID = Int32.Parse(cbVendorName.SelectedItem.ToString().Substring(0, index));
            //    vendorSourceItemList = _vendorSourceItemManager.GetVendorSourceItemsByVendor(vendorID);
            //    ProductManager _productManager = new ProductManager();


            //    foreach (VendorSourceItem v in vendorSourceItemList)
            //    {
            //        cbProductName.Items.Add(v.ProductID + " " + _productManager.GetProduct(v.ProductID).Name);
            //    }
            //}
        }

        private void btnAddLineItem_Click(object sender, EventArgs e)
        {
            ReceivingManager _receivingManager = new ReceivingManager();
            VendorOrder vendorOrder;
            Product product;
            Int32 qtyReceived;

            Int32 vendorID = Int32.Parse(txtVendorID.Text);
            vendorOrder = new VendorOrder(Int32.Parse(txtVendorOrderID.Text), vendorID);
            
            product = new Product(vendorID);
            qtyReceived = Int32.Parse(upQuantityReceived.Value.ToString());
            _receivingManager.AddNewLineItemToVendorOrder(vendorOrder, product, qtyReceived);
            MessageBox.Show("Product added to Order");
            frmReceiving _frmReceiving = new frmReceiving(vendorOrder);
            _frmReceiving.Show();
            _frmReceiving.BringToFront();
            this.Close();

        }

       
    }
}
