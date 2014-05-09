using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
//Author: Kaleb
//Date Created: 1/31/2014
//Last Modified: 04/01/2014
//Last Modified By: Kaleb Wendel

/*
*                               Changelog
* Date         By          Ticket          Version          Description
* 02/13/2014   Kaleb                         0.0.2a         Added enumerated type for active.
*                                                           Added method to populate a list view.
*                                                           Added event handlers to activate, deactive, add, edit a
*                                                           product click events.
*                                                           Added event handlers for index changed events.
*
* 02/20/14     Nathan S     n/a             "updated"       Added accessToken value to ProductView Windows.
* 
* 02/26/2014   Kaleb W                       0.0.3a         Adjusted class to populate the list view upon selecting an active status.
*                                                           Adjusted class to determine whether the item is active or not which determines what controls are enabled.
* 
* 04/01/2014   Kaleb                                        Adjusted populateListView to include OnOrder, Threshold, ReorderAmount, ShippingWeight, and ShippingDimension values. Also adjusted this method to account for nullable values. 
* 
* 04/10/2014   Kaleb                                        Adjusted populateListView to populate the list view in a different order to match the update/add form.
* 
* 04/18/2014   Kaleb                                        Adjusted class to implement a singleton pattern so only one form can be instantiated.
*/

//Enumeration for active drop down.
public enum Active { No = 0, Yes = 1, };

namespace com.Farouche.Presentation
{
    public partial class FrmProduct : Form
    {
        private readonly AccessToken _myAccessToken;
        private ProductManager _myProductManager;
        public static FrmProduct Instance;
        public RoleAccess RoleAccess;
        //Constructor with AccessToken as the only parameter.
        public FrmProduct(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            //Instantiates a ProductManager.
            _myProductManager = new ProductManager();
            Instance = this;
            RoleAccess = new RoleAccess(_myAccessToken, this);
        }//End of FrmProduct(.)

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            //Text += "                         " + _myAccessToken.FirstName + " " + _myAccessToken.LastName + " logged in as a " + _myAccessToken.Title;

            //Populates the active combo box. 
            this.populateActiveCombo();

            //Populates the list view upon the page load event.
            populateListView(this.lvProducts, _myProductManager.GetProductsByActive(true));
        }//frmAddProduct_Load(..)

        //Populates the Active combo box.
        //Postcondition: The combo box will hold the values (Yes, No, Both).
        private void populateActiveCombo()
        {
            Active active;
            for (int i = 1; i >= 0; i--)
            {
                active = (Active)i;
                this.cbProductStatusSearch.Items.Add(active);
            }
            this.cbProductStatusSearch.Items.Add("Both");
            this.cbProductStatusSearch.SelectedIndex = 0;
        }//End of populateActiveCombo()

        //Populates a list view.
        private void populateListView(ListView lv, List<Product> productList)
        {
            _myProductManager.Products = productList;
            lv.Clear();
            
            foreach (var product in productList)
            {
                var item = new ListViewItem();
                item.Text = product.Id.ToString();
                item.SubItems.Add(product.Name);
                item.SubItems.Add(product.description);
                item.SubItems.Add(String.Format("{0:C}",product.unitPrice));
                item.SubItems.Add(product.available.ToString());
                item.SubItems.Add(product.reserved.ToString());
                item.SubItems.Add(product._reorderThreshold == null ? "Null" : product._reorderThreshold.ToString());
                item.SubItems.Add(product._reorderAmount == null ? "Null" : product._reorderAmount.ToString());
                item.SubItems.Add(product._onOrder.ToString());
                item.SubItems.Add(product.location == null ? "Null" : product.location.ToString());
                item.SubItems.Add(product._shippingWeight == null ? "Null" : product._shippingWeight.ToString());
                item.SubItems.Add(product._shippingDemensions == null ? "Null" : product._shippingDemensions.ToString());
                item.SubItems.Add(product.Active.ToString());
                lv.Items.Add(item);
            }
            lv.Columns.Add("Product ID");
            lv.Columns.Add("Short Description");
            lv.Columns.Add("Description");
            lv.Columns.Add("Unit Price");
            lv.Columns.Add("Available");
            lv.Columns.Add("On Hand");
            lv.Columns.Add("Reorder Threshold");
            lv.Columns.Add("Reorder Amount");
            lv.Columns.Add("On Order");
            lv.Columns.Add("Location ID");
            lv.Columns.Add("Shipping Weight");
            lv.Columns.Add("Shipping Dimensions");
            lv.Columns.Add("Active");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of populateListView(..)

        private void btnActivateProduct_Click(object sender, EventArgs e)
        {
            //int currentIndex = this.lvProducts.Items[0].Index;
            int currentIndex = this.lvProducts.SelectedIndices[0];
            Boolean success = _myProductManager.ReactivateProduct(_myProductManager.Products[currentIndex]);
            if (success == true)
            {
                MessageBox.Show("The product was activated");
            }
            findActiveSelection();
        }//End of btnActivateProduct_Click(..)

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            //int currentIndex = this.lvProducts.Items[0].Index;
            int currentIndex = this.lvProducts.SelectedIndices[0];
            Boolean success = _myProductManager.DeactivateProduct(_myProductManager.Products[currentIndex]);
            if (success == true)
            {
                MessageBox.Show("The product was deactivated");
            }
            findActiveSelection();
        }//End of btnDeativateProduct_Click(..)

        //Sets the update, activate, deactive buttons enabled property to false.
        private void cbProductStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            findActiveSelection();
        }//End of cbProductStatusSearch_SelectedIndexChanged(..)

        private void setDefaults()
        {
            btnUpdateProduct.Enabled = false;
            btnDeactivateProduct.Enabled = false;
            btnActivateProduct.Enabled = false;
            btnUpdateOnOrder.Enabled = false;
            btnUpdateReorderAmount.Enabled = false;
            btnUpdateReorderThreshold.Enabled = false;
        }//End of setDefaults()

        //Need to make sure that this links up with Nathan's code correctly.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductView frm = new ProductView(_myAccessToken);
            frm.ShowDialog();
            findActiveSelection();
        }//End of btnAdd_Click(..)

        //Need to make sure that this links up with Nathan's code correctly.
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvProducts.SelectedIndices[0];
            Product thisProduct = _myProductManager.Products[currentIndex];
            ProductView frm = new ProductView(_myAccessToken, thisProduct);
            frm.ShowDialog();
            findActiveSelection();
        }//End of btnUpdateProduct_Click(..)

        private void btnVendorSource_Click(object sender, EventArgs e)
        {
            FrmVendorSource form = new FrmVendorSource(_myAccessToken);
            form.Show();
            Close();
        }//End of btnVendorSource_Click(..)

        private void btnVendor_Click(object sender, EventArgs e)
        {
            FrmVendor form = new FrmVendor(_myAccessToken);
            form.Show();
            Close();
        }//End of btnVendor_Click(..)

        private void lvProducts_Click(object sender, EventArgs e)
        {
            //int currentIndex = this.lvProducts.SelectedItems[0].Index;
            int currentIndex = this.lvProducts.SelectedIndices[0];
            Product thisProduct = _myProductManager.Products[currentIndex];
            if (thisProduct.Active == true)
            {
                btnActivateProduct.Enabled = false;
                btnDeactivateProduct.Enabled = true;
            }
            else
            {
                btnActivateProduct.Enabled = true;
                btnDeactivateProduct.Enabled = false;
            }
            btnUpdateReorderThreshold.Enabled = true;
            btnUpdateReorderAmount.Enabled = true;
            btnUpdateOnOrder.Enabled = true;
            btnUpdateProduct.Enabled = true;
        }//End of lvProducts_Click(..)

        private void findActiveSelection()
        {
            Boolean active;
            switch (this.cbProductStatusSearch.SelectedIndex)
            {
                case 0:
                    active = true; //True
                    populateListView(this.lvProducts, _myProductManager.GetProductsByActive(active));
                    break;
                case 1:
                    active = false; //False
                    populateListView(this.lvProducts, _myProductManager.GetProductsByActive(active));
                    break;
                case 2:
                    populateListView(this.lvProducts, _myProductManager.GetProducts());
                    break;
            }
            setDefaults();
        }//End of findActiveSelection()

        private void cbProductStatusSearch_Click(object sender, EventArgs e)
        {
            setDefaults();
        }//End of cbProductStatusSearch_Click(..)

        private void btnShipping_Click(object sender, EventArgs e)
        {
            var form = new FrmShipping(_myAccessToken);
            form.Show();
            this.Close();
        }

        private void btnUpdateReorderAmount_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvProducts.SelectedIndices[0];
            Product thisProduct = _myProductManager.Products[currentIndex];
            FrmUpdateReorderAmount frm = new FrmUpdateReorderAmount(thisProduct._reorderAmount, thisProduct.Id);
            frm.ShowDialog();
            findActiveSelection();
        }

        private void btnUpdateReorderThreshold_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvProducts.SelectedIndices[0];
            Product thisProduct = _myProductManager.Products[currentIndex];
            FrmUpdateReorderThreshold frm = new FrmUpdateReorderThreshold(thisProduct._reorderThreshold, thisProduct.Id);
            frm.ShowDialog();
            findActiveSelection();
        }

        private void btnUpdateOnOrder_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvProducts.SelectedIndices[0];
            Product thisProduct = _myProductManager.Products[currentIndex];
            FrmUpdateReorderOnOrder frm = new FrmUpdateReorderOnOrder(thisProduct._onOrder, thisProduct.Id);
            frm.ShowDialog();
            findActiveSelection();
        }

        private void FrmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }//End of FrmProduct_CormClosed(..)
    }
}
