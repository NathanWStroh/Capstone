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
            this.btnDeactivateProduct = new System.Windows.Forms.Button();
            this.btnActivateProduct = new System.Windows.Forms.Button();
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
            // btnDeactivateProduct
            // 
            this.btnDeactivateProduct.Enabled = false;
            this.btnDeactivateProduct.Location = new System.Drawing.Point(741, 70);
            this.btnDeactivateProduct.Name = "btnDeactivateProduct";
            this.btnDeactivateProduct.Size = new System.Drawing.Size(100, 25);
            this.btnDeactivateProduct.TabIndex = 44;
            this.btnDeactivateProduct.Text = "Deactivate";
            this.btnDeactivateProduct.UseVisualStyleBackColor = true;
            this.btnDeactivateProduct.Visible = false;
            // 
            // btnActivateProduct
            // 
            this.btnActivateProduct.Enabled = false;
            this.btnActivateProduct.Location = new System.Drawing.Point(741, 39);
            this.btnActivateProduct.Name = "btnActivateProduct";
            this.btnActivateProduct.Size = new System.Drawing.Size(100, 25);
            this.btnActivateProduct.TabIndex = 43;
            this.btnActivateProduct.Text = "Activate";
            this.btnActivateProduct.UseVisualStyleBackColor = true;
            this.btnActivateProduct.Visible = false;
            // 
            // cbVendortStatusSearch
            // 
            this.cbVendortStatusSearch.FormattingEnabled = true;
            this.cbVendortStatusSearch.Location = new System.Drawing.Point(614, 12);
            this.cbVendortStatusSearch.Name = "cbVendortStatusSearch";
            this.cbVendortStatusSearch.Size = new System.Drawing.Size(121, 21);
            this.cbVendortStatusSearch.TabIndex = 42;
            this.cbVendortStatusSearch.Visible = false;
            // 
            // lblProductActiveSearch
            // 
            this.lblProductActiveSearch.AutoSize = true;
            this.lblProductActiveSearch.Location = new System.Drawing.Point(568, 14);
            this.lblProductActiveSearch.Name = "lblProductActiveSearch";
            this.lblProductActiveSearch.Size = new System.Drawing.Size(40, 13);
            this.lblProductActiveSearch.TabIndex = 41;
            this.lblProductActiveSearch.Text = "Active:";
            this.lblProductActiveSearch.Visible = false;
            // 
            // btnGetProductByID
            // 
            this.btnGetProductByID.Location = new System.Drawing.Point(310, 8);
            this.btnGetProductByID.Name = "btnGetProductByID";
            this.btnGetProductByID.Size = new System.Drawing.Size(42, 25);
            this.btnGetProductByID.TabIndex = 40;
            this.btnGetProductByID.Text = "Find";
            this.btnGetProductByID.UseVisualStyleBackColor = true;
            this.btnGetProductByID.Visible = false;
            // 
            // btnUpdateVendor
            // 
            this.btnUpdateVendor.Location = new System.Drawing.Point(33, 70);
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
            this.txtVendorIDSearch.Location = new System.Drawing.Point(204, 11);
            this.txtVendorIDSearch.Name = "txtVendorIDSearch";
            this.txtVendorIDSearch.Size = new System.Drawing.Size(100, 20);
            this.txtVendorIDSearch.TabIndex = 38;
            this.txtVendorIDSearch.Visible = false;
            // 
            // lblProductIDSearch
            // 
            this.lblProductIDSearch.AutoSize = true;
            this.lblProductIDSearch.Location = new System.Drawing.Point(139, 14);
            this.lblProductIDSearch.Name = "lblProductIDSearch";
            this.lblProductIDSearch.Size = new System.Drawing.Size(61, 13);
            this.lblProductIDSearch.TabIndex = 37;
            this.lblProductIDSearch.Text = "Vendor ID: ";
            this.lblProductIDSearch.Visible = false;
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.Location = new System.Drawing.Point(33, 39);
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
            this.lvVendors.Location = new System.Drawing.Point(142, 39);
            this.lvVendors.Name = "lvVendors";
            this.lvVendors.Size = new System.Drawing.Size(593, 261);
            this.lvVendors.TabIndex = 45;
            this.lvVendors.UseCompatibleStateImageBehavior = false;
            this.lvVendors.View = System.Windows.Forms.View.Details;
            // 
            // FrmVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 312);
            this.Controls.Add(this.lvVendors);
            this.Controls.Add(this.btnDeactivateProduct);
            this.Controls.Add(this.btnActivateProduct);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeactivateProduct;
        private System.Windows.Forms.Button btnActivateProduct;
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

