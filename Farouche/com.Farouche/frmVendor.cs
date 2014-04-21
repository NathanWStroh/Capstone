using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
//Author: Andrew
//Date Created: 1/31/2014
//Last Modified: 02/7/2014 
//Last Modified By: Adam Chandler

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/7/2014   Adam                          0.0.1b         Updated Instantiation of new objects to use id as parameter
* 
* 04/19/2014  Kaleb Wendel                                 Adjusted class to implement a singleton pattern so only one form can beinstantiated.
*/




namespace com.Farouche.Presentation
//namespace CapstoneProject
{
    public partial class FrmVendor : Form
    {
        private readonly AccessToken _myAccessToken;
        private VendorManager _myVendorManager = new VendorManager();
        private List<Vendor> _myVendorList = new List<Vendor>();
        public static FrmVendor Instance;

        public FrmVendor(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
          //  _myVendorList = _myVendorManager.GetVendors();
          //  populateListView(lvVendors, _myVendorList);
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
        }

        private void btnUpdateVendor_Click(object sender, EventArgs e)
        {
            //have to add 1 to current index so it grabs the proper vendor id.
            int currentIndex = this.lvVendors.SelectedIndices[0]+1;
            Vendor thisVendor = _myVendorManager.GetVendor(currentIndex);
            FrmVendorAddUpdate frm = new FrmVendorAddUpdate(_myAccessToken, thisVendor);
            frm.ShowDialog();
        }

        private void btnActivateProduct_Click(object sender, EventArgs e)
        {
            int currentIndex = this.lvVendors.SelectedIndices[0] + 1;
            Vendor thisVendor = _myVendorManager.GetVendor(currentIndex);
            Boolean success = _myVendorManager.ReactivateVendor(thisVendor);
            if (success == true)
            {
                MessageBox.Show("The vendor was activated");
            }
            findActiveSelection();
        }

        private void btnDeactivateProduct_Click(object sender, EventArgs e)
        {

        }

        private void populateListView(ListView lv, List<Vendor> vendorList)
        {
            try
            {
              //  vendorList = _myVendorList;
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
            }//end of Try
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while loading the vendor listView. " + ex.ToString());
            }//end of Catch
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
                this.cbVendortStatusSearch.Items.Add(active);
            }
            this.cbVendortStatusSearch.Items.Add("Both");
            this.cbVendortStatusSearch.SelectedIndex = 0;
        }



        //private void lvVendors_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int currentIndex = this.lvVendors.SelectedIndices[0] + 1;
        //    var selectedVendor = this.lvVendors.SelectedItems;
        //    if (selectedVendor.Count > 0)
        //    {
        //        currentIndex = (int)selectedVendor[0].SubItems[0].Text;

        //    }
        //    Vendor thisVendor = _myVendorManager.GetVendor(currentIndex);

        //    if (thisVendor.Active == true)
        //    {
        //        btnActivateVendor.Enabled = false;
        //        btnDeactivateVendor.Enabled = true;
        //    }
        //    else
        //    {
        //        btnActivateVendor.Enabled = false;
        //        btnDeactivateVendor.Enabled = true;
        //        //MessageBox.Show(thisVendor.ToString());   
        //    }
        //    btnUpdateVendor.Enabled = true;
        //}



        private void cbVendortStatusSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            findActiveSelection();
        }

        private void findActiveSelection()
        {
            Boolean active;
            switch (this.cbVendortStatusSearch.SelectedIndex)
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
            int currentIndex = this.lvVendors.SelectedIndices[0] + 1;
            Vendor thisVendor = _myVendorManager.GetVendor(currentIndex);
            
            if (thisVendor.Active == true)
            {
                btnActivateVendor.Enabled = false;
                btnDeactivateVendor.Enabled = true;
            }
            else
            {
                btnActivateVendor.Enabled = false;
                btnDeactivateVendor.Enabled = true;
                //MessageBox.Show(thisVendor.ToString());   
            }
            btnUpdateVendor.Enabled = true;
        } //end lvVendors_Click(..)







        private void FrmVendor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }


    }
}
