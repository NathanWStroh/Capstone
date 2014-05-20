namespace com.Farouche
{
    partial class frmReorderChangeLevels
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtROThreshold = new System.Windows.Forms.TextBox();
            this.txtROAmount = new System.Windows.Forms.TextBox();
            this.numericROAmount = new System.Windows.Forms.NumericUpDown();
            this.numericROThreshold = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtProduct = new System.Windows.Forms.Label();
            this.ttpReorderLevels = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericROAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericROThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Reorder Threshold:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "New Reorder Threshold:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "New Reorder Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Current Reorder Amount:";
            // 
            // txtROThreshold
            // 
            this.txtROThreshold.Location = new System.Drawing.Point(192, 41);
            this.txtROThreshold.Name = "txtROThreshold";
            this.txtROThreshold.ReadOnly = true;
            this.txtROThreshold.Size = new System.Drawing.Size(50, 20);
            this.txtROThreshold.TabIndex = 0;
            this.txtROThreshold.TabStop = false;
            this.ttpReorderLevels.SetToolTip(this.txtROThreshold, "Current Threshold before a Product is considered to be needing Reordered by the S" +
        "ystem.");
            // 
            // txtROAmount
            // 
            this.txtROAmount.Location = new System.Drawing.Point(192, 105);
            this.txtROAmount.Name = "txtROAmount";
            this.txtROAmount.ReadOnly = true;
            this.txtROAmount.Size = new System.Drawing.Size(50, 20);
            this.txtROAmount.TabIndex = 0;
            this.txtROAmount.TabStop = false;
            this.ttpReorderLevels.SetToolTip(this.txtROAmount, "Current amount to be reordered at one time.");
            // 
            // numericROAmount
            // 
            this.numericROAmount.Location = new System.Drawing.Point(192, 131);
            this.numericROAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericROAmount.Name = "numericROAmount";
            this.numericROAmount.Size = new System.Drawing.Size(50, 20);
            this.numericROAmount.TabIndex = 1;
            this.numericROAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ttpReorderLevels.SetToolTip(this.numericROAmount, "Replaces the above amount with a new Reorder Amount.");
            this.numericROAmount.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // numericROThreshold
            // 
            this.numericROThreshold.Location = new System.Drawing.Point(192, 67);
            this.numericROThreshold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericROThreshold.Name = "numericROThreshold";
            this.numericROThreshold.Size = new System.Drawing.Size(50, 20);
            this.numericROThreshold.TabIndex = 1;
            this.numericROThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ttpReorderLevels.SetToolTip(this.numericROThreshold, "Replaces the above amount with a new Reorder Threshold.");
            this.numericROThreshold.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(192, 165);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.ttpReorderLevels.SetToolTip(this.btnSave, "Saves Changes.");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(136, 165);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.ttpReorderLevels.SetToolTip(this.btnCancel, "Reverts Changes.");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtProduct
            // 
            this.txtProduct.AutoSize = true;
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(12, 9);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(203, 24);
            this.txtProduct.TabIndex = 12;
            this.txtProduct.Text = "No Product Selected";
            this.ttpReorderLevels.SetToolTip(this.txtProduct, "Current Product Selected to be Changed.");
            // 
            // frmReorderChangeLevels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 222);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numericROThreshold);
            this.Controls.Add(this.numericROAmount);
            this.Controls.Add(this.txtROAmount);
            this.Controls.Add(this.txtROThreshold);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmReorderChangeLevels";
            this.Text = "Change Reorder Levels";
            this.Load += new System.EventHandler(this.frmReorderChangeLevels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericROAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericROThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtROThreshold;
        private System.Windows.Forms.TextBox txtROAmount;
        private System.Windows.Forms.NumericUpDown numericROAmount;
        private System.Windows.Forms.NumericUpDown numericROThreshold;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label txtProduct;
        private System.Windows.Forms.ToolTip ttpReorderLevels;
    }
}