namespace com.Farouche
{
    partial class FrmViewOrderDetails
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
            this.lvItemsForPick = new System.Windows.Forms.ListView();
            this.btnPick = new System.Windows.Forms.Button();
            this.lvPickedItems = new System.Windows.Forms.ListView();
            this.btnPrintDetails = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnUnpick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvItemsForPick
            // 
            this.lvItemsForPick.FullRowSelect = true;
            this.lvItemsForPick.GridLines = true;
            this.lvItemsForPick.Location = new System.Drawing.Point(12, 34);
            this.lvItemsForPick.MultiSelect = false;
            this.lvItemsForPick.Name = "lvItemsForPick";
            this.lvItemsForPick.Size = new System.Drawing.Size(323, 321);
            this.lvItemsForPick.TabIndex = 0;
            this.lvItemsForPick.UseCompatibleStateImageBehavior = false;
            this.lvItemsForPick.View = System.Windows.Forms.View.Details;
            this.lvItemsForPick.Click += new System.EventHandler(this.lvItemsForPick_Click);
            this.lvItemsForPick.DoubleClick += new System.EventHandler(this.lvItemsForPick_DoubleClick);
            // 
            // btnPick
            // 
            this.btnPick.Enabled = false;
            this.btnPick.Location = new System.Drawing.Point(341, 98);
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(78, 61);
            this.btnPick.TabIndex = 1;
            this.btnPick.Text = "Pick Item";
            this.btnPick.UseVisualStyleBackColor = true;
            this.btnPick.Click += new System.EventHandler(this.BtnPick_Click);
            // 
            // lvPickedItems
            // 
            this.lvPickedItems.FullRowSelect = true;
            this.lvPickedItems.GridLines = true;
            this.lvPickedItems.Location = new System.Drawing.Point(425, 34);
            this.lvPickedItems.MultiSelect = false;
            this.lvPickedItems.Name = "lvPickedItems";
            this.lvPickedItems.Size = new System.Drawing.Size(312, 321);
            this.lvPickedItems.TabIndex = 2;
            this.lvPickedItems.UseCompatibleStateImageBehavior = false;
            this.lvPickedItems.View = System.Windows.Forms.View.Details;
            this.lvPickedItems.Click += new System.EventHandler(this.lvPickedItems_Click);
            this.lvPickedItems.DoubleClick += new System.EventHandler(this.lvPickedItems_DoubleClick);
            // 
            // btnPrintDetails
            // 
            this.btnPrintDetails.Location = new System.Drawing.Point(341, 34);
            this.btnPrintDetails.Name = "btnPrintDetails";
            this.btnPrintDetails.Size = new System.Drawing.Size(78, 58);
            this.btnPrintDetails.TabIndex = 3;
            this.btnPrintDetails.Text = "Print Details";
            this.btnPrintDetails.UseVisualStyleBackColor = true;
            this.btnPrintDetails.Click += new System.EventHandler(this.BtnPrintDetails_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(540, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Picked Items";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Items Available for Pick";
            // 
            // btnComplete
            // 
            this.btnComplete.Enabled = false;
            this.btnComplete.Location = new System.Drawing.Point(341, 289);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(78, 66);
            this.btnComplete.TabIndex = 7;
            this.btnComplete.Text = "Complete Order";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.BtnComplete_Click);
            // 
            // btnUnpick
            // 
            this.btnUnpick.Enabled = false;
            this.btnUnpick.Location = new System.Drawing.Point(341, 217);
            this.btnUnpick.Name = "btnUnpick";
            this.btnUnpick.Size = new System.Drawing.Size(78, 66);
            this.btnUnpick.TabIndex = 8;
            this.btnUnpick.Text = "Unpick Item";
            this.btnUnpick.UseVisualStyleBackColor = true;
            this.btnUnpick.Click += new System.EventHandler(this.BtnUnpick_Click);
            // 
            // FrmViewOrderDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 363);
            this.Controls.Add(this.btnUnpick);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrintDetails);
            this.Controls.Add(this.lvPickedItems);
            this.Controls.Add(this.btnPick);
            this.Controls.Add(this.lvItemsForPick);
            this.Name = "FrmViewOrderDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shipping Order Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvItemsForPick;
        private System.Windows.Forms.Button btnPick;
        private System.Windows.Forms.ListView lvPickedItems;
        private System.Windows.Forms.Button btnPrintDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnUnpick;
    }

}