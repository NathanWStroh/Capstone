namespace com.Farouche.Presentation
{
    partial class ProductView
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
            this.btMorph = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.lblItemName = new System.Windows.Forms.Label();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblWHSL = new System.Windows.Forms.Label();
            this.tbUnitPrice = new System.Windows.Forms.TextBox();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.comboWHSL = new System.Windows.Forms.ComboBox();
            this.lvVendor = new System.Windows.Forms.ListView();
            this.lblVendors = new System.Windows.Forms.Label();
            this.btAddVendor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btMorph
            // 
            this.btMorph.Location = new System.Drawing.Point(92, 272);
            this.btMorph.Name = "btMorph";
            this.btMorph.Size = new System.Drawing.Size(75, 23);
            this.btMorph.TabIndex = 0;
            this.btMorph.Text = "btMorph";
            this.btMorph.UseVisualStyleBackColor = true;
            this.btMorph.Click += new System.EventHandler(this.btMorph_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(9, 272);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 1;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(23, 38);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(61, 13);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "Item Name:";
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(90, 35);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(247, 20);
            this.tbItemName.TabIndex = 3;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(90, 61);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(247, 20);
            this.tbDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(21, 64);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(35, 90);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(52, 13);
            this.lblCategory.TabIndex = 6;
            this.lblCategory.Text = "Category:";
            // 
            // lblWHSL
            // 
            this.lblWHSL.AutoSize = true;
            this.lblWHSL.Location = new System.Drawing.Point(4, 117);
            this.lblWHSL.Name = "lblWHSL";
            this.lblWHSL.Size = new System.Drawing.Size(80, 13);
            this.lblWHSL.TabIndex = 8;
            this.lblWHSL.Text = "WHS Location:";
            // 
            // tbUnitPrice
            // 
            this.tbUnitPrice.Location = new System.Drawing.Point(90, 141);
            this.tbUnitPrice.Name = "tbUnitPrice";
            this.tbUnitPrice.Size = new System.Drawing.Size(89, 20);
            this.tbUnitPrice.TabIndex = 11;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(28, 144);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(56, 13);
            this.lblUnitPrice.TabIndex = 10;
            this.lblUnitPrice.Text = "Unit Price:";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(248, 141);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(89, 20);
            this.tbQuantity.TabIndex = 13;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(193, 144);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Quantity:";
            // 
            // tbProductID
            // 
            this.tbProductID.Location = new System.Drawing.Point(90, 9);
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.ReadOnly = true;
            this.tbProductID.Size = new System.Drawing.Size(77, 20);
            this.tbProductID.TabIndex = 15;
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(26, 12);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(58, 13);
            this.lblProductID.TabIndex = 14;
            this.lblProductID.Text = "Product ID";
            // 
            // comboCategory
            // 
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(90, 87);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(247, 21);
            this.comboCategory.TabIndex = 16;
            // 
            // comboWHSL
            // 
            this.comboWHSL.FormattingEnabled = true;
            this.comboWHSL.Location = new System.Drawing.Point(90, 114);
            this.comboWHSL.Name = "comboWHSL";
            this.comboWHSL.Size = new System.Drawing.Size(247, 21);
            this.comboWHSL.TabIndex = 17;
            // 
            // lvVendor
            // 
            this.lvVendor.FullRowSelect = true;
            this.lvVendor.GridLines = true;
            this.lvVendor.Location = new System.Drawing.Point(368, 21);
            this.lvVendor.Name = "lvVendor";
            this.lvVendor.Size = new System.Drawing.Size(455, 274);
            this.lvVendor.TabIndex = 18;
            this.lvVendor.UseCompatibleStateImageBehavior = false;
            this.lvVendor.SelectedIndexChanged += new System.EventHandler(this.lvVendor_SelectedIndexChanged);
            // 
            // lblVendors
            // 
            this.lblVendors.AutoSize = true;
            this.lblVendors.Location = new System.Drawing.Point(522, 5);
            this.lblVendors.Name = "lblVendors";
            this.lblVendors.Size = new System.Drawing.Size(144, 13);
            this.lblVendors.TabIndex = 19;
            this.lblVendors.Text = "Vendors Attached to Product";
            // 
            // btAddVendor
            // 
            this.btAddVendor.Enabled = false;
            this.btAddVendor.Location = new System.Drawing.Point(287, 272);
            this.btAddVendor.Name = "btAddVendor";
            this.btAddVendor.Size = new System.Drawing.Size(75, 23);
            this.btAddVendor.TabIndex = 20;
            this.btAddVendor.Text = "Add Vendor";
            this.btAddVendor.UseVisualStyleBackColor = true;
            this.btAddVendor.Click += new System.EventHandler(this.btAddVendor_Click);
            // 
            // ProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 307);
            this.Controls.Add(this.btAddVendor);
            this.Controls.Add(this.lblVendors);
            this.Controls.Add(this.lvVendor);
            this.Controls.Add(this.comboWHSL);
            this.Controls.Add(this.comboCategory);
            this.Controls.Add(this.tbProductID);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.tbUnitPrice);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.lblWHSL);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbItemName);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btMorph);
            this.Name = "ProductView";
            this.Text = "Product Window";
            this.Load += new System.EventHandler(this.ProductView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btMorph;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblWHSL;
        private System.Windows.Forms.TextBox tbUnitPrice;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.ComboBox comboWHSL;
        private System.Windows.Forms.ListView lvVendor;
        private System.Windows.Forms.Label lblVendors;
        private System.Windows.Forms.Button btAddVendor;
    }
}

