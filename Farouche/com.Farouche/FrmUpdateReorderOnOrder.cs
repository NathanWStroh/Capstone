using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.Farouche.BusinessLogic;

namespace com.Farouche
{
    public partial class FrmUpdateReorderOnOrder : Form
    {
        private int? _currentAmount;
        private int _currentProduct;
        private ProductManager _productManager;

        public FrmUpdateReorderOnOrder(int? currentReorderAmount, int currentProductID)
        {
            InitializeComponent();
            _currentAmount = currentReorderAmount;
            _currentProduct = currentProductID;
        }

        private void FrmUpdateReorderOnOrder_Load(object sender, EventArgs e)
        {
            _productManager = new ProductManager();
            txtAmount.Text = _currentAmount.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int value;
                bool valid = int.TryParse(txtAmount.Text, out value);
                if (valid)
                {
                    if (_productManager.UpdateOnOrder(value, _currentProduct))
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("The on order amount was updated.");
                    }
                    else
                    {
                        MessageBox.Show("The on order amount was not updated.\nPlease try again.");
                    }
                }
                else
                {
                    MessageBox.Show("The on order amount was invalid. Please enter an integer value");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has Occured. Error Message: " + ex.Message);
            }
        }
    }
}
