namespace com.Farouche.Presentation
{
    partial class AddVendorWindow
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
            this.btClose = new System.Windows.Forms.Button();
            this.lvVendors = new System.Windows.Forms.ListView();
            this.tbVendorSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btAddRelation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(28, 394);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lvVendors
            // 
            this.lvVendors.Location = new System.Drawing.Point(28, 89);
            this.lvVendors.Name = "lvVendors";
            this.lvVendors.Size = new System.Drawing.Size(525, 289);
            this.lvVendors.TabIndex = 1;
            this.lvVendors.UseCompatibleStateImageBehavior = false;
            // 
            // tbVendorSearch
            // 
            this.tbVendorSearch.Location = new System.Drawing.Point(141, 61);
            this.tbVendorSearch.Name = "tbVendorSearch";
            this.tbVendorSearch.Size = new System.Drawing.Size(412, 22);
            this.tbVendorSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Vendor:";
            // 
            // btAddRelation
            // 
            this.btAddRelation.Location = new System.Drawing.Point(451, 394);
            this.btAddRelation.Name = "btAddRelation";
            this.btAddRelation.Size = new System.Drawing.Size(102, 23);
            this.btAddRelation.TabIndex = 4;
            this.btAddRelation.Text = "Add Relation";
            this.btAddRelation.UseVisualStyleBackColor = true;
            // 
            // AddVendorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 429);
            this.Controls.Add(this.btAddRelation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbVendorSearch);
            this.Controls.Add(this.lvVendors);
            this.Controls.Add(this.btClose);
            this.Name = "AddVendorWindow";
            this.Text = "AddVendorWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.ListView lvVendors;
        private System.Windows.Forms.TextBox tbVendorSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btAddRelation;
    }
}