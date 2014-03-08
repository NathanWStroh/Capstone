using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
//Author: Kaleb
//Date Created: 1/31/2014
//Last Modified: 1/31/2014
//Last Modified By: Steven Schuette

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
* 02/26/2014   Kaleb W                       0.0.3a         Adjusted class to populate the list view upon selecting an active
*                                                           status.
*                                                           Adjusted class to determine whether the item is active or not
*                                                           which determines what controls are enabled.
* 
*/ 

//Enumeration for active drop down.
public enum Active { No = 0, Yes = 1 };

namespace com.Farouche.Presentation
{
    public partial class FrmProduct : Form
    {
        private readonly AccessToken _myAccessToken;
        private ProductManager _myProductManager;

        //Constructor with AccessToken as the only parameter.
        public FrmProduct(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            //Instantiates a ProductManager.
            _myProductManager = new ProductManager();
        }//End of FrmProduct(.)

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            Text += "                         " + _myAccessToken.FirstName + " " + _myAccessToken.LastName + " logged in as a " + _myAccessToken.Title;

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
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var product in productList)
            {
                var item = new ListViewItem();
                item.Text = product.Id.ToString();
                item.SubItems.Add(product.Name);
                item.SubItems.Add(product.description);
                item.SubItems.Add(product.reserved.ToString());
                item.SubItems.Add(product.available.ToString());
                item.SubItems.Add(product.location.ToString());
                item.SubItems.Add(product.unitPrice.ToString());
                item.SubItems.Add(product.Active.ToString());
                lv.Items.Add(item);
            }
            lv.Columns.Add("Product ID");
            lv.Columns.Add("Short Description");
            lv.Columns.Add("Description");
            lv.Columns.Add("On Hand");
            lv.Columns.Add("Available");
            lv.Columns.Add("Location ID");
            lv.Columns.Add("Unit Price");
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
        }//End of setDefaults()
        
        //Need to make sure that this links up with Nathan's code correctly.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductView frm = new ProductView(_myAccessToken);
            frm.Show();
            this.Close();
        }//End of btnAdd_Click(..)

        //Need to make sure that this links up with Nathan's code correctly.
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            //int currentIndex = this.lvProducts.Items[0].Index;
            int currentIndex = this.lvProducts.SelectedIndices[0];
            Product thisProduct = _myProductManager.Products[currentIndex];
            ProductView frm = new ProductView(_myAccessToken, thisProduct);
            frm.Show();
            this.Close();   
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            Close();
        }//End of btnLogout_Click(..)

        private void lvProducts_Click(object sender, EventArgs e)
        {
            //int currentIndex = this.lvProducts.SelectedItems[0].Index;
            int currentIndex = this.lvProducts.SelectedIndices[0];
            Console.WriteLine(currentIndex);
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
    }
}
