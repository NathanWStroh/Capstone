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

//Author: Kaleb
//Date Created: 3/13/2014
//Last Modified: 3/13/2014
//Last Modified By: Kaleb Wendel

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 5/1/2014     Kaleb                                        Improved validation to use the Validation class.
*
* 5/1/2014     Kaleb                                        Adjusted class to populate the vendor drop down with the vendor name rather than Id.
*/

namespace com.Farouche
{
    public partial class FrmAddShippingTerm : Form
    {
        private ShippingTermManager _myShippingTermManager;
        private ShippingVendorManager _myShippingVendorManager;
        private ShippingTerm _originalTerm;
        List<ShippingVendor> vendors;

        public FrmAddShippingTerm()
        {
            InitializeComponent();
            _myShippingTermManager = new ShippingTermManager();
            _myShippingVendorManager = new ShippingVendorManager();
            vendors = _myShippingVendorManager.GetVendors();
            PopulateVendorCombo();
        }//End of FrmAddShippingTerm()

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//End of btnCancel_Click(..)

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }//End of btnClear_Click(..)
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShippingTerm term;
            bool validShippingTerm = true;
            string errorMessage = "Please correct the following errors:\n";
            if(Validation.IsNullOrEmpty(txtDesc.Text) || Validation.IsBlank(txtDesc.Text))
            {
                validShippingTerm = false;
                errorMessage += "You must enter a description.";
                txtDesc.Focus();
            }
            if (txtDesc.TextLength > 250)
            {
                validShippingTerm = false;
                errorMessage += "The description must be 250 characters or less.";
                txtDesc.Focus();
            }
            if(validShippingTerm)
            {
                term = new ShippingTerm()
                {
                    Description = txtDesc.Text,
                    ShippingVendorId = ((KeyValuePair<int,string>)comboVendors.SelectedItem).Key
                };
                if(_myShippingTermManager.Insert(term))
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("The shipping term was created and added.");
                }
                else
                {
                    MessageBox.Show("The shipping term was not created.");
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }//End of btnAdd_Click(..)

        private void ClearFields()
        {
            txtDesc.Text = "";
            comboVendors.SelectedIndex = 0;
        }//End of ClearFields()

        private void PopulateVendorCombo()
        {
            Dictionary<int, String> vendorsDictionary = new Dictionary<int, string>();
            int counter = 0;
            int index = 0;
            foreach (var vendor in vendors)
            {
                vendorsDictionary.Add(vendor.Id, vendor.Name);
                if (_originalTerm != null)
                {
                    if (vendor.Id.Equals(_originalTerm.Id))
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
    }
}
