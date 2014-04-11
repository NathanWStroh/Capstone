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
 
    public partial class frmReorderChangeLevels : Form
    {
        //private Product _myProduct;
        //public frmReorderChangeLevels(Product prod)
        //{
        //    InitializeComponent();
        //    _myProduct = prod;
        //}

        private void frmReorderChangeLevels_Load(object sender, EventArgs e)
        {
            //txtProduct.Text = _myProduct.Name;

            //txtROThreshold.Text = _myProduct._reorderThreshold.ToString();
            //numericROThreshold.Value = _myProduct._reorderThreshold;

            //txtROAmount.Text = _myProduct._reorderAmount.ToString();
            //numericROAmount.Increment = _myProduct._reorderAmount;
            //numericROAmount.Value = _myProduct._reorderAmount;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //var newROAmount = numericROAmount.Value % _myProduct._reorderAmount;
            //if (newROAmount != 0)
            //{
            //    newROAmount = newROAmount * _myProduct._reorderAmount;
            //    MessageBox.Show("Unable to break cases\n Please pick a number that is evenly divisible by the case", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //}
            //else
            //{
            //    this.Close();
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
