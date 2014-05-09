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

//Author: Justin
//Date Created: 4/10/14
//Last Modified: 5/7/14
//Last Modified By: Justin Pitts

namespace com.Farouche
{
    public partial class frmReceivingNotes : Form
    {
        private readonly AccessToken _myAccessToken;
        private VendorOrder vendorOrder;
        private VendorOrderLineItem vendorOrderLineItem;
        private ReceivingManager _receivingManager;


        public frmReceivingNotes(int vendorOrderID, int productID, int vendorID, string note, AccessToken acctkn)
        {
            InitializeComponent();
            _myAccessToken = acctkn;
            txtVendorOrderID.Text = vendorOrderID.ToString();
            txtProductID.Text = productID.ToString();
            txtVendorID.Text = vendorID.ToString();
            txtNotes.Text = note;
            
        }



        private void btnUpdatedNote_Click(object sender, EventArgs e)
        {
            var note = txtNotes.Text;
            
            _receivingManager = new ReceivingManager();
            VendorOrderManager _vendorOrderManager = new VendorOrderManager();
            

            vendorOrder = new VendorOrder(Int32.Parse(txtVendorOrderID.Text.ToString()),Int32.Parse(txtVendorID.Text.ToString()));
            

            VendorOrderLineItem vendorOrderLineItem = new VendorOrderLineItem(Int32.Parse(txtVendorOrderID.Text), Int32.Parse(txtProductID.Text));

            vendorOrderLineItem.Note = note;
            _receivingManager.UpdateLineItemNote(vendorOrderLineItem, note);
            MessageBox.Show("Note added to Order");
           
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
