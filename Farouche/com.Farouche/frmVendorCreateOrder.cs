//Author: NathanWStroh
//Date Created: 04/11/2014
//Last Modified: 04/13/2014
//Last Modified By: Nathan W Stroh

/*
*                               Changelog
* Date          By          Ticket          Version         Description
* 4-13-14       NWS         n/a             n/a             Did several quality of life changes to this form. 
*                                                            Including removing an item from product after it has been 
*                                                            added to the lvOrderItem. Need to add in a way to add it
*                                                            back into list if item is removed from lvOrderItem.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;


namespace com.Farouche.Presentation
{
    public partial class frmVendorCreateOrder : Form
    {
        private readonly AccessToken _myAccessToken;
        private readonly List<Vendor> _vendorList;
        private VendorManager _myVendorManager = new VendorManager();
        private readonly List<Product> _productList;
        private ProductManager _myProductManager = new ProductManager();
        private VendorOrderManager _myVendorOrderManager = new VendorOrderManager();

        public frmVendorCreateOrder(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _vendorList = _myVendorManager.GetVendors();
            _productList = _myProductManager.GetProducts();
            

            tbOrderDate.Text = DateTime.Now.Date.ToString("MM.dd.yyyy");

            lvOrderItems.Columns.Add("ID");
            lvOrderItems.Columns.Add("Product");
            lvOrderItems.Columns.Add("Quantity");
            

            for (int i = 0; i <= 100; i++)
            {
                comboQuanity.Items.Add(i);
            }

            for (int i = 0; i <= 10; i++)
            {
                comboShipments.Items.Add(i);
            }

            foreach (var vendor in _vendorList)
            {
                comboVendor.Items.Add(vendor.Id + " " + vendor.Name);
            }

            foreach (var product in _productList)
            {
                comboProduct.Items.Add(product.Id + " " + product.Name);
            }
        }

        private void btAddNewProduct_Click(object sender, EventArgs e)
        {
            ProductView frm = new ProductView(_myAccessToken);
            frm.ShowDialog();
        }

        private void btAddLineItem_Click(object sender, EventArgs e)
        {
            //needs additional methods to test if two items are the same and increment/decrement.
            try
            {
                Product product = new Product();
                int index = comboProduct.SelectedItem.ToString().IndexOf(" ");
                string id = comboProduct.SelectedItem.ToString().Substring(0, index);
                product = _myProductManager.GetProduct(int.Parse(id));
                int qty = int.Parse(comboQuanity.SelectedItem.ToString());
                ListViewItem lineItem = new ListViewItem();
                lineItem.Text = product.Id.ToString();
                lineItem.SubItems.Add(product.Name);
                lineItem.SubItems.Add(qty.ToString());
                lvOrderItems.Items.Add(lineItem);

                comboProduct.Items.RemoveAt(comboProduct.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("A Generic error as occured. You should fix this message " + ex.ToString());
            }

        }
        private void btRemove_Click(object sender, EventArgs e)
        {

            try
            {
                int currentIndex = this.lvOrderItems.SelectedIndices[0];
                //comboProduct.Items.Add(this.lvOrderItems.Items.ToString());
                lvOrderItems.Items.RemoveAt(currentIndex);

            }
            catch (Exception ex)
            {

                MessageBox.Show("No item selected from List View.");
                if (_myAccessToken.RoleID == 1400)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void btSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                List<VendorOrderLineItem> lineItemList = new List<VendorOrderLineItem>();
                int index = comboVendor.SelectedItem.ToString().IndexOf(" ");
                string id = comboVendor.SelectedItem.ToString().Substring(0, index);
                string vendorName = comboVendor.SelectedItem.ToString().Substring(1, index);

                //VendorOrder myVendorOrder = new VendorOrder(int.Parse(id));
                VendorOrder myVendorOrder = new VendorOrder(int.Parse(id));
                myVendorOrder.NumberOfShipments = int.Parse(comboShipments.SelectedItem.ToString());
                myVendorOrder.DateOrdered = DateTime.Parse(tbOrderDate.Text);
                myVendorOrder.Name = vendorName;

                for (int i = 0; i < lvOrderItems.Items.Count;i++)
                {
                    int productId = int.Parse(lvOrderItems.Items[i].SubItems[0].Text);
                    VendorOrderLineItem item = new VendorOrderLineItem(int.Parse(id), productId);
                    item.Name = lvOrderItems.Items[i].SubItems[1].Text; 
                    item.QtyOrdered = int.Parse(lvOrderItems.Items[i].SubItems[2].Text);
                    lineItemList.Add(item);
                    
                }
                myVendorOrder.LineItems = lineItemList;
                
                _myVendorOrderManager.AddVendorOrder(myVendorOrder);

                MessageBox.Show("Order Added.");

            }
            catch(Exception ex)
            {
                MessageBox.Show("A Generic error as occured. You should fix this message " + ex.ToString());
            }
        }
    }
}
