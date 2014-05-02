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
    public partial class frmReceivingNotes : Form
    {
        private VendorOrder vendorOrder;
        private VendorOrderLineItem vendorOrderLineItem;
        private ReceivingManager _receivingManager;
       

        public frmReceivingNotes(int vendorOrderID, int productID)
        {
            InitializeComponent();
            txtVendorOrderID.Text = vendorOrderID.ToString();
            txtProductID.Text = productID.ToString();
            
        }



        private void btnUpdatedNote_Click(object sender, EventArgs e)
        {
            var note = txtNotes.Text;
            
            _receivingManager = new ReceivingManager();
            VendorOrderManager _vendorOrderManager = new VendorOrderManager();
            

            vendorOrder = _vendorOrderManager.getVendorOrder(Int32.Parse(txtVendorOrderID.Text.ToString()));
            

            VendorOrderLineItem vendorOrderLineItem = new VendorOrderLineItem(Int32.Parse(txtVendorOrderID.Text), Int32.Parse(txtProductID.Text));

            vendorOrderLineItem.Note = note;
            _receivingManager.UpdateLineItemNote(vendorOrderLineItem, note);
            MessageBox.Show("Note added to line item");
            
            frmReceiving _frmReceiving = new frmReceiving(vendorOrder);
            _frmReceiving.Show();
            _frmReceiving.BringToFront();
            this.Close();
            
            
        }



        private void frmReceivingNotes_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
