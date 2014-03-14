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
 * 
*/

namespace com.Farouche
{
    public partial class FrmAddShippingTerm : Form
    {
        private ShippingTermManager _myShippingTermManager;
        private ShippingVendorManager _myShippingVendorManager;

        public FrmAddShippingTerm()
        {
            InitializeComponent();
            _myShippingTermManager = new ShippingTermManager();
            _myShippingVendorManager = new ShippingVendorManager();
            PopulateVendorList();
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
        }//End of btnAdd_Click(..)

        private void ClearFields()
        {
            txtDesc.Text = "";
            comboVendor.SelectedIndex = 0;
        }//End of ClearFields()

        private void PopulateVendorList()
        {
            _myShippingVendorManager.GetVendors();
            ShippingVendor vendor;
            for (int i = 0; i < _myShippingVendorManager.ShippingVendors.Count; i++)
            {
                vendor = _myShippingVendorManager.ShippingVendors[i];
                comboVendor.Items.Add(vendor.Id);
            }
            comboVendor.SelectedIndex = 0;
        }//End of PopulateVendorList()
    }
}
