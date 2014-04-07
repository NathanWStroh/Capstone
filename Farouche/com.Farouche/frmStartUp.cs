//Author: Nathan Stroh
//Date Created: 3/30/2014
//Last Modified:  
//Last Modified By:

/*
*                               Changelog
* Date         By           Ticket          Version         Description
* 4-4-14       NathanStroh                  ???             Removed title from frame.
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

        public frmStartUp( AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
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

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendorCreateOrder frm = new frmVendorCreateOrder(_myAccessToken);
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


    }
}
