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
            dgvReceiving.CellClick += new DataGridViewCellEventHandler(dgvReceiving_CellClick);//updates Quantity Received
            dgvReceiving.CellClick += new DataGridViewCellEventHandler(dgvReceiving_CellClick2);//updates Quantity Damaged
            dgvReceiving.CellClick += new DataGridViewCellEventHandler(dgvReceiving_CellClick3);//adds Notes
            dgvReceiving.CellClick += new DataGridViewCellEventHandler(dgvReceiving_CellClick4);//allows quantity received column to be edited
            dgvReceiving.CellClick += new DataGridViewCellEventHandler(dgvReceiving_CellClick5);//allows quantity damaged column to be edited
            dgvReceiving.CellClick += new DataGridViewCellEventHandler(dgvReceiving_CellClick6);//finalize lineitems
            dgvReceiving.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);//adds Row
            dgvReceiving.CellBeginEdit += dgvReceiving_CellBeginEdit;
            dgvReceiving.CellValidating += dgvReceiving_CellValidating;
            dgvReceiving.CellEndEdit += dgvReceiving_CellEndEdit;

            dgvReceiving.ClearSelection();
            dgvReceiving.Rows.Clear();
             VendorManager _vendorManager = new VendorManager();

            txtVendorOrderID.Text = vendorOrder.Id.ToString();
            txtVendorName.Text = _vendorManager.GetVendor(vendorOrder.VendorID).Name.ToString();
            txtVendorID.Text = _vendorManager.GetVendor(vendorOrder.VendorID).Id.ToString();
            txtNumberofShipments.Text = _vendorOrderManager.getVendorOrder(vendorOrder.Id).NumberOfShipments.ToString();
            txtDateOrdered.Text = _vendorOrderManager.getVendorOrder(vendorOrder.Id).DateOrdered.ToString();
            
            DataGridViewTextBoxColumn productIDTextBoxColumn = new DataGridViewTextBoxColumn();
            productIDTextBoxColumn.HeaderText = "Product ID";
            productIDTextBoxColumn.Name = "Product ID";
            productIDTextBoxColumn.ReadOnly = true;

            DataGridViewTextBoxColumn productNameTextBoxColumn = new DataGridViewTextBoxColumn();
            productNameTextBoxColumn.HeaderText = "Product Name";
            productNameTextBoxColumn.Name = "Product Name";
            productIDTextBoxColumn.ReadOnly = true;

            DataGridViewTextBoxColumn quantityOrderedTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityOrderedTextBoxColumn.HeaderText = "Quantity Ordered";
            quantityOrderedTextBoxColumn.Name = "Quantity Ordered";
            productIDTextBoxColumn.ReadOnly = true;

            DataGridViewTextBoxColumn quantityReceivedTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityReceivedTextBoxColumn.HeaderText = "Quantity Received";
            quantityReceivedTextBoxColumn.Name = "Quantity Received";
            quantityReceivedTextBoxColumn.ReadOnly = false;


            DataGridViewTextBoxColumn quantityDamagedTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityDamagedTextBoxColumn.HeaderText = "Quantity Damaged";
            quantityDamagedTextBoxColumn.Name = "Quantity Damaged";
            quantityDamagedTextBoxColumn.ReadOnly = false;

            DataGridViewTextBoxColumn noteTextBoxColumn = new DataGridViewTextBoxColumn();
            noteTextBoxColumn.HeaderText = "Notes";
            noteTextBoxColumn.Name = "Notes";
            noteTextBoxColumn.ReadOnly = true;

            

            dgvReceiving.Columns.Add(productIDTextBoxColumn);
            dgvReceiving.Columns.Add(productNameTextBoxColumn);
            dgvReceiving.Columns.Add(quantityOrderedTextBoxColumn);
            dgvReceiving.Columns.Add(quantityReceivedTextBoxColumn);
            dgvReceiving.Columns.Add(quantityDamagedTextBoxColumn);
            dgvReceiving.Columns.Add(noteTextBoxColumn);
            



            //populateVendorOrderLineItems(vendorOrder);

            //vendorOrderLineItemList = _receivingManager.GetAllLineItemsByVendorOrder(vendorOrder);

           // populateVendorOrderLineItems(vendorOrder, vendorOrderLineItemList);

            //if (dgvReceiving.Rows.Count == 0)
            //{
            //    btnAddNote.Hide();
            //    btnUpdateLineItem.Hide();
                
            //}
            //else
            //{
            //    btnAddNote.Show();
            //    btnUpdateLineItem.Show();
            //}
            
        }



        private void frmReceiving_Load(object sender, EventArgs e)

        {
            //VendorOrder vendorOrder = this.vendorOrder;
            //DataGridView dgv = dgvReceiving;
            dgvReceiving.Rows.Clear();
            vendorOrder = new VendorOrder(Int32.Parse(txtVendorOrderID.Text.ToString()), Int32.Parse(txtVendorID.Text.ToString()));
            populateVendorOrderLineItems(vendorOrder);

            //populateVendorOrderLineItems(vendorOrder, dgvReceiving, vendorOrderLineItemList);
  
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex != dgvReceiving.Columns["Add Row"].Index)
            {
                return;
            }
            else
            {
                
                
                    vendorOrder = new VendorOrder(Int32.Parse(txtVendorOrderID.Text), Int32.Parse(txtVendorID.Text));

                    FrmAddLineItemToVendorOrder _FrmAddLineItemToVendorOrder = new FrmAddLineItemToVendorOrder(vendorOrder);
                    _FrmAddLineItemToVendorOrder.Show();
                    _FrmAddLineItemToVendorOrder.BringToFront();
  
            }
        }

        private void dgvReceiving_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvReceiving.Columns["Update Quantity Received"].Index)
            {
                return;
            }

            else
            {
                MessageBox.Show("Update Received");
            }
        }

        private void dgvReceiving_CellClick2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvReceiving.Columns["Update Quantity Damaged"].Index)
            {
                return;
            }

            else
            {
                MessageBox.Show("Update Damaged");
            }
        }

        private void dgvReceiving_CellClick3(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvReceiving.Columns["Add Note"].Index)
            {
                return;
            }

            else
            {
                MessageBox.Show("Add Note");
            }
        }

        private void dgvReceiving_CellClick4(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvReceiving.Columns["Quantity Received"].Index)
            {
                return;
            }

            else
            {
                    
                        
                        
             
                
                
                
            }
        }

        private void dgvReceiving_CellClick5(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvReceiving.Columns["Quantity Damaged"].Index)
            {
                return;
            }

            else
            {
                MessageBox.Show("Quantity Damaged");
            }
        }

        private void dgvReceiving_CellClick6(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvReceiving.Columns["Finalize Line Item"].Index)
            {
                return;
            }

            else
            {
                MessageBox.Show("Finalize Line Item");
            }
        }


private void dgvReceiving_CellBeginEdit(Object sender, DataGridViewCellCancelEventArgs e)
{
     //Here we save a current value of cell to some variable, that later we can compare with a new value
    Int32 oldQuantity = Int32.Parse(dgvReceiving.CurrentCell.Value.ToString());
    Int32 newQuantity = Int32.Parse(dgvReceiving.CurrentCell.Value.ToString());
    if (oldQuantity == newQuantity)
    {
        e.Cancel = true;
    }
    else
    {
        dgvReceiving.CurrentCell.Value = newQuantity;
    }
    
}

private void dgvReceiving_CellValidating(Object sender, DataGridViewCellValidatingEventArgs e)
{
    //Here you can add all kind of checks for new value
    
   
}

private void dgvReceiving_CellEndEdit(Object sender, DataGridViewCellEventArgs e)
{
    //Because CellEndEdit event occurs after CellValidating event(if not cancelled)
    //Here you can update new value to database
}
        private void populateVendorOrderLineItems(VendorOrder vendorOrder)
        {
            DataGridViewButtonColumn updateReceivedButtonColumn = new DataGridViewButtonColumn();
            updateReceivedButtonColumn.HeaderText = "Update Quantity Received";
            updateReceivedButtonColumn.Name = "Update Quantity Received";
            updateReceivedButtonColumn.Text = "Update Quantity Received";
            updateReceivedButtonColumn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn updateDamagedButtonColumn = new DataGridViewButtonColumn();
            updateDamagedButtonColumn.HeaderText = "Update Quantity Damaged";
            updateDamagedButtonColumn.Name = "Update Quantity Damaged";
            updateDamagedButtonColumn.Text = "Update Quantity Damaged";
            updateDamagedButtonColumn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn addNoteButtonColumn = new DataGridViewButtonColumn();
            addNoteButtonColumn.HeaderText = "Add Note";
            addNoteButtonColumn.Name = "Add Note";
            addNoteButtonColumn.Text = "Add Notes";
            addNoteButtonColumn.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn addRowButtonColumn = new DataGridViewButtonColumn();
            addRowButtonColumn.HeaderText = "Add Row";
            addRowButtonColumn.Name = "Add Row";
            addRowButtonColumn.Text = "Add Row";
            addRowButtonColumn.UseColumnTextForButtonValue = true;

            DataGridViewCheckBoxColumn finalize = new DataGridViewCheckBoxColumn();
            finalize.HeaderText = "Finalize Line Item";
            finalize.Name = "Finalize Line Item";
            
            _receivingManager = new ReceivingManager();
            _productManager = new ProductManager();

            vendorOrderLineItemList = _receivingManager.GetAllLineItemsByVendorOrder(vendorOrder);
            
            foreach (var vendorOrderLineItem in vendorOrderLineItemList)
            {
                string[] row = {vendorOrderLineItem.ProductID.ToString(), _productManager.GetProduct(vendorOrderLineItem.ProductID).Name, vendorOrderLineItem.QtyOrdered.ToString(), vendorOrderLineItem.QtyReceived.ToString(), vendorOrderLineItem.QtyDamaged.ToString(), vendorOrderLineItem.Note};
                dgvReceiving.Rows.Add(row);
                
            }

            dgvReceiving.Columns.Insert(6, updateReceivedButtonColumn);
            dgvReceiving.Columns.Insert(7, updateDamagedButtonColumn);
            dgvReceiving.Columns.Insert(8, addNoteButtonColumn);
            dgvReceiving.Columns.Insert(9, addRowButtonColumn);
            dgvReceiving.Columns.Insert(10, finalize);
            dgvReceiving.ReadOnly = true;
            

            

            //foreach (var vendorOrderLineItem in vendorOrderLineItemList)
            //{

            //    var productID = vendorOrderLineItem.ProductID;
            //    var productName = _productManager.GetProduct(vendorOrderLineItem.ProductID).Name;
            //    var quantityOrdered = vendorOrderLineItem.QtyOrdered;
            //    var quantityReceived = vendorOrderLineItem.QtyReceived;
            //    var quantityDamaged = vendorOrderLineItem.QtyDamaged;
            //    var note = vendorOrderLineItem.Note;
            //    dgvReceiving.Rows.Add(productID, productName, quantityReceived, quantityOrdered, quantityDamaged, note);

            //}

            

           
        }


        private void btnAddLineItemtoCurrentListView_Click(object sender, EventArgs e)
        {

            vendorOrder = new VendorOrder(Int32.Parse(txtVendorOrderID.Text), Int32.Parse(txtVendorID.Text));

            FrmAddLineItemToVendorOrder _FrmAddLineItemToVendorOrder = new FrmAddLineItemToVendorOrder(vendorOrder);
            _FrmAddLineItemToVendorOrder.Show();
            _FrmAddLineItemToVendorOrder.BringToFront();
            
        }

        private void btnUpdateLineItem_Click(object sender, EventArgs e)
        {

            try
            {
                VendorManager _vendorManager = new VendorManager();
                int productID = Int32.Parse(dgvReceiving.SelectedCells[0].Value.ToString());
                int id = Int32.Parse(txtVendorOrderID.Text);
                string vendorName = txtVendorName.Text;
                int vendorID = Int32.Parse(txtVendorID.Text);

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

            if (dgvReceiving.Rows.Count == 0)
            {
                return;
            }

            else
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
