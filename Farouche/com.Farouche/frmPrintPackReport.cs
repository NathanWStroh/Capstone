using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

namespace com.Farouche
{
    public partial class frmPrintPackReport : Form
    {
        private ShippingOrder _currentOrder;
        public static frmPrintPackReport Instance;

        public frmPrintPackReport(ShippingOrder order, AccessToken _myAccessToken)
        {
            InitializeComponent();
            var RoleAccess = new RoleAccess(_myAccessToken, this);
            
            _currentOrder = order;
            Instance = this;
        }//frmPrintPackReport(.)

        private void frmPrintPackReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            ReportList reportList = new ReportList();
            this.CLSPackDetailsBindingSource.DataSource = reportList.FetchPackingDetails(_currentOrder);
            this.reportViewer1.RefreshReport();
        }//frmPrintPackReport_Load(..)

        private void frmPrintPackReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }//frmPrintPackReport_FormClosed(..)
    }
}
