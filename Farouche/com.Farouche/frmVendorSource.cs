using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
//Author: Adam
//Date Created: 1/31/2014
//Last Modified: 02/07/2014
//Last Modified By: Adam Chandler

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/07/2014   Adam                          0.0.1b       Updated code to work with all the new changes
*/
namespace com.Farouche.Presentation
{
    public partial class FrmVendorSource : Form
    {
        private readonly AccessToken _myAccessToken;
        public FrmVendorSource(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            var RoleAccess = new RoleAccess(acctoken, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var vsiManager = new VendorSourceItemManager();
            var vsrcItem = new VendorSourceItem
            {
                ProductID = (int) productCb.SelectedValue,
                VendorID = (int) vendorCb.SelectedValue,
                MinQtyToOrder = (int) minQty.Value,
                UnitCost = Convert.ToDecimal(unitCost.Text),
                Active = true
            };
            vsiManager.AddVendorSourceItem(vsrcItem);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += "                         " + _myAccessToken.FirstName + " " + _myAccessToken.LastName + " logged in as a " + _myAccessToken.Role.Name;

             var vsiManager = new VendorSourceItemManager();
             fillListView(vnd,vsiManager.GetAllVendorSourceItems());
             var venManager = new VendorManager();
             fillVendorDropDown(vendorCb, venManager.GetVendors());

             var prodManager = new ProductManager();
             fillProductDropDown(productCb, prodManager.GetProducts());
        }
        private void fillListView(ListView lv, List<VendorSourceItem> lista)
        {
           lv.Items.Clear();
           lv.View = View.Details;
           lv.GridLines = true;
           foreach (var vsr in lista)
	       {
               var item = new ListViewItem {Text = vsr.ProductID.ToString()};
	          // item.SubItems.Add(vsr.Name);
               item.SubItems.Add(vsr.VendorID.ToString());
               item.SubItems.Add(vsr.MinQtyToOrder.ToString());
               item.SubItems.Add(vsr.UnitCost.ToString());
               lv.Items.Add(item);
	       }
           lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void fillVendorDropDown(ComboBox cb, List<Vendor> listOfVendors)
        {
            var v = new Vendor(0) {Name = ""};
            cb.DataSource = listOfVendors;
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
        }
        private void fillProductDropDown(ComboBox cb, List<Product> listOfProducts)
        {
            var p = new Product(0) {Name = ""};
            cb.DataSource = listOfProducts;
            cb.DisplayMember = "Name";
            cb.ValueMember = "ID";
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            var myform = new FrmProduct(_myAccessToken);
            myform.Show();
            Close();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            var form = new FrmVendor(_myAccessToken);
            form.Show();
            Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var frm = new FrmLogin();
            frm.Show();
            Close();
        }

        private void btnShipping_Click(object sender, EventArgs e)
        {
            var form = new FrmShipping(_myAccessToken);
            form.Show();
            this.Close();
        }


    }
}
