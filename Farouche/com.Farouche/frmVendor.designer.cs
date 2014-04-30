namespace com.Farouche.Presentation
{
    partial class FrmVendor
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
            this.btnDeactivateVendor = new System.Windows.Forms.Button();
            this.btnActivateVendor = new System.Windows.Forms.Button();
            this.cbVendorStatusSearch = new System.Windows.Forms.ComboBox();
            this.lblVendorActiveSearch = new System.Windows.Forms.Label();
            this.btnGetVendorByID = new System.Windows.Forms.Button();
            this.btnUpdateVendor = new System.Windows.Forms.Button();
            this.txtVendorIDSearch = new System.Windows.Forms.TextBox();
            this.lblVendorIDSearch = new System.Windows.Forms.Label();
            this.btnAddVendor = new System.Windows.Forms.Button();
            this.lvVendors = new System.Windows.Forms.ListView();
            this.btnVendorReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeactivateVendor
            // 
            this.btnDeactivateVendor.Enabled = false;
            this.btnDeactivateVendor.Location = new System.Drawing.Point(12, 141);
            this.btnDeactivateVendor.Name = "btnDeactivateVendor";
            this.btnDeactivateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnDeactivateVendor.TabIndex = 4;
            this.btnDeactivateVendor.Text = "Deactivate";
            this.btnDeactivateVendor.UseVisualStyleBackColor = true;
            this.btnDeactivateVendor.Click += new System.EventHandler(this.btnDeactivateProduct_Click);
            // 
            // btnActivateVendor
            // 
            this.btnActivateVendor.Enabled = false;
            this.btnActivateVendor.Location = new System.Drawing.Point(12, 110);
            this.btnActivateVendor.Name = "btnActivateVendor";
            this.btnActivateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnActivateVendor.TabIndex = 3;
            this.btnActivateVendor.Text = "Activate";
            this.btnActivateVendor.UseVisualStyleBackColor = true;
            this.btnActivateVendor.Click += new System.EventHandler(this.btnActivateProduct_Click);
            // 
            // cbVendorStatusSearch
            // 
            this.cbVendorStatusSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVendorStatusSearch.FormattingEnabled = true;
            this.cbVendorStatusSearch.Location = new System.Drawing.Point(640, 14);
            this.cbVendorStatusSearch.Name = "cbVendorStatusSearch";
            this.cbVendorStatusSearch.Size = new System.Drawing.Size(121, 21);
            this.cbVendorStatusSearch.TabIndex = 5;
            this.cbVendorStatusSearch.SelectedIndexChanged += new System.EventHandler(this.cbVendortStatusSearch_SelectedIndexChanged);
            // 
            // lblVendorActiveSearch
            // 
            this.lblVendorActiveSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVendorActiveSearch.AutoSize = true;
            this.lblVendorActiveSearch.Location = new System.Drawing.Point(594, 18);
            this.lblVendorActiveSearch.Name = "lblVendorActiveSearch";
            this.lblVendorActiveSearch.Size = new System.Drawing.Size(40, 13);
            this.lblVendorActiveSearch.TabIndex = 41;
            this.lblVendorActiveSearch.Text = "Active:";
            // 
            // btnGetVendorByID
            // 
            this.btnGetVendorByID.Location = new System.Drawing.Point(286, 8);
            this.btnGetVendorByID.Name = "btnGetVendorByID";
            this.btnGetVendorByID.Size = new System.Drawing.Size(42, 25);
            this.btnGetVendorByID.TabIndex = 40;
            this.btnGetVendorByID.Text = "Find";
            this.btnGetVendorByID.UseVisualStyleBackColor = true;
            this.btnGetVendorByID.Click += new System.EventHandler(this.btnGetVendorByID_Click);
            // 
            // btnUpdateVendor
            // 
            this.btnUpdateVendor.Enabled = false;
            this.btnUpdateVendor.Location = new System.Drawing.Point(12, 79);
            this.btnUpdateVendor.Name = "btnUpdateVendor";
            this.btnUpdateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnUpdateVendor.TabIndex = 2;
            this.btnUpdateVendor.Text = "Update Vendor";
            this.btnUpdateVendor.UseVisualStyleBackColor = true;
            this.btnUpdateVendor.Click += new System.EventHandler(this.btnUpdateVendor_Click);
            // 
            // txtVendorIDSearch
            // 
            this.txtVendorIDSearch.Location = new System.Drawing.Point(180, 11);
            this.txtVendorIDSearch.Name = "txtVendorIDSearch";
            this.txtVendorIDSearch.Size = new System.Drawing.Size(100, 20);
            this.txtVendorIDSearch.TabIndex = 0;
            // 
            // lblVendorIDSearch
            // 
            this.lblVendorIDSearch.AutoSize = true;
            this.lblVendorIDSearch.Location = new System.Drawing.Point(115, 14);
            this.lblVendorIDSearch.Name = "lblVendorIDSearch";
            this.lblVendorIDSearch.Size = new System.Drawing.Size(61, 13);
            this.lblVendorIDSearch.TabIndex = 37;
            this.lblVendorIDSearch.Text = "Vendor ID: ";
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.Location = new System.Drawing.Point(12, 48);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(100, 25);
            this.btnAddVendor.TabIndex = 1;
            this.btnAddVendor.Text = "Add Vendor";
            this.btnAddVendor.UseVisualStyleBackColor = true;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // lvVendors
            // 
            this.lvVendors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvVendors.FullRowSelect = true;
            this.lvVendors.GridLines = true;
            this.lvVendors.Location = new System.Drawing.Point(118, 48);
            this.lvVendors.Name = "lvVendors";
            this.lvVendors.Size = new System.Drawing.Size(643, 256);
            this.lvVendors.TabIndex = 45;
            this.lvVendors.UseCompatibleStateImageBehavior = false;
            this.lvVendors.View = System.Windows.Forms.View.Details;
            this.lvVendors.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvVendors_ColumnClick);
            this.lvVendors.SelectedIndexChanged += new System.EventHandler(this.lvVendors_SelectedIndexChanged);
            this.lvVendors.Click += new System.EventHandler(this.lvVendors_Click);
            this.lvVendors.DoubleClick += new System.EventHandler(this.lvVendors_DoubleClick);
            // 
            // btnVendorReport
            // 
            this.btnVendorReport.Location = new System.Drawing.Point(12, 279);
            this.btnVendorReport.Name = "btnVendorReport";
            this.btnVendorReport.Size = new System.Drawing.Size(100, 25);
            this.btnVendorReport.TabIndex = 46;
            this.btnVendorReport.Text = "Vendor Report";
            this.btnVendorReport.UseVisualStyleBackColor = true;
            this.btnVendorReport.Click += new System.EventHandler(this.btnVendorReport_Click);
            // 
            // FrmVendor
            // 
            this.AcceptButton = this.btnGetVendorByID;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 319);
            this.Controls.Add(this.btnVendorReport);
            this.Controls.Add(this.lvVendors);
            this.Controls.Add(this.btnDeactivateVendor);
            this.Controls.Add(this.btnActivateVendor);
            this.Controls.Add(this.cbVendorStatusSearch);
            this.Controls.Add(this.lblVendorActiveSearch);
            this.Controls.Add(this.btnGetVendorByID);
            this.Controls.Add(this.btnUpdateVendor);
            this.Controls.Add(this.txtVendorIDSearch);
            this.Controls.Add(this.lblVendorIDSearch);
            this.Controls.Add(this.btnAddVendor);
            this.Name = "FrmVendor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVendor_FormClosed);
            this.Load += new System.EventHandler(this.FrmVendor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeactivateVendor;
        private System.Windows.Forms.Button btnActivateVendor;
        private System.Windows.Forms.ComboBox cbVendorStatusSearch;
        private System.Windows.Forms.Label lblVendorActiveSearch;
        private System.Windows.Forms.Button btnGetVendorByID;
        private System.Windows.Forms.Button btnUpdateVendor;
        private System.Windows.Forms.TextBox txtVendorIDSearch;
        private System.Windows.Forms.Label lblVendorIDSearch;
        private System.Windows.Forms.Button btnAddVendor;
        private System.Windows.Forms.ListView lvVendors;
        private System.Windows.Forms.Button btnVendorReport;

    }
}

