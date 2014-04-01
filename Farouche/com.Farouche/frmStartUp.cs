//Author: Nathan Stroh
//Date Created: 3/30/2014
//Last Modified:  
//Last Modified By:

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


    }
}
