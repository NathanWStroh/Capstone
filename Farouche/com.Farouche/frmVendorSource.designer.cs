namespace com.Farouche.Presentation
{
    partial class FrmVendorSource
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
            this.vendorSrcTab = new System.Windows.Forms.TabControl();
            this.addVSITab = new System.Windows.Forms.TabPage();
            this.unitCost = new System.Windows.Forms.TextBox();
            this.vnd = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.minQty = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.vendorCb = new System.Windows.Forms.ComboBox();
            this.productCb = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnVendor = new System.Windows.Forms.Button();
            this.btnPressed = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnShipping = new System.Windows.Forms.Button();
            this.vendorSrcTab.SuspendLayout();
            this.addVSITab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minQty)).BeginInit();
            this.SuspendLayout();
            // 
            // vendorSrcTab
            // 
            this.vendorSrcTab.Controls.Add(this.addVSITab);
            this.vendorSrcTab.Controls.Add(this.tabPage2);
            this.vendorSrcTab.Controls.Add(this.tabPage3);
            this.vendorSrcTab.Location = new System.Drawing.Point(26, 26);
            this.vendorSrcTab.Multiline = true;
            this.vendorSrcTab.Name = "vendorSrcTab";
            this.vendorSrcTab.SelectedIndex = 0;
            this.vendorSrcTab.Size = new System.Drawing.Size(780, 350);
            this.vendorSrcTab.TabIndex = 0;
            // 
            // addVSITab
            // 
            this.addVSITab.Controls.Add(this.unitCost);
            this.addVSITab.Controls.Add(this.vnd);
            this.addVSITab.Controls.Add(this.button1);
            this.addVSITab.Controls.Add(this.label4);
            this.addVSITab.Controls.Add(this.label3);
            this.addVSITab.Controls.Add(this.minQty);
            this.addVSITab.Controls.Add(this.label2);
            this.addVSITab.Controls.Add(this.label1);
            this.addVSITab.Controls.Add(this.vendorCb);
            this.addVSITab.Controls.Add(this.productCb);
            this.addVSITab.Location = new System.Drawing.Point(4, 22);
            this.addVSITab.Name = "addVSITab";
            this.addVSITab.Padding = new System.Windows.Forms.Padding(3);
            this.addVSITab.Size = new System.Drawing.Size(772, 324);
            this.addVSITab.TabIndex = 0;
            this.addVSITab.Text = "Add Vendor Source Item";
            this.addVSITab.UseVisualStyleBackColor = true;
            // 
            // unitCost
            // 
            this.unitCost.Location = new System.Drawing.Point(266, 58);
            this.unitCost.Name = "unitCost";
            this.unitCost.Size = new System.Drawing.Size(121, 20);
            this.unitCost.TabIndex = 10;
            // 
            // vnd
            // 
            this.vnd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.vnd.GridLines = true;
            this.vnd.Location = new System.Drawing.Point(18, 118);
            this.vnd.Name = "vnd";
            this.vnd.Size = new System.Drawing.Size(745, 182);
            this.vnd.TabIndex = 9;
            this.vnd.UseCompatibleStateImageBehavior = false;
            this.vnd.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ProductId";
            this.columnHeader2.Width = 77;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "VendorId";
            this.columnHeader3.Width = 82;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "MinQty";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "UnitCost";
            this.columnHeader5.Width = 112;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(422, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Add Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "UnitCost: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "MinQty: ";
            // 
            // minQty
            // 
            this.minQty.Location = new System.Drawing.Point(69, 61);
            this.minQty.Name = "minQty";
            this.minQty.Size = new System.Drawing.Size(120, 20);
            this.minQty.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vendor: ";
            // 
            // vendorCb
            // 
            this.vendorCb.FormattingEnabled = true;
            this.vendorCb.Location = new System.Drawing.Point(68, 18);
            this.vendorCb.Name = "vendorCb";
            this.vendorCb.Size = new System.Drawing.Size(121, 21);
            this.vendorCb.TabIndex = 1;
            this.vendorCb.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // productCb
            // 
            this.productCb.FormattingEnabled = true;
            this.productCb.Location = new System.Drawing.Point(266, 18);
            this.productCb.Name = "productCb";
            this.productCb.Size = new System.Drawing.Size(121, 21);
            this.productCb.TabIndex = 0;
            this.productCb.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(772, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(772, 324);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(108, 399);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(90, 23);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "Product";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnVendor
            // 
            this.btnVendor.Location = new System.Drawing.Point(12, 399);
            this.btnVendor.Name = "btnVendor";
            this.btnVendor.Size = new System.Drawing.Size(90, 23);
            this.btnVendor.TabIndex = 2;
            this.btnVendor.Text = "Vendor";
            this.btnVendor.UseVisualStyleBackColor = true;
            this.btnVendor.Click += new System.EventHandler(this.btnVendor_Click);
            // 
            // btnPressed
            // 
            this.btnPressed.Enabled = false;
            this.btnPressed.Location = new System.Drawing.Point(204, 399);
            this.btnPressed.Name = "btnPressed";
            this.btnPressed.Size = new System.Drawing.Size(90, 23);
            this.btnPressed.TabIndex = 3;
            this.btnPressed.Text = "Vendor Source";
            this.btnPressed.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(747, 402);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 23;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnShipping
            // 
            this.btnShipping.Location = new System.Drawing.Point(300, 399);
            this.btnShipping.Name = "btnShipping";
            this.btnShipping.Size = new System.Drawing.Size(75, 23);
            this.btnShipping.TabIndex = 24;
            this.btnShipping.Text = "Shipping";
            this.btnShipping.UseVisualStyleBackColor = true;
            this.btnShipping.Click += new System.EventHandler(this.btnShipping_Click);
            // 
            // FrmVendorSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 479);
            this.Controls.Add(this.btnShipping);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnPressed);
            this.Controls.Add(this.btnVendor);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.vendorSrcTab);
            this.Name = "FrmVendorSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vendor Source";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.vendorSrcTab.ResumeLayout(false);
            this.addVSITab.ResumeLayout(false);
            this.addVSITab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl vendorSrcTab;
        private System.Windows.Forms.TabPage addVSITab;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox vendorCb;
        private System.Windows.Forms.ComboBox productCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown minQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView vnd;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnVendor;
        private System.Windows.Forms.Button btnPressed;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox unitCost;
        private System.Windows.Forms.Button btnShipping;
    }
}

