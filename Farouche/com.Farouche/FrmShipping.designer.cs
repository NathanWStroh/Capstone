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
            this.tabControlShipping = new System.Windows.Forms.TabControl();
            this.tabShippingTerms = new System.Windows.Forms.TabPage();
            this.btnDeactivateTerm = new System.Windows.Forms.Button();
            this.btnActivateTerm = new System.Windows.Forms.Button();
            this.cbTermStatusSearch = new System.Windows.Forms.ComboBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.btnUpdateTerm = new System.Windows.Forms.Button();
            this.lvShippingTerms = new System.Windows.Forms.ListView();
            this.btnAddTerm = new System.Windows.Forms.Button();
            this.tabShippingOrders = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabPackList = new System.Windows.Forms.TabControl();
            this.tabAllOrders = new System.Windows.Forms.TabPage();
            this.btnClearUser = new System.Windows.Forms.Button();
            this.lvAllOrders = new System.Windows.Forms.ListView();
            this.tabPickList = new System.Windows.Forms.TabPage();
            this.lvPickList = new System.Windows.Forms.ListView();
            this.btnStartPick = new System.Windows.Forms.Button();
            this.tabMyOrders = new System.Windows.Forms.TabPage();
            this.btnDetails = new System.Windows.Forms.Button();
            this.lvMyOrders = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnPackComplete = new System.Windows.Forms.Button();
            this.lvPackList = new System.Windows.Forms.ListView();
            this.tabShippingVendors.SuspendLayout();
            this.tabControlShipping.SuspendLayout();
            this.tabShippingTerms.SuspendLayout();
            this.tabShippingOrders.SuspendLayout();
            this.tabPackList.SuspendLayout();
            this.tabAllOrders.SuspendLayout();
            this.tabPickList.SuspendLayout();
            this.tabMyOrders.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            // tabControlShipping
            // 
            this.tabControlShipping.Controls.Add(this.tabShippingVendors);
            this.tabControlShipping.Controls.Add(this.tabShippingTerms);
            this.tabControlShipping.Controls.Add(this.tabShippingOrders);
            this.tabControlShipping.Location = new System.Drawing.Point(26, 19);
            this.tabControlShipping.Name = "tabControlShipping";
            this.tabControlShipping.SelectedIndex = 0;
            this.tabControlShipping.Size = new System.Drawing.Size(780, 350);
            this.tabControlShipping.TabIndex = 26;
            this.tabControlShipping.SelectedIndexChanged += new System.EventHandler(this.tabControlShipping_SelectedIndexChanged);
            // 
            // tabShippingTerms
            // 
            this.tabShippingTerms.Controls.Add(this.btnDeactivateTerm);
            this.tabShippingTerms.Controls.Add(this.btnActivateTerm);
            this.tabShippingTerms.Controls.Add(this.cbTermStatusSearch);
            this.tabShippingTerms.Controls.Add(this.lblActive);
            this.tabShippingTerms.Controls.Add(this.btnUpdateTerm);
            this.tabShippingTerms.Controls.Add(this.lvShippingTerms);
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
            // lvShippingTerms
            // 
            this.lvShippingTerms.FullRowSelect = true;
            this.lvShippingTerms.GridLines = true;
            this.lvShippingTerms.Location = new System.Drawing.Point(123, 54);
            this.lvShippingTerms.MultiSelect = false;
            this.lvShippingTerms.Name = "lvShippingTerms";
            this.lvShippingTerms.Size = new System.Drawing.Size(643, 253);
            this.lvShippingTerms.TabIndex = 20;
            this.lvShippingTerms.UseCompatibleStateImageBehavior = false;
            this.lvShippingTerms.View = System.Windows.Forms.View.Details;
            this.lvShippingTerms.Click += new System.EventHandler(this.lvShippingTerms_Click);
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
            // tabShippingOrders
            // 
            this.tabShippingOrders.Controls.Add(this.btnRefresh);
            this.tabShippingOrders.Controls.Add(this.tabPackList);
            this.tabShippingOrders.Location = new System.Drawing.Point(4, 22);
            this.tabShippingOrders.Name = "tabShippingOrders";
            this.tabShippingOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabShippingOrders.Size = new System.Drawing.Size(772, 324);
            this.tabShippingOrders.TabIndex = 2;
            this.tabShippingOrders.Text = "Shipping Orders";
            this.tabShippingOrders.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(624, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(144, 24);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh Lists";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // tabPackList
            // 
            this.tabPackList.Controls.Add(this.tabAllOrders);
            this.tabPackList.Controls.Add(this.tabPickList);
            this.tabPackList.Controls.Add(this.tabMyOrders);
            this.tabPackList.Controls.Add(this.tabPage2);
            this.tabPackList.Location = new System.Drawing.Point(0, 16);
            this.tabPackList.Name = "tabPackList";
            this.tabPackList.SelectedIndex = 0;
            this.tabPackList.Size = new System.Drawing.Size(772, 313);
            this.tabPackList.TabIndex = 2;
            // 
            // tabAllOrders
            // 
            this.tabAllOrders.Controls.Add(this.btnClearUser);
            this.tabAllOrders.Controls.Add(this.lvAllOrders);
            this.tabAllOrders.Location = new System.Drawing.Point(4, 22);
            this.tabAllOrders.Name = "tabAllOrders";
            this.tabAllOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllOrders.Size = new System.Drawing.Size(764, 287);
            this.tabAllOrders.TabIndex = 0;
            this.tabAllOrders.Text = "All Orders";
            this.tabAllOrders.UseVisualStyleBackColor = true;
            // 
            // btnClearUser
            // 
            this.btnClearUser.Location = new System.Drawing.Point(620, 260);
            this.btnClearUser.Name = "btnClearUser";
            this.btnClearUser.Size = new System.Drawing.Size(144, 23);
            this.btnClearUser.TabIndex = 1;
            this.btnClearUser.Text = "Clear User";
            this.btnClearUser.UseVisualStyleBackColor = true;
            // 
            // lvAllOrders
            // 
            this.lvAllOrders.FullRowSelect = true;
            this.lvAllOrders.GridLines = true;
            this.lvAllOrders.Location = new System.Drawing.Point(2, 0);
            this.lvAllOrders.MultiSelect = false;
            this.lvAllOrders.Name = "lvAllOrders";
            this.lvAllOrders.Size = new System.Drawing.Size(760, 252);
            this.lvAllOrders.TabIndex = 0;
            this.lvAllOrders.UseCompatibleStateImageBehavior = false;
            this.lvAllOrders.View = System.Windows.Forms.View.Details;
            // 
            // tabPickList
            // 
            this.tabPickList.Controls.Add(this.lvPickList);
            this.tabPickList.Controls.Add(this.btnStartPick);
            this.tabPickList.Location = new System.Drawing.Point(4, 22);
            this.tabPickList.Name = "tabPickList";
            this.tabPickList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPickList.Size = new System.Drawing.Size(764, 287);
            this.tabPickList.TabIndex = 1;
            this.tabPickList.Text = "Pick List";
            this.tabPickList.UseVisualStyleBackColor = true;
            // 
            // lvPickList
            // 
            this.lvPickList.FullRowSelect = true;
            this.lvPickList.GridLines = true;
            this.lvPickList.Location = new System.Drawing.Point(-2, -2);
            this.lvPickList.MultiSelect = false;
            this.lvPickList.Name = "lvPickList";
            this.lvPickList.Size = new System.Drawing.Size(760, 252);
            this.lvPickList.TabIndex = 2;
            this.lvPickList.UseCompatibleStateImageBehavior = false;
            this.lvPickList.View = System.Windows.Forms.View.Details;
            // 
            // btnStartPick
            // 
            this.btnStartPick.Location = new System.Drawing.Point(620, 260);
            this.btnStartPick.Name = "btnStartPick";
            this.btnStartPick.Size = new System.Drawing.Size(144, 23);
            this.btnStartPick.TabIndex = 1;
            this.btnStartPick.Text = "Start Pick";
            this.btnStartPick.UseVisualStyleBackColor = true;
            // 
            // tabMyOrders
            // 
            this.tabMyOrders.Controls.Add(this.btnDetails);
            this.tabMyOrders.Controls.Add(this.lvMyOrders);
            this.tabMyOrders.Location = new System.Drawing.Point(4, 22);
            this.tabMyOrders.Name = "tabMyOrders";
            this.tabMyOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyOrders.Size = new System.Drawing.Size(764, 287);
            this.tabMyOrders.TabIndex = 2;
            this.tabMyOrders.Text = "My Orders";
            this.tabMyOrders.UseVisualStyleBackColor = true;
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(620, 260);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(144, 23);
            this.btnDetails.TabIndex = 1;
            this.btnDetails.Text = "View Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            // 
            // lvMyOrders
            // 
            this.lvMyOrders.FullRowSelect = true;
            this.lvMyOrders.GridLines = true;
            this.lvMyOrders.Location = new System.Drawing.Point(2, 0);
            this.lvMyOrders.MultiSelect = false;
            this.lvMyOrders.Name = "lvMyOrders";
            this.lvMyOrders.Size = new System.Drawing.Size(760, 252);
            this.lvMyOrders.TabIndex = 0;
            this.lvMyOrders.UseCompatibleStateImageBehavior = false;
            this.lvMyOrders.View = System.Windows.Forms.View.Details;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnPackComplete);
            this.tabPage2.Controls.Add(this.lvPackList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(764, 287);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Pack List";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnPackComplete
            // 
            this.btnPackComplete.Location = new System.Drawing.Point(620, 260);
            this.btnPackComplete.Name = "btnPackComplete";
            this.btnPackComplete.Size = new System.Drawing.Size(144, 23);
            this.btnPackComplete.TabIndex = 1;
            this.btnPackComplete.Text = "Ready for Ship";
            this.btnPackComplete.UseVisualStyleBackColor = true;
            // 
            // lvPackList
            // 
            this.lvPackList.FullRowSelect = true;
            this.lvPackList.GridLines = true;
            this.lvPackList.Location = new System.Drawing.Point(0, 2);
            this.lvPackList.MultiSelect = false;
            this.lvPackList.Name = "lvPackList";
            this.lvPackList.Size = new System.Drawing.Size(760, 252);
            this.lvPackList.TabIndex = 0;
            this.lvPackList.UseCompatibleStateImageBehavior = false;
            this.lvPackList.View = System.Windows.Forms.View.Details;
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
            this.Controls.Add(this.tabControlShipping);
            this.Name = "FrmShipping";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shipping";
            this.Load += new System.EventHandler(this.FrmShipping_Load);
            this.tabShippingVendors.ResumeLayout(false);
            this.tabShippingVendors.PerformLayout();
            this.tabControlShipping.ResumeLayout(false);
            this.tabShippingTerms.ResumeLayout(false);
            this.tabShippingTerms.PerformLayout();
            this.tabShippingOrders.ResumeLayout(false);
            this.tabPackList.ResumeLayout(false);
            this.tabAllOrders.ResumeLayout(false);
            this.tabPickList.ResumeLayout(false);
            this.tabMyOrders.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControlShipping;
        private System.Windows.Forms.TabPage tabShippingTerms;
        private System.Windows.Forms.Button btnDeactivateTerm;
        private System.Windows.Forms.Button btnActivateTerm;
        private System.Windows.Forms.ComboBox cbTermStatusSearch;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Button btnUpdateTerm;
        private System.Windows.Forms.ListView lvShippingTerms;
        private System.Windows.Forms.Button btnAddTerm;
        private System.Windows.Forms.TabPage tabShippingOrders;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TabControl tabPackList;
        private System.Windows.Forms.TabPage tabAllOrders;
        private System.Windows.Forms.Button btnClearUser;
        private System.Windows.Forms.ListView lvAllOrders;
        private System.Windows.Forms.TabPage tabPickList;
        private System.Windows.Forms.ListView lvPickList;
        private System.Windows.Forms.Button btnStartPick;
        private System.Windows.Forms.TabPage tabMyOrders;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.ListView lvMyOrders;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnPackComplete;
        private System.Windows.Forms.ListView lvPackList;
    }
}