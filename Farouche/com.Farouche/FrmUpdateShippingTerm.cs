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
*/

namespace com.Farouche
{
    public partial class FrmUpdateShippingTerm : Form
    {
        private ShippingTermManager _myShippingTermManager;
        private ShippingVendorManager _myShippingVendorManager;
        private ShippingTerm _originalTerm;

        public FrmUpdateShippingTerm(ShippingTerm term)
        {
            InitializeComponent();
            _myShippingTermManager = new ShippingTermManager();
            _myShippingVendorManager = new ShippingVendorManager();
            _originalTerm = term;
            PopulateVendorList();
            txtDesc.Text = term.Description;
            comboVendor.SelectedItem = term.ShippingVendorId;
            this.Text = "Shipping Term: " + term.Id;
        }//End of FrmUpdateShippingTerm(.)

        private void ClearFields()
        {
            txtDesc.Text = "";
            comboVendor.SelectedIndex = 0;
        }//End of ClearFields()

        private void PopulateVendorList()
        {
            _myShippingVendorManager.GetVendors();
            ShippingVendor vendor;
            int index = 0;
            for (int i = 0; i < _myShippingVendorManager.ShippingVendors.Count; i++)
            {
                vendor = _myShippingVendorManager.ShippingVendors[i];
                comboVendor.Items.Add(vendor.Id);
            }
        }//End of PopulateVendorList()

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//End of btnCancel_Click(..)

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            ShippingTerm term;
            if (txtDesc.TextLength > 250 || txtDesc.Text.Equals(""))
            {
                MessageBox.Show("The description was not valid.\nThis value must be 250 characters or less.");
                txtDesc.Focus();
            }
            else
            {
                term = new ShippingTerm();
                term.Description = txtDesc.Text;
                term.ShippingVendorId = (int)comboVendor.SelectedItem;
                term.Id = _originalTerm.Id;
                if (_myShippingTermManager.Update(term, _originalTerm))
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Term: " + _originalTerm.Id + " was updated.");
                }
                else
                {
                    MessageBox.Show("The shipping term was not updated.");
                }
            }
        }//End of btnEdit_Click(..)
    }
}

