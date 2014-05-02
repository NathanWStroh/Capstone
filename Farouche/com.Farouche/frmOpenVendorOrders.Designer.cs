namespace com.Farouche.Presentation
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
            this.lblGetAllOpenOrdersByVendor = new System.Windows.Forms.Label();
            this.cbGetVendorsById = new System.Windows.Forms.ComboBox();
            this.btngetAllOpenOrdersByVendor = new System.Windows.Forms.Button();
            this.dgvOpenVendorOrders = new System.Windows.Forms.DataGridView();
            this.btnGellAllOpenOrders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenVendorOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGetAllOpenOrdersByVendor
            // 
            this.lblGetAllOpenOrdersByVendor.AutoSize = true;
            this.lblGetAllOpenOrdersByVendor.Location = new System.Drawing.Point(35, 21);
            this.lblGetAllOpenOrdersByVendor.Name = "lblGetAllOpenOrdersByVendor";
            this.lblGetAllOpenOrdersByVendor.Size = new System.Drawing.Size(158, 13);
            this.lblGetAllOpenOrdersByVendor.TabIndex = 1;
            this.lblGetAllOpenOrdersByVendor.Text = "View All Open Orders by Vendor";
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
            // dgvOpenVendorOrders
            // 
            this.dgvOpenVendorOrders.AllowUserToAddRows = false;
            this.dgvOpenVendorOrders.AllowUserToDeleteRows = false;
            this.dgvOpenVendorOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOpenVendorOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOpenVendorOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOpenVendorOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpenVendorOrders.Location = new System.Drawing.Point(38, 70);
            this.dgvOpenVendorOrders.MultiSelect = false;
            this.dgvOpenVendorOrders.Name = "dgvOpenVendorOrders";
            this.dgvOpenVendorOrders.ReadOnly = true;
            this.dgvOpenVendorOrders.Size = new System.Drawing.Size(667, 250);
            this.dgvOpenVendorOrders.TabIndex = 4;
            // 
            // btnGellAllOpenOrders
            // 
            this.btnGellAllOpenOrders.Location = new System.Drawing.Point(497, 18);
            this.btnGellAllOpenOrders.Name = "btnGellAllOpenOrders";
            this.btnGellAllOpenOrders.Size = new System.Drawing.Size(129, 23);
            this.btnGellAllOpenOrders.TabIndex = 5;
            this.btnGellAllOpenOrders.Text = "Reset";
            this.btnGellAllOpenOrders.UseVisualStyleBackColor = true;
            this.btnGellAllOpenOrders.Click += new System.EventHandler(this.btnGellAllOpenOrders_Click);
            // 
            // frmOpenVendorOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 589);
            this.Controls.Add(this.btnGellAllOpenOrders);
            this.Controls.Add(this.dgvOpenVendorOrders);
            this.Controls.Add(this.btngetAllOpenOrdersByVendor);
            this.Controls.Add(this.cbGetVendorsById);
            this.Controls.Add(this.lblGetAllOpenOrdersByVendor);
            this.Name = "frmOpenVendorOrders";
            this.Text = "Open Vendor Orders";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmOpenVendorOrders_FormClosed);
            this.Load += new System.EventHandler(this.frmOpenVendorOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpenVendorOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGetAllOpenOrdersByVendor;
        private System.Windows.Forms.ComboBox cbGetVendorsById;
        private System.Windows.Forms.Button btngetAllOpenOrdersByVendor;
        private System.Windows.Forms.DataGridView dgvOpenVendorOrders;
        private System.Windows.Forms.Button btnGellAllOpenOrders;
    }
}