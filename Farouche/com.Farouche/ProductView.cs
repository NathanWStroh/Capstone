using System;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

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
*/

namespace com.Farouche.Presentation
{
    public partial class ProductView : Form
    {
        private VendorManager _vendorManager = new VendorManager();
        private ProductManager _productManager = new ProductManager();
        private Product _currentProduct;

        private readonly AccessToken _myAccessToken;

        public ProductView(AccessToken accToken)
        {
            InitializeComponent();
            _myAccessToken = accToken;
            this.Text = "Add Product";
            btMorph.Text = "Add Product";
            PopulateLocationCombo();
            PopulateActiveCombo();
            tbProductID.Enabled = false;
            tbProductID.Text = "The id will automatically be assigned.";
            this.lblVendors.Visible = false;
            this.lvVendor.Visible = false;
            this.btAddVendor.Visible = false;
            tbProductID.Focus();
        }//End of ProductView(.)

        public ProductView(AccessToken accToken, Product ProductInfo)
        {
            InitializeComponent();
            _myAccessToken = accToken;
            _currentProduct = ProductInfo;

            //Assigning the current product values to the appropriate controls.
            this.Text = "Update Product";
            btMorph.Text = "Update Product";
            tbProductID.Text = ProductInfo.Id.ToString();
            tbDescription.Text = ProductInfo.description;
            tbItemName.Text = ProductInfo.Name;
            tbUnitPrice.Text = ProductInfo.unitPrice.ToString();
            tbQuantity.Text = ProductInfo.available.ToString();
            txtOnHand.Text = ProductInfo.reserved.ToString();
            txtThreshold.Text = ProductInfo._reorderThreshold.ToString();
            txtReorder.Text = ProductInfo._reorderAmount.ToString();
            txtOnOrder.Text = ProductInfo._onOrder.ToString();
            txtDimensions.Text = ProductInfo._shippingDemensions;
            txtWeight.Text = ProductInfo._shippingWeight.ToString();
            PopulateActiveCombo();
            PopulateLocationCombo();
            this.btnClear.Enabled = false;
            tbItemName.Focus();
        }//End of ProductView(..)

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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }//End of btClose_Click

        private void btAddVendor_Click(object sender, EventArgs e)
        {
            AddVendorWindow newWindow = new AddVendorWindow(tbProductID.Text);
        }//End of btAddVendor_Click(..)

        private void btMorph_Click(object sender, EventArgs e)
        {
            if (btMorph.Text == "Add Product")
            {
                //Add Error handling!
                Product newProduct = new Product()
                {
                    description = tbDescription.Text,
                    Name = tbItemName.Text,
                    unitPrice = Convert.ToDecimal(tbUnitPrice.Text),
                    available = Convert.ToInt32(tbQuantity.Text),
                    reserved = Convert.ToInt32(txtOnHand.Text),
                    _reorderThreshold = txtThreshold.Text == null || txtThreshold.Text == "" ? (int?)null : Convert.ToInt32(txtThreshold.Text),
                    _reorderAmount = txtReorder.Text == null || txtReorder.Text == "" ? (int?)null : Convert.ToInt32(txtReorder.Text),
                    _onOrder = Convert.ToInt32(txtOnOrder.Text),
                    location = comboWHSL.SelectedIndex == 0 ? null : comboWHSL.SelectedItem.ToString(),
                    _shippingWeight = txtWeight.Text == null || txtWeight.Text == "" ? (double?)null : Convert.ToDouble(txtWeight.Text),
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
            else if (btMorph.Text == "Update Product")
            {
                //Add error handling!
                Product newProduct = new Product()
                {
                    description = tbDescription.Text,
                    Name = tbItemName.Text,
                    unitPrice = Convert.ToDecimal(tbUnitPrice.Text),
                    available = Convert.ToInt32(tbQuantity.Text),
                    reserved = Convert.ToInt32(txtOnHand.Text),
                    _reorderThreshold = txtThreshold.Text == null || txtThreshold.Text == "" ? (int?)null : Convert.ToInt32(txtThreshold.Text),
                    _reorderAmount = txtReorder.Text == null || txtReorder.Text == "" ? (int?)null : Convert.ToInt32(txtReorder.Text),
                    _onOrder = Convert.ToInt32(txtOnOrder.Text),
                    location = comboWHSL.SelectedIndex == 0 ? null : comboWHSL.SelectedItem.ToString(),
                    _shippingWeight = txtWeight.Text == null || txtWeight.Text == "" ? (double?)null : Convert.ToDouble(txtWeight.Text),
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
                        MessageBox.Show("The product was not updated.\nPlease try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has Occured. Error Message: " + ex.Message);
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
            tbUnitPrice.Text = "";
            tbQuantity.Text = "";
            txtOnHand.Text = "";
            txtThreshold.Text = "";
            txtReorder.Text = "";
            txtOnOrder.Text = "";
            txtDimensions.Text = "";
            txtWeight.Text = "";
            comboWHSL.SelectedIndex = 0;
            cbActive.SelectedIndex = 0;
        }

        //Event to clear controls.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetDefaults();
        }//End of ResetDefaults()
    }//public partial class ProductView : Form
}
