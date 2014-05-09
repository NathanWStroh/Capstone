//Author: Steven Schuette
//Date Created: 1/31/2014
//Last Modified: 1/31/2014
//Last Modified By: Steven Schuette

using System;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
namespace com.Farouche.Presentation
{
    public partial class FrmLogin : Form
    {
        public FrmLogin(AccessToken _myAccessToken)
        {
            var RoleAccess = new RoleAccess(_myAccessToken, this);
            InitializeComponent();
            //added for faster access
            txtUserID.Text = "1";
            txtPassword.Text = "1111";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

           AccessToken myAccessToken = default(AccessToken);

           frmStartUp myForm = default(frmStartUp);
            try
            {

                myAccessToken = Authenticator.Authenticate(int.Parse(txtUserID.Text), txtPassword.Text);

                myForm = new frmStartUp(myAccessToken);
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
