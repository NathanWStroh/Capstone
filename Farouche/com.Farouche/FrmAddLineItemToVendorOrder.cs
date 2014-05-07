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
        private readonly AccessToken _myAccessToken;
        public FrmAddLineItemToVendorOrder(VendorOrder vendorOrder, AccessToken acctkn)
        {
            InitializeComponent();
            _myAccessToken = acctkn;
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
            VendorOrderManager _vendorOrderManager = new VendorOrderManager();
            VendorOrder vendorOrder;
            Product product;
            Int32 qtyReceived;
            Int32 qtyDamaged;

            Int32 vendorID = Int32.Parse(txtVendorID.Text);
            vendorOrder = new VendorOrder(Int32.Parse(txtVendorOrderID.Text), vendorID);
            int index = cbProductName.SelectedItem.ToString().IndexOf(" ");
            var productID = Int32.Parse(cbProductName.SelectedItem.ToString().Substring(0, index));
            product = new Product(productID);
            qtyReceived = Int32.Parse(upQuantityReceived.Value.ToString());
            qtyDamaged = Int32.Parse(upQtyDamaged.Value.ToString());
            string note = txtNotes.Text;
            _receivingManager.AddNewLineItemToVendorOrder(vendorOrder, product, qtyReceived, note, qtyDamaged);
            MessageBox.Show("Line Item Added");
            
            this.Close();

        }

       
    }
}
