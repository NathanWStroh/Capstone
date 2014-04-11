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

        public frmPrintOrderDetails(int myOrderId)
        {
            InitializeComponent();
            _myOrderId = myOrderId;
        }

        private void frmPrintOrderDetails_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            ReportList ReportList = new ReportList();
            this.CLSLineItemBindingSource.DataSource = ReportList.FetchCLSLineItems(_myOrderId);
            this.reportViewer1.RefreshReport();
        }
    }
}
