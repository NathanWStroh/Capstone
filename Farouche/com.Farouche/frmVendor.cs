﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
//Author: Andrew
//Date Created: 1/31/2014
//Last Modified: 02/22/2014 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/7/2014   Adam                          0.0.1b         Updated Instantiation of new objects to use id as parameter
* 
* 04/19/2014  Kaleb Wendel                                 Adjusted class to implement a singleton pattern so only one form can beinstantiated.
* 
*04/22/2014   Andrew Willhoit                              Fixed active/deactive/update/add buttons to show/hide appropriatly
 *                                                         Added search by Vendor capabilites, added display vendors by list by active/deactive
 *                                                         Added Validation. - Adjusted layout of form to match project.
*/




namespace com.Farouche.Presentation
//namespace CapstoneProject
{
    public partial class FrmVendor : Form
    {
        private readonly AccessToken _myAccessToken;
        private VendorManager _myVendorManager = new VendorManager();
        public static FrmVendor Instance;

        public FrmVendor(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            Instance = this;
        }


        private void FrmVendor_Load(object sender, EventArgs e)
        {
            //Populates the active combo box. 
            this.populateActiveCombo();
            populateListView(this.lvVendors, _myVendorManager.GetVendorsByActive(true));
        }


        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken);
            frm.ShowDialog();
            findActiveSelection();
        }

        private void btnUpdateVendor_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedVendor = this.lvVendors.SelectedItems;
            if (selectedVendor.Count > 0)
            {
                int vendorID = Convert.ToInt32(selectedVendor[0].SubItems[0].Text);
                Vendor thisVendor = _myVendorManager.GetVendor(vendorID);
                FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken, thisVendor);
                frm.ShowDialog();
                findActiveSelection();
            }
        }

        private void btnActivateProduct_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedVendor = this.lvVendors.SelectedItems;
            if (selectedVendor.Count > 0)
            {
                int vendorID = Convert.ToInt32(selectedVendor[0].SubItems[0].Text);
                Vendor thisVendor = _myVendorManager.GetVendor(vendorID);
                Boolean success = _myVendorManager.ReactivateVendor(thisVendor);

                if (success == true)
                {
                    MessageBox.Show("The vendor " + thisVendor.Name + " was reactivated");
                }
                findActiveSelection();
            }
        }

        private void btnDeactivateProduct_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedVendor = this.lvVendors.SelectedItems;
            if (selectedVendor.Count > 0)
            {
                int vendorID = Convert.ToInt32(selectedVendor[0].SubItems[0].Text);
                Vendor thisVendor = _myVendorManager.GetVendor(vendorID);
                Boolean success = _myVendorManager.DeactivateVendor(thisVendor);

                if (success == true)
                {
                    MessageBox.Show("The vendor " + thisVendor.Name + " was deactivated");
                }
                findActiveSelection();
            }
        }

        private void btnGetVendorByID_Click(object sender, EventArgs e)
        {
            searchForVendorByID();

        }

        private void populateListView(ListView lv, List<Vendor> vendorList)
        {
            try
            {
                lv.Clear();

                foreach (var vendor in vendorList)
                {
                    var item = new ListViewItem();
                    item.Text = vendor.Id.ToString();
                    item.SubItems.Add(vendor.Name);
                    item.SubItems.Add(vendor.Address);
                    item.SubItems.Add(vendor.City);
                    item.SubItems.Add(vendor.State);
                    item.SubItems.Add(vendor.Country);
                    item.SubItems.Add(vendor.Zip);
                    item.SubItems.Add(vendor.Contact);
                    item.SubItems.Add(vendor.ContactEmail);
                    item.SubItems.Add(vendor.Phone);
                    item.SubItems.Add(vendor.Active.ToString());
                    lv.Items.Add(item);
                }
                lv.Columns.Add("Id");
                lv.Columns.Add("Name");
                lv.Columns.Add("Address");
                lv.Columns.Add("City");
                lv.Columns.Add("State");
                lv.Columns.Add("Country");
                lv.Columns.Add("Zip Code");
                lv.Columns.Add("Contact");
                lv.Columns.Add("Contact Email");
                lv.Columns.Add("Contact Phone");
                lv.Columns.Add("Active");
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while loading the vendor listView. " + ex.ToString());
            }
        }

        private void setDefaults()
        {
            btnUpdateVendor.Enabled = false;
            btnDeactivateVendor.Enabled = false;
            btnActivateVendor.Enabled = false;
        }


        //Populates the Active combo box.
        //Postcondition: The combo box will hold the values (Yes, No, Both).
        private void populateActiveCombo()
        {
            Active active;
            for (int i = 1; i >= 0; i--)
            {
                active = (Active)i;
                this.cbVendorStatusSearch.Items.Add(active);
            }
            this.cbVendorStatusSearch.Items.Add("Both");
            this.cbVendorStatusSearch.SelectedIndex = 0;
        }





        private void cbVendortStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            findActiveSelection();
        }

        private void findActiveSelection()
        {
            Boolean active;
            switch (this.cbVendorStatusSearch.SelectedIndex)
            {
                case 0:
                    active = true; //True
                    populateListView(this.lvVendors, _myVendorManager.GetVendorsByActive(active));
                    break;
                case 1:
                    active = false; //False
                    populateListView(this.lvVendors, _myVendorManager.GetVendorsByActive(active));
                    break;
                case 2:
                    populateListView(this.lvVendors, _myVendorManager.GetVendors());
                    break;
            }
            setDefaults();
        }

        private void lvVendors_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedVendor = this.lvVendors.SelectedItems;
            if (selectedVendor.Count > 0)
            {
                int vendorID = Convert.ToInt32(selectedVendor[0].SubItems[0].Text);
                Vendor thisVendor = _myVendorManager.GetVendor(vendorID);

                if (thisVendor.Active == true)
                {
                    btnActivateVendor.Enabled = false;
                    btnDeactivateVendor.Enabled = true;
                }
                else
                {
                    btnActivateVendor.Enabled = true;
                    btnDeactivateVendor.Enabled = false;

                }
                btnUpdateVendor.Enabled = true;
            }
        } //end lvVendors_Click(..)

        private void lvVendors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedVendor = this.lvVendors.SelectedItems;
            if (selectedVendor.Count > 0)
            {
                int vendorID = Convert.ToInt32(selectedVendor[0].SubItems[0].Text);
                Vendor thisVendor = _myVendorManager.GetVendor(vendorID);
                if (thisVendor.Active == true)
                {
                    btnActivateVendor.Enabled = false;
                    btnDeactivateVendor.Enabled = true;
                }
                else
                {
                    btnActivateVendor.Enabled = true;
                    btnDeactivateVendor.Enabled = false;

                }
                this.txtVendorIDSearch.Text = thisVendor.Id.ToString();
                btnUpdateVendor.Enabled = true;
            }
        }


        private void searchForVendorByID()
        {
            if (inputIsValid())
            { 
                String vendorIDString = this.txtVendorIDSearch.Text;
                int vendorID = Convert.ToInt32(vendorIDString);
                Vendor thisVendor = _myVendorManager.GetVendor(vendorID);
                FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken, thisVendor);
                frm.ShowDialog();
                setDefaults();
            }
            
        }

        // does Validation on VendorID Search TextBox
        private Boolean inputIsValid()
        {
            string errText = this.txtVendorIDSearch.Text;
            if (Validation.IsBlank(this.txtVendorIDSearch.Text) || 
                Validation.IsNullOrEmpty(this.txtVendorIDSearch.Text))
            {
                MessageBox.Show("There must be an Id to search for.");
                this.txtVendorIDSearch.Focus();
                this.txtVendorIDSearch.Clear();
                return false;
            }
            else if (!Validation.IsInt(this.txtVendorIDSearch.Text))
            {
                MessageBox.Show("'" + errText + "'" + " is not a valid Vendor ID. " + 
                    "\nId must be a numeric value.");
                this.txtVendorIDSearch.Focus();
                this.txtVendorIDSearch.Clear();
                return false;
            } 
            
            int venID = Convert.ToInt32(txtVendorIDSearch.Text);
            int maxID =  _myVendorManager.GetMaxVendorID();
            if (!Validation.IsIntRange(1, maxID ,venID)) 
            {
                MessageBox.Show("'" + errText + "'" + " is not a valid Vendor ID. " +
    "\nId must be greater than 0 but less than " + maxID );
                this.txtVendorIDSearch.Focus();
                this.txtVendorIDSearch.Clear();
                return false;
            }

            return true;
        }


        private void FrmVendor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }


    }
}
