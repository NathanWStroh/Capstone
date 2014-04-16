using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

namespace com.Farouche.Presentation
{
    public partial class FrmVendorAddUpdate : Form
    {
        private readonly AccessToken _myAccessToken;
        private List<State> _myStateList = new List<State>();
        private VendorManager _myVendorManager = new VendorManager();
        private Vendor _myVendor = new Vendor();
        private Vendor _myUpdatedVendor = new Vendor();

        public FrmVendorAddUpdate(AccessToken acctkn)
        {
            InitializeComponent();
            _myAccessToken = acctkn;
            btMorph.Text = "Add Vendor";

            foreach (State state in _myStateList)
            {
                cbVendorState.Items.Add(state.Name);
            }
        }//Add window end

        public FrmVendorAddUpdate(AccessToken acctkn, Vendor vendor)
        {
            InitializeComponent();
            
            _myAccessToken = acctkn;
            _myVendor = vendor;

            btMorph.Text = "Update Vendor";

            txtVendorID.Text = vendor.Id.ToString();
            txtVendorName.Text = vendor.Name;
            txtVendorAddress.Text = vendor.Address;
            txtVendorCity.Text = vendor.City;
            cbVendorState.Text = vendor.State;
            cbVendorCountry.Text = vendor.Country;
            txtVendorZipCode.Text = vendor.Zip;

            txtVendorContact.Text = vendor.Contact;
            txtVendorContactEmail.Text = vendor.ContactEmail;
            txtVendorContactPhone.Text = vendor.Phone;

        }//update window end

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }//close event

        private void btMorph_Click(object sender, EventArgs e)
        {
            if (btMorph.Text == "Add Vendor")
            {
                try
                {
                    _myVendor.Name = txtVendorName.Text.ToString();
                    _myVendor.Address = txtVendorAddress.Text;
                    _myVendor.City = txtVendorCity.Text;
                    _myVendor.State = cbVendorState.Text;
                    _myVendor.Country = cbVendorCountry.Text;
                    _myVendor.Zip = txtVendorZipCode.Text;

                    _myVendor.Contact = txtVendorContact.Text;
                    _myVendor.ContactEmail = txtVendorContactEmail.Text;
                    _myVendor.Phone = txtVendorContactPhone.Text;

                    _myVendorManager.AddVendor(_myVendor);

                    MessageBox.Show("Vendor was added");
                }//end try
                catch (Exception ex)
                {
                    MessageBox.Show("This is a generic message and should be changed" + ex.ToString());
                }//end catch

            }
            else
            {
                try
                {
                    _myUpdatedVendor.Name = txtVendorName.Text.ToString();
                    _myUpdatedVendor.Address = txtVendorAddress.Text;
                    _myUpdatedVendor.City = txtVendorCity.Text;
                    _myUpdatedVendor.State = cbVendorState.Text;
                    _myUpdatedVendor.Country = cbVendorCountry.Text;
                    _myUpdatedVendor.Zip = txtVendorZipCode.Text;

                    _myUpdatedVendor.Contact = txtVendorContact.Text;
                    _myUpdatedVendor.ContactEmail = txtVendorContactEmail.Text;
                    _myUpdatedVendor.Phone = txtVendorContactPhone.Text;

                    _myVendorManager.UpdateVendor(_myVendor, _myUpdatedVendor);

                    MessageBox.Show("Vendor was updated!");
                }//end try
                catch (Exception ex)
                {
                    MessageBox.Show("This is a generic message and should be changed" + ex.ToString());
                }//end catch
            }
        }//morph button event
    }
}
