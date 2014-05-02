namespace com.Farouche
{
    partial class frmPrintPackReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CLSPackDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.CLSPackDetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CLSPackDetailsBindingSource
            // 
            this.CLSPackDetailsBindingSource.DataSource = typeof(com.Farouche.Commons.CLSPackDetails);
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.CLSPackDetailsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "com.Farouche.Reports.PackListReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 21);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(943, 293);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmPrintPackReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 326);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmPrintPackReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Print Pack Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrintPackReport_FormClosed);
            this.Load += new System.EventHandler(this.frmPrintPackReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CLSPackDetailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CLSPackDetailsBindingSource;
    }
}