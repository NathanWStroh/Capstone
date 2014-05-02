namespace com.Farouche
{
    partial class FrmAttachVendorSource
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
            this.btCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblVendor = new System.Windows.Forms.Label();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.lblCaseQty = new System.Windows.Forms.Label();
            this.nudUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.lblMinimum = new System.Windows.Forms.Label();
            this.nudCase = new System.Windows.Forms.NumericUpDown();
            this.nudMinnimum = new System.Windows.Forms.NumericUpDown();
            this.lblDisplayUnitPrice = new System.Windows.Forms.Label();
            this.comboVendors = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinnimum)).BeginInit();
            this.SuspendLayout();
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(75, 158);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 16;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAdd.Location = new System.Drawing.Point(156, 158);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Add Vendor";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(60, 38);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(44, 13);
            this.lblVendor.TabIndex = 18;
            this.lblVendor.Text = "Vendor:";
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(48, 65);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(56, 13);
            this.lblUnitPrice.TabIndex = 20;
            this.lblUnitPrice.Text = "Unit Price:";
            // 
            // lblCaseQty
            // 
            this.lblCaseQty.AutoSize = true;
            this.lblCaseQty.Location = new System.Drawing.Point(28, 116);
            this.lblCaseQty.Name = "lblCaseQty";
            this.lblCaseQty.Size = new System.Drawing.Size(76, 13);
            this.lblCaseQty.TabIndex = 21;
            this.lblCaseQty.Text = "Case Quantity:";
            // 
            // nudUnitPrice
            // 
            this.nudUnitPrice.DecimalPlaces = 2;
            this.nudUnitPrice.Location = new System.Drawing.Point(110, 62);
            this.nudUnitPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudUnitPrice.Name = "nudUnitPrice";
            this.nudUnitPrice.Size = new System.Drawing.Size(121, 20);
            this.nudUnitPrice.TabIndex = 45;
            this.nudUnitPrice.ThousandsSeparator = true;
            this.nudUnitPrice.ValueChanged += new System.EventHandler(this.nudUnitPrice_ValueChanged);
            // 
            // lblMinimum
            // 
            this.lblMinimum.AutoSize = true;
            this.lblMinimum.Location = new System.Drawing.Point(24, 90);
            this.lblMinimum.Name = "lblMinimum";
            this.lblMinimum.Size = new System.Drawing.Size(80, 13);
            this.lblMinimum.TabIndex = 48;
            this.lblMinimum.Text = "Minimum Order:";
            // 
            // nudCase
            // 
            this.nudCase.Location = new System.Drawing.Point(110, 114);
            this.nudCase.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudCase.Name = "nudCase";
            this.nudCase.Size = new System.Drawing.Size(121, 20);
            this.nudCase.TabIndex = 50;
            // 
            // nudMinnimum
            // 
            this.nudMinnimum.Location = new System.Drawing.Point(110, 88);
            this.nudMinnimum.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinnimum.Name = "nudMinnimum";
            this.nudMinnimum.Size = new System.Drawing.Size(121, 20);
            this.nudMinnimum.TabIndex = 49;
            // 
            // lblDisplayUnitPrice
            // 
            this.lblDisplayUnitPrice.AutoSize = true;
            this.lblDisplayUnitPrice.Location = new System.Drawing.Point(229, 65);
            this.lblDisplayUnitPrice.Name = "lblDisplayUnitPrice";
            this.lblDisplayUnitPrice.Size = new System.Drawing.Size(0, 13);
            this.lblDisplayUnitPrice.TabIndex = 51;
            // 
            // comboVendors
            // 
            this.comboVendors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVendors.FormattingEnabled = true;
            this.comboVendors.Location = new System.Drawing.Point(110, 35);
            this.comboVendors.Name = "comboVendors";
            this.comboVendors.Size = new System.Drawing.Size(121, 21);
            this.comboVendors.TabIndex = 52;
            // 
            // FrmAttachVendorSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 216);
            this.Controls.Add(this.comboVendors);
            this.Controls.Add(this.lblDisplayUnitPrice);
            this.Controls.Add(this.nudCase);
            this.Controls.Add(this.nudMinnimum);
            this.Controls.Add(this.lblMinimum);
            this.Controls.Add(this.nudUnitPrice);
            this.Controls.Add(this.lblCaseQty);
            this.Controls.Add(this.lblUnitPrice);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btCancel);
            this.Name = "FrmAttachVendorSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Attach Vendor";
            this.Load += new System.EventHandler(this.FrmAttachVendorSource_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinnimum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.Label lblCaseQty;
        private System.Windows.Forms.NumericUpDown nudUnitPrice;
        private System.Windows.Forms.Label lblMinimum;
        private System.Windows.Forms.NumericUpDown nudCase;
        private System.Windows.Forms.NumericUpDown nudMinnimum;
        private System.Windows.Forms.Label lblDisplayUnitPrice;
        private System.Windows.Forms.ComboBox comboVendors;
    }
}