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
       

        public frmReceivingNotes(int vendorOrder, int productID)
        {
            InitializeComponent();
            txtVendorOrderID.Text = vendorOrder.ToString();
            txtProductID.Text = productID.ToString();
        }

        private void btnUpdatedNote_Click(object sender, EventArgs e)
        {
            var note = txtNotes.Text;
            
            _receivingManager = new ReceivingManager();
            vendorOrder.VendorID = Int32.Parse(txtVendorOrderID.Text);
            vendorOrderLineItem.ProductID = Int32.Parse(txtProductID.Text);

            //_receivingManager.AddNotes(note, vendorOrder, vendorOrderLineItem);
            
            
        }

    }
}
