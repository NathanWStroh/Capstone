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
            this.cbVendortStatusSearch = new System.Windows.Forms.ComboBox();
            this.lblProductActiveSearch = new System.Windows.Forms.Label();
            this.btnGetProductByID = new System.Windows.Forms.Button();
            this.btnUpdateVendor = new System.Windows.Forms.Button();
            this.txtVendorIDSearch = new System.Windows.Forms.TextBox();
            this.lblProductIDSearch = new System.Windows.Forms.Label();
            this.btnAddVendor = new System.Windows.Forms.Button();
            this.lvVendors = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnDeactivateVendor
            // 
            this.btnDeactivateVendor.Enabled = false;
            this.btnDeactivateVendor.Location = new System.Drawing.Point(12, 141);
            this.btnDeactivateVendor.Name = "btnDeactivateVendor";
            this.btnDeactivateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnDeactivateVendor.TabIndex = 44;
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
            this.btnActivateVendor.TabIndex = 43;
            this.btnActivateVendor.Text = "Activate";
            this.btnActivateVendor.UseVisualStyleBackColor = true;
            this.btnActivateVendor.Click += new System.EventHandler(this.btnActivateProduct_Click);
            // 
            // cbVendortStatusSearch
            // 
            this.cbVendortStatusSearch.FormattingEnabled = true;
            this.cbVendortStatusSearch.Location = new System.Drawing.Point(640, 14);
            this.cbVendortStatusSearch.Name = "cbVendortStatusSearch";
            this.cbVendortStatusSearch.Size = new System.Drawing.Size(121, 21);
            this.cbVendortStatusSearch.TabIndex = 42;
            this.cbVendortStatusSearch.SelectedIndexChanged += new System.EventHandler(this.cbVendortStatusSearch_SelectedIndexChanged);
            // 
            // lblProductActiveSearch
            // 
            this.lblProductActiveSearch.AutoSize = true;
            this.lblProductActiveSearch.Location = new System.Drawing.Point(594, 18);
            this.lblProductActiveSearch.Name = "lblProductActiveSearch";
            this.lblProductActiveSearch.Size = new System.Drawing.Size(40, 13);
            this.lblProductActiveSearch.TabIndex = 41;
            this.lblProductActiveSearch.Text = "Active:";
            // 
            // btnGetProductByID
            // 
            this.btnGetProductByID.Location = new System.Drawing.Point(286, 8);
            this.btnGetProductByID.Name = "btnGetProductByID";
            this.btnGetProductByID.Size = new System.Drawing.Size(42, 25);
            this.btnGetProductByID.TabIndex = 40;
            this.btnGetProductByID.Text = "Find";
            this.btnGetProductByID.UseVisualStyleBackColor = true;
            this.btnGetProductByID.Visible = false;
            // 
            // btnUpdateVendor
            // 
            this.btnUpdateVendor.Enabled = false;
            this.btnUpdateVendor.Location = new System.Drawing.Point(12, 79);
            this.btnUpdateVendor.Name = "btnUpdateVendor";
            this.btnUpdateVendor.Size = new System.Drawing.Size(100, 25);
            this.btnUpdateVendor.TabIndex = 39;
            this.btnUpdateVendor.Text = "Update Vendor";
            this.btnUpdateVendor.UseVisualStyleBackColor = true;
            this.btnUpdateVendor.Click += new System.EventHandler(this.btnUpdateVendor_Click);
            // 
            // txtVendorIDSearch
            // 
            this.txtVendorIDSearch.Enabled = false;
            this.txtVendorIDSearch.Location = new System.Drawing.Point(180, 11);
            this.txtVendorIDSearch.Name = "txtVendorIDSearch";
            this.txtVendorIDSearch.Size = new System.Drawing.Size(100, 20);
            this.txtVendorIDSearch.TabIndex = 38;
            this.txtVendorIDSearch.Visible = false;
            // 
            // lblProductIDSearch
            // 
            this.lblProductIDSearch.AutoSize = true;
            this.lblProductIDSearch.Location = new System.Drawing.Point(115, 14);
            this.lblProductIDSearch.Name = "lblProductIDSearch";
            this.lblProductIDSearch.Size = new System.Drawing.Size(61, 13);
            this.lblProductIDSearch.TabIndex = 37;
            this.lblProductIDSearch.Text = "Vendor ID: ";
            this.lblProductIDSearch.Visible = false;
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.Location = new System.Drawing.Point(12, 48);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(100, 25);
            this.btnAddVendor.TabIndex = 35;
            this.btnAddVendor.Text = "Add Vendor";
            this.btnAddVendor.UseVisualStyleBackColor = true;
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // lvVendors
            // 
            this.lvVendors.FullRowSelect = true;
            this.lvVendors.GridLines = true;
            this.lvVendors.Location = new System.Drawing.Point(118, 48);
            this.lvVendors.Name = "lvVendors";
            this.lvVendors.Size = new System.Drawing.Size(643, 256);
            this.lvVendors.TabIndex = 45;
            this.lvVendors.UseCompatibleStateImageBehavior = false;
            this.lvVendors.View = System.Windows.Forms.View.Details;
            this.lvVendors.SelectedIndexChanged += new System.EventHandler(this.lvVendors_SelectedIndexChanged);
            this.lvVendors.Click += new System.EventHandler(this.lvVendors_Click);
            // 
            // FrmVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 319);
            this.Controls.Add(this.lvVendors);
            this.Controls.Add(this.btnDeactivateVendor);
            this.Controls.Add(this.btnActivateVendor);
            this.Controls.Add(this.cbVendortStatusSearch);
            this.Controls.Add(this.lblProductActiveSearch);
            this.Controls.Add(this.btnGetProductByID);
            this.Controls.Add(this.btnUpdateVendor);
            this.Controls.Add(this.txtVendorIDSearch);
            this.Controls.Add(this.lblProductIDSearch);
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
        private System.Windows.Forms.ComboBox cbVendortStatusSearch;
        private System.Windows.Forms.Label lblProductActiveSearch;
        private System.Windows.Forms.Button btnGetProductByID;
        private System.Windows.Forms.Button btnUpdateVendor;
        private System.Windows.Forms.TextBox txtVendorIDSearch;
        private System.Windows.Forms.Label lblProductIDSearch;
        private System.Windows.Forms.Button btnAddVendor;
        private System.Windows.Forms.ListView lvVendors;

    }
}

