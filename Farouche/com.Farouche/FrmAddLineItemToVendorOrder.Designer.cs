namespace com.Farouche
{
    partial class FrmAddLineItemToVendorOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVendorOrderID = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddLineItem = new System.Windows.Forms.Button();
            this.cbProductName = new System.Windows.Forms.ComboBox();
            this.upQuantityReceived = new System.Windows.Forms.NumericUpDown();
            this.upQtyDamaged = new System.Windows.Forms.NumericUpDown();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.txtVendorID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.upQuantityReceived)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upQtyDamaged)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "VendorOrderID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vendor Name ";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(223, 171);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(49, 13);
            this.lblProducts.TabIndex = 4;
            this.lblProducts.Text = "Products";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(217, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "QtyReceived";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(217, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "QtyDamaged";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(240, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Notes";
            // 
            // txtVendorOrderID
            // 
            this.txtVendorOrderID.Location = new System.Drawing.Point(301, 36);
            this.txtVendorOrderID.Name = "txtVendorOrderID";
            this.txtVendorOrderID.ReadOnly = true;
            this.txtVendorOrderID.Size = new System.Drawing.Size(119, 20);
            this.txtVendorOrderID.TabIndex = 11;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(298, 307);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(361, 20);
            this.txtNotes.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddLineItem
            // 
            this.btnAddLineItem.Location = new System.Drawing.Point(356, 349);
            this.btnAddLineItem.Name = "btnAddLineItem";
            this.btnAddLineItem.Size = new System.Drawing.Size(169, 23);
            this.btnAddLineItem.TabIndex = 20;
            this.btnAddLineItem.Text = "Add LineItem";
            this.btnAddLineItem.UseVisualStyleBackColor = true;
            this.btnAddLineItem.Click += new System.EventHandler(this.btnAddLineItem_Click);
            // 
            // cbProductName
            // 
            this.cbProductName.FormattingEnabled = true;
            this.cbProductName.Location = new System.Drawing.Point(299, 168);
            this.cbProductName.Name = "cbProductName";
            this.cbProductName.Size = new System.Drawing.Size(121, 21);
            this.cbProductName.TabIndex = 22;
            this.cbProductName.SelectedIndexChanged += new System.EventHandler(this.cbProductName_SelectedIndexChanged);
            // 
            // upQuantityReceived
            // 
            this.upQuantityReceived.Location = new System.Drawing.Point(298, 220);
            this.upQuantityReceived.Name = "upQuantityReceived";
            this.upQuantityReceived.Size = new System.Drawing.Size(120, 20);
            this.upQuantityReceived.TabIndex = 24;
            // 
            // upQtyDamaged
            // 
            this.upQtyDamaged.Location = new System.Drawing.Point(298, 267);
            this.upQtyDamaged.Name = "upQtyDamaged";
            this.upQtyDamaged.Size = new System.Drawing.Size(120, 20);
            this.upQtyDamaged.TabIndex = 25;
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(301, 78);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(119, 20);
            this.txtVendorName.TabIndex = 27;
            // 
            // txtVendorID
            // 
            this.txtVendorID.Location = new System.Drawing.Point(302, 117);
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.Size = new System.Drawing.Size(118, 20);
            this.txtVendorID.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Vendor ID";
            // 
            // FrmAddLineItemToVendorOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 406);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVendorID);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.upQtyDamaged);
            this.Controls.Add(this.upQuantityReceived);
            this.Controls.Add(this.cbProductName);
            this.Controls.Add(this.btnAddLineItem);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtVendorOrderID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "FrmAddLineItemToVendorOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddLineItemToVendorOrder";
            ((System.ComponentModel.ISupportInitialize)(this.upQuantityReceived)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upQtyDamaged)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVendorOrderID;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAddLineItem;
        private System.Windows.Forms.ComboBox cbProductName;
        private System.Windows.Forms.NumericUpDown upQuantityReceived;
        private System.Windows.Forms.NumericUpDown upQtyDamaged;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.TextBox txtVendorID;
        private System.Windows.Forms.Label label2;
    }
}