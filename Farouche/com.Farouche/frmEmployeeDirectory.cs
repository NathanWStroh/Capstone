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
    public partial class frmEmployeeDirectory : Form
    {
        public frmEmployeeDirectory(AccessToken _myAccessToken)
        {
            var RoleAccess = new RoleAccess(_myAccessToken, this);
            InitializeComponent();
        }

        private void frmEmployeeDirectory_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            ReportList reportList = new ReportList();
            this.CLSEmployeeBindingSource.DataSource = reportList.GetEmployeeDirectory();
            this.reportViewer1.RefreshReport();
        }
    }
}
