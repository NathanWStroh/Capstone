//Author: Nathan Stroh
//Date Created: 3/30/2014
//Last Modified:  4/4/14
//Last Modified By: Ben Grimes

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 
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
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
 
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
    }
}
