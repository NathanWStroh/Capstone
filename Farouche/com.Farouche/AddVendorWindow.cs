using System;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

namespace com.Farouche.Presentation
{

    public partial class AddVendorWindow : Form
    {
        readonly VendorManager _vendorManager = new VendorManager();
        public AddVendorWindow(string productId, AccessToken _myAccessToken)
        {
            var RoleAccess = new RoleAccess(_myAccessToken, this);
            var vendors = _vendorManager.GetVendors();
            foreach (var vendor in vendors)
            {
                lvVendors.Items.Add(vendor.ToString());
            }
        }
        public void tbVendorSearch_Change_State(object sender, EventArgs e)
        {
            //will add in formating to search for Vendor as you type
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
