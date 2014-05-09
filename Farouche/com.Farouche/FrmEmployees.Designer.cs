namespace com.Farouche
{
    partial class FrmEmployees
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
            this.employeeLv = new System.Windows.Forms.ListView();
            this.addEmployeeBtn = new System.Windows.Forms.Button();
            this.updateEmployeeBtn = new System.Windows.Forms.Button();
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
            // employeeLv
            // 
            this.employeeLv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.employeeLv.FullRowSelect = true;
            this.employeeLv.GridLines = true;
            this.employeeLv.Location = new System.Drawing.Point(119, 39);
            this.employeeLv.MultiSelect = false;
            this.employeeLv.Name = "employeeLv";
            this.employeeLv.Size = new System.Drawing.Size(511, 200);
            this.employeeLv.TabIndex = 1;
            this.employeeLv.UseCompatibleStateImageBehavior = false;
            this.employeeLv.View = System.Windows.Forms.View.Details;
            this.employeeLv.SelectedIndexChanged += new System.EventHandler(this.employeeLv_SelectedIndexChanged);
            this.employeeLv.Click += new System.EventHandler(this.employeeLv_Click);
            // 
            // addEmployeeBtn
            // 
            this.addEmployeeBtn.Location = new System.Drawing.Point(13, 39);
            this.addEmployeeBtn.Name = "addEmployeeBtn";
            this.addEmployeeBtn.Size = new System.Drawing.Size(100, 25);
            this.addEmployeeBtn.TabIndex = 2;
            this.addEmployeeBtn.Text = "Add Employee";
            this.addEmployeeBtn.UseVisualStyleBackColor = true;
            this.addEmployeeBtn.Click += new System.EventHandler(this.addEmployeeBtn_Click);
            // 
            // updateEmployeeBtn
            // 
            this.updateEmployeeBtn.Enabled = false;
            this.updateEmployeeBtn.Location = new System.Drawing.Point(13, 70);
            this.updateEmployeeBtn.Name = "updateEmployeeBtn";
            this.updateEmployeeBtn.Size = new System.Drawing.Size(100, 25);
            this.updateEmployeeBtn.TabIndex = 3;
            this.updateEmployeeBtn.Text = "Update Employee";
            this.updateEmployeeBtn.UseVisualStyleBackColor = true;
            this.updateEmployeeBtn.Click += new System.EventHandler(this.updateEmployeeBtn_Click);
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
            // FrmEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 271);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.activateBtn);
            this.Controls.Add(this.deactivateBtn);
            this.Controls.Add(this.updateEmployeeBtn);
            this.Controls.Add(this.addEmployeeBtn);
            this.Controls.Add(this.employeeLv);
            this.Controls.Add(this.comboBox1);
            this.Name = "FrmEmployees";
            this.Text = "Employee List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEmployees_FormClosed);
            this.Load += new System.EventHandler(this.FrmEmployees_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListView employeeLv;
        private System.Windows.Forms.Button addEmployeeBtn;
        private System.Windows.Forms.Button updateEmployeeBtn;
        private System.Windows.Forms.Button deactivateBtn;
        private System.Windows.Forms.Button activateBtn;
        private System.Windows.Forms.Label lblActive;

    }
}