namespace com.Farouche
{
    partial class FrmShippingAllOrders
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
            this.btnClearUser = new System.Windows.Forms.Button();
            this.lvAllOrders = new System.Windows.Forms.ListView();
            this.btnAssignUser = new System.Windows.Forms.Button();
            this.btnUserDirectory = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClearUser
            // 
            this.btnClearUser.Location = new System.Drawing.Point(394, 254);
            this.btnClearUser.Name = "btnClearUser";
            this.btnClearUser.Size = new System.Drawing.Size(144, 23);
            this.btnClearUser.TabIndex = 3;
            this.btnClearUser.Text = "Clear User";
            this.btnClearUser.UseVisualStyleBackColor = true;
            this.btnClearUser.Click += new System.EventHandler(this.btnClearUser_Click);
            // 
            // lvAllOrders
            // 
            this.lvAllOrders.FullRowSelect = true;
            this.lvAllOrders.GridLines = true;
            this.lvAllOrders.HideSelection = false;
            this.lvAllOrders.Location = new System.Drawing.Point(2, -4);
            this.lvAllOrders.MultiSelect = false;
            this.lvAllOrders.Name = "lvAllOrders";
            this.lvAllOrders.Size = new System.Drawing.Size(760, 252);
            this.lvAllOrders.TabIndex = 0;
            this.lvAllOrders.UseCompatibleStateImageBehavior = false;
            this.lvAllOrders.View = System.Windows.Forms.View.Details;
            this.lvAllOrders.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAllOrders_ColumnClick);
            // 
            // btnAssignUser
            // 
            this.btnAssignUser.Location = new System.Drawing.Point(261, 254);
            this.btnAssignUser.Name = "btnAssignUser";
            this.btnAssignUser.Size = new System.Drawing.Size(127, 23);
            this.btnAssignUser.TabIndex = 4;
            this.btnAssignUser.Text = "Assign User";
            this.btnAssignUser.UseVisualStyleBackColor = true;
            this.btnAssignUser.Click += new System.EventHandler(this.btnAssignUser_Click);
            // 
            // btnUserDirectory
            // 
            this.btnUserDirectory.Location = new System.Drawing.Point(2, 254);
            this.btnUserDirectory.Name = "btnUserDirectory";
            this.btnUserDirectory.Size = new System.Drawing.Size(134, 23);
            this.btnUserDirectory.TabIndex = 5;
            this.btnUserDirectory.Text = "User Directory";
            this.btnUserDirectory.UseVisualStyleBackColor = true;
            this.btnUserDirectory.Click += new System.EventHandler(this.btnUserDirectory_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "User ID:";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(194, 256);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(61, 20);
            this.txtUserId.TabIndex = 7;
            // 
            // FrmShippingAllOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 281);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUserDirectory);
            this.Controls.Add(this.btnAssignUser);
            this.Controls.Add(this.btnClearUser);
            this.Controls.Add(this.lvAllOrders);
            this.Name = "FrmShippingAllOrders";
            this.Text = "frmShippingAllOrders";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmShippingAllOrders_FormClosed);
            this.Load += new System.EventHandler(this.FrmShippingAllOrders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearUser;
        private System.Windows.Forms.ListView lvAllOrders;
        private System.Windows.Forms.Button btnAssignUser;
        private System.Windows.Forms.Button btnUserDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserId;
    }
}