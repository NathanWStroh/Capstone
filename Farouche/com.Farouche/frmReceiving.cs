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
        private List<VendorOrderLineItem> vendorOrderLineItemList;
        private frmReceivingNotes _frmReceivingNotes;
        



        public frmReceiving()
        {
            InitializeComponent();
        }

        public frmReceiving(VendorOrder vendorOrder)
        {
            InitializeComponent();
            this.vendorOrder = vendorOrder;
            
            txtVendorOrderID.Text = vendorOrder.Id.ToString();
            txtVendorName.Text = vendorOrder.Name;
            txtNumberofShipments.Text = vendorOrder.NumberOfShipments.ToString();

            //Do cast
            // txtDateOrdered.Text = vendorOrder.DateOrdered;
            //VendorOrderLineItem vendorOrderLineItem1 = new VendorOrderLineItem(vendorOrder.VendorOrderID, vendorOrder.ProductID);
            //vendorOrderLineItem1.VendorOrderId = vendorOrder.VendorOrderID;
            //vendorOrderLineItem1.ProductID = vendorOrder.ProductID;
            //vendorOrderLineItem1.Name = "mouse";
            //vendorOrderLineItem1.QtyOrdered = 25;



            vendorOrderLineItemList = new List<VendorOrderLineItem>();
           // vendorOrderLineItemList.Add(vendorOrderLineItem1);
            populateVendorOrderLineItems(lvVendorOrderLineItems, vendorOrder);
            
        }

        private void frmReceiving_Load(object sender, EventArgs e)
        {

            
        }

        private void populateVendorOrderLineItems(ListView lv, VendorOrder vendorOrder)
        {
            receivingManager = new ReceivingManager();
            
            vendorOrderLineItemList = receivingManager.GetAllLineItemsByVendorOrder(vendorOrder);
            lv.Items.Clear();
            lv.Columns.Clear();
            foreach (var vendorOrderLineItem in vendorOrderLineItemList)
            {
                var item = new ListViewItem();
                item.Text = vendorOrderLineItem.ProductID.ToString();
                //item.SubItems.Add(vendorOrderLineItem.UnitPrice.ToString());
                item.SubItems.Add(vendorOrderLineItem.QtyOrdered.ToString());
                item.SubItems.Add(vendorOrderLineItem.QtyReceived.ToString());
                item.SubItems.Add(vendorOrderLineItem.QtyReceived.ToString());
                item.SubItems.Add(vendorOrderLineItem.QtyDamaged.ToString());
                //item.SubItems.Add(vendorOrderLineItem.TotalPrice.ToString());
                item.SubItems.Add(vendorOrderLineItem.Note);
                lv.Items.Add(item);
            }

            lv.Columns.Add("ProductID");
            //lv.Columns.Add("Unit Price");
            lv.Columns.Add("Qty Ordered");
            lv.Columns.Add("Qty Received");
            lv.Columns.Add("Total Quantity");
            lv.Columns.Add("Qty Damaged");
            //lv.Columns.Add("Total Price");
            lv.Columns.Add("Note");


            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnAddLineItemtoCurrentListView_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            lvVendorOrderLineItems.FullRowSelect = true;
            var selectedRow = lvVendorOrderLineItems.SelectedItems;
            int productID = Int32.Parse(selectedRow[0].Text);
            var id = Int32.Parse(txtVendorOrderID.Text);
            
            _frmReceivingNotes = new frmReceivingNotes(vendorOrder.Id, productID);

            //vendorOrder.VendorOrderID = Int32.Parse(txtVendorOrderID.Text);
            
           // _frmReceivingNotes = new frmReceivingNotes(vendorOrder.VendorOrderID, productID);
            _frmReceivingNotes.BringToFront();
            _frmReceivingNotes.Show();

        }

        private void btnUpdateLineItem_Click(object sender, EventArgs e)
        {


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {

        }

       
    }
}
