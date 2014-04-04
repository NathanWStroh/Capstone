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
    public partial class FrmUpdateShippingVendor : Form
    {
        private ShippingVendorManager _myShippingVendorManager;
        private ShippingVendor _originalVendor; 

        public FrmUpdateShippingVendor(ShippingVendor vendor)
        {
            InitializeComponent();
            _myShippingVendorManager = new ShippingVendorManager();
            _originalVendor = vendor;
            this.Text = "Shipping Vendor ID: " + vendor.Id;
            txtAddress.Text = vendor.Address;
            txtCity.Text = vendor.City;
            txtContact.Text = vendor.Contact;
            txtCountry.Text = vendor.Country;
            txtEmail.Text = vendor.ContactEmail;
            txtName.Text = vendor.Name;
            txtPhone.Text = vendor.Phone;
            txtZip.Text = vendor.Zip;
            txtState.Text = vendor.State;
            //PopulateCityDropDown();
        }//End of FrmUpdateShippingVendor(.)

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }//End of btnCancel_Click(..)

        private void btnEdit_Click(object sender, EventArgs e)
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
                if (_myShippingVendorManager.Update(newVendor, _originalVendor))
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Vendor: " + _originalVendor.Id + " was updated.");
                }
                else
                {
                    MessageBox.Show("The vendor information was not updated.");
                }
            }
        }//End of btnEdit_Click(..)

        //private void PopulateCityDropDown()
        //{
        //    String[] stateArray = new String[]
        //        {"AL","AK","AS","AZ","AR","CA","CO","CT","DE","DC","FL","GA",
        //        "GU","HI","ID","IL","IN","IA","KS","KY","LA","ME","MD","MH",
        //        "MA","MI","FM","MN","MS","MO","MT","NE","NV","NH","NJ","NM",
        //        "NY","NC","ND","MP","OH","OK","OR","PW","PA","PR","RI","SC",
        //        "SD","TN","TX","UT","VT","VA","VI","WA","WV","WI","WY"};
        //    int index = 0;
        //    for(int i = 0; i < stateArray.Length; i++)
        //    {
        //        comboState.Items.Add(stateArray[i]);
        //        if (stateArray[i].Equals(_originalVendor.State))
        //        {
        //            index = i;
        //        }
        //    }
        //    comboState.SelectedIndex = index;
        //}
    }
}
