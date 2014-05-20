using System;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
using System.Collections.Generic;

//Author: Nathan S
//Date Created: null
//Last Modified: 04/01/2014
//Last Modified By: Kaleb Wendel
/*
*                               Changelog
* Date         By          Ticket          Version          Description
*2-20-14       Nathan S     n/a            "updated"        Working on fixing bugs.
*                                                           1. Closing Window doesn't close program
*                                                           2. adding functionallity to the buttons
*                                                           3. Also worked on changing cleaning up code.
*                                                           
* 04/01/2014   Kaleb                                        Adjusted class to account for new data members that were added to product.
*
* 04/02/2014   Kaleb                                        Added PopulateActiveCombo, PopulateLocationCombo, ResetDefaults methods.
*
* 04/02/2014   Kaleb                                        Corrected code to correctly add a product and update a product.
*
* 04/10/2014   Kaleb                                        Adjusted the form to have numericUpDown controls rather than text boxes for certain fields.
* 
* 04/10/2014   Kaleb                                        Added data validation to the form.
*
* 04/19/2014   Kaleb                                        Adjusted class to implement a singleton pattern so only one form can be instantiated.
*
* 4/30/2014    Kaleb                                        Added functionality to update the vendor source item and remove a vendor source item.
*/

namespace com.Farouche.Presentation
{
    public partial class ProductView : Form
    {
        List<VendorSourceItem> vendorSourceList;
        private VendorManager _vendorManager;
        private ProductManager _productManager;
        private VendorSourceItemManager _vendorSourceManager;
        private Product _currentProduct;
        private readonly AccessToken _myAccessToken;
        public static ProductView Instance;

        public ProductView(AccessToken accToken)
        {
            InitializeComponent();
            var RoleAccess = new RoleAccess(accToken, this);
            _myAccessToken = accToken;
            _productManager = new ProductManager();
            _vendorManager = new VendorManager();
            _vendorSourceManager = new VendorSourceItemManager();
            this.Text = "Add Product";
            btMorph.Text = "Add Product";
            PopulateLocationCombo();
            PopulateActiveCombo();
            tbProductID.Enabled = false;
            tbProductID.Text = "The ID will automatically be created.";
            this.lblVendors.Visible = false;
            this.lvVendors.Visible = false;
            this.btAddVendor.Visible = false;
            lblPriceDisplay.Text = String.Format("{0:C}", 0);
            lblWeightDisplay.Text = "0.0 lbs";
            tbProductID.Focus();
            Instance = this;
        }//End of ProductView(.)

        public ProductView(AccessToken accToken, Product ProductInfo)
        {
            InitializeComponent();
            _myAccessToken = accToken;
            _productManager = new ProductManager();
            _vendorManager = new VendorManager();
            _vendorSourceManager = new VendorSourceItemManager();
            _currentProduct = ProductInfo;
            //Assigning the current product values to the appropriate controls.
            this.Text = "Update Product";
            btMorph.Text = "Update Product";
            tbProductID.Text = ProductInfo.Id.ToString();
            tbDescription.Text = ProductInfo.description;
            tbItemName.Text = ProductInfo.Name;
            nudUnitPrice.Value = ProductInfo.unitPrice;
            nudAvailableQty.Value = ProductInfo.available;
            nudOnHandQty.Value = ProductInfo.reserved;
            nudReorderThreshold.Value = (decimal)ProductInfo._reorderThreshold;
            nudReorderAmount.Value = (decimal)ProductInfo._reorderAmount;
            nudOnOrderAmount.Value = ProductInfo._onOrder;
            txtDimensions.Text = ProductInfo._shippingDemensions;
            nudWeight.Value = (decimal)ProductInfo._shippingWeight;
            PopulateActiveCombo();
            PopulateLocationCombo();
            PopulateListView(lvVendors, ProductInfo.Id);
            this.btnClear.Enabled = false;
            lblPriceDisplay.Text = String.Format("{0:C}", ProductInfo.unitPrice);
            tbItemName.Focus();
            Instance = this;
        }//End of ProductView(..)

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }//btClose_Click

        public ProductView(String itemName)
        {
            String somePhrase = "";
            //overloaded constructor for creating an update or deactivation form depending on the need or button pressed.
            if (somePhrase == "Deactivate")
            {
                //all rows need to be readonly and the btSubmit.Text should be changed to Deactivate. 
                this.Text = "Deactivation " + this.Text;
                btMorph.Text = "Deactivate";
            }
            else
            {
                //pulls information and places it in the correct spot. They can be edited.
                //btMorph.Text should be changed to "Update."
                btMorph.Text = "Update";
                this.Text = "Update " + this.Text;
            }
        }//ProductView(.)

        private void lvVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btAddVendor.Enabled = false;
        }//ProductView

        private void btMorph_Click(object sender, EventArgs e)
        {
            bool validProduct = true;
            string errorMessage = "Please correct the following errors:\n";
            
            if (btMorph.Text == "Add Product")
            {
                if (Validation.IsBlank(tbItemName.Text) || Validation.IsNullOrEmpty(tbItemName.Text))
                {
                    validProduct = false;
                    errorMessage += "\nEnter a short description.";
                }
                if (tbItemName.Text.Length > 50)
                {
                    validProduct = false;
                    errorMessage += "\nThe name must be 50 characters or less.";
                }
                if (Validation.IsBlank(tbDescription.Text) || Validation.IsNullOrEmpty(tbDescription.Text))
                {
                    validProduct = false;
                    errorMessage += "\nEnter a description.";
                }
                if(tbDescription.Text.Length > 250)
                {
                    validProduct = false;
                    errorMessage += "\nThe description must be 250 characters or less.";
                }
                if(txtDimensions.Text.Length > 50)
                {
                    validProduct = false;
                    errorMessage += "\nThe shipping dimensions must be 50 characters or less.";
                }
                if (validProduct)
                {
                    Product newProduct = new Product()
                    {
                        description = tbDescription.Text,
                        Name = tbItemName.Text,
                        unitPrice = nudUnitPrice.Value,
                        available = (int)nudAvailableQty.Value,
                        reserved = (int)nudOnHandQty.Value,
                        _reorderThreshold = (int?)nudReorderThreshold.Value,
                        _reorderAmount = (int?)nudReorderAmount.Value,
                        _onOrder = (int)nudOnOrderAmount.Value,
                        location = comboWHSL.SelectedIndex == 0 ? null : comboWHSL.SelectedItem.ToString(),
                        _shippingWeight = (double)nudWeight.Value,
                        _shippingDemensions = txtDimensions.Text == null || txtDimensions.Text == "" ? null : txtDimensions.Text,
                        Active = Convert.ToBoolean(cbActive.SelectedItem)
                    };
                    try
                    {
                        if (_productManager.AddProduct(newProduct))
                        {
                            this.DialogResult = DialogResult.OK;
                            MessageBox.Show("The product was added to inventory.");
                        }
                        else
                        {
                            MessageBox.Show("The product was not added to inventory.\nPlease try again.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error has Occured. Error Message: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            else if (btMorph.Text == "Update Product")
            {
                if (Validation.IsBlank(tbItemName.Text) || Validation.IsNullOrEmpty(tbItemName.Text))
                {
                    validProduct = false;
                    errorMessage += "\nEnter a short description.";
                }
                if (tbItemName.Text.Length > 50)
                {
                    validProduct = false;
                    errorMessage += "\nThe name must be 50 characters or less.";
                }
                if (Validation.IsBlank(tbDescription.Text) || Validation.IsNullOrEmpty(tbDescription.Text))
                {
                    validProduct = false;
                    errorMessage += "\nEnter a description.";
                }
                if (tbDescription.Text.Length > 250)
                {
                    validProduct = false;
                    errorMessage += "\nThe description must be 250 characters or less.";
                }
                if (txtDimensions.Text.Length > 50)
                {
                    validProduct = false;
                    errorMessage += "\nThe shipping dimensions must be 50 characters or less.";
                }
                if (validProduct)
                {
                    Product newProduct = new Product()
                    {
                        description = tbDescription.Text,
                        Name = tbItemName.Text,
                        unitPrice = nudUnitPrice.Value,
                        available = (int)nudAvailableQty.Value,
                        reserved = (int)nudOnHandQty.Value,
                        _reorderThreshold = (int?)nudReorderThreshold.Value,
                        _reorderAmount = (int?)nudReorderAmount.Value,
                        _onOrder = (int)nudOnOrderAmount.Value,
                        location = comboWHSL.SelectedIndex == 0 ? null : comboWHSL.SelectedItem.ToString(),
                        _shippingWeight = (double)nudWeight.Value,
                        _shippingDemensions = txtDimensions.Text == null || txtDimensions.Text == "" ? null : txtDimensions.Text,
                        Active = Convert.ToBoolean(cbActive.SelectedItem)
                    };
                    try
                    {
                        if (_productManager.UpdateProduct(newProduct, _currentProduct))
                        {
                            this.DialogResult = DialogResult.OK;
                            MessageBox.Show("The product was updated.");
                        }
                        else
                        {
                            MessageBox.Show("The product was not updated.\nAnother user may have already updated this product.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error has Occured. Error Message: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
        }//End of btMorph_Click(..)

        //Populates the active combo and sets the appropriate index based off of what function the user is performing.
        private void PopulateActiveCombo()
        {
            Active active;
            var index = 0;
            for (int i = 1; i >= 0; i--)
            {
                active = (Active)i;
                this.cbActive.Items.Add(active);
                if (_currentProduct != null)
                {
                    if (_currentProduct.Active.Equals(false))
                    {
                        index = 1;
                    }
                }
            }
            this.cbActive.SelectedIndex = index;
        }//End of populateActiveCombo()

        //Populates the locations drop down and sets the appropriate index based off of what function the user is performing.
        private void PopulateLocationCombo()
        {
            var index = 0;
            var locations = _productManager.GetLocations();
            comboWHSL.Items.Add("No Location");
            for (int i = 0; i < locations.Count; i++)
            {
                comboWHSL.Items.Add(locations[i]);
                if (_currentProduct != null && locations[i].Equals(_currentProduct.location))
                {
                    index = i + 1;
                }
            }
            this.comboWHSL.SelectedIndex = index;
        }//End of populateLocationCombo()

        //Clears controls.
        private void ResetDefaults()
        {
            tbDescription.Text = "";
            tbItemName.Text = "";
            nudUnitPrice.Value = 0;
            nudAvailableQty.Value = 0;
            nudOnHandQty.Value = 0;
            nudReorderThreshold.Value = 0;
            nudReorderAmount.Value = 0;
            nudOnOrderAmount.Value = 0;
            txtDimensions.Text = "";
            nudWeight.Value = 0;
            comboWHSL.SelectedIndex = 0;
            cbActive.SelectedIndex = 0;
        }

        //Event to clear controls.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetDefaults();
        }//End of ResetDefaults(..)

        private void nudUnitPrice_ValueChanged(object sender, EventArgs e)
        {
            lblPriceDisplay.Text = String.Format("{0:C}", nudUnitPrice.Value);
        }//End of nudUnitPrice_ValueChanged(..)

        private void nudWeight_ValueChanged(object sender, EventArgs e)
        {
            lblWeightDisplay.Text = nudWeight.Value.ToString() + " lbs";
        }//End of nudWeight_ValueChanged(..)
        
        //Populates a list view.
        private void PopulateListView(ListView lv, int productID)
        {
            vendorSourceList = _vendorSourceManager.GetVendorSourceItemsByProduct(productID);
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var vendorSource in vendorSourceList)
            {
                var item = new ListViewItem();
                item.Text = vendorSource.Name;
                item.SubItems.Add(String.Format("{0:C}", vendorSource.UnitCost));
                item.SubItems.Add(vendorSource.MinQtyToOrder.ToString());
                item.SubItems.Add(vendorSource.ItemsPerCase.ToString());
                lv.Items.Add(item);
            }
            lv.Columns.Add("Vendor Name");
            lv.Columns.Add("Unit Cost");
            lv.Columns.Add("Min Order Qty");
            lv.Columns.Add("Case Qty");
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }//End of populateListView(..)

        private void ProductView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }//End of ProductView_FormClosed(..)

        private void lvVendors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvVendors.SelectedItems.Count != 0)
            {
                btnRemoveVendor.Enabled = true;
                btnUpdateVendor.Enabled = true;
            }
            else
            {
                btnRemoveVendor.Enabled = false;
                btnUpdateVendor.Enabled = false;
            }
        }//End of lvVendors_SelectedIndexChanged(..)

        private void btnUpdateVendor_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvVendors.SelectedIndices[0];
            FrmAttachVendorSource frmVendorSource = new FrmAttachVendorSource(_currentProduct, vendorSourceList[currentIndex]);
            frmVendorSource.ShowDialog();
            PopulateListView(lvVendors, _currentProduct.Id);
            btnRemoveVendor.Enabled = false;
            btnUpdateVendor.Enabled = false;
        }//End of btnUpdateVendor_Click(..)

        private void btAddVendor_Click(object sender, EventArgs e)
        {
            FrmAttachVendorSource frmVendorSource = new FrmAttachVendorSource(_currentProduct, _myAccessToken);
            frmVendorSource.ShowDialog();
            PopulateListView(lvVendors, _currentProduct.Id);
            btnRemoveVendor.Enabled = false;
            btnUpdateVendor.Enabled = false;
        }//End of btAddVendor_Click(..)

        private void btnRemoveVendor_Click(object sender, EventArgs e)
        {
             int currentIndex = this.lvVendors.SelectedIndices[0];
             Boolean success = _vendorSourceManager.DeleteVendorSourceItem(vendorSourceList[currentIndex]);
             if (success == true)
             {
                 MessageBox.Show("The vendor was removed from this product.");
             }
             PopulateListView(lvVendors, _currentProduct.Id);
        }//End of btnRemoveVendor_Click(..)


    }//public partial class ProductView : Form
}
