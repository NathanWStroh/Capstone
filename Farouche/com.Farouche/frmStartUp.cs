//Author: Nathan Stroh
//Date Created: 3/30/2014
//Last Modified:  4/16/14
//Last Modified By: Ben Grimes

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 4/16/14   Ben Grimes                                      Added Shipping Vendors and Terms into Startup
* 
* 04/19/2014   Kaleb Wendel                                 Adjusted the class to check to see if the form in question was instantiated before.  If the form has an instance already it will bring the form to the front. If there is no instance it will instantiate the form.
*
*5-2-14         NWS         n/a             n/a             Fixed issue on line 206. Code was checking for FrmVendor == null when it should have stated frmVendorCreateOrder == null. Caused errors when loading frmVendorCreateOrder when FrmVendor was open.
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
        public frmReceiving frmReceiving;

        public frmStartUp(AccessToken acctoken)
        {
            InitializeComponent();
            _myAccessToken = acctoken;
            this.Text = "                         " + _myAccessToken.FirstName + " " + _myAccessToken.LastName + " logged in as a " + _myAccessToken.Title;
            this.WindowState = FormWindowState.Maximized;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            frm.Visible = true;
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduct frmProduct;
            if(FrmProduct.Instance == null)
            {
                frmProduct = new FrmProduct(_myAccessToken);
                frmProduct.MdiParent = this;
                frmProduct.StartPosition = FormStartPosition.CenterScreen;
                frmProduct.Show();
            }
            else
            {
                FrmProduct.Instance.WindowState = FormWindowState.Normal;
                FrmProduct.Instance.Show();
                FrmProduct.Instance.BringToFront();       
            }
        }

        //TSMI = Tool Strip Menu Item
        private void tsmiMyOrders_Click(object sender, EventArgs e)
        {
            FrmShippingMyOrders frmShippingMyOrders;
            if (FrmShippingMyOrders.Instance == null)
            {
                frmShippingMyOrders = new FrmShippingMyOrders(_myAccessToken);
                frmShippingMyOrders.MdiParent = this;
                frmShippingMyOrders.StartPosition = FormStartPosition.CenterScreen;
                frmShippingMyOrders.Show();
            }
            else
            {
                FrmShippingMyOrders.Instance.WindowState = FormWindowState.Normal;
                FrmShippingMyOrders.Instance.Show();
                FrmShippingMyOrders.Instance.BringToFront();
            }
        }

        private void tsmiAllShippingOrders_Click(object sender, EventArgs e)
        {
            FrmShippingAllOrders frmAllShippingOrders;
            if (FrmShippingAllOrders.Instance == null)
            {
                frmAllShippingOrders = new FrmShippingAllOrders(_myAccessToken);
                frmAllShippingOrders.MdiParent = this;
                frmAllShippingOrders.StartPosition = FormStartPosition.CenterScreen;
                frmAllShippingOrders.Show();
            }
            else
            {
                FrmShippingAllOrders.Instance.WindowState = FormWindowState.Normal;
                FrmShippingAllOrders.Instance.Show();
                FrmShippingAllOrders.Instance.BringToFront();
            }
        }

        private void tsmiPickList_Click(object sender, EventArgs e)
        {
            FrmShippingPickList frmShippingPickList;
            if (FrmShippingPickList.Instance == null)
            {
                frmShippingPickList = new FrmShippingPickList(_myAccessToken);
                frmShippingPickList.MdiParent = this;
                frmShippingPickList.StartPosition = FormStartPosition.CenterScreen;
                frmShippingPickList.Show();
            }
            else
            {
                FrmShippingPickList.Instance.WindowState = FormWindowState.Normal;
                FrmShippingPickList.Instance.Show();
                FrmShippingPickList.Instance.BringToFront();
            }
        }

        private void tsmiPackList_Click(object sender, EventArgs e)
        {
            FrmShippingPackList frmShippingPackList;
            if (FrmShippingPackList.Instance == null)
            {
                frmShippingPackList = new FrmShippingPackList(_myAccessToken);
                frmShippingPackList.MdiParent = this;
                frmShippingPackList.StartPosition = FormStartPosition.CenterScreen;
                frmShippingPackList.Show();
            }
            else
            {
                FrmShippingPackList.Instance.WindowState = FormWindowState.Normal;
                FrmShippingPackList.Instance.Show();
                FrmShippingPackList.Instance.BringToFront();
            }
        }

        private void tsmiShippingVendors_Click(object sender, EventArgs e)
        {
            FrmShippingVendor frmShippingVendor;
            if (FrmShippingVendor.Instance == null)
            {
                frmShippingVendor = new FrmShippingVendor(_myAccessToken);
                frmShippingVendor.MdiParent = this;
                frmShippingVendor.StartPosition = FormStartPosition.CenterScreen;
                frmShippingVendor.Show();
            }
            else
            {
                FrmShippingVendor.Instance.WindowState = FormWindowState.Normal;
                FrmShippingVendor.Instance.Show();
                FrmShippingVendor.Instance.BringToFront();
            }
        }

        private void tsmiShippingTerms_Click(object sender, EventArgs e)
        {
            FrmShippingTerm frmShippingTerm;
            if (FrmShippingTerm.Instance == null)
            {
                frmShippingTerm = new FrmShippingTerm(_myAccessToken);
                frmShippingTerm.MdiParent = this;
                frmShippingTerm.StartPosition = FormStartPosition.CenterScreen;
                frmShippingTerm.Show();
            }
            else
            {
                FrmShippingTerm.Instance.WindowState = FormWindowState.Normal;
                FrmShippingTerm.Instance.Show();
                FrmShippingTerm.Instance.BringToFront();
            }
        }

        private void vendorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVendor frmVendor;
            if (FrmVendor.Instance == null)
            {
                frmVendor = new FrmVendor(_myAccessToken);
                frmVendor.MdiParent = this;
                frmVendor.StartPosition = FormStartPosition.CenterScreen;
                frmVendor.Show();
            }
            else
            {
                FrmVendor.Instance.WindowState = FormWindowState.Normal;
                FrmVendor.Instance.Show();
                FrmVendor.Instance.BringToFront();
            }
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVendorCreateOrder frmVendorCreateOrder;
            if (frmVendorCreateOrder.Instance == null)
            {
                frmVendorCreateOrder = new frmVendorCreateOrder(_myAccessToken);
                frmVendorCreateOrder.MdiParent = this;
                frmVendorCreateOrder.StartPosition = FormStartPosition.CenterScreen;
                frmVendorCreateOrder.Show();
            }
            else
            {
                frmVendorCreateOrder.Instance.WindowState = FormWindowState.Normal;
                frmVendorCreateOrder.Instance.Show();
                frmVendorCreateOrder.Instance.BringToFront();
            }
        }

        private void viewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOpenVendorOrders frmOpenVendorOrders;
            if (frmOpenVendorOrders.Instance == null)
            {
                frmOpenVendorOrders = new frmOpenVendorOrders(_myAccessToken);
                frmOpenVendorOrders.MdiParent = this;
                frmOpenVendorOrders.StartPosition = FormStartPosition.CenterScreen;
                frmOpenVendorOrders.Show();
            }
            else
            {
                frmOpenVendorOrders.Instance.WindowState = FormWindowState.Normal;
                frmOpenVendorOrders.Instance.Show();
                frmOpenVendorOrders.Instance.BringToFront();
            }
        }

        private void receivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReceiving frmReceiving;
            if (frmReceiving.Instance == null)
            {
                frmReceiving = new frmReceiving(_myAccessToken);
                frmReceiving.MdiParent = this;
                frmReceiving.StartPosition = FormStartPosition.CenterScreen;
                frmReceiving.Show();
            }
            else
            {
                frmReceiving.Instance.WindowState = FormWindowState.Normal;
                frmReceiving.Instance.Show();
                frmReceiving.Instance.BringToFront();
            }
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reorderProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReorder frmReorder;
            if (frmReorder.Instance == null)
            {
                frmReorder = new frmReorder(_myAccessToken);
                frmReorder.MdiParent = this;
                frmReorder.StartPosition = FormStartPosition.CenterScreen;
                frmReorder.Show();
            }
            else
            {
                frmReorder.Instance.WindowState = FormWindowState.Normal;
                frmReorder.Instance.Show();
                frmReorder.Instance.BringToFront();
            }
        }

        private void frmStartUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }//End of frmStartUp_FormClosed(..)

        private void toolStripButtonCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void toolStripButtonTileVertically_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
