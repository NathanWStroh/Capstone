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

namespace com.Farouche
{
    public partial class frmOpenVendorOrders : Form
    {
        private VendorManager _vendorManager;
        private ReceivingManager _receivingManager;
        private Vendor vendor;
        private VendorOrder vendorOrder;
        private List<VendorOrder> orderList;
        public frmOpenVendorOrders()
        {
            InitializeComponent();

        }

        private void frmOpenVendorOrders_Load(object sender, EventArgs e)
        {
            
            _receivingManager = new ReceivingManager();

            fillVendorDropDown();

            VendorOrder vendorOrder1 = new VendorOrder();
            VendorOrder vendorOrder2 = new VendorOrder();


            vendorOrder1.VendorOrderID = 1;
            vendorOrder1.Name = "Sam's";
            vendorOrder1.DateOrdered = "1/24/2014";
            vendorOrder1.NumberOfShipments = 3;

            vendorOrder2.VendorOrderID = 2;
            vendorOrder2.Name = "Target";
            vendorOrder2.DateOrdered = "1/25/2014";
            vendorOrder2.NumberOfShipments = 1;

            orderList = new List<VendorOrder>();
            orderList.Add(vendorOrder1);
            orderList.Add(vendorOrder2);

            fillListView(lvOpenVendorOrders, orderList);
            
            
        }

        
           
        private void fillVendorDropDown()
        {
            _vendorManager = new VendorManager();
            List<Vendor> vendorList = new List<Vendor>();


            vendorList = _vendorManager.GetVendors();

            foreach (Vendor v in vendorList)
            {

                cbGetVendorsByName.Items.Add(v.Name);
            }

        }

        private void fillListView(ListView lv, List<VendorOrder> orderList)
        {
            
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var vendorOrder in orderList)
            {
                var item = new ListViewItem();
                item.Text = vendorOrder.VendorOrderID.ToString();
                item.SubItems.Add(vendorOrder.Name);
                item.SubItems.Add(vendorOrder.DateOrdered);
                item.SubItems.Add(vendorOrder.NumberOfShipments.ToString());
                lv.Items.Add(item);
            }

            lv.Columns.Add("Vendor OrderID");
            lv.Columns.Add("Vendor Name");
            lv.Columns.Add("Date Ordered");
            lv.Columns.Add("Number of Shipments");

            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
     
        }

        private void cbGetVendorsByName_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            vendor = new Vendor();
            vendor.Name = cbGetVendorsByName.Text;
            //fillListViewByVendor(lvOpenVendorOrders, ); 
            
            
        }

        //private void fillListViewByVendor(ListView lv, List<VendorOrder> orderList)
        //{
        //    orderList = _receivingManager.GetAllOpenOrdersByVendor(vendor);
        //    lv.Items.Clear();
        //    lv.Columns.Clear();
        //    foreach (var vendorOrder in orderList)
        //    {
        //        var item = new ListViewItem();
        //        item.Text = vendorOrder.Id.ToString();
        //        item.SubItems.Add(vendorOrder.Name);
        //        item.SubItems.Add(vendorOrder.DateOrdered);
        //        item.SubItems.Add(vendorOrder.NumberOfShipments.ToString());



        //        lv.Items.Add(item);
        //    }
        //}

        private void lvOpenVendorOrders_Click(object sender, EventArgs e)
        {
            lvOpenVendorOrders.FullRowSelect = true;
            var selectedRow = lvOpenVendorOrders.SelectedItems;
            
           
            
           
           
               vendorOrder = new VendorOrder();
               foreach (ListViewItem item in selectedRow)
               {
                   vendorOrder.VendorOrderID = Int32.Parse(item.SubItems[0].Text);
                   vendorOrder.Name = item.SubItems[1].Text;
                   vendorOrder.DateOrdered = item.SubItems[2].Text;
                   vendorOrder.NumberOfShipments = Int32.Parse(item.SubItems[3].Text);
               }
               frmReceiving _frmReceiving = new frmReceiving(vendorOrder);
               _frmReceiving.BringToFront();
               _frmReceiving.Show();

               
        }
        

        private void getVendorOrders()
        {
            VendorOrder vendorOrder1 = new VendorOrder();
            VendorOrder vendorOrder2 = new VendorOrder();
            

            vendorOrder1.VendorOrderID = 1;
            vendorOrder1.Name = "Sam's";
            vendorOrder1.DateOrdered = "1/24/2014";
            vendorOrder1.NumberOfShipments = 3;

            vendorOrder2.VendorOrderID = 2;
            vendorOrder2.Name = "Target";
            vendorOrder2.DateOrdered = "1/25/2014";
            vendorOrder2.NumberOfShipments = 1;

            List<VendorOrder> orderList = new List<VendorOrder>();
            orderList.Add(vendorOrder1);
            orderList.Add(vendorOrder2);




        }

        




            
        
    }
}
