﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

namespace com.Farouche
{
    public partial class frmOpenVendorOrders : Form
    {
        
        private VendorOrderManager _vendorOrdersManager;
        private ReceivingManager _receivingManager;
        private Vendor vendor;
        private VendorOrder vendorOrder;
        private List<VendorOrder> orderList;
        private VendorOrderLineItem vendorOrderLineItem;
        

        public frmOpenVendorOrders()
        {
            InitializeComponent();
            

        }

        private void frmOpenVendorOrders_Load(object sender, EventArgs e)
        {

            
            _receivingManager = new ReceivingManager();

            createVendorOrder();
            fillVendorDropDown();
            fillListView(lvOpenVendorOrders, _receivingManager.GetAllOpenOrders());

            
            
        }

        
           
        private void fillVendorDropDown()
        {
           
            string vendorListString = "";
          
            List<VendorOrder> vendorList = new List<VendorOrder>();

            vendorList = _receivingManager.GetAllOpenOrders();

            foreach (VendorOrder v in vendorList)
            {
                cbGetVendorsById.Items.Add(v.VendorID.ToString());
            }

            
            
        }

            

        

        private void fillListView(ListView lv, List<VendorOrder> orderList)
        {
            
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var vendorOrder in orderList)
            {
                var item = new ListViewItem();


                item.Text = vendorOrder.Id.ToString();
                item.SubItems.Add(vendorOrder.VendorID.ToString());
                item.SubItems.Add(vendorOrder.Name);
                item.SubItems.Add(vendorOrder.DateOrdered.ToString());
                item.SubItems.Add(vendorOrder.NumberOfShipments.ToString());


                lv.Items.Add(item);
            }

            lv.Columns.Add("Vendor OrderID");
            lv.Columns.Add("VendorID");
            lv.Columns.Add("Vendor Name");
            lv.Columns.Add("Date Ordered");
            lv.Columns.Add("Number of Shipments");


            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
     
        }

       

        private void lvOpenVendorOrders_Click(object sender, EventArgs e)
        {
            lvOpenVendorOrders.FullRowSelect = true;
            var selectedRow = lvOpenVendorOrders.SelectedItems;
            if (selectedRow.Count != 0)
            {
                vendorOrder = new VendorOrder(Int32.Parse(selectedRow[0].Text), Int32.Parse(selectedRow[0].SubItems[1].Text));
                vendorOrder.DateOrdered = Convert.ToDateTime(selectedRow[0].SubItems[3].Text);
                vendorOrder.NumberOfShipments = Int32.Parse(selectedRow[0].SubItems[4].Text);

                frmReceiving _frmReceiving = new frmReceiving(vendorOrder);
                _frmReceiving.Show();
                _frmReceiving.BringToFront();
                

            }  
        }

        private void btngetAllOpenOrdersByVendor_Click(object sender, EventArgs e)
        {

            
            
            vendor = new Vendor(Int32.Parse(cbGetVendorsById.SelectedItem.ToString()));
            orderList = _receivingManager.GetAllOpenOrdersByVendor(vendor);
            fillListView(lvOpenVendorOrders, orderList);


        }

        private void createVendorOrder()
        {


            _vendorOrdersManager = new VendorOrderManager();
            
            vendorOrder = new VendorOrder(1);

            vendorOrder.Name = "Target";

            

            vendorOrder.DateOrdered = DateTime.Today;
            vendorOrder.NumberOfShipments = 4;
            _vendorOrdersManager.AddVendorOrder(vendorOrder);

            vendorOrderLineItem = new VendorOrderLineItem(1, 1);
            vendorOrderLineItem.Name = "Target";
            vendorOrderLineItem.QtyOrdered = 10;
            vendorOrderLineItem.ProductID = 1;
            vendorOrderLineItem.VendorOrderId = 1;
            vendorOrderLineItem.LineItemTotal = 20.00;
            vendorOrder.AddLineItem(vendorOrderLineItem);
            

        }

        private void cbGetVendorsById_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillVendorDropDown();
        }
        
     
    }
}
