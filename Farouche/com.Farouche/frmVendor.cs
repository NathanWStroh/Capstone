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
*/
namespace com.Farouche.Presentation
//namespace CapstoneProject
{
    public partial class FrmVendor : Form
    {
        private readonly AccessToken _myAccessToken;
        private VendorManager _vendorManager;
        //private ProductBLL productManager;
        Vendor vendor;
        Vendor origVendor;
        Vendor updatedVendor;

        public FrmVendor(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
        }

        private void frmVendor_Load(object sender, EventArgs e)
        {
            Text += "                         " + _myAccessToken.FirstName + " " + _myAccessToken.LastName + " logged in as a " + _myAccessToken.Title;
            
            _vendorManager = new VendorManager();
           // productManager = new ProductBLL();
            showVendors();
            showProducts();
            populateVendorsInfo();
            populateVendorsById();
            
        }

        // don't know how to get rid of this, so I just commented out the code inside
        private void tpAddVendor_Click(object sender, EventArgs e)
        {
           // tpAddVendor.Controls.Add(lblVendorName);  
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewVendor_Click(object sender, EventArgs e)
        {
            addVendor();
        }

        private void addVendor()
        {
            string name = txtVendorName.Text;
            string address = txtVendorAddress.Text;
            string city = txtVendorCity.Text;
            // string state = cbVendorState.SelectedText.Trim();
            string state = cbVendorState.Text;
            string zip = txtVendorZipCode.Text;
            string country = cbVendorCountry.Text;
            string phone = txtVendorContactPhone.Text;
            string contact = txtVendorContact.Text;
            string email = txtVendorContactEmail.Text;
            vendor = new Vendor(name, address, city, state, zip, country, phone, contact, email);

         //   Console.WriteLine("Here: " + name + " " + address  + " " + city  + " " + state + " " + zip  + " " + country  + " " + phone  + " " + contact  + " " + email  );

            //bool success = _vendorManager.AddVendorBll(name, address, city, state, country, zip, phone, contact, email);
            
            
            bool success = _vendorManager.AddVendor(vendor);//updated vendor code to pass a Vendor object instead of variables--Justin Pitts 2/13/14
            if (success == true)
            {
                MessageBox.Show(name + " was added");
                showVendors();//updated to refresh List of Vendors after adding a new Vendor--Justin Pitts 2/13/14
            }
            else
            {
                MessageBox.Show(name + " was not added, sorry bro");
            }

            
        }

        private void deactivateVendor()
        {

            
           


        }
        private void showVendors()
        {
            string vendorListString = "";
          
            List<Vendor> vendorList = new List<Vendor>();

            vendorList = _vendorManager.GetVendors();

            foreach (Vendor v in vendorList)
            {
              vendorListString = vendorListString + (v.ToString() + "\r\n");
            }

            txtVendors.Text = vendorListString;
        }

        private void populateVendorsInfo()
        {
            

            List<Vendor> vendorList = new List<Vendor>();
            

            vendorList = _vendorManager.GetVendors();

            foreach (Vendor v in vendorList)
            {
                
                cbDeactivateVendorID.Items.Add(v.Id);
            }

            
        }

        private void populateVendorsById()
        {


            List<Vendor> vendorList = new List<Vendor>();


            vendorList = _vendorManager.GetVendors();

            foreach (Vendor v in vendorList)
            {

                cbVendorID.Items.Add(v.Id);
            }


        }

        private void showProducts()
        {
            //string productListString = "";
            //List<Product2> productList = new List<Product2>();

            //productList = productManager.getProducts();

            //foreach (Product2 p in productList)
            //{ 
            //productListString = productListString + (p.toString() + "\r\n");
            //}

            //Console.WriteLine(productListString);
            //txtProducts.Text = productListString;

        }



        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmProduct myform = new FrmProduct(_myAccessToken);
            myform.Show();
            Close();
        }


        private void btnVendorSource_Click(object sender, EventArgs e)
        {
            FrmVendorSource form = new FrmVendorSource(_myAccessToken);
            form.Show();
            Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Show();
            Close();
        }

        private void tpDeactivateVendor_Click(object sender, EventArgs e)
        {
            //can't figure how to get rid of this
        }

        private void cbDeactivateVendorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int vendorSelectedId = (int)cbDeactivateVendorID.SelectedItem;
            vendor = _vendorManager.GetVendor(vendorSelectedId);
            cbDeactivateVendorID.Text = vendor.Id.ToString();
            txtDeactivateName.Text = vendor.Name;
            txtDeactivateAddress.Text = vendor.Address;
            txtDeactivateCity.Text = vendor.City;
            cbDeactivateCountry.Text = vendor.Country;
            cbDeactivateState.Text = vendor.State;
            txtDeactivateZipCode.Text = vendor.Zip;
            txtDeactivateContact.Text = vendor.Contact;
            txtDeactivatePhone.Text = vendor.Phone;
            txtDeactivateContEmail.Text = vendor.ContactEmail;
            
        }

        private void btnDeactivateVendor_Click(object sender, EventArgs e)
        {
            bool success = _vendorManager.DeactivateVendor(vendor);
            if (success == true)
            {
                MessageBox.Show(vendor.Name + " was deActivated");
                showVendors();//updated to refresh List of Vendors after adding a new Vendor--Justin Pitts 2/13/14
            }
            else
            {
                MessageBox.Show(vendor.Name + " was not deActivated");
            }

            
        }

        private void tpUpdateVendor_Click(object sender, EventArgs e)
        {
            //couldn't remove this
        }

       

        private void cbVendorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int vendorSelectedId = (int)cbVendorID.SelectedItem;
            origVendor = _vendorManager.GetVendor(vendorSelectedId);
            cbVendorID.Text = origVendor.Id.ToString();
            txtUpdateVendorName.Text = origVendor.Name;
            txtUpdateAddress.Text = origVendor.Address;
            txtUpdateCity.Text = origVendor.City;
            cbCountry.Text = origVendor.Country;
            cbState.Text = origVendor.State;
            txtUpdateZip.Text = origVendor.Zip;
            txtUpdateContact.Text = origVendor.Contact;
            txtUpdatePhone.Text = origVendor.Phone;
            txtUpdateEmail.Text = origVendor.ContactEmail;
            
        }

        private void btnUpdateVendor_Click(object sender, EventArgs e)
        {
            updatedVendor = new Vendor(origVendor.Id) ;
            updatedVendor.Name = txtUpdateVendorName.Text;
            updatedVendor.Address = txtUpdateAddress.Text;
            updatedVendor.City = txtUpdateCity.Text;
            updatedVendor.State = cbState.Text;
            updatedVendor.Country = cbCountry.Text;
            updatedVendor.Zip = txtUpdateZip.Text;
            updatedVendor.Contact = txtUpdateContact.Text;
            updatedVendor.ContactEmail = txtUpdateEmail.Text;
            updatedVendor.Phone = txtUpdatePhone.Text;
            




            bool success = _vendorManager.UpdateVendor(updatedVendor, origVendor);
            if (success == true)
            {
                MessageBox.Show(updatedVendor.Name + " was updated");
                showVendors();//updated to refresh List of Vendors after adding a new Vendor--Justin Pitts 2/13/14
            }
            else
            {
                MessageBox.Show(updatedVendor.Name + " was not updated");
            }
        }

        private void btnOpenVendorOrders_Click(object sender, EventArgs e)
        {
            frmOpenVendorOrders _frmOpenVendorOrders = new frmOpenVendorOrders();
            _frmOpenVendorOrders.Show();
        }

        private void btnReceiving_Click(object sender, EventArgs e)
        {
            frmReceiving _frmReceiving = new frmReceiving();
            _frmReceiving.Show();
        }


       




        
    }
}
