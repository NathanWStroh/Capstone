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
        private List<VendorOrderLineItem> vendorOrderLineItemList = new List<VendorOrderLineItem>();
        private frmReceivingNotes _frmReceivingNotes;
        private VendorOrderManager _vendorOrderManager = new VendorOrderManager();
        private FrmUpdateVendorOrderLineItem _frmUpdateVendorOrderLineItem;
        private ProductManager _productManager;
        



        public frmReceiving()
        {
            InitializeComponent();
        }

        public frmReceiving(VendorOrder vendorOrder)
        {
            
            InitializeComponent();
            

            this.vendorOrder = vendorOrder;

            _receivingManager = new ReceivingManager();

            vendorOrderLineItemList = _receivingManager.GetAllLineItemsByVendorOrder(vendorOrder);

            VendorManager _vendorManager = new VendorManager();
            
            

            txtVendorOrderID.Text = vendorOrder.Id.ToString();
            txtVendorName.Text = _vendorManager.GetVendor(vendorOrder.VendorID).Name.ToString();
            txtNumberofShipments.Text = _vendorOrderManager.getVendorOrder(vendorOrder.Id).NumberOfShipments.ToString();
            txtDateOrdered.Text = _vendorOrderManager.getVendorOrder(vendorOrder.Id).DateOrdered.ToString();

            populateVendorOrderLineItems(vendorOrder, dgvReceiving, vendorOrderLineItemList);

            if (dgvReceiving.Rows.Count == 0)
            {
                btnAddNote.Hide();
                btnUpdateLineItem.Hide();
                
            }
            else
            {
                btnAddNote.Show();
                btnUpdateLineItem.Show();
            }
            
        }

        private void frmReceiving_Load(object sender, EventArgs e)

        {
            VendorOrder vendorOrder = this.vendorOrder;
            DataGridView dgv = dgvReceiving;

            populateVendorOrderLineItems(vendorOrder, dgvReceiving, vendorOrderLineItemList);
  
        }

        private void populateVendorOrderLineItems(VendorOrder vendorOrder, DataGridView dgv, List<VendorOrderLineItem> vendorOrderLineItemList)
        {

            _productManager = new ProductManager();

            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.ColumnCount = 6;
            dgv.Columns[0].Name = "ProductID";
            dgv.Columns[1].Name = "Product Name";
            dgv.Columns[2].Name = "Quantity Received";
            dgv.Columns[3].Name = "Quantity Ordered";
            dgv.Columns[4].Name = "Quantity Damaged";
            dgv.Columns[5].Name = "Notes";
 
            foreach (var vendorOrderLineItem in vendorOrderLineItemList)
            {

                var productID = vendorOrderLineItem.ProductID;
                var productName = _productManager.GetProduct(vendorOrderLineItem.ProductID).Name;
                var quantityOrdered = vendorOrderLineItem.QtyOrdered;
                var quantityReceived = vendorOrderLineItem.QtyReceived;
                var quantityDamaged = vendorOrderLineItem.QtyDamaged;
                var note = vendorOrderLineItem.Note;
                dgv.Rows.Add(productID, productName, quantityReceived, quantityOrdered, quantityDamaged, note);

            }


            DataGridViewCheckBoxColumn finalize = new DataGridViewCheckBoxColumn();
            finalize.HeaderText = "Finalize Line Item";
  
 
            dgv.Columns.Add(finalize);

            dgvReceiving.ReadOnly = true;
            

           
        }


        private void btnAddLineItemtoCurrentListView_Click(object sender, EventArgs e)
        {
            FrmAddLineItemToVendorOrder _FrmAddLineItemToVendorOrder = new FrmAddLineItemToVendorOrder(vendorOrder);
            _FrmAddLineItemToVendorOrder.Show();
            _FrmAddLineItemToVendorOrder.BringToFront();
            this.Close();
        }

        private void btnUpdateLineItem_Click(object sender, EventArgs e)
        {

            try
            {
                VendorManager _vendorManager = new VendorManager();
                int productID = Int32.Parse(dgvReceiving.SelectedCells[0].Value.ToString());
                var id = Int32.Parse(txtVendorOrderID.Text);
                var vendorName = txtVendorName.Text;
                var vendorID = _vendorManager.GetVendor(vendorOrder.VendorID).Id;

                VendorOrderLineItem item = new VendorOrderLineItem(id, productID);
                item.ProductID = productID;
                item.Name = dgvReceiving.SelectedCells[1].Value.ToString();
                item.QtyOrdered = Int32.Parse(dgvReceiving.SelectedCells[3].Value.ToString());
                item.QtyReceived = Int32.Parse(dgvReceiving.SelectedCells[2].Value.ToString());
                item.QtyDamaged = Int32.Parse(dgvReceiving.SelectedCells[4].Value.ToString());


                _frmUpdateVendorOrderLineItem = new FrmUpdateVendorOrderLineItem(item, vendorName, vendorID);
                _frmUpdateVendorOrderLineItem.Show();
                _frmUpdateVendorOrderLineItem.BringToFront();
                this.Close();
            }

            catch
            {
                MessageBox.Show("You have to select a line item to Update a Line Item");
                return;
            }
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                VendorManager _vendorManager = new VendorManager();
                int productID = Int32.Parse(dgvReceiving.SelectedCells[0].Value.ToString());
                var id = Int32.Parse(txtVendorOrderID.Text);
                var vendorName = txtVendorName.Text;
                var vendorID = _vendorManager.GetVendor(vendorOrder.VendorID).Id;

                VendorOrderLineItem item = new VendorOrderLineItem(id, productID);
                item.ProductID = productID;
                item.Name = dgvReceiving.SelectedCells[1].Value.ToString();
                item.QtyOrdered = Int32.Parse(dgvReceiving.SelectedCells[3].Value.ToString());
                item.QtyReceived = Int32.Parse(dgvReceiving.SelectedCells[2].Value.ToString());
                item.QtyDamaged = Int32.Parse(dgvReceiving.SelectedCells[4].Value.ToString());


                _frmUpdateVendorOrderLineItem = new FrmUpdateVendorOrderLineItem(item, vendorName, vendorID);
                _frmUpdateVendorOrderLineItem.Show();
                _frmUpdateVendorOrderLineItem.BringToFront();
                this.Close();
            }

            catch
            {
                MessageBox.Show("You have to select a line item to Update a Line Item");
                return;
            }
        }
        


        private void btnAddNote_Click(object sender, EventArgs e)
        {
            
                var id = Int32.Parse(txtVendorOrderID.Text);

                var productID = Int32.Parse(dgvReceiving.SelectedCells[0].Value.ToString());
                VendorOrderManager _vendorOrderManager = new VendorOrderManager();
                VendorOrder vendorOrder = _vendorOrderManager.getVendorOrder(id);


                _frmReceivingNotes = new frmReceivingNotes(id, productID);


                _frmReceivingNotes.BringToFront();
                _frmReceivingNotes.Show();
                this.Close();
            

         
        }

        private void btnUpdateLineItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                VendorManager _vendorManager = new VendorManager();
                int productID = Int32.Parse(dgvReceiving.SelectedCells[0].Value.ToString());
                var id = Int32.Parse(txtVendorOrderID.Text);
                var vendorName = txtVendorName.Text;
                var vendorID = _vendorManager.GetVendor(vendorOrder.VendorID).Id;

                VendorOrderLineItem item = new VendorOrderLineItem(id, productID);
                item.ProductID = productID;
                item.Name = dgvReceiving.SelectedCells[1].Value.ToString();
                item.QtyOrdered = Int32.Parse(dgvReceiving.SelectedCells[3].Value.ToString());
                item.QtyReceived = Int32.Parse(dgvReceiving.SelectedCells[2].Value.ToString());
                item.QtyDamaged = Int32.Parse(dgvReceiving.SelectedCells[4].Value.ToString());


                _frmUpdateVendorOrderLineItem = new FrmUpdateVendorOrderLineItem(item, vendorName, vendorID);
                _frmUpdateVendorOrderLineItem.Show();
                _frmUpdateVendorOrderLineItem.BringToFront();
                this.Close();
            }

            catch
            {
                MessageBox.Show("You have to select a line item to Update a Line Item");
                return;
            }
        }
 
    }
}
