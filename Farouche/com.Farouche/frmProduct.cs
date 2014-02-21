﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commmons;

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
        }//End of FrmProduct(.)

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            Text += "                         " + _myAccessToken.FirstName + " " + _myAccessToken.LastName + " logged in as a " + _myAccessToken.Title;

            //Populates the active combo box. 
            this.populateActiveCombo();

            //Instantiates a ProductManager.
            _myProductManager = new ProductManager();

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

        //Event handler causing the products list view to be populated.
        private void btnViewProducts_Click_1(object sender, EventArgs e)
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
        }//End of btnViewProducts_Click(..)

        private void btnActivateProduct_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvProducts.Items[0].Index;
            Boolean success = _myProductManager.ReactivateProduct(_myProductManager.Products[currentIndex]);
            if (success == true)
            {
                MessageBox.Show("The product was activated");
            }
            populateListView(this.lvProducts, _myProductManager.GetProductsByActive(false));
        }//End of btnActivateProduct_Click(..)

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvProducts.Items[0].Index;
            Boolean success = _myProductManager.DeactivateProduct(_myProductManager.Products[currentIndex]);
            if (success == true)
            {
                MessageBox.Show("The product was deactivated");
            }

            populateListView(this.lvProducts, _myProductManager.GetProductsByActive(true));
        }//End of btnDeativateProduct_Click(..)

        private void lvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentIndex = this.lvProducts.Items[0].Index;
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
        }//End of lvProducts_SelectedIndexChanged(..)

        //Sets the update, activate, deactive buttons enabled property to false.
        private void cbProductStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            setDefaults();
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
            int currentIndex = this.lvProducts.Items[0].Index;
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
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            FrmVendor form = new FrmVendor(_myAccessToken);
            form.Show();
            Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            Close();
        }
    }
}
