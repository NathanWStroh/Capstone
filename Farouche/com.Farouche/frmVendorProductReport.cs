﻿using System;
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
    public partial class frmVendorProductReport : Form
    {
        public static frmVendorProductReport Instance;

        public frmVendorProductReport(AccessToken _myAccessToken)
        {
            InitializeComponent();
            Instance = this;
            var RoleAccess = new RoleAccess(_myAccessToken, this);
        }//frmVendorProductReport()

        private void frmVendorProductReport_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            ReportList reportList = new ReportList();
            this.CLSVendorProductBindingSource.DataSource = reportList.GetVendorProducts();
            this.reportViewer1.RefreshReport();
        }//frmVendorProductReport_Load(..)

        private void frmVendorProductReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }//frmVendorProductReport_FormClosed(..)
    }
}
