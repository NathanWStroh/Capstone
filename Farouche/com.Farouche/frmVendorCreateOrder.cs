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

        public frmVendorCreateOrder(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _vendorList = _myVendorManager.GetVendors();
            _productList = _myProductManager.GetProducts();

            tbOrderDate.Text = DateTime.Now.Date.ToString("dd.MM.yyyy");

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
                comboVendor.Items.Add(vendor.Name);

            }

            foreach (var product in _productList)
            {
                comboProduct.Items.Add(product.Name);
            }
        }

        private void btAddNewProduct_Click(object sender, EventArgs e)
        {
            ProductView frm = new ProductView(_myAccessToken);
            frm.ShowDialog();
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            frm.FormClosed -= frm_FormClosed;
        }
        private void frm_FormClosed(object sender, EventArgs e)
        {
            
        }

        private void btAddLineItem_Click(object sender, EventArgs e)
        {

        }


    }
}
