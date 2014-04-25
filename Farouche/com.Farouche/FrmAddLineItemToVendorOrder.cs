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
    public partial class FrmAddLineItemToVendorOrder : Form
    {
        public FrmAddLineItemToVendorOrder(VendorOrder vendorOrder)
        {
            InitializeComponent();

            txtVendorOrderID.Text = vendorOrder.Id.ToString();
        }

       
    }
}
