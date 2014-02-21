using System;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commmons;

//Author: Nathan S
//Date Created: null
//Last Modified: 2/20/2014
//Last Modified By: Nathan S

/*
*                               Changelog
* Date         By          Ticket          Version          Description
*2-20-14       Nathan S     n/a            "updated"        Working on fixing bugs.
*                                                           1. Closing Window doesn't close program
*                                                           2. adding functionallity to the buttons
*                                                           3. Also worked on changing cleaning up code.
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
            this.Text = "Add " + this.Text;
            btMorph.Text = "Add Product";

            _myAccessToken = accToken;



        }

       private void lvVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            btAddVendor.Enabled = false;
        }//ProductView
        public ProductView(AccessToken accToken, Product ProductInfo)
        {
            InitializeComponent();

            _myAccessToken = accToken;

            _currentProduct = ProductInfo;
            tbProductID.Text = ProductInfo.Id.ToString();
            //comboCategory.Text = ProductInfo.Category.ToString();
            //comboWHSL.Text = ProductInfo.WHSLocation.ToString();
            tbDescription.Text = ProductInfo.description;
            tbItemName.Text = ProductInfo.Name;
            tbQuantity.Text = ProductInfo.available.ToString();
            tbUnitPrice.Text = ProductInfo.unitPrice.ToString();

            this.Text = "Update " + this.Text;

            btMorph.Text = "Update";

        }
        private void btClose_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct(_myAccessToken);
            frm.Show();
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

        //btMorph_Click

        private void btAddVendor_Click(object sender, EventArgs e)
        {

            AddVendorWindow newWindow = new AddVendorWindow(tbProductID.Text);

        }

        private void ProductView_Load(object sender, EventArgs e)
        {

        }

        private void btMorph_Click(object sender, EventArgs e)
        {
            if (btMorph.Text == "Add Product")
            {
                Product productInfo = new Product();

                //comboCategory.Text;
                //comboWHSL.Text;
                productInfo.description = tbDescription.Text;
                productInfo.Name = tbItemName.Text;
                productInfo.available = System.Convert.ToInt32(tbQuantity.Text);
                productInfo.unitPrice = System.Convert.ToDecimal(tbUnitPrice.Text);

                try
                {
                    _productManager.AddProduct(_currentProduct);
                    MessageBox.Show("Product added to Inventory");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has Occured. Error Message: " + ex.Message);
                }

            }
            else if (btMorph.Text == "Update")
            {

                Product productInfo = new Product();
                productInfo.description = tbDescription.Text;
                productInfo.Name = tbItemName.Text;
                productInfo.available = System.Convert.ToInt32(tbQuantity.Text);
                productInfo.unitPrice = System.Convert.ToDecimal(tbUnitPrice.Text);

                try
                {
                    _productManager.UpdateProduct(newProduct, _currentProduct);
                    MessageBox.Show("Product added to Inventory");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has Occured. Error Message: " + ex.Message);
                }
            }

        }

    }//public partial class ProductView : Form

}
