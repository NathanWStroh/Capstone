using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
//Author: ?
//Date Created: ?
//Last Modified: 02/22/2014 
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 
*04/22/2014   Andrew Willhoit                              Updating a Vendor now works. Adjusted layout of form to match project.
 *                                                         Added Validation to both updating and adding vendors.
 *                                                         Forms close when appropriate.
*/
namespace com.Farouche.Presentation
{
    public partial class FrmVendorAddUpdate : Form
    {
        private readonly AccessToken _myAccessToken;
      //  private List<State> _myStateList = new List<State>();
        private VendorManager _myVendorManager = new VendorManager();
        private Vendor _myVendor = new Vendor();
        private Vendor _myUpdatedVendor = new Vendor();
        public static FrmVendorAddUpdate Instance;

        public FrmVendorAddUpdate(AccessToken acctkn)
        {
            InitializeComponent();
            _myAccessToken = acctkn;
            btMorph.Text = "Add Vendor";



            PopulateStateCombo();
            PopulateCountryCombo();

            Instance = this;
        }//Add window end

        public FrmVendorAddUpdate(AccessToken acctkn, Vendor vendor)
        {
            InitializeComponent();
            
            _myAccessToken = acctkn;
            _myVendor = vendor;

            this.Text = "Update Vendor: " + vendor.Name;
            btMorph.Text = "Update Vendor";

            PopulateStateCombo();
            PopulateCountryCombo();

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
            Instance = this;
        }//update window end

        // viewOnly mode
        public FrmVendorAddUpdate(AccessToken acctkn, Vendor vendor, Boolean viewOnly)
        {
            InitializeComponent();

            _myAccessToken = acctkn;
            _myVendor = vendor;

            this.Text = "Vendor: " + vendor.Name;
            btMorph.Text = "Done";

            PopulateStateCombo();
            PopulateCountryCombo();

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

            txtVendorID.Enabled = false;
            txtVendorName.Enabled = false;
            txtVendorAddress.Enabled = false;
            txtVendorCity.Enabled = false;
            cbVendorState.Enabled = false;
            cbVendorCountry.Enabled = false;
            txtVendorZipCode.Enabled = false;

            txtVendorContact.Enabled = false;
            txtVendorContactEmail.Enabled = false;
            txtVendorContactPhone.Enabled = false;

            btnEditVendor.Visible = true;

            Instance = this;
        }//update window end

        private void btnEditVendor_Click(object sender, EventArgs e)
        {
            txtVendorID.Enabled = false;
            txtVendorName.Enabled = true;
            txtVendorAddress.Enabled = true;
            txtVendorCity.Enabled = true;
            cbVendorState.Enabled = true;
            cbVendorCountry.Enabled = true;
            txtVendorZipCode.Enabled = true;

            txtVendorContact.Enabled = true;
            txtVendorContactEmail.Enabled = true;
            txtVendorContactPhone.Enabled = true;

            this.Text = "Update Vendor: " + _myVendor.Name;
            btMorph.Text = "Update Vendor";
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }//close event

        private void btMorph_Click(object sender, EventArgs e)
        {
            if (btMorph.Text == "Add Vendor")
            {
                addVendor();
            }
            else if (btMorph.Text == "Update Vendor")
            {
                updateVendor();
            }
            else 
            {
                this.Close();
            }
        }//morph button event




        private void addVendor()
        {
            if (inputIsValid())
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

                    MessageBox.Show("Vendor "+ _myVendor.Name +"  was added.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An exception was thrown while adding vendor\n" + ex.ToString());
                }
            }

        } // end addVendor()


        private void updateVendor()
        {
            if (inputIsValid())
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

                    _myVendorManager.UpdateVendor(_myUpdatedVendor, _myVendor);

                    MessageBox.Show("Vendor " + _myUpdatedVendor.Name + "  was updated.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An exception was thrown while editing vendor\n" + ex.ToString());
                }
            }
        } // end updateVendor()


        private Boolean inputIsValid()
        {
            string errText = "";

            if (Validation.IsBlank(this.txtVendorName.Text) ||
                Validation.IsNullOrEmpty(this.txtVendorName.Text))
            {
                MessageBox.Show("Vendor Name should be provided.");
                this.txtVendorName.Focus();
                this.txtVendorName.Clear();
                return false;
            }
            if (Validation.IsBlank(this.txtVendorAddress.Text) ||
                Validation.IsNullOrEmpty(this.txtVendorAddress.Text))
            {
                MessageBox.Show("Vendor Address should be provided.");
                this.txtVendorAddress.Focus();
                this.txtVendorAddress.Clear();
                return false;
            }
            if (Validation.IsBlank(this.txtVendorCity.Text) ||
                Validation.IsNullOrEmpty(this.txtVendorCity.Text))
            {
                MessageBox.Show("Vendor City should be provided.");
                this.txtVendorCity.Focus();
                this.txtVendorCity.Clear();
                return false;
            }
            if (cbVendorState.SelectedIndex < 0)
            {
                MessageBox.Show("A Vendor State should be selected");
                this.cbVendorState.Focus();
                return false;
            }
            if (cbVendorCountry.SelectedIndex < 0)
            { 
                MessageBox.Show("A Vendor Country should be selected");
                this.cbVendorCountry.Focus();
                return false;
            }
            if (Validation.IsBlank(this.txtVendorZipCode.Text) ||
                Validation.IsNullOrEmpty(this.txtVendorZipCode.Text))
            {
                MessageBox.Show("Vendor Zip Code should be provided.");
                this.txtVendorZipCode.Focus();
                this.txtVendorZipCode.Clear();
                return false;
            }

            errText = this.txtVendorZipCode.Text;
            if (!Validation.IsInt(this.txtVendorZipCode.Text))
            {
                MessageBox.Show("'" + errText + "'" + " is not a valid Zip Code. " +
                    "\nVendor Zip Code must be a numeric value.");
                this.txtVendorZipCode.Focus();
                this.txtVendorZipCode.Clear();
                return false;
            }

            if (!Validation.ValidateZip(this.txtVendorZipCode.Text, this.cbVendorState.Text))
            {
                MessageBox.Show("'" + errText + "'" + " is not a valid Zip Code " +
                    "for the state " + this.cbVendorState.Text);
                this.txtVendorZipCode.Focus();
                this.txtVendorZipCode.Clear();
                return false;
            }

            if ((!Validation.IsBlank(txtVendorContactEmail.Text)) && (!Validation.IsNullOrEmpty(txtVendorContactEmail.Text)))
            {
                if (!Validation.IsEmail(txtVendorContactEmail.Text))
                {
                    MessageBox.Show("The email address " + txtVendorContactEmail.Text + " is not valid." +
                        "\nA Vendor Email address is not required, but must be valid.");
                    this.txtVendorContactEmail.Focus();
                    return false;
                }
                if (Validation.IsBlank(this.txtVendorContact.Text) ||
                    Validation.IsNullOrEmpty(this.txtVendorContact.Text))
                {
                    MessageBox.Show("Because you supplied the email " + txtVendorContactEmail.Text + 
                        ", you should add a Vendor contact name." +
                        "\nNeither a Vendor Name, nor Email is required.");
                    this.txtVendorContact.Focus();
                    this.txtVendorContact.Clear();
                    return false;
                }
            }

            if ((!Validation.IsBlank(txtVendorContactPhone.Text)) && (!Validation.IsNullOrEmpty(txtVendorContactPhone.Text)))
            {
                if (!Validation.IsPhone(txtVendorContactPhone.Text))
                {
                    MessageBox.Show("The phone number " + txtVendorContactPhone.Text + " is not valid." +
                        "\nA Vendor Phone number is not required, but must be valid.");
                    this.txtVendorContactPhone.Focus();
                    return false;
                }
                if (txtVendorContactPhone.Text.Length > 12 && txtVendorContactPhone.Text.Contains("("))
                {
                    MessageBox.Show("The phone number " + txtVendorContactPhone.Text + " is not valid." +
                        "\nPlease do not include parentheses: (  )  " +
                        "\nA Vendor Phone number is not required, but must be valid.");

                    this.txtVendorContactPhone.Focus();
                    return false;
                }
                if (Validation.IsBlank(this.txtVendorContact.Text) ||
                    Validation.IsNullOrEmpty(this.txtVendorContact.Text))
                {
                    MessageBox.Show("Because you supplied the phone number " + txtVendorContactPhone.Text +
                        ", you should add a Vendor contact name." +
                        "\nNeither a Vendor Name, nor Phone Number is required.");
                    this.txtVendorContact.Focus();
                    this.txtVendorContact.Clear();
                    return false;
                }
            }

            return true;
        } // end inputIsValid()


        private void PopulateStateCombo()
        {
            var appVariables = ApplicationVariables.Instance;
            cbVendorState.DisplayMember = "Value";
            cbVendorState.ValueMember = "Key";

            for (int i = 1; i <= appVariables.States.Count; i++)
            {
                cbVendorState.Items.Add(appVariables.States[i].StateCode);
            }

        }//End of PopulateStateCombo()

        private void PopulateCountryCombo()
        {
            cbVendorCountry.Items.Add("United States");
            cbVendorCountry.Items.Add("Canada");
            cbVendorCountry.Items.Add("China");
            cbVendorCountry.Items.Add("Japan");

        }//End of PopulateCountryCombo()

        private void FrmVendorAddUpdate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }

       


    } // end FrmVendorAddUpdate
}
