//Author: Nathan Stroh
//Date Created: 3/30/2014
//Last Modified:  4/16/14
//Last Modified By: Ben Grimes

/*
*                               Changelog
<<<<<<< HEAD
* Date         By          Ticket          Version         Description
* 4/16/14   Ben Grimes                                      Added Shipping Vendors and Terms into Startup
=======
* Date         By           Ticket          Version         Description
* 4-4-14       NathanStroh                  ???             Removed title from frame.
>>>>>>> origin
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

namespace com.Farouche.Presentation
{
    public partial class frmStartUp : Form
    {
        private readonly AccessToken _myAccessToken;

        public FrmShippingAllOrders AllShippingOrders;
        public FrmShippingMyOrders ShippingMyOrders;
        public FrmShippingPickList ShippingPickList;
        public FrmShippingPackList ShippingPackList;
        public FrmShippingTerm ShippingTerm;
        public FrmShippingVendor ShippingVendor;

        public frmStartUp(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            this.Text = "                         " + _myAccessToken.FirstName + " " + _myAccessToken.LastName + " logged in as a " + _myAccessToken.Title;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Visible = true;
            Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct(_myAccessToken);
            frm.MdiParent = this;
            this.Text = frm.Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductView frm = new ProductView(_myAccessToken);
            frm.ShowDialog();
        }
        
        //TSMI = Tool Strip Menu Item
        private void tsmiMyOrders_Click(object sender, EventArgs e)
        {
            ShippingMyOrders = new FrmShippingMyOrders(_myAccessToken);
            ShippingMyOrders.MdiParent = this;
            ShippingMyOrders.WindowState = FormWindowState.Maximized;
            ShippingMyOrders.Show();
        }

        private void tsmiAllShippingOrders_Click(object sender, EventArgs e)
        {
            AllShippingOrders = new FrmShippingAllOrders(_myAccessToken);
            AllShippingOrders.MdiParent = this;
            AllShippingOrders.WindowState = FormWindowState.Maximized;
            AllShippingOrders.Show();
        }

        private void tsmiPickList_Click(object sender, EventArgs e)
        {
            ShippingPickList = new FrmShippingPickList(_myAccessToken);
            ShippingPickList.MdiParent = this;
            ShippingPickList.WindowState = FormWindowState.Maximized;
            ShippingPickList.Show();
        }

        private void tsmiPackList_Click(object sender, EventArgs e)
        {
            ShippingPackList = new FrmShippingPackList(_myAccessToken);
            ShippingPackList.MdiParent = this;
            ShippingPackList.WindowState = FormWindowState.Maximized;
            ShippingPackList.Show();
        }

        private void tsmiShippingVendors_Click(object sender, EventArgs e)
        {
            ShippingVendor = new FrmShippingVendor(_myAccessToken);
            ShippingVendor.MdiParent = this;
            ShippingVendor.WindowState = FormWindowState.Maximized;
            ShippingVendor.Show();
        }

        private void tsmiShippingTerms_Click(object sender, EventArgs e)
        {
            ShippingTerm = new FrmShippingTerm(_myAccessToken);
            ShippingTerm.MdiParent = this;
            ShippingTerm.WindowState = FormWindowState.Maximized;
            ShippingTerm.Show();
        }

        private void vendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVendor frm = new FrmVendor(_myAccessToken);
            frm.MdiParent = this;
            this.Text = frm.Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendorCreateOrder frm = new frmVendorCreateOrder(_myAccessToken);
            frm.MdiParent = this;
            this.Text = frm.Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void viewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //no accesstoken used
            frmOpenVendorOrders frm = new frmOpenVendorOrders();
            frm.MdiParent = this;
            this.Text = frm.Text;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
