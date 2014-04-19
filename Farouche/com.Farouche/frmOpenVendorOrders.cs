using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;

/*
*                               Changelog
* Date         By               Ticket          Version          Description
* 04/19/2014   Kaleb Wendel                                      Adjusted class to implement a singleton pattern so only one form can be instantiated.
*/

namespace com.Farouche.Presentation
{
    public partial class frmOpenVendorOrders : Form
    {     
        private VendorOrderManager _vendorOrdersManager;
        private ReceivingManager _receivingManager;
        private Vendor vendor;
        private VendorOrder vendorOrder;
        private List<VendorOrder> orderList;
        private VendorOrderLineItem vendorOrderLineItem;
        public static frmOpenVendorOrders Instance;

        public frmOpenVendorOrders()
        {
            InitializeComponent();
            Instance = this;
        }

        private void frmOpenVendorOrders_Load(object sender, EventArgs e)
        {
            _receivingManager = new ReceivingManager();

            //createVendorOrder();
            //fillVendorDropDown();
            //fillListView(lvOpenVendorOrders, _receivingManager.GetAllOpenOrders());

            //vendorOrder1.VendorOrderID = 1;
            //vendorOrder1.VendorID = 1;
            //vendorOrder1.ProductID = 1;
            //vendorOrder1.Name = "Sam's";
            //vendorOrder1.DateOrdered = "1/24/2014";
            //vendorOrder1.NumberOfShipments = 3;

            //vendorOrder2.VendorOrderID = 2;
            //vendorOrder2.VendorID = 2;
            //vendorOrder2.ProductID = 2;
            //vendorOrder2.Name = "Target";
            //vendorOrder2.DateOrdered = "1/25/2014";
            //vendorOrder2.NumberOfShipments = 1;

            //orderList = _receivingManager.GetAllOpenOrders();

            //vendorList = new List<Vendor>();
            //var vendor1 = new Vendor();
            //var vendor2 = new Vendor();
            ////vendor1.Name = vendorOrder1.Name;
            ////vendor2.Name = vendorOrder2.Name;
            //vendorList.Add(vendor1);
            //vendorList.Add(vendor2);
            //fillVendorDropDown(vendorList);

            fillListView(lvOpenVendorOrders, orderList);
            //fillListView(lvOpenVendorOrders, _receivingManager.GetAllOpenOrders());
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

        private void frmOpenVendorOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }
    }
}
