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
            this.btnAddLineItemtoCurrentListView = new System.Windows.Forms.Button();
            this.btnAddNote = new System.Windows.Forms.Button();
            this.btnUpdateLineItem = new System.Windows.Forms.Button();
            this.lblDateReceived = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumberofShipments = new System.Windows.Forms.TextBox();
            this.lblShipmentsReceived = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnUpdateOrder = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lvVendorOrderLineItems = new System.Windows.Forms.ListView();
            this.chProductID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQtyOrdered = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQtyReceived = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTotalQtyReceived = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chQtyDamaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLineItemNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVendorOrderID
            // 
            this.lblVendorOrderID.AutoSize = true;
            this.lblVendorOrderID.Location = new System.Drawing.Point(37, 13);
            this.lblVendorOrderID.Name = "lblVendorOrderID";
            this.lblVendorOrderID.Size = new System.Drawing.Size(81, 13);
            this.lblVendorOrderID.TabIndex = 1;
            this.lblVendorOrderID.Text = "Vendor OrderID";
            // 
            // txtVendorOrderID
            // 
            this.txtVendorOrderID.Location = new System.Drawing.Point(125, 13);
            this.txtVendorOrderID.Name = "txtVendorOrderID";
            this.txtVendorOrderID.ReadOnly = true;
            this.txtVendorOrderID.Size = new System.Drawing.Size(100, 20);
            this.txtVendorOrderID.TabIndex = 2;
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Location = new System.Drawing.Point(40, 46);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(72, 13);
            this.lblVendorName.TabIndex = 3;
            this.lblVendorName.Text = "Vendor Name";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(125, 39);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.ReadOnly = true;
            this.txtVendorName.Size = new System.Drawing.Size(100, 20);
            this.txtVendorName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Date Ordered";
            // 
            // txtDateOrdered
            // 
            this.txtDateOrdered.Location = new System.Drawing.Point(612, 6);
            this.txtDateOrdered.Name = "txtDateOrdered";
            this.txtDateOrdered.ReadOnly = true;
            this.txtDateOrdered.Size = new System.Drawing.Size(100, 20);
            this.txtDateOrdered.TabIndex = 6;
            // 
            // btnAddLineItemtoCurrentListView
            // 
            this.btnAddLineItemtoCurrentListView.Location = new System.Drawing.Point(704, 102);
            this.btnAddLineItemtoCurrentListView.Name = "btnAddLineItemtoCurrentListView";
            this.btnAddLineItemtoCurrentListView.Size = new System.Drawing.Size(162, 23);
            this.btnAddLineItemtoCurrentListView.TabIndex = 7;
            this.btnAddLineItemtoCurrentListView.Text = "Add Line Item";
            this.btnAddLineItemtoCurrentListView.UseVisualStyleBackColor = true;
            // 
            // btnAddNote
            // 
            this.btnAddNote.Location = new System.Drawing.Point(704, 151);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(162, 23);
            this.btnAddNote.TabIndex = 8;
            this.btnAddNote.Text = "Add Note";
            this.btnAddNote.UseVisualStyleBackColor = true;
            // 
            // btnUpdateLineItem
            // 
            this.btnUpdateLineItem.Location = new System.Drawing.Point(704, 194);
            this.btnUpdateLineItem.Name = "btnUpdateLineItem";
            this.btnUpdateLineItem.Size = new System.Drawing.Size(162, 23);
            this.btnUpdateLineItem.TabIndex = 9;
            this.btnUpdateLineItem.Text = "Update Line Item";
            this.btnUpdateLineItem.UseVisualStyleBackColor = true;
            // 
            // lblDateReceived
            // 
            this.lblDateReceived.AutoSize = true;
            this.lblDateReceived.Location = new System.Drawing.Point(527, 46);
            this.lblDateReceived.Name = "lblDateReceived";
            this.lblDateReceived.Size = new System.Drawing.Size(79, 13);
            this.lblDateReceived.TabIndex = 10;
            this.lblDateReceived.Text = "Date Received";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(612, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Number of Shipments";
            // 
            // txtNumberofShipments
            // 
            this.txtNumberofShipments.Location = new System.Drawing.Point(368, 10);
            this.txtNumberofShipments.Name = "txtNumberofShipments";
            this.txtNumberofShipments.ReadOnly = true;
            this.txtNumberofShipments.Size = new System.Drawing.Size(63, 20);
            this.txtNumberofShipments.TabIndex = 13;
            // 
            // lblShipmentsReceived
            // 
            this.lblShipmentsReceived.AutoSize = true;
            this.lblShipmentsReceived.Location = new System.Drawing.Point(257, 45);
            this.lblShipmentsReceived.Name = "lblShipmentsReceived";
            this.lblShipmentsReceived.Size = new System.Drawing.Size(105, 13);
            this.lblShipmentsReceived.TabIndex = 14;
            this.lblShipmentsReceived.Text = "Shipments Received";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(368, 40);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 15;
            // 
            // btnUpdateOrder
            // 
            this.btnUpdateOrder.Location = new System.Drawing.Point(705, 244);
            this.btnUpdateOrder.Name = "btnUpdateOrder";
            this.btnUpdateOrder.Size = new System.Drawing.Size(161, 23);
            this.btnUpdateOrder.TabIndex = 16;
            this.btnUpdateOrder.Text = "Update Order";
            this.btnUpdateOrder.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(705, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(161, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lvVendorOrderLineItems
            // 
            this.lvVendorOrderLineItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProductID,
            this.chQtyOrdered,
            this.chQtyReceived,
            this.chTotalQtyReceived,
            this.chQtyDamaged,
            this.chLineItemNotes});
            this.lvVendorOrderLineItems.FullRowSelect = true;
            this.lvVendorOrderLineItems.GridLines = true;
            this.lvVendorOrderLineItems.LabelWrap = false;
            this.lvVendorOrderLineItems.Location = new System.Drawing.Point(12, 85);
            this.lvVendorOrderLineItems.Name = "lvVendorOrderLineItems";
            this.lvVendorOrderLineItems.Size = new System.Drawing.Size(658, 297);
            this.lvVendorOrderLineItems.TabIndex = 18;
            this.lvVendorOrderLineItems.UseCompatibleStateImageBehavior = false;
            this.lvVendorOrderLineItems.View = System.Windows.Forms.View.Details;
            // 
            // chProductID
            // 
            this.chProductID.Text = "Product ID";
            this.chProductID.Width = 75;
            // 
            // chQtyOrdered
            // 
            this.chQtyOrdered.Text = "Quantity Ordered";
            this.chQtyOrdered.Width = 107;
            // 
            // chQtyReceived
            // 
            this.chQtyReceived.Text = "Quanity Received";
            this.chQtyReceived.Width = 103;
            // 
            // chTotalQtyReceived
            // 
            this.chTotalQtyReceived.Text = "Total Quantity Delivered";
            this.chTotalQtyReceived.Width = 128;
            // 
            // chQtyDamaged
            // 
            this.chQtyDamaged.Text = "Quantity Damaged";
            this.chQtyDamaged.Width = 131;
            // 
            // chLineItemNotes
            // 
            this.chLineItemNotes.Text = "Notes";
            this.chLineItemNotes.Width = 150;
            // 
            // frmReceiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 423);
            this.Controls.Add(this.lvVendorOrderLineItems);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdateOrder);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.lblShipmentsReceived);
            this.Controls.Add(this.txtNumberofShipments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblDateReceived);
            this.Controls.Add(this.btnUpdateLineItem);
            this.Controls.Add(this.btnAddNote);
            this.Controls.Add(this.btnAddLineItemtoCurrentListView);
            this.Controls.Add(this.txtDateOrdered);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.lblVendorName);
            this.Controls.Add(this.txtVendorOrderID);
            this.Controls.Add(this.lblVendorOrderID);
            this.Name = "frmReceiving";
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
        private System.Windows.Forms.Button btnAddLineItemtoCurrentListView;
        private System.Windows.Forms.Button btnAddNote;
        private System.Windows.Forms.Button btnUpdateLineItem;
        private System.Windows.Forms.Label lblDateReceived;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumberofShipments;
        private System.Windows.Forms.Label lblShipmentsReceived;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnUpdateOrder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lvVendorOrderLineItems;
        private System.Windows.Forms.ColumnHeader chProductID;
        private System.Windows.Forms.ColumnHeader chQtyOrdered;
        private System.Windows.Forms.ColumnHeader chQtyReceived;
        private System.Windows.Forms.ColumnHeader chTotalQtyReceived;
        private System.Windows.Forms.ColumnHeader chQtyDamaged;
        private System.Windows.Forms.ColumnHeader chLineItemNotes;
    }
}