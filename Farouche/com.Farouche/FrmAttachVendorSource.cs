using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.Commons;
using com.Farouche.BusinessLogic;

namespace com.Farouche
{
    public partial class FrmAttachVendorSource : Form
    {
        private Product _currentProduct;
        private VendorSourceItemManager _vendorSource;
        private VendorManager _vendorManager;
        List<Vendor> vendors;

        public FrmAttachVendorSource(Product product)
        {
            InitializeComponent();
            _currentProduct = product;
            _vendorSource = new VendorSourceItemManager();
            _vendorManager = new VendorManager();
            vendors = _vendorManager.GetVendors();
        }//End of FrmAttachVendorSource(.)

        private void FrmAttachVendorSource_Load(object sender, EventArgs e)
        {
            lblDisplayUnitPrice.Text = String.Format("{0:C}", 0);
            PopulateActiveCombo();
            PopulateVendorCombo();
            txtVendorName.Text = vendors[0].Name;
        }//End of FrmAttachVendorSource_Load(..)

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//End of btCancel_Click(..)

        private void btnAdd_Click(object sender, EventArgs e)
        {
            VendorSourceItem vendorSource = new VendorSourceItem()
            {
                ProductID = _currentProduct.Id,
                VendorID = (int)cbVendor.SelectedItem,
                UnitCost = (decimal)nudUnitPrice.Value,
                ItemsPerCase = (int)nudCase.Value,
                MinQtyToOrder = (int)nudMinnimum.Value,
                Active = Convert.ToBoolean(cbActive.SelectedItem)
            };
            try
            {
                if (_vendorSource.AddVendorSourceItem(vendorSource))
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("The vendor was attached to this product.");
                }
                else
                {
                    MessageBox.Show("The vendor was not attached to the product.\nThat Product/Vendor combination may already exist.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has Occured. Error Message: " + ex.Message);
            }
        }//End of btnAdd_Click(..)

        private void PopulateActiveCombo()
        {
            Active active;
            for (int i = 1; i >= 0; i--)
            {
                active = (Active)i;
                this.cbActive.Items.Add(active);
            }
            this.cbActive.SelectedIndex = 0;
        }//End of populateActiveCombo()

        private void PopulateVendorCombo()
        {
            foreach(var vendor in vendors)
            {
                cbVendor.Items.Add(vendor.Id + " " + vendor.Name);
            }
            this.cbVendor.SelectedIndex = 0;

        }//End of PopulateVendorCombo()

        private void nudUnitPrice_ValueChanged(object sender, EventArgs e)
        {
            //lblDisplayUnitPrice.Text = String.Format("{0:C}", nudUnitPrice.Value);
        }
        private void cbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtVendorName.Text = vendors[cbVendor.SelectedIndex].Name;
        }

        private void nudUnitPrice_Enter(object sender, EventArgs e)
        {
            NumericUpDown that = (NumericUpDown)sender;
            that.Select(0, that.Text.Length);
        }//End of nudUnitPrice_ValueChanged(..)
    }
}
