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
//Last Modified: 4/30/2014
//Last Modified By: Kaleb

/*
*                               Changelog
* Date         By          Ticket          Version          Description
* 4/30/2014    Kaleb                                        Adjusted class to use the states stored as ApplicationVariables.
*
* 4/30/2014    Kaleb                                        Adjusted data validation for the class.
*/

namespace com.Farouche
{
    public partial class FrmAddShippingVendor : Form
    {
        private ShippingVendorManager _myShippingVendorManager;
        public FrmAddShippingVendor()
        {
            InitializeComponent();
            _myShippingVendorManager = new ShippingVendorManager();
            PopulateCountryCombo();
            PopulateStateCombo();
        }//End of FrmAddShippingVendor()

        //Closes the current form upon selecting cancel.
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//End of btnCancel_Click(..)

        //Resets the text box values to null.
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }//End of btnClear_Click(..)

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool validShippingVendor = true;
            string errorMessage = "Please correct the following errors:\n";
            
            ShippingVendor newVendor;
            if (txtEmail.TextLength > 50)
            {
                validShippingVendor = false;
                errorMessage += "\nThe contact email must be less than 50 characters.";
                txtEmail.Focus();
            }
            if (Validation.IsNullOrEmpty(txtContact.Text) || Validation.IsBlank(txtContact.Text))
            {
                validShippingVendor = false;
                errorMessage += "\nYou must enter a primary contact.";
                txtContact.Focus();
            }
            if (Validation.IsNullOrEmpty(txtPhone.Text) || Validation.IsBlank(txtPhone.Text))
            {
                validShippingVendor = false;
                errorMessage += "\nYou must enter a phone.";
                txtPhone.Focus();
            }
            if (Validation.IsNullOrEmpty(txtZip.Text) || Validation.IsBlank(txtZip.Text))
            {
                validShippingVendor = false;
                errorMessage += "\nYou must enter a zip code.";
                txtZip.Focus();
            }
            else if (!Validation.ValidateZip(txtZip.Text, comboState.SelectedItem.ToString()))
            {
                validShippingVendor = false;
                errorMessage += "\nZip code " + txtZip.Text + " is not a valid zip code for the state of " + comboState.SelectedItem.ToString() + ".";
                txtZip.Focus();
            }
            if (Validation.IsNullOrEmpty(txtCity.Text) || Validation.IsBlank(txtCity.Text))
            {
                validShippingVendor = false;
                errorMessage += "\nYou must enter a city.";
                txtCity.Focus();
            }
            if (txtCity.TextLength > 25)
            {
                validShippingVendor = false;
                errorMessage += "\nThe city must be less than 25 characters.";
                txtCity.Focus();
            }
            if (Validation.IsNullOrEmpty(txtAddress.Text) || Validation.IsBlank(txtAddress.Text))
            {
                validShippingVendor = false;
                errorMessage += "\nYou must enter an address.";
                txtAddress.Focus();
            }
            if (txtAddress.TextLength > 50)
            {
                validShippingVendor = false;
                errorMessage += "\nThe address must be less than 50 characters.";
                txtAddress.Focus();
            }
            if (Validation.IsNullOrEmpty(txtName.Text) || Validation.IsBlank(txtName.Text))
            {
                validShippingVendor = false;
                errorMessage += "\nYou must enter a vendor name";
                txtName.Focus();
            }
            if (txtName.TextLength > 50)
            {
                validShippingVendor = false;
                errorMessage += "\nThe vendor name must be less than 50 characters.";
                txtName.Focus();
            }

            if(validShippingVendor)
            {
                newVendor = new ShippingVendor();
                newVendor.Name = txtName.Text;
                newVendor.Address = txtAddress.Text;
                newVendor.City = txtCity.Text;
                newVendor.Country = comboCountry.SelectedItem.ToString();
                newVendor.Contact = txtContact.Text;
                newVendor.ContactEmail = txtEmail.Text;
                newVendor.Phone = txtPhone.Text;
                newVendor.Zip = txtZip.Text;
                //newVendor.State = (String)comboState.SelectedItem;
                newVendor.State = comboState.SelectedItem.ToString();
                if (_myShippingVendorManager.Insert(newVendor))
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("The vendor was created and added.");
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("The vendor was not created.");
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }//End of btnAdd_Click(..)

        private void ClearFields()
        {
            txtAddress.Text = "";
            txtCity.Text = "";
            txtContact.Text = "";
            comboCountry.SelectedIndex = 0;
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtZip.Text = "";
            comboState.SelectedIndex = 0;
        }//End of ClearFields()

        private void PopulateStateCombo()
        {
            var appVariables = ApplicationVariables.Instance;
            comboState.DisplayMember = "Value";
            comboState.ValueMember = "Key";
            for (int i = 1; i <= appVariables.States.Count; i++)
            {
                comboState.Items.Add(appVariables.States[i].StateCode);
            }
            comboState.SelectedIndex = 0;
        }//End of PopulateStateCombo()

        private void PopulateCountryCombo()
        {
            comboCountry.Items.Add("United States");
            comboCountry.Items.Add("Canada");
            comboCountry.Items.Add("China");
            comboCountry.Items.Add("Japan");
            comboCountry.SelectedIndex = 0;
        }//End of PopulateCountryCombo()
    }
}
