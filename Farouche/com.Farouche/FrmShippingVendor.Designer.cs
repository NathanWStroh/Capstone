namespace com.Farouche
{
    partial class FrmShippingVendor
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
            this.lblProductActiveSearch = new System.Windows.Forms.Label();
            this.btnUpdateVendor = new System.Windows.Forms.Button();
            this.lvShippingVendors = new System.Windows.Forms.ListView();
            this.btnAddVendor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeactivateVendor
            // 
            this.btnDeactivateVendor.Enabled = false;
            this.btnDeactivateVendor.Location = new System.Drawing.Point(22, 162);
            this.btnDeactivateVendor.Name = "btnDeactivateVendor";
            this.btnDeactivateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnDeactivateVendor.TabIndex = 25;
            this.btnDeactivateVendor.Text = "Deactivate";
            this.btnDeactivateVendor.UseVisualStyleBackColor = true;
            // 
            // btnActivateVendor
            // 
            this.btnActivateVendor.Enabled = false;
            this.btnActivateVendor.Location = new System.Drawing.Point(22, 131);
            this.btnActivateVendor.Name = "btnActivateVendor";
            this.btnActivateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnActivateVendor.TabIndex = 24;
            this.btnActivateVendor.Text = "Activate";
            this.btnActivateVendor.UseVisualStyleBackColor = true;
            // 
            // cbVendorStatusSearch
            // 
            this.cbVendorStatusSearch.Enabled = false;
            this.cbVendorStatusSearch.FormattingEnabled = true;
            this.cbVendorStatusSearch.Location = new System.Drawing.Point(650, 32);
            this.cbVendorStatusSearch.Name = "cbVendorStatusSearch";
            this.cbVendorStatusSearch.Size = new System.Drawing.Size(121, 21);
            this.cbVendorStatusSearch.TabIndex = 23;
            // 
            // lblProductActiveSearch
            // 
            this.lblProductActiveSearch.AutoSize = true;
            this.lblProductActiveSearch.Location = new System.Drawing.Point(604, 35);
            this.lblProductActiveSearch.Name = "lblProductActiveSearch";
            this.lblProductActiveSearch.Size = new System.Drawing.Size(40, 13);
            this.lblProductActiveSearch.TabIndex = 22;
            this.lblProductActiveSearch.Text = "Active:";
            // 
            // btnUpdateVendor
            // 
            this.btnUpdateVendor.Enabled = false;
            this.btnUpdateVendor.Location = new System.Drawing.Point(22, 100);
            this.btnUpdateVendor.Name = "btnUpdateVendor";
            this.btnUpdateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnUpdateVendor.TabIndex = 21;
            this.btnUpdateVendor.Text = "Update Vendor";
            this.btnUpdateVendor.UseVisualStyleBackColor = true;
            this.btnUpdateVendor.Click += new System.EventHandler(this.btnUpdateVendor_Click);
            // 
            // lvShippingVendors
            // 
            this.lvShippingVendors.FullRowSelect = true;
            this.lvShippingVendors.GridLines = true;
            this.lvShippingVendors.Location = new System.Drawing.Point(139, 69);
            this.lvShippingVendors.MultiSelect = false;
            this.lvShippingVendors.Name = "lvShippingVendors";
            this.lvShippingVendors.Size = new System.Drawing.Size(643, 253);
            this.lvShippingVendors.TabIndex = 20;
            this.lvShippingVendors.UseCompatibleStateImageBehavior = false;
            this.lvShippingVendors.View = System.Windows.Forms.View.Details;
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.Location = new System.Drawing.Point(22, 69);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(100, 25);
            this.btnAddVendor.TabIndex = 19;
            this.btnAddVendor.Text = "Add Vendor";
            this.btnAddVendor.UseVisualStyleBackColor = true;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // FrmShippingVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 350);
            this.Controls.Add(this.btnDeactivateVendor);
            this.Controls.Add(this.btnActivateVendor);
            this.Controls.Add(this.cbVendorStatusSearch);
            this.Controls.Add(this.lblProductActiveSearch);
            this.Controls.Add(this.btnUpdateVendor);
            this.Controls.Add(this.lvShippingVendors);
            this.Controls.Add(this.btnAddVendor);
            this.Name = "FrmShippingVendor";
            this.Text = "FrmShippingVendor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeactivateVendor;
        private System.Windows.Forms.Button btnActivateVendor;
        private System.Windows.Forms.ComboBox cbVendorStatusSearch;
        private System.Windows.Forms.Label lblProductActiveSearch;
        private System.Windows.Forms.Button btnUpdateVendor;
        private System.Windows.Forms.ListView lvShippingVendors;
        private System.Windows.Forms.Button btnAddVendor;
    }
}