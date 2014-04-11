﻿namespace com.Farouche.Presentation
{
    partial class frmStartUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vendorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shippingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shippingOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAllShippingOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMyOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPickList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPackList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShippingTerms = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShippingVendors = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.productToolStripMenuItem,
            this.vendorToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.shippingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem});
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.productToolStripMenuItem.Text = "Product";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.productsToolStripMenuItem.Text = "Products";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            // 
            // vendorToolStripMenuItem
            // 
            this.vendorToolStripMenuItem.Name = "vendorToolStripMenuItem";
            this.vendorToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.vendorToolStripMenuItem.Text = "Vendor";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // shippingToolStripMenuItem
            // 
            this.shippingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shippingOrdersToolStripMenuItem,
            this.tsmiShippingTerms,
            this.tsmiShippingVendors});
            this.shippingToolStripMenuItem.Name = "shippingToolStripMenuItem";
            this.shippingToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.shippingToolStripMenuItem.Text = "Shipping";
            // 
            // shippingOrdersToolStripMenuItem
            // 
            this.shippingOrdersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAllShippingOrders,
            this.tsmiMyOrders,
            this.tsmiPickList,
            this.tsmiPackList});
            this.shippingOrdersToolStripMenuItem.Name = "shippingOrdersToolStripMenuItem";
            this.shippingOrdersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.shippingOrdersToolStripMenuItem.Text = "Orders";
            // 
            // tsmiAllShippingOrders
            // 
            this.tsmiAllShippingOrders.Name = "tsmiAllShippingOrders";
            this.tsmiAllShippingOrders.Size = new System.Drawing.Size(152, 22);
            this.tsmiAllShippingOrders.Text = "All Orders";
            this.tsmiAllShippingOrders.Click += new System.EventHandler(this.tsmiAllShippingOrders_Click);
            // 
            // tsmiMyOrders
            // 
            this.tsmiMyOrders.Name = "tsmiMyOrders";
            this.tsmiMyOrders.Size = new System.Drawing.Size(152, 22);
            this.tsmiMyOrders.Text = "My Orders";
            this.tsmiMyOrders.Click += new System.EventHandler(this.tsmiMyOrders_Click);
            // 
            // tsmiPickList
            // 
            this.tsmiPickList.Name = "tsmiPickList";
            this.tsmiPickList.Size = new System.Drawing.Size(152, 22);
            this.tsmiPickList.Text = "Pick List";
            this.tsmiPickList.Click += new System.EventHandler(this.tsmiPickList_Click);
            // 
            // tsmiPackList
            // 
            this.tsmiPackList.Name = "tsmiPackList";
            this.tsmiPackList.Size = new System.Drawing.Size(152, 22);
            this.tsmiPackList.Text = "Pack List";
            this.tsmiPackList.Click += new System.EventHandler(tsmiPackList_Click);
            // 
            // tsmiShippingTerms
            // 
            this.tsmiShippingTerms.Name = "tsmiShippingTerms";
            this.tsmiShippingTerms.Size = new System.Drawing.Size(152, 22);
            this.tsmiShippingTerms.Text = "Terms";
            // 
            // tsmiShippingVendors
            // 
            this.tsmiShippingVendors.Name = "tsmiShippingVendors";
            this.tsmiShippingVendors.Size = new System.Drawing.Size(152, 22);
            this.tsmiShippingVendors.Text = "Vendors";
            // 
            // frmStartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 575);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmStartUp";
            this.Text = "frmStartUp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shippingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shippingOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAllShippingOrders;
        private System.Windows.Forms.ToolStripMenuItem tsmiMyOrders;
        private System.Windows.Forms.ToolStripMenuItem tsmiPickList;
        private System.Windows.Forms.ToolStripMenuItem tsmiPackList;
        private System.Windows.Forms.ToolStripMenuItem tsmiShippingTerms;
        private System.Windows.Forms.ToolStripMenuItem tsmiShippingVendors;

    }
}