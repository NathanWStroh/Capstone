using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;


namespace com.Farouche.Presentation
{
    public partial class frmVendorCreateOrder : Form
    {
        private readonly AccessToken _myAccessToken;

        public frmVendorCreateOrder(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;

            tbOrderDate.Text = DateTime.Now.Date.ToString("dd.MM.yyyy");
        }


    }
}
