namespace com.Farouche
{
    partial class FrmShippingMyOrders
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
            this.btnDetails = new System.Windows.Forms.Button();
            this.lvMyOrders = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(628, 270);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(144, 23);
            this.btnDetails.TabIndex = 3;
            this.btnDetails.Text = "View Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // lvMyOrders
            // 
            this.lvMyOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMyOrders.FullRowSelect = true;
            this.lvMyOrders.GridLines = true;
            this.lvMyOrders.HideSelection = false;
            this.lvMyOrders.Location = new System.Drawing.Point(12, 12);
            this.lvMyOrders.MultiSelect = false;
            this.lvMyOrders.Name = "lvMyOrders";
            this.lvMyOrders.Size = new System.Drawing.Size(760, 252);
            this.lvMyOrders.TabIndex = 2;
            this.lvMyOrders.UseCompatibleStateImageBehavior = false;
            this.lvMyOrders.View = System.Windows.Forms.View.Details;
            // 
            // FrmShippingMyOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 305);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.lvMyOrders);
            this.Name = "FrmShippingMyOrders";
            this.Text = "Shipping My Orders";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmShippingMyOrders_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.ListView lvMyOrders;
    }
}