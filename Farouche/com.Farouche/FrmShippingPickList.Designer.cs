namespace com.Farouche
{
    partial class FrmShippingPickList
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
            this.lvPickList = new System.Windows.Forms.ListView();
            this.btnStartPick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvPickList
            // 
            this.lvPickList.FullRowSelect = true;
            this.lvPickList.GridLines = true;
            this.lvPickList.HideSelection = false;
            this.lvPickList.Location = new System.Drawing.Point(12, 12);
            this.lvPickList.MultiSelect = false;
            this.lvPickList.Name = "lvPickList";
            this.lvPickList.Size = new System.Drawing.Size(760, 252);
            this.lvPickList.TabIndex = 4;
            this.lvPickList.UseCompatibleStateImageBehavior = false;
            this.lvPickList.View = System.Windows.Forms.View.Details;
            this.lvPickList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvPickList_ColumnClick);
            // 
            // btnStartPick
            // 
            this.btnStartPick.Location = new System.Drawing.Point(634, 274);
            this.btnStartPick.Name = "btnStartPick";
            this.btnStartPick.Size = new System.Drawing.Size(144, 23);
            this.btnStartPick.TabIndex = 3;
            this.btnStartPick.Text = "Start Pick";
            this.btnStartPick.UseVisualStyleBackColor = true;
            this.btnStartPick.Click += new System.EventHandler(this.btnStartPick_Click);
            // 
            // FrmShippingPickList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 305);
            this.Controls.Add(this.lvPickList);
            this.Controls.Add(this.btnStartPick);
            this.Name = "FrmShippingPickList";
            this.Text = "FrmShippingPickList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmShippingPickList_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvPickList;
        private System.Windows.Forms.Button btnStartPick;
    }
}