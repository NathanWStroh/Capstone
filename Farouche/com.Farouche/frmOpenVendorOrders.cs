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
        private VendorManager _vendorManager;
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

            
            fillVendorDropDown();
            fillListView(lvOpenVendorOrders, _receivingManager.GetAllOpenOrders());

            

           

            orderList = _receivingManager.GetAllOpenOrders();

            
            //fillVendorDropDown(vendorList);

            fillListView(lvOpenVendorOrders, orderList);
            
            //fillListView(lvOpenVendorOrders, _receivingManager.GetAllOpenOrders());
            
        }

        private void fillVendorDropDown()
        {

           
            

          
            List<Vendor> vendorList = new List<Vendor>();
            _vendorManager = new VendorManager();

            vendorList = _vendorManager.GetVendors();

            foreach (Vendor v in vendorList)

            {
                cbGetVendorsById.Items.Add(v.Id.ToString() + " " + v.Name);
            }
        }

        private void fillListView(ListView lv, List<VendorOrder> orderList)

        {      

            lv.Items.Clear();
            lv.Columns.Clear();
            _vendorManager = new VendorManager();
            foreach (var vendorOrder in orderList)
            {
                var item = new ListViewItem();
                item.Text = vendorOrder.Id.ToString();
                item.SubItems.Add(vendorOrder.VendorID.ToString());
                item.SubItems.Add(_vendorManager.GetVendor(vendorOrder.VendorID).Name);
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
            int index = cbGetVendorsById.SelectedItem.ToString().IndexOf(" ");
            string id = cbGetVendorsById.SelectedItem.ToString().Substring(0, index);
            vendor = new Vendor(Int32.Parse(id));
            orderList = _receivingManager.GetAllOpenOrdersByVendor(vendor);
            fillListView(lvOpenVendorOrders, orderList);
        }


        

        private void cbGetVendorsById_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillVendorDropDown();
        }

        private void lvOpenVendorOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            lvOpenVendorOrders.FullRowSelect = true;
            var selectedItem = lvOpenVendorOrders.SelectedItems;
            if (selectedItem.Count != 0)
            {

                VendorOrder selectedVendorOrder = new VendorOrder(Int32.Parse(selectedItem[0].Text.ToString()), Int32.Parse(selectedItem[0].SubItems[1].Text.ToString()));
                selectedVendorOrder.DateOrdered = DateTime.Parse(selectedItem[0].SubItems[3].Text);
                selectedVendorOrder.NumberOfShipments = Int32.Parse(selectedItem[0].SubItems[4].Text);
                frmReceiving _frmReceiving = new frmReceiving(selectedVendorOrder);
                _frmReceiving.Show();
                _frmReceiving.BringToFront();
            }
            

            
        }

       
        


        private void frmOpenVendorOrders_FormClosed(object sender, FormClosedEventArgs e)
        {
            Instance = null;
        }
    }
}
