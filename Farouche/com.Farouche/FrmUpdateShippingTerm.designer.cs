namespace com.Farouche
{
    partial class FrmUpdateShippingTerm
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
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.comboVendors = new System.Windows.Forms.ComboBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.labelVendor = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(111, 58);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(282, 117);
            this.txtDesc.TabIndex = 1;
            // 
            // comboVendors
            // 
            this.comboVendors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboVendors.Enabled = false;
            this.comboVendors.FormattingEnabled = true;
            this.comboVendors.Location = new System.Drawing.Point(111, 30);
            this.comboVendors.Name = "comboVendors";
            this.comboVendors.Size = new System.Drawing.Size(121, 21);
            this.comboVendors.TabIndex = 0;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(42, 61);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(63, 13);
            this.lblDesc.TabIndex = 41;
            this.lblDesc.Text = "Description:";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(226, 208);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(89, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Update Term";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // labelVendor
            // 
            this.labelVendor.AutoSize = true;
            this.labelVendor.Location = new System.Drawing.Point(61, 33);
            this.labelVendor.Name = "labelVendor";
            this.labelVendor.Size = new System.Drawing.Size(44, 13);
            this.labelVendor.TabIndex = 37;
            this.labelVendor.Text = "Vendor:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(145, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmUpdateShippingTerm
            // 
            this.AcceptButton = this.btnEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 297);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.comboVendors);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.labelVendor);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmUpdateShippingTerm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.ComboBox comboVendors;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label labelVendor;
        private System.Windows.Forms.Button btnCancel;

    }
}