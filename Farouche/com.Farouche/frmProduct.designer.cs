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
            this.SuspendLayout();
            // 
            // btnUpdateOnOrder
            // 
            this.btnUpdateOnOrder.Enabled = false;
            this.btnUpdateOnOrder.Location = new System.Drawing.Point(12, 264);
            this.btnUpdateOnOrder.Name = "btnUpdateOnOrder";
            this.btnUpdateOnOrder.Size = new System.Drawing.Size(100, 40);
            this.btnUpdateOnOrder.TabIndex = 34;
            this.btnUpdateOnOrder.Text = "Adjust On Order Level";
            this.btnUpdateOnOrder.UseVisualStyleBackColor = true;
            this.btnUpdateOnOrder.Click += new System.EventHandler(this.btnUpdateOnOrder_Click);
            // 
            // btnUpdateReorderThreshold
            // 
            this.btnUpdateReorderThreshold.Enabled = false;
            this.btnUpdateReorderThreshold.Location = new System.Drawing.Point(12, 172);
            this.btnUpdateReorderThreshold.Name = "btnUpdateReorderThreshold";
            this.btnUpdateReorderThreshold.Size = new System.Drawing.Size(100, 40);
            this.btnUpdateReorderThreshold.TabIndex = 33;
            this.btnUpdateReorderThreshold.Text = "Adjust Reorder Threshold";
            this.btnUpdateReorderThreshold.UseVisualStyleBackColor = true;
            this.btnUpdateReorderThreshold.Click += new System.EventHandler(this.btnUpdateReorderThreshold_Click);
            // 
            // btnUpdateReorderAmount
            // 
            this.btnUpdateReorderAmount.Enabled = false;
            this.btnUpdateReorderAmount.Location = new System.Drawing.Point(12, 218);
            this.btnUpdateReorderAmount.Name = "btnUpdateReorderAmount";
            this.btnUpdateReorderAmount.Size = new System.Drawing.Size(100, 40);
            this.btnUpdateReorderAmount.TabIndex = 32;
            this.btnUpdateReorderAmount.Text = "Adjust Reorder Amount";
            this.btnUpdateReorderAmount.UseVisualStyleBackColor = true;
            this.btnUpdateReorderAmount.Click += new System.EventHandler(this.btnUpdateReorderAmount_Click);
            // 
            // btnDeactivateProduct
            // 
            this.btnDeactivateProduct.Enabled = false;
            this.btnDeactivateProduct.Location = new System.Drawing.Point(12, 141);
            this.btnDeactivateProduct.Name = "btnDeactivateProduct";
            this.btnDeactivateProduct.Size = new System.Drawing.Size(100, 25);
            this.btnDeactivateProduct.TabIndex = 31;
            this.btnDeactivateProduct.Text = "Deactivate";
            this.btnDeactivateProduct.UseVisualStyleBackColor = true;
            this.btnDeactivateProduct.Click += new System.EventHandler(this.btnDeactivate_Click);
            // 
            // btnActivateProduct
            // 
            this.btnActivateProduct.Enabled = false;
            this.btnActivateProduct.Location = new System.Drawing.Point(12, 110);
            this.btnActivateProduct.Name = "btnActivateProduct";
            this.btnActivateProduct.Size = new System.Drawing.Size(100, 25);
            this.btnActivateProduct.TabIndex = 30;
            this.btnActivateProduct.Text = "Activate";
            this.btnActivateProduct.UseVisualStyleBackColor = true;
            this.btnActivateProduct.Click += new System.EventHandler(this.btnActivateProduct_Click);
            // 
            // cbProductStatusSearch
            // 
            this.cbProductStatusSearch.FormattingEnabled = true;
            this.cbProductStatusSearch.Location = new System.Drawing.Point(640, 11);
            this.cbProductStatusSearch.Name = "cbProductStatusSearch";
            this.cbProductStatusSearch.Size = new System.Drawing.Size(121, 21);
            this.cbProductStatusSearch.TabIndex = 29;
            this.cbProductStatusSearch.SelectedIndexChanged += new System.EventHandler(this.cbProductStatusSearch_SelectedIndexChanged);
            this.cbProductStatusSearch.Click += new System.EventHandler(this.cbProductStatusSearch_Click);
            // 
            // lblProductActiveSearch
            // 
            this.lblProductActiveSearch.AutoSize = true;
            this.lblProductActiveSearch.Location = new System.Drawing.Point(594, 14);
            this.lblProductActiveSearch.Name = "lblProductActiveSearch";
            this.lblProductActiveSearch.Size = new System.Drawing.Size(40, 13);
            this.lblProductActiveSearch.TabIndex = 28;
            this.lblProductActiveSearch.Text = "Active:";
            // 
            // btnGetProductByID
            // 
            this.btnGetProductByID.Location = new System.Drawing.Point(286, 8);
            this.btnGetProductByID.Name = "btnGetProductByID";
            this.btnGetProductByID.Size = new System.Drawing.Size(42, 25);
            this.btnGetProductByID.TabIndex = 27;
            this.btnGetProductByID.Text = "Find";
            this.btnGetProductByID.UseVisualStyleBackColor = true;
            // 
            // btnUpdateProduct
            // 
            this.btnUpdateProduct.Enabled = false;
            this.btnUpdateProduct.Location = new System.Drawing.Point(12, 79);
            this.btnUpdateProduct.Name = "btnUpdateProduct";
            this.btnUpdateProduct.Size = new System.Drawing.Size(100, 25);
            this.btnUpdateProduct.TabIndex = 26;
            this.btnUpdateProduct.Text = "Update Product";
            this.btnUpdateProduct.UseVisualStyleBackColor = true;
            this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
            // 
            // txtProductIDSearch
            // 
            this.txtProductIDSearch.Enabled = false;
            this.txtProductIDSearch.Location = new System.Drawing.Point(180, 11);
            this.txtProductIDSearch.Name = "txtProductIDSearch";
            this.txtProductIDSearch.Size = new System.Drawing.Size(100, 20);
            this.txtProductIDSearch.TabIndex = 25;
            // 
            // lblProductIDSearch
            // 
            this.lblProductIDSearch.AutoSize = true;
            this.lblProductIDSearch.Location = new System.Drawing.Point(115, 14);
            this.lblProductIDSearch.Name = "lblProductIDSearch";
            this.lblProductIDSearch.Size = new System.Drawing.Size(64, 13);
            this.lblProductIDSearch.TabIndex = 24;
            this.lblProductIDSearch.Text = "Product ID: ";
            // 
            // lvProducts
            // 
            this.lvProducts.FullRowSelect = true;
            this.lvProducts.GridLines = true;
            this.lvProducts.Location = new System.Drawing.Point(118, 48);
            this.lvProducts.MultiSelect = false;
            this.lvProducts.Name = "lvProducts";
            this.lvProducts.Size = new System.Drawing.Size(643, 256);
            this.lvProducts.TabIndex = 23;
            this.lvProducts.UseCompatibleStateImageBehavior = false;
            this.lvProducts.View = System.Windows.Forms.View.Details;
            this.lvProducts.Click += new System.EventHandler(this.lvProducts_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(12, 48);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(100, 25);
            this.btnAddProduct.TabIndex = 22;
            this.btnAddProduct.Text = "Add Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FrmProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 319);
            this.Controls.Add(this.btnUpdateOnOrder);
            this.Controls.Add(this.btnUpdateReorderThreshold);
            this.Controls.Add(this.btnUpdateReorderAmount);
            this.Controls.Add(this.btnDeactivateProduct);
            this.Controls.Add(this.btnActivateProduct);
            this.Controls.Add(this.cbProductStatusSearch);
            this.Controls.Add(this.lblProductActiveSearch);
            this.Controls.Add(this.btnGetProductByID);
            this.Controls.Add(this.btnUpdateProduct);
            this.Controls.Add(this.txtProductIDSearch);
            this.Controls.Add(this.lblProductIDSearch);
            this.Controls.Add(this.lvProducts);
            this.Controls.Add(this.btnAddProduct);
            this.Name = "FrmProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            this.Load += new System.EventHandler(this.frmAddProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateOnOrder;
        private System.Windows.Forms.Button btnUpdateReorderThreshold;
        private System.Windows.Forms.Button btnUpdateReorderAmount;
        private System.Windows.Forms.Button btnDeactivateProduct;
        private System.Windows.Forms.Button btnActivateProduct;
        private System.Windows.Forms.ComboBox cbProductStatusSearch;
        private System.Windows.Forms.Label lblProductActiveSearch;
        private System.Windows.Forms.Button btnGetProductByID;
        private System.Windows.Forms.Button btnUpdateProduct;
        private System.Windows.Forms.TextBox txtProductIDSearch;
        private System.Windows.Forms.Label lblProductIDSearch;
        private System.Windows.Forms.ListView lvProducts;
        private System.Windows.Forms.Button btnAddProduct;

    }
}