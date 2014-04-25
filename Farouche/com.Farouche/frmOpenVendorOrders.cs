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


//commented out 38-46. When I merged it, it was broken.
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
        

        public frmOpenVendorOrders()
        {
            InitializeComponent();
            

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


       

        private void btngetAllOpenOrdersByVendor_Click(object sender, EventArgs e)
        {

            int index = cbGetVendorsById.SelectedItem.ToString().IndexOf(" ");
            
            vendor = new Vendor(Int32.Parse(cbGetVendorsById.SelectedItem.ToString().Substring(0, index)));
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

       
        

    }
}
