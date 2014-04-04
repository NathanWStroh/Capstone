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
    public partial class FrmAddShippingVendor : Form
    {
        private ShippingVendorManager _myShippingVendorManager;
        public FrmAddShippingVendor()
        {
            InitializeComponent();
            _myShippingVendorManager = new ShippingVendorManager();
            //PopulateCityDropDown();
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
            ShippingVendor newVendor;
            if (txtName.Text.Trim().Equals("") || txtName.TextLength > 50)
            {
                MessageBox.Show("You did not enter a valid vendor name.\nThe value must be 50 characters or less.");
                txtName.Focus();
            }
            else if (txtAddress.Text.Trim().Equals("") || txtAddress.TextLength > 50)
            {
                MessageBox.Show("You did not enter a valid address.\nThe value must be 50 characters or less.");
                txtAddress.Focus();
            }
            else if (txtCity.Text.Trim().Equals("") || txtCity.TextLength > 25)
            {
                MessageBox.Show("You did not enter a valid city.\nThe value must be 25 characters or less.");
                txtCity.Focus();
            }
            else if (txtState.Text.Trim().Equals("") || txtState.TextLength > 2)
            {
                MessageBox.Show("You did not enter a valid State.\nThe value must be 2 characters or less.");
                txtState.Focus();
            }
            else if (txtCountry.Text.Trim().Equals("") || txtCountry.TextLength > 50)
            {
                MessageBox.Show("You did not enter a valid country.\nThe value must be 50 characters or less.");
                txtCountry.Focus();
            }
            else if (txtZip.Text.Trim().Equals("") || txtZip.TextLength > 10)
            {
                MessageBox.Show("You did not enter a valid zip code.\nThe value must be 10 characters or less.");
                txtZip.Focus();
            }
            else if (txtPhone.Text.Trim().Equals("") || txtPhone.TextLength > 12)
            {
                MessageBox.Show("You did not enter a valid phone.\nThe value must be 12 characters or less.");
                txtPhone.Focus();
            }
            else if (txtContact.Text.Trim().Equals("") || txtContact.TextLength > 50)
            {
                MessageBox.Show("You did not enter a valid contact name.\nThe value must be 50 characters or less.");
                txtContact.Focus();
            }
            else if (txtEmail.TextLength > 50)
            {
                MessageBox.Show("You did not enter a valid contact email.\nThe value must be 50 characters or less.");
                txtEmail.Focus();
            }
            else
            {
                newVendor = new ShippingVendor();
                newVendor.Name = txtName.Text;
                newVendor.Address = txtAddress.Text;
                newVendor.City = txtCity.Text;
                newVendor.Country = txtCountry.Text;
                newVendor.Contact = txtContact.Text;
                newVendor.ContactEmail = txtEmail.Text;
                newVendor.Phone = txtPhone.Text;
                newVendor.Zip = txtZip.Text;
                //newVendor.State = (String)comboState.SelectedItem;
                newVendor.State = txtState.Text;
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
        }//End of btnAdd_Click(..)

        private void ClearFields()
        {
            txtAddress.Text = "";
            txtCity.Text = "";
            txtContact.Text = "";
            txtCountry.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtZip.Text = "";
            txtState.Text = "";
        }//End of ClearFields()

        //private void PopulateCityDropDown()
        //{
        //    String[] stateArray = new String[]
        //        {"AL","AK","AS","AZ","AR","CA","CO","CT","DE","DC","FL","GA",
        //        "GU","HI","ID","IL","IN","IA","KS","KY","LA","ME","MD","MH",
        //        "MA","MI","FM","MN","MS","MO","MT","NE","NV","NH","NJ","NM",
        //        "NY","NC","ND","MP","OH","OK","OR","PW","PA","PR","RI","SC",
        //        "SD","TN","TX","UT","VT","VA","VI","WA","WV","WI","WY"};
        //    foreach(var state in stateArray)
        //    {
        //        comboState.Items.Add(state);
        //    }
        //    comboState.SelectedIndex = 0;
        //}
    }
}
