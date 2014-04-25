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
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.tbProductID = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.comboWHSL = new System.Windows.Forms.ComboBox();
            this.lblVendors = new System.Windows.Forms.Label();
            this.btAddVendor = new System.Windows.Forms.Button();
            this.lblOnHand = new System.Windows.Forms.Label();
            this.lblReorderAmount = new System.Windows.Forms.Label();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.lblOnOrder = new System.Windows.Forms.Label();
            this.cbActive = new System.Windows.Forms.ComboBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.txtDimensions = new System.Windows.Forms.TextBox();
            this.lblDimensions = new System.Windows.Forms.Label();
            this.lblShippingWeight = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblShippingInfo = new System.Windows.Forms.Label();
            this.lblProductInfo = new System.Windows.Forms.Label();
            this.nudAvailableQty = new System.Windows.Forms.NumericUpDown();
            this.nudOnHandQty = new System.Windows.Forms.NumericUpDown();
            this.nudReorderThreshold = new System.Windows.Forms.NumericUpDown();
            this.nudReorderAmount = new System.Windows.Forms.NumericUpDown();
            this.nudOnOrderAmount = new System.Windows.Forms.NumericUpDown();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.nudUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.lblPriceDisplay = new System.Windows.Forms.Label();
            this.lblWeightDisplay = new System.Windows.Forms.Label();
            this.lvVendors = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvailableQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOnHandQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReorderThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReorderAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOnOrderAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).BeginInit();
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
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(61, 131);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(56, 13);
            this.lblUnitPrice.TabIndex = 10;
            this.lblUnitPrice.Text = "Unit Price:";
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
            // lblReorderAmount
            // 
            this.lblReorderAmount.AutoSize = true;
            this.lblReorderAmount.Location = new System.Drawing.Point(30, 235);
            this.lblReorderAmount.Name = "lblReorderAmount";
            this.lblReorderAmount.Size = new System.Drawing.Size(87, 13);
            this.lblReorderAmount.TabIndex = 25;
            this.lblReorderAmount.Text = "Reorder Amount:";
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
            // nudAvailableQty
            // 
            this.nudAvailableQty.Location = new System.Drawing.Point(123, 154);
            this.nudAvailableQty.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAvailableQty.Name = "nudAvailableQty";
            this.nudAvailableQty.Size = new System.Drawing.Size(120, 20);
            this.nudAvailableQty.TabIndex = 37;
            // 
            // nudOnHandQty
            // 
            this.nudOnHandQty.Location = new System.Drawing.Point(123, 180);
            this.nudOnHandQty.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudOnHandQty.Name = "nudOnHandQty";
            this.nudOnHandQty.Size = new System.Drawing.Size(120, 20);
            this.nudOnHandQty.TabIndex = 38;
            // 
            // nudReorderThreshold
            // 
            this.nudReorderThreshold.Location = new System.Drawing.Point(123, 206);
            this.nudReorderThreshold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudReorderThreshold.Name = "nudReorderThreshold";
            this.nudReorderThreshold.Size = new System.Drawing.Size(120, 20);
            this.nudReorderThreshold.TabIndex = 39;
            // 
            // nudReorderAmount
            // 
            this.nudReorderAmount.Location = new System.Drawing.Point(123, 232);
            this.nudReorderAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudReorderAmount.Name = "nudReorderAmount";
            this.nudReorderAmount.Size = new System.Drawing.Size(120, 20);
            this.nudReorderAmount.TabIndex = 40;
            // 
            // nudOnOrderAmount
            // 
            this.nudOnOrderAmount.Location = new System.Drawing.Point(123, 258);
            this.nudOnOrderAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudOnOrderAmount.Name = "nudOnOrderAmount";
            this.nudOnOrderAmount.Size = new System.Drawing.Size(120, 20);
            this.nudOnOrderAmount.TabIndex = 41;
            // 
            // nudWeight
            // 
            this.nudWeight.DecimalPlaces = 2;
            this.nudWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudWeight.Location = new System.Drawing.Point(500, 77);
            this.nudWeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(120, 20);
            this.nudWeight.TabIndex = 42;
            this.nudWeight.ValueChanged += new System.EventHandler(this.nudWeight_ValueChanged);
            // 
            // nudUnitPrice
            // 
            this.nudUnitPrice.DecimalPlaces = 2;
            this.nudUnitPrice.Location = new System.Drawing.Point(123, 129);
            this.nudUnitPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudUnitPrice.Name = "nudUnitPrice";
            this.nudUnitPrice.Size = new System.Drawing.Size(120, 20);
            this.nudUnitPrice.TabIndex = 44;
            this.nudUnitPrice.ValueChanged += new System.EventHandler(this.nudUnitPrice_ValueChanged);
            // 
            // lblPriceDisplay
            // 
            this.lblPriceDisplay.AutoSize = true;
            this.lblPriceDisplay.Location = new System.Drawing.Point(250, 131);
            this.lblPriceDisplay.Name = "lblPriceDisplay";
            this.lblPriceDisplay.Size = new System.Drawing.Size(0, 13);
            this.lblPriceDisplay.TabIndex = 43;
            // 
            // lblWeightDisplay
            // 
            this.lblWeightDisplay.AutoSize = true;
            this.lblWeightDisplay.Location = new System.Drawing.Point(626, 79);
            this.lblWeightDisplay.Name = "lblWeightDisplay";
            this.lblWeightDisplay.Size = new System.Drawing.Size(0, 13);
            this.lblWeightDisplay.TabIndex = 45;
            // 
            // lvVendors
            // 
            this.lvVendors.FullRowSelect = true;
            this.lvVendors.GridLines = true;
            this.lvVendors.Location = new System.Drawing.Point(389, 157);
            this.lvVendors.MultiSelect = false;
            this.lvVendors.Name = "lvVendors";
            this.lvVendors.Size = new System.Drawing.Size(358, 154);
            this.lvVendors.TabIndex = 46;
            this.lvVendors.UseCompatibleStateImageBehavior = false;
            this.lvVendors.View = System.Windows.Forms.View.Details;
            // 
            // ProductView
            // 
            this.AcceptButton = this.btMorph;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(769, 366);
            this.Controls.Add(this.lvVendors);
            this.Controls.Add(this.lblWeightDisplay);
            this.Controls.Add(this.nudUnitPrice);
            this.Controls.Add(this.lblPriceDisplay);
            this.Controls.Add(this.nudWeight);
            this.Controls.Add(this.nudOnOrderAmount);
            this.Controls.Add(this.nudReorderAmount);
            this.Controls.Add(this.nudReorderThreshold);
            this.Controls.Add(this.nudOnHandQty);
            this.Controls.Add(this.nudAvailableQty);
            this.Controls.Add(this.lblProductInfo);
            this.Controls.Add(this.lblShippingInfo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblShippingWeight);
            this.Controls.Add(this.txtDimensions);
            this.Controls.Add(this.lblDimensions);
            this.Controls.Add(this.cbActive);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.lblOnOrder);
            this.Controls.Add(this.lblReorderAmount);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.lblOnHand);
            this.Controls.Add(this.btAddVendor);
            this.Controls.Add(this.lblVendors);
            this.Controls.Add(this.comboWHSL);
            this.Controls.Add(this.tbProductID);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.lblQuantity);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProductView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.nudAvailableQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOnHandQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReorderThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudReorderAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOnOrderAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).EndInit();
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
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox tbProductID;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.ComboBox comboWHSL;
        private System.Windows.Forms.Label lblVendors;
        private System.Windows.Forms.Button btAddVendor;
        private System.Windows.Forms.Label lblOnHand;
        private System.Windows.Forms.Label lblReorderAmount;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Label lblOnOrder;
        private System.Windows.Forms.ComboBox cbActive;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.TextBox txtDimensions;
        private System.Windows.Forms.Label lblDimensions;
        private System.Windows.Forms.Label lblShippingWeight;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblShippingInfo;
        private System.Windows.Forms.Label lblProductInfo;
        private System.Windows.Forms.NumericUpDown nudAvailableQty;
        private System.Windows.Forms.NumericUpDown nudOnHandQty;
        private System.Windows.Forms.NumericUpDown nudReorderThreshold;
        private System.Windows.Forms.NumericUpDown nudReorderAmount;
        private System.Windows.Forms.NumericUpDown nudOnOrderAmount;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.NumericUpDown nudUnitPrice;
        private System.Windows.Forms.Label lblPriceDisplay;
        private System.Windows.Forms.Label lblWeightDisplay;
        private System.Windows.Forms.ListView lvVendors;
    }
}