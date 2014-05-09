using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.Commons;
using com.Farouche.BusinessLogic;

namespace com.Farouche
{
    public partial class frmPrintOrderDetails : Form
    {
        private int _myOrderId;
        public static frmPrintOrderDetails Instance;

        public frmPrintOrderDetails(int myOrderId, AccessToken _myAccessToken)
        {
            var RoleAccess = new RoleAccess(_myAccessToken, this);
            InitializeComponent();
            _myOrderId = myOrderId;
            Instance = this;
        }//frmPrintOrderDetails(.)

        private void frmPrintOrderDetails_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            ReportList ReportList = new ReportList();
            this.CLSLineItemBindingSource.DataSource = ReportList.FetchCLSLineItems(_myOrderId);
            this.reportViewer1.RefreshReport();
        }//frmPrintOrderDetails_Load(..)

        private void frmPrintOrderDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }//frmPrintOrderDetails_FormClosed(..)
    }
}
