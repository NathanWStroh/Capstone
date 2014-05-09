namespace com.Farouche
{
    partial class FrmRoles
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.roleLv = new System.Windows.Forms.ListView();
            this.addRoleBtn = new System.Windows.Forms.Button();
            this.updateRoleBtn = new System.Windows.Forms.Button();
            this.deactivateBtn = new System.Windows.Forms.Button();
            this.activateBtn = new System.Windows.Forms.Button();
            this.lblActive = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DisplayMember = "Description";
            this.comboBox1.Location = new System.Drawing.Point(509, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // roleLv
            // 
            this.roleLv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roleLv.FullRowSelect = true;
            this.roleLv.GridLines = true;
            this.roleLv.Location = new System.Drawing.Point(119, 39);
            this.roleLv.MultiSelect = false;
            this.roleLv.Name = "roleLv";
            this.roleLv.Size = new System.Drawing.Size(511, 200);
            this.roleLv.TabIndex = 1;
            this.roleLv.UseCompatibleStateImageBehavior = false;
            this.roleLv.View = System.Windows.Forms.View.Details;
            this.roleLv.SelectedIndexChanged += new System.EventHandler(this.roleLv_SelectedIndexChanged);
            this.roleLv.Click += new System.EventHandler(this.roleLv_Click);
            // 
            // addRoleBtn
            // 
            this.addRoleBtn.Location = new System.Drawing.Point(13, 39);
            this.addRoleBtn.Name = "addRoleBtn";
            this.addRoleBtn.Size = new System.Drawing.Size(100, 25);
            this.addRoleBtn.TabIndex = 2;
            this.addRoleBtn.Text = "Add Role";
            this.addRoleBtn.UseVisualStyleBackColor = true;
            this.addRoleBtn.Click += new System.EventHandler(this.addRoleBtn_Click);
            // 
            // updateRoleBtn
            // 
            this.updateRoleBtn.Enabled = false;
            this.updateRoleBtn.Location = new System.Drawing.Point(13, 70);
            this.updateRoleBtn.Name = "updateRoleBtn";
            this.updateRoleBtn.Size = new System.Drawing.Size(100, 25);
            this.updateRoleBtn.TabIndex = 3;
            this.updateRoleBtn.Text = "Update Role";
            this.updateRoleBtn.UseVisualStyleBackColor = true;
            this.updateRoleBtn.Click += new System.EventHandler(this.updateRoleBtn_Click);
            // 
            // deactivateBtn
            // 
            this.deactivateBtn.Enabled = false;
            this.deactivateBtn.Location = new System.Drawing.Point(12, 132);
            this.deactivateBtn.Name = "deactivateBtn";
            this.deactivateBtn.Size = new System.Drawing.Size(100, 25);
            this.deactivateBtn.TabIndex = 5;
            this.deactivateBtn.Text = "Deactivate";
            this.deactivateBtn.UseVisualStyleBackColor = true;
            this.deactivateBtn.Click += new System.EventHandler(this.deactivateBtn_Click);
            // 
            // activateBtn
            // 
            this.activateBtn.Enabled = false;
            this.activateBtn.Location = new System.Drawing.Point(12, 101);
            this.activateBtn.Name = "activateBtn";
            this.activateBtn.Size = new System.Drawing.Size(100, 25);
            this.activateBtn.TabIndex = 6;
            this.activateBtn.Text = "Activate";
            this.activateBtn.UseVisualStyleBackColor = true;
            this.activateBtn.Click += new System.EventHandler(this.activateBtn_Click);
            // 
            // lblActive
            // 
            this.lblActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(466, 15);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(37, 13);
            this.lblActive.TabIndex = 7;
            this.lblActive.Text = "Active";
            // 
            // FrmRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 271);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.activateBtn);
            this.Controls.Add(this.deactivateBtn);
            this.Controls.Add(this.updateRoleBtn);
            this.Controls.Add(this.addRoleBtn);
            this.Controls.Add(this.roleLv);
            this.Controls.Add(this.comboBox1);
            this.Name = "FrmRoles";
            this.Text = "Roles List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmRoles_FormClosed);
            this.Load += new System.EventHandler(this.FrmRoles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView roleLv;
        private System.Windows.Forms.Button addRoleBtn;
        private System.Windows.Forms.Button updateRoleBtn;
        private System.Windows.Forms.Button deactivateBtn;
        private System.Windows.Forms.Button activateBtn;
        private System.Windows.Forms.Label lblActive;

    }
}