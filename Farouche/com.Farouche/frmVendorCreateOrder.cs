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

        public frmVendorCreateOrder(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            _vendorList = _myVendorManager.GetVendors();

            tbOrderDate.Text = DateTime.Now.Date.ToString("dd.MM.yyyy");

            for (int i = 0; i <= 100; i++)
            {
                comboQuanity.Items.Add(i);
            }

            for (int i = 0; i <= 10; i++)
            {
                comboShipments.Items.Add(i);
            }

            _vendorList = _myVendorManager.GetVendors();

            foreach (var vendor in _vendorList)
            {
                comboVendor.Items.Add(vendor.Name);

            }

            //comboProduct.Items.Add(myProduct);
        }


    }
}
