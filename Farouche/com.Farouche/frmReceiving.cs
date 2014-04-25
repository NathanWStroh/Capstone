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
        private ReceivingManager _receivingManager;
        private List<VendorOrderLineItem> vendorOrderLineItemList;
        private frmReceivingNotes _frmReceivingNotes;
        private VendorOrderManager _vendorOrderManager;
        private FrmUpdateVendorOrderLineItem _frmUpdateVendorOrderLineItem;
        



        public frmReceiving()
        {
            InitializeComponent();
        }

        public frmReceiving(VendorOrder vendorOrder)
        {
            
            InitializeComponent();

            this.vendorOrder = vendorOrder;



            

            txtVendorOrderID.Text = vendorOrder.Id.ToString();
            //txtVendorName.Text = vendorOrder.Name;
            txtNumberofShipments.Text = vendorOrder.NumberOfShipments.ToString();
            txtDateOrdered.Text = vendorOrder.DateOrdered.ToString();
            //txtNumberofShipments.Text = vendorOrder.NumberOfShipments.ToString();





            populateVendorOrderLineItems(lvVendorOrderLineItems, this.vendorOrder);
            
            
            
        }

        private void frmReceiving_Load(object sender, EventArgs e)
        {
            
            
        }

        private void populateVendorOrderLineItems(ListView lv, VendorOrder vendorOrder)
        {
            
            
            
            lv.Items.Clear();
            lv.Columns.Clear();
            _receivingManager = new ReceivingManager();
            List<VendorOrderLineItem> vendorOrderLineItemList = new List<VendorOrderLineItem>();
            vendorOrderLineItemList = _receivingManager.GetAllLineItemsByVendorOrder(vendorOrder);
            
            foreach(var vendorOrderLineItem in vendorOrderLineItemList)
            {
                
                var item = new ListViewItem();
                item.Text = vendorOrderLineItem.ProductID.ToString();
                //item.SubItems.Add(vendorOrderLineItem.Name.ToString());
                item.SubItems.Add(vendorOrderLineItem.QtyOrdered.ToString());
                item.SubItems.Add(vendorOrderLineItem.QtyReceived.ToString());
                item.SubItems.Add(vendorOrderLineItem.QtyDamaged.ToString());
                item.SubItems.Add(vendorOrderLineItem.LineItemTotal.ToString());
                //item.SubItems.Add(vendorOrderLineItem.Note.ToString());

                lv.Items.Add(item);

            }

            lv.Columns.Add("ProductID");
            //lv.Columns.Add("Name");
            lv.Columns.Add("Qty Ordered");
            lv.Columns.Add("Qty Received");
            lv.Columns.Add("Qty Damaged");
            lv.Columns.Add("LineItemTotal");
            lv.Columns.Add("Note");


            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void btnAddLineItemtoCurrentListView_Click(object sender, EventArgs e)
        {
            FrmAddLineItemToVendorOrder _FrmAddLineItemToVendorOrder = new FrmAddLineItemToVendorOrder(vendorOrder);
            _FrmAddLineItemToVendorOrder.Show();
            _FrmAddLineItemToVendorOrder.BringToFront();
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            
            lvVendorOrderLineItems.FullRowSelect = true;
            var selectedRow = lvVendorOrderLineItems.SelectedItems;
            if (selectedRow.Count != 0)
            {
                int productID = Int32.Parse(selectedRow[0].Text);
                var id = Int32.Parse(txtVendorOrderID.Text);

                _frmReceivingNotes = new frmReceivingNotes(id, productID);

                
                _frmReceivingNotes.BringToFront();
                _frmReceivingNotes.Show();
            }
        }

        private void btnUpdateLineItem_Click(object sender, EventArgs e)
        {
            lvVendorOrderLineItems.FullRowSelect = true;
            var selectedRow = lvVendorOrderLineItems.SelectedItems;
            int productID = Int32.Parse(selectedRow[0].Text);
            var id = Int32.Parse(txtVendorOrderID.Text);


            VendorOrderLineItem item = new VendorOrderLineItem(id, productID);
            item.ProductID = Int32.Parse(selectedRow[0].SubItems[1].Text);
            item.Name = selectedRow[0].SubItems[2].Text;
            item.QtyOrdered = Int32.Parse(selectedRow[0].SubItems[3].Text);
            item.QtyReceived = Int32.Parse(selectedRow[0].SubItems[4].Text);
            item.QtyDamaged = Int32.Parse(selectedRow[0].SubItems[5].Text);
            item.LineItemTotal = Double.Parse(selectedRow[0].SubItems[6].Text);

            int newQuantityOrdered = item.QtyOrdered;

           _frmUpdateVendorOrderLineItem = new FrmUpdateVendorOrderLineItem(item);
           _frmUpdateVendorOrderLineItem.Show();
           _frmUpdateVendorOrderLineItem.BringToFront();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {

        }

        private void lvVendorOrderLineItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

       
    }
}
