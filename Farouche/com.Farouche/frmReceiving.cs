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
    public partial class frmReceiving : Form
    {
        private Vendor vendor;
        private VendorOrder vendorOrder;
        private VendorOrderLineItem vendorOrderLineItem;
        private ReceivingManager receivingManager;
        



        public frmReceiving()
        {
            InitializeComponent();
        }

        public frmReceiving(VendorOrder vendorOrder)
        {
            InitializeComponent();
            this.vendorOrder = vendorOrder;
            txtVendorOrderID.Text = vendorOrder.VendorOrderID.ToString();
            txtVendorName.Text = vendorOrder.Name;
            txtNumberofShipments.Text = vendorOrder.NumberOfShipments.ToString();
            txtDateOrdered.Text = vendorOrder.DateOrdered;

        }

        private void frmReceiving_Load(object sender, EventArgs e)
        {

            populateVendorOrderLineItems();
        }

        private void populateVendorOrderLineItems()
        {
            //orderList = _receivingManager.GetAllOpenOrders();
            //lv.Items.Clear();
            //lv.Columns.Clear();
            //foreach (var vendorOrder in orderList)
            //{
            //    var item = new ListViewItem();
            //    item.Text = vendorOrder.Id.ToString();
            //    item.SubItems.Add(vendorOrder.Name);
            //    item.SubItems.Add(vendorOrder.);
               
               
            //    lv.Items.Add(item);
            //}
        }

       
    }
}
