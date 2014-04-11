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

        public frmPrintPackReport(ShippingOrder order)
        {
            InitializeComponent();
            _currentOrder = order;
        }

        private void frmPrintPackReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            ReportList reportList = new ReportList();
            List<CLSPackDetails> details;
            details = reportList.FetchPackingDetails(_currentOrder);
            MessageBox.Show(details[0].ToString());
            this.CLSPackDetailsBindingSource.DataSource = reportList.FetchPackingDetails(_currentOrder);
            this.reportViewer1.RefreshReport();
        }
    }
}
