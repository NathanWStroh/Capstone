namespace com.Farouche
{
    partial class FrmShippingTerm
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
            this.btnDeactivateTerm = new System.Windows.Forms.Button();
            this.btnActivateTerm = new System.Windows.Forms.Button();
            this.cbTermStatusSearch = new System.Windows.Forms.ComboBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.btnUpdateTerm = new System.Windows.Forms.Button();
            this.lvShippingTerms = new System.Windows.Forms.ListView();
            this.btnAddTerm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeactivateTerm
            // 
            this.btnDeactivateTerm.Enabled = false;
            this.btnDeactivateTerm.Location = new System.Drawing.Point(18, 161);
            this.btnDeactivateTerm.Name = "btnDeactivateTerm";
            this.btnDeactivateTerm.Size = new System.Drawing.Size(100, 25);
            this.btnDeactivateTerm.TabIndex = 32;
            this.btnDeactivateTerm.Text = "Deactivate";
            this.btnDeactivateTerm.UseVisualStyleBackColor = true;
            // 
            // btnActivateTerm
            // 
            this.btnActivateTerm.Enabled = false;
            this.btnActivateTerm.Location = new System.Drawing.Point(18, 130);
            this.btnActivateTerm.Name = "btnActivateTerm";
            this.btnActivateTerm.Size = new System.Drawing.Size(100, 25);
            this.btnActivateTerm.TabIndex = 31;
            this.btnActivateTerm.Text = "Activate";
            this.btnActivateTerm.UseVisualStyleBackColor = true;
            // 
            // cbTermStatusSearch
            // 
            this.cbTermStatusSearch.Enabled = false;
            this.cbTermStatusSearch.FormattingEnabled = true;
            this.cbTermStatusSearch.Location = new System.Drawing.Point(646, 31);
            this.cbTermStatusSearch.Name = "cbTermStatusSearch";
            this.cbTermStatusSearch.Size = new System.Drawing.Size(121, 21);
            this.cbTermStatusSearch.TabIndex = 30;
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(600, 34);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(40, 13);
            this.lblActive.TabIndex = 29;
            this.lblActive.Text = "Active:";
            // 
            // btnUpdateTerm
            // 
            this.btnUpdateTerm.Enabled = false;
            this.btnUpdateTerm.Location = new System.Drawing.Point(18, 99);
            this.btnUpdateTerm.Name = "btnUpdateTerm";
            this.btnUpdateTerm.Size = new System.Drawing.Size(100, 25);
            this.btnUpdateTerm.TabIndex = 28;
            this.btnUpdateTerm.Text = "Update Term";
            this.btnUpdateTerm.UseVisualStyleBackColor = true;
            this.btnUpdateTerm.Click += new System.EventHandler(this.btnUpdateTerm_Click);
            // 
            // lvShippingTerms
            // 
            this.lvShippingTerms.FullRowSelect = true;
            this.lvShippingTerms.GridLines = true;
            this.lvShippingTerms.Location = new System.Drawing.Point(135, 68);
            this.lvShippingTerms.MultiSelect = false;
            this.lvShippingTerms.Name = "lvShippingTerms";
            this.lvShippingTerms.Size = new System.Drawing.Size(643, 253);
            this.lvShippingTerms.TabIndex = 27;
            this.lvShippingTerms.UseCompatibleStateImageBehavior = false;
            this.lvShippingTerms.View = System.Windows.Forms.View.Details;
            // 
            // btnAddTerm
            // 
            this.btnAddTerm.Location = new System.Drawing.Point(18, 68);
            this.btnAddTerm.Name = "btnAddTerm";
            this.btnAddTerm.Size = new System.Drawing.Size(100, 25);
            this.btnAddTerm.TabIndex = 26;
            this.btnAddTerm.Text = "Add Term";
            this.btnAddTerm.UseVisualStyleBackColor = true;
            this.btnAddTerm.Click += new System.EventHandler(this.btnAddTerm_Click);
            // 
            // FrmShippingTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 352);
            this.Controls.Add(this.btnDeactivateTerm);
            this.Controls.Add(this.btnActivateTerm);
            this.Controls.Add(this.cbTermStatusSearch);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.btnUpdateTerm);
            this.Controls.Add(this.lvShippingTerms);
            this.Controls.Add(this.btnAddTerm);
            this.Name = "FrmShippingTerm";
            this.Text = "FrmShippingTerm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeactivateTerm;
        private System.Windows.Forms.Button btnActivateTerm;
        private System.Windows.Forms.ComboBox cbTermStatusSearch;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Button btnUpdateTerm;
        private System.Windows.Forms.ListView lvShippingTerms;
        private System.Windows.Forms.Button btnAddTerm;
    }
}