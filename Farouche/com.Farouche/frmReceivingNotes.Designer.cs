namespace com.Farouche
{
    partial class frmReceivingNotes
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
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblVendorOrderID = new System.Windows.Forms.Label();
            this.txtVendorOrderID = new System.Windows.Forms.TextBox();
            this.btnUpdatedNote = new System.Windows.Forms.Button();
            this.lblProductID = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(12, 62);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(399, 188);
            this.txtNotes.TabIndex = 0;
            // 
            // lblVendorOrderID
            // 
            this.lblVendorOrderID.AutoSize = true;
            this.lblVendorOrderID.Location = new System.Drawing.Point(12, 9);
            this.lblVendorOrderID.Name = "lblVendorOrderID";
            this.lblVendorOrderID.Size = new System.Drawing.Size(87, 13);
            this.lblVendorOrderID.TabIndex = 1;
            this.lblVendorOrderID.Text = "Vendor Order ID:";
            // 
            // txtVendorOrderID
            // 
            this.txtVendorOrderID.Location = new System.Drawing.Point(105, 6);
            this.txtVendorOrderID.Name = "txtVendorOrderID";
            this.txtVendorOrderID.ReadOnly = true;
            this.txtVendorOrderID.Size = new System.Drawing.Size(134, 20);
            this.txtVendorOrderID.TabIndex = 2;
            // 
            // btnUpdatedNote
            // 
            this.btnUpdatedNote.Location = new System.Drawing.Point(304, 256);
            this.btnUpdatedNote.Name = "btnUpdatedNote";
            this.btnUpdatedNote.Size = new System.Drawing.Size(107, 23);
            this.btnUpdatedNote.TabIndex = 3;
            this.btnUpdatedNote.Text = "Update Notes";
            this.btnUpdatedNote.UseVisualStyleBackColor = true;
            this.btnUpdatedNote.Click += new System.EventHandler(this.btnUpdatedNote_Click);
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(41, 43);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(58, 13);
            this.lblProductID.TabIndex = 4;
            this.lblProductID.Text = "ProductID:";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(107, 36);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(134, 20);
            this.txtProductID.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(110, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmReceivingNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(644, 350);
            this.Controls.Add(this.btnCancel);

            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.lblProductID);
            this.Controls.Add(this.btnUpdatedNote);
            this.Controls.Add(this.txtVendorOrderID);
            this.Controls.Add(this.lblVendorOrderID);
            this.Controls.Add(this.txtNotes);
            this.Name = "frmReceivingNotes";

            this.Text = "frmReceivingNotes";
            this.Load += new System.EventHandler(this.frmReceivingNotes_Load);

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblVendorOrderID;
        private System.Windows.Forms.TextBox txtVendorOrderID;
        private System.Windows.Forms.Button btnUpdatedNote;
        private System.Windows.Forms.Label lblProductID;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Button btnCancel;
    }
}