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
*                                                            
* 04/19/2014   Kaleb Wendel                                 Adjusted class to implement a singleton pattern so only one form can be instantiated.
* 5-2-14        NWS         n/a             n/a             ***** 
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
        private VendorSourceItemManager _myVendorItem = new VendorSourceItemManager();
        private readonly List<Product> _productList;
        private ProductManager _myProductManager = new ProductManager();
        private VendorOrderManager _myVendorOrderManager = new VendorOrderManager();
        private Product _currentProduct = new Product();
        
        public static frmVendorCreateOrder Instance;

        public frmVendorCreateOrder(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _vendorList = _myVendorManager.GetVendors();
            _productList = _myProductManager.GetProducts();
            var RoleAccess = new RoleAccess(acctoken, this);

            tbOrderDate.Text = DateTime.Now.ToString();
            populateListView();

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

            Instance = this;
        }

        private void populateListView()
        {
            lvOrderItems.Clear();

            lvOrderItems.Columns.Add("ID");
            lvOrderItems.Columns.Add("Product");
            lvOrderItems.Columns.Add("Price");
            lvOrderItems.Columns.Add("Quantity");
            lvOrderItems.Columns.Add("Total");

            lvOrderItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        
        private void btAddLineItem_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Product();
                int index = comboProduct.SelectedItem.ToString().IndexOf(" ");
                string id = comboProduct.SelectedItem.ToString().Substring(0, index);
                
                product = _myProductManager.GetProduct(int.Parse(id));
                
                int qty = int.Parse(comboQuanity.SelectedItem.ToString());
                decimal totalAmount = Math.Round(qty * product.unitPrice,2);

                ListViewItem lineItem = new ListViewItem();
                
                lineItem.Text = product.Id.ToString();
                lineItem.SubItems.Add(product.Name);
                lineItem.SubItems.Add(Math.Round(product.unitPrice,2).ToString());
                lineItem.SubItems.Add(qty.ToString());
                lineItem.SubItems.Add(totalAmount.ToString());
                
                lvOrderItems.Items.Add(lineItem);

                lvOrderItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                
                comboProduct.Items.RemoveAt(comboProduct.SelectedIndex);
                
                comboVendor.Enabled = false;

                calculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A Generic error as occured. You should fix this message " + ex.ToString());
            }

        }

        private void btRemove_Click(object sender, EventArgs e)
        {    
            int index = this.lvOrderItems.SelectedIndices[0];
            String productID = this.lvOrderItems.Items[0].SubItems[0].ToString();
            productID = productID.Replace("ListViewSubItem: {","");
            productID = productID.Replace("}","");
            int prodId = Int32.Parse(productID);
            Product product = new Product();

            try
            {   
                lvOrderItems.Items.RemoveAt(index);
            }
            catch (Exception ex)
            {

                MessageBox.Show("No item selected from List View.");
                if (_myAccessToken.Role.Id == 1400)
                {
                    MessageBox.Show(ex.ToString());
                }
                if(lvOrderItems.Items.Count <= 0)
                {
                    comboVendor.Enabled = true;
                }

            }

            try
            {
                product = _myProductManager.GetProduct(prodId);
                comboProduct.Items.Add(product.Id + " " + product.Name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to add remove product into Product Drop down");
            }
            calculateTotal();



            btRemove.Enabled = false;
        }

        private void btSaveOrder_Click(object sender, EventArgs e)
        {
            try
            {
                List<VendorOrderLineItem> lineItemList = new List<VendorOrderLineItem>();
                int index = comboVendor.SelectedItem.ToString().IndexOf(" ");
                int id = Convert.ToInt32(comboVendor.SelectedItem.ToString().Substring(0, index));
                _myVendorManager = new VendorManager();

                var vendorName = _myVendorManager.GetVendor(id).Name;

                //VendorOrder myVendorOrder = new VendorOrder(int.Parse(id));
                VendorOrder myVendorOrder = new VendorOrder(id);
                myVendorOrder.NumberOfShipments = Convert.ToInt32(comboShipments.SelectedItem.ToString());
                myVendorOrder.DateOrdered = Convert.ToDateTime(tbOrderDate.Text);
                myVendorOrder.Name = vendorName;

                for (int i = 0; i < lvOrderItems.Items.Count;i++)
                {
                    
                    Int32 productId = Int32.Parse(lvOrderItems.Items[i].SubItems[0].Text);
                    VendorOrderLineItem item = new VendorOrderLineItem(id, productId);
                    item.Name = lvOrderItems.Items[i].SubItems[1].Text; 
                    item.QtyOrdered = Int32.Parse(lvOrderItems.Items[i].SubItems[3].Text);
                    lineItemList.Add(item);
                    
                }
                myVendorOrder.LineItems = lineItemList;
                
                Boolean success = _myVendorOrderManager.AddVendorOrder(myVendorOrder);
                if (success == true)
                {
                    MessageBox.Show("Order Added.");
                    populateListView();
                    comboProduct.Items.Clear();
                }
                else
                {
                    MessageBox.Show("A field is not filled in. Please verify all fields are correct.");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("A Generic error as occured. You should fix this message " + ex.ToString());
            }
        }

        private void frmVendorCreateOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

        private void calculateTotal()
        {
            decimal total=0;

            for(int i = 0; i < lvOrderItems.Items.Count; i++)
            {
              //insert code for adding lineItem values;
                String thisPrice = lvOrderItems.Items[i].SubItems[4].ToString();
                thisPrice = thisPrice.Replace("ListViewSubItem: ", "");
                int index = thisPrice.IndexOf("{");
                int index2 = thisPrice.IndexOf("}");
                thisPrice = thisPrice.Substring(index+1, index2-1);
                
                decimal unitPrice = Decimal.Parse(thisPrice);
                total= Math.Round(total + unitPrice,2);
            }
            lblPrice.Text = "$" + total;
        }

        private void comboVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboVendor.SelectedItem.ToString().IndexOf(" ");
            populateProduct(index);
        }

        private void lvOrderItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            btRemove.Enabled = true;
        }

        private void populateProduct(int vendorId)
        {
            List<VendorSourceItem> vendorProducts = new List<VendorSourceItem>();
            vendorProducts = _myVendorItem.GetVendorSourceItemsByVendor(vendorId);

            comboProduct.Items.Clear();

            foreach (VendorSourceItem item in vendorProducts)
            {
                Product product = new Product();
                product = _myProductManager.GetProduct(item.ProductID);

                comboProduct.Items.Add(product.Id + " " + product.Name);
            }

        }
        
    }
    
}

