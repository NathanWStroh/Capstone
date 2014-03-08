namespace com.Farouche.Presentation
{
    partial class FrmShipping
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
            this.btnVendor = new System.Windows.Forms.Button();
            this.btnActivateVendor = new System.Windows.Forms.Button();
            this.cbVendorStatusSearch = new System.Windows.Forms.ComboBox();
            this.tabShippingVendors = new System.Windows.Forms.TabPage();
            this.lblProductActiveSearch = new System.Windows.Forms.Label();
            this.btnUpdateVendor = new System.Windows.Forms.Button();
            this.lvShippingVendors = new System.Windows.Forms.ListView();
            this.btnAddVendor = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnVendorSource = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.tabControlShippingVendors = new System.Windows.Forms.TabControl();
            this.tabShippingTerms = new System.Windows.Forms.TabPage();
            this.btnDeactivateTerm = new System.Windows.Forms.Button();
            this.btnActivateTerm = new System.Windows.Forms.Button();
            this.cbTermStatusSearch = new System.Windows.Forms.ComboBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.btnUpdateTerm = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnAddTerm = new System.Windows.Forms.Button();
            this.tabShippingVendors.SuspendLayout();
            this.tabControlShippingVendors.SuspendLayout();
            this.tabShippingTerms.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeactivateVendor
            // 
            this.btnDeactivateVendor.Enabled = false;
            this.btnDeactivateVendor.Location = new System.Drawing.Point(6, 147);
            this.btnDeactivateVendor.Name = "btnDeactivateVendor";
            this.btnDeactivateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnDeactivateVendor.TabIndex = 18;
            this.btnDeactivateVendor.Text = "Deactivate";
            this.btnDeactivateVendor.UseVisualStyleBackColor = true;
            // 
            // btnVendor
            // 
            this.btnVendor.Location = new System.Drawing.Point(12, 392);
            this.btnVendor.Name = "btnVendor";
            this.btnVendor.Size = new System.Drawing.Size(90, 23);
            this.btnVendor.TabIndex = 23;
            this.btnVendor.Text = "Vendor";
            this.btnVendor.UseVisualStyleBackColor = true;
            this.btnVendor.Click += new System.EventHandler(this.btnVendor_Click);
            // 
            // btnActivateVendor
            // 
            this.btnActivateVendor.Enabled = false;
            this.btnActivateVendor.Location = new System.Drawing.Point(6, 116);
            this.btnActivateVendor.Name = "btnActivateVendor";
            this.btnActivateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnActivateVendor.TabIndex = 17;
            this.btnActivateVendor.Text = "Activate";
            this.btnActivateVendor.UseVisualStyleBackColor = true;
            // 
            // cbVendorStatusSearch
            // 
            this.cbVendorStatusSearch.Enabled = false;
            this.cbVendorStatusSearch.FormattingEnabled = true;
            this.cbVendorStatusSearch.Location = new System.Drawing.Point(634, 17);
            this.cbVendorStatusSearch.Name = "cbVendorStatusSearch";
            this.cbVendorStatusSearch.Size = new System.Drawing.Size(121, 21);
            this.cbVendorStatusSearch.TabIndex = 16;
            // 
            // tabShippingVendors
            // 
            this.tabShippingVendors.Controls.Add(this.btnDeactivateVendor);
            this.tabShippingVendors.Controls.Add(this.btnActivateVendor);
            this.tabShippingVendors.Controls.Add(this.cbVendorStatusSearch);
            this.tabShippingVendors.Controls.Add(this.lblProductActiveSearch);
            this.tabShippingVendors.Controls.Add(this.btnUpdateVendor);
            this.tabShippingVendors.Controls.Add(this.lvShippingVendors);
            this.tabShippingVendors.Controls.Add(this.btnAddVendor);
            this.tabShippingVendors.Location = new System.Drawing.Point(4, 22);
            this.tabShippingVendors.Name = "tabShippingVendors";
            this.tabShippingVendors.Padding = new System.Windows.Forms.Padding(3);
            this.tabShippingVendors.Size = new System.Drawing.Size(772, 324);
            this.tabShippingVendors.TabIndex = 0;
            this.tabShippingVendors.Text = "Shipping Vendors";
            this.tabShippingVendors.UseVisualStyleBackColor = true;
            // 
            // lblProductActiveSearch
            // 
            this.lblProductActiveSearch.AutoSize = true;
            this.lblProductActiveSearch.Location = new System.Drawing.Point(588, 20);
            this.lblProductActiveSearch.Name = "lblProductActiveSearch";
            this.lblProductActiveSearch.Size = new System.Drawing.Size(40, 13);
            this.lblProductActiveSearch.TabIndex = 15;
            this.lblProductActiveSearch.Text = "Active:";
            // 
            // btnUpdateVendor
            // 
            this.btnUpdateVendor.Enabled = false;
            this.btnUpdateVendor.Location = new System.Drawing.Point(6, 85);
            this.btnUpdateVendor.Name = "btnUpdateVendor";
            this.btnUpdateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnUpdateVendor.TabIndex = 13;
            this.btnUpdateVendor.Text = "Update Vendor";
            this.btnUpdateVendor.UseVisualStyleBackColor = true;
            this.btnUpdateVendor.Click += new System.EventHandler(this.btnUpdateVendor_Click);
            // 
            // lvShippingVendors
            // 
            this.lvShippingVendors.FullRowSelect = true;
            this.lvShippingVendors.GridLines = true;
            this.lvShippingVendors.Location = new System.Drawing.Point(123, 54);
            this.lvShippingVendors.MultiSelect = false;
            this.lvShippingVendors.Name = "lvShippingVendors";
            this.lvShippingVendors.Size = new System.Drawing.Size(643, 253);
            this.lvShippingVendors.TabIndex = 10;
            this.lvShippingVendors.UseCompatibleStateImageBehavior = false;
            this.lvShippingVendors.View = System.Windows.Forms.View.Details;
            this.lvShippingVendors.Click += new System.EventHandler(this.lvShippingVendors_Click);
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.Location = new System.Drawing.Point(6, 54);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(100, 25);
            this.btnAddVendor.TabIndex = 8;
            this.btnAddVendor.Text = "Add Vendor";
            this.btnAddVendor.UseVisualStyleBackColor = true;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(747, 395);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 27;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnVendorSource
            // 
            this.btnVendorSource.Location = new System.Drawing.Point(204, 392);
            this.btnVendorSource.Name = "btnVendorSource";
            this.btnVendorSource.Size = new System.Drawing.Size(90, 23);
            this.btnVendorSource.TabIndex = 24;
            this.btnVendorSource.Text = "Vendor Source";
            this.btnVendorSource.UseVisualStyleBackColor = true;
            this.btnVendorSource.Click += new System.EventHandler(this.btnVendorSource_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(108, 392);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(90, 23);
            this.btnProduct.TabIndex = 25;
            this.btnProduct.Text = "Product";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // tabControlShippingVendors
            // 
            this.tabControlShippingVendors.Controls.Add(this.tabShippingVendors);
            this.tabControlShippingVendors.Controls.Add(this.tabShippingTerms);
            this.tabControlShippingVendors.Location = new System.Drawing.Point(26, 19);
            this.tabControlShippingVendors.Name = "tabControlShippingVendors";
            this.tabControlShippingVendors.SelectedIndex = 0;
            this.tabControlShippingVendors.Size = new System.Drawing.Size(780, 350);
            this.tabControlShippingVendors.TabIndex = 26;
            // 
            // tabShippingTerms
            // 
            this.tabShippingTerms.Controls.Add(this.btnDeactivateTerm);
            this.tabShippingTerms.Controls.Add(this.btnActivateTerm);
            this.tabShippingTerms.Controls.Add(this.cbTermStatusSearch);
            this.tabShippingTerms.Controls.Add(this.lblActive);
            this.tabShippingTerms.Controls.Add(this.btnUpdateTerm);
            this.tabShippingTerms.Controls.Add(this.listView1);
            this.tabShippingTerms.Controls.Add(this.btnAddTerm);
            this.tabShippingTerms.Location = new System.Drawing.Point(4, 22);
            this.tabShippingTerms.Name = "tabShippingTerms";
            this.tabShippingTerms.Padding = new System.Windows.Forms.Padding(3);
            this.tabShippingTerms.Size = new System.Drawing.Size(772, 324);
            this.tabShippingTerms.TabIndex = 1;
            this.tabShippingTerms.Text = "Shipping Terms";
            this.tabShippingTerms.UseVisualStyleBackColor = true;
            // 
            // btnDeactivateTerm
            // 
            this.btnDeactivateTerm.Enabled = false;
            this.btnDeactivateTerm.Location = new System.Drawing.Point(6, 147);
            this.btnDeactivateTerm.Name = "btnDeactivateTerm";
            this.btnDeactivateTerm.Size = new System.Drawing.Size(100, 25);
            this.btnDeactivateTerm.TabIndex = 25;
            this.btnDeactivateTerm.Text = "Deactivate";
            this.btnDeactivateTerm.UseVisualStyleBackColor = true;
            // 
            // btnActivateTerm
            // 
            this.btnActivateTerm.Enabled = false;
            this.btnActivateTerm.Location = new System.Drawing.Point(6, 116);
            this.btnActivateTerm.Name = "btnActivateTerm";
            this.btnActivateTerm.Size = new System.Drawing.Size(100, 25);
            this.btnActivateTerm.TabIndex = 24;
            this.btnActivateTerm.Text = "Activate";
            this.btnActivateTerm.UseVisualStyleBackColor = true;
            // 
            // cbTermStatusSearch
            // 
            this.cbTermStatusSearch.Enabled = false;
            this.cbTermStatusSearch.FormattingEnabled = true;
            this.cbTermStatusSearch.Location = new System.Drawing.Point(634, 17);
            this.cbTermStatusSearch.Name = "cbTermStatusSearch";
            this.cbTermStatusSearch.Size = new System.Drawing.Size(121, 21);
            this.cbTermStatusSearch.TabIndex = 23;
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(588, 20);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(40, 13);
            this.lblActive.TabIndex = 22;
            this.lblActive.Text = "Active:";
            // 
            // btnUpdateTerm
            // 
            this.btnUpdateTerm.Enabled = false;
            this.btnUpdateTerm.Location = new System.Drawing.Point(6, 85);
            this.btnUpdateTerm.Name = "btnUpdateTerm";
            this.btnUpdateTerm.Size = new System.Drawing.Size(100, 25);
            this.btnUpdateTerm.TabIndex = 21;
            this.btnUpdateTerm.Text = "Update Term";
            this.btnUpdateTerm.UseVisualStyleBackColor = true;
            this.btnUpdateTerm.Click += new System.EventHandler(this.btnUpdateTerm_Click);
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(123, 54);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(643, 253);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // btnAddTerm
            // 
            this.btnAddTerm.Location = new System.Drawing.Point(6, 54);
            this.btnAddTerm.Name = "btnAddTerm";
            this.btnAddTerm.Size = new System.Drawing.Size(100, 25);
            this.btnAddTerm.TabIndex = 19;
            this.btnAddTerm.Text = "Add Term";
            this.btnAddTerm.UseVisualStyleBackColor = true;
            this.btnAddTerm.Click += new System.EventHandler(this.btnAddTerm_Click);
            // 
            // FrmShipping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 437);
            this.Controls.Add(this.btnVendor);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnVendorSource);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.tabControlShippingVendors);
            this.Name = "FrmShipping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipping";
            this.Load += new System.EventHandler(this.FrmShipping_Load);
            this.tabShippingVendors.ResumeLayout(false);
            this.tabShippingVendors.PerformLayout();
            this.tabControlShippingVendors.ResumeLayout(false);
            this.tabShippingTerms.ResumeLayout(false);
            this.tabShippingTerms.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeactivateVendor;
        private System.Windows.Forms.Button btnVendor;
        private System.Windows.Forms.Button btnActivateVendor;
        private System.Windows.Forms.ComboBox cbVendorStatusSearch;
        private System.Windows.Forms.TabPage tabShippingVendors;
        private System.Windows.Forms.Label lblProductActiveSearch;
        private System.Windows.Forms.Button btnUpdateVendor;
        private System.Windows.Forms.ListView lvShippingVendors;
        private System.Windows.Forms.Button btnAddVendor;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnVendorSource;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.TabControl tabControlShippingVendors;
        private System.Windows.Forms.TabPage tabShippingTerms;
        private System.Windows.Forms.Button btnDeactivateTerm;
        private System.Windows.Forms.Button btnActivateTerm;
        private System.Windows.Forms.ComboBox cbTermStatusSearch;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Button btnUpdateTerm;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnAddTerm;
    }
}