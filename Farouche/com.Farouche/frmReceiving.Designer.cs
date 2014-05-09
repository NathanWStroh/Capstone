namespace com.Farouche
{
    partial class frmReceiving
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
            this.lblVendorOrderID = new System.Windows.Forms.Label();
            this.txtVendorOrderID = new System.Windows.Forms.TextBox();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateOrdered = new System.Windows.Forms.TextBox();
            this.lblDateReceived = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumberofShipments = new System.Windows.Forms.TextBox();
            this.lblShipmentsReceived = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdateLineItem = new System.Windows.Forms.Button();
            this.btnAddLineItemtoCurrentListView = new System.Windows.Forms.Button();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVendorID = new System.Windows.Forms.TextBox();
            this.lvReceiving = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVendorOrderID
            // 
            this.lblVendorOrderID.AutoSize = true;
            this.lblVendorOrderID.Location = new System.Drawing.Point(12, 9);
            this.lblVendorOrderID.Name = "lblVendorOrderID";
            this.lblVendorOrderID.Size = new System.Drawing.Size(81, 13);
            this.lblVendorOrderID.TabIndex = 1;
            this.lblVendorOrderID.Text = "Vendor OrderID";
            // 
            // txtVendorOrderID
            // 
            this.txtVendorOrderID.Location = new System.Drawing.Point(100, 9);
            this.txtVendorOrderID.Name = "txtVendorOrderID";
            this.txtVendorOrderID.ReadOnly = true;
            this.txtVendorOrderID.Size = new System.Drawing.Size(100, 20);
            this.txtVendorOrderID.TabIndex = 2;
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Location = new System.Drawing.Point(12, 69);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(72, 13);
            this.lblVendorName.TabIndex = 3;
            this.lblVendorName.Text = "Vendor Name";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(100, 66);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.ReadOnly = true;
            this.txtVendorName.Size = new System.Drawing.Size(100, 20);
            this.txtVendorName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(502, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date Ordered";
            // 
            // txtDateOrdered
            // 
            this.txtDateOrdered.Location = new System.Drawing.Point(587, 6);
            this.txtDateOrdered.Name = "txtDateOrdered";
            this.txtDateOrdered.ReadOnly = true;
            this.txtDateOrdered.Size = new System.Drawing.Size(100, 20);
            this.txtDateOrdered.TabIndex = 6;
            // 
            // lblDateReceived
            // 
            this.lblDateReceived.AutoSize = true;
            this.lblDateReceived.Location = new System.Drawing.Point(502, 42);
            this.lblDateReceived.Name = "lblDateReceived";
            this.lblDateReceived.Size = new System.Drawing.Size(79, 13);
            this.lblDateReceived.TabIndex = 10;
            this.lblDateReceived.Text = "Date Received";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(587, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Number of Shipments";
            // 
            // txtNumberofShipments
            // 
            this.txtNumberofShipments.Location = new System.Drawing.Point(343, 6);
            this.txtNumberofShipments.Name = "txtNumberofShipments";
            this.txtNumberofShipments.ReadOnly = true;
            this.txtNumberofShipments.Size = new System.Drawing.Size(63, 20);
            this.txtNumberofShipments.TabIndex = 13;
            // 
            // lblShipmentsReceived
            // 
            this.lblShipmentsReceived.AutoSize = true;
            this.lblShipmentsReceived.Location = new System.Drawing.Point(232, 41);
            this.lblShipmentsReceived.Name = "lblShipmentsReceived";
            this.lblShipmentsReceived.Size = new System.Drawing.Size(105, 13);
            this.lblShipmentsReceived.TabIndex = 14;
            this.lblShipmentsReceived.Text = "Shipments Received";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(343, 36);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 15;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(599, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 23);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnUpdateLineItem
            // 
            this.btnUpdateLineItem.Location = new System.Drawing.Point(224, 404);
            this.btnUpdateLineItem.Name = "btnUpdateLineItem";
            this.btnUpdateLineItem.Size = new System.Drawing.Size(162, 23);
            this.btnUpdateLineItem.TabIndex = 22;
            this.btnUpdateLineItem.Text = "Update Line Item";
            this.btnUpdateLineItem.UseVisualStyleBackColor = true;
            this.btnUpdateLineItem.Click += new System.EventHandler(this.btnUpdateLineItem_Click_2);
            // 
            // btnAddLineItemtoCurrentListView
            // 
            this.btnAddLineItemtoCurrentListView.Location = new System.Drawing.Point(40, 404);
            this.btnAddLineItemtoCurrentListView.Name = "btnAddLineItemtoCurrentListView";
            this.btnAddLineItemtoCurrentListView.Size = new System.Drawing.Size(162, 23);
            this.btnAddLineItemtoCurrentListView.TabIndex = 20;
            this.btnAddLineItemtoCurrentListView.Text = "Add Line Item";
            this.btnAddLineItemtoCurrentListView.UseVisualStyleBackColor = true;
            this.btnAddLineItemtoCurrentListView.Click += new System.EventHandler(this.btnAddLineItemtoCurrentListView_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.Location = new System.Drawing.Point(419, 404);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(136, 23);
            this.btnAddNote.TabIndex = 25;
            this.btnAddNote.Text = "Add Note";
            this.btnAddNote.UseVisualStyleBackColor = true;
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "VendorID";
            // 
            // txtVendorID
            // 
            this.txtVendorID.Location = new System.Drawing.Point(100, 41);
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.ReadOnly = true;
            this.txtVendorID.Size = new System.Drawing.Size(100, 20);
            this.txtVendorID.TabIndex = 27;
            // 
            // lvReceiving
            // 
            this.lvReceiving.FullRowSelect = true;
            this.lvReceiving.GridLines = true;
            this.lvReceiving.Location = new System.Drawing.Point(40, 122);
            this.lvReceiving.Name = "lvReceiving";
            this.lvReceiving.Size = new System.Drawing.Size(707, 220);
            this.lvReceiving.TabIndex = 28;
            this.lvReceiving.UseCompatibleStateImageBehavior = false;
            this.lvReceiving.View = System.Windows.Forms.View.Details;
            // 
            // frmReceiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 692);
            this.Controls.Add(this.lvReceiving);
            this.Controls.Add(this.txtVendorID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNote);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdateLineItem);
            this.Controls.Add(this.btnAddLineItemtoCurrentListView);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblShipmentsReceived);
            this.Controls.Add(this.txtNumberofShipments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblDateReceived);
            this.Controls.Add(this.txtDateOrdered);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.lblVendorName);
            this.Controls.Add(this.txtVendorOrderID);
            this.Controls.Add(this.lblVendorOrderID);
            this.Name = "frmReceiving";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receiving";
            this.Load += new System.EventHandler(this.frmReceiving_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVendorOrderID;
        private System.Windows.Forms.TextBox txtVendorOrderID;
        private System.Windows.Forms.Label lblVendorName;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDateOrdered;
        private System.Windows.Forms.Label lblDateReceived;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumberofShipments;
        private System.Windows.Forms.Label lblShipmentsReceived;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdateLineItem;
        private System.Windows.Forms.Button btnAddLineItemtoCurrentListView;
        private System.Windows.Forms.Button btnAddNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVendorID;
        private System.Windows.Forms.ListView lvReceiving;
    }
}