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
            this.btClose.Location = new System.Drawing.Point(21, 320);
            this.btClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(56, 19);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // lvVendors
            // 
            this.lvVendors.Location = new System.Drawing.Point(21, 72);
            this.lvVendors.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvVendors.Name = "lvVendors";
            this.lvVendors.Size = new System.Drawing.Size(395, 236);
            this.lvVendors.TabIndex = 1;
            this.lvVendors.UseCompatibleStateImageBehavior = false;
            // 
            // tbVendorSearch
            // 
            this.tbVendorSearch.Location = new System.Drawing.Point(106, 50);
            this.tbVendorSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbVendorSearch.Name = "tbVendorSearch";
            this.tbVendorSearch.Size = new System.Drawing.Size(310, 20);
            this.tbVendorSearch.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search Vendor:";
            // 
            // btAddRelation
            // 
            this.btAddRelation.Location = new System.Drawing.Point(338, 320);
            this.btAddRelation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddRelation.Name = "btAddRelation";
            this.btAddRelation.Size = new System.Drawing.Size(76, 19);
            this.btAddRelation.TabIndex = 4;
            this.btAddRelation.Text = "Add Relation";
            this.btAddRelation.UseVisualStyleBackColor = true;
            // 
            // AddVendorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 369);
            this.Controls.Add(this.btAddRelation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbVendorSearch);
            this.Controls.Add(this.lvVendors);
            this.Controls.Add(this.btClose);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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