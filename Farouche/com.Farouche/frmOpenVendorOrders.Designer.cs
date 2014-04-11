namespace com.Farouche
{
    partial class frmOpenVendorOrders
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
            this.lvOpenVendorOrders = new System.Windows.Forms.ListView();
            this.lblGetAllOpenOrdersByVendor = new System.Windows.Forms.Label();
            this.cbGetVendorsById = new System.Windows.Forms.ComboBox();
            this.btngetAllOpenOrdersByVendor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvOpenVendorOrders
            // 
            this.lvOpenVendorOrders.GridLines = true;
            this.lvOpenVendorOrders.Location = new System.Drawing.Point(55, 54);
            this.lvOpenVendorOrders.Name = "lvOpenVendorOrders";
            this.lvOpenVendorOrders.Size = new System.Drawing.Size(645, 288);
            this.lvOpenVendorOrders.TabIndex = 0;
            this.lvOpenVendorOrders.UseCompatibleStateImageBehavior = false;
            this.lvOpenVendorOrders.View = System.Windows.Forms.View.Details;
            this.lvOpenVendorOrders.SelectedIndexChanged += new System.EventHandler(this.lvOpenVendorOrders_Click);
            // 
            // lblGetAllOpenOrdersByVendor
            // 
            this.lblGetAllOpenOrdersByVendor.AutoSize = true;
            this.lblGetAllOpenOrdersByVendor.Location = new System.Drawing.Point(35, 21);
            this.lblGetAllOpenOrdersByVendor.Name = "lblGetAllOpenOrdersByVendor";
            this.lblGetAllOpenOrdersByVendor.Size = new System.Drawing.Size(169, 13);
            this.lblGetAllOpenOrdersByVendor.TabIndex = 1;
            this.lblGetAllOpenOrdersByVendor.Text = "View All Open Orders by VendorID";
            // 
            // cbGetVendorsById
            // 
            this.cbGetVendorsById.FormattingEnabled = true;
            this.cbGetVendorsById.Location = new System.Drawing.Point(210, 18);
            this.cbGetVendorsById.Name = "cbGetVendorsById";
            this.cbGetVendorsById.Size = new System.Drawing.Size(121, 21);
            this.cbGetVendorsById.TabIndex = 2;
            this.cbGetVendorsById.SelectedIndexChanged += new System.EventHandler(this.cbGetVendorsById_SelectedIndexChanged);
            // 
            // btngetAllOpenOrdersByVendor
            // 
            this.btngetAllOpenOrdersByVendor.Location = new System.Drawing.Point(356, 18);
            this.btngetAllOpenOrdersByVendor.Name = "btngetAllOpenOrdersByVendor";
            this.btngetAllOpenOrdersByVendor.Size = new System.Drawing.Size(135, 23);
            this.btngetAllOpenOrdersByVendor.TabIndex = 3;
            this.btngetAllOpenOrdersByVendor.Text = "Get Vendor Orders";
            this.btngetAllOpenOrdersByVendor.UseVisualStyleBackColor = true;
            this.btngetAllOpenOrdersByVendor.Click += new System.EventHandler(this.btngetAllOpenOrdersByVendor_Click);
            // 
            // frmOpenVendorOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 379);
            this.Controls.Add(this.btngetAllOpenOrdersByVendor);
            this.Controls.Add(this.cbGetVendorsById);
            this.Controls.Add(this.lblGetAllOpenOrdersByVendor);
            this.Controls.Add(this.lvOpenVendorOrders);
            this.Name = "frmOpenVendorOrders";
            this.Text = "Open Vendor Orders";
            this.Load += new System.EventHandler(this.frmOpenVendorOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvOpenVendorOrders;
        private System.Windows.Forms.Label lblGetAllOpenOrdersByVendor;
        private System.Windows.Forms.ComboBox cbGetVendorsById;
        private System.Windows.Forms.Button btngetAllOpenOrdersByVendor;
    }
}