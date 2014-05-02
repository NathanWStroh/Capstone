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

/*
*                               Changelog
* Date         By          Ticket          Version          Description
* 4/30/2014    Kaleb                                        Bound the vendor combo box to a dictionary.  This is used to set the display member to the vendor name and the value member to the vendor Id.
*
* 4/30/2014    Kaleb                                        Added functionality to update the vendor source item.
*/
namespace com.Farouche
{
    public partial class FrmAttachVendorSource : Form
    {
        private Product _currentProduct;
        private VendorSourceItemManager _vendorSource;
        private VendorManager _vendorManager;
        private VendorSourceItem _currentVendorSourceItem;
        List<Vendor> _vendors;

        public FrmAttachVendorSource(Product product)
        {
            InitializeComponent();
            _currentProduct = product;
            _vendorSource = new VendorSourceItemManager();
            _vendorManager = new VendorManager();
            _vendors = _vendorManager.GetVendors();
        }//End of FrmAttachVendorSource(.)

        public FrmAttachVendorSource(Product product, VendorSourceItem currentVendorSourceItem)
        {
            InitializeComponent();
            _vendorSource = new VendorSourceItemManager();
            _vendorManager = new VendorManager();
            _currentVendorSourceItem = currentVendorSourceItem;
            _vendors = _vendorManager.GetVendors();
            _currentProduct = product;
            nudCase.Value = _currentVendorSourceItem.ItemsPerCase;
            nudMinnimum.Value = _currentVendorSourceItem.MinQtyToOrder;
            nudUnitPrice.Value = _currentVendorSourceItem.UnitCost;
            btnAdd.Text = "Update Vendor";
            comboVendors.Enabled = false;
        }//End of FrmAttachVendorSource(..)

        private void FrmAttachVendorSource_Load(object sender, EventArgs e)
        {
            lblDisplayUnitPrice.Text = String.Format("{0:C}", 0);
            PopulateVendorCombo();
        }//End of FrmAttachVendorSource_Load(..)

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//End of btCancel_Click(..)

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnAdd.Text.Equals("Add Vendor"))
            {
                VendorSourceItem vendorSource = new VendorSourceItem()
                {
                    ProductID = _currentProduct.Id,
                    VendorID = ((KeyValuePair<int,string>)comboVendors.SelectedItem).Key,
                    UnitCost = nudUnitPrice.Value,
                    ItemsPerCase = (int)nudCase.Value,
                    MinQtyToOrder = (int)nudMinnimum.Value,
                    Active = true,
                };
                try
                {
                    if (_vendorSource.AddVendorSourceItem(vendorSource))
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("The vendor details were added to this product.");
                    }
                    else
                    {
                        MessageBox.Show("The vendor was not attached to the product.\nThat Product/Vendor combination may already exist.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if(btnAdd.Text.Equals("Update Vendor"))
            {
                VendorSourceItem vendorSource = new VendorSourceItem()
                {
                    ProductID = _currentProduct.Id,
                    VendorID = ((KeyValuePair<int, string>)comboVendors.SelectedItem).Key,
                    UnitCost = nudUnitPrice.Value,
                    ItemsPerCase = (int)nudCase.Value,
                    MinQtyToOrder = (int)nudMinnimum.Value,
                    Active = true,
                };
                try
                {
                    if (_vendorSource.UpdateVendorSourceItem(vendorSource, _currentVendorSourceItem))
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("The vendor details for this product were updated.");
                    }
                    else
                    {
                        MessageBox.Show("The vendor details were not updated. This information may have already been updated by another employee. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has Occured. Error Message: " + ex.Message);
                }
            }
        }//End of btnAdd_Click(..)

        private void PopulateVendorCombo()
        {
            Dictionary<int,String> vendorsDictionary = new Dictionary<int,string>();
            int counter = 0;
            int index = 0;
            foreach(var vendor in _vendors)
            {
                vendorsDictionary.Add(vendor.Id, vendor.Name);
                if(_currentVendorSourceItem != null)
                {
                    if (vendor.Name.Equals(_currentVendorSourceItem.Name))
                    {
                        index = counter;
                    }
                    counter++;
                }
            }
            comboVendors.DataSource = new BindingSource(vendorsDictionary, null);
            comboVendors.DisplayMember = "Value";
            comboVendors.ValueMember = "Key";
            comboVendors.SelectedIndex = index;
        }//End of PopulateVendorCombo()

        private void nudUnitPrice_ValueChanged(object sender, EventArgs e)
        {
            //lblDisplayUnitPrice.Text = String.Format("{0:C}", nudUnitPrice.Value);
        }

        private void nudUnitPrice_Enter(object sender, EventArgs e)
        {
            NumericUpDown that = (NumericUpDown)sender;
            that.Select(0, that.Text.Length);
        }//End of nudUnitPrice_ValueChanged(..)
    }
}
