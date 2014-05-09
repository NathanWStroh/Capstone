namespace com.Farouche
{
    partial class frmVendorProductReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CLSVendorProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CLSEmployeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.CLSVendorProductBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLSEmployeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.CLSVendorProductBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "com.Farouche.Reports.VendorProductReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(17, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(816, 582);
            this.reportViewer1.TabIndex = 0;
            // 
            // CLSVendorProductBindingSource
            // 
            this.CLSVendorProductBindingSource.DataSource = typeof(com.Farouche.Commons.CLSVendorProduct);
            // 
            // CLSEmployeeBindingSource
            // 
            this.CLSEmployeeBindingSource.DataSource = typeof(com.Farouche.Commons.CLSEmployee);
            // 
            // frmVendorProductReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 606);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmVendorProductReport";
            this.Text = "Vendor Product Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVendorProductReport_FormClosed);
            this.Load += new System.EventHandler(this.frmVendorProductReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CLSVendorProductBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CLSEmployeeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CLSVendorProductBindingSource;
        private System.Windows.Forms.BindingSource CLSEmployeeBindingSource;
    }
}