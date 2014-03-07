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
            this.lblSelectedItemRow = new System.Windows.Forms.Label();
            this.txtSelectedLineItem = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(107, 77);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(399, 188);
            this.txtNotes.TabIndex = 0;
            // 
            // lblVendorOrderID
            // 
            this.lblVendorOrderID.AutoSize = true;
            this.lblVendorOrderID.Location = new System.Drawing.Point(107, 13);
            this.lblVendorOrderID.Name = "lblVendorOrderID";
            this.lblVendorOrderID.Size = new System.Drawing.Size(87, 13);
            this.lblVendorOrderID.TabIndex = 1;
            this.lblVendorOrderID.Text = "Vendor Order ID:";
            // 
            // txtVendorOrderID
            // 
            this.txtVendorOrderID.Location = new System.Drawing.Point(200, 10);
            this.txtVendorOrderID.Name = "txtVendorOrderID";
            this.txtVendorOrderID.ReadOnly = true;
            this.txtVendorOrderID.Size = new System.Drawing.Size(134, 20);
            this.txtVendorOrderID.TabIndex = 2;
            // 
            // btnUpdatedNote
            // 
            this.btnUpdatedNote.Location = new System.Drawing.Point(399, 295);
            this.btnUpdatedNote.Name = "btnUpdatedNote";
            this.btnUpdatedNote.Size = new System.Drawing.Size(107, 23);
            this.btnUpdatedNote.TabIndex = 3;
            this.btnUpdatedNote.Text = "Update Notes";
            this.btnUpdatedNote.UseVisualStyleBackColor = true;
            // 
            // lblSelectedItemRow
            // 
            this.lblSelectedItemRow.AutoSize = true;
            this.lblSelectedItemRow.Location = new System.Drawing.Point(104, 46);
            this.lblSelectedItemRow.Name = "lblSelectedItemRow";
            this.lblSelectedItemRow.Size = new System.Drawing.Size(77, 13);
            this.lblSelectedItemRow.TabIndex = 4;
            this.lblSelectedItemRow.Text = "Selected Row:";
            // 
            // txtSelectedLineItem
            // 
            this.txtSelectedLineItem.Location = new System.Drawing.Point(200, 43);
            this.txtSelectedLineItem.Name = "txtSelectedLineItem";
            this.txtSelectedLineItem.ReadOnly = true;
            this.txtSelectedLineItem.Size = new System.Drawing.Size(134, 20);
            this.txtSelectedLineItem.TabIndex = 5;
            // 
            // frmReceivingNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 350);
            this.Controls.Add(this.txtSelectedLineItem);
            this.Controls.Add(this.lblSelectedItemRow);
            this.Controls.Add(this.btnUpdatedNote);
            this.Controls.Add(this.txtVendorOrderID);
            this.Controls.Add(this.lblVendorOrderID);
            this.Controls.Add(this.txtNotes);
            this.Name = "frmReceivingNotes";
            this.Text = "frmReceivingNotes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblVendorOrderID;
        private System.Windows.Forms.TextBox txtVendorOrderID;
        private System.Windows.Forms.Button btnUpdatedNote;
        private System.Windows.Forms.Label lblSelectedItemRow;
        private System.Windows.Forms.TextBox txtSelectedLineItem;
    }
}