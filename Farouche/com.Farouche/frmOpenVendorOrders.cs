using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

namespace com.Farouche
{
    public partial class frmOpenVendorOrders : Form
    {
        private VendorManager _vendorManager;
        
        public frmOpenVendorOrders()
        {
            InitializeComponent();

        }

        private void frmOpenVendorOrders_Load(object sender, EventArgs e)
        {
            fillVendorDropDown();
        }

        
           
        private void fillVendorDropDown()
        {
            _vendorManager = new VendorManager();
            List<Vendor> vendorList = new List<Vendor>();


            vendorList = _vendorManager.GetVendors();

            foreach (Vendor v in vendorList)
            {

                cbGetVendorsByName.Items.Add(v.Name);
            }

        }

        private void cbGetVendorsByName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


            
        
    }
}
