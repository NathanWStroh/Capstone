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
            this.components = new System.ComponentModel.Container();
            this.tbOrderDate = new System.Windows.Forms.TextBox();
            this.comboVendor = new System.Windows.Forms.ComboBox();
            this.comboShipments = new System.Windows.Forms.ComboBox();
            this.lblShippments = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.btSaveOrder = new System.Windows.Forms.Button();
            this.lblVendor = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btAddLineItem = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.lblVendorHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.comboProduct = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.comboQuanity = new System.Windows.Forms.ComboBox();
            this.lvOrderItems = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // tbOrderDate
            // 
            this.tbOrderDate.Location = new System.Drawing.Point(445, 9);
            this.tbOrderDate.Name = "tbOrderDate";
            this.tbOrderDate.ReadOnly = true;
            this.tbOrderDate.Size = new System.Drawing.Size(131, 20);
            this.tbOrderDate.TabIndex = 13;
            // 
            // comboVendor
            // 
            this.comboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVendor.FormattingEnabled = true;
            this.comboVendor.Location = new System.Drawing.Point(64, 35);
            this.comboVendor.Name = "comboVendor";
            this.comboVendor.Size = new System.Drawing.Size(131, 21);
            this.comboVendor.TabIndex = 15;
            this.comboVendor.SelectedIndexChanged += new System.EventHandler(this.comboVendor_SelectedIndexChanged);
            // 
            // comboShipments
            // 
            this.comboShipments.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboShipments.FormattingEnabled = true;
            this.comboShipments.Location = new System.Drawing.Point(263, 35);
            this.comboShipments.Name = "comboShipments";
            this.comboShipments.Size = new System.Drawing.Size(41, 21);
            this.comboShipments.TabIndex = 16;
            // 
            // lblShippments
            // 
            this.lblShippments.AutoSize = true;
            this.lblShippments.Location = new System.Drawing.Point(201, 38);
            this.lblShippments.Name = "lblShippments";
            this.lblShippments.Size = new System.Drawing.Size(56, 13);
            this.lblShippments.TabIndex = 17;
            this.lblShippments.Text = "Shipments";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(388, 11);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(56, 13);
            this.lblOrderDate.TabIndex = 19;
            this.lblOrderDate.Text = "OrderDate";
            // 
            // btSaveOrder
            // 
            this.btSaveOrder.Location = new System.Drawing.Point(498, 304);
            this.btSaveOrder.Name = "btSaveOrder";
            this.btSaveOrder.Size = new System.Drawing.Size(78, 23);
            this.btSaveOrder.TabIndex = 20;
            this.btSaveOrder.Text = "Save Order";
            this.btSaveOrder.UseVisualStyleBackColor = true;
            this.btSaveOrder.Click += new System.EventHandler(this.btSaveOrder_Click);
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(17, 38);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(41, 13);
            this.lblVendor.TabIndex = 21;
            this.lblVendor.Text = "Vendor";
            // 
            // btAddLineItem
            // 
            this.btAddLineItem.Location = new System.Drawing.Point(298, 109);
            this.btAddLineItem.Name = "btAddLineItem";
            this.btAddLineItem.Size = new System.Drawing.Size(75, 23);
            this.btAddLineItem.TabIndex = 9;
            this.btAddLineItem.Text = "Add Item";
            this.toolTip1.SetToolTip(this.btAddLineItem, "Add an item to the order.");
            this.btAddLineItem.UseVisualStyleBackColor = true;
            this.btAddLineItem.Click += new System.EventHandler(this.btAddLineItem_Click);
            // 
            // btRemove
            // 
            this.btRemove.Enabled = false;
            this.btRemove.Location = new System.Drawing.Point(498, 143);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(78, 23);
            this.btRemove.TabIndex = 29;
            this.btRemove.Text = "Remove Item";
            this.toolTip1.SetToolTip(this.btRemove, "Remove selected item from the list.");
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
            // 
            // lblVendorHeader
            // 
            this.lblVendorHeader.AutoSize = true;
            this.lblVendorHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendorHeader.Location = new System.Drawing.Point(16, 9);
            this.lblVendorHeader.Name = "lblVendorHeader";
            this.lblVendorHeader.Size = new System.Drawing.Size(164, 20);
            this.lblVendorHeader.TabIndex = 24;
            this.lblVendorHeader.Text = "Vendor Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Product Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(343, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Total Order Price:";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(499, 341);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(13, 13);
            this.lblPrice.TabIndex = 27;
            this.lblPrice.Text = "$";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(17, 112);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(44, 13);
            this.lblProduct.TabIndex = 22;
            this.lblProduct.Text = "Product";
            // 
            // comboProduct
            // 
            this.comboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProduct.FormattingEnabled = true;
            this.comboProduct.Location = new System.Drawing.Point(63, 109);
            this.comboProduct.Name = "comboProduct";
            this.comboProduct.Size = new System.Drawing.Size(121, 21);
            this.comboProduct.TabIndex = 11;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(190, 112);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 23;
            this.lblQuantity.Text = "Quantity";
            // 
            // comboQuanity
            // 
            this.comboQuanity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQuanity.FormattingEnabled = true;
            this.comboQuanity.Location = new System.Drawing.Point(242, 109);
            this.comboQuanity.Name = "comboQuanity";
            this.comboQuanity.Size = new System.Drawing.Size(41, 21);
            this.comboQuanity.TabIndex = 18;
            // 
            // lvOrderItems
            // 
            this.lvOrderItems.FullRowSelect = true;
            this.lvOrderItems.GridLines = true;
            this.lvOrderItems.Location = new System.Drawing.Point(20, 143);
            this.lvOrderItems.Name = "lvOrderItems";
            this.lvOrderItems.Size = new System.Drawing.Size(472, 184);
            this.lvOrderItems.TabIndex = 28;
            this.lvOrderItems.UseCompatibleStateImageBehavior = false;
            this.lvOrderItems.View = System.Windows.Forms.View.Details;
            this.lvOrderItems.SelectedIndexChanged += new System.EventHandler(this.lvOrderItems_SelectedIndexChanged);
            // 
            // frmVendorCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 406);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.lvOrderItems);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblVendorHeader);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.btSaveOrder);
            this.Controls.Add(this.lblOrderDate);
            this.Controls.Add(this.comboQuanity);
            this.Controls.Add(this.lblShippments);
            this.Controls.Add(this.comboShipments);
            this.Controls.Add(this.comboVendor);
            this.Controls.Add(this.tbOrderDate);
            this.Controls.Add(this.comboProduct);
            this.Controls.Add(this.btAddLineItem);
            this.Name = "frmVendorCreateOrder";
            this.Text = "Create Order View";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVendorCreateOrder_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbOrderDate;
        private System.Windows.Forms.ComboBox comboVendor;
        private System.Windows.Forms.ComboBox comboShipments;
        private System.Windows.Forms.Label lblShippments;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Button btSaveOrder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblVendorHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.ComboBox comboProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.ComboBox comboQuanity;
        private System.Windows.Forms.Button btAddLineItem;
        private System.Windows.Forms.ListView lvOrderItems;
        private System.Windows.Forms.Button btRemove;

    }
}