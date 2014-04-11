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
            this.lblWHSL = new System.Windows.Forms.Label();
            this.tbUnitPrice = new System.Windows.Forms.TextBox();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.tbQuantity = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.comboWHSL = new System.Windows.Forms.ComboBox();
            this.lvVendor = new System.Windows.Forms.ListView();
            this.lblVendors = new System.Windows.Forms.Label();
            this.btAddVendor = new System.Windows.Forms.Button();
            this.lblOnHand = new System.Windows.Forms.Label();
            this.txtOnHand = new System.Windows.Forms.TextBox();
            this.txtReorder = new System.Windows.Forms.TextBox();
            this.lblReorderAmount = new System.Windows.Forms.Label();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.txtOnOrder = new System.Windows.Forms.TextBox();
            this.lblOnOrder = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.ComboBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.txtDimensions = new System.Windows.Forms.TextBox();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblShippingWeight = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblShippingInfo = new System.Windows.Forms.Label();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btMorph
            // 
            this.btMorph.Location = new System.Drawing.Point(295, 323);
            this.btMorph.Name = "btMorph";
            this.btMorph.Size = new System.Drawing.Size(75, 23);
            this.btMorph.TabIndex = 17;
            this.btMorph.Text = "btMorph";
            this.btMorph.UseVisualStyleBackColor = true;
            this.btMorph.Click += new System.EventHandler(this.btMorph_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(123, 323);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 15;
            this.btClose.Text = "Cancel";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(26, 79);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(91, 13);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "Short Description:";
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(123, 76);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(247, 20);
            this.tbItemName.TabIndex = 2;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(123, 102);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(247, 20);
            this.tbDescription.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(54, 105);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description:";
            // 
            // lblWHSL
            // 
            this.lblWHSL.AutoSize = true;
            this.lblWHSL.Location = new System.Drawing.Point(414, 53);
            this.lblWHSL.Name = "lblWHSL";
            this.lblWHSL.Size = new System.Drawing.Size(80, 13);
            this.lblWHSL.TabIndex = 8;
            this.lblWHSL.Text = "WHS Location:";
            // 
            // tbUnitPrice
            // 
            this.tbUnitPrice.Location = new System.Drawing.Point(123, 128);
            this.tbUnitPrice.Name = "tbUnitPrice";
            this.tbUnitPrice.Size = new System.Drawing.Size(121, 20);
            this.tbUnitPrice.TabIndex = 4;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(61, 131);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(56, 13);
            this.lblUnitPrice.TabIndex = 10;
            this.lblUnitPrice.Text = "Unit Price:";
            // 
            // tbQuantity
            // 
            this.tbQuantity.Location = new System.Drawing.Point(123, 154);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new System.Drawing.Size(121, 20);
            this.tbQuantity.TabIndex = 5;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(45, 157);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(72, 13);
            this.lblQuantity.TabIndex = 12;
            this.lblQuantity.Text = "Available Qty:";
            // 
            // tbProductID
            // 
            this.tbProductID.Location = new System.Drawing.Point(123, 50);
            this.tbProductID.Name = "tbProductID";
            this.tbProductID.ReadOnly = true;
            this.tbProductID.Size = new System.Drawing.Size(247, 20);
            this.tbProductID.TabIndex = 1;
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(56, 53);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(61, 13);
            this.lblProductID.TabIndex = 14;
            this.lblProductID.Text = "Product ID:";
            // 
            // comboWHSL
            // 
            this.comboWHSL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWHSL.FormattingEnabled = true;
            this.comboWHSL.Location = new System.Drawing.Point(500, 50);
            this.comboWHSL.Name = "comboWHSL";
            this.comboWHSL.Size = new System.Drawing.Size(247, 21);
            this.comboWHSL.TabIndex = 11;
            // 
            // lvVendor
            // 
            this.lvVendor.FullRowSelect = true;
            this.lvVendor.GridLines = true;
            this.lvVendor.Location = new System.Drawing.Point(389, 151);
            this.lvVendor.Name = "lvVendor";
            this.lvVendor.Size = new System.Drawing.Size(358, 154);
            this.lvVendor.TabIndex = 14;
            this.lvVendor.UseCompatibleStateImageBehavior = false;
            this.lvVendor.SelectedIndexChanged += new System.EventHandler(this.lvVendor_SelectedIndexChanged);
            // 
            // lblVendors
            // 
            this.lblVendors.AutoSize = true;
            this.lblVendors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendors.Location = new System.Drawing.Point(386, 135);
            this.lblVendors.Name = "lblVendors";
            this.lblVendors.Size = new System.Drawing.Size(205, 13);
            this.lblVendors.TabIndex = 19;
            this.lblVendors.Text = "Vendors Attached To The Product:";
            // 
            // btAddVendor
            // 
            this.btAddVendor.Enabled = false;
            this.btAddVendor.Location = new System.Drawing.Point(500, 323);
            this.btAddVendor.Name = "btAddVendor";
            this.btAddVendor.Size = new System.Drawing.Size(129, 23);
            this.btAddVendor.TabIndex = 18;
            this.btAddVendor.Text = "Add Vendor To Product";
            this.btAddVendor.UseVisualStyleBackColor = true;
            this.btAddVendor.Click += new System.EventHandler(this.btAddVendor_Click);
            // 
            // lblOnHand
            // 
            this.lblOnHand.AutoSize = true;
            this.lblOnHand.Location = new System.Drawing.Point(48, 183);
            this.lblOnHand.Name = "lblOnHand";
            this.lblOnHand.Size = new System.Drawing.Size(69, 13);
            this.lblOnHand.TabIndex = 21;
            this.lblOnHand.Text = "OnHand Qty:";
            // 
            // txtOnHand
            // 
            this.txtOnHand.Location = new System.Drawing.Point(123, 180);
            this.txtOnHand.Name = "txtOnHand";
            this.txtOnHand.Size = new System.Drawing.Size(121, 20);
            this.txtOnHand.TabIndex = 6;
            // 
            // txtReorder
            // 
            this.txtReorder.Location = new System.Drawing.Point(123, 232);
            this.txtReorder.Name = "txtReorder";
            this.txtReorder.Size = new System.Drawing.Size(121, 20);
            this.txtReorder.TabIndex = 8;
            // 
            // lblReorderAmount
            // 
            this.lblReorderAmount.AutoSize = true;
            this.lblReorderAmount.Location = new System.Drawing.Point(30, 235);
            this.lblReorderAmount.Name = "lblReorderAmount";
            this.lblReorderAmount.Size = new System.Drawing.Size(87, 13);
            this.lblReorderAmount.TabIndex = 25;
            this.lblReorderAmount.Text = "Reorder Amount:";
            // 
            // txtThreshold
            // 
            this.txtThreshold.Location = new System.Drawing.Point(123, 206);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(121, 20);
            this.txtThreshold.TabIndex = 7;
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Location = new System.Drawing.Point(19, 209);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(98, 13);
            this.lblThreshold.TabIndex = 23;
            this.lblThreshold.Text = "Reorder Threshold:";
            // 
            // txtOnOrder
            // 
            this.txtOnOrder.Location = new System.Drawing.Point(123, 258);
            this.txtOnOrder.Name = "txtOnOrder";
            this.txtOnOrder.Size = new System.Drawing.Size(121, 20);
            this.txtOnOrder.TabIndex = 9;
            // 
            // lblOnOrder
            // 
            this.lblOnOrder.AutoSize = true;
            this.lblOnOrder.Location = new System.Drawing.Point(25, 261);
            this.lblOnOrder.Name = "lblOnOrder";
            this.lblOnOrder.Size = new System.Drawing.Size(92, 13);
            this.lblOnOrder.TabIndex = 27;
            this.lblOnOrder.Text = "On Order Amount:";
            // 
            // cbActive
            // 
            this.cbActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActive.FormattingEnabled = true;
            this.cbActive.Location = new System.Drawing.Point(123, 284);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(121, 21);
            this.cbActive.TabIndex = 10;
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(77, 287);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(40, 13);
            this.lblActive.TabIndex = 29;
            this.lblActive.Text = "Active:";
            // 
            // txtDimensions
            // 
            this.txtDimensions.Location = new System.Drawing.Point(500, 103);
            this.txtDimensions.Name = "txtDimensions";
            this.txtDimensions.Size = new System.Drawing.Size(247, 20);
            this.txtDimensions.TabIndex = 13;
            // 
            // lblDimensions
            // 
            this.lblDimensions.AutoSize = true;
            this.lblDimensions.Location = new System.Drawing.Point(386, 106);
            this.lblDimensions.Name = "lblDimensions";
            this.lblDimensions.Size = new System.Drawing.Size(108, 13);
            this.lblDimensions.TabIndex = 31;
            this.lblDimensions.Text = "Shipping Dimensions:";
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(500, 77);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(247, 20);
            this.txtWeight.TabIndex = 12;
            // 
            // lblShippingWeight
            // 
            this.lblShippingWeight.AutoSize = true;
            this.lblShippingWeight.Location = new System.Drawing.Point(406, 80);
            this.lblShippingWeight.Name = "lblShippingWeight";
            this.lblShippingWeight.Size = new System.Drawing.Size(88, 13);
            this.lblShippingWeight.TabIndex = 33;
            this.lblShippingWeight.Text = "Shipping Weight:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(209, 323);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblShippingInfo
            // 
            this.lblShippingInfo.AutoSize = true;
            this.lblShippingInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShippingInfo.Location = new System.Drawing.Point(497, 25);
            this.lblShippingInfo.Name = "lblShippingInfo";
            this.lblShippingInfo.Size = new System.Drawing.Size(149, 16);
            this.lblShippingInfo.TabIndex = 34;
            this.lblShippingInfo.Text = "Shipping Information";
            // 
            // lblProductInfo
            // 
            this.lblProductInfo.AutoSize = true;
            this.lblProductInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductInfo.Location = new System.Drawing.Point(120, 25);
            this.lblProductInfo.Name = "lblProductInfo";
            this.lblProductInfo.Size = new System.Drawing.Size(141, 16);
            this.lblProductInfo.TabIndex = 35;
            this.lblProductInfo.Text = "Product Information";
            // 
            // ProductView
            // 
            this.AcceptButton = this.btMorph;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(769, 366);
            this.Controls.Add(this.lblProductInfo);
            this.Controls.Add(this.lblShippingInfo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.lblShippingWeight);
            this.Controls.Add(this.txtDimensions);
            this.Controls.Add(this.lblDimensions);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.txtOnOrder);
            this.Controls.Add(this.lblOnOrder);
            this.Controls.Add(this.txtReorder);
            this.Controls.Add(this.lblReorderAmount);
            this.Controls.Add(this.txtThreshold);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.txtOnHand);
            this.Controls.Add(this.lblOnHand);
            this.Controls.Add(this.btAddVendor);
            this.Controls.Add(this.lblVendors);
            this.Controls.Add(this.lvVendor);
            this.Controls.Add(this.comboWHSL);
            this.Controls.Add(this.tbProductID);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.tbQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.tbUnitPrice);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.lblWHSL);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbItemName);
            this.Controls.Add(this.lblItemName);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btMorph);
            this.Name = "ProductView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Product Window";
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
        private System.Windows.Forms.Label lblWHSL;
        private System.Windows.Forms.TextBox tbUnitPrice;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox tbQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.ComboBox comboWHSL;
        private System.Windows.Forms.ListView lvVendor;
        private System.Windows.Forms.Label lblVendors;
        private System.Windows.Forms.Button btAddVendor;
        private System.Windows.Forms.Label lblOnHand;
        private System.Windows.Forms.TextBox txtOnHand;
        private System.Windows.Forms.TextBox txtReorder;
        private System.Windows.Forms.Label lblReorderAmount;
        private System.Windows.Forms.TextBox txtThreshold;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.TextBox txtOnOrder;
        private System.Windows.Forms.Label lblOnOrder;
        private System.Windows.Forms.ComboBox cbActive;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.TextBox txtDimensions;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblShippingWeight;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblShippingInfo;
        private System.Windows.Forms.Label lblProductInfo;
    }
}