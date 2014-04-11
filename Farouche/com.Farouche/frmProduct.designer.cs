namespace com.Farouche.Presentation
{
    partial class FrmProduct
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
            this.btnVendor = new System.Windows.Forms.Button();
            this.btnVendorSource = new System.Windows.Forms.Button();
            this.btnPressed = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabProducts = new System.Windows.Forms.TabPage();
            this.btnUpdateOnOrder = new System.Windows.Forms.Button();
            this.btnUpdateReorderThreshold = new System.Windows.Forms.Button();
            this.btnUpdateReorderAmount = new System.Windows.Forms.Button();
            this.btnDeactivateProduct = new System.Windows.Forms.Button();
            this.btnActivateProduct = new System.Windows.Forms.Button();
            this.cbProductStatusSearch = new System.Windows.Forms.ComboBox();
            this.lblProductActiveSearch = new System.Windows.Forms.Label();
            this.btnGetProductByID = new System.Windows.Forms.Button();
            this.btnUpdateProduct = new System.Windows.Forms.Button();
            this.txtProductIDSearch = new System.Windows.Forms.TextBox();
            this.lblProductIDSearch = new System.Windows.Forms.Label();
            this.lvProducts = new System.Windows.Forms.ListView();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.tabControlProducts = new System.Windows.Forms.TabControl();
            this.btnShipping = new System.Windows.Forms.Button();
            this.tabProducts.SuspendLayout();
            this.tabControlProducts.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVendor
            // 
            this.btnVendor.Location = new System.Drawing.Point(12, 399);
            this.btnVendor.Name = "btnVendor";
            this.btnVendor.Size = new System.Drawing.Size(90, 23);
            this.btnVendor.TabIndex = 18;
            this.btnVendor.Text = "Vendor";
            this.btnVendor.UseVisualStyleBackColor = true;
            this.btnVendor.Click += new System.EventHandler(this.btnVendor_Click);
            // 
            // btnVendorSource
            // 
            this.btnVendorSource.Location = new System.Drawing.Point(204, 399);
            this.btnVendorSource.Name = "btnVendorSource";
            this.btnVendorSource.Size = new System.Drawing.Size(90, 23);
            this.btnVendorSource.TabIndex = 19;
            this.btnVendorSource.Text = "Vendor Source";
            this.btnVendorSource.UseVisualStyleBackColor = true;
            this.btnVendorSource.Click += new System.EventHandler(this.btnVendorSource_Click);
            // 
            // btnPressed
            // 
            this.btnPressed.Enabled = false;
            this.btnPressed.Location = new System.Drawing.Point(108, 399);
            this.btnPressed.Name = "btnPressed";
            this.btnPressed.Size = new System.Drawing.Size(90, 23);
            this.btnPressed.TabIndex = 20;
            this.btnPressed.Text = "Product";
            this.btnPressed.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(747, 402);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 22;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tabProducts
            // 
            this.tabProducts.Controls.Add(this.btnUpdateOnOrder);
            this.tabProducts.Controls.Add(this.btnUpdateReorderThreshold);
            this.tabProducts.Controls.Add(this.btnUpdateReorderAmount);
            this.tabProducts.Controls.Add(this.btnDeactivateProduct);
            this.tabProducts.Controls.Add(this.btnActivateProduct);
            this.tabProducts.Controls.Add(this.cbProductStatusSearch);
            this.tabProducts.Controls.Add(this.lblProductActiveSearch);
            this.tabProducts.Controls.Add(this.btnGetProductByID);
            this.tabProducts.Controls.Add(this.btnUpdateProduct);
            this.tabProducts.Controls.Add(this.txtProductIDSearch);
            this.tabProducts.Controls.Add(this.lblProductIDSearch);
            this.tabProducts.Controls.Add(this.lvProducts);
            this.tabProducts.Controls.Add(this.btnAddProduct);
            this.tabProducts.Location = new System.Drawing.Point(4, 22);
            this.tabProducts.Name = "tabProducts";
            this.tabProducts.Padding = new System.Windows.Forms.Padding(3);
            this.tabProducts.Size = new System.Drawing.Size(772, 324);
            this.tabProducts.TabIndex = 0;
            this.tabProducts.Text = "Products";
            this.tabProducts.UseVisualStyleBackColor = true;
            // 
            // btnUpdateOnOrder
            // 
            this.btnUpdateOnOrder.Enabled = false;
            this.btnUpdateOnOrder.Location = new System.Drawing.Point(6, 270);
            this.btnUpdateOnOrder.Name = "btnUpdateOnOrder";
            this.btnUpdateOnOrder.Size = new System.Drawing.Size(100, 40);
            this.btnUpdateOnOrder.TabIndex = 21;
            this.btnUpdateOnOrder.Text = "Adjust On Order Level";
            this.btnUpdateOnOrder.UseVisualStyleBackColor = true;
            this.btnUpdateOnOrder.Click += new System.EventHandler(this.btnUpdateOnOrder_Click);
            // 
            // btnUpdateReorderThreshold
            // 
            this.btnUpdateReorderThreshold.Enabled = false;
            this.btnUpdateReorderThreshold.Location = new System.Drawing.Point(6, 178);
            this.btnUpdateReorderThreshold.Name = "btnUpdateReorderThreshold";
            this.btnUpdateReorderThreshold.Size = new System.Drawing.Size(100, 40);
            this.btnUpdateReorderThreshold.TabIndex = 20;
            this.btnUpdateReorderThreshold.Text = "Adjust Reorder Threshold";
            this.btnUpdateReorderThreshold.UseVisualStyleBackColor = true;
            this.btnUpdateReorderThreshold.Click += new System.EventHandler(this.btnUpdateReorderThreshold_Click);
            // 
            // btnUpdateReorderAmount
            // 
            this.btnUpdateReorderAmount.Enabled = false;
            this.btnUpdateReorderAmount.Location = new System.Drawing.Point(6, 224);
            this.btnUpdateReorderAmount.Name = "btnUpdateReorderAmount";
            this.btnUpdateReorderAmount.Size = new System.Drawing.Size(100, 40);
            this.btnUpdateReorderAmount.TabIndex = 19;
            this.btnUpdateReorderAmount.Text = "Adjust Reorder Amount";
            this.btnUpdateReorderAmount.UseVisualStyleBackColor = true;
            this.btnUpdateReorderAmount.Click += new System.EventHandler(this.btnUpdateReorderAmount_Click);
            // 
            // btnDeactivateProduct
            // 
            this.btnDeactivateProduct.Enabled = false;
            this.btnDeactivateProduct.Location = new System.Drawing.Point(6, 147);
            this.btnDeactivateProduct.Name = "btnDeactivateProduct";
            this.btnDeactivateProduct.Size = new System.Drawing.Size(100, 25);
            this.btnDeactivateProduct.TabIndex = 18;
            this.btnDeactivateProduct.Text = "Deactivate";
            this.btnDeactivateProduct.UseVisualStyleBackColor = true;
            this.btnDeactivateProduct.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // btnActivateProduct
            // 
            this.btnActivateProduct.Enabled = false;
            this.btnActivateProduct.Location = new System.Drawing.Point(6, 116);
            this.btnActivateProduct.Name = "btnActivateProduct";
            this.btnActivateProduct.Size = new System.Drawing.Size(100, 25);
            this.btnActivateProduct.TabIndex = 17;
            this.btnActivateProduct.Text = "Activate";
            this.btnActivateProduct.UseVisualStyleBackColor = true;
            this.btnActivateProduct.Click += new System.EventHandler(this.btnActivateProduct_Click);
            // 
            // cbProductStatusSearch
            // 
            this.cbProductStatusSearch.FormattingEnabled = true;
            this.cbProductStatusSearch.Location = new System.Drawing.Point(634, 17);
            this.cbProductStatusSearch.Name = "cbProductStatusSearch";
            this.cbProductStatusSearch.Size = new System.Drawing.Size(121, 21);
            this.cbProductStatusSearch.TabIndex = 16;
            this.cbProductStatusSearch.SelectedIndexChanged += new System.EventHandler(this.cbProductStatusSearch_SelectedIndexChanged);
            this.cbProductStatusSearch.Click += new System.EventHandler(this.cbProductStatusSearch_Click);
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
            // btnGetProductByID
            // 
            this.btnGetProductByID.Location = new System.Drawing.Point(280, 14);
            this.btnGetProductByID.Name = "btnGetProductByID";
            this.btnGetProductByID.Size = new System.Drawing.Size(42, 25);
            this.btnGetProductByID.TabIndex = 14;
            this.btnGetProductByID.Text = "Find";
            this.btnGetProductByID.UseVisualStyleBackColor = true;
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Enabled = false;
            this.btnUpdateProduct.Location = new System.Drawing.Point(6, 85);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(100, 25);
            this.btnUpdateProduct.TabIndex = 13;
            this.btnUpdateProduct.Text = "Update Product";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // txtProductIDSearch
            // 
            this.txtProductIDSearch.Enabled = false;
            this.txtProductIDSearch.Location = new System.Drawing.Point(174, 17);
            this.txtProductIDSearch.Name = "txtProductIDSearch";
            this.txtProductIDSearch.Size = new System.Drawing.Size(100, 20);
            this.txtProductIDSearch.TabIndex = 12;
            // 
            // lblProductIDSearch
            // 
            this.lblProductIDSearch.AutoSize = true;
            this.lblProductIDSearch.Location = new System.Drawing.Point(109, 20);
            this.lblProductIDSearch.Name = "lblProductIDSearch";
            this.lblProductIDSearch.Size = new System.Drawing.Size(64, 13);
            this.lblProductIDSearch.TabIndex = 11;
            this.lblProductIDSearch.Text = "Product ID: ";
            // 
            // lvProducts
            // 
            this.lvProducts.FullRowSelect = true;
            this.lvProducts.GridLines = true;
            this.lvProducts.Location = new System.Drawing.Point(112, 54);
            this.lvProducts.MultiSelect = false;
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(643, 256);
            this.lvProducts.TabIndex = 10;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            this.lvProducts.Click += new System.EventHandler(this.lvProducts_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(6, 54);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(100, 25);
            this.btnAddProduct.TabIndex = 8;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tabControlProducts
            // 
            this.tabControlProducts.Controls.Add(this.tabProducts);
            this.tabControlProducts.Location = new System.Drawing.Point(26, 26);
            this.tabControlProducts.Name = "tabControlProducts";
            this.tabControlProducts.SelectedIndex = 0;
            this.tabControlProducts.Size = new System.Drawing.Size(780, 350);
            this.tabControlProducts.TabIndex = 21;
            // 
            // btnShipping
            // 
            this.btnShipping.Location = new System.Drawing.Point(300, 399);
            this.btnShipping.Name = "btnShipping";
            this.btnShipping.Size = new System.Drawing.Size(75, 23);
            this.btnShipping.TabIndex = 25;
            this.btnShipping.Text = "Shipping";
            this.btnShipping.UseVisualStyleBackColor = true;
            this.btnShipping.Click += new System.EventHandler(this.btnShipping_Click);
            // 
            // FrmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 437);
            this.Controls.Add(this.btnShipping);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControlProducts);
            this.Controls.Add(this.btnPressed);
            this.Controls.Add(this.btnVendorSource);
            this.Controls.Add(this.btnVendor);
            this.MinimumSize = new System.Drawing.Size(850, 476);
            this.Name = "FrmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAddProduct_Load);
            this.tabProducts.ResumeLayout(false);
            this.tabProducts.PerformLayout();
            this.tabControlProducts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVendor;
        private System.Windows.Forms.Button btnVendorSource;
        private System.Windows.Forms.Button btnPressed;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabPage tabProducts;
        private System.Windows.Forms.ComboBox cbProductStatusSearch;
        private System.Windows.Forms.Label lblProductActiveSearch;
        private System.Windows.Forms.Button btnGetProductByID;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.TextBox txtProductIDSearch;
        private System.Windows.Forms.Label lblProductIDSearch;
        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.TabControl tabControlProducts;
        private System.Windows.Forms.Button btnDeactivateProduct;
        private System.Windows.Forms.Button btnActivateProduct;
        private System.Windows.Forms.Button btnShipping;
        private System.Windows.Forms.Button btnUpdateOnOrder;
        private System.Windows.Forms.Button btnUpdateReorderThreshold;
        private System.Windows.Forms.Button btnUpdateReorderAmount;
    }
}