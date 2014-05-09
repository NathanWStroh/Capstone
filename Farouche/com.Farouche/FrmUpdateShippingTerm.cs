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

//Author: Kaleb
//Date Created: 3/13/2014
//Last Modified: 3/13/2014
//Last Modified By: Steven Schuette

/*
*                               Changelog
* Date         By          Ticket          Version          Description
* 5/1/2014     Kaleb                                        Improved validation to use the Validation class.
*
* 5/1/2014     Kaleb                                        Adjusted class to populate the vendor drop down with the vendor name rather than Id.
*/

namespace com.Farouche
{
    public partial class FrmUpdateShippingTerm : Form
    {
        private ShippingTermManager _myShippingTermManager;
        private ShippingVendorManager _myShippingVendorManager;
        private ShippingTerm _originalTerm;
        List<ShippingVendor> vendors;

        public FrmUpdateShippingTerm(ShippingTerm term, AccessToken _myAccessToken)
        {
            InitializeComponent();
            var RoleAccess = new RoleAccess(_myAccessToken, this);
            _myShippingTermManager = new ShippingTermManager();
            _myShippingVendorManager = new ShippingVendorManager();
            vendors = _myShippingVendorManager.GetVendors();
            _originalTerm = term;
            PopulateVendorCombo();
            txtDesc.Text = term.Description;
            this.Text = "Shipping Term: " + term.Id;
        }//End of FrmUpdateShippingTerm(.)

        private void ClearFields()
        {
            txtDesc.Text = "";
            comboVendors.SelectedIndex = 0;
        }//End of ClearFields()

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//End of btnCancel_Click(..)

        private void btnEdit_Click_1(object sender, EventArgs e)
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
            if (validShippingTerm)
            {
                term = new ShippingTerm()
                {
                    Description = txtDesc.Text,
                    ShippingVendorId = ((KeyValuePair<int, string>)comboVendors.SelectedItem).Key,
                    Id = _originalTerm.Id
                };
                if (_myShippingTermManager.Update(term, _originalTerm))
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Shipping term " + _originalTerm.Id + " was updated.");
                }
                else
                {
                    MessageBox.Show("The shipping term was not updated.");
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }//End of btnEdit_Click(..)
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
                    if (vendor.Id.Equals(_originalTerm.ShippingVendorId))
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

