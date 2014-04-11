namespace com.Farouche.Presentation
{
    partial class frmVendorCreateOrder
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
            this.comboProduct = new System.Windows.Forms.ComboBox();
            this.btAddLineItem = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.btAddNewProduct = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tbOrderDate = new System.Windows.Forms.TextBox();
            this.comboVendor = new System.Windows.Forms.ComboBox();
            this.comboShipments = new System.Windows.Forms.ComboBox();
            this.lblShippments = new System.Windows.Forms.Label();
            this.comboQuanity = new System.Windows.Forms.ComboBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.btSaveOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboProduct
            // 
            this.comboProduct.FormattingEnabled = true;
            this.comboProduct.Location = new System.Drawing.Point(174, 72);
            this.comboProduct.Name = "comboProduct";
            this.comboProduct.Size = new System.Drawing.Size(121, 21);
            this.comboProduct.TabIndex = 11;
            // 
            // btAddLineItem
            // 
            this.btAddLineItem.Enabled = false;
            this.btAddLineItem.Location = new System.Drawing.Point(418, 70);
            this.btAddLineItem.Name = "btAddLineItem";
            this.btAddLineItem.Size = new System.Drawing.Size(75, 23);
            this.btAddLineItem.TabIndex = 9;
            this.btAddLineItem.Text = "Add Item";
            this.btAddLineItem.UseVisualStyleBackColor = true;
            this.btAddLineItem.Click += new System.EventHandler(this.btAddLineItem_Click);
            // 
            // btRemove
            // 
            this.btRemove.Enabled = false;
            this.btRemove.Location = new System.Drawing.Point(577, 99);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(94, 23);
            this.btRemove.TabIndex = 8;
            this.btRemove.Text = "Remove Line";
            this.btRemove.UseVisualStyleBackColor = true;
            // 
            // btAddNewProduct
            // 
            this.btAddNewProduct.Location = new System.Drawing.Point(14, 99);
            this.btAddNewProduct.Name = "btAddNewProduct";
            this.btAddNewProduct.Size = new System.Drawing.Size(75, 23);
            this.btAddNewProduct.TabIndex = 6;
            this.btAddNewProduct.Text = "Add Product";
            this.btAddNewProduct.UseVisualStyleBackColor = true;
            this.btAddNewProduct.Click += new System.EventHandler(this.btAddNewProduct_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(95, 99);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(476, 243);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // tbOrderDate
            // 
            this.tbOrderDate.Location = new System.Drawing.Point(490, 11);
            this.tbOrderDate.Name = "tbOrderDate";
            this.tbOrderDate.Size = new System.Drawing.Size(100, 20);
            this.tbOrderDate.TabIndex = 13;
            // 
            // comboVendor
            // 
            this.comboVendor.FormattingEnabled = true;
            this.comboVendor.Location = new System.Drawing.Point(95, 11);
            this.comboVendor.Name = "comboVendor";
            this.comboVendor.Size = new System.Drawing.Size(121, 21);
            this.comboVendor.TabIndex = 15;
            // 
            // comboShipments
            // 
            this.comboShipments.FormattingEnabled = true;
            this.comboShipments.Location = new System.Drawing.Point(317, 11);
            this.comboShipments.Name = "comboShipments";
            this.comboShipments.Size = new System.Drawing.Size(41, 21);
            this.comboShipments.TabIndex = 16;
            // 
            // lblShippments
            // 
            this.lblShippments.AutoSize = true;
            this.lblShippments.Location = new System.Drawing.Point(255, 15);
            this.lblShippments.Name = "lblShippments";
            this.lblShippments.Size = new System.Drawing.Size(56, 13);
            this.lblShippments.TabIndex = 17;
            this.lblShippments.Text = "Shipments";
            // 
            // comboQuanity
            // 
            this.comboQuanity.FormattingEnabled = true;
            this.comboQuanity.Location = new System.Drawing.Point(337, 72);
            this.comboQuanity.Name = "comboQuanity";
            this.comboQuanity.Size = new System.Drawing.Size(41, 21);
            this.comboQuanity.TabIndex = 18;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(428, 14);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(56, 13);
            this.lblOrderDate.TabIndex = 19;
            this.lblOrderDate.Text = "OrderDate";
            // 
            // btSaveOrder
            // 
            this.btSaveOrder.Location = new System.Drawing.Point(577, 319);
            this.btSaveOrder.Name = "btSaveOrder";
            this.btSaveOrder.Size = new System.Drawing.Size(94, 23);
            this.btSaveOrder.TabIndex = 20;
            this.btSaveOrder.Text = "Save Order";
            this.btSaveOrder.UseVisualStyleBackColor = true;
            // 
            // frmVendorCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 364);
            this.Controls.Add(this.btSaveOrder);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.comboQuanity);
            this.Controls.Add(this.lblShippments);
            this.Controls.Add(this.comboShipments);
            this.Controls.Add(this.comboVendor);
            this.Controls.Add(this.tbOrderDate);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.comboProduct);
            this.Controls.Add(this.btAddLineItem);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAddNewProduct);
            this.Name = "frmVendorCreateOrder";
            this.Text = "Create Order View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboProduct;
        private System.Windows.Forms.Button btAddLineItem;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.Button btAddNewProduct;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox tbOrderDate;
        private System.Windows.Forms.ComboBox comboVendor;
        private System.Windows.Forms.ComboBox comboShipments;
        private System.Windows.Forms.Label lblShippments;
        private System.Windows.Forms.ComboBox comboQuanity;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Button btSaveOrder;

    }
}