//Author: Steven Schuette
//Date Created: 1/31/2014
//Last Modified: 1/31/2014
//Last Modified By: Steven Schuette
using System;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commmons;

namespace com.Farouche.Presentation
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            AccessToken myAccessToken = default(AccessToken);

           FrmVendor myForm = default(FrmVendor);
            try
            {

                myAccessToken = Authenticator.authenticate(int.Parse(txtUserID.Text), txtPassword.Text);

                myForm = new FrmVendor(myAccessToken);
                myForm.Show();
                Hide();

            }
            catch (Exception)
            {
                MessageBox.Show("Please contact your administrator or try again.", "Error!");
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
    }
}
