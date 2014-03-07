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
            this.listView1 = new System.Windows.Forms.ListView();
            this.chVendorOrderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVendorName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDateOrdered = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumberOfShipments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblGetAllOpenOrdersByVendor = new System.Windows.Forms.Label();
            this.cbGetVendorsByName = new System.Windows.Forms.ComboBox();
            this.btngetAllOpenOrdersByVendor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chVendorOrderID,
            this.chVendorName,
            this.chDateOrdered,
            this.chNumberOfShipments});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(53, 54);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(645, 288);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // chVendorOrderID
            // 
            this.chVendorOrderID.Text = "Vendor Order ID";
            this.chVendorOrderID.Width = 114;
            // 
            // chVendorName
            // 
            this.chVendorName.Text = "Vendor Name";
            this.chVendorName.Width = 85;
            // 
            // chDateOrdered
            // 
            this.chDateOrdered.Text = "Date Ordered";
            this.chDateOrdered.Width = 104;
            // 
            // chNumberOfShipments
            // 
            this.chNumberOfShipments.Text = "Number of Shipments";
            this.chNumberOfShipments.Width = 153;
            // 
            // lblGetAllOpenOrdersByVendor
            // 
            this.lblGetAllOpenOrdersByVendor.AutoSize = true;
            this.lblGetAllOpenOrdersByVendor.Location = new System.Drawing.Point(50, 18);
            this.lblGetAllOpenOrdersByVendor.Name = "lblGetAllOpenOrdersByVendor";
            this.lblGetAllOpenOrdersByVendor.Size = new System.Drawing.Size(158, 13);
            this.lblGetAllOpenOrdersByVendor.TabIndex = 1;
            this.lblGetAllOpenOrdersByVendor.Text = "View All Open Orders by Vendor";
            // 
            // cbGetVendorsByName
            // 
            this.cbGetVendorsByName.FormattingEnabled = true;
            this.cbGetVendorsByName.Location = new System.Drawing.Point(210, 18);
            this.cbGetVendorsByName.Name = "cbGetVendorsByName";
            this.cbGetVendorsByName.Size = new System.Drawing.Size(121, 21);
            this.cbGetVendorsByName.TabIndex = 2;
            // 
            // btngetAllOpenOrdersByVendor
            // 
            this.btngetAllOpenOrdersByVendor.Location = new System.Drawing.Point(356, 18);
            this.btngetAllOpenOrdersByVendor.Name = "btngetAllOpenOrdersByVendor";
            this.btngetAllOpenOrdersByVendor.Size = new System.Drawing.Size(135, 23);
            this.btngetAllOpenOrdersByVendor.TabIndex = 3;
            this.btngetAllOpenOrdersByVendor.Text = "Get Vendor Orders";
            this.btngetAllOpenOrdersByVendor.UseVisualStyleBackColor = true;
            // 
            // frmOpenVendorOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 379);
            this.Controls.Add(this.btngetAllOpenOrdersByVendor);
            this.Controls.Add(this.cbGetVendorsByName);
            this.Controls.Add(this.lblGetAllOpenOrdersByVendor);
            this.Controls.Add(this.listView1);
            this.Name = "frmOpenVendorOrders";
            this.Text = "Open Vendor Orders";
            this.Load += new System.EventHandler(this.frmOpenVendorOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chVendorOrderID;
        private System.Windows.Forms.ColumnHeader chVendorName;
        private System.Windows.Forms.ColumnHeader chDateOrdered;
        private System.Windows.Forms.ColumnHeader chNumberOfShipments;
        private System.Windows.Forms.Label lblGetAllOpenOrdersByVendor;
        private System.Windows.Forms.ComboBox cbGetVendorsByName;
        private System.Windows.Forms.Button btngetAllOpenOrdersByVendor;
    }
}